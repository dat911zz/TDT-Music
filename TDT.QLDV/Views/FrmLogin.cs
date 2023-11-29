using TDT.QLDV.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDT.QLDV.Views
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pnl.Location = new Point(
            this.ClientSize.Width / 2 - pnl.Size.Width / 2,
            this.ClientSize.Height / 2 - pnl.Size.Height / 2);
            pnl.Anchor = AnchorStyles.None;
            txtUsername.Focus();
        }
        //public FrmLoginBinding GetBindings()
        //{
        //    return new FrmLoginBinding(
        //        txtUsername,
        //        txtPass,
        //        btnLogin,
        //        btnCancel
        //        );
        //}
    }
}
