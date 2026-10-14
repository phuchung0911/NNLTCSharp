using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai2
{
    public class GiaoDienBai2 : Form
    {
        private QuanLyTaiKhoan ql = new QuanLyTaiKhoan();

        private Label lblTieuDe;
        private Label lblSTK, lblTenKH, lblDiaChi, lblSoTien, lblTongTien;
        private TextBox txtSTK, txtTenKH, txtDiaChi, txtSoTien, txtTongTien;

        // Các nút bấm điều khiển
        private Button btnThem, btnLuu, btnXoa, btnThoat;

        // ListView hiển thị danh sách tài khoản
        private ListView lsvTaiKhoan;

        public GiaoDienBai2()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "frmBaiTap2";
            this.Size = new Size(620, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề 
            lblTieuDe = new Label()
            {
                Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN",
                Location = new Point(90, 15),
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Blue
            };

            // Các ô nhập liệu
            lblSTK = new Label() { Text = "Số tài khoản", Location = new Point(45, 55), AutoSize = true };
            txtSTK = new TextBox() { Location = new Point(190, 52), Size = new Size(370, 23) };

            lblTenKH = new Label() { Text = "Tên khách hàng", Location = new Point(45, 90), AutoSize = true };
            txtTenKH = new TextBox() { Location = new Point(190, 87), Size = new Size(370, 23) };

            lblDiaChi = new Label() { Text = "Địa chỉ khách hàng", Location = new Point(45, 125), AutoSize = true };
            txtDiaChi = new TextBox() { Location = new Point(190, 122), Size = new Size(370, 23) };

            lblSoTien = new Label() { Text = "Số tiền trong tài khoản", Location = new Point(45, 160), AutoSize = true };
            txtSoTien = new TextBox() { Location = new Point(190, 157), Size = new Size(370, 23) };
            txtSoTien.KeyPress += TxtSoTien_KeyPress;

            // Các nút bấm
            btnThem = new Button() { Text = "Thêm", Location = new Point(190, 195), Size = new Size(80, 30) };
            btnLuu = new Button() { Text = "Lưu", Location = new Point(285, 195), Size = new Size(80, 30), Enabled = false };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(380, 195), Size = new Size(80, 30), Enabled = false };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(480, 195), Size = new Size(80, 30) };

            btnThem.Click += BtnThem_Click;
            btnLuu.Click += BtnLuu_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += (s, e) => this.Close();

            // ListView danh sách tài khoản
            lsvTaiKhoan = new ListView()
            {
                Location = new Point(45, 235),
                Size = new Size(515, 170),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                MultiSelect = false
            };

            // Thiết lập các cột
            lsvTaiKhoan.Columns.Add("STT", 45);
            lsvTaiKhoan.Columns.Add("Số tài khoản", 110);
            lsvTaiKhoan.Columns.Add("Tên khách hàng", 140);
            lsvTaiKhoan.Columns.Add("Địa chỉ", 110);
            lsvTaiKhoan.Columns.Add("Số tiền", 105, HorizontalAlignment.Right);

            lsvTaiKhoan.SelectedIndexChanged += LsvTaiKhoan_SelectedIndexChanged;

            // Ô hiển thị Tổng tiền (ban đầu là 0)
            lblTongTien = new Label() { Text = "Tổng tiền", Location = new Point(300, 420), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            txtTongTien = new TextBox()
            {
                Location = new Point(370, 417),
                Size = new Size(190, 23),
                ReadOnly = true,
                BackColor = Color.White,
                TextAlign = HorizontalAlignment.Right,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Text = "0"
            };

            this.Controls.AddRange(new Control[] {
                lblTieuDe,
                lblSTK, txtSTK,
                lblTenKH, txtTenKH,
                lblDiaChi, txtDiaChi,
                lblSoTien, txtSoTien,
                btnThem, btnLuu, btnXoa, btnThoat,
                lsvTaiKhoan,
                lblTongTien, txtTongTien
            });

            this.FormClosing += GiaoDienBai2_FormClosing;
        }

        // Chỉ cho phép gõ số vào ô Số tiền
        private void TxtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Nút Thêm (chuyển đổi trạng thái Thêm <-> Hủy)
        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;

                // Xóa trắng các ô và đưa con trỏ vào ô Số tài khoản
                txtSTK.Clear();
                txtTenKH.Clear();
                txtDiaChi.Clear();
                txtSoTien.Clear();
                txtSTK.Focus();
            }
            else // Bấm Hủy
            {
                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;

                txtSTK.Clear();
                txtTenKH.Clear();
                txtDiaChi.Clear();
                txtSoTien.Clear();
            }
        }

        // Nút Lưu: đọc dữ liệu từ các ô và đưa vào ListView
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string stk = txtSTK.Text.Trim();
            string ten = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string tienChuoi = txtSoTien.Text.Trim();

            if (string.IsNullOrEmpty(stk) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(tienChuoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!", "Thông báo");
                return;
            }

            if (ql.KiemTraTrungSTK(stk))
            {
                MessageBox.Show("Số tài khoản này đã tồn tại, không được nhập trùng!", "Báo lỗi");
                txtSTK.Focus();
                return;
            }

            if (!decimal.TryParse(tienChuoi, out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Báo lỗi");
                txtSoTien.Focus();
                return;
            }

            // Thêm vào lớp nghiệp vụ
            TaiKhoan tkMoi = new TaiKhoan(stk, ten, diaChi, soTien);
            ql.Them(tkMoi);

            // Cập nhật lại ListView và Tổng tiền
            NapDuLieuLenListView();

            // Trả nút về trạng thái ban đầu
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;

            txtSTK.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSoTien.Clear();

            MessageBox.Show("Lưu tài khoản thành công!");
        }

        // Khi người dùng bấm vào một dòng trong ListView
        private void LsvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvTaiKhoan.SelectedItems[0];
                txtSTK.Text = item.SubItems[1].Text;
                txtTenKH.Text = item.SubItems[2].Text;
                txtDiaChi.Text = item.SubItems[3].Text;
                txtSoTien.Text = item.SubItems[4].Text.Replace(",", "");

                btnXoa.Enabled = true;

                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        // Nút Xóa: xóa dòng đang chọn
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản cần xóa!", "Thông báo");
                return;
            }

            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.Yes)
            {
                string stk = lsvTaiKhoan.SelectedItems[0].SubItems[1].Text;
                ql.Xoa(stk);

                NapDuLieuLenListView();

                txtSTK.Clear();
                txtTenKH.Clear();
                txtDiaChi.Clear();
                txtSoTien.Clear();
                btnXoa.Enabled = false;

                MessageBox.Show("Đã xóa tài khoản thành công!");
            }
        }

        // Đổ lại danh sách, đánh STT tự động từ 1 và tính Tổng tiền
        private void NapDuLieuLenListView()
        {
            lsvTaiKhoan.BeginUpdate();
            lsvTaiKhoan.Items.Clear();

            int stt = 1;
            foreach (var tk in ql.LayDanhSach())
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(tk.SoTaiKhoan);
                item.SubItems.Add(tk.TenKhachHang);
                item.SubItems.Add(tk.DiaChi);
                item.SubItems.Add(string.Format("{0:N0}", tk.SoTien));

                lsvTaiKhoan.Items.Add(item);
                stt++;
            }

            lsvTaiKhoan.EndUpdate();

            txtTongTien.Text = string.Format("{0:N0}", ql.TinhTongTien());
        }

        // Xác nhận trước khi đóng chương trình
        private void GiaoDienBai2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}