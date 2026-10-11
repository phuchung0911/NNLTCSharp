namespace BTNangCao
{
    public class HoaDonCafe
    {
        // Thông tin đơn hàng hiện tại
        public string TenKhachHang { get; set; } = "";
        public int SoKhachHang { get; set; } = 0;
        public bool LaSinhVien { get; set; } = false;
        public double GiaNuoc { get; set; } = 0;
        public double GiaThucAn { get; set; } = 0;

        public HoaDonCafe() { }

        public HoaDonCafe(string tenKH, int soKH, bool laSV, double giaNuoc, double giaThucAn)
        {
            TenKhachHang = tenKH;
            SoKhachHang = soKH;
            LaSinhVien = laSV;
            GiaNuoc = giaNuoc;
            GiaThucAn = giaThucAn;
        }

        // Tính thành tiền cho nhóm khách hiện tại (có xét giảm giá 20% nếu là SV)
        public double TinhThanhTien()
        {
            double tongTien = (GiaNuoc + GiaThucAn) * SoKhachHang;
            if (LaSinhVien)
            {
                tongTien *= 0.8; // Giảm giá 20%
            }
            return tongTien;
        }
    }
}