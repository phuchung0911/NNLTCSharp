using System;
using System.Collections.Generic;

namespace ThucHanh02
{
    class Person
    {
        // Field
        private string id;
        private string name;
        private int yob;
        private int yod;

        // Property
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Yob
        {
            get { return yob; }
            set { yob = value; }
        }

        public int Yod
        {
            get { return yod; }
            set { yod = value; }
        }

        // Constructor mac nhien
        public Person()
        {
            id = "";
            name = "";
            yob = 0;
            yod = 0;
        }

        // Constructor co tham so
        public Person(string id, string name, int yob, int yod)
        {
            this.id = id;
            this.name = name;
            this.yob = yob;
            this.yod = yod;
        }

        // Constructor sao chep
        public Person(Person p)
        {
            this.id = p.id;
            this.name = p.name;
            this.yob = p.yob;
            this.yod = p.yod;
        }

        // Method
        public void Input()
        {
            Console.Write("Nhap ma dinh danh (ID): ");
            Id = Console.ReadLine() ?? "";

            Console.Write("Nhap ho ten: ");
            Name = Console.ReadLine() ?? "";

            Console.Write("Nhap nam sinh (YOB): ");
            Yob = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap nam mat (YOD - nhap 0 neu con song): ");
            Yod = int.Parse(Console.ReadLine() ?? "0");
        }

        public bool IsLiving()
        {
            return Yod == 0;
        }

        public void Output()
        {
            Console.Write("ID: {0} | Ho ten: {1} | Nam sinh: {2}", Id, Name, Yob);
            if (IsLiving())
            {
                Console.WriteLine(" | Tinh trang: Con song");
            }
            else
            {
                Console.WriteLine(" | Nam mat: {0} | Tinh trang: Da mat", Yod);
            }
        }
    }

    class PersonList
    {
        // Field
        private List<Person> danhSach;

        // Constructor mac nhien
        public PersonList()
        {
            danhSach = new List<Person>();
        }

        // Constructor sao chep
        public PersonList(PersonList pl)
        {
            danhSach = new List<Person>();
            for (int i = 0; i < pl.danhSach.Count; i++)
            {
                danhSach.Add(new Person(pl.danhSach[i]));
            }
        }

        // Method: Them mot nguoi vao danh sach
        public void Add(Person x)
        {
            danhSach.Add(x);
        }

        // Method: Nhap danh sach
        public void Input()
        {
            Console.Write("Nhap so luong nguoi: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap thong tin nguoi thu {0}:", i + 1);
                Person p = new Person();
                p.Input();
                danhSach.Add(p);
            }
        }

        // Method: Xuat danh sach
        public void Output()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }

            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.Write("{0}. ", i + 1);
                danhSach[i].Output();
            }
        }

        // Method: Loc danh sach nhung nguoi con song
        public PersonList LivingPeople()
        {
            PersonList dsSong = new PersonList();
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (danhSach[i].IsLiving())
                {
                    dsSong.Add(new Person(danhSach[i]));
                }
            }
            return dsSong;
        }
    }

    class Bai2_2
    {
        public static void Main(string[] args)
        {
            PersonList dsNhanKhau = new PersonList();

            Console.WriteLine("NHAP DANH SACH NHAN KHAU:");
            dsNhanKhau.Input();

            Console.WriteLine("\nDANH SACH NHAN KHAU VUA NHAP:");
            dsNhanKhau.Output();

            // danh sach nguoi con song
            PersonList dsConSong = dsNhanKhau.LivingPeople();

            Console.WriteLine("\nDANH SACH NHUNG NGUOI CON SONG:");
            dsConSong.Output();
        }
    }
}