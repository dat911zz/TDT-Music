using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.QLDV;
using TDT.QLDV.DTO;
using TDT.QLDV.Extensions;
using TDT.QLDV.Models;
using TDT.QLDV.Ultils;
using System.Web;

namespace TDT.Admin.Desktop.Views
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {

            //ResponseDataDTO<UserDTO> users = APICallHelper.Get<ResponseDataDTO<UserDTO>>("user", User.GetToken()).Result;

            //TDT.QLDV.Models.DataBindings.Instance.LoadUsers(User.GetToken());
        }
    }
}
