using System;

namespace ThucHanh01
{
    class Cau16
    {
        // Phương thức nhập danh sách họ tên
        public static void NhapDanhSach(string[] ds, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap ho ten thu {0}: ", i + 1);
                ds[i] = Console.ReadLine();
            }
        }

        // Phương thức in danh sách họ tên
        public static void InDanhSach(string[] ds)
        {
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, ds[i]);
            }
        }

        // Phương thức sắp xếp họ tên tăng dần
        public static void SapXepTangDan(string[] ds)
        {
            Array.Sort(ds);
        }

        public static void Main(string[] args)
        {
            // Nhập số lượng người
            Console.Write("Nhap so luong nguoi n: ");
            int n = int.Parse(Console.ReadLine());

            string[] danhSach = new string[n];

            // Nhập dữ liệu
            Console.WriteLine("\nNHAP DANH SACH HO TEN: ");
            NhapDanhSach(danhSach, n);

            // Sắp xếp
            SapXepTangDan(danhSach);

            // Xuất kết quả
            Console.WriteLine("\nDANH SACH SAU KHI SAP XEP TANG DAN:");
            InDanhSach(danhSach);
        }
    }
}
