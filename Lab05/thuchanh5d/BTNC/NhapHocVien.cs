using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTNC
{
    public class frmNhapHocVien : Form
    {
        private Label lblHoTen, lblLop;
        private TextBox txtHoTen;
        private ComboBox cboLop;
        private Button btnCapNhat, btnTroVe;

        // Delegate để truyền dữ liệu học viên mới về Form chính
        public delegate void TruyenDuLieuHocVien(string hoTen, string lop);
        public TruyenDuLieuHocVien OnThemHocVien;

        public frmNhapHocVien()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Nhập học viên mới";
            this.Size = new Size(380, 230);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Nhập họ tên
            lblHoTen = new Label() { Text = "Họ và Tên", Location = new Point(30, 30), AutoSize = true, Font = new Font("Arial", 10) };
            txtHoTen = new TextBox() { Location = new Point(120, 27), Size = new Size(210, 23), Font = new Font("Arial", 10) };

            // chọn lớp
            lblLop = new Label() { Text = "Lớp", Location = new Point(30, 75), AutoSize = true, Font = new Font("Arial", 10) };
            cboLop = new ComboBox()
            {
                Location = new Point(120, 72),
                Size = new Size(210, 23),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 10)
            };
            cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            cboLop.SelectedIndex = 0;

            // Nút Cập nhật và Trở về
            btnCapNhat = new Button() { Text = "Cập nhật", Location = new Point(120, 125), Size = new Size(95, 32), Font = new Font("Arial", 10) };
            btnTroVe = new Button() { Text = "Trở về", Location = new Point(235, 125), Size = new Size(95, 32), Font = new Font("Arial", 10) };

            btnCapNhat.Click += BtnCapNhat_Click;
            btnTroVe.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { lblHoTen, txtHoTen, lblLop, cboLop, btnCapNhat, btnTroVe });
        }

        // Xử lý nút Cập nhật 
        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();

            // Nếu Họ và Tên rỗng: báo lỗi và đặt con trỏ vào ô nhập
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên học viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // Nếu Họ và Tên hợp lệ: truyền thông tin về Form chính
            string lop = cboLop.SelectedItem.ToString();
            if (OnThemHocVien != null)
            {
                OnThemHocVien(hoTen, lop);
            }

            // Xóa trắng để tiếp tục nhập học viên khác
            txtHoTen.Clear();
            txtHoTen.Focus();
            MessageBox.Show($"Đã thêm học viên vào {lop} thành công!", "Thông báo");
        }
    }
}