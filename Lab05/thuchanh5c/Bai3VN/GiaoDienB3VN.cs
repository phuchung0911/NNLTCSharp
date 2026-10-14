using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTVN3
{
    public class GiaoDienB3VN : Form
    {
        private TreeView trvDanhBa;
        private Label lblFirstName, lblLastName;
        private TextBox txtFirstName, txtLastName;
        private Button btnAdd, btnExit;

        public GiaoDienB3VN()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "frmBTVN2";
            this.Size = new Size(540, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Cây danh bạ bên trái
            trvDanhBa = new TreeView()
            {
                Location = new Point(15, 15),
                Size = new Size(200, 410),
                Font = new Font("Arial", 11, FontStyle.Regular)
            };

            // Khu vực nhập liệu bên phải
            lblFirstName = new Label()
            {
                Text = "First Name",
                Location = new Point(240, 45),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            txtFirstName = new TextBox()
            {
                Location = new Point(330, 42),
                Size = new Size(170, 23),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            lblLastName = new Label()
            {
                Text = "Last Name",
                Location = new Point(240, 95),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            txtLastName = new TextBox()
            {
                Location = new Point(330, 92),
                Size = new Size(170, 23),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            btnAdd = new Button()
            {
                Text = "Add",
                Location = new Point(410, 140),
                Size = new Size(90, 32),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            btnAdd.Click += BtnAdd_Click;

            btnExit = new Button()
            {
                Text = "Exit",
                Location = new Point(410, 210),
                Size = new Size(90, 32),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            btnExit.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                trvDanhBa, lblFirstName, txtFirstName,
                lblLastName, txtLastName, btnAdd, btnExit
            });

            // Gán sự kiện Load và Closing
            this.Load += GiaoDienB3VN_Load;
            this.FormClosing += GiaoDienB3VN_FormClosing;
        }

        // Khi mở Form: khởi tạo các nút từ A đến Z trên TreeView
        private void GiaoDienB3VN_Load(object sender, EventArgs e)
        {
            trvDanhBa.Nodes.Clear();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                TreeNode node = new TreeNode(c.ToString());
                node.Name = c.ToString(); // Đặt name để dễ tìm kiếm nút
                trvDanhBa.Nodes.Add(node);
            }
        }

        // Nút Add: thêm người mới vào đúng nút chữ cái đầu của First Name
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            // Kiểm tra không để trống ô nhập
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ First Name và Last Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }

            NguoiDanhBa nguoiMoi = new NguoiDanhBa(firstName, lastName);
            char kyTuDau = nguoiMoi.LayKyTuDau();

            // Tìm nút cha tương ứng với ký tự đầu trên TreeView
            TreeNode[] danhSachNodeTimThay = trvDanhBa.Nodes.Find(kyTuDau.ToString(), false);

            if (danhSachNodeTimThay.Length > 0)
            {
                TreeNode nodeCha = danhSachNodeTimThay[0];

                // Kiểm tra xem người này đã tồn tại trong nhánh chữ cái này chưa
                string chuoiHienThi = nguoiMoi.LayChuoiHienThi();
                foreach (TreeNode nodeCon in nodeCha.Nodes)
                {
                    if (string.Compare(nodeCon.Text, chuoiHienThi, true) == 0)
                    {
                        MessageBox.Show("Người này đã có trong danh bạ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Thêm nút con mới vào nút cha
                TreeNode nodeConMoi = new TreeNode(chuoiHienThi);
                nodeCha.Nodes.Add(nodeConMoi);

                // Mở rộng nút cha để người dùng thấy ngay kết quả
                nodeCha.Expand();

                // Chọn nút vừa thêm
                trvDanhBa.SelectedNode = nodeConMoi;

                // Xóa trắng ô nhập và đặt con trỏ chuột quay lại First Name
                txtFirstName.Clear();
                txtLastName.Clear();
                txtFirstName.Focus();
            }
            else
            {
                MessageBox.Show("Tên phải bắt đầu bằng chữ cái từ A đến Z!", "Lỗi ký tự", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
            }
        }

        // Xác nhận trước khi đóng chương trình
        private void GiaoDienB3VN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình danh bạ không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}