using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai3
{
    public class GiaoDienBai3 : Form
    {
        private Label lblTieuDe;
        private Label lblA, lblB, lblUCLN, lblBCNN;
        private TextBox txtA, txtB, txtUCLN, txtBCNN;
        private Button btnThucHien, btnTiepTuc, btnThoat;

        public GiaoDienBai3()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Ước Số - Bội Số";
            this.Size = new Size(390, 310);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "Ước Số Chung - Bội Số Chung",
                ForeColor = Color.Red,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(45, 18),
                AutoSize = true
            };

            // nhập a
            lblA = new Label() { Text = "Nhập số a :", Location = new Point(40, 60), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtA = new TextBox() { Location = new Point(190, 57), Width = 140 };
            txtA.KeyPress += ChanKyTuSo_KeyPress;

            // nhập b
            lblB = new Label() { Text = "Nhập số b :", Location = new Point(40, 95), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtB = new TextBox() { Location = new Point(190, 92), Width = 140 };
            txtB.KeyPress += ChanKyTuSo_KeyPress;

            // Kết quả UCLN
            lblUCLN = new Label() { Text = "Ước số chung lớn nhất :", Location = new Point(40, 132), AutoSize = true };
            txtUCLN = new TextBox() { Location = new Point(190, 129), Width = 140, ReadOnly = true };

            // Kết quả BCNN
            lblBCNN = new Label() { Text = "Bội số chung nhỏ nhất :", Location = new Point(40, 168), AutoSize = true };
            txtBCNN = new TextBox() { Location = new Point(190, 165), Width = 140, ReadOnly = true };

            // Các nút chức năng
            btnThucHien = new Button() { Text = "Thực Hiện", Location = new Point(40, 215), Size = new Size(85, 32) };
            btnTiepTuc = new Button() { Text = "Tiếp Tục", Location = new Point(145, 215), Size = new Size(85, 32) };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(245, 215), Size = new Size(85, 32) };

            btnThucHien.Click += BtnThucHien_Click;
            btnTiepTuc.Click += BtnTiepTuc_Click;
            btnThoat.Click += (s, e) => this.Close();

            // Thêm các control vào Form
            this.Controls.AddRange(new Control[] {
                lblTieuDe,
                lblA, txtA,
                lblB, txtB,
                lblUCLN, txtUCLN,
                lblBCNN, txtBCNN,
                btnThucHien, btnTiepTuc, btnThoat
            });

            this.FormClosing += GiaoDienBai3_FormClosing;
        }

        // Chặn nhập ký tự ko phải số nguyên dương
        private void ChanKyTuSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra và tính toán khi bấm nút thực hiện
        private void BtnThucHien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ cả hai số a và b!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(txtA.Text, out long a) || !long.TryParse(txtB.Text, out long b))
            {
                MessageBox.Show("Dữ liệu nhập vào phải là số nguyên hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (a == 0 && b == 0)
            {
                MessageBox.Show("Không thể tìm UCLN và BCNN khi cả hai số đều bằng 0!", "Lỗi toán học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UocBoiSo tinh = new UocBoiSo(a, b);
            txtUCLN.Text = tinh.TimUCLN().ToString();
            txtBCNN.Text = tinh.TimBCNN().ToString();
        }

        // Xóa trắng form để nhập lượt mới khi bấm nút tiếp tục
        private void BtnTiepTuc_Click(object sender, EventArgs e)
        {
            txtA.Clear();
            txtB.Clear();
            txtUCLN.Clear();
            txtBCNN.Clear();
            txtA.Focus();
        }

        // Hỏi xác nhận khi thoát chương trình
        private void GiaoDienBai3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}