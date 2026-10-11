using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai1
{
    public class GiaoDienBai1 : Form
    {
        private Label lblTieuDe;
        private GroupBox grpChon;
        private RadioButton radBacNhat, radBacHai;
        private Label lblA, lblB, lblC, lblKetQua;
        private TextBox txtA, txtB, txtC, txtKetQua;
        private Button btnGiai, btnThoat;

        public GiaoDienBai1()
        {
            // Cài đặt form
            this.Text = "Giải phương trình bậc 1-2";
            this.Size = new Size(380, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTieuDe = new Label()
            {
                Text = "GIẢI PHƯƠNG TRÌNH", // tạo tiêu đề
                ForeColor = Color.Red,
                Font = new Font("Arial", 15, FontStyle.Bold),
                Location = new Point(70, 18),
                AutoSize = true
            };

            // tạo box chọn loại phương trình
            grpChon = new GroupBox()
            {
                Text = "Bạn vui lòng chọn",
                Location = new Point(25, 55),
                Size = new Size(310, 85)
            };

            radBacNhat = new RadioButton()
            {
                Text = "Phương trình bậc nhất",
                Location = new Point(20, 22),
                AutoSize = true,
                Checked = true
            };

            radBacHai = new RadioButton()
            {
                Text = "Phương trình bậc hai",
                Location = new Point(20, 50),
                AutoSize = true
            };

            radBacNhat.CheckedChanged += ChonLoaiPT_CheckedChanged;
            radBacHai.CheckedChanged += ChonLoaiPT_CheckedChanged;

            grpChon.Controls.Add(radBacNhat);
            grpChon.Controls.Add(radBacHai);

            // Các ô nhập a, b, c
            lblA = new Label() { Text = "Nhập a", Location = new Point(25, 160), AutoSize = true };
            txtA = new TextBox() { Location = new Point(85, 157), Width = 135 };

            lblB = new Label() { Text = "Nhập b", Location = new Point(25, 195), AutoSize = true };
            txtB = new TextBox() { Location = new Point(85, 192), Width = 135 };

            lblC = new Label() { Text = "Nhập c", Location = new Point(25, 230), AutoSize = true, Enabled = false };
            txtC = new TextBox() { Location = new Point(85, 227), Width = 135, Enabled = false };

            txtA.TextChanged += DuLieu_TextChanged;
            txtB.TextChanged += DuLieu_TextChanged;
            txtC.TextChanged += DuLieu_TextChanged;

            txtA.KeyPress += ChanChu_KeyPress;
            txtB.KeyPress += ChanChu_KeyPress;
            txtC.KeyPress += ChanChu_KeyPress;

            // nút giải và thoát
            btnGiai = new Button()
            {
                Text = "Giải",
                Location = new Point(235, 157),
                Size = new Size(100, 58),
                Enabled = false
            };

            btnThoat = new Button()
            {
                Text = "Thoát",
                Location = new Point(235, 225),
                Size = new Size(100, 30)
            };

            btnGiai.Click += btnGiai_Click;
            btnThoat.Click += (s, e) => this.Close();

            // Kết quả
            lblKetQua = new Label() { Text = "Kết quả", Location = new Point(25, 275), AutoSize = true };
            txtKetQua = new TextBox()
            {
                Location = new Point(25, 300),
                Size = new Size(310, 115),
                Multiline = true,
                ReadOnly = true
            };

            // Thêm các thành phần vào Form
            this.Controls.AddRange(new Control[] {
                lblTieuDe, grpChon, lblA, txtA, lblB, txtB, lblC, txtC,
                btnGiai, btnThoat, lblKetQua, txtKetQua
            });

            this.FormClosing += GiaoDienBai1_FormClosing;
        }

        // ẩn, hiện ô c
        private void ChonLoaiPT_CheckedChanged(object sender, EventArgs e)
        {
            bool laBacHai = radBacHai.Checked;
            lblC.Enabled = laBacHai;
            txtC.Enabled = laBacHai;
            if (!laBacHai) txtC.Clear();

            KiemTraDuLieu();
        }
        
        // bật nút giải khi đã nhập đầy đủ các ô
        private void DuLieu_TextChanged(object sender, EventArgs e)
        {
            KiemTraDuLieu();
        }

        // chặn nhập chữ cái ko phải số
        private void KiemTraDuLieu()
        {
            if (radBacNhat.Checked)
                btnGiai.Enabled = (txtA.Text != "" && txtB.Text != "");
            else
                btnGiai.Enabled = (txtA.Text != "" && txtB.Text != "" && txtC.Text != "");
        }

        private void ChanChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void btnGiai_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);

                if (radBacNhat.Checked)
                {
                    PhuongTrinhBacHai pt = new PhuongTrinhBacHai(a, b);
                    txtKetQua.Text = pt.GiaiBacNhat();
                }
                else
                {
                    double c = double.Parse(txtC.Text);
                    PhuongTrinhBacHai pt = new PhuongTrinhBacHai(a, b, c);
                    txtKetQua.Text = pt.GiaiBacHai();
                }

                btnGiai.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số!");
            }
        }

        // Xác nhận trước khi đóng ứng dụng
        private void GiaoDienBai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}