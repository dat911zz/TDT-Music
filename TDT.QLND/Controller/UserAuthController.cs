using TDT.QLND.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDT.Core.Ultils;
using TDT.Core.Models;
using TDT.Core.DTO;

namespace TDT.QLND.Controller
{
    public class UserAuthController
    {
        private string connStr;
        private FrmLoginBinding loginBinding;
        private FrmConfigBinding configBinding;
        private static UserAuthController instance;
        private FrmConfig frmConfig = null;
        private FrmLogin frmLogin = null;
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
        private UserAuthController() { }
        public void SetConnStr(string connStr)
        {
            this.connStr = connStr;
        }
        public void InitComponents(FrmLogin frmLogin, FrmConfig frmConfig, FrmLoginBinding loginBinding, FrmConfigBinding cfgBinding)
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
            ConnectionState rs = CheckConnectionString();
            DialogResult dig;
            switch (rs)
            {
                case ConnectionState.Valid:
                    ProcessLogin();
                    break;
                case ConnectionState.NotExist:
                    dig = MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dig == DialogResult.OK)
                    {
                        ProcessConfig();
                    }
                    break;
                case ConnectionState.Invalid:
                    dig = MessageBox.Show("Cấu hình không hợp lệ hoặc kết nối thất bại, vui lòng kiểm tra lại kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dig == DialogResult.OK)
                    {
                        ProcessConfig();
                    }
                    break;
            }
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
            AuthDTO auth = APICallHelper.Post<AuthDTO>("login", new LoginModel()
            {
                UserName = pUser,
                Password = pPass
            }.ToString()).Result;
            if (string.IsNullOrEmpty(auth.Token))
            {
                return LoginResult.Invalid;
            }
            UserDetailDTO userDetail = APICallHelper.Get<UserDetailDTO>("user/get", token: auth.Token).Result;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from QL_NguoiDung where TenDangNhap='" + pUser + "' and MatKhau='" + pPass + "'", connStr);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    return LoginResult.Invalid;
                }
                else
                {
                    if (dt.Rows[0]["HoatDong"] == null || dt.Rows[0]["HoatDong"].ToString() == "False")
                    {
                        return LoginResult.Disabled;
                    }
                    return LoginResult.Success;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Lỗi: {0}", ex.Message));
                return LoginResult.Invalid;
            }

        }
        public void ProcessLogin()
        {
            switch (CheckUser(loginBinding.txtUsername.Text.Trim(), loginBinding.txtPass.Text.Trim()))
            {
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
        Invalid,
        Disabled,
        Success,
    }
    public class FrmLoginBinding
    {
        public TextBox txtUsername;
        public TextBox txtPass;
        public Button btnLogin;
        public Button btnCancel;
        public FrmLoginBinding(TextBox txtUsername, TextBox txtPass, Button btnLogin, Button btnCancel)
        {
            this.txtUsername = txtUsername;
            this.txtPass = txtPass;
            this.btnLogin = btnLogin;
            this.btnCancel = btnCancel;
        }
    }
    public class FrmConfigBinding
    {
        public TextBox txtUsername;
        public TextBox txtPass;
        public Button btnSave;
        public Button btnCancel;
        public ComboBox cboServer;
        public ComboBox cboDB;
        public FrmConfigBinding(TextBox txtUsername, TextBox txtPass, Button btnSave, Button btnCancel, ComboBox cboServer, ComboBox cboDB)
        {
            this.txtUsername = txtUsername;
            this.txtPass = txtPass;
            this.btnSave = btnSave;
            this.btnCancel = btnCancel;
            this.cboServer = cboServer;
            this.cboDB = cboDB;
        }
    }
}
