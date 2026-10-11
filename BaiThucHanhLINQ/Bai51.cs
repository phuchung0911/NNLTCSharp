using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public static class Bai51
    {
        public static void Chay()
        {
            Console.WriteLine("\n-- Bài 5.1:");
            var ds = DuLieu.DS_Mon();

            // a. Liệt kê tên các môn học bắt đầu bằng “Lập trình”.
            var cauA = ds.Where(m => m.TenMon.StartsWith("Lập trình")).Select(m => m.TenMon);
            Console.WriteLine("a. Môn bắt đầu bằng 'Lập trình':\n   " + string.Join("\n   ", cauA));

            // b. Liệt kê các môn thuộc hệ “CD”, sắp xếp số tiết giảm dần rồi mã môn tăng dần.
            var cauB = ds.Where(m => m.He == "CD")
                         .OrderByDescending(m => m.SoTiet)
                         .ThenBy(m => m.MaMon);
            Console.WriteLine("\nb. Hệ CD (tiết giảm dần, mã môn tăng dần):");
            foreach (var m in cauB) Console.WriteLine($"   {m.MaMon,-6}");
            foreach (var m in cauB) Console.WriteLine($"   {m.TenMon,-40}");
            foreach (var m in cauB) Console.WriteLine($"   {m.SoTiet} tiết");

            // c. Liệt kê các môn có tên chứa từ “web”, chỉ lấy Tên môn và Hệ.
            var cauC = ds.Where(m => m.TenMon.ToLower().Contains("web"))
                         .Select(m => new { m.TenMon, m.He });
            Console.WriteLine("\nc. Môn có chứa 'web':");
            foreach (var m in cauC) Console.WriteLine($"   {m.TenMon,-45}");
            foreach (var m in cauC) Console.WriteLine($"   Hệ: {m.He,-3}");

            // d. Liệt kê các môn thuộc hệ “KTV”, sắp xếp tăng dần theo Mã môn.
            var cauD = ds.Where(m => m.He == "KTV").OrderBy(m => m.MaMon);
            Console.WriteLine("\nd. Hệ KTV sắp theo Mã môn:");
            foreach (var m in cauD) Console.WriteLine($"   {m.MaMon,-6}");
            foreach (var m in cauD) Console.WriteLine($"   {m.TenMon}");
        }
    }
}