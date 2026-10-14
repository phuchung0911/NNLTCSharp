using System;
using System.Windows.Forms;

namespace BTVN3
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GiaoDienB3VN());
        }
    }
}