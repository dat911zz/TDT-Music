using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.QLDV.Controller;

namespace TDT.QLDV.Views
{
    public partial class frmLoginNew : Form
    {
        public frmLoginNew()
        {
            InitializeComponent();
        }
        public FrmLoginBinding GetBindings()
        {
            return new FrmLoginBinding(
                txtUsername,
                txtPass,
                btnLogin,
                btnCancel
                );
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmConfigNew frm = new frmConfigNew();
            frm.ShowDialog();
        }
    }
}
