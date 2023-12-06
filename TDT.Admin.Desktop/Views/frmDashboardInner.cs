using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.QLDV.Models.QLDVTableAdapters;
using TDT.QLDV.Ultils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TDT.Admin.Desktop.Views
{
    public partial class frmDashboardInner : Form
    {
        QLDV.Models.DataBindings _bindings = QLDV.Models.DataBindings.Instance;
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
            _bindings.dgvPredict = dgv;
            _bindings.progressBar = progressBar1;
            _bindings.progressBar.Minimum = 0;
            //dgv.DataSource = QLDV.Ultils.Algorithms.DecisionTree_ID3.data;
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_bindings.FileImportData))
            {
                MessageDialog.Show("Vui lòng chọn file dữ liệu!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }
            Algorithms.DecisionTree_ID3.TrainingData();
            MessageDialog.Show("Đã train thành công!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);
        }

        private void btnDecide_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(_bindings.FileImportData))
            //{
            //    MessageDialog.Show("Vui lòng chọn file dữ liệu!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Error);
            //    return;
            //}
            if (Algorithms.DecisionTree_ID3.codebook == null)
            {
                MessageDialog.Show("Vui lòng import codebook trước khi train!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }
            bool flag = false;
            var listWord = txtMsg.Text.ToString().Split(' ', '\n', '_', '|', '-', '@', '*', '=', '+');

            foreach (var word in listWord)
            {
                var inputs = Algorithms.DecisionTree_ID3.GetInputs(word);
                var output = Algorithms.DecisionTree_ID3.MakeDecision(inputs);
                if (output.Equals("1"))
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                MessageDialog.Show("Phát hiện vi phạm nguyên tắc cộng đồng \nĐoạn chat chứa từ ngữ độc hại!\nNội dung: " + txtMsg.Text.ToString(), "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Warning);
            }
            else
            {
                MessageDialog.Show("Không phát hiện vi phạm!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);
            }
        }
        private void btnImportModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\HK\HK7",
                Title = "Tìm file dữ liệu",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "Model File |*.accord",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileModel.Text = _bindings.FileModelData = openFileDialog1.FileName;
                //MessageDialog.Show("Đang tải dữ liệu lên, vui lòng đợi...", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);
                Algorithms.DecisionTree_ID3.ImportModel(openFileDialog1.FileName);
                MessageDialog.Show("Đã nạp file dữ liệu!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);
            }
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            Algorithms.DecisionTree_ID3.SaveModel();
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\HK\HK7",
                Title = "Tìm file dữ liệu",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "txt files (*.txt)|*.txt |*.csv |*.xlsx",

                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileImport.Text = _bindings.FileImportData = openFileDialog1.FileName;
                //MessageDialog.Show("Đang tải dữ liệu lên, vui lòng đợi...", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);

                Algorithms.DecisionTree_ID3.data = Algorithms.DecisionTree_ID3.GetDataTableFromExcel(_bindings.FileImportData);
                _bindings.progressBar.Value = 0;
                _bindings.dgvPredict.Invoke(new MethodInvoker(delegate
                {
                    _bindings.dgvPredict.DataSource = Algorithms.DecisionTree_ID3.data;
                }));
                MessageDialog.Show("Đã nạp file dữ liệu!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\HK\HK7",
                Title = "Tìm file dữ liệu",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "Model File |*.accord",

                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //txtFileImport.Text = _bindings.FileImportData = openFileDialog1.FileName;
                //MessageDialog.Show("Đang tải dữ liệu lên, vui lòng đợi...", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);

                Algorithms.DecisionTree_ID3.ImportCodebook(openFileDialog1.FileName);
                MessageDialog.Show("Đã nạp file dữ liệu!", "Hệ thống", MessageDialogButtons.OK, MessageDialogIcon.Information);
            }
        }

        private void btnSaveCodebook_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\HK\HK7\codebook_id3_" + DateTime.Now.ToFileTime() + ".accord";
            Algorithms.DecisionTree_ID3.SaveCodebook(filePath);
        }
    }
}
