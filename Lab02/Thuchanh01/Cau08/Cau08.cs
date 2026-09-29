using System;

namespace ThucHanh01
{
    class Cau08
    {
        // Phương thức hoán vị sử dụng từ khóa ref
        public static void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            double x, y;

            // Nhập dữ liệu
            Console.Write("Nhap so thuc x: ");
            x = double.Parse(Console.ReadLine());

            Console.Write("Nhap so thuc y: ");
            y = double.Parse(Console.ReadLine());

            // In giá trị trước khi hoán vị
            Console.WriteLine("Truoc khi hoan vi: x = {0}, y = {1}", x, y);

            // Gọi phương thức truyền tham chiếu ref
            HoanVi(ref x, ref y);

            // In giá trị sau khi hoán vị
            Console.WriteLine("Sau khi hoan vi: x = {0}, y = {1}", x, y);
        }
    }
}