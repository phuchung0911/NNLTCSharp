using System;
using System.Windows.Forms;

namespace BTVN2
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GiaoDienB2VN());
        }
    }
}