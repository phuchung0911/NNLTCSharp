using System.Text.RegularExpressions;

namespace Bai2
{
    public class KiemTraTaiKhoan
    {
        public static bool KiemTraEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string mauEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email.Trim(), mauEmail);
        }
    }
}