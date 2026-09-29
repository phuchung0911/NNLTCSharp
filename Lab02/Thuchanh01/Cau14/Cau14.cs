using System;

namespace ThucHanh01
{
    class NhanVien
    {
        // Khai báo thuộc tính
        public string HoTen;
        public double MucLuong;
        public int SoNgayVang;

        // Phương thức nhập thông tin
        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap muc luong co ban: ");
            MucLuong = double.Parse(Console.ReadLine());

            Console.Write("Nhap so ngay vang: ");
            SoNgayVang = int.Parse(Console.ReadLine());
        }

        // Phương thức tính lương thực lãnh
        public double TinhLuong()
        {
            double luongThucLanh = MucLuong - (SoNgayVang * 100000);
            if (luongThucLanh < 0)
            {
                luongThucLanh = 0;
            }
            return luongThucLanh;
        }

        // Phương thức xuất thông tin
        public void Xuat()
        {
            Console.WriteLine("Ho ten: {0}", HoTen);
            Console.WriteLine("Muc luong: {0} VND", MucLuong);
            Console.WriteLine("So ngay vang: {0}", SoNgayVang);
            Console.WriteLine("Luong thuc lanh: {0} VND", TinhLuong());
        }
    }

    class Cau14
    {
        public static void Main(string[] args)
        {
            // Tạo nhân viên
            NhanVien nv = new NhanVien();

            // Nhập và xuất thông tin
            Console.WriteLine("NHAP THONG TIN NHAN VIEN:");
            nv.Nhap();

            Console.WriteLine("\nKET QUA TINH LUONG:");
            nv.Xuat();
        }
    }
}