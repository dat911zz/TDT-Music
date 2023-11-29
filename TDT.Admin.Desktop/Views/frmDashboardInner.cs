using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.QLDV.Models.QLDVTableAdapters;

namespace TDT.Admin.Desktop.Views
{
    public partial class frmDashboardInner : Form
    {
        public frmDashboardInner()
        {
            InitializeComponent();
        }

        private void frmDashboardInner_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgv.DataSource = new UsersTableAdapter().GetData();
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            QLDV.Ultils.Algorithms.DecisionTree_ID3.TrainingData();
            MessageDialog.Show("Đã train xong!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);
        }
    }
}
