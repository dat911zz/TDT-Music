using TDT.QLDV.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDT.QLDV.Models;
using TDT.QLDV.DTO;
using TDT.QLDV.Ultils;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace TDT.QLDV.Controller
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
    public class UserAuthController
    {
        private string connStr;
        private FrmLoginBinding loginBinding;
        private FrmConfigBinding configBinding;
        private static UserAuthController instance;
        private frmConfigNew frmConfig;
        private frmLoginNew frmLogin;
        public Action gotoDashborad;
        public Action<string, string, string, string> saveConfig;
        public static UserAuthController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserAuthController();
                }
                return instance;
            }
        }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private UserAuthController() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public void SetConnStr(string connStr)
        {
            this.connStr = connStr;
        }
        public void InitComponents(frmLoginNew frmLogin, frmConfigNew frmConfig, FrmLoginBinding loginBinding, FrmConfigBinding cfgBinding)
        {
            this.frmLogin = frmLogin;
            this.frmConfig = frmConfig;
            this.loginBinding = loginBinding;
            this.configBinding = cfgBinding;
            this.loginBinding.btnLogin.Click += FrmLoginBtnLogin_Click;
            this.loginBinding.btnCancel.Click += FrmLoginBtnCancel_Click;
            this.configBinding.btnCancel.Click += BtnCancel_Click;
            this.configBinding.btnSave.Click += BtnSave_Click;
            this.configBinding.cboDB.DropDown += CboDB_DropDown;
            this.configBinding.cboServer.DropDown += CboServer_DropDown;
        }

        private void CboServer_DropDown(object sender, EventArgs e)
        {
            configBinding.cboServer.DataSource = ConfigHelper.GetServerName();
            configBinding.cboServer.DisplayMember = "ServerName";
        }

        private void CboDB_DropDown(object sender, EventArgs e)
        {
            configBinding.cboDB.DataSource = ConfigHelper.GetDBName(configBinding.cboServer.Text, configBinding.txtUsername.Text, configBinding.txtPass.Text);
            configBinding.cboDB.DisplayMember = "name";
        }
        public void SaveConfig(string serverName, string userName, string pass, string dbName)
        {
            saveConfig(serverName, userName, pass, dbName);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveConfig(
                configBinding.cboServer.Text.Trim(),
                configBinding.txtUsername.Text.Trim(),
                configBinding.txtPass.Text.Trim(),
                configBinding.cboDB.Text.Trim()
                );
            DialogResult drs = MessageBox.Show("Lưu thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (drs == DialogResult.OK)
            {
                frmConfig.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            frmConfig.Close();
        }

        private void FrmLoginBtnCancel_Click(object sender, EventArgs e)
        {
            frmLogin.Close();
        }

        private void FrmLoginBtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginBinding.txtUsername.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống trường Tên người dùng");
                loginBinding.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(loginBinding.txtPass.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống trường Mật khẩu");
                loginBinding.txtPass.Focus();
                return;
            }
            ProcessLogin();
            //--Đã chuyển sang sử dụng xác thực thông qua API
            //ConnectionState rs = CheckConnectionString();
            //DialogResult dig;
            //switch (rs)
            //{
            //    case ConnectionState.Valid:
            //        ProcessLogin();
            //        break;
            //    case ConnectionState.NotExist:
            //        dig = MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxGuna2Buttons.OK, MessageBoxIcon.Error);
            //        if (dig == DialogResult.OK)
            //        {
            //            ProcessConfig();
            //        }
            //        break;
            //    case ConnectionState.Invalid:
            //        dig = MessageBox.Show("Cấu hình không hợp lệ hoặc kết nối thất bại, vui lòng kiểm tra lại kết nối!", "Thông báo", MessageBoxGuna2Buttons.OK, MessageBoxIcon.Error);
            //        if (dig == DialogResult.OK)
            //        {
            //            ProcessConfig();
            //        }
            //        break;
            //}
        }

        public ConnectionState CheckConnectionString()
        {
            if (string.IsNullOrEmpty(connStr))
            {
                return ConnectionState.NotExist;
            }
            SqlConnection _sqlConn = new SqlConnection(connStr);
            try
            {
                if (_sqlConn.State == System.Data.ConnectionState.Closed)
                {
                    _sqlConn.Open();
                }
                return ConnectionState.Valid;
            }
            catch (Exception ex)
            {
                return ConnectionState.Invalid;
            }
        }
        public LoginResult CheckUser(string pUser, string pPass)
        {
            try
            {
                AuthDTO auth = APICallHelper.Post<AuthDTO>("auth/login", new LoginModel()
                {
                    UserName = pUser,
                    Password = pPass
                }.ToString()).Result;
                if (string.IsNullOrEmpty(auth.Token))
                {
                    return LoginResult.Invalid;
                }
                //ResponseDataDTO<User> userDetail = APICallHelper.Get<ResponseDataDTO<User>>("user", token: auth.Token).Result;
                //ResponseDataDTO<User> res = APICallHelper.Get<ResponseDataDTO<User>>($"user/{pUser}", token: auth.Token).Result;
                DataBindings.Instance.LoadUserToken(pUser, pPass);
                DataBindings.Instance.CurrentUser = pUser;
                return LoginResult.Success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Lỗi: {0}", ex.Message), "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return LoginResult.Exception;
            }

        }
        public void ProcessLogin()
        {
            switch (CheckUser(loginBinding.txtUsername.Text.Trim(), loginBinding.txtPass.Text.Trim()))
            {
                case LoginResult.Exception:
                    break;
                case LoginResult.Invalid:
                    MessageBox.Show("Sai Tên đăng nhập hoặc Mật khẩu");
                    break;
                case LoginResult.Disabled:
                    MessageBox.Show("Tài khoản bị khóa");
                    break;
                case LoginResult.Success:
                    gotoDashborad();
                    break;
                default:
                    break;
            }
        }
        public void ProcessConfig()
        {
            frmConfig.Show();
        }

    }
    public enum ConnectionState
    {
        Valid,
        NotExist,
        Invalid
    }
    public enum LoginResult
    {
        Exception,
        Invalid,
        Disabled,
        Success,
    }
    public class FrmLoginBinding
    {
        public Guna2TextBox txtUsername;
        public Guna2TextBox txtPass;
        public Guna2Button btnLogin;
        public Guna2Button btnCancel;
        public FrmLoginBinding(Guna2TextBox txtUsername, Guna2TextBox txtPass, Guna2Button btnLogin, Guna2Button btnCancel)
        {
            this.txtUsername = txtUsername;
            this.txtPass = txtPass;
            this.btnLogin = btnLogin;
            this.btnCancel = btnCancel;
        }
    }
    public class FrmConfigBinding
    {
        public Guna2TextBox txtUsername;
        public Guna2TextBox txtPass;
        public Guna2Button btnSave;
        public Guna2Button btnCancel;
        public ComboBox cboServer;
        public ComboBox cboDB;
        public FrmConfigBinding(Guna2TextBox txtUsername, Guna2TextBox txtPass, Guna2Button btnSave, Guna2Button btnCancel, ComboBox cboServer, ComboBox cboDB)
        {
            this.txtUsername = txtUsername;
            this.txtPass = txtPass;
            this.btnSave = btnSave;
            this.btnCancel = btnCancel;
            this.cboServer = cboServer;
            this.cboDB = cboDB;
        }
        //public FrmConfigBinding(Guna2Guna2TextBox txtUsername, Guna2Guna2TextBox txtPass, Guna2Guna2Button btnSave, Guna2Guna2Button btnCancel, Guna2ComboBox cboServer, Guna2ComboBox cboDB)
        //{
        //    this.txtUsername = txtUsername;
        //    this.txtPass = txtPass;
        //    this.btnSave = btnSave;
        //    this.btnCancel = btnCancel;
        //    this.cboServer = cboServer;
        //    this.cboDB = cboDB;
        //}
    }
}
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning restore CS8602 // Dereference of a possibly null reference.