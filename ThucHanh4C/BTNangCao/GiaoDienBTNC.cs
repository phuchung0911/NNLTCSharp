using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTNangCao
{
    public class GiaoDienBTNC : Form
    {
        private QuanLyRapPhim quanLy = new QuanLyRapPhim();

        // Mảng 15 nút đại diện cho 15 ghế
        private Button[] btnGhe = new Button[16];

        private Label lblTieuDe, lblThanhTien;
        private TextBox txtThanhTien;
        private Button btnChon, btnHuyBo, btnKetThuc;

        public GiaoDienBTNC()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "BÁN VÉ RẠP CHIẾU BÓNG";
            this.Size = new Size(390, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "MÀN ẢNH",
                ForeColor = Color.Orange,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(135, 12),
                AutoSize = true
            };

            Panel pnlVien = new Panel()
            {
                Location = new Point(25, 45),
                Size = new Size(325, 2),
                BackColor = Color.Silver
            };

            // Tạo 15 nút ghế tự động theo ma trận 3 hàng x 5 cột
            int batDauX = 35;
            int batDauY = 60;
            int chieuRong = 55;
            int chieuCao = 45;
            int khoangCach = 10;

            for (int i = 1; i <= 15; i++)
            {
                int hang = (i - 1) / 5;
                int cot = (i - 1) % 5;

                btnGhe[i] = new Button()
                {
                    Text = i.ToString(),
                    Tag = i,
                    Size = new Size(chieuRong, chieuCao),
                    Location = new Point(batDauX + cot * (chieuRong + khoangCach), batDauY + hang * (chieuCao + khoangCach)),
                    BackColor = Color.White,
                    Font = new Font("Arial", 11, FontStyle.Bold)
                };

                btnGhe[i].Click += BtnGhe_Click;
                this.Controls.Add(btnGhe[i]);
            }

            // Vùng hiển thị Thành Tiền
            lblThanhTien = new Label()
            {
                Text = "Thành Tiền:",
                Location = new Point(35, 245),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            txtThanhTien = new TextBox()
            {
                Location = new Point(130, 242),
                Size = new Size(220, 23),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            txtThanhTien.Text = "0";

            // Các nút chức năng
            btnChon = new Button() { Text = "Chọn", Location = new Point(35, 290), Size = new Size(95, 35) };
            btnHuyBo = new Button() { Text = "Hủy bỏ", Location = new Point(145, 290), Size = new Size(95, 35) };
            btnKetThuc = new Button() { Text = "Kết thúc", Location = new Point(255, 290), Size = new Size(95, 35) };

            btnChon.Click += BtnChon_Click;
            btnHuyBo.Click += BtnHuyBo_Click;
            btnKetThuc.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                lblTieuDe, pnlVien, lblThanhTien, txtThanhTien,
                btnChon, btnHuyBo, btnKetThuc
            });

            this.FormClosing += GiaoDienBTNC_FormClosing;
        }

        // Xử lý khi click vào từng ghế ngồi
        private void BtnGhe_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int soGhe = (int)btn.Tag;
            int trangThai = quanLy.GetTrangThai(soGhe);

            // TH1: Ghế đã bán (màu vàng)
            if (trangThai == 2)
            {
                MessageBox.Show($"Ghế số {soGhe} đã được bán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TH2: Ghế chưa bán (màu trắng) > chuyển sang Đang chọn (màu xanh)
            if (trangThai == 0)
            {
                quanLy.SetTrangThai(soGhe, 1);
                btn.BackColor = Color.Blue;
                btn.ForeColor = Color.White;
            }
            // TH3: Ghế đang chọn (màu xanh) > hủy chọn về màu trắng
            else if (trangThai == 1)
            {
                quanLy.SetTrangThai(soGhe, 0);
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
        }

        // Thanh toán và chuyển ghế đang chọn sang màu vàng (đã bán) khi bấm nút chọn
        private void BtnChon_Click(object sender, EventArgs e)
        {
            int tongTien = quanLy.TinhTongTienDangChon();

            if (tongTien == 0)
            {
                MessageBox.Show("Vui lòng click chọn ít nhất một vị trí ghế trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Đổi màu các ghế đang chọn (màu xanh) sang màu vàng (đã bán)
            for (int i = 1; i <= 15; i++)
            {
                if (quanLy.GetTrangThai(i) == 1)
                {
                    btnGhe[i].BackColor = Color.Yellow;
                    btnGhe[i].ForeColor = Color.Black;
                }
            }

            // Xuất tổng tiền và chốt bán vé
            txtThanhTien.Text = $"{tongTien:N0} VNĐ";
            quanLy.XacNhanBanVe();
        }

        // Hủy các ghế đang chọn về lại màu trắng khi bấm nút hủy
        private void BtnHuyBo_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
            {
                if (quanLy.GetTrangThai(i) == 1)
                {
                    btnGhe[i].BackColor = Color.White;
                    btnGhe[i].ForeColor = Color.Black;
                }
            }

            quanLy.HuyBoChonVe();
            txtThanhTien.Text = "0";
        }

        // Hỏi xác nhận đóng chương trình
        private void GiaoDienBTNC_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn kết thúc chương trình bán vé không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}