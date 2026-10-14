using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTVN1
{
    public class frmDongHo : Form
    {
        private BoDemNguoc boDem = new BoDemNguoc(30);
        
        private System.Windows.Forms.Timer timer1;

        private Label lblThoiGian;
        private Button btnDieuKhien;

        public frmDongHo()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Đồng hồ";
            this.Size = new Size(260, 180);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Nhãn hiển thị thời gian 30:00
            lblThoiGian = new Label()
            {
                Text = boDem.LayChuoiThoiGian(),
                Location = new Point(40, 25),
                Size = new Size(160, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 22, FontStyle.Bold),
                ForeColor = Color.Black
            };

            // Nút Bắt đầu / Tạm dừng
            btnDieuKhien = new Button()
            {
                Text = "Bắt đầu",
                Location = new Point(70, 80),
                Size = new Size(100, 35),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            btnDieuKhien.Click += BtnDieuKhien_Click;

            // Khởi tạo rõ ràng System.Windows.Forms.Timer
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000; // 1 giây gọi sự kiện Tick một lần[cite: 1, 14]
            timer1.Tick += Timer1_Tick;

            this.Controls.Add(lblThoiGian);
            this.Controls.Add(btnDieuKhien);

            this.FormClosing += FrmDongHo_FormClosing;
        }

        private void BtnDieuKhien_Click(object sender, EventArgs e)
        {
            if (boDem.DaHetGio())
            {
                boDem.DatLai();
                lblThoiGian.Text = boDem.LayChuoiThoiGian();
            }

            if (!timer1.Enabled)
            {
                timer1.Start();
                btnDieuKhien.Text = "Tạm dừng";
            }
            else
            {
                timer1.Stop();
                btnDieuKhien.Text = "Tiếp tục";
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (boDem.GiamMotGiay())
            {
                lblThoiGian.Text = boDem.LayChuoiThoiGian();
            }
            else
            {
                timer1.Stop();
                btnDieuKhien.Text = "Bắt đầu";
                MessageBox.Show("Đã hết thời gian 30 phút!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmDongHo_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }
    }
}