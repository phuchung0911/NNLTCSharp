using System;
using System.Collections.Generic;

namespace ThucHanh01
{
    class Cau15
    {
        // Phương thức nhập mảng
        public static void NhapMang(int[] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = int.Parse(Console.ReadLine());
            }
        }

        // Phương thức in mảng
        public static void InMang(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }

        // Phương thức tìm max và min bằng tham chiếu out
        public static void TimMaxMin(int[] a, out int max, out int min)
        {
            max = a[0];
            min = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
                if (a[i] < min) min = a[i];
            }
        }

        // Hàm phụ kiểm tra số nguyên tố
        public static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // Phương thức trả về mảng các số nguyên tố
        public static int[] LayMangNguyenTo(int[] a)
        {
            List<int> danhSachNT = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (LaSoNguyenTo(a[i]))
                {
                    danhSachNT.Add(a[i]);
                }
            }

            return danhSachNT.ToArray();
        }

        public static void Main(string[] args)
        {
            // Nhập số lượng phần tử
            Console.Write("Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];

            // Nhập mảng
            Console.WriteLine("\nNHAP MANG:");
            NhapMang(a, n);

            // Xuất mảng
            Console.Write("\nMang vua nhap: ");
            InMang(a);

            // Tìm Max và Min
            int max, min;
            TimMaxMin(a, out max, out min);
            Console.WriteLine("Phan tu lon nhat: {0}", max);
            Console.WriteLine("Phan tu nho nhat: {0}", min);

            // Lọc mảng số nguyên tố
            int[] mangNT = LayMangNguyenTo(a);
            Console.Write("Mang cac so nguyen to: ");
            if (mangNT.Length > 0)
            {
                InMang(mangNT);
            }
            else
            {
                Console.WriteLine("Khong co so nguyen to nao trong mang.");
            }
        }
    }
}