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
    public partial class frmConfigNew : Form
    {
        public frmConfigNew()
        {
            InitializeComponent();
        }
        public FrmConfigBinding GetBindings()
        {
            return new FrmConfigBinding(
                txtUsername,
                txtPass,
                btnSave,
                btnCancel,
                cboServer,
                cboDB
                );
        }
    }
}
