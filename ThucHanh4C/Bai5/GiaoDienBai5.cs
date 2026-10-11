using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai5
{
    public class GiaoDienBai5 : Form
    {
        private Label lblTieuDe;
        private Label lblNhapDaySo;
        private TextBox txtNhapSo;
        private Button btnThucHien, btnXoa, btnThoat;
        private Label lblKetQua;

        public GiaoDienBai5()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Đọc Chữ Số";
            this.Size = new Size(390, 240);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "Đọc Số Thành Chữ",
                ForeColor = Color.Red,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(95, 15),
                AutoSize = true
            };

            // Ô nhập số
            lblNhapDaySo = new Label()
            {
                Text = "Nhập dãy số : ( từ 1 đến 999 )",
                Location = new Point(25, 60),
                AutoSize = true,
                Font = new Font("Arial", 9, FontStyle.Regular)
            };

            txtNhapSo = new TextBox()
            {
                Location = new Point(220, 57),
                Width = 120
            };
            txtNhapSo.KeyPress += ChanKyTuSo_KeyPress;
            txtNhapSo.KeyDown += TxtNhapSo_KeyDown;

            // Các nút bấm chức năng
            btnThucHien = new Button() { Text = "Thực hiện", Location = new Point(30, 100), Size = new Size(95, 32) };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(135, 100), Size = new Size(95, 32) };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(245, 100), Size = new Size(95, 32) };

            btnThucHien.Click += BtnThucHien_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += (s, e) => this.Close();

            // Nhãn hiển thị kết quả đọc chữ
            lblKetQua = new Label()
            {
                Location = new Point(30, 150),
                Size = new Size(310, 32),
                BackColor = Color.PeachPuff,
                ForeColor = Color.DarkBlue,
                Font = new Font("Arial", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            this.Controls.AddRange(new Control[] {
                lblTieuDe, lblNhapDaySo, txtNhapSo,
                btnThucHien, btnXoa, btnThoat, lblKetQua
            });

            this.FormClosing += GiaoDienBai5_FormClosing;
        }

        // Chặn phím nhập ký tự ko phải số nguyên dương
        private void ChanKyTuSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Nhấn phím Enter để thực hiện đọc số ngay lập tức
        private void TxtNhapSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnThucHien_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        // kiểm tra số hợp lệ từ 1 đến 999 và đọc thành chữ khi bấm nút thực hiện
        private void BtnThucHien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapSo.Text))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên từ 1 đến 999!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.Focus();
                return;
            }

            if (int.TryParse(txtNhapSo.Text.Trim(), out int n))
            {
                if (n >= 1 && n <= 999)
                {
                    lblKetQua.Text = "  " + DocSo.ChuyenSoThanhChu(n);
                }
                else
                {
                    MessageBox.Show("Chỉ được nhập số trong khoảng từ 1 đến 999!", "Lỗi phạm vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNhapSo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // trả form về trạng thái ban đầu khi bấm nút xóa
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            txtNhapSo.Clear();
            lblKetQua.Text = "";
            txtNhapSo.Focus();
        }

        // Hỏi xác nhận trước khi đóng chườn tình
        private void GiaoDienBai5_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}