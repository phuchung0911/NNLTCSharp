using System;

namespace ThucHanh02
{
    // lop phan so co ban
    class PhanSo
    {
        // field
        private int tu;
        private int mau;

        // property
        public int Tu
        {
            get { return tu; }
            set { tu = value; }
        }

        public int Mau
        {
            get { return mau; }
            set 
            { 
                if (value == 0) mau = 1;
                else mau = value;
            }
        }

        // constructor mac nhien
        public PhanSo()
        {
            tu = 0;
            mau = 1;
        }

        // constructor co tham so
        public PhanSo(int tu, int mau)
        {
            this.tu = tu;
            this.mau = (mau == 0) ? 1 : mau;
            RutGon();
        }

        // constructor sao chep
        public PhanSo(PhanSo ps)
        {
            this.tu = ps.tu;
            this.mau = ps.mau;
        }

        // ham tim uoc chung lon nhat
        private int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        // ham rut gon phan so
        public void RutGon()
        {
            int uc = UCLN(tu, mau);
            tu /= uc;
            mau /= uc;

            // neu mau am thi doi dau len tu
            if (mau < 0)
            {
                tu = -tu;
                mau = -mau;
            }
        }

        // ham nhap 1 phan so
        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            Tu = int.Parse(Console.ReadLine() ?? "0");

            do
            {
                Console.Write("Nhap mau so (khac 0): ");
                Mau = int.Parse(Console.ReadLine() ?? "1");
            } while (Mau == 0);

            RutGon();
        }

        // ham xuat phan so dang chuoi
        public override string ToString()
        {
            if (mau == 1) return tu.ToString();
            return string.Format("{0}/{1}", tu, mau);
        }

        // nap chong toan tu cong 2 phan so
        public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
        {
            int tuMoi = ps1.Tu * ps2.Mau + ps2.Tu * ps1.Mau;
            int mauMoi = ps1.Mau * ps2.Mau;
            return new PhanSo(tuMoi, mauMoi);
        }
    }

    // lop day phan so chua n phan so
    class DayPhanSo
    {
        // field
        private PhanSo[] ds;
        private int n;

        // property
        public int N
        {
            get { return n; }
        }

        // constructor mac nhien
        public DayPhanSo()
        {
            n = 0;
            ds = new PhanSo[0];
        }

        // constructor co tham so
        public DayPhanSo(int n)
        {
            this.n = (n < 0) ? 0 : n;
            ds = new PhanSo[this.n];
        }

        // constructor sao chep
        public DayPhanSo(DayPhanSo dps)
        {
            this.n = dps.n;
            this.ds = new PhanSo[this.n];
            for (int i = 0; i < this.n; i++)
            {
                this.ds[i] = new PhanSo(dps.ds[i]);
            }
        }

        // indexer truy cap phan so thu i
        public PhanSo this[int i]
        {
            get
            {
                if (i >= 0 && i < n)
                {
                    return ds[i];
                }
                throw new IndexOutOfRangeException("Chi so vuot qua so luong phan so!");
            }
            set
            {
                if (i >= 0 && i < n)
                {
                    ds[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua so luong phan so!");
                }
            }
        }

        // ham nhap day phan so
        public void Nhap()
        {
            do
            {
                Console.Write("Nhap so luong phan so n (n > 0): ");
                n = int.Parse(Console.ReadLine() ?? "0");
            } while (n <= 0);

            ds = new PhanSo[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap phan so thu {0}:", i + 1);
                ds[i] = new PhanSo();
                ds[i].Nhap();
            }
        }

        // ham xuat day phan so
        public void Xuat()
        {
            if (n == 0)
            {
                Console.WriteLine("Day phan so trong!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0}  ", this[i]);
            }
            Console.WriteLine();
        }

        // ham tinh tong cua n phan so
        public PhanSo TinhTong()
        {
            PhanSo tong = new PhanSo(0, 1);
            for (int i = 0; i < n; i++)
            {
                // dung toan tu + da nap chong de cong don
                tong = tong + ds[i];
            }
            return tong;
        }
    }

    class Bai2_4
    {
        public static void Main(string[] args)
        {
            // khoi tao day phan so
            DayPhanSo day = new DayPhanSo();

            Console.WriteLine("NHAP DAY PHAN SO:");
            day.Nhap();

            Console.Write("\nDAY PHAN SO VUA NHAP: ");
            day.Xuat();

            // tinh tong n phan so
            PhanSo tong = day.TinhTong();
            Console.WriteLine("\nTong cua day phan so la: {0}", tong);
        }
    }
}