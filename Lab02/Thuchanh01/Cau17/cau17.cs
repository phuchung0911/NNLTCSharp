using System;
using System.Collections.Generic;

namespace ThucHanh01
{
    class Cau17
    {
        // Phương thức sinh ngẫu nhiên mảng hai chiều
        public static void SinhNgauNhien(int[,] a, int n, int m)
        {
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rd.Next(10, 101); // lấy giá trị tới 100 
                }
            }
        }

        // Phương thức in mảng 2 chiều ra màn hình
        public static void InMang2Chieu(int[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0, 5}", a[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Phương thức in mảng 1 chiều
        public static void InMang1Chieu(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }

        // Phương thức tách và trả về 2 mảng chẵn, lẻ bằng out
        public static void TachChanLe(int[,] a, int n, int m, out int[] mangChan, out int[] mangLe)
        {
            List<int> chan = new List<int>();
            List<int> le = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] % 2 == 0)
                        chan.Add(a[i, j]);
                    else
                        le.Add(a[i, j]);
                }
            }

            mangChan = chan.ToArray();
            mangLe = le.ToArray();
        }

        public static void Main(string[] args)
        {
            // Nhập số hàng n và số cột m
            Console.Write("Nhap so hang n: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine());

            int[,] a = new int[n, m];

            // Sinh ngẫu nhiên
            SinhNgauNhien(a, n, m);

            // In ma trận
            Console.WriteLine("\nMANG 2 CHIEU NGAU NHIEN:");
            InMang2Chieu(a, n, m);

            // Tách mảng chẵn lẻ
            int[] mangChan;
            int[] mangLe;
            TachChanLe(a, n, m, out mangChan, out mangLe);

            // In kết quả mảng chẵn lẻ
            Console.WriteLine("\nMANG CAC SO CHAN:");
            InMang1Chieu(mangChan);

            Console.WriteLine("\nMANG CAC SO LE:");
            InMang1Chieu(mangLe);
        }
    }
}
