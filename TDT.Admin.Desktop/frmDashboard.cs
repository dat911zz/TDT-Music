using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.Admin.Desktop.Views;
using TDT.QLDV.Models;
using TDT.QLDV.Views;

namespace TDT.Cadmin.Desktop.Views
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
        private void ShowUserProfilePopup()
        {
            if (pnlProfile.Visible == false)
            {
                pnlProfile.Visible = true;
            }
            else
            {
                pnlProfile.Visible = false;
            }
        }

        private void btnUserProfile_Click(object sender, EventArgs e)
        {
            ShowUserProfilePopup();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            btnUserName.Text = QLDV.Models.DataBindings.Instance.CurrentUser;
            string token = QLDV.Models.DataBindings.Instance.CurrentUserToken;

            pnlProfile.Visible = false;

            ClearMDIForms();
            frmDashboardInner frm = new frmDashboardInner();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();

        }
        private void ClearMDIForms()
        {
            // close childs of parentForm
            foreach (Form form in Application.OpenForms)
            {
                if (form.MdiParent == this)
                {
                    form.Close();
                    return;
                }
            }
                
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenu_Home_Click(object sender, EventArgs e)
        {
            ClearMDIForms();
            frmDashboardInner frm = new frmDashboardInner();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }

        private void btnMenu_Account_Click(object sender, EventArgs e)
        {
            ClearMDIForms();
            frmAccount frm = new frmAccount();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }
        private void btnMenu_Role_Click(object sender, EventArgs e)
        {
            ClearMDIForms();

            frmRoles frm = new frmRoles();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;

            frm.Show();

        }
        private void btnMenu_Permission_Click(object sender, EventArgs e)
        {
            ClearMDIForms();
            frmPermission frm = new frmPermission();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();

        }
        private void btnMenu_Group_Click(object sender, EventArgs e)
        {
            ClearMDIForms();
            frmGroup frm = new frmGroup();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }

        private void btnMenu_Song_Click(object sender, EventArgs e)
        {
            ClearMDIForms();
            frmSong frm = new frmSong();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();
        }

        private void btnMenu_Playlist_Click(object sender, EventArgs e)
        {
            ClearMDIForms();
            frmPlaylist frm = new frmPlaylist();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();

        }

        private void btnMenu_Genre_Click(object sender, EventArgs e)
        {
            ClearMDIForms();
            frmGenre frm = new frmGenre();
            frm.MdiParent = this;
            //Fill form full khoảng trống
            frm.Width = this.Width;
            frm.Height = this.Height;
            frm.Show();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _prevFrm.Close();
        }
    }
}
