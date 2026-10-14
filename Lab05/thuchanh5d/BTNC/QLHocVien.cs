using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BTNC
{
    public class frmQuanLyHocVien : Form
    {
        private QuanLyHocVien ql = new QuanLyHocVien();

        // MenuStrip
        private MenuStrip mnuMain;
        private ToolStripMenuItem mnuCapNhat, mnuKetThuc;
        private ToolStripMenuItem mnuNhapMoi, mnuChuyenSangB, mnuChuyenSangA, mnuXoaHocVien;

        // Điều khiển giao diện 2 lớp
        private Label lblLopA, lblLopB;
        private ListBox lstLopA, lstLopB;

        public frmQuanLyHocVien()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Quản lý học viên";
            this.Size = new Size(480, 380);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Tạo MenuStrip
            mnuMain = new MenuStrip();

            // Menu Cập nhật
            mnuCapNhat = new ToolStripMenuItem("Cập nhật");
            mnuNhapMoi = new ToolStripMenuItem("Nhập học viên mới");
            mnuChuyenSangB = new ToolStripMenuItem("Chuyển sang lớp B");
            mnuChuyenSangA = new ToolStripMenuItem("Chuyển sang lớp A");
            mnuXoaHocVien = new ToolStripMenuItem("Xóa học viên");

            mnuCapNhat.DropDownItems.AddRange(new ToolStripItem[] {
                mnuNhapMoi, mnuChuyenSangB, mnuChuyenSangA, mnuXoaHocVien
            });

            // Menu Kết thúc
            mnuKetThuc = new ToolStripMenuItem("Kết thúc");

            mnuMain.Items.AddRange(new ToolStripItem[] { mnuCapNhat, mnuKetThuc });
            this.MainMenuStrip = mnuMain;

            // Gắn sự kiện Menu
            mnuKetThuc.Click += (s, e) => this.Close();
            mnuNhapMoi.Click += MnuNhapMoi_Click;
            mnuChuyenSangB.Click += MnuChuyenSangB_Click;
            mnuChuyenSangA.Click += MnuChuyenSangA_Click;
            mnuXoaHocVien.Click += MnuXoaHocVien_Click;

            // Giao diện 2 ListBox bên dưới
            lblLopA = new Label() { Text = "Lớp A", Location = new Point(35, 45), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            lstLopA = new ListBox()
            {
                Location = new Point(35, 70),
                Size = new Size(180, 240),
                SelectionMode = SelectionMode.MultiExtended, // Cho phép chọn nhiều mục
                Font = new Font("Arial", 10)
            };

            lblLopB = new Label() { Text = "Lớp B", Location = new Point(250, 45), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            lstLopB = new ListBox()
            {
                Location = new Point(250, 70),
                Size = new Size(180, 240),
                SelectionMode = SelectionMode.MultiExtended,
                Font = new Font("Arial", 10)
            };

            this.Controls.AddRange(new Control[] { mnuMain, lblLopA, lstLopA, lblLopB, lstLopB });

            this.FormClosing += FrmQuanLyHocVien_FormClosing;
        }

        // Đồng bộ dữ liệu từ QuanLyHocVien lên 2 ListBox
        private void CapNhatListBoxes()
        {
            lstLopA.BeginUpdate();
            lstLopA.Items.Clear();
            foreach (var ten in ql.DanhSachLopA) lstLopA.Items.Add(ten);
            lstLopA.EndUpdate();

            lstLopB.BeginUpdate();
            lstLopB.Items.Clear();
            foreach (var ten in ql.DanhSachLopB) lstLopB.Items.Add(ten);
            lstLopB.EndUpdate();
        }

        // Menu: Nhập học viên mới > Mở form con
        private void MnuNhapMoi_Click(object sender, EventArgs e)
        {
            frmNhapHocVien fNhap = new frmNhapHocVien();
            // Lắng nghe sự kiện truyền dữ liệu từ form con
            fNhap.OnThemHocVien = (hoTen, lop) =>
            {
                ql.ThemHocVien(hoTen, lop);
                CapNhatListBoxes();
            };
            fNhap.ShowDialog();
        }

        // Menu: Chuyển sang lớp B (Lấy các mục đang chọn từ Lớp A chuyển sang Lớp B)
        private void MnuChuyenSangB_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên ở Lớp A cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> dsChon = new List<string>();
            foreach (var item in lstLopA.SelectedItems)
            {
                dsChon.Add(item.ToString());
            }

            ql.ChuyenLop(dsChon, ql.DanhSachLopA, ql.DanhSachLopB);
            CapNhatListBoxes();
        }

        // Menu: Chuyển sang lớp A (Lấy các mục đang chọn từ Lớp B chuyển sang Lớp A)
        private void MnuChuyenSangA_Click(object sender, EventArgs e)
        {
            if (lstLopB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên ở Lớp B cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> dsChon = new List<string>();
            foreach (var item in lstLopB.SelectedItems)
            {
                dsChon.Add(item.ToString());
            }

            ql.ChuyenLop(dsChon, ql.DanhSachLopB, ql.DanhSachLopA);
            CapNhatListBoxes();
        }

        // Menu: Xóa học viên (Xóa tất cả các học viên đang chọn ở cả Lớp A và Lớp B)
        private void MnuXoaHocVien_Click(object sender, EventArgs e)
        {
            if (lstLopA.SelectedItems.Count == 0 && lstLopB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một học viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn xóa các học viên đang chọn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                // Xóa ở Lớp A
                List<string> dsChonA = new List<string>();
                foreach (var item in lstLopA.SelectedItems) dsChonA.Add(item.ToString());
                ql.XoaHocVien(dsChonA, ql.DanhSachLopA);

                // Xóa ở Lớp B
                List<string> dsChonB = new List<string>();
                foreach (var item in lstLopB.SelectedItems) dsChonB.Add(item.ToString());
                ql.XoaHocVien(dsChonB, ql.DanhSachLopB);

                CapNhatListBoxes();
                MessageBox.Show("Đã xóa học viên được chọn thành công!", "Thông báo");
            }
        }

        // Hỏi xác nhận trước khi thoát chương trình
        private void FrmQuanLyHocVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn kết thúc chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}