using System.Collections.Generic;
using System.Linq;

namespace Bai4
{
    public class DaySo
    {
        // danh sách lưu trữ các số nguyên đã nhập
        private List<int> danhSach = new List<int>();

        public DaySo()
        {
            danhSach.Clear();
        }

        // Thêm một số mới vào dãy
        public void ThemSo(int so)
        {
            danhSach.Add(so);
        }

        // Xuất toàn bộ dãy số thành chuỗi 
        public string XuatDaySo()
        {
            return string.Join(" ", danhSach); // cách mỗi số bằng một khoảng trắng
        }

        // Tính tổng toàn bộ các phần tử trong dãy
        public int TinhTongTatCa()
        {
            return danhSach.Sum();
        }

        // Tính tổng các số chẵn
        public int TinhTongChan()
        {
            return danhSach.Where(x => x % 2 == 0).Sum();
        }

        // Tính tổng các số lẻ
        public int TinhTongLe()
        {
            return danhSach.Where(x => x % 2 != 0).Sum();
        }

        // Xóa trắng dãy để làm lại từ đầu
        public void LamMoi()
        {
            danhSach.Clear();
        }

        // Kiểm tra xem dãy đã có phần tử nào chưa
        public bool CoPhanTu()
        {
            return danhSach.Count > 0;
        }
    }
}