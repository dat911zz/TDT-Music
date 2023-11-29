using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.Cadmin.Desktop.Views;

namespace TDT.Admin.Desktop
{
    internal static class Program
    {
        //public static IConfiguration? cfg = null;
        public static frmDashboard frmDashboard = null;
        public static QLDV.Controller.UserAuthController controller = null;
        public static QLDV.Views.frmConfigNew frmConfig = null;
        public static QLDV.Views.frmLoginNew frmLogin = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyExceptionHandler);
            frmConfig = new QLDV.Views.frmConfigNew();
            frmLogin = new QLDV.Views.frmLoginNew();
            controller = QLDV.Controller.UserAuthController.Instance;
            //controller.SetConnStr(cfg.GetConnectionString("Admin"));
            controller.gotoDashborad = () =>
            {
                frmDashboard = new frmDashboard(frmLogin);
                frmDashboard.Show();
                frmLogin.Hide();
            };
            controller.saveConfig = (serverName, userName, pass, dbName) =>
            {
                //ConfigHelper.SaveConfig("Admin", "Data Source=" + serverName + ";Initial Catalog=" + dbName + ";User ID=" + userName + ";pwd = " + pass + "");
            };
            controller.InitComponents(frmLogin, frmConfig, frmLogin.GetBindings(), frmConfig.GetBindings());
            Application.Run(frmLogin);

            //Application.Run(frmLoginNew);

        }
        static void MyExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Uncaught: " + e.Message);
        }
    }
}
