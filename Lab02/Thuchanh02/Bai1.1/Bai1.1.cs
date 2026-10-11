using System;

namespace ThucHanh02
{
    class SinhVien
    {
        // Field
        private string hoTen;
        private int namSinh;

        // Constructor
        public SinhVien()
        {
            hoTen = "";
            namSinh = 0;
        }

        public SinhVien(string hoTen, int namSinh)
        {
            this.hoTen = hoTen;
            this.namSinh = namSinh;
        }

        // Property
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public int NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }

        // Method
        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.Write("Nhap nam sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
        }

        public int TinhTuoi()
        {
            int namHienTai = DateTime.Now.Year;
            return namHienTai - NamSinh;
        }

        public void Xuat()
        {
            Console.WriteLine("Ho ten: {0}", HoTen);
            Console.WriteLine("Nam sinh: {0}", NamSinh);
            Console.WriteLine("Tuoi hien tai: {0}", TinhTuoi());
        }
    }

    class Bai1_1
    {
        public static void Main(string[] args)
        {
            SinhVien sv = new SinhVien();

            Console.WriteLine("NHAP THONG TIN SINH VIEN:");
            sv.Nhap();

            Console.WriteLine("\nTHONG TIN VA TUOI CUA SINH VIEN:");
            sv.Xuat();
        }
    }
}