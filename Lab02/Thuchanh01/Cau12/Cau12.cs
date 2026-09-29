using System;

namespace ThucHanh01
{
    class Cau12
    {
        // Phương thức đếm số từ trong chuỗi
        public static int DemSoTu(string s)
        {
            // Tách chuỗi theo khoảng trắng và tự động bỏ qua khoảng trắng thừa
            string[] cacTu = s.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return cacTu.Length;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            string str;

            // Nhập dữ liệu
            Console.Write("Nhap vao mot chuoi: ");
            str = Console.ReadLine();

            // Xử lý chuyển sang chữ thường và chữ hoa
            string chuoiThuong = str.ToLower();
            string chuoiHoa = str.ToUpper();

            // Đếm số từ
            int soTu = DemSoTu(str);

            // Xuất kết quả
            Console.WriteLine("Chuoi in thuong: {0}", chuoiThuong);
            Console.WriteLine("Chuoi in hoa: {0}", chuoiHoa);
            Console.WriteLine("So tu trong chuoi la: {0}", soTu);
        }
    }
}