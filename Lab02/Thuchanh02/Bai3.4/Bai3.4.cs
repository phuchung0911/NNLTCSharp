using System;
using System.Collections.Generic;

namespace ThucHanh02
{
    // delegate cho su kien chon menu
    public delegate void MenuHandler(int choice);

    // lop menu tong quat
    class ConsoleMenu
    {
        // danh sach luu ten cac muc menu
        protected List<string> dsChucNang;

        // su kien event ban ra khi nguoi dung chon chuc nang
        public event MenuHandler Choose;

        // constructor mac nhien
        public ConsoleMenu()
        {
            dsChucNang = new List<string>();
        }

        // ham de them mot dong chuc nang vao menu
        public void ThemChucNang(string tenChucNang)
        {
            dsChucNang.Add(tenChucNang);
        }

        // ham in ra menu theo dung form de bai
        public void Display()
        {
            Console.WriteLine("\nMenu");
            for (int i = 0; i < dsChucNang.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, dsChucNang[i]);
            }
            Console.WriteLine("0. Thoat chuong trinh");
        }

        // vong lap cho nguoi dung nhap va chay chuc nang
        public void Run()
        {
            int chon = -1;
            while (chon != 0)
            {
                Display();
                Console.Write("Thuc hien: ");
                chon = int.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine("Ban thuc hien chuc nang {0}", chon);

                // neu chon 0 thi thoat khoi vong lap
                if (chon == 0)
                {
                    Console.WriteLine("Ket thuc chuong trinh.");
                    break;
                }

                // goi event neu da co ham dang ky
                if (Choose != null)
                {
                    Choose(chon);
                }
            }
        }
    }

    // lop con ke thua ConsoleMenu de lam bai pt bac 2
    class PTBac2Console : ConsoleMenu
    {
        // cac he so cua phuong trinh
        private double a;
        private double b;
        private double c;

        // constructor mac nhien
        public PTBac2Console()
        {
            // them cac muc vao menu
            ThemChucNang("Nhap he so a, b, c");
            ThemChucNang("Giai phuong trinh bac 2");

            // gan ham xu ly vao event Choose cua lop cha
            this.Choose += ThucHienChucNang;
        }

        // ham nhap 3 he so a, b, c
        private void NhapHeSo()
        {
            Console.WriteLine("\n--- NHAP HE SO PHUONG TRINH AX^2 + BX + C = 0 ---");
            Console.Write("Nhap a: ");
            a = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap b: ");
            b = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap c: ");
            c = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Phuong trinh vua nhap: {0}x^2 + {1}x + {2} = 0", a, b, c);
        }

        // ham giai va in nghiem phuong trinh bac 2
        private void GiaiPT()
        {
            Console.WriteLine("\n--- KET QUA GIAI PHUONG TRINH ---");

            // neu a bang 0 thi la phuong trinh bac 1
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0) Console.WriteLine("Phuong trinh vo so nghiem.");
                    else Console.WriteLine("Phuong trinh vo nghiem.");
                }
                else
                {
                    Console.WriteLine("Phuong trinh bac nhat, co nghiem x = {0}", -c / b);
                }
            }
            else
            {
                // tinh delta
                double delta = b * b - 4 * a * c;

                if (delta < 0)
                {
                    Console.WriteLine("Phuong trinh vo nghiem.");
                }
                else if (delta == 0)
                {
                    Console.WriteLine("Phuong trinh co nghiem kep: x1 = x2 = {0}", -b / (2 * a));
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine("Phuong trinh co 2 nghiem phan biet:");
                    Console.WriteLine("x1 = {0}", x1);
                    Console.WriteLine("x2 = {0}", x2);
                }
            }
        }

        // ham dieu huong chuc nang theo so nguoi dung nhap
        private void ThucHienChucNang(int choice)
        {
            switch (choice)
            {
                case 1:
                    NhapHeSo();
                    break;
                case 2:
                    GiaiPT();
                    break;
                default:
                    Console.WriteLine("Chuc nang khong ton tai!");
                    break;
            }
        }
    }

    class Bai3_4
    {
        public static void Main(string[] args)
        {
            // tao doi tuong va cho chay menu
            PTBac2Console app = new PTBac2Console();
            app.Run();
        }
    }
}