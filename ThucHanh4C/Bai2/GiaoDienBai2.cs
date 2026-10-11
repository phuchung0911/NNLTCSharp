using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai2
{
    public class GiaoDienBai2 : Form
    {
        private Label lblTieuDe;
        private Label lblTenDangNhap, lblEmail, lblMatKhau, lblXacNhanMK;
        private Label lblSao1, lblSao2, lblSao3;
        private TextBox txtTenDangNhap, txtEmail, txtMatKhau, txtXacNhanMK;
        private Button btnDangKy;
        private ErrorProvider epKiemTra;

        public GiaoDienBai2()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Đăng ký tài khoản";
            this.Size = new Size(390, 310);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            epKiemTra = new ErrorProvider();

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "Đăng ký tài khoản",
                ForeColor = Color.DodgerBlue,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(105, 15),
                AutoSize = true
            };

            // Tên đăng nhập
            lblTenDangNhap = new Label() { Text = "Tên đăng nhập", Location = new Point(25, 58), AutoSize = true };
            txtTenDangNhap = new TextBox() { Location = new Point(135, 55), Width = 190 };
            lblSao1 = new Label() { Text = "(*)", ForeColor = Color.Red, Location = new Point(330, 58), AutoSize = true };

            // Địa chỉ email
            lblEmail = new Label() { Text = "Địa chỉ email", Location = new Point(25, 98), AutoSize = true };
            txtEmail = new TextBox() { Location = new Point(135, 95), Width = 190 };
            lblSao2 = new Label() { Text = "(*)", ForeColor = Color.Red, Location = new Point(330, 98), AutoSize = true };
            txtEmail.Leave += TxtEmail_Leave;

            // Mật khẩu
            lblMatKhau = new Label() { Text = "Mật khẩu", Location = new Point(25, 138), AutoSize = true };
            txtMatKhau = new TextBox() { Location = new Point(135, 135), Width = 190, PasswordChar = '*' };
            lblSao3 = new Label() { Text = "(*)", ForeColor = Color.Red, Location = new Point(330, 138), AutoSize = true };

            // Xác nhận mật khẩu
            lblXacNhanMK = new Label() { Text = "Xác nhận mật khẩu", Location = new Point(25, 178), AutoSize = true };
            txtXacNhanMK = new TextBox() { Location = new Point(135, 175), Width = 190, PasswordChar = '*' };
            txtXacNhanMK.KeyDown += TxtXacNhanMK_KeyDown;

            // Nút Đăng ký
            btnDangKy = new Button()
            {
                Text = "Đăng ký",
                Location = new Point(135, 215),
                Size = new Size(190, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnDangKy.Click += BtnDangKy_Click;

            // Thêm control vào Form
            this.Controls.AddRange(new Control[] {
                lblTieuDe,
                lblTenDangNhap, txtTenDangNhap, lblSao1,
                lblEmail, txtEmail, lblSao2,
                lblMatKhau, txtMatKhau, lblSao3,
                lblXacNhanMK, txtXacNhanMK,
                btnDangKy
            });

            this.FormClosing += GiaoDienBai2_FormClosing;
        }

        // Kiểm tra định dạng email khi rời khỏi textbox Email
        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!KiemTraTaiKhoan.KiemTraEmail(txtEmail.Text))
                {
                    epKiemTra.SetError(txtEmail, "Địa chỉ email không đúng định dạng!");
                }
                else
                {
                    epKiemTra.SetError(txtEmail, "");
                }
            }
        }

        // Nhấn phím Enter tại ô Xác nhận mật khẩu sẽ thực hiện đăng ký
        private void TxtXacNhanMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThucHienDangKy();
                e.SuppressKeyPress = true; // Chặn tiếng kêu beep của hệ thống
            }
        }

        // Sự kiện click nút Đăng ký
        private void BtnDangKy_Click(object sender, EventArgs e)
        {
            ThucHienDangKy();
        }

        // Thực hiện kiểm tra toàn bộ thông tin và hiển thị MessageBox
        private void ThucHienDangKy()
        {
            // Kiểm tra bắt buộc các trường có dấu *
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Địa chỉ email!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!KiemTraTaiKhoan.KiemTraEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ!", "Sai định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // Kiểm tra khớp mật khẩu
            if (txtMatKhau.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Mật khẩu và Xác nhận mật khẩu không trùng khớp!", "Lỗi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMK.Focus();
                return;
            }

            // Hiển thị thông tin đăng ký thành công lên MessageBox
            string thongTin = $"ĐĂNG KÝ THÀNH CÔNG!\n\n" +
                              $"Tên đăng nhập: {txtTenDangNhap.Text}\n" +
                              $"Địa chỉ email: {txtEmail.Text}\n" +
                              $"Mật khẩu: {txtMatKhau.Text}";

            MessageBox.Show(thongTin, "Thông tin tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Hỏi xác nhận trước khi đóng form
        private void GiaoDienBai2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}