using System;

namespace ThucHanh02
{
    interface IMyComparable
    {
        int CompareTo(object obj);
    }

    class PhanSo : IMyComparable
    {
        private int tu;
        private int mau;

        public int Tu
        {
            get { return tu; }
            set { tu = value; }
        }

        public int Mau
        {
            get { return mau; }
            set { mau = (value == 0) ? 1 : value; }
        }

        // Constructor mac nhien
        public PhanSo()
        {
            tu = 0;
            mau = 1;
        }

        // Constructor co tham so
        public PhanSo(int tu, int mau)
        {
            this.tu = tu;
            this.mau = (mau == 0) ? 1 : mau;
        }

        // Constructor sao chep
        public PhanSo(PhanSo ps)
        {
            this.tu = ps.tu;
            this.mau = ps.mau;
        }

        public void Nhap()
        {
            Console.Write("Nhap tu: ");
            Tu = int.Parse(Console.ReadLine() ?? "0");

            do
            {
                Console.Write("Nhap mau (khac 0): ");
                Mau = int.Parse(Console.ReadLine() ?? "1");
            } while (Mau == 0);
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", tu, mau);
        }

        // Cai dat interface IMyComparable (so sanh tich cheo tu va mau)
        public int CompareTo(object obj)
        {
            PhanSo other = obj as PhanSo;
            if (other == null) return 1;

            int left = this.tu * other.mau;
            int right = other.tu * this.mau;
            return left.CompareTo(right);
        }
    }

    class ThuatToanSapXep
    {
        // Mo phong Array.Sort dung Interface tong quat
        public static void MySort<T>(T[] array) where T : IMyComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }

    class Bai3_2
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap so luong phan so: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            PhanSo[] ds = new PhanSo[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap phan so thu {0}:", i + 1);
                ds[i] = new PhanSo();
                ds[i].Nhap();
            }

            Console.Write("\nMANG PHAN SO BAN DAU: ");
            foreach (PhanSo ps in ds) Console.Write("{0}  ", ps);
            Console.WriteLine();

            // Goi ham sap xep tu viet mo phong Array.Sort
            ThuatToanSapXep.MySort(ds);

            Console.Write("MANG PHAN SO SAU KHI SAP XEP (QUA INTERFACE): ");
            foreach (PhanSo ps in ds) Console.Write("{0}  ", ps);
            Console.WriteLine();
        }
    }
}