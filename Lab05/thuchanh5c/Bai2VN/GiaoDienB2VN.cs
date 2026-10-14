using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BTVN2
{
    public class GiaoDienB2VN : Form
    {
        private List<int> dsSo = new List<int>();

        // Tiêu đề và nhóm nhập liệu bên trái
        private Label lblTieuDe;
        private Label lblListBox;
        private TextBox txtNhap;
        private Button btnNhap;
        private ListBox lstSo;

        // Nhóm nút xử lý bên phải
        private Label lblXuLy;
        private Button btnTong;
        private Button btnXoaDauCuoi;
        private Button btnXoaDangChon;
        private Button btnTang2;
        private Button btnBinhPhuong;
        private Button btnChonChan;
        private Button btnChonLe;

        // Nút kết thúc
        private Button btnKetThuc;

        public GiaoDienB2VN()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "frmListbox";
            this.Size = new Size(520, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề chữ hoa lớn ở giữa form
            lblTieuDe = new Label()
            {
                Text = "LISTBOX",
                Location = new Point(190, 10),
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.OrangeRed
            };

            // Bên trái: Nhập số và ListBox
            lblListBox = new Label() { Text = "Listbox", Location = new Point(40, 45), AutoSize = true };
            
            txtNhap = new TextBox() { Location = new Point(40, 68), Size = new Size(130, 23) };
            txtNhap.KeyPress += TxtNhap_KeyPress;
            txtNhap.KeyDown += TxtNhap_KeyDown;

            btnNhap = new Button() { Text = "Nhập", Location = new Point(40, 98), Size = new Size(130, 28) };
            btnNhap.Click += BtnNhap_Click;

            // ListBox hỗ trợ chọn nhiều phần tử (MultiSimple)
            lstSo = new ListBox()
            {
                Location = new Point(40, 135),
                Size = new Size(130, 240),
                SelectionMode = SelectionMode.MultiSimple,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            // Bên phải: Các nút xử lý
            lblXuLy = new Label() { Text = "Xử lý Listbox", Location = new Point(220, 45), AutoSize = true };

            int startX = 220;
            int startY = 68;
            int btnW = 230;
            int btnH = 28;
            int cachY = 6;

            btnTong = TaoNut("Tổng các phần tử trong List", startX, startY, btnW, btnH);
            btnXoaDauCuoi = TaoNut("Xóa Phần tử đầu và cuối", startX, startY + (btnH + cachY) * 1, btnW, btnH);
            btnXoaDangChon = TaoNut("Xóa Phần tử đang chọn", startX, startY + (btnH + cachY) * 2, btnW, btnH);
            btnTang2 = TaoNut("Tăng mỗi phần tử lên 2", startX, startY + (btnH + cachY) * 3, btnW, btnH);
            btnBinhPhuong = TaoNut("Thay bằng bình phương", startX, startY + (btnH + cachY) * 4, btnW, btnH);
            btnChonChan = TaoNut("Chọn số chẵn", startX, startY + (btnH + cachY) * 5, btnW, btnH);
            btnChonLe = TaoNut("Chọn số lẻ", startX, startY + (btnH + cachY) * 6, btnW, btnH);

            // Gắn sự kiện các nút
            btnTong.Click += BtnTong_Click;
            btnXoaDauCuoi.Click += BtnXoaDauCuoi_Click;
            btnXoaDangChon.Click += BtnXoaDangChon_Click;
            btnTang2.Click += BtnTang2_Click;
            btnBinhPhuong.Click += BtnBinhPhuong_Click;
            btnChonChan.Click += BtnChonChan_Click;
            btnChonLe.Click += BtnChonLe_Click;

            // Nút KẾT THÚC
            btnKetThuc = new Button()
            {
                Text = "KẾT THÚC",
                Location = new Point(40, 390),
                Size = new Size(410, 35),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            btnKetThuc.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                lblTieuDe, lblListBox, txtNhap, btnNhap, lstSo,
                lblXuLy, btnTong, btnXoaDauCuoi, btnXoaDangChon, btnTang2,
                btnBinhPhuong, btnChonChan, btnChonLe, btnKetThuc
            });

            this.FormClosing += GiaoDienB2VN_FormClosing;
        }

        private Button TaoNut(string text, int x, int y, int w, int h)
        {
            return new Button()
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };
        }

        // Cập nhật lại toàn bộ danh sách hiển thị trên ListBox
        private void CapNhatListBox()
        {
            lstSo.BeginUpdate();
            lstSo.Items.Clear();
            foreach (int x in dsSo)
            {
                lstSo.Items.Add(x);
            }
            lstSo.EndUpdate();
        }

        // Chỉ cho phép nhập ký tự số nguyên
        private void TxtNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        // Nhấn phím Enter để thêm số nhanh
        private void TxtNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnNhap_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        // Nút Nhập: thêm số vào ListBox
        private void BtnNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập một số tự nhiên!", "Thông báo");
                txtNhap.Focus();
                return;
            }

            if (int.TryParse(txtNhap.Text.Trim(), out int giaTri))
            {
                dsSo.Add(giaTri);
                CapNhatListBox();
                txtNhap.Clear();
                txtNhap.Focus();
            }
            else
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!", "Lỗi");
                txtNhap.Focus();
            }
        }

        // Tính tổng các phần tử trong List, hiển thị lên MessageBox
        private void BtnTong_Click(object sender, EventArgs e)
        {
            if (dsSo.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!", "Thông báo");
                return;
            }

            long tong = XuLySoNguyen.TinhTong(dsSo);
            MessageBox.Show($"Tổng các phần tử trong List là: {tong}", "Kết quả");
        }

        // Xóa phần tử đầu và cuối của listbox
        private void BtnXoaDauCuoi_Click(object sender, EventArgs e)
        {
            if (dsSo.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!", "Thông báo");
                return;
            }

            if (dsSo.Count == 1)
            {
                dsSo.RemoveAt(0);
            }
            else
            {
                // Xóa phần tử cuối trước rồi mới xóa phần tử đầu để không bị lệch chỉ số
                dsSo.RemoveAt(dsSo.Count - 1);
                dsSo.RemoveAt(0);
            }

            CapNhatListBox();
        }

        // Xóa các phần tử đang chọn trong listbox
        private void BtnXoaDangChon_Click(object sender, EventArgs e)
        {
            if (lstSo.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một phần tử để xóa!", "Thông báo");
                return;
            }

            List<int> viTri = new List<int>();
            foreach (int idx in lstSo.SelectedIndices)
            {
                viTri.Add(idx);
            }
            viTri.Sort();

            // Duyệt ngược từ cuối về đầu để xóa an toàn
            for (int i = viTri.Count - 1; i >= 0; i--)
            {
                dsSo.RemoveAt(viTri[i]);
            }

            CapNhatListBox();
        }

        // Tăng giá trị mỗi phần tử lên 2
        private void BtnTang2_Click(object sender, EventArgs e)
        {
            if (dsSo.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!", "Thông báo");
                return;
            }

            XuLySoNguyen.TangLenHai(dsSo);
            CapNhatListBox();
        }

        // Thay mỗi giá trị bằng bình phương của chính nó
        private void BtnBinhPhuong_Click(object sender, EventArgs e)
        {
            if (dsSo.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!", "Thông báo");
                return;
            }

            XuLySoNguyen.ThayBangBinhPhuong(dsSo);
            CapNhatListBox();
        }

        // Thực hiện chọn các phần tử trong listbox là số chẵn
        private void BtnChonChan_Click(object sender, EventArgs e)
        {
            if (dsSo.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!", "Thông báo");
                return;
            }

            lstSo.ClearSelected();
            for (int i = 0; i < dsSo.Count; i++)
            {
                if (XuLySoNguyen.LaSoChan(dsSo[i]))
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }

        // Thực hiện chọn các phần tử trong listbox là số lẻ
        private void BtnChonLe_Click(object sender, EventArgs e)
        {
            if (dsSo.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!", "Thông báo");
                return;
            }

            lstSo.ClearSelected();
            for (int i = 0; i < dsSo.Count; i++)
            {
                if (XuLySoNguyen.LaSoLe(dsSo[i]))
                {
                    lstSo.SetSelected(i, true);
                }
            }
        }

        // Xác nhận trước khi đóng chương trình
        private void GiaoDienB2VN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn kết thúc chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}