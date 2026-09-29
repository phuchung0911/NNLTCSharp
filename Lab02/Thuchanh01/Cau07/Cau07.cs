using System;

namespace ThucHanh01
{
    class Cau07
    {
        // kiểm tra số nguyên tố
        public static bool KiemTraNguyenTo(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;

            // Nhập dữ liệu
            Console.Write("Nhap so nguyen n: ");
            n = int.Parse(Console.ReadLine());

            // Xử lý và xuất kết quả
            if (KiemTraNguyenTo(n))
            {
                Console.WriteLine("{0} la so nguyen to.", n);
            }
            else
            {
                Console.WriteLine("{0} khong phai la so nguyen to.", n);
            }
        }
    }
}