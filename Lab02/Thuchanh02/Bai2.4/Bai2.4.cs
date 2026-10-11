using System;

namespace ThucHanh02
{
    class MaTran
    {
        // Field
        private int[,] a;
        private int dong;
        private int cot;

        // Property
        public int Dong
        {
            get { return dong; }
        }

        public int Cot
        {
            get { return cot; }
        }

        // Constructor mac nhien
        public MaTran()
        {
            dong = 0;
            cot = 0;
            a = new int[0, 0];
        }

        // Constructor co tham so
        public MaTran(int dong, int cot)
        {
            this.dong = (dong < 0) ? 0 : dong;
            this.cot = (cot < 0) ? 0 : cot;
            a = new int[this.dong, this.cot];
        }

        // Constructor sao chep
        public MaTran(MaTran mt)
        {
            this.dong = mt.dong;
            this.cot = mt.cot;
            this.a = new int[this.dong, this.cot];
            for (int i = 0; i < this.dong; i++)
            {
                for (int j = 0; j < this.cot; j++)
                {
                    this.a[i, j] = mt.a[i, j];
                }
            }
        }

        // Indexer truy cap phan tu tai dong i, cot j
        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < dong && j >= 0 && j < cot)
                {
                    return a[i, j];
                }
                throw new IndexOutOfRangeException("Chi so dong hoac cot vuot qua pham vi!");
            }
            set
            {
                if (i >= 0 && i < dong && j >= 0 && j < cot)
                {
                    a[i, j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so dong hoac cot vuot qua pham vi!");
                }
            }
        }

        // Ham kiem tra mot so co phai so nguyen to hay khong
        private static bool KiemTraNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // Method: Nhap mang 2 chieu
        public void Nhap()
        {
            do
            {
                Console.Write("Nhap so dong n (n > 0): ");
                dong = int.Parse(Console.ReadLine() ?? "0");
            } while (dong <= 0);

            do
            {
                Console.Write("Nhap so cot m (m > 0): ");
                cot = int.Parse(Console.ReadLine() ?? "0");
            } while (cot <= 0);

            a = new int[dong, cot];
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    Console.Write("Nhap phan tu a[{0},{1}]: ", i, j);
                    a[i, j] = int.Parse(Console.ReadLine() ?? "0");
                }
            }
        }

        // Method: Xuat mang 2 chieu
        public void Xuat()
        {
            if (dong == 0 || cot == 0)
            {
                Console.WriteLine("Ma tran trong!");
                return;
            }

            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    Console.Write("{0}\t", this[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Method: Tim cac so nguyen to trong ma tran
        public void TimSoNguyenTo()
        {
            bool coNguyenTo = false;
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (KiemTraNguyenTo(a[i, j]))
                    {
                        Console.WriteLine("So nguyen to {0} tai vi tri [{1},{2}]", a[i, j], i, j);
                        coNguyenTo = true;
                    }
                }
            }

            if (!coNguyenTo)
            {
                Console.WriteLine("Khong co so nguyen to nao trong ma tran.");
            }
        }
    }

    class Bai2_4
    {
        public static void Main(string[] args)
        {
            MaTran mt = new MaTran();

            Console.WriteLine("NHAP MA TRAN:");
            mt.Nhap();

            Console.WriteLine("\nMA TRAN VUA NHAP:");
            mt.Xuat();

            // Kiem tra Indexer
            Console.WriteLine("\nKIEM TRA INDEXER:");
            Console.WriteLine("Phan tu tai vi tri [0,0] la: {0}", mt[0, 0]);

            // Tim so nguyen to
            Console.WriteLine("\nCAC SO NGUYEN TO TRONG MA TRAN:");
            mt.TimSoNguyenTo();
        }
    }
}