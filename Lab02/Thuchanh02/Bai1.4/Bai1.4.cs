using System;

namespace ThucHanh02
{
    class PhanSo
    {
        // Field
        private int tu;
        private int mau;

        // Property
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
                if (value == 0)
                {
                    mau = 1;
                }
                else
                {
                    mau = value;
                }
            }
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
            if (mau == 0)
            {
                this.mau = 1;
            }
            else
            {
                this.mau = mau;
            }
            RutGon();
        }

        // constructor 1 tham so
        public PhanSo(int giaTri)
        {
            this.tu = giaTri;
            this.mau = 1;
        }

        // constructor sao chep
        public PhanSo(PhanSo ps)
        {
            this.tu = ps.tu;
            this.mau = ps.mau;
        }

        // Ham tim uoc chung lon nhat
        private static int UCLN(int a, int b)
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

        // Phuong thuc rut gon phan so
        public void RutGon()
        {
            int ucln = UCLN(tu, mau);
            tu /= ucln;
            mau /= ucln;

            if (mau < 0)
            {
                tu = -tu;
                mau = -mau;
            }
        }

        // phuong thuc nhap, xuat
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

        public override string ToString()
        {
            if (mau == 1) return tu.ToString();
            return string.Format("{0}/{1}", tu, mau);
        }

        // Toan tu mot ngoi: +, -
        public static PhanSo operator +(PhanSo ps)
        {
            return new PhanSo(ps.Tu, ps.Mau);
        }

        public static PhanSo operator -(PhanSo ps)
        {
            return new PhanSo(-ps.Tu, ps.Mau);
        }

        // Toan tu hai ngoi: +, -, *, /
        public static PhanSo operator +(PhanSo ps1, PhanSo ps2)
        {
            int tuMoi = ps1.Tu * ps2.Mau + ps2.Tu * ps1.Mau;
            int mauMoi = ps1.Mau * ps2.Mau;
            return new PhanSo(tuMoi, mauMoi);
        }

        public static PhanSo operator -(PhanSo ps1, PhanSo ps2)
        {
            int tuMoi = ps1.Tu * ps2.Mau - ps2.Tu * ps1.Mau;
            int mauMoi = ps1.Mau * ps2.Mau;
            return new PhanSo(tuMoi, mauMoi);
        }

        public static PhanSo operator *(PhanSo ps1, PhanSo ps2)
        {
            int tuMoi = ps1.Tu * ps2.Tu;
            int mauMoi = ps1.Mau * ps2.Mau;
            return new PhanSo(tuMoi, mauMoi);
        }

        public static PhanSo operator /(PhanSo ps1, PhanSo ps2)
        {
            int tuMoi = ps1.Tu * ps2.Mau;
            int mauMoi = ps1.Mau * ps2.Tu;
            return new PhanSo(tuMoi, mauMoi);
        }

        // Toan tu so sanh: ==, !=
        public static bool operator ==(PhanSo ps1, PhanSo ps2)
        {
            if (ReferenceEquals(ps1, ps2)) return true;
            if (ReferenceEquals(ps1, null) || ReferenceEquals(ps2, null)) return false;
            return (ps1.Tu * ps2.Mau) == (ps2.Tu * ps1.Mau);
        }

        public static bool operator !=(PhanSo ps1, PhanSo ps2)
        {
            return !(ps1 == ps2);
        }

        // Toan tu so sanh: >, <
        public static bool operator >(PhanSo ps1, PhanSo ps2)
        {
            return (ps1.Tu * ps2.Mau) > (ps2.Tu * ps1.Mau);
        }

        public static bool operator <(PhanSo ps1, PhanSo ps2)
        {
            return (ps1.Tu * ps2.Mau) < (ps2.Tu * ps1.Mau);
        }

        // Toan tu so sanh: >=, <=
        public static bool operator >=(PhanSo ps1, PhanSo ps2)
        {
            return (ps1.Tu * ps2.Mau) >= (ps2.Tu * ps1.Mau);
        }

        public static bool operator <=(PhanSo ps1, PhanSo ps2)
        {
            return (ps1.Tu * ps2.Mau) <= (ps2.Tu * ps1.Mau);
        }

        public override bool Equals(object obj)
        {
            if (obj is PhanSo ps)
            {
                return this == ps;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Tu, Mau).GetHashCode();
        }
    }

    class Bai1_4
    {
        public static void Main(string[] args)
        {
            PhanSo ps1 = new PhanSo();
            PhanSo ps2 = new PhanSo();

            Console.WriteLine("NHAP PHAN SO THU 1:");
            ps1.Nhap();

            Console.WriteLine("\nNHAP PHAN SO THU 2:");
            ps2.Nhap();

            Console.WriteLine("\nHAI PHAN SO VUA NHAP:");
            Console.WriteLine("Phan so 1: {0}", ps1);
            Console.WriteLine("Phan so 2: {0}", ps2);

            Console.WriteLine("\nTOAN TU MOT NGOI:");
            Console.WriteLine("+ps1 = {0}", +ps1);
            Console.WriteLine("-ps1 = {0}", -ps1);

            Console.WriteLine("\nTOAN TU HAI NGOI:");
            Console.WriteLine("Tong: {0} + {1} = {2}", ps1, ps2, ps1 + ps2);
            Console.WriteLine("Hieu: {0} - {1} = {2}", ps1, ps2, ps1 - ps2);
            Console.WriteLine("Tich: {0} * {1} = {2}", ps1, ps2, ps1 * ps2);
            Console.WriteLine("Thuong: {0} / {1} = {2}", ps1, ps2, ps1 / ps2);

            Console.WriteLine("\nTOAN TU SO SANH:");
            Console.WriteLine("{0} > {1}  : {2}", ps1, ps2, ps1 > ps2);
            Console.WriteLine("{0} < {1}  : {2}", ps1, ps2, ps1 < ps2);
            Console.WriteLine("{0} >= {1} : {2}", ps1, ps2, ps1 >= ps2);
            Console.WriteLine("{0} <= {1} : {2}", ps1, ps2, ps1 <= ps2);
            Console.WriteLine("{0} == {1} : {2}", ps1, ps2, ps1 == ps2);
            Console.WriteLine("{0} != {1} : {2}", ps1, ps2, ps1 != ps2);
        }
    }
}