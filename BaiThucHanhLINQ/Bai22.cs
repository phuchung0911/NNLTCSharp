using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public static class Bai22
    {
        public static void Chay()
        {
            Console.WriteLine("\n-- Bài 2.2:");
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            // a. Có 4 ký tự và sắp xếp tăng dần theo ký tự đầu
            var cauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
            Console.WriteLine("a. 4 ký tự sắp tăng dần: " + string.Join(", ", cauA));

            // b. Biến đổi dạng: <chữ thường> - <CHỮ HOA>
            var cauB = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");
            Console.WriteLine("b. Biến đổi dạng thường - HOA: " + string.Join(" | ", cauB));

            // c. Chứa ký tự 'u'
            var cauC = mangChuoi.Where(s => s.Contains('u'));
            Console.WriteLine("c. Chứa ký tự 'u': " + string.Join(", ", cauC));

            // d. Các từ bắt đầu bằng chữ in hoa
            var cauD = mangChuoi.Where(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
            Console.WriteLine("d. Bắt đầu bằng chữ hoa: " + string.Join(" ", cauD));
        }
    }
}