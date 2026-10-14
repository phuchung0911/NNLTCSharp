using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BTVN2
{
    public class frmBaitap1 : Form
    {
        private Label lblHoTen, lblMaSV, lblGioiTinh, lblNgoaiNgu, lblDanToc;
        private TextBox txtHoTen, txtMaSV;
        private RadioButton radNam, radNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cboDanToc;
        private ListView lsvSinhVien;
        private Button btnThem, btnXoa, btnSua;
        private ContextMenuStrip cmsListView;

        public frmBaitap1()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "frmBaitap1";
            this.Size = new Size(580, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Ô nhập liệu
            lblHoTen = new Label() { Text = "Họ và Tên", Location = new Point(35, 20), AutoSize = true };
            txtHoTen = new TextBox() { Location = new Point(135, 17), Size = new Size(380, 23) };

            lblMaSV = new Label() { Text = "Mã sinh viên", Location = new Point(35, 55), AutoSize = true };
            txtMaSV = new TextBox() { Location = new Point(135, 52), Size = new Size(380, 23) };

            lblGioiTinh = new Label() { Text = "Giới tính", Location = new Point(35, 90), AutoSize = true };
            radNam = new RadioButton() { Text = "Nam", Location = new Point(135, 88), AutoSize = true, Checked = true };
            radNu = new RadioButton() { Text = "Nữ", Location = new Point(220, 88), AutoSize = true };

            lblNgoaiNgu = new Label() { Text = "Ngoại ngữ", Location = new Point(35, 125), AutoSize = true };
            chkAnh = new CheckBox() { Text = "Anh", Location = new Point(135, 124), AutoSize = true, Checked = true };
            chkPhap = new CheckBox() { Text = "Pháp", Location = new Point(220, 124), AutoSize = true };
            chkHoa = new CheckBox() { Text = "Hoa", Location = new Point(305, 124), AutoSize = true };

            lblDanToc = new Label() { Text = "Dân tộc", Location = new Point(35, 160), AutoSize = true };
            cboDanToc = new ComboBox() { Location = new Point(135, 157), Size = new Size(380, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cboDanToc.Items.AddRange(new object[] { "Kinh", "Hoa", "K'Me", "H'Mông", "Tày", "Khác" });
            cboDanToc.SelectedIndex = 0;

            // ListView
            lsvSinhVien = new ListView()
            {
                Location = new Point(35, 195),
                Size = new Size(480, 180),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lsvSinhVien.Columns.Add("Họ tên", 120);
            lsvSinhVien.Columns.Add("Mã sinh viên", 90);
            lsvSinhVien.Columns.Add("Giới tính", 70);
            lsvSinhVien.Columns.Add("Ngoại ngữ", 110);
            lsvSinhVien.Columns.Add("Dân tộc", 80);

            // Menu chuột phải
            cmsListView = new ContextMenuStrip();
            ToolStripMenuItem mnuXoa = new ToolStripMenuItem("Xóa sinh viên");
            mnuXoa.Click += (s, e) => XoaSinhVien();
            cmsListView.Items.Add(mnuXoa);
            lsvSinhVien.ContextMenuStrip = cmsListView;

            // Các nút Thêm, Xóa, Sửa
            btnThem = new Button() { Text = "Thêm", Location = new Point(110, 395), Size = new Size(90, 32) };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(230, 395), Size = new Size(90, 32) };
            btnSua = new Button() { Text = "Sửa", Location = new Point(350, 395), Size = new Size(90, 32) };

            btnThem.Click += BtnThem_Click;
            btnXoa.Click += (s, e) => XoaSinhVien();
            btnSua.Click += BtnSua_Click;
            lsvSinhVien.SelectedIndexChanged += LsvSinhVien_SelectedIndexChanged;

            this.Controls.AddRange(new Control[] {
                lblHoTen, txtHoTen, lblMaSV, txtMaSV, lblGioiTinh, radNam, radNu,
                lblNgoaiNgu, chkAnh, chkPhap, chkHoa, lblDanToc, cboDanToc,
                lsvSinhVien, btnThem, btnXoa, btnSua
            });
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Mã sinh viên!", "Thông báo");
                txtHoTen.Focus();
                return;
            }

            foreach (ListViewItem it in lsvSinhVien.Items)
            {
                if (string.Compare(it.SubItems[1].Text, maSV, true) == 0)
                {
                    MessageBox.Show("Mã sinh viên này đã tồn tại, không được thêm trùng!", "Lỗi trùng mã");
                    txtMaSV.Focus();
                    return;
                }
            }

            List<string> nn = new List<string>();
            if (chkAnh.Checked) nn.Add("Anh");
            if (chkPhap.Checked) nn.Add("Pháp");
            if (chkHoa.Checked) nn.Add("Hoa");

            ListViewItem item = new ListViewItem(hoTen);
            item.SubItems.Add(maSV);
            item.SubItems.Add(radNam.Checked ? "Nam" : "Nữ");
            item.SubItems.Add(string.Join(", ", nn));
            item.SubItems.Add(cboDanToc.SelectedItem.ToString());

            lsvSinhVien.Items.Add(item);
            txtHoTen.Clear();
            txtMaSV.Clear();
            txtHoTen.Focus();
        }

        private void LsvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvSinhVien.SelectedItems[0];
                txtHoTen.Text = item.SubItems[0].Text;
                txtMaSV.Text = item.SubItems[1].Text;
                txtMaSV.ReadOnly = true;

                if (item.SubItems[2].Text == "Nam") radNam.Checked = true;
                else radNu.Checked = true;

                chkAnh.Checked = item.SubItems[3].Text.Contains("Anh");
                chkPhap.Checked = item.SubItems[3].Text.Contains("Pháp");
                chkHoa.Checked = item.SubItems[3].Text.Contains("Hoa");
                cboDanToc.SelectedItem = item.SubItems[4].Text;
            }
            else
            {
                txtMaSV.ReadOnly = false;
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo");
                return;
            }

            ListViewItem item = lsvSinhVien.SelectedItems[0];
            item.SubItems[0].Text = txtHoTen.Text.Trim();
            item.SubItems[2].Text = radNam.Checked ? "Nam" : "Nữ";

            List<string> nn = new List<string>();
            if (chkAnh.Checked) nn.Add("Anh");
            if (chkPhap.Checked) nn.Add("Pháp");
            if (chkHoa.Checked) nn.Add("Hoa");

            item.SubItems[3].Text = string.Join(", ", nn);
            item.SubItems[4].Text = cboDanToc.SelectedItem.ToString();
            MessageBox.Show("Cập nhật sinh viên thành công!");
        }

        private void XoaSinhVien()
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa sinh viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lsvSinhVien.Items.Remove(lsvSinhVien.SelectedItems[0]);
                txtHoTen.Clear();
                txtMaSV.Clear();
                txtMaSV.ReadOnly = false;
            }
        }
    }
}