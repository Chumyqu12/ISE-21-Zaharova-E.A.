using SoftwareDevelopmentService.Interfaces;
using SoftwareDevelopmentService.ImplementationsBD;
using SoftwareDevelopmentService;
using System;
using System.Data.Entity;
using System.Windows.Forms;


namespace SoftwareDevelopmentView
{
	static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APICustomer.Connect();
            MailCustomer.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormGeneral());
        }
    }
}
