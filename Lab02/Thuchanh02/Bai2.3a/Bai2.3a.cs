using System;

namespace ThucHanh02
{
    // Lop DonThuc thanh phan
    class DonThuc
    {
        private double heSo;
        private int soMu;

        public double HeSo
        {
            get { return heSo; }
            set { heSo = value; }
        }

        public int SoMu
        {
            get { return soMu; }
            set { soMu = (value < 0) ? 0 : value; }
        }

        // Constructor mac nhien
        public DonThuc()
        {
            heSo = 0;
            soMu = 0;
        }

        // Constructor co tham so
        public DonThuc(double heSo, int soMu)
        {
            this.heSo = heSo;
            this.soMu = (soMu < 0) ? 0 : soMu;
        }

        // Constructor sao chep
        public DonThuc(DonThuc dt)
        {
            this.heSo = dt.heSo;
            this.soMu = dt.soMu;
        }

        public double TinhGiaTri(double x)
        {
            return heSo * Math.Pow(x, soMu);
        }

        public override string ToString()
        {
            if (soMu == 0) return string.Format("{0}", heSo);
            if (soMu == 1) return string.Format("{0}x", heSo);
            return string.Format("{0}x^{1}", heSo, soMu);
        }
    }

    // Lop phuc DaThuc
    class DaThuc
    {
        // Field: mang cac don thuc co bac tu 0 den n
        private DonThuc[] dsDonThuc;
        private int bac;

        // Property
        public int Bac
        {
            get { return bac; }
        }

        // Constructor mac nhien
        public DaThuc()
        {
            bac = 0;
            dsDonThuc = new DonThuc[1];
            dsDonThuc[0] = new DonThuc(0, 0);
        }

        // Constructor co tham so
        public DaThuc(int bac)
        {
            this.bac = (bac < 0) ? 0 : bac;
            dsDonThuc = new DonThuc[this.bac + 1];
            for (int i = 0; i <= this.bac; i++)
            {
                dsDonThuc[i] = new DonThuc(0, i);
            }
        }

        // Constructor sao chep
        public DaThuc(DaThuc dt)
        {
            this.bac = dt.bac;
            this.dsDonThuc = new DonThuc[this.bac + 1];
            for (int i = 0; i <= this.bac; i++)
            {
                this.dsDonThuc[i] = new DonThuc(dt.dsDonThuc[i]);
            }
        }

        // Indexer de truy cap don thuc thu i
        public DonThuc this[int i]
        {
            get
            {
                if (i >= 0 && i <= bac)
                {
                    return dsDonThuc[i];
                }
                throw new IndexOutOfRangeException("Chi so don thuc khong hop le!");
            }
            set
            {
                if (i >= 0 && i <= bac)
                {
                    dsDonThuc[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so don thuc khong hop le!");
                }
            }
        }

        // Method: Nhap
        public void Nhap()
        {
            do
            {
                Console.Write("Nhap bac cua da thuc n (n >= 0): ");
                bac = int.Parse(Console.ReadLine() ?? "0");
            } while (bac < 0);

            dsDonThuc = new DonThuc[bac + 1];
            for (int i = 0; i <= bac; i++)
            {
                Console.Write("Nhap he so cho a{0} (x^{1}): ", i, i);
                double hs = double.Parse(Console.ReadLine() ?? "0");
                dsDonThuc[i] = new DonThuc(hs, i);
            }
        }

        // Method: Xuat
        public void Xuat()
        {
            bool dauTien = true;
            for (int i = 0; i <= bac; i++)
            {
                if (this[i].HeSo != 0 || bac == 0)
                {
                    if (!dauTien && this[i].HeSo > 0)
                    {
                        Console.Write(" + ");
                    }
                    else if (!dauTien && this[i].HeSo < 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(this[i]);
                    dauTien = false;
                }
            }
            if (dauTien) Console.Write("0");
            Console.WriteLine();
        }

        // Method: Tinh gia tri da thuc voi gia tri x cho truoc
        public double TinhGiaTri(double x)
        {
            double tong = 0;
            for (int i = 0; i <= bac; i++)
            {
                tong += this[i].TinhGiaTri(x);
            }
            return tong;
        }
    }

    class Bai2_3_Main
    {
        public static void Main(string[] args)
        {
            DaThuc P = new DaThuc();

            Console.WriteLine("NHAP DA THUC P(x):");
            P.Nhap();

            Console.Write("\nDA THUC P(x) = ");
            P.Xuat();

            Console.WriteLine("\nKIEM TRA INDEXER:");
            Console.WriteLine("Don thuc bac 0: {0}", P[0]);

            Console.Write("\nNhap gia tri x can tinh: ");
            double x = double.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Gia tri P({0}) = {1}", x, P.TinhGiaTri(x));
        }
    }
}