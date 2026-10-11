using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public static class Bai62
    {
        public static void Chay()
        {
            Console.WriteLine("\n-- Bài 6.2:");
            var dsMon = DuLieu.DS_Mon();
            var dsHe = DuLieu.DS_He();

            // a. Dùng join để liệt kê: Tên hệ, Mã môn, Tên môn.
            var cauA = from m in dsMon
                       join h in dsHe on m.He equals h.MaHe
                       select new { h.TenHe, m.MaMon, m.TenMon };
            Console.WriteLine("a. Dùng Join để liệt kê (mẫu 3 dòng):");
            foreach (var item in cauA.Take(3))
            {
                // In trên cùng 1 dòng cho đúng định dạng bảng
                Console.WriteLine($"   {item.TenHe,-20} | {item.MaMon,-6} | {item.TenMon}");
            }

            // b. Liệt kê cả những hệ chưa có môn học (left outer join với GroupJoin + DefaultIfEmpty).
            var cauB = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into nhom
                       from sub in nhom.DefaultIfEmpty()
                       select new { h.TenHe, TenMon = sub != null ? sub.TenMon : "(Chưa có môn học)" };
            Console.WriteLine("\nb. Left Outer Join (Hệ chưa có môn):");
            foreach (var item in cauB.Where(x => x.TenMon == "(Chưa có môn học)"))
                Console.WriteLine($"   Hệ: {item.TenHe} -> {item.TenMon}");

            // c. Liệt kê cả hệ chưa có môn học và môn học chưa khai báo hệ.
            var leftJoin = from h in dsHe
                           join m in dsMon on h.MaHe equals m.He into nhom
                           from sub in nhom.DefaultIfEmpty()
                           select new { TenHe = h.TenHe, TenMon = sub != null ? sub.TenMon : "(Trống)" };
            var rightOnly = from m in dsMon
                            where !dsHe.Any(h => h.MaHe == m.He)
                            select new { TenHe = "(Chưa khai báo hệ)", TenMon = m.TenMon };
            var cauC = leftJoin.Concat(rightOnly);
            Console.WriteLine("\nc. Liệt kê cả hệ chưa có môn học và môn học chưa khai báo hệ:");
            foreach (var item in cauC.Where(x => x.TenHe == "(Chưa khai báo hệ)" || x.TenMon == "(Trống)"))
            {
                Console.WriteLine($"   {item.TenHe,-22} | {item.TenMon}");
            } // <-- BẠN ĐÃ THIẾU DẤU ĐÓNG NGOẶC NÀY

            // d. Chỉ liệt kê những hệ chưa có môn học và những môn học chưa khai báo hệ.
            Console.WriteLine("\nd. Hệ chưa có môn & Môn chưa có hệ:");
            var heChuaMon = dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe));
            var monChuaHe = dsMon.Where(m => !dsHe.Any(h => h.MaHe == m.He));
            foreach (var h in heChuaMon) Console.WriteLine($"   - Hệ chưa có môn: [{h.MaHe}] {h.TenHe}");
            foreach (var m in monChuaHe) Console.WriteLine($"   - Môn chưa có hệ: [{m.MaMon}] {m.TenMon}");

            // e. Lấy 5 môn học đầu tiên có số tiết giảm dần; hiển thị Tên hệ, Mã môn, Tên môn, Số tiết.
            var cauE = (from m in dsMon
                        join h in dsHe on m.He equals h.MaHe into nhomHe
                        from subHe in nhomHe.DefaultIfEmpty()
                        orderby m.SoTiet descending
                        select new
                        {
                            TenHe = subHe != null ? subHe.TenHe : "(Chưa có hệ)",
                            m.MaMon,
                            m.TenMon,
                            m.SoTiet
                        }).Take(5);

            Console.WriteLine("\ne. 5 môn số tiết cao nhất:");
            foreach (var m in cauE)
            {
                // In đầy đủ cả Tên hệ, Mã môn, Tên môn, Số tiết trên cùng 1 dòng
                Console.WriteLine($"   {m.TenHe,-18} | {m.MaMon,-6} | {m.TenMon,-40} | {m.SoTiet} tiết");
            }

            // f. Cho biết tổng số môn học của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn.
            var cauF = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into nhom
                       select new { h.MaHe, h.TenHe, SoMon = nhom.Count() };
            Console.WriteLine("\nf. Tổng số môn của mỗi hệ:");
            foreach (var item in cauF) Console.WriteLine($"   [{item.MaHe}] {item.TenHe,-22}: {item.SoMon} môn");

            // g. Cho biết có bao nhiêu loại Số tiết khác nhau trong danh sách môn học.
            Console.WriteLine($"\ng. Có {dsMon.Select(m => m.SoTiet).Distinct().Count()} loại số tiết khác nhau.");

            // h. Tìm môn học đầu tiên có tên bắt đầu bằng “Lập trình”.
            var cauH = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"h. Môn đầu tiên bắt đầu bằng 'Lập trình': {cauH?.TenMon}");

            // i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm.
            Console.WriteLine("\ni. Đánh số thứ tự theo từng hệ:");
            var nhomSTT = from h in dsHe
                          join m in dsMon on h.MaHe equals m.He into nhom
                          select new
                          {
                              h.TenHe,
                              DanhSach = nhom.Select((mon, idx) => new { STT = idx + 1, mon.MaMon, mon.TenMon })
                          };
            foreach (var n in nhomSTT)
            {
                Console.WriteLine($"   * Hệ: {n.TenHe}");
                if (!n.DanhSach.Any()) Console.WriteLine("     (Không có môn nào)");
                foreach (var item in n.DanhSach) Console.WriteLine($"     {item.STT}. {item.MaMon,-6} | {item.TenMon}");
            }
        }
    }
}
