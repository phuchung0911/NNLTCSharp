using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public static class Bai52
    {
        public static void Chay()
        {
            Console.WriteLine("\n-- Bài 5.2:");
            var ds = DuLieu.DS_Mon();

            // a. Cho biết tổng số môn hiện có.
            Console.WriteLine($"a. Tổng số môn hiện có: {ds.Count}");

            // b. Đếm số môn có tên bắt đầu bằng “Lập trình”.
            Console.WriteLine($"b. Số môn bắt đầu bằng 'Lập trình': {ds.Count(m => m.TenMon.StartsWith("Lập trình"))}");

            // c. Tính tổng số tiết của hệ Kỹ thuật viên (KTV).
            Console.WriteLine($"c. Tổng số tiết hệ KTV: {ds.Where(m => m.He == "KTV").Sum(m => m.SoTiet)}");

            // d. Cho biết tổng số môn của mỗi hệ: Hệ, Tổng số môn.
            Console.WriteLine("\nd. Tổng số môn của mỗi hệ:");
            foreach (var g in ds.GroupBy(m => string.IsNullOrEmpty(m.He) ? "(Chưa gán)" : m.He))
                Console.WriteLine($"   Hệ {g.Key,-8}: {g.Count()} môn");

            // e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết.
            Console.WriteLine("\ne. Nhóm theo Số tiết giảm dần:");
            foreach (var g in ds.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key))
                Console.WriteLine($"   {g.Key,3} tiết: {g.Count()} môn");

            // f. Cho biết thông tin môn học có số tiết cao nhất.
            byte maxTiet = ds.Max(m => m.SoTiet);
            var monMax = ds.First(m => m.SoTiet == maxTiet);
            Console.WriteLine($"\nf. Thông tin môn học có số tiết cao nhất: {monMax.MaMon} - {monMax.TenMon} ({monMax.SoTiet} tiết)");

            // g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, số tiết thấp nhất.
            Console.WriteLine("\ng. Thống kê theo Hệ:");
            foreach (var g in ds.GroupBy(m => string.IsNullOrEmpty(m.He) ? "(Chưa gán)" : m.He))
            {
                Console.WriteLine($"   Hệ {g.Key,-8}");
                Console.WriteLine($"   Môn: {g.Count()}");
                Console.WriteLine($"   Tổng tiết: {g.Sum(x => x.SoTiet)}");
                Console.WriteLine($"   Max: {g.Max(x => x.SoTiet)}");
                Console.WriteLine($"   Min: {g.Min(x => x.SoTiet)}");
            }

            // h. Liệt kê các môn học được phân nhóm theo Hệ.
            Console.WriteLine("\nh. Danh sách môn theo Hệ:");
            foreach (var g in ds.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Chưa gán hệ" : m.He))
            {
                Console.WriteLine($"   [Hệ {g.Key}]");
                foreach (var m in g) Console.WriteLine($"      - {m.TenMon}");
            }

            //i. Liệt kê các môn học được phân nhóm theo Số tiết và tăng dần theo Số tiết.
            Console.WriteLine("\ni. Nhóm môn theo Số tiết tăng dần:");
            foreach (var g in ds.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
            {
                Console.WriteLine($"   [{g.Key} tiết]: " + string.Join(", ", g.Select(x => x.MaMon)));
            }

            //j. Với hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn.
            Console.WriteLine("\nj. Hệ KTV theo học phần:");
            var ktv = ds.Where(m => m.He == "KTV").GroupBy(m => m.MaMon.Split(' ')[0]);
            foreach (var g in ktv)
            {
                Console.WriteLine($"   [{g.Key}]: " + string.Join(", ", g.Select(x => x.TenMon)));
            }

            // k. Phân nhóm theo Hệ, chỉ lấy các môn có Số tiết > 40; trong mỗi nhóm sắp xếp theo Mã môn.
            Console.WriteLine("\nk. Các môn có > 40 tiết theo từng hệ:");
            foreach (var g in ds.Where(m => m.SoTiet > 40).GroupBy(m => m.He))
            {
                Console.WriteLine($"   [Hệ {g.Key}]");
                foreach (var m in g.OrderBy(x => x.MaMon)) Console.WriteLine($"      - {m.MaMon}: {m.TenMon} ({m.SoTiet}t)");
            }
        }
    }
}