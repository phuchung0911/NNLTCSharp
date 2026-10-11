using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTNangCao
{
    public class GiaoDienBTNC : Form
    {
        // Các control trên giao diện
        private Label lblTieuDe, lblTenKH, lblSoKH, lblNuocUong, lblThucAn;
        private Label lblTongKhach, lblTongTien;
        private TextBox txtTenKH, txtSoKH, txtTongKhach, txtTongTien;
        private CheckBox chkSinhVien;
        private GroupBox grpNuocUong, grpThucAn;

        // Tùy chọn nước uống
        private RadioButton radCafeDen, radCafeDa, radCafeSua, radCafeKem, radCafeSuaDa;

        // Tùy chọn thức ăn
        private RadioButton radBanhMyTrung, radBanhMyCa, radMyTomTrung, radMyXaoBo, radMyCay;

        // Nút chức năng
        private Button btnTinhTien, btnNhapLai, btnThanhToan, btnThoat;

        // Biến cộng dồn toàn quán
        private int tongSoKhachToanQuan = 0;
        private double tongTienToanQuan = 0;
        private double tienKhachHienTai = 0;

        public GiaoDienBTNC()
        {
            ThietKeGiaoDien();
        }

        private void ThietKeGiaoDien()
        {
            this.Text = "Thanh toán tiền";
            this.Size = new Size(530, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "CAFE SINH VIÊN",
                ForeColor = Color.DarkOrange,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(175, 15),
                AutoSize = true
            };

            // Thông tin khách hàng
            lblTenKH = new Label() { Text = "Tên khách hàng", Location = new Point(30, 58), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtTenKH = new TextBox() { Location = new Point(160, 55), Width = 315 };
            txtTenKH.TextChanged += KiemTraDuLieu_TextChanged;

            lblSoKH = new Label() { Text = "Số khách hàng", Location = new Point(30, 93), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtSoKH = new TextBox() { Location = new Point(160, 90), Width = 315 };
            txtSoKH.KeyPress += TxtSoKH_KeyPress;
            txtSoKH.TextChanged += KiemTraDuLieu_TextChanged;

            chkSinhVien = new CheckBox() { Text = "Sinh viên ?", Location = new Point(160, 120), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };

            // Khung Nước uống
            grpNuocUong = new GroupBox() { Text = "Nước uống", Location = new Point(30, 150), Size = new Size(220, 140) };
            radCafeDen = new RadioButton() { Text = "Cafe đen", Location = new Point(15, 25), AutoSize = true };
            radCafeDa = new RadioButton() { Text = "Cafe đá", Location = new Point(120, 25), AutoSize = true };
            radCafeSua = new RadioButton() { Text = "Cafe sữa", Location = new Point(15, 60), AutoSize = true };
            radCafeKem = new RadioButton() { Text = "Cafe kem", Location = new Point(120, 60), AutoSize = true };
            radCafeSuaDa = new RadioButton() { Text = "Cafe sữa đá", Location = new Point(15, 95), AutoSize = true };

            radCafeDen.CheckedChanged += KiemTraDuLieu_TextChanged;
            radCafeDa.CheckedChanged += KiemTraDuLieu_TextChanged;
            radCafeSua.CheckedChanged += KiemTraDuLieu_TextChanged;
            radCafeKem.CheckedChanged += KiemTraDuLieu_TextChanged;
            radCafeSuaDa.CheckedChanged += KiemTraDuLieu_TextChanged;

            grpNuocUong.Controls.AddRange(new Control[] { radCafeDen, radCafeDa, radCafeSua, radCafeKem, radCafeSuaDa });

            // Khung Thức ăn
            grpThucAn = new GroupBox() { Text = "Thức ăn", Location = new Point(265, 150), Size = new Size(220, 140) };
            radBanhMyTrung = new RadioButton() { Text = "Bánh mỳ trứng", Location = new Point(15, 25), AutoSize = true };
            radMyXaoBo = new RadioButton() { Text = "Mỳ xào bò", Location = new Point(120, 25), AutoSize = true };
            radBanhMyCa = new RadioButton() { Text = "Bánh mỳ cá", Location = new Point(15, 60), AutoSize = true };
            radMyCay = new RadioButton() { Text = "Mỳ cay", Location = new Point(120, 60), AutoSize = true };
            radMyTomTrung = new RadioButton() { Text = "Mỳ tôm trứng", Location = new Point(15, 95), AutoSize = true };

            radBanhMyTrung.CheckedChanged += KiemTraDuLieu_TextChanged;
            radMyXaoBo.CheckedChanged += KiemTraDuLieu_TextChanged;
            radBanhMyCa.CheckedChanged += KiemTraDuLieu_TextChanged;
            radMyCay.CheckedChanged += KiemTraDuLieu_TextChanged;
            radMyTomTrung.CheckedChanged += KiemTraDuLieu_TextChanged;

            grpThucAn.Controls.AddRange(new Control[] { radBanhMyTrung, radMyXaoBo, radBanhMyCa, radMyCay, radMyTomTrung });

            // Nút 
            btnTinhTien = new Button() { Text = "Tính tiền", Location = new Point(30, 310), Size = new Size(95, 32), Enabled = false };
            btnNhapLai = new Button() { Text = "Nhập lại", Location = new Point(145, 310), Size = new Size(95, 32), Enabled = false };
            btnThanhToan = new Button() { Text = "Thanh toán", Location = new Point(260, 310), Size = new Size(95, 32), Enabled = false };
            btnThoat = new Button() { Text = "Thoát", Location = new Point(375, 310), Size = new Size(95, 32) };

            btnTinhTien.Click += BtnTinhTien_Click;
            btnNhapLai.Click += BtnNhapLai_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
            btnThoat.Click += (s, e) => this.Close();

            // Tổng kết
            lblTongKhach = new Label() { Text = "Tổng khách hàng", Location = new Point(30, 370), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtTongKhach = new TextBox() { Location = new Point(175, 367), Width = 300, ReadOnly = true };

            lblTongTien = new Label() { Text = "Tổng tiền thanh toán", Location = new Point(30, 410), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtTongTien = new TextBox() { Location = new Point(175, 407), Width = 300, ReadOnly = true };

            this.Controls.AddRange(new Control[] {
                lblTieuDe, lblTenKH, txtTenKH, lblSoKH, txtSoKH, chkSinhVien,
                grpNuocUong, grpThucAn, btnTinhTien, btnNhapLai, btnThanhToan, btnThoat,
                lblTongKhach, txtTongKhach, lblTongTien, txtTongTien
            });

            this.Load += GiaoDienBTNC_Load;
            this.FormClosing += GiaoDienBTNC_FormClosing;
        }

        // form Load: trỏ chuột vào ô tên, mờ 3 nút
        private void GiaoDienBTNC_Load(object sender, EventArgs e)
        {
            txtTenKH.Focus();
            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;
        }

        // Chặn nhập ký tự ko phải số vào ô số khách hàng
        private void TxtSoKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra điền đủ thông tin thì sáng nút Tính tiền
        private void KiemTraDuLieu_TextChanged(object sender, EventArgs e)
        {
            bool coTen = !string.IsNullOrWhiteSpace(txtTenKH.Text);
            bool coSoKhach = !string.IsNullOrWhiteSpace(txtSoKH.Text);

            bool coNuoc = radCafeDen.Checked || radCafeDa.Checked || radCafeSua.Checked ||
                          radCafeKem.Checked || radCafeSuaDa.Checked;

            bool coDoAn = radBanhMyTrung.Checked || radBanhMyCa.Checked || radMyTomTrung.Checked ||
                          radMyXaoBo.Checked || radMyCay.Checked;

            btnTinhTien.Enabled = coTen && coSoKhach && coNuoc && coDoAn;
        }

        // Xử lý nút Tính tiền
        private void BtnTinhTien_Click(object sender, EventArgs e)
        {
            double giaNuoc = 0;
            if (radCafeDen.Checked) giaNuoc = 20000;
            else if (radCafeDa.Checked) giaNuoc = 25000;
            else if (radCafeSua.Checked) giaNuoc = 25000;
            else if (radCafeSuaDa.Checked) giaNuoc = 30000;
            else if (radCafeKem.Checked) giaNuoc = 35000;

            double giaDoAn = 0;
            if (radBanhMyTrung.Checked) giaDoAn = 15000;
            else if (radBanhMyCa.Checked) giaDoAn = 15000;
            else if (radMyTomTrung.Checked) giaDoAn = 20000;
            else if (radMyXaoBo.Checked) giaDoAn = 30000;
            else if (radMyCay.Checked) giaDoAn = 50000;

            int soKhach = int.Parse(txtSoKH.Text);

            // Tạo đối tượng HoaDonCafe từ class BTNangCao
            HoaDonCafe hd = new HoaDonCafe(txtTenKH.Text, soKhach, chkSinhVien.Checked, giaNuoc, giaDoAn);
            tienKhachHienTai = hd.TinhThanhTien();

            MessageBox.Show($"Khách hàng: {hd.TenKhachHang}\nSố tiền phải thanh toán: {tienKhachHienTai:N0} VNĐ",
                            "Thông báo thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnNhapLai.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        // Xử lý nút Nhập lại
        private void BtnNhapLai_Click(object sender, EventArgs e)
        {
            txtTenKH.Clear();
            txtSoKH.Clear();
            chkSinhVien.Checked = false;

            radCafeDen.Checked = radCafeDa.Checked = radCafeSua.Checked = false;
            radCafeKem.Checked = radCafeSuaDa.Checked = false;

            radBanhMyTrung.Checked = radBanhMyCa.Checked = radMyTomTrung.Checked = false;
            radMyXaoBo.Checked = radMyCay.Checked = false;

            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;

            txtTenKH.Focus();
        }

        // Xử lý nút Thanh toán
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            int soKhach = int.Parse(txtSoKH.Text);
            tongSoKhachToanQuan += soKhach;
            tongTienToanQuan += tienKhachHienTai;

            txtTongKhach.Text = tongSoKhachToanQuan.ToString();
            txtTongTien.Text = $"{tongTienToanQuan:N0} VNĐ";

            btnThanhToan.Enabled = false;
            BtnNhapLai_Click(sender, e);
        }

        // Xác nhận thoát
        private void GiaoDienBTNC_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình hay không?",
                                               "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}