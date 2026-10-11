namespace BTVeNha
{
    public class KhachSanThanhThanh
    {
        // Thông tin khách
        public string HoTen { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public int SoNgayO { get; set; } = 0;

        // Đơn giá phòng theo ngày
        // Phòng đơn: 300.000đ, Phòng đôi: 350.000đ, Phòng ba: 400.000đ
        public double GiaPhong { get; set; } = 0;

        // mỗi tiện nghi cộng 10.000đ
        public int SoTienNghi { get; set; } = 0;

        // Karaoke (50.000đ), Ăn sáng (15.000đ/ngày)
        public bool CoKaraoke { get; set; } = false;
        public bool CoAnSang { get; set; } = false;

        public KhachSanThanhThanh() { }

        public KhachSanThanhThanh(string hoTen, string diaChi, int soNgay, double giaPhong, int soTienNghi, bool karaoke, bool anSang)
        {
            HoTen = hoTen;
            DiaChi = diaChi;
            SoNgayO = soNgay;
            GiaPhong = giaPhong;
            SoTienNghi = soTienNghi;
            CoKaraoke = karaoke;
            CoAnSang = anSang;
        }

        // Tính tổng tiền phòng của khách
        public double TinhTien()
        {
            // Tiền phòng cơ bản theo số ngày
            double tienPhong = GiaPhong * SoNgayO;

            // Tiền tiện nghi: 10.000đ cho mỗi tiện nghi được chọn
            double tienTienNghi = SoTienNghi * 10000;

            // Tiền dịch vụ
            double tienDichVu = 0;
            if (CoKaraoke) tienDichVu += 50000;
            if (CoAnSang) tienDichVu += 15000 * SoNgayO;

            return tienPhong + tienTienNghi + tienDichVu;
        }
    }
}