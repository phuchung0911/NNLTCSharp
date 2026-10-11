using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTVeNha
{
    public class GiaoDienBTVN : Form
    {
        private MayTinhBoTui mayTinh = new MayTinhBoTui();

        private Label lblTieuDe;
        private TextBox txtManHinh;

        public GiaoDienBTVN()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Máy Tính Bỏ Túi";
            this.Size = new Size(330, 410);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "Máy Tính Bỏ Túi",
                ForeColor = Color.Red,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(55, 15),
                AutoSize = true
            };

            // Màn hình 
            txtManHinh = new TextBox()
            {
                Location = new Point(25, 55),
                Size = new Size(265, 30),
                ReadOnly = true,
                TextAlign = HorizontalAlignment.Right,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Text = "0"
            };

            this.Controls.Add(lblTieuDe);
            this.Controls.Add(txtManHinh);

            // Tạo các nút bấm theo lưới 4 hàng x 4 cột
            string[,] banPhim = new string[4, 4]
            {
                { "1", "2", "3", "4" },
                { "5", "6", "7", "8" },
                { "9", "0", "=", "C" },
                { "+", "-", "*", "/" }
            };

            int startX = 25;
            int startY = 105;
            int btnWidth = 60;
            int btnHeight = 50;
            int khoangCach = 8;

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 4; c++)
                {
                    string giaTriNut = banPhim[r, c];
                    Button btn = new Button()
                    {
                        Text = giaTriNut,
                        Size = new Size(btnWidth, btnHeight),
                        Location = new Point(startX + c * (btnWidth + khoangCach), startY + r * (btnHeight + khoangCach)),
                        Font = new Font("Arial", 12, FontStyle.Bold),
                        BackColor = Color.WhiteSmoke
                    };

                    btn.Click += BtnBanPhim_Click;
                    this.Controls.Add(btn);
                }
            }

            this.FormClosing += GiaoDienBTVN_FormClosing;
        }

        // Xử lý sự kiện khi bấm nút trên bàn phím máy tính
        private void BtnBanPhim_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string phim = btn.Text;

            // Nhóm phím số từ 0-9
            if (char.IsDigit(phim[0]))
            {
                if (txtManHinh.Text == "0" || mayTinh.DangChoSoMoi)
                {
                    txtManHinh.Text = phim;
                    mayTinh.DangChoSoMoi = false;
                }
                else
                {
                    txtManHinh.Text += phim;
                }
            }
            // phím c (xóa)
            else if (phim == "C")
            {
                mayTinh.Reset();
                txtManHinh.Text = "0";
            }
            // phím = (dấu bằng)
            else if (phim == "=")
            {
                if (mayTinh.PhepToan != ' ')
                {
                    try
                    {
                        double soThuHai = double.Parse(txtManHinh.Text);
                        double ketQua = mayTinh.TinhToan(soThuHai);

                        txtManHinh.Text = ketQua.ToString();
                        mayTinh.Reset();
                        mayTinh.DangChoSoMoi = true;
                    }
                    catch (DivideByZeroException ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi toán học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtManHinh.Text = "0";
                        mayTinh.Reset();
                    }
                }
            }
            // Nhóm phím phép tính +, -, *, /
            else
            {
                mayTinh.SoThuNhat = double.Parse(txtManHinh.Text);
                mayTinh.PhepToan = phim[0];
                mayTinh.DangChoSoMoi = true;
            }
        }

        // Xác nhận trước khi đóng chương trình
        private void GiaoDienBTVN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình Máy Tính không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}