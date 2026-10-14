using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai1
{
    public class GiaoDienBai1 : Form
    {
        private QuanLySinhVien ql = new QuanLySinhVien();

        private Label lblHoTen, lblMaSV, lblGioiTinh, lblNgoaiNgu, lblDanToc;
        private TextBox txtHoTen, txtMaSV;
        private RadioButton radNam, radNu;
        private CheckBox chkAnh, chkPhap, chkHoa;
        private ComboBox cboDanToc;

        // ListView hiển thị danh sách
        private ListView lsvSinhVien;

        // Các nút chức năng
        private Button btnThem, btnXoa, btnSua;

        // ContextMenuStrip chuột phải trên ListView
        private ContextMenuStrip cmsListView;
        private ToolStripMenuItem mnuXoaContext;

        public GiaoDienBai1()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "frmBaitap1";
            this.Size = new Size(580, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Nhập Họ và Tên
            lblHoTen = new Label() { Text = "Họ và Tên", Location = new Point(40, 25), AutoSize = true };
            txtHoTen = new TextBox() { Location = new Point(140, 22), Size = new Size(360, 23) };

            // Nhập Mã sinh viên
            lblMaSV = new Label() { Text = "Mã sinh viên", Location = new Point(40, 65), AutoSize = true };
            txtMaSV = new TextBox() { Location = new Point(140, 62), Size = new Size(360, 23) };

            // Giới tính 
            lblGioiTinh = new Label() { Text = "Giới tính", Location = new Point(40, 105), AutoSize = true };
            radNam = new RadioButton() { Text = "Nam", Location = new Point(140, 103), AutoSize = true, Checked = true };
            radNu = new RadioButton() { Text = "Nữ", Location = new Point(230, 103), AutoSize = true };

            // Ngoại ngữ 
            lblNgoaiNgu = new Label() { Text = "Ngoại ngữ", Location = new Point(40, 140), AutoSize = true };
            chkAnh = new CheckBox() { Text = "Anh", Location = new Point(140, 139), AutoSize = true, Checked = true };
            chkPhap = new CheckBox() { Text = "Pháp", Location = new Point(230, 139), AutoSize = true };
            chkHoa = new CheckBox() { Text = "Hoa", Location = new Point(320, 139), AutoSize = true };

            // Dân tộc 
            lblDanToc = new Label() { Text = "Dân tộc", Location = new Point(40, 175), AutoSize = true };
            cboDanToc = new ComboBox()
            {
                Location = new Point(140, 172),
                Size = new Size(360, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // ListView cấu hình dạng bảng 
            lsvSinhVien = new ListView()
            {
                Location = new Point(40, 215),
                Size = new Size(480, 180),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                MultiSelect = false
            };

            // Thiết lập các cột
            lsvSinhVien.Columns.Add("Họ tên", 120);
            lsvSinhVien.Columns.Add("Mã sinh viên", 90);
            lsvSinhVien.Columns.Add("Giới tính", 70);
            lsvSinhVien.Columns.Add("Ngoại ngữ", 110);
            lsvSinhVien.Columns.Add("Dân tộc", 80);

            lsvSinhVien.SelectedIndexChanged += LsvSinhVien_SelectedIndexChanged;

            // ContextMenuStrip để xóa khi kích chuột phải vào ListView
            cmsListView = new ContextMenuStrip();
            mnuXoaContext = new ToolStripMenuItem("Xóa sinh viên");
            mnuXoaContext.Click += (s, e) => ThucHienXoa();
            cmsListView.Items.Add(mnuXoaContext);
            lsvSinhVien.ContextMenuStrip = cmsListView;

            // Các nút chức năng Thêm, Xóa, Sửa
            btnThem = new Button() { Text = "Thêm", Location = new Point(110, 415), Size = new Size(95, 35) };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(230, 415), Size = new Size(95, 35) };
            btnSua = new Button() { Text = "Sửa", Location = new Point(350, 415), Size = new Size(95, 35) };

            btnThem.Click += BtnThem_Click;
            btnXoa.Click += (s, e) => ThucHienXoa();
            btnSua.Click += BtnSua_Click;

            this.Controls.AddRange(new Control[] {
                lblHoTen, txtHoTen, lblMaSV, txtMaSV,
                lblGioiTinh, radNam, radNu,
                lblNgoaiNgu, chkAnh, chkPhap, chkHoa,
                lblDanToc, cboDanToc,
                lsvSinhVien,
                btnThem, btnXoa, btnSua
            });

            this.Load += GiaoDienBai1_Load;
            this.FormClosing += GiaoDienBai1_FormClosing;
        }

        // Nạp danh sách dân tộc khi Form khởi động
        private void GiaoDienBai1_Load(object sender, EventArgs e)
        {
            string[] danToc = { "Kinh", "Hoa", "K'Me", "H'Mông", "Tày", "Khác" };
            foreach (string dt in danToc)
            {
                cboDanToc.Items.Add(dt);
            }
            cboDanToc.SelectedIndex = 0;
        }

        // Lấy chuỗi các ngoại ngữ được tích chọn
        private string LayChuoiNgoaiNgu()
        {
            List<string> ds = new List<string>();
            if (chkAnh.Checked) ds.Add("Anh");
            if (chkPhap.Checked) ds.Add("Pháp");
            if (chkHoa.Checked) ds.Add("Hoa");
            return string.Join(", ", ds);
        }

        // Nút Thêm: kiểm tra dữ liệu và chống trùng mã SV
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

            if (ql.KiemTraTrungMa(maSV))
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại, không được thêm trùng!", "Lỗi trùng mã");
                txtMaSV.Focus();
                return;
            }

            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string ngoaiNgu = LayChuoiNgoaiNgu();
            string danToc = cboDanToc.SelectedItem.ToString();

            SinhVien sv = new SinhVien(hoTen, maSV, gioiTinh, ngoaiNgu, danToc);
            ql.Them(sv);

            // Thêm một dòng (ListViewItem) vào ListView
            ListViewItem item = new ListViewItem(sv.HoTen);
            item.SubItems.Add(sv.MaSV);
            item.SubItems.Add(sv.GioiTinh);
            item.SubItems.Add(sv.NgoaiNgu);
            item.SubItems.Add(sv.DanToc);

            lsvSinhVien.Items.Add(item);

            LamMoiForm();
            MessageBox.Show("Thêm sinh viên thành công!");
        }

        // Chọn một dòng trên ListView: đổ thông tin lên các ô nhập
        private void LsvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvSinhVien.SelectedItems[0];
                txtHoTen.Text = item.SubItems[0].Text;
                txtMaSV.Text = item.SubItems[1].Text;
                txtMaSV.ReadOnly = true; // Đề bài yêu cầu: Không cho sửa Mã sinh viên

                if (item.SubItems[2].Text == "Nam") radNam.Checked = true;
                else radNu.Checked = true;

                string ngoaiNgu = item.SubItems[3].Text;
                chkAnh.Checked = ngoaiNgu.Contains("Anh");
                chkPhap.Checked = ngoaiNgu.Contains("Pháp");
                chkHoa.Checked = ngoaiNgu.Contains("Hoa");

                cboDanToc.SelectedItem = item.SubItems[4].Text;
            }
            else
            {
                txtMaSV.ReadOnly = false;
            }
        }

        // Nút Sửa: cập nhật thông tin dòng đang chọn (không đổi mã SV)
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa trong danh sách!", "Thông báo");
                return;
            }

            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Họ và tên không được để trống!", "Thông báo");
                txtHoTen.Focus();
                return;
            }

            ListViewItem item = lsvSinhVien.SelectedItems[0];
            string maSV = item.SubItems[1].Text; // Giữ nguyên mã SV gốc

            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            string ngoaiNgu = LayChuoiNgoaiNgu();
            string danToc = cboDanToc.SelectedItem.ToString();

            SinhVien svMoi = new SinhVien(hoTen, maSV, gioiTinh, ngoaiNgu, danToc);
            ql.Sua(svMoi);

            // Cập nhật lại trên ListView
            item.SubItems[0].Text = svMoi.HoTen;
            item.SubItems[2].Text = svMoi.GioiTinh;
            item.SubItems[3].Text = svMoi.NgoaiNgu;
            item.SubItems[4].Text = svMoi.DanToc;

            LamMoiForm();
            MessageBox.Show("Cập nhật thông tin thành công!");
        }

        // Hàm dùng chung cho nút Xóa và ContextMenuStrip xóa chuột phải
        private void ThucHienXoa()
        {
            if (lsvSinhVien.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo");
                return;
            }

            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên đang chọn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                ListViewItem item = lsvSinhVien.SelectedItems[0];
                string maSV = item.SubItems[1].Text;

                ql.Xoa(maSV);
                lsvSinhVien.Items.Remove(item);

                LamMoiForm();
                MessageBox.Show("Đã xóa sinh viên!");
            }
        }

        private void LamMoiForm()
        {
            txtHoTen.Clear();
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false;
            radNam.Checked = true;
            chkAnh.Checked = true;
            chkPhap.Checked = false;
            chkHoa.Checked = false;
            cboDanToc.SelectedIndex = 0;
            txtHoTen.Focus();
        }

        // Xác nhận trước khi đóng chương trình
        private void GiaoDienBai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn đóng form không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}