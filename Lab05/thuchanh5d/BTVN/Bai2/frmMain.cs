using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTVN2
{
    public class frmMain : Form
    {
        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuBai1, mnuBai2;

        public frmMain()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "BTVN_Tuan6";
            this.Size = new Size(820, 640);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true; // Thiết lập form cha đa giao diện (MDI Container)

            // Khởi tạo MenuStrip
            mnuMain = new MenuStrip();

            mnuBai1 = new ToolStripMenuItem("Bài 1");
            mnuBai1.Click += MnuBai1_Click;

            mnuBai2 = new ToolStripMenuItem("Bài 2");
            mnuBai2.Click += MnuBai2_Click;

            mnuMain.Items.AddRange(new ToolStripItem[] { mnuBai1, mnuBai2 });
            this.MainMenuStrip = mnuMain;

            this.Controls.Add(mnuMain);
            this.FormClosing += FrmMain_FormClosing;
        }

        // Mở Form Bài 1: Quản lý sinh viên
        private void MnuBai1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmBaitap1)
                {
                    f.Activate();
                    return;
                }
            }

            frmBaitap1 form1 = new frmBaitap1();
            form1.MdiParent = this;
            form1.Show();
        }

        // Mở Form Bài 2: Quản lý tài khoản
        private void MnuBai2_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f is frmBaiTap2)
                {
                    f.Activate();
                    return;
                }
            }

            frmBaiTap2 form2 = new frmBaiTap2();
            form2.MdiParent = this;
            form2.Show();
        }

        // Xác nhận khi thoát chương trình
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình BTVN_Tuan6 không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}