using System;
using System.Drawing;
using System.Windows.Forms;

namespace BTVeNha
{
    public class GiaoDienBTVN : Form
    {
        // Nhãn và ô nhập liệu thông tin khách
        private Label lblTieuDe, lblHoTen, lblDiaChi, lblSoNgayO, lblThanhTien;
        private TextBox txtHoTen, txtDiaChi, txtSoNgayO;

        // Nhóm Loại phòng 
        private GroupBox grpLoaiPhong;
        private RadioButton radPhongDon, radPhongDoi, radPhongBa;

        // Nhóm Tiện nghi 
        private GroupBox grpTienNghi;
        private CheckBox chkTivi, chkInternet, chkMayNuocNong;

        // Nhóm Dịch vụ
        private GroupBox grpDichVu;
        private CheckBox chkKaraoke, chkAnSang;

        // Các nút bấm điều khiển
        private Button btnThanhToan, btnNhapMoi, btnTongKet, btnThoat;

        // Nhóm thông tin tổng kết cuối ngày
        private GroupBox grpTongKet;
        private Label lblSoLuotNguoi, lblTongTien;
        private TextBox txtSoLuotNguoi, txtTongTien;

        // Biến lưu trữ thống kê cộng dồn trong ngày
        private int tongLuotKhach = 0;
        private double tongTienThuDuoc = 0;
        private double tienKhachHienTai = 0;

        public GiaoDienBTVN()
        {
            ThietKeGiaoDien();
        }

        private void ThietKeGiaoDien()
        {
            this.Text = "frmDangkyKS";
            this.Size = new Size(620, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG",
                ForeColor = Color.MediumBlue,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(100, 15),
                AutoSize = true
            };

            // Thông tin khách
            lblHoTen = new Label() { Text = "Họ và tên:", Location = new Point(30, 60), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtHoTen = new TextBox() { Location = new Point(110, 57), Width = 310 };
            txtHoTen.TextChanged += KiemTraDuLieu_TextChanged;

            lblDiaChi = new Label() { Text = "Địa chỉ:", Location = new Point(30, 95), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtDiaChi = new TextBox() { Location = new Point(110, 92), Width = 310 };
            txtDiaChi.TextChanged += KiemTraDuLieu_TextChanged;

            lblSoNgayO = new Label() { Text = "Số ngày ở:", Location = new Point(30, 130), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtSoNgayO = new TextBox() { Location = new Point(110, 127), Width = 310 };
            txtSoNgayO.KeyPress += TxtSoNgayO_KeyPress;
            txtSoNgayO.TextChanged += KiemTraDuLieu_TextChanged;

            // Nút Thanh toán, Nhập mới và Label Thành tiền
            btnThanhToan = new Button() { Text = "Thanh toán", Location = new Point(460, 55), Size = new Size(110, 30), Enabled = false };
            btnThanhToan.Click += BtnThanhToan_Click;

            lblThanhTien = new Label()
            {
                Text = "Thành tiền: 0 VND",
                ForeColor = Color.Red,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Location = new Point(445, 95),
                AutoSize = true
            };

            btnNhapMoi = new Button() { Text = "Nhập mới", Location = new Point(460, 125), Size = new Size(110, 30), Enabled = false };
            btnNhapMoi.Click += BtnNhapMoi_Click;

            // Khung Loại phòng
            grpLoaiPhong = new GroupBox() { Text = "Loại phòng", Location = new Point(30, 175), Size = new Size(160, 130) };
            radPhongDon = new RadioButton() { Text = "Phòng đơn", Location = new Point(15, 25), AutoSize = true };
            radPhongDoi = new RadioButton() { Text = "Phòng đôi", Location = new Point(15, 60), AutoSize = true };
            radPhongBa = new RadioButton() { Text = "Phòng ba", Location = new Point(15, 95), AutoSize = true };
            radPhongDon.CheckedChanged += KiemTraDuLieu_TextChanged;
            radPhongDoi.CheckedChanged += KiemTraDuLieu_TextChanged;
            radPhongBa.CheckedChanged += KiemTraDuLieu_TextChanged;
            grpLoaiPhong.Controls.AddRange(new Control[] { radPhongDon, radPhongDoi, radPhongBa });

            // Khung Tiện nghi
            grpTienNghi = new GroupBox() { Text = "Tiện nghi", Location = new Point(205, 175), Size = new Size(160, 130) };
            chkTivi = new CheckBox() { Text = "Tivi", Location = new Point(15, 25), AutoSize = true };
            chkInternet = new CheckBox() { Text = "Internet", Location = new Point(15, 60), AutoSize = true };
            chkMayNuocNong = new CheckBox() { Text = "Máy nước nóng", Location = new Point(15, 95), AutoSize = true };
            grpTienNghi.Controls.AddRange(new Control[] { chkTivi, chkInternet, chkMayNuocNong });

            // Khung Dịch vụ
            grpDichVu = new GroupBox() { Text = "Dịch vụ", Location = new Point(380, 175), Size = new Size(190, 130) };
            chkKaraoke = new CheckBox() { Text = "Karaoke", Location = new Point(15, 30), AutoSize = true };
            chkAnSang = new CheckBox() { Text = "Ăn sáng", Location = new Point(15, 75), AutoSize = true };
            grpDichVu.Controls.AddRange(new Control[] { chkKaraoke, chkAnSang });

            // Nút Tổng kết và Thoát
            btnTongKet = new Button() { Text = "Tổng Kết", Location = new Point(30, 325), Size = new Size(110, 35), Enabled = false };
            btnTongKet.Click += BtnTongKet_Click;

            btnThoat = new Button() { Text = "Thoát", Location = new Point(460, 325), Size = new Size(110, 35) };
            btnThoat.Click += (s, e) => this.Close();

            // Khung Thông tin tổng kết
            grpTongKet = new GroupBox() { Text = "Thông tin tổng kết", Location = new Point(30, 375), Size = new Size(540, 120) };
            lblSoLuotNguoi = new Label() { Text = "Số lượt người:", Location = new Point(25, 35), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtSoLuotNguoi = new TextBox() { Location = new Point(150, 32), Width = 350, ReadOnly = true };

            lblTongTien = new Label() { Text = "Tổng số tiền:", Location = new Point(25, 75), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtTongTien = new TextBox() { Location = new Point(150, 72), Width = 350, ReadOnly = true };
            grpTongKet.Controls.AddRange(new Control[] { lblSoLuotNguoi, txtSoLuotNguoi, lblTongTien, txtTongTien });

            // Thêm tất cả vào Form
            this.Controls.AddRange(new Control[] {
                lblTieuDe, lblHoTen, txtHoTen, lblDiaChi, txtDiaChi, lblSoNgayO, txtSoNgayO,
                btnThanhToan, lblThanhTien, btnNhapMoi, grpLoaiPhong, grpTienNghi, grpDichVu,
                btnTongKet, btnThoat, grpTongKet
            });

            this.Load += GiaoDienBTVN_Load;
            this.FormClosing += GiaoDienBTVN_FormClosing;
        }

        // Trỏ vào họ tên, làm mờ 3 nút
        private void GiaoDienBTVN_Load(object sender, EventArgs e)
        {
            txtHoTen.Focus();
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = false;
        }

        // Chặn nhập chữ ở ô số ngày ở
        private void TxtSoNgayO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra điền đủ thông tin thì mở nút thanh toán
        private void KiemTraDuLieu_TextChanged(object sender, EventArgs e)
        {
            bool coHoTen = !string.IsNullOrWhiteSpace(txtHoTen.Text);
            bool coDiaChi = !string.IsNullOrWhiteSpace(txtDiaChi.Text);
            bool coSoNgay = !string.IsNullOrWhiteSpace(txtSoNgayO.Text);
            bool coLoaiPhong = radPhongDon.Checked || radPhongDoi.Checked || radPhongBa.Checked;

            btnThanhToan.Enabled = coHoTen && coDiaChi && coSoNgay && coLoaiPhong;
        }

        // Bấm nút Thanh toán: tính tiền hiển thị ra label và lưu cộng dồn
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            double giaPhong = 0;
            if (radPhongDon.Checked) giaPhong = 300000;
            else if (radPhongDoi.Checked) giaPhong = 350000;
            else if (radPhongBa.Checked) giaPhong = 400000;

            int soTienNghi = 0;
            if (chkTivi.Checked) soTienNghi++;
            if (chkInternet.Checked) soTienNghi++;
            if (chkMayNuocNong.Checked) soTienNghi++;

            int soNgay = int.Parse(txtSoNgayO.Text);

            KhachSanThanhThanh ks = new KhachSanThanhThanh(txtHoTen.Text, txtDiaChi.Text, soNgay, giaPhong, soTienNghi, chkKaraoke.Checked, chkAnSang.Checked);
            tienKhachHienTai = ks.TinhTien();

            // Cập nhật lên label Thành tiền
            lblThanhTien.Text = $"Thành tiền: {tienKhachHienTai:N0} VND";

            // Lưu cộng dồn số lượt khách và tiền thu được
            tongLuotKhach++;
            tongTienThuDuoc += tienKhachHienTai;

            // Bật 2 nút nhập mới và tổng kết
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;
            btnThanhToan.Enabled = false;
        }

        // Bấm nút Nhập mới: đưa form về ban đầu, sẵn sàng nhập khách mới
        private void BtnNhapMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgayO.Clear();

            radPhongDon.Checked = radPhongDoi.Checked = radPhongBa.Checked = false;
            chkTivi.Checked = chkInternet.Checked = chkMayNuocNong.Checked = false;
            chkKaraoke.Checked = chkAnSang.Checked = false;

            lblThanhTien.Text = "Thành tiền: 0 VND";

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;

            txtHoTen.Focus();
        }

        // Bấm nút Tổng kết: ghi thông tin ra textbox và reset giá trị cộng dồn về 0
        private void BtnTongKet_Click(object sender, EventArgs e)
        {
            txtSoLuotNguoi.Text = tongLuotKhach.ToString();
            txtTongTien.Text = $"{tongTienThuDuoc:N0} VND";

            // Khởi tạo lại giá trị 
            tongLuotKhach = 0;
            tongTienThuDuoc = 0;

            btnTongKet.Enabled = false;
        }

        // xác nhận khi đóng form
        private void GiaoDienBTVN_FormClosing(object sender, FormClosingEventArgs e)
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