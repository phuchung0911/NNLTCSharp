namespace BTNangCao
{
    public class QuanLyRapPhim
    {
        // Trạng thái ghế: 0: Chưa bán (Trắng), 1: Đang chọn (Xanh), 2: Đã bán (Vàng)
        private int[] trangThaiGhe = new int[16];

        public QuanLyRapPhim()
        {
            // Mặc định tất cả các ghế từ 1 đến 15 là chưa bán (0)
            for (int i = 1; i <= 15; i++)
            {
                trangThaiGhe[i] = 0;
            }
        }

        // Lấy giá vé theo số thứ tự ghế (1-5: Lô A, 6-10: Lô B, 11-15: Lô C)
        public int LayGiaVe(int soGhe)
        {
            if (soGhe >= 1 && soGhe <= 5) return 1000;   // Lô A
            if (soGhe >= 6 && soGhe <= 10) return 1500;  // Lô B
            if (soGhe >= 11 && soGhe <= 15) return 2000; // Lô C
            return 0;
        }

        // Cập nhật trạng thái một ghế
        public void SetTrangThai(int soGhe, int trangThai)
        {
            if (soGhe >= 1 && soGhe <= 15)
            {
                trangThaiGhe[soGhe] = trangThai;
            }
        }

        // Lấy trạng thái hiện tại của ghế
        public int GetTrangThai(int soGhe)
        {
            return (soGhe >= 1 && soGhe <= 15) ? trangThaiGhe[soGhe] : -1;
        }

        // Tính tổng tiền cho tất cả các ghế đang ở trạng thái "Đang chọn" (1)
        public int TinhTongTienDangChon()
        {
            int tong = 0;
            for (int i = 1; i <= 15; i++)
            {
                if (trangThaiGhe[i] == 1)
                {
                    tong += LayGiaVe(i);
                }
            }
            return tong;
        }

        // Xác nhận mua: chuyển các ghế "Đang chọn" (1) sang "Đã bán" (2)
        public void XacNhanBanVe()
        {
            for (int i = 1; i <= 15; i++)
            {
                if (trangThaiGhe[i] == 1)
                {
                    trangThaiGhe[i] = 2;
                }
            }
        }

        // Hủy bỏ: chuyển các ghế "Đang chọn" (1) trở lại "Chưa bán" (0)
        public void HuyBoChonVe()
        {
            for (int i = 1; i <= 15; i++)
            {
                if (trangThaiGhe[i] == 1)
                {
                    trangThaiGhe[i] = 0;
                }
            }
        }
    }
}