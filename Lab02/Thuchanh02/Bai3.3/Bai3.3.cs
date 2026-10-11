using System;

namespace ThucHanh02
{
    // khai bao delegate dung lam con tro ham so sanh 2 so
    public delegate int SoSanhDelegate(int a, int b);

    class Bai3_3
    {
        // ham sap xep mang truyen vao delegate de biet xep kieu gi
        public static void SapXep(int[] a, SoSanhDelegate soSanh)
        {
            // chay 2 vong for de doi cho truc tiep
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    // neu ham so sanh tra ve > 0 thi hoan doi vi tri
                    if (soSanh(a[i], a[j]) > 0)
                    {
                        int tam = a[i];
                        a[i] = a[j];
                        a[j] = tam;
                    }
                }
            }
        }

        // ham de truyen vao xep tang dan
        public static int TangDan(int a, int b)
        {
            return a.CompareTo(b);
        }

        // ham de truyen vao xep giam dan
        public static int GiamDan(int a, int b)
        {
            return b.CompareTo(a);
        }

        // ham in mang ra man hinh
        public static void XuatMang(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            // nhap
            Console.Write("Nhap so luong phan tu n: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            // tao mang va nhap tung phan tu
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = int.Parse(Console.ReadLine() ?? "0");
            }

            Console.Write("\nMANG BAN DAU: ");
            XuatMang(a);

            // goi ham sap xep tang dan qua delegate TangDan
            SapXep(a, TangDan);
            Console.Write("MANG SAP XEP TANG DAN: ");
            XuatMang(a);

            // goi ham sap xep giam dan qua delegate GiamDan
            SapXep(a, GiamDan);
            Console.Write("MANG SAP XEP GIAM DAN: ");
            XuatMang(a);
        }
    }
}