using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai2
{
    public class MangSoNguyen
    {
        // Danh sách lưu trữ các phần tử mảng số nguyên
        private List<int> danhSach;

        public MangSoNguyen()
        {
            danhSach = new List<int>();
        }

        // Chuyển chuỗi nhập vào thành mảng số
        public bool KhoiTaoTuChuoi(string chuoiNhap)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(chuoiNhap)) return false;

                // Tách chuỗi theo khoảng trắng và chuyển đổi sang số nguyên
                string[] cacPhanTu = chuoiNhap.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                danhSach = cacPhanTu.Select(int.Parse).ToList();
                return danhSach.Count > 0;
            }
            catch
            {
                return false;
            }
        }

        // Xuất mảng thành chuỗi hiển thị
        public string XuatChuoi()
        {
            return string.Join(" ", danhSach);
        }

        // Sắp xếp tăng dần
        public void SapXepTang()
        {
            danhSach.Sort();
        }

        // Sắp xếp giảm dần
        public void SapXepGiam()
        {
            danhSach.Sort((x, y) => y.CompareTo(x));
        }

        // Tìm vị trí đầu tiên của một giá trị trong mảng, trả về -1 nếu không tìm thấy
        public int TimViTriTheoGiaTri(int giaTri)
        {
            return danhSach.IndexOf(giaTri);
        }

        // Lấy giá trị tại một vị trí chỉ định
        public int? LayGiaTriTheoViTri(int viTri)
        {
            if (viTri >= 0 && viTri < danhSach.Count)
            {
                return danhSach[viTri];
            }
            return null;
        }

        // Xóa theo giá trị 
        public bool XoaTheoGiaTri(int giaTri)
        {
            return danhSach.Remove(giaTri);
        }

        // Xóa theo vị trí
        public bool XoaTheoViTri(int viTri)
        {
            if (viTri >= 0 && viTri < danhSach.Count)
            {
                danhSach.RemoveAt(viTri);
                return true;
            }
            return false;
        }

        // Thêm giá trị tại vị trí chỉ định
        public bool ThemTaiViTri(int viTri, int giaTri)
        {
            if (viTri >= 0 && viTri <= danhSach.Count)
            {
                danhSach.Insert(viTri, giaTri);
                return true;
            }
            return false;
        }

        // Tính tổng toàn bộ mảng
        public int TinhTong()
        {
            return danhSach.Sum();
        }

        // Tính tổng các phần tử chẵn
        public int TinhTongChan()
        {
            return danhSach.Where(x => x % 2 == 0).Sum();
        }

        // Tính tổng các phần tử lẻ
        public int TinhTongLe()
        {
            return danhSach.Where(x => x % 2 != 0).Sum();
        }

        // Tìm phần tử lớn nhất
        public int? TimMax()
        {
            return danhSach.Count > 0 ? danhSach.Max() : (int?)null;
        }

        // Tìm phần tử nhỏ nhất
        public int? TimMin()
        {
            return danhSach.Count > 0 ? danhSach.Min() : (int?)null;
        }

        // Thay thế theo giá trị cũ bằng giá trị mới
        public bool ThayTheTheoGiaTri(int giaTriCu, int giaTriMoi)
        {
            int index = danhSach.IndexOf(giaTriCu);
            if (index != -1)
            {
                danhSach[index] = giaTriMoi;
                return true;
            }
            return false;
        }

        // Thay thế phần tử tại vị trí chỉ định bằng giá trị mới
        public bool ThayTheTheoViTri(int viTri, int giaTriMoi)
        {
            if (viTri >= 0 && viTri < danhSach.Count)
            {
                danhSach[viTri] = giaTriMoi;
                return true;
            }
            return false;
        }
    }
}