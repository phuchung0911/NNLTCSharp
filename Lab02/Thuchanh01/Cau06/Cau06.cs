using System;

namespace ThucHanh01
{
    class Cau06
    {
        // Phương thức truyền tham trị và return giá trị lớn nhất
        public static int TimMax(int a, int b, int c)
        {
            int max = a;

            if (b > max)
            {
                max = b;
            }

            if (c > max)
            {
                max = c;
            }

            return max;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            int x, y, z, ketQua;

            // Nhập dữ liệu
            Console.Write("Nhap so thu nhat: ");
            x = int.Parse(Console.ReadLine());

            Console.Write("Nhap so thu hai: ");
            y = int.Parse(Console.ReadLine());

            Console.Write("Nhap so thu ba: ");
            z = int.Parse(Console.ReadLine());

            // Gọi phương thức theo kiểu truyền tham trị và nhận giá trị return
            ketQua = TimMax(x, y, z);

            // Xuất kết quả
            Console.WriteLine("Gia tri lon nhat trong 3 so la: {0}", ketQua);
        }
    }
}