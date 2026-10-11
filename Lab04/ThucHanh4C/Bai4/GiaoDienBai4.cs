using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai4
{
    public class GiaoDienBai4 : Form
    {
        private DaySo ds = new DaySo();

        private Label lblTieuDe;
        private Label lblNhapSo, lblDayVuaNhap, lblTongDay, lblTongChan, lblTongLe;
        private TextBox txtNhapSo, txtDayVuaNhap, txtTongDay, txtTongChan, txtTongLe;
        private Button btnNhap, btnTiepTuc, btnThoat;

        public GiaoDienBai4()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Dãy số và Tính Tổng";
            this.Size = new Size(390, 330);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "Nhập Dãy Số và Tính Tổng",
                ForeColor = Color.Red,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(45, 18),
                AutoSize = true
            };

            // Nhập số và nút Nhập
            lblNhapSo = new Label() { Text = "Nhập số :", Location = new Point(35, 60), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtNhapSo = new TextBox() { Location = new Point(145, 57), Width = 100 };
            txtNhapSo.KeyPress += ChanKyTuSo_KeyPress;
            txtNhapSo.KeyDown += TxtNhapSo_KeyDown;

            btnNhap = new Button() { Text = "Nhập", Location = new Point(260, 55), Size = new Size(80, 27) };
            btnNhap.Click += BtnNhap_Click;

            // Dãy vừa nhập
            lblDayVuaNhap = new Label() { Text = "Dãy vừa nhập :", Location = new Point(35, 95), AutoSize = true };
            txtDayVuaNhap = new TextBox() { Location = new Point(145, 92), Width = 195, ReadOnly = true };

            // Tổng các phần tử
            lblTongDay = new Label() { Text = "Tổng các phần tử trong dãy :", Location = new Point(35, 130), AutoSize = true };
            txtTongDay = new TextBox() { Location = new Point(220, 127), Width = 120, ReadOnly = true };

            // Tổng chẵn và Tổng lẻ
            lblTongChan = new Label() { Text = "Tổng Chẵn :", Location = new Point(35, 165), AutoSize = true };
            txtTongChan = new TextBox() { Location = new Point(115, 162), Width = 60, ReadOnly = true };

            lblTongLe = new Label() { Text = "Tổng Lẻ :", Location = new Point(195, 165), AutoSize = true };
            txtTongLe = new TextBox() { Location = new Point(260, 162), Width = 80, ReadOnly = true };

            // Nút Tiếp Tục và Thoát
            btnTiepTuc = new Button() { Text = "Tiếp Tục", Location = new Point(90, 220), Size = new Size(90, 32) };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(210, 220), Size = new Size(90, 32) };

            btnTiepTuc.Click += BtnTiepTuc_Click;
            btnThoat.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                lblTieuDe,
                lblNhapSo, txtNhapSo, btnNhap,
                lblDayVuaNhap, txtDayVuaNhap,
                lblTongDay, txtTongDay,
                lblTongChan, txtTongChan, lblTongLe, txtTongLe,
                btnTiepTuc, btnThoat
            });

            this.FormClosing += GiaoDienBai4_FormClosing;
        }

        // Chặn nhập ký tự chữ cái 
        private void ChanKyTuSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '-' && tb.SelectionStart == 0 && !tb.Text.Contains("-")) return;
            e.Handled = true;
        }

        // Hỗ trợ gõ Enter tại ô nhập số để nạp luôn vào dãy
        private void TxtNhapSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnNhap_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        // Xử lý nạp số và tự động cập nhật lại các giá trị tổng
        private void BtnNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapSo.Text))
            {
                MessageBox.Show("Vui lòng nhập một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapSo.Focus();
                return;
            }

            if (int.TryParse(txtNhapSo.Text.Trim(), out int so))
            {
                ds.ThemSo(so);

                // Cập nhật dãy hiển thị
                txtDayVuaNhap.Text = ds.XuatDaySo();

                // Tự động tính và cập nhật các tổng
                txtTongDay.Text = ds.TinhTongTatCa().ToString();
                txtTongChan.Text = ds.TinhTongChan().ToString();
                txtTongLe.Text = ds.TinhTongLe().ToString();

                // Xóa ô nhập để nhập số tiếp theo
                txtNhapSo.Clear();
                txtNhapSo.Focus();
            }
            else
            {
                MessageBox.Show("Giá trị nhập không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa trắng toàn bộ khi bấm nút tiếp tục
        private void BtnTiepTuc_Click(object sender, EventArgs e)
        {
            ds.LamMoi();
            txtNhapSo.Clear();
            txtDayVuaNhap.Clear();
            txtTongDay.Clear();
            txtTongChan.Clear();
            txtTongLe.Clear();
            txtNhapSo.Focus();
        }

        // Hỏi xác nhận khi đóng chuong trình
        private void GiaoDienBai4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}