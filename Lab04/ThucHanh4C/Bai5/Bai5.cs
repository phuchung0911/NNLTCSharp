namespace Bai5
{
    public class DocSo
    {
        private static readonly string[] ChuSo = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };

        // Đọc số nguyên dương từ 1 đến 999
        public static string ChuyenSoThanhChu(int n)
        {
            if (n < 1 || n > 999) return "Số nằm ngoài phạm vi (1 - 999)";

            int tram = n / 100;
            int chuc = (n % 100) / 10;
            int donVi = n % 10;

            string ketQua = "";

            // Đọc hàng trăm
            if (tram > 0)
            {
                ketQua += ChuSo[tram] + " Trăm ";
            }

            // Đọc hàng chục
            if (tram > 0 && chuc == 0 && donVi > 0)
            {
                ketQua += "Lẻ ";
            }
            else if (chuc == 1)
            {
                ketQua += "Mười ";
            }
            else if (chuc > 1)
            {
                ketQua += ChuSo[chuc] + " Mươi ";
            }

            // Đọc hàng đơn vị
            if (donVi == 1)
            {
                if (chuc > 1) ketQua += "Mốt";
                else ketQua += "Một";
            }
            else if (donVi == 5)
            {
                if (chuc > 0) ketQua += "Lăm";
                else ketQua += "Năm";
            }
            else if (donVi > 0)
            {
                ketQua += ChuSo[donVi];
            }

            return ketQua.Trim();
        }
    }
}