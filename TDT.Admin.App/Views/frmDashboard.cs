using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.QLND.Views;

namespace TDT.Cadmin.App.Views
{
    public partial class frmDashboard : Form
    {
        private Form _prevFrm;
        public frmDashboard(Form _prevFrm)
        {
            InitializeComponent();
            this._prevFrm = _prevFrm;
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _prevFrm.Show();
            e.Cancel = false;
            this.Hide();
        }
    }
}
