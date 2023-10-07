using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using TDT.Cadmin.Desktop.Views;
using TDT.QLND;

namespace TDT.Cadmin.Desktop
{
    internal static class Program
    {
        public static IConfiguration? cfg = null;
        public static frmDashboard? frmDashboard = null;
        public static QLND.Controller.UserAuthController? controller = null;
        public static QLND.View.FrmConfig? frmConfig = null;
        public static QLND.View.FrmLogin? frmLogin = null;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            cfg = builder.Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyExceptionHandler);
            frmConfig = new QLND.View.FrmConfig();
            frmLogin = new QLND.View.FrmLogin();
            frmDashboard = new frmDashboard(frmLogin);
            controller = QLND.Controller.UserAuthController.Instance;
            controller.SetConnStr(cfg.GetConnectionString("Admin"));
            controller.gotoDashborad = () =>
            {
                frmDashboard.Show();
                frmLogin.Hide();
            };
            controller.saveConfig = (serverName, userName, pass, dbName) =>
            {
                ConfigHelper.SaveConfig("Admin" ,"Data Source=" + serverName + ";Initial Catalog=" + dbName + ";User ID=" + userName + ";pwd = " + pass + "");
            };
            controller.InitComponents(frmLogin, frmConfig, frmLogin.GetBindings(), frmConfig.GetBindings());

            Application.Run(frmLogin);
        }
        static void MyExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("Uncaught: " + e.Message);
        }
    }
}
