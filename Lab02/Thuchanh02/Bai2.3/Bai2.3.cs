using System;

namespace ThucHanh02
{
    class DaySo
    {
        // Field
        private int[] a;
        private int n;

        // Property
        public int N
        {
            get { return n; }
        }

        // Constructor mac nhien
        public DaySo()
        {
            n = 0;
            a = new int[0];
        }

        // Constructor co tham so
        public DaySo(int kichThuoc)
        {
            if (kichThuoc < 0)
            {
                kichThuoc = 0;
            }
            n = kichThuoc;
            a = new int[n];
        }

        // Constructor sao chep
        public DaySo(DaySo ds)
        {
            this.n = ds.n;
            this.a = new int[this.n];
            for (int i = 0; i < this.n; i++)
            {
                this.a[i] = ds.a[i];
            }
        }

        // Indexer truy cap phan tu thu i
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < n)
                {
                    return a[index];
                }
                throw new IndexOutOfRangeException("Chi so vuot qua pham vi!");
            }
            set
            {
                if (index >= 0 && index < n)
                {
                    a[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua pham vi!");
                }
            }
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhap so luong phan tu n (n > 0): ");
                n = int.Parse(Console.ReadLine() ?? "0");
            } while (n <= 0);

            a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap phan tu a[{0}]: ", i);
                a[i] = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        public void Xuat()
        {
            if (n == 0)
            {
                Console.WriteLine("Day so trong!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", this[i]);
            }
            Console.WriteLine();
        }

        // tim cac so chan
        public DaySo TimSoChan()
        {
            int dem = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                {
                    dem++;
                }
            }

            DaySo dsChan = new DaySo(dem);
            int viTri = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                {
                    dsChan[viTri] = a[i];
                    viTri++;
                }
            }

            return dsChan;
        }
    }

    class Bai2_3
    {
        public static void Main(string[] args)
        {
            DaySo ds = new DaySo();

            Console.WriteLine("NHAP DAY SO:");
            ds.Nhap();

            Console.Write("\nDAY SO VUA NHAP: ");
            ds.Xuat();

            // Kiem tra Indexer
            Console.WriteLine("\nKIEM TRA INDEXER:");
            Console.WriteLine("Phan tu dau tien ds[0] = {0}", ds[0]);

            // Tim so chan
            DaySo dsChan = ds.TimSoChan();
            Console.Write("\nCAC SO CHAN TRONG DAY: ");
            dsChan.Xuat();
        }
    }
}