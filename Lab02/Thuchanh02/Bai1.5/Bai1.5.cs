using System;

namespace ThucHanh02
{
    class DonThuc
    {
        // Field
        private double heSo;
        private int soMu;

        // Property
        public double HeSo
        {
            get { return heSo; }
            set { heSo = value; }
        }

        public int SoMu
        {
            get { return soMu; }
            set 
            { 
                if (value < 0)
                {
                    soMu = 0;
                }
                else
                {
                    soMu = value;
                }
            }
        }

        // constructor
        public DonThuc()
        {
            heSo = 0;
            soMu = 0;
        }

        // constructor co tham so
        public DonThuc(double heSo, int soMu)
        {
            this.heSo = heSo;
            this.soMu = (soMu < 0) ? 0 : soMu;
        }

        // constructor sao chep
        public DonThuc(DonThuc dt)
        {
            this.heSo = dt.heSo;
            this.soMu = dt.soMu;
        }

        // Method
        public void Nhap()
        {
            Console.Write("Nhap he so a: ");
            HeSo = double.Parse(Console.ReadLine() ?? "0");

            do
            {
                Console.Write("Nhap so mu n (n >= 0): ");
                SoMu = int.Parse(Console.ReadLine() ?? "0");
            } while (SoMu < 0);
        }

        public void Xuat()
        {
            if (HeSo == 0)
            {
                Console.WriteLine("0");
                return;
            }

            if (SoMu == 0)
            {
                Console.WriteLine("{0}", HeSo);
            }
            else if (SoMu == 1)
            {
                Console.WriteLine("{0}x", HeSo);
            }
            else
            {
                Console.WriteLine("{0}x^{1}", HeSo, SoMu);
            }
        }

        // a. Tinh gia tri don thuc voi x cho truoc
        public double TinhGiaTri(double x)
        {
            return HeSo * Math.Pow(x, SoMu);
        }

        // b. Dao ham don thuc: Q(x) = P'(x) = a * n * x^(n - 1)
        public DonThuc DaoHam()
        {
            if (SoMu == 0)
            {
                return new DonThuc(0, 0);
            }
            return new DonThuc(HeSo * SoMu, SoMu - 1);
        }
    }

    class Bai1_5
    {
        public static void Main(string[] args)
        {
            DonThuc P = new DonThuc();

            Console.WriteLine("NHAP DON THUC P(x):");
            P.Nhap();

            Console.Write("\nDON THUC VUA NHAP: P(x) = ");
            P.Xuat();

            // a. Tinh gia tri don thuc P(x)
            Console.Write("\nNhap gia tri x can tinh: ");
            double x = double.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Gia tri P({0}) = {1}", x, P.TinhGiaTri(x));

            // b. Dao ham don thuc P'(x)
            DonThuc Q = P.DaoHam();
            Console.Write("\nDao ham Q(x) = P'(x) = ");
            Q.Xuat();
        }
    }
}