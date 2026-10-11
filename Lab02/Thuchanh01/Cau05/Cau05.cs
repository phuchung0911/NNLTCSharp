using System;

namespace ThucHanh01
{
    class Cau05
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double x = 0, y = 0;
            int chon;
            bool daNhap = false;

            do
            {
                // In menu
                Console.WriteLine("\nMENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");
                chon = int.Parse(Console.ReadLine());

                // Xử lý lựa chọn
                switch (chon)
                {
                    case 1:
                        Console.Write("Nhap so thuc x: ");
                        x = double.Parse(Console.ReadLine());
                        Console.Write("Nhap so thuc y: ");
                        y = double.Parse(Console.ReadLine());
                        daNhap = true;
                        Console.WriteLine("Da luu hai so x va y thanh cong!");
                        break;

                    case 2:
                        if (!daNhap)
                        {
                            Console.WriteLine("Vui long chon 1 de nhap x va y truoc!");
                        }
                        else
                        {
                            Console.WriteLine("Ket qua {0}^{1} la: {2}", x, y, Math.Pow(x, y));
                        }
                        break;

                    case 3:
                        if (!daNhap)
                        {
                            Console.WriteLine("Vui long chon 1 de nhap x va y truoc!");
                        }
                        else
                        {
                            if (x >= 0)
                                Console.WriteLine("Can bac 2 cua x ({0}) la: {1}", x, Math.Sqrt(x));
                            else
                                Console.WriteLine("Khong tinh duoc can bac 2 cua x vi x < 0");

                            if (y >= 0)
                                Console.WriteLine("Can bac 2 cua y ({0}) la: {1}", y, Math.Sqrt(y));
                            else
                                Console.WriteLine("Khong tinh duoc can bac 2 cua y vi y < 0");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Chuong trinh ket thuc. Tam biet!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long chon tu 1 den 4!");
                        break;
                }
            } while (chon != 4);
        }
    }
}