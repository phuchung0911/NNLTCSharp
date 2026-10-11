using System;
using System.Windows.Forms;

namespace BTNangCao
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GiaoDienBTNC());
        }
    }
}