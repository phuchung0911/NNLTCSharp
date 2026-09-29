using System;
using System.Collections.Generic;

namespace ThucHanh02
{
    class NhanVien
    {
        // Field
        private string hoTen;
        private double mucLuong;
        private int soNgayVang;

        // Property
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public double MucLuong
        {
            get { return mucLuong; }
            set { mucLuong = (value < 0) ? 0 : value; }
        }

        public int SoNgayVang
        {
            get { return soNgayVang; }
            set { soNgayVang = (value < 0) ? 0 : value; }
        }

        // Constructor mac nhien
        public NhanVien()
        {
            hoTen = "";
            mucLuong = 0;
            soNgayVang = 0;
        }

        // Constructor co tham so
        public NhanVien(string hoTen, double mucLuong, int soNgayVang)
        {
            this.hoTen = hoTen;
            this.mucLuong = (mucLuong < 0) ? 0 : mucLuong;
            this.soNgayVang = (soNgayVang < 0) ? 0 : soNgayVang;
        }

        // Constructor sao chep
        public NhanVien(NhanVien nv)
        {
            this.hoTen = nv.hoTen;
            this.mucLuong = nv.mucLuong;
            this.soNgayVang = nv.soNgayVang;
        }

        // Method: Nhap
        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine() ?? "";

            Console.Write("Nhap muc luong: ");
            MucLuong = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap so ngay vang: ");
            SoNgayVang = int.Parse(Console.ReadLine() ?? "0");
        }

        // Method: Tinh luong thuc lanh (tru 100.000 cho moi ngay vang)
        public double TinhLuong()
        {
            double luong = MucLuong - (SoNgayVang * 100000.0);
            return (luong < 0) ? 0 : luong;
        }

        // Method: Xuat
        public void Xuat()
        {
            Console.WriteLine("Ho ten: {0,-20} | Muc luong: {1,12:N0} | Ngay vang: {2,2} | Thuc lanh: {3,12:N0} VND",
                HoTen, MucLuong, SoNgayVang, TinhLuong());
        }
    }

    // Lop PhongBan quan ly n nhan vien
    class PhongBan
    {
        // Field
        private List<NhanVien> dsNhanVien;

        // Constructor mac nhien
        public PhongBan()
        {
            dsNhanVien = new List<NhanVien>();
        }

        // Constructor co tham so
        public PhongBan(int capacity)
        {
            dsNhanVien = new List<NhanVien>(capacity);
        }

        // Constructor sao chep
        public PhongBan(PhongBan pb)
        {
            dsNhanVien = new List<NhanVien>();
            for (int i = 0; i < pb.dsNhanVien.Count; i++)
            {
                dsNhanVien.Add(new NhanVien(pb.dsNhanVien[i]));
            }
        }

        // Indexer
        public NhanVien this[int i]
        {
            get
            {
                if (i >= 0 && i < dsNhanVien.Count)
                {
                    return dsNhanVien[i];
                }
                throw new IndexOutOfRangeException("Chi so nhan vien khong hop le!");
            }
            set
            {
                if (i >= 0 && i < dsNhanVien.Count)
                {
                    dsNhanVien[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so nhan vien khong hop le!");
                }
            }
        }

        // Method: Nhap
        public void Nhap()
        {
            Console.Write("Nhap so luong nhan vien n: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap thong tin nhan vien thu {0}:", i + 1);
                NhanVien nv = new NhanVien();
                nv.Nhap();
                dsNhanVien.Add(nv);
            }
        }

        // Method: Xuat
        public void Xuat()
        {
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                Console.Write("{0}. ", i + 1);
                this[i].Xuat();
            }
        }

        // Method: Tinh tong luong cua phong ban
        public double TongLuongPhongBan()
        {
            double tong = 0;
            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                tong += dsNhanVien[i].TinhLuong();
            }
            return tong;
        }
    }

    class Bai2_5
    {
        public static void Main(string[] args)
        {
            PhongBan pb = new PhongBan();

            Console.WriteLine("NHAP THONG TIN PHONG BAN:");
            pb.Nhap();

            Console.WriteLine("\nDANH SACH NHAN VIEN VA TIEN LUONG:");
            pb.Xuat();

            // Tinh va in tong luong
            Console.WriteLine("\nTong luong cua toan bo phong ban: {0:N0} VND", pb.TongLuongPhongBan());
        }
    }
}