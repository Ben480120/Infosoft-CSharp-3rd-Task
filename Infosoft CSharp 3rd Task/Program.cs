using System;
using System.Windows.Forms;

namespace Infosoft_CSharp_3rd_Task
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            Application.Run(new CustomerForm());  
        }
    }
}
