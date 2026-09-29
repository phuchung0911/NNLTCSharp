using System;

namespace ThucHanh02
{
    class SinhVien : IComparable
    {
        private string maSV;
        private string hoTen;
        private double diemTB;

        public string MaSV
        {
            get { return maSV; }
            set { maSV = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public double DiemTB
        {
            get { return diemTB; }
            set { diemTB = value; }
        }

        // Constructor mac nhien
        public SinhVien()
        {
            maSV = "";
            hoTen = "";
            diemTB = 0;
        }

        // Constructor co tham so
        public SinhVien(string maSV, string hoTen, double diemTB)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.diemTB = diemTB;
        }

        // Constructor sao chep
        public SinhVien(SinhVien sv)
        {
            this.maSV = sv.maSV;
            this.hoTen = sv.hoTen;
            this.diemTB = sv.diemTB;
        }

        public void Nhap()
        {
            Console.Write("Nhap ma SV: ");
            MaSV = Console.ReadLine() ?? "";

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine() ?? "";

            Console.Write("Nhap diem TB: ");
            DiemTB = double.Parse(Console.ReadLine() ?? "0");
        }

        public void Xuat()
        {
            Console.WriteLine("Ma SV: {0,-10} | Ho ten: {1,-20} | Diem TB: {2,4:F1}", MaSV, HoTen, DiemTB);
        }

        // Cai dat IComparable de Array.Sort sap xep tang dan theo diem TB
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            SinhVien other = obj as SinhVien;
            if (other != null)
            {
                return this.DiemTB.CompareTo(other.DiemTB);
            }
            throw new ArgumentException("Doi tuong khong phai la SinhVien!");
        }
    }

    class Bai3_1
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap so luong sinh vien: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            SinhVien[] ds = new SinhVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap sinh vien thu {0}:", i + 1);
                ds[i] = new SinhVien();
                ds[i].Nhap();
            }

            Console.WriteLine("\nDANH SACH SINH VIEN BAN DAU:");
            foreach (SinhVien sv in ds)
            {
                sv.Xuat();
            }

            // sap xep bang arraysort
            Array.Sort(ds);

            Console.WriteLine("\nDANH SACH SINH VIEN SAU KHI SAP XEP TANG DAN THEO DIEM TB:");
            foreach (SinhVien sv in ds)
            {
                sv.Xuat();
            }
        }
    }
}