using System;

namespace ThucHanh01
{
    class SinhVien
    {
        // Khai báo các thuộc tính
        public string MaSV;
        public string HoTen;
        public string DiaChi;
        public int NamThu;

        // Phương thức nhập thông tin
        public void Nhap()
        {
            Console.Write("Nhap ma sinh vien: ");
            MaSV = Console.ReadLine();

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();

            Console.Write("Nhap sinh vien nam thu may: ");
            NamThu = int.Parse(Console.ReadLine());
        }

        // Phương thức xuất thông tin
        public void Xuat()
        {
            Console.WriteLine("Ma SV: {0}", MaSV);
            Console.WriteLine("Ho ten: {0}", HoTen);
            Console.WriteLine("Dia chi: {0}", DiaChi);
            Console.WriteLine("Sinh vien nam thu: {0}", NamThu);
        }
    }

    class Cau13
    {
        public static void Main(string[] args)
        {
            // Tạo sinh viên
            SinhVien sv = new SinhVien();

            // Nhập thông tin
            Console.WriteLine("NHAP THONG TIN SINH VIEN:");
            sv.Nhap();

            // Xuất thông tin
            Console.WriteLine("\nTHONG TIN SINH VIEN VUA NHAP:");
            sv.Xuat();
        }
    }
}