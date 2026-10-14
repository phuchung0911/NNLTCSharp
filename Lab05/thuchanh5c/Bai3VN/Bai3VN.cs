using System;

namespace BTVN3
{
    public class NguoiDanhBa
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public NguoiDanhBa()
        {
            FirstName = "";
            LastName = "";
        }

        public NguoiDanhBa(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Định dạng hiển thị trên nút con TreeView: "FirstName, LastName"
        public string LayChuoiHienThi()
        {
            return FirstName + ", " + LastName;
        }

        // Lấy chữ cái đầu tiên của First Name để phân nhóm A đến Z
        public char LayKyTuDau()
        {
            if (string.IsNullOrWhiteSpace(FirstName)) return '#';

            // Chuyển ký tự đầu tiên về dạng chữ hoa không dấu tiếng Anh cơ bản
            char c = FirstName.Trim().ToUpper()[0];

            // Xử lý các chữ cái tiếng Việt có dấu về chữ cái gốc tương ứng
            switch (c)
            {
                case 'Á': case 'À': case 'Ả': case 'Ã': case 'Ạ':
                case 'Ă': case 'Ắ': case 'Ằ': case 'Ẳ': case 'Ẵ': case 'Ặ':
                case 'Â': case 'Ấ': case 'Ầ': case 'Ẩ': case 'Ẫ': case 'Ậ':
                    return 'A';
                case 'Đ':
                    return 'D';
                case 'É': case 'È': case 'Ẻ': case 'Ẽ': case 'Ẹ':
                case 'Ê': case 'Ế': case 'Ề': case 'Ể': case 'Ễ': case 'Ệ':
                    return 'E';
                case 'Í': case 'Ì': case 'Ỉ': case 'Ĩ': case 'Ị':
                    return 'I';
                case 'Ó': case 'Ò': case 'Ỏ': case 'Õ': case 'Ọ':
                case 'Ô': case 'Ố': case 'Ồ': case 'Ổ': case 'Ỗ': case 'Ộ':
                case 'Ơ': case 'Ớ': case 'Ờ': case 'Ở': case 'Ỡ': case 'Ợ':
                    return 'O';
                case 'Ú': case 'Ù': case 'Ủ': case 'Ũ': case 'Ụ':
                case 'Ư': case 'Ứ': case 'Ừ': case 'Ử': case 'Ữ': case 'Ự':
                    return 'U';
                case 'Ý': case 'Ỳ': case 'Ỷ': case 'Ỹ': case 'Ỵ':
                    return 'Y';
                default:
                    return c;
            }
        }
    }
}