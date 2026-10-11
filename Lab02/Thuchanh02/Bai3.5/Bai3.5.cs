using System;
using System.Collections.Generic;

namespace ThucHanh02
{
    // lop cha NhanVien chua thong tin chung
    abstract class NhanVien
    {
        // field chung
        protected string maNV;
        protected string hoTen;

        // property
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        // constructor mac nhien
        public NhanVien()
        {
            maNV = "";
            hoTen = "";
        }

        // constructor co tham so
        public NhanVien(string maNV, string hoTen)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
        }

        // constructor sao chep
        public NhanVien(NhanVien nv)
        {
            this.maNV = nv.maNV;
            this.hoTen = nv.hoTen;
        }

        // nhap thong tin chung
        public virtual void Nhap()
        {
            Console.Write("Nhap ma NV: ");
            MaNV = Console.ReadLine() ?? "";

            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine() ?? "";
        }

        // phuong thuc truu tuong tinh luong de lop con tu override
        public abstract double TinhLuong();

        // xuat thong tin co ban
        public virtual void Xuat()
        {
            Console.Write("Ma NV: {0,-8} | Ho ten: {1,-18} | Luong: {2,12:N0} VND", MaNV, HoTen, TinhLuong());
        }
    }

    // lop NhanVienKinhDoanh ke thua NhanVien
    class NhanVienKinhDoanh : NhanVien
    {
        private double luongCoBan;
        private int soHopDong;

        // constructor mac nhien
        public NhanVienKinhDoanh() : base()
        {
            luongCoBan = 0;
            soHopDong = 0;
        }

        // constructor co tham so
        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, int soHopDong) : base(maNV, hoTen)
        {
            this.luongCoBan = luongCoBan;
            this.soHopDong = soHopDong;
        }

        // constructor sao chep
        public NhanVienKinhDoanh(NhanVienKinhDoanh nvkd) : base(nvkd)
        {
            this.luongCoBan = nvkd.luongCoBan;
            this.soHopDong = nvkd.soHopDong;
        }

        // nhap thong tin nhan vien kinh doanh
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap luong co ban: ");
            luongCoBan = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap so hop dong ky duoc: ");
            soHopDong = int.Parse(Console.ReadLine() ?? "0");
        }

        // tinh luong: luong co ban + moi hop dong duoc 500k
        public override double TinhLuong()
        {
            return luongCoBan + (soHopDong * 500000.0);
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine(" (Nhan vien kinh doanh)");
        }
    }

    // lop NhanVienSanXuat ke thua NhanVien
    class NhanVienSanXuat : NhanVien
    {
        private int soSanPham;

        // constructor mac nhien
        public NhanVienSanXuat() : base()
        {
            soSanPham = 0;
        }

        // constructor co tham so
        public NhanVienSanXuat(string maNV, string hoTen, int soSanPham) : base(maNV, hoTen)
        {
            this.soSanPham = soSanPham;
        }

        // constructor sao chep
        public NhanVienSanXuat(NhanVienSanXuat nvsx) : base(nvsx)
        {
            this.soSanPham = nvsx.soSanPham;
        }

        // nhap thong tin nhan vien san xuat
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so luong san pham: ");
            soSanPham = int.Parse(Console.ReadLine() ?? "0");
        }

        // tinh luong: moi san pham 1000, tren 3000 sp thi thuong 5%
        public override double TinhLuong()
        {
            double luong = soSanPham * 1000.0;
            if (soSanPham > 3000)
            {
                luong = luong * 1.05;
            }
            return luong;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine(" (Nhan vien san xuat)");
        }
    }

    class Bai3_5
    {
        public static void Main(string[] args)
        {
            List<NhanVien> ds = new List<NhanVien>();

            Console.Write("Nhap so luong nhan vien: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap nhan vien thu {0}:", i + 1);
                Console.WriteLine("1. Nhan vien kinh doanh");
                Console.WriteLine("2. Nhan vien san xuat");
                Console.Write("Chon loai nhan vien: ");
                int loai = int.Parse(Console.ReadLine() ?? "1");

                NhanVien nv;
                if (loai == 1)
                {
                    nv = new NhanVienKinhDoanh();
                }
                else
                {
                    nv = new NhanVienSanXuat();
                }

                nv.Nhap();
                ds.Add(nv);
            }

            Console.WriteLine("\nDANH SACH NHAN VIEN VA TIEN LUONG:");
            double tongLuong = 0;
            for (int i = 0; i < ds.Count; i++)
            {
                ds[i].Xuat();
                tongLuong += ds[i].TinhLuong();
            }

            Console.WriteLine("\nTong tien luong toan bo cong ty: {0:N0} VND", tongLuong);
        }
    }
}