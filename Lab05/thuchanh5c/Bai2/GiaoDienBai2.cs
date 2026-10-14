using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai2
{
    public class GiaoDienBai2 : Form
    {
        // Khai báo các điều khiển trên Form theo đề bài
        private TreeView trvLop;
        private ComboBox cboLop;
        private Label lblChonLop;

        // Nhóm thông tin sinh viên
        private GroupBox grpTTSV;
        private Label lblMaSV, lblHoTen, lblDiaChi;
        private TextBox txtMaSV, txtHoTen, txtDiaChi;
        private Button btnCapNhat, btnXoa;

        // Nhóm thêm lớp mới
        private CheckBox chkThemLop;
        private GroupBox grpThemLop;
        private Label lblTenLop;
        private TextBox txtTenLop;
        private Button btnThemLop;

        public GiaoDienBai2()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Quản lý sinh viên";
            this.Size = new Size(680, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 1. Cây danh sách lớp bên trái
            trvLop = new TreeView()
            {
                Location = new Point(15, 15),
                Size = new Size(230, 420)
            };
            trvLop.AfterSelect += TrvLop_AfterSelect;

            // 2. Ô chọn lớp bên phải
            lblChonLop = new Label() { Text = "Chọn Lớp", Location = new Point(270, 20), AutoSize = true };
            cboLop = new ComboBox()
            {
                Location = new Point(350, 17),
                Size = new Size(280, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // 3. Khung nhập thông tin sinh viên
            grpTTSV = new GroupBox()
            {
                Text = "Thông tin sinh viên",
                Location = new Point(270, 60),
                Size = new Size(370, 180)
            };

            lblMaSV = new Label() { Text = "Mã SV:", Location = new Point(20, 30), AutoSize = true };
            txtMaSV = new TextBox() { Location = new Point(90, 27), Size = new Size(250, 23) };

            lblHoTen = new Label() { Text = "Họ Tên:", Location = new Point(20, 65), AutoSize = true };
            txtHoTen = new TextBox() { Location = new Point(90, 62), Size = new Size(250, 23) };

            lblDiaChi = new Label() { Text = "Địa Chỉ:", Location = new Point(20, 100), AutoSize = true };
            txtDiaChi = new TextBox() { Location = new Point(90, 97), Size = new Size(250, 23) };

            btnCapNhat = new Button() { Text = "Cập Nhật", Location = new Point(110, 135), Size = new Size(90, 30) };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(220, 135), Size = new Size(90, 30) };

            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa.Click += BtnXoa_Click;

            grpTTSV.Controls.AddRange(new Control[] {
                lblMaSV, txtMaSV, lblHoTen, txtHoTen, lblDiaChi, txtDiaChi,
                btnCapNhat, btnXoa
            });

            // 4. CheckBox để ẩn hoặc hiện khung thêm lớp
            chkThemLop = new CheckBox()
            {
                Text = "Thêm lớp",
                Location = new Point(270, 255),
                AutoSize = true,
                Checked = false
            };
            chkThemLop.CheckedChanged += ChkThemLop_CheckedChanged;

            // 5. Khung thêm lớp
            grpThemLop = new GroupBox()
            {
                Text = "Thông tin lớp",
                Location = new Point(270, 285),
                Size = new Size(370, 100),
                Visible = false
            };

            lblTenLop = new Label() { Text = "Tên lớp:", Location = new Point(20, 35), AutoSize = true };
            txtTenLop = new TextBox() { Location = new Point(90, 32), Size = new Size(250, 23) };
            btnThemLop = new Button() { Text = "Thêm lớp", Location = new Point(240, 62), Size = new Size(100, 28) };
            btnThemLop.Click += BtnThemLop_Click;

            grpThemLop.Controls.AddRange(new Control[] { lblTenLop, txtTenLop, btnThemLop });

            this.Controls.AddRange(new Control[] {
                trvLop, lblChonLop, cboLop, grpTTSV, chkThemLop, grpThemLop
            });

            this.Load += GiaoDienBai2_Load;
            this.FormClosing += GiaoDienBai2_FormClosing;
        }

        // Khi chạy chương trình: nạp sẵn danh sách lớp mẫu vào TreeView và ComboBox
        private void GiaoDienBai2_Load(object sender, EventArgs e)
        {
            // Tạo nút gốc
            TreeNode goc = new TreeNode("Danh sách lớp");
            trvLop.Nodes.Add(goc);

            // Danh sách các lớp ban đầu trong tài liệu
            string[] cacLop = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };

            foreach (string lop in cacLop)
            {
                goc.Nodes.Add(lop); // Thêm vào nhánh của TreeView
                cboLop.Items.Add(lop); // Thêm vào danh sách chọn ComboBox
            }

            goc.Expand(); // Mở rộng nhánh để thấy các lớp
            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0; // Chọn sẵn lớp đầu tiên
            }
        }

        // Tích chọn thì hiện khung thông tin lớp, bỏ tích thì ẩn đi
        private void ChkThemLop_CheckedChanged(object sender, EventArgs e)
        {
            grpThemLop.Visible = chkThemLop.Checked;
        }

        // Nút Thêm lớp: kiểm tra trùng tên trước khi thêm
        private void BtnThemLop_Click(object sender, EventArgs e)
        {
            string tenLopMoi = txtTenLop.Text.Trim();

            if (tenLopMoi == "")
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo");
                txtTenLop.Focus();
                return;
            }

            // So sánh chuỗi không phân biệt hoa thường để chống trùng lớp
            foreach (var item in cboLop.Items)
            {
                if (string.Compare(item.ToString(), tenLopMoi, true) == 0)
                {
                    MessageBox.Show("Tên lớp này đã tồn tại rồi!", "Báo lỗi");
                    txtTenLop.Focus();
                    return;
                }
            }

            // Thêm vào nhánh gốc của TreeView và thêm vào ComboBox
            trvLop.Nodes[0].Nodes.Add(tenLopMoi);
            cboLop.Items.Add(tenLopMoi);
            cboLop.SelectedItem = tenLopMoi; // Tự động chọn lớp mới thêm

            MessageBox.Show("Thêm lớp thành công!");
            txtTenLop.Clear();
        }

        // Nút Cập Nhật: thêm sinh viên vào lớp đang chọn
        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            // Kiểm tra không được để trống ô nào
            if (txtMaSV.Text.Trim() == "" || txtHoTen.Text.Trim() == "" || txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã SV, Họ Tên và Địa Chỉ!", "Thông báo");
                return;
            }

            if (cboLop.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn lớp nào!", "Thông báo");
                return;
            }

            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string lopDangChon = cboLop.SelectedItem.ToString();

            // Kiểm tra không được trùng mã sinh viên trên toàn bộ cây
            if (KiemTraTrungMaSV(trvLop.Nodes[0], maSV))
            {
                MessageBox.Show("Mã sinh viên này đã có rồi, vui lòng đổi mã khác!", "Báo lỗi");
                txtMaSV.Focus();
                return;
            }

            // Tìm đúng nhánh lớp đang chọn để gắn sinh viên vào
            foreach (TreeNode nodeLop in trvLop.Nodes[0].Nodes)
            {
                if (nodeLop.Text == lopDangChon)
                {
                    // Nút sinh viên có định dạng: "Mã SV, Họ Tên"
                    TreeNode nodeSV = new TreeNode(maSV + ", " + hoTen);
                    nodeSV.Tag = maSV; // Lưu riêng mã SV vào Tag để tiện kiểm tra và lấy lại

                    // Nút con bên dưới lưu địa chỉ
                    TreeNode nodeDiaChi = new TreeNode(diaChi);
                    nodeSV.Nodes.Add(nodeDiaChi);

                    nodeLop.Nodes.Add(nodeSV);
                    nodeLop.Expand(); // Mở nhánh ra để nhìn thấy sinh viên vừa thêm
                    break;
                }
            }

            MessageBox.Show("Thêm sinh viên thành công!");

            // Xóa trắng ô nhập để tiếp tục nhập người khác
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtMaSV.Focus();
        }

        // Hàm kiểm tra trùng mã sinh viên bằng cách duyệt các nút
        private bool KiemTraTrungMaSV(TreeNode goc, string maSV)
        {
            foreach (TreeNode n in goc.Nodes)
            {
                // Nếu nút có lưu mã SV mà trùng khớp thì báo true
                if (n.Tag != null && n.Tag.ToString() == maSV)
                {
                    return true;
                }
                // Tìm tiếp các nút con bên dưới
                if (KiemTraTrungMaSV(n, maSV)) return true;
            }
            return false;
        }

        // Khi nhấp chuột vào một nút trên cây: hiển thị thông tin lên các ô bên phải
        private void TrvLop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode nodeDuocChon = e.Node;

            // Chỉ xử lý khi nhấp đúng vào nút sinh viên (có chứa Tag là mã SV)
            if (nodeDuocChon != null && nodeDuocChon.Tag != null)
            {
                txtMaSV.Text = nodeDuocChon.Tag.ToString();

                // Chuỗi trên nút là "Mã SV, Họ Tên" nên tách chuỗi theo dấu phẩy
                string[] thongTin = nodeDuocChon.Text.Split(',');
                if (thongTin.Length > 1)
                {
                    txtHoTen.Text = thongTin[1].Trim();
                }

                // Nút con đầu tiên chính là địa chỉ
                if (nodeDuocChon.Nodes.Count > 0)
                {
                    txtDiaChi.Text = nodeDuocChon.Nodes[0].Text;
                }

                // Chọn đúng lớp của sinh viên này trên ComboBox
                if (nodeDuocChon.Parent != null)
                {
                    cboLop.SelectedItem = nodeDuocChon.Parent.Text;
                }
            }
        }

        // Nút Xóa: chỉ cho xóa nút là sinh viên và hỏi xác nhận trước
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            TreeNode nodeDuocChon = trvLop.SelectedNode;

            // Kiểm tra xem người dùng có đang chọn đúng nút sinh viên không
            if (nodeDuocChon == null || nodeDuocChon.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trên danh sách để xóa!", "Thông báo");
                return;
            }

            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                nodeDuocChon.Remove(); // Xóa khỏi TreeView
                // Làm sạch các ô nhập
                txtMaSV.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();
                MessageBox.Show("Đã xóa sinh viên!");
            }
        }

        // Xác nhận trước khi đóng chương trình
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