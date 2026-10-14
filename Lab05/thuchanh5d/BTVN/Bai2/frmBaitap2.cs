using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTVN2
{
    public class frmBaiTap2 : Form
    {
        private Label lblTieuDe, lblSTK, lblTenKH, lblDiaChi, lblSoTien, lblTongTien;
        private TextBox txtSTK, txtTenKH, txtDiaChi, txtSoTien, txtTongTien;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lsvTaiKhoan;

        public frmBaiTap2()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "frmBaiTap2";
            this.Size = new Size(620, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblTieuDe = new Label()
            {
                Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN",
                Location = new Point(90, 15),
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Blue
            };

            lblSTK = new Label() { Text = "Số tài khoản", Location = new Point(45, 55), AutoSize = true };
            txtSTK = new TextBox() { Location = new Point(190, 52), Size = new Size(370, 23) };

            lblTenKH = new Label() { Text = "Tên khách hàng", Location = new Point(45, 90), AutoSize = true };
            txtTenKH = new TextBox() { Location = new Point(190, 87), Size = new Size(370, 23) };

            lblDiaChi = new Label() { Text = "Địa chỉ khách hàng", Location = new Point(45, 125), AutoSize = true };
            txtDiaChi = new TextBox() { Location = new Point(190, 122), Size = new Size(370, 23) };

            lblSoTien = new Label() { Text = "Số tiền trong tài khoản", Location = new Point(45, 160), AutoSize = true };
            txtSoTien = new TextBox() { Location = new Point(190, 157), Size = new Size(370, 23) };
            txtSoTien.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
            };

            btnThem = new Button() { Text = "Thêm", Location = new Point(190, 195), Size = new Size(80, 30) };
            btnLuu = new Button() { Text = "Lưu", Location = new Point(285, 195), Size = new Size(80, 30), Enabled = false };
            btnXoa = new Button() { Text = "Xóa", Location = new Point(380, 195), Size = new Size(80, 30), Enabled = false };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(480, 195), Size = new Size(80, 30) };

            btnThem.Click += BtnThem_Click;
            btnLuu.Click += BtnLuu_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += (s, e) => this.Close();

            lsvTaiKhoan = new ListView()
            {
                Location = new Point(45, 235),
                Size = new Size(515, 170),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lsvTaiKhoan.Columns.Add("STT", 45);
            lsvTaiKhoan.Columns.Add("Số tài khoản", 110);
            lsvTaiKhoan.Columns.Add("Tên khách hàng", 140);
            lsvTaiKhoan.Columns.Add("Địa chỉ", 110);
            lsvTaiKhoan.Columns.Add("Số tiền", 105, HorizontalAlignment.Right);
            lsvTaiKhoan.SelectedIndexChanged += LsvTaiKhoan_SelectedIndexChanged;

            lblTongTien = new Label() { Text = "Tổng tiền", Location = new Point(300, 420), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            txtTongTien = new TextBox()
            {
                Location = new Point(370, 417),
                Size = new Size(190, 23),
                ReadOnly = true,
                BackColor = Color.White,
                TextAlign = HorizontalAlignment.Right,
                Text = "0",
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            this.Controls.AddRange(new Control[] {
                lblTieuDe, lblSTK, txtSTK, lblTenKH, txtTenKH, lblDiaChi, txtDiaChi,
                lblSoTien, txtSoTien, btnThem, btnLuu, btnXoa, btnThoat, lsvTaiKhoan, lblTongTien, txtTongTien
            });
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                txtSTK.Clear(); txtTenKH.Clear(); txtDiaChi.Clear(); txtSoTien.Clear();
                txtSTK.Focus();
            }
            else
            {
                btnThem.Text = "Thêm";
                btnLuu.Enabled = false;
                txtSTK.Clear(); txtTenKH.Clear(); txtDiaChi.Clear(); txtSoTien.Clear();
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string stk = txtSTK.Text.Trim();
            string ten = txtTenKH.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string tien = txtSoTien.Text.Trim();

            if (string.IsNullOrEmpty(stk) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(tien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            foreach (ListViewItem itm in lsvTaiKhoan.Items)
            {
                if (string.Compare(itm.SubItems[1].Text, stk, true) == 0)
                {
                    MessageBox.Show("Số tài khoản này đã tồn tại!", "Báo lỗi");
                    txtSTK.Focus();
                    return;
                }
            }

            ListViewItem it = new ListViewItem((lsvTaiKhoan.Items.Count + 1).ToString());
            it.SubItems.Add(stk);
            it.SubItems.Add(ten);
            it.SubItems.Add(diaChi);
            decimal dTien = decimal.Parse(tien);
            it.SubItems.Add(string.Format("{0:N0}", dTien));

            lsvTaiKhoan.Items.Add(it);
            CapNhatTongTien();

            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            txtSTK.Clear(); txtTenKH.Clear(); txtDiaChi.Clear(); txtSoTien.Clear();
        }

        private void LsvTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count > 0)
            {
                ListViewItem it = lsvTaiKhoan.SelectedItems[0];
                txtSTK.Text = it.SubItems[1].Text;
                txtTenKH.Text = it.SubItems[2].Text;
                txtDiaChi.Text = it.SubItems[3].Text;
                txtSoTien.Text = it.SubItems[4].Text.Replace(",", "");
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (lsvTaiKhoan.SelectedItems.Count > 0)
            {
                lsvTaiKhoan.Items.Remove(lsvTaiKhoan.SelectedItems[0]);
                for (int i = 0; i < lsvTaiKhoan.Items.Count; i++)
                {
                    lsvTaiKhoan.Items[i].SubItems[0].Text = (i + 1).ToString();
                }
                CapNhatTongTien();
                btnXoa.Enabled = false;
                txtSTK.Clear(); txtTenKH.Clear(); txtDiaChi.Clear(); txtSoTien.Clear();
            }
        }

        private void CapNhatTongTien()
        {
            decimal sum = 0;
            foreach (ListViewItem it in lsvTaiKhoan.Items)
            {
                sum += decimal.Parse(it.SubItems[4].Text.Replace(",", ""));
            }
            txtTongTien.Text = string.Format("{0:N0}", sum);
        }
    }
}