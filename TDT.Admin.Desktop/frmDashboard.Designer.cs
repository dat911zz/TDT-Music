using Guna.UI2.WinForms;

namespace TDT.Cadmin.Desktop.Views
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlProfile = new System.Windows.Forms.Panel();
            this.btnExit = new Guna.UI.WinForms.GunaButton();
            this.btnLogout = new Guna.UI.WinForms.GunaButton();
            this.btnUserName = new Guna.UI.WinForms.GunaButton();
            this.btnUserProfile = new Guna.UI.WinForms.GunaCircleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMenu_Genre = new Guna.UI.WinForms.GunaButton();
            this.btnMenu_Playlist = new Guna.UI.WinForms.GunaButton();
            this.btnMenu_Song = new Guna.UI.WinForms.GunaButton();
            this.btnMenu_Group = new Guna.UI.WinForms.GunaButton();
            this.btnMenu_Permission = new Guna.UI.WinForms.GunaButton();
            this.btnMenu_Role = new Guna.UI.WinForms.GunaButton();
            this.btnMenu_Account = new Guna.UI.WinForms.GunaButton();
            this.btnMenu_Home = new Guna.UI.WinForms.GunaButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 724);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.panel2.Controls.Add(this.btnMenu_Genre);
            this.panel2.Controls.Add(this.btnMenu_Playlist);
            this.panel2.Controls.Add(this.btnMenu_Song);
            this.panel2.Controls.Add(this.btnMenu_Group);
            this.panel2.Controls.Add(this.btnMenu_Permission);
            this.panel2.Controls.Add(this.btnMenu_Role);
            this.panel2.Controls.Add(this.btnMenu_Account);
            this.panel2.Controls.Add(this.btnMenu_Home);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 592);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.panel4.Controls.Add(this.btnUserProfile);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(200, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1164, 69);
            this.panel4.TabIndex = 1;
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.Gray;
            this.pnlProfile.Controls.Add(this.btnExit);
            this.pnlProfile.Controls.Add(this.btnLogout);
            this.pnlProfile.Controls.Add(this.btnUserName);
            this.pnlProfile.Location = new System.Drawing.Point(1221, 75);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(131, 133);
            this.pnlProfile.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.AnimationHoverSpeed = 0.07F;
            this.btnExit.AnimationSpeed = 0.03F;
            this.btnExit.BaseColor = System.Drawing.Color.White;
            this.btnExit.BorderColor = System.Drawing.Color.Black;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.FocusedColor = System.Drawing.Color.Empty;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = null;
            this.btnExit.ImageSize = new System.Drawing.Size(20, 20);
            this.btnExit.Location = new System.Drawing.Point(0, 86);
            this.btnExit.Margin = new System.Windows.Forms.Padding(5);
            this.btnExit.Name = "btnExit";
            this.btnExit.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnExit.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExit.OnHoverForeColor = System.Drawing.Color.White;
            this.btnExit.OnHoverImage = null;
            this.btnExit.OnPressedColor = System.Drawing.Color.Black;
            this.btnExit.Padding = new System.Windows.Forms.Padding(10);
            this.btnExit.Size = new System.Drawing.Size(127, 42);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AnimationHoverSpeed = 0.07F;
            this.btnLogout.AnimationSpeed = 0.03F;
            this.btnLogout.BaseColor = System.Drawing.Color.White;
            this.btnLogout.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.Image = null;
            this.btnLogout.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogout.Location = new System.Drawing.Point(0, 43);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnLogout.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogout.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogout.OnHoverImage = null;
            this.btnLogout.OnPressedColor = System.Drawing.Color.Black;
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10);
            this.btnLogout.Size = new System.Drawing.Size(127, 42);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUserName
            // 
            this.btnUserName.AnimationHoverSpeed = 0.07F;
            this.btnUserName.AnimationSpeed = 0.03F;
            this.btnUserName.BaseColor = System.Drawing.Color.White;
            this.btnUserName.BorderColor = System.Drawing.Color.Black;
            this.btnUserName.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUserName.Enabled = false;
            this.btnUserName.FocusedColor = System.Drawing.Color.Empty;
            this.btnUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUserName.ForeColor = System.Drawing.Color.Black;
            this.btnUserName.Image = null;
            this.btnUserName.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUserName.Location = new System.Drawing.Point(0, 0);
            this.btnUserName.Margin = new System.Windows.Forms.Padding(5);
            this.btnUserName.Name = "btnUserName";
            this.btnUserName.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnUserName.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUserName.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUserName.OnHoverImage = null;
            this.btnUserName.OnPressedColor = System.Drawing.Color.Black;
            this.btnUserName.Padding = new System.Windows.Forms.Padding(10);
            this.btnUserName.Size = new System.Drawing.Size(127, 42);
            this.btnUserName.TabIndex = 8;
            this.btnUserName.Text = "Username";
            this.btnUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUserProfile
            // 
            this.btnUserProfile.AnimationHoverSpeed = 0.07F;
            this.btnUserProfile.AnimationSpeed = 0.03F;
            this.btnUserProfile.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUserProfile.BorderColor = System.Drawing.Color.Black;
            this.btnUserProfile.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUserProfile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUserProfile.FocusedColor = System.Drawing.Color.Empty;
            this.btnUserProfile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUserProfile.ForeColor = System.Drawing.Color.White;
            this.btnUserProfile.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_user_50;
            this.btnUserProfile.ImageSize = new System.Drawing.Size(52, 52);
            this.btnUserProfile.Location = new System.Drawing.Point(1089, 0);
            this.btnUserProfile.Name = "btnUserProfile";
            this.btnUserProfile.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUserProfile.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUserProfile.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUserProfile.OnHoverImage = null;
            this.btnUserProfile.OnPressedColor = System.Drawing.Color.Black;
            this.btnUserProfile.Size = new System.Drawing.Size(75, 69);
            this.btnUserProfile.TabIndex = 0;
            this.btnUserProfile.Click += new System.EventHandler(this.btnUserProfile_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.panel3.BackgroundImage = global::TDT.Admin.Desktop.Properties.Resources.logo_TDT_Devil_red;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 132);
            this.panel3.TabIndex = 2;
            // 
            // btnMenu_Genre
            // 
            this.btnMenu_Genre.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Genre.AnimationSpeed = 0.03F;
            this.btnMenu_Genre.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Genre.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Genre.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Genre.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Genre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Genre.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Genre.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_genre_24;
            this.btnMenu_Genre.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Genre.Location = new System.Drawing.Point(-3, 369);
            this.btnMenu_Genre.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenu_Genre.Name = "btnMenu_Genre";
            this.btnMenu_Genre.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Genre.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Genre.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Genre.OnHoverImage = null;
            this.btnMenu_Genre.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Genre.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Genre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Genre.Size = new System.Drawing.Size(200, 42);
            this.btnMenu_Genre.TabIndex = 7;
            this.btnMenu_Genre.Text = "Thể Loại";
            this.btnMenu_Genre.TextOffsetX = 15;
            this.btnMenu_Genre.Click += new System.EventHandler(this.btnMenu_Genre_Click);
            // 
            // btnMenu_Playlist
            // 
            this.btnMenu_Playlist.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Playlist.AnimationSpeed = 0.03F;
            this.btnMenu_Playlist.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Playlist.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Playlist.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Playlist.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Playlist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Playlist.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Playlist.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_music_library_50;
            this.btnMenu_Playlist.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Playlist.Location = new System.Drawing.Point(-3, 318);
            this.btnMenu_Playlist.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenu_Playlist.Name = "btnMenu_Playlist";
            this.btnMenu_Playlist.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Playlist.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Playlist.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Playlist.OnHoverImage = null;
            this.btnMenu_Playlist.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Playlist.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Playlist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Playlist.Size = new System.Drawing.Size(200, 42);
            this.btnMenu_Playlist.TabIndex = 6;
            this.btnMenu_Playlist.Text = "Danh Sách Phát";
            this.btnMenu_Playlist.TextOffsetX = 15;
            this.btnMenu_Playlist.Click += new System.EventHandler(this.btnMenu_Playlist_Click);
            // 
            // btnMenu_Song
            // 
            this.btnMenu_Song.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Song.AnimationSpeed = 0.03F;
            this.btnMenu_Song.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Song.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Song.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Song.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Song.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Song.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Song.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_musical_notes_50;
            this.btnMenu_Song.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Song.Location = new System.Drawing.Point(-3, 267);
            this.btnMenu_Song.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenu_Song.Name = "btnMenu_Song";
            this.btnMenu_Song.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Song.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Song.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Song.OnHoverImage = null;
            this.btnMenu_Song.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Song.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Song.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Song.Size = new System.Drawing.Size(200, 42);
            this.btnMenu_Song.TabIndex = 5;
            this.btnMenu_Song.Text = "Bài Hát";
            this.btnMenu_Song.TextOffsetX = 15;
            this.btnMenu_Song.Click += new System.EventHandler(this.btnMenu_Song_Click);
            // 
            // btnMenu_Group
            // 
            this.btnMenu_Group.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Group.AnimationSpeed = 0.03F;
            this.btnMenu_Group.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Group.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Group.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Group.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Group.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Group.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Group.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_group_50;
            this.btnMenu_Group.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Group.Location = new System.Drawing.Point(-3, 216);
            this.btnMenu_Group.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenu_Group.Name = "btnMenu_Group";
            this.btnMenu_Group.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Group.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Group.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Group.OnHoverImage = null;
            this.btnMenu_Group.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Group.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Group.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Group.Size = new System.Drawing.Size(200, 42);
            this.btnMenu_Group.TabIndex = 4;
            this.btnMenu_Group.Text = "Nhóm Quyền";
            this.btnMenu_Group.TextOffsetX = 15;
            this.btnMenu_Group.Click += new System.EventHandler(this.btnMenu_Group_Click);
            // 
            // btnMenu_Permission
            // 
            this.btnMenu_Permission.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Permission.AnimationSpeed = 0.03F;
            this.btnMenu_Permission.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Permission.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Permission.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Permission.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Permission.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Permission.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Permission.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_key_50;
            this.btnMenu_Permission.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Permission.Location = new System.Drawing.Point(-3, 165);
            this.btnMenu_Permission.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenu_Permission.Name = "btnMenu_Permission";
            this.btnMenu_Permission.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Permission.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Permission.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Permission.OnHoverImage = null;
            this.btnMenu_Permission.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Permission.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Permission.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Permission.Size = new System.Drawing.Size(200, 42);
            this.btnMenu_Permission.TabIndex = 3;
            this.btnMenu_Permission.Text = "Quyền Truy Cập";
            this.btnMenu_Permission.TextOffsetX = 15;
            this.btnMenu_Permission.Click += new System.EventHandler(this.btnMenu_Permission_Click);
            // 
            // btnMenu_Role
            // 
            this.btnMenu_Role.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Role.AnimationSpeed = 0.03F;
            this.btnMenu_Role.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Role.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Role.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Role.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Role.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Role.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Role.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_shield_50;
            this.btnMenu_Role.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Role.Location = new System.Drawing.Point(-3, 114);
            this.btnMenu_Role.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenu_Role.Name = "btnMenu_Role";
            this.btnMenu_Role.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Role.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Role.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Role.OnHoverImage = null;
            this.btnMenu_Role.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Role.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Role.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Role.Size = new System.Drawing.Size(200, 42);
            this.btnMenu_Role.TabIndex = 2;
            this.btnMenu_Role.Text = "Vai Trò";
            this.btnMenu_Role.TextOffsetX = 15;
            this.btnMenu_Role.Click += new System.EventHandler(this.btnMenu_Role_Click);
            // 
            // btnMenu_Account
            // 
            this.btnMenu_Account.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Account.AnimationSpeed = 0.03F;
            this.btnMenu_Account.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Account.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Account.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Account.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Account.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Account.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Account.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_user_50;
            this.btnMenu_Account.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Account.Location = new System.Drawing.Point(-3, 63);
            this.btnMenu_Account.Margin = new System.Windows.Forms.Padding(10);
            this.btnMenu_Account.Name = "btnMenu_Account";
            this.btnMenu_Account.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Account.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Account.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Account.OnHoverImage = null;
            this.btnMenu_Account.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Account.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Account.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Account.Size = new System.Drawing.Size(200, 42);
            this.btnMenu_Account.TabIndex = 1;
            this.btnMenu_Account.Text = "Tài Khoản";
            this.btnMenu_Account.TextOffsetX = 15;
            this.btnMenu_Account.Click += new System.EventHandler(this.btnMenu_Account_Click);
            // 
            // btnMenu_Home
            // 
            this.btnMenu_Home.AnimationHoverSpeed = 0.07F;
            this.btnMenu_Home.AnimationSpeed = 0.03F;
            this.btnMenu_Home.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.btnMenu_Home.BorderColor = System.Drawing.Color.Black;
            this.btnMenu_Home.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenu_Home.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenu_Home.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMenu_Home.ForeColor = System.Drawing.Color.White;
            this.btnMenu_Home.Image = global::TDT.Admin.Desktop.Properties.Resources.icons8_home_50;
            this.btnMenu_Home.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenu_Home.Location = new System.Drawing.Point(0, 12);
            this.btnMenu_Home.Margin = new System.Windows.Forms.Padding(5);
            this.btnMenu_Home.Name = "btnMenu_Home";
            this.btnMenu_Home.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnMenu_Home.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenu_Home.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenu_Home.OnHoverImage = null;
            this.btnMenu_Home.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenu_Home.Padding = new System.Windows.Forms.Padding(10);
            this.btnMenu_Home.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMenu_Home.Size = new System.Drawing.Size(195, 42);
            this.btnMenu_Home.TabIndex = 0;
            this.btnMenu_Home.Text = "Trang Chủ";
            this.btnMenu_Home.TextOffsetX = 15;
            this.btnMenu_Home.Click += new System.EventHandler(this.btnMenu_Home_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1364, 724);
            this.ControlBox = false;
            this.Controls.Add(this.pnlProfile);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Trị";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaButton btnMenu_Home;
        private Guna.UI.WinForms.GunaButton btnMenu_Permission;
        private Guna.UI.WinForms.GunaButton btnMenu_Role;
        private Guna.UI.WinForms.GunaButton btnMenu_Account;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI.WinForms.GunaCircleButton btnUserProfile;
        private Guna.UI.WinForms.GunaButton btnMenu_Group;
        private Guna.UI.WinForms.GunaButton btnMenu_Genre;
        private Guna.UI.WinForms.GunaButton btnMenu_Playlist;
        private Guna.UI.WinForms.GunaButton btnMenu_Song;
        private System.Windows.Forms.Panel pnlProfile;
        private Guna.UI.WinForms.GunaButton btnUserName;
        private Guna.UI.WinForms.GunaButton btnLogout;
        private Guna.UI.WinForms.GunaButton btnExit;
    }
}