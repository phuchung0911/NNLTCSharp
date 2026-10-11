using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai2
{
    public class GiaoDienBai2 : Form
    {
        private MangSoNguyen mang = new MangSoNguyen();

        // khung mảng và sắp xếp
        private Label lblTieuDe, lblNhapMang, lblKetQuaMang;
        private TextBox txtNhapMang, txtKetQuaMang;
        private Button btnThucHien, btnReset, btnThoat;
        private GroupBox grpSapXep, grpTimKiem, grpXoa, grpThem, grpTong, grpMaxMin, grpThayThe;
        private RadioButton radSapXepTang, radSapXepGiam;

        // Khung tìm kiếm
        private RadioButton radTimGiaTri, radTimViTri;
        private TextBox txtGiaTriTim, txtViTriTim, txtKetQuaTim;
        private Label lblSoTimDuoc;
        private Button btnThucHienTim;

        // Khung Xóa
        private RadioButton radXoaGiaTri, radXoaViTri;
        private TextBox txtGiaTriXoa, txtViTriXoa;
        private Button btnThucHienXoa;

        // Khung thêm
        private Label lblGiaTriThem, lblViTriThem;
        private TextBox txtGiaTriThem, txtViTriThem;
        private Button btnThucHienThem;

        // Khung tổng
        private Label lblTongMang, lblTongChan, lblTongLe;
        private TextBox txtTongMang, txtTongChan, txtTongLe;
        private Button btnTinhTong;

        // Khung max-min
        private Label lblMax, lblMin;
        private TextBox txtMax, txtMin;
        private Button btnTimMaxMin;

        // Khung thay thế
        private RadioButton radThayGiaTri, radThayViTri;
        private TextBox txtGiaTriCanThay, txtViTriCanThay, txtSoThayThe;
        private Label lblSoThayThe;
        private Button btnThucHienThayThe;

        public GiaoDienBai2()
        {
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            this.Text = "Mảng Số Nguyên";
            this.Size = new Size(540, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTieuDe = new Label()
            {
                Text = "Mảng Số Nguyên",
                ForeColor = Color.Red,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(180, 15),
                AutoSize = true
            };

            // Ô Nhập và Kết quả mảng
            lblNhapMang = new Label() { Text = "Nhập mảng:", Location = new Point(20, 60), AutoSize = true };
            txtNhapMang = new TextBox() { Location = new Point(100, 57), Size = new Size(300, 23) };

            btnReset = new Button() { Text = "Reset", Location = new Point(415, 55), Size = new Size(85, 27) };
            btnReset.Click += BtnReset_Click;

            lblKetQuaMang = new Label() { Text = "Kết quả mảng:", Location = new Point(20, 95), AutoSize = true };
            txtKetQuaMang = new TextBox() { Location = new Point(100, 92), Size = new Size(300, 23), ReadOnly = true };

            btnThoat = new Button() { Text = "Thoát", Location = new Point(415, 90), Size = new Size(85, 27) };
            btnThoat.Click += (s, e) => this.Close();

            // Khung sắp xếp
            btnThucHien = new Button() { Text = "Thực Hiện", Location = new Point(20, 130), Size = new Size(90, 45) };
            btnThucHien.Click += BtnThucHienSapXep_Click;

            grpSapXep = new GroupBox() { Text = "Sắp Xếp", Location = new Point(125, 125), Size = new Size(375, 50) };
            radSapXepTang = new RadioButton() { Text = "Sắp xếp Tăng", Location = new Point(30, 20), Checked = true, AutoSize = true };
            radSapXepGiam = new RadioButton() { Text = "Sắp xếp Giảm", Location = new Point(180, 20), AutoSize = true };
            grpSapXep.Controls.AddRange(new Control[] { radSapXepTang, radSapXepGiam });

            // Khung Tìm kiếm
            grpTimKiem = new GroupBox() { Text = "Tìm Kiếm", Location = new Point(20, 185), Size = new Size(230, 140) };
            radTimGiaTri = new RadioButton() { Text = "Tìm giá trị", Location = new Point(10, 20), AutoSize = true, Checked = true };
            txtGiaTriTim = new TextBox() { Location = new Point(140, 18), Size = new Size(75, 23) };

            radTimViTri = new RadioButton() { Text = "Tìm vị trí", Location = new Point(10, 48), AutoSize = true };
            txtViTriTim = new TextBox() { Location = new Point(140, 46), Size = new Size(75, 23) };

            lblSoTimDuoc = new Label() { Text = "Kết quả tìm:", Location = new Point(10, 78), AutoSize = true };
            txtKetQuaTim = new TextBox() { Location = new Point(140, 75), Size = new Size(75, 23), ReadOnly = true };

            btnThucHienTim = new Button() { Text = "Tìm", Location = new Point(140, 105), Size = new Size(75, 25) };
            btnThucHienTim.Click += BtnThucHienTim_Click;
            grpTimKiem.Controls.AddRange(new Control[] { radTimGiaTri, txtGiaTriTim, radTimViTri, txtViTriTim, lblSoTimDuoc, txtKetQuaTim, btnThucHienTim });

            // Khung Xóa
            grpXoa = new GroupBox() { Text = "Xóa", Location = new Point(270, 185), Size = new Size(230, 140) };
            radXoaGiaTri = new RadioButton() { Text = "Xóa theo giá trị", Location = new Point(10, 20), AutoSize = true, Checked = true };
            txtGiaTriXoa = new TextBox() { Location = new Point(140, 18), Size = new Size(75, 23) };

            radXoaViTri = new RadioButton() { Text = "Xóa theo vị trí", Location = new Point(10, 48), AutoSize = true };
            txtViTriXoa = new TextBox() { Location = new Point(140, 46), Size = new Size(75, 23) };

            btnThucHienXoa = new Button() { Text = "Xóa", Location = new Point(140, 85), Size = new Size(75, 30) };
            btnThucHienXoa.Click += BtnThucHienXoa_Click;
            grpXoa.Controls.AddRange(new Control[] { radXoaGiaTri, txtGiaTriXoa, radXoaViTri, txtViTriXoa, btnThucHienXoa });

            // Khung Thêm
            grpThem = new GroupBox() { Text = "Thêm", Location = new Point(20, 335), Size = new Size(230, 130) };
            lblGiaTriThem = new Label() { Text = "Giá trị cần thêm:", Location = new Point(10, 25), AutoSize = true };
            txtGiaTriThem = new TextBox() { Location = new Point(140, 22), Size = new Size(75, 23) };

            lblViTriThem = new Label() { Text = "Tại vị trí:", Location = new Point(10, 58), AutoSize = true };
            txtViTriThem = new TextBox() { Location = new Point(140, 55), Size = new Size(75, 23) };

            btnThucHienThem = new Button() { Text = "Thêm", Location = new Point(140, 90), Size = new Size(75, 28) };
            btnThucHienThem.Click += BtnThucHienThem_Click;
            grpThem.Controls.AddRange(new Control[] { lblGiaTriThem, txtGiaTriThem, lblViTriThem, txtViTriThem, btnThucHienThem });

            // Khung Tổng
            grpTong = new GroupBox() { Text = "Tổng", Location = new Point(270, 335), Size = new Size(230, 130) };
            lblTongMang = new Label() { Text = "Tổng mảng:", Location = new Point(10, 25), AutoSize = true };
            txtTongMang = new TextBox() { Location = new Point(85, 22), Size = new Size(60, 23), ReadOnly = true };

            lblTongChan = new Label() { Text = "Tổng chẵn:", Location = new Point(10, 58), AutoSize = true };
            txtTongChan = new TextBox() { Location = new Point(85, 55), Size = new Size(60, 23), ReadOnly = true };

            lblTongLe = new Label() { Text = "Tổng lẻ:", Location = new Point(10, 91), AutoSize = true };
            txtTongLe = new TextBox() { Location = new Point(85, 88), Size = new Size(60, 23), ReadOnly = true };

            btnTinhTong = new Button() { Text = "Tổng", Location = new Point(155, 35), Size = new Size(65, 65) };
            btnTinhTong.Click += BtnTinhTong_Click;
            grpTong.Controls.AddRange(new Control[] { lblTongMang, txtTongMang, lblTongChan, txtTongChan, lblTongLe, txtTongLe, btnTinhTong });

            // Khung Max - Min
            grpMaxMin = new GroupBox() { Text = "Max - Min", Location = new Point(20, 475), Size = new Size(230, 125) };
            lblMax = new Label() { Text = "Giá trị lớn nhất:", Location = new Point(10, 30), AutoSize = true };
            txtMax = new TextBox() { Location = new Point(100, 27), Size = new Size(50, 23), ReadOnly = true };

            lblMin = new Label() { Text = "Giá trị nhỏ nhất:", Location = new Point(10, 68), AutoSize = true };
            txtMin = new TextBox() { Location = new Point(100, 65), Size = new Size(50, 23), ReadOnly = true };

            btnTimMaxMin = new Button() { Text = "Tìm", Location = new Point(160, 35), Size = new Size(60, 45) };
            btnTimMaxMin.Click += BtnTimMaxMin_Click;
            grpMaxMin.Controls.AddRange(new Control[] { lblMax, txtMax, lblMin, txtMin, btnTimMaxMin });

            // Khung Thay Thế
            grpThayThe = new GroupBox() { Text = "Thay Thế", Location = new Point(270, 475), Size = new Size(230, 125) };
            radThayGiaTri = new RadioButton() { Text = "Thay giá trị", Location = new Point(10, 20), AutoSize = true, Checked = true };
            txtGiaTriCanThay = new TextBox() { Location = new Point(135, 18), Size = new Size(80, 23) };

            radThayViTri = new RadioButton() { Text = "Thay vị trí", Location = new Point(10, 48), AutoSize = true };
            txtViTriCanThay = new TextBox() { Location = new Point(135, 46), Size = new Size(80, 23) };

            lblSoThayThe = new Label() { Text = "Số thay thế:", Location = new Point(10, 80), AutoSize = true };
            txtSoThayThe = new TextBox() { Location = new Point(80, 77), Size = new Size(60, 23) };

            btnThucHienThayThe = new Button() { Text = "Đổi", Location = new Point(150, 75), Size = new Size(65, 27) };
            btnThucHienThayThe.Click += BtnThucHienThayThe_Click;
            grpThayThe.Controls.AddRange(new Control[] { radThayGiaTri, txtGiaTriCanThay, radThayViTri, txtViTriCanThay, lblSoThayThe, txtSoThayThe, btnThucHienThayThe });

            // Thêm tất cả vào Form
            this.Controls.AddRange(new Control[] {
                lblTieuDe, lblNhapMang, txtNhapMang, btnReset, lblKetQuaMang, txtKetQuaMang, btnThoat,
                btnThucHien, grpSapXep, grpTimKiem, grpXoa, grpThem, grpTong, grpMaxMin, grpThayThe
            });

            this.FormClosing += GiaoDienBai2_FormClosing;
        }

        // Đọc mảng từ TextBox vào lớp
        private bool DocDuLieuMang()
        {
            if (!mang.KhoiTaoTuChuoi(txtNhapMang.Text))
            {
                MessageBox.Show("Vui lòng nhập mảng số nguyên cách nhau bằng khoảng trắng hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Nút Sắp xếp
        private void BtnThucHienSapXep_Click(object sender, EventArgs e)
        {
            if (!DocDuLieuMang()) return;

            if (radSapXepTang.Checked) mang.SapXepTang();
            else mang.SapXepGiam();

            txtKetQuaMang.Text = mang.XuatChuoi();
        }

        // Nút Tìm kiếm
        private void BtnThucHienTim_Click(object sender, EventArgs e)
        {
            if (!DocDuLieuMang()) return;

            if (radTimGiaTri.Checked)
            {
                if (int.TryParse(txtGiaTriTim.Text, out int giaTri))
                {
                    int viTri = mang.TimViTriTheoGiaTri(giaTri);
                    txtKetQuaTim.Text = (viTri != -1) ? $"Vị trí: {viTri}" : "Không thấy";
                }
                else MessageBox.Show("Nhập giá trị cần tìm hợp lệ!");
            }
            else
            {
                if (int.TryParse(txtViTriTim.Text, out int viTri))
                {
                    int? kq = mang.LayGiaTriTheoViTri(viTri);
                    txtKetQuaTim.Text = kq.HasValue ? kq.Value.ToString() : "Ngoài mảng";
                }
                else MessageBox.Show("Nhập chỉ số vị trí hợp lệ!");
            }
        }

        // Nút Xóa
        private void BtnThucHienXoa_Click(object sender, EventArgs e)
        {
            if (!DocDuLieuMang()) return;

            if (radXoaGiaTri.Checked)
            {
                if (int.TryParse(txtGiaTriXoa.Text, out int giaTri))
                {
                    if (mang.XoaTheoGiaTri(giaTri))
                    {
                        txtKetQuaMang.Text = mang.XuatChuoi();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else MessageBox.Show("Không tìm thấy giá trị cần xóa!");
                }
            }
            else
            {
                if (int.TryParse(txtViTriXoa.Text, out int viTri))
                {
                    if (mang.XoaTheoViTri(viTri))
                    {
                        txtKetQuaMang.Text = mang.XuatChuoi();
                        MessageBox.Show("Xóa thành công!");
                    }
                    else MessageBox.Show("Vị trí xóa không hợp lệ!");
                }
            }
        }

        // Nút Thêm
        private void BtnThucHienThem_Click(object sender, EventArgs e)
        {
            if (!DocDuLieuMang()) return;

            if (int.TryParse(txtGiaTriThem.Text, out int giaTri) && int.TryParse(txtViTriThem.Text, out int viTri))
            {
                if (mang.ThemTaiViTri(viTri, giaTri))
                {
                    txtKetQuaMang.Text = mang.XuatChuoi();
                    MessageBox.Show("Thêm thành công!");
                }
                else MessageBox.Show("Vị trí chèn vượt giới hạn mảng!");
            }
            else MessageBox.Show("Vui lòng điền đủ giá trị và vị trí!");
        }

        // Nút Tổng
        private void BtnTinhTong_Click(object sender, EventArgs e)
        {
            if (!DocDuLieuMang()) return;

            txtTongMang.Text = mang.TinhTong().ToString();
            txtTongChan.Text = mang.TinhTongChan().ToString();
            txtTongLe.Text = mang.TinhTongLe().ToString();
        }

        // Nút Max Min
        private void BtnTimMaxMin_Click(object sender, EventArgs e)
        {
            if (!DocDuLieuMang()) return;

            txtMax.Text = mang.TimMax()?.ToString() ?? "";
            txtMin.Text = mang.TimMin()?.ToString() ?? "";
        }

        // Nút Thay thế
        private void BtnThucHienThayThe_Click(object sender, EventArgs e)
        {
            if (!DocDuLieuMang()) return;

            if (!int.TryParse(txtSoThayThe.Text, out int soMoi))
            {
                MessageBox.Show("Nhập số thay thế mới hợp lệ!");
                return;
            }

            if (radThayGiaTri.Checked)
            {
                if (int.TryParse(txtGiaTriCanThay.Text, out int giaTriCu))
                {
                    if (mang.ThayTheTheoGiaTri(giaTriCu, soMoi))
                    {
                        txtKetQuaMang.Text = mang.XuatChuoi();
                        MessageBox.Show("Thay thế thành công!");
                    }
                    else MessageBox.Show("Không tìm thấy giá trị cần thay!");
                }
            }
            else
            {
                if (int.TryParse(txtViTriCanThay.Text, out int viTri))
                {
                    if (mang.ThayTheTheoViTri(viTri, soMoi))
                    {
                        txtKetQuaMang.Text = mang.XuatChuoi();
                        MessageBox.Show("Thay thế thành công!");
                    }
                    else MessageBox.Show("Vị trí thay thế không tồn tại!");
                }
            }
        }

        // Nút Reset
        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtNhapMang.Clear();
            txtKetQuaMang.Clear();
            txtGiaTriTim.Clear();
            txtViTriTim.Clear();
            txtKetQuaTim.Clear();
            txtGiaTriXoa.Clear();
            txtViTriXoa.Clear();
            txtGiaTriThem.Clear();
            txtViTriThem.Clear();
            txtTongMang.Clear();
            txtTongChan.Clear();
            txtTongLe.Clear();
            txtMax.Clear();
            txtMin.Clear();
            txtGiaTriCanThay.Clear();
            txtViTriCanThay.Clear();
            txtSoThayThe.Clear();
        }

        // Xác nhận thoát form
        private void GiaoDienBai2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}