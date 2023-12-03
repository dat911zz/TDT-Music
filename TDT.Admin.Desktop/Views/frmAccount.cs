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
using System.Collections;

namespace TDT.Admin.Desktop.Views
{
    public partial class frmAccount : Form
    {
        public frmAccount()
        {
            InitializeComponent();
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            IList<UserDTO> users = await loadDataUserAsync();
            dtgvUserDTO.DataSource = users;
        }
        public static async Task<IList<UserDTO>> loadDataUserAsync()
        {
            string token = QLDV.Models.DataBindings.Instance.CurrentUserToken;
            await QLDV.Models.DataBindings.Instance.LoadUsers(token);
            var users = QLDV.Models.DataBindings.Instance.Users;
            return users;

        }

        private void dtgvUserDTO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == 0 && e.RowIndex < dtgvUserDTO.Rows.Count - 1) { 
                
            }
        }
    }
}
 