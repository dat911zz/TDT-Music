namespace TDT.Admin.Desktop.Views
{
    partial class frmSong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvSongDTO = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tEST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpbThumbnail = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.btnChonAnh = new Guna.UI2.WinForms.Guna2Button();
            this.txtID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlias = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtArtists = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArtistsNames = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDistributor = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDuration = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cboAlbum = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbIsWorldWide = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cbIsPrivate = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cbPreRelease = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cbIsIndie = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cbHasLyric = new Guna.UI2.WinForms.Guna2CheckBox();
            this.cbIsRBT = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLike = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtListen = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtComment = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUserID = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSongDTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtListen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(434, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 67;
            this.label1.Text = "Quản Lý Bài Hát";
            // 
            // dtgvSongDTO
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtgvSongDTO.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvSongDTO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvSongDTO.ColumnHeadersHeight = 18;
            this.dtgvSongDTO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgvSongDTO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tEST,
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvSongDTO.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvSongDTO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvSongDTO.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvSongDTO.Location = new System.Drawing.Point(0, 295);
            this.dtgvSongDTO.Name = "dtgvSongDTO";
            this.dtgvSongDTO.RowHeadersVisible = false;
            this.dtgvSongDTO.RowHeadersWidth = 51;
            this.dtgvSongDTO.RowTemplate.Height = 24;
            this.dtgvSongDTO.Size = new System.Drawing.Size(1065, 349);
            this.dtgvSongDTO.TabIndex = 76;
            this.dtgvSongDTO.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvSongDTO.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtgvSongDTO.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtgvSongDTO.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtgvSongDTO.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtgvSongDTO.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtgvSongDTO.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvSongDTO.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtgvSongDTO.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgvSongDTO.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtgvSongDTO.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtgvSongDTO.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtgvSongDTO.ThemeStyle.HeaderStyle.Height = 18;
            this.dtgvSongDTO.ThemeStyle.ReadOnly = false;
            this.dtgvSongDTO.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtgvSongDTO.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtgvSongDTO.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtgvSongDTO.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtgvSongDTO.ThemeStyle.RowsStyle.Height = 24;
            this.dtgvSongDTO.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtgvSongDTO.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // tEST
            // 
            this.tEST.HeaderText = "Column1";
            this.tEST.MinimumWidth = 6;
            this.tEST.Name = "tEST";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // cpbThumbnail
            // 
            this.cpbThumbnail.BaseColor = System.Drawing.Color.White;
            this.cpbThumbnail.Image = global::TDT.Admin.Desktop.Properties.Resources.logo_TDT_Devil_red;
            this.cpbThumbnail.Location = new System.Drawing.Point(858, 31);
            this.cpbThumbnail.Name = "cpbThumbnail";
            this.cpbThumbnail.Size = new System.Drawing.Size(160, 167);
            this.cpbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cpbThumbnail.TabIndex = 78;
            this.cpbThumbnail.TabStop = false;
            this.cpbThumbnail.UseTransfarantBackground = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Animated = true;
            this.btnChonAnh.AutoRoundedCorners = true;
            this.btnChonAnh.BorderRadius = 21;
            this.btnChonAnh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChonAnh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChonAnh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChonAnh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChonAnh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(879, 220);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(120, 45);
            this.btnChonAnh.TabIndex = 79;
            this.btnChonAnh.Text = "Chọn Ảnh";
            // 
            // txtID
            // 
            this.txtID.Animated = true;
            this.txtID.BorderColor = System.Drawing.Color.Blue;
            this.txtID.BorderRadius = 5;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.DefaultText = "";
            this.txtID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtID.Location = new System.Drawing.Point(121, 43);
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.PlaceholderText = "Mã ID";
            this.txtID.SelectedText = "";
            this.txtID.Size = new System.Drawing.Size(181, 27);
            this.txtID.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(28, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "Mã ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(28, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 83;
            this.label3.Text = "Tiêu đề";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            this.txtTitle.Animated = true;
            this.txtTitle.BorderColor = System.Drawing.Color.Blue;
            this.txtTitle.BorderRadius = 5;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.DefaultText = "";
            this.txtTitle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTitle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitle.Location = new System.Drawing.Point(121, 77);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.PlaceholderText = "Title";
            this.txtTitle.SelectedText = "";
            this.txtTitle.Size = new System.Drawing.Size(181, 27);
            this.txtTitle.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(28, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 85;
            this.label4.Text = "Bí danh";
            // 
            // txtAlias
            // 
            this.txtAlias.Animated = true;
            this.txtAlias.BorderColor = System.Drawing.Color.Blue;
            this.txtAlias.BorderRadius = 5;
            this.txtAlias.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAlias.DefaultText = "";
            this.txtAlias.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAlias.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAlias.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAlias.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAlias.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAlias.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtAlias.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAlias.Location = new System.Drawing.Point(121, 116);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.PasswordChar = '\0';
            this.txtAlias.PlaceholderText = "Alias";
            this.txtAlias.SelectedText = "";
            this.txtAlias.Size = new System.Drawing.Size(181, 27);
            this.txtAlias.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(335, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 89;
            this.label5.Text = "List Nghệ Sĩ";
            // 
            // txtArtists
            // 
            this.txtArtists.Animated = true;
            this.txtArtists.BorderColor = System.Drawing.Color.Blue;
            this.txtArtists.BorderRadius = 5;
            this.txtArtists.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArtists.DefaultText = "";
            this.txtArtists.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtArtists.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtArtists.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArtists.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArtists.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArtists.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtArtists.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArtists.Location = new System.Drawing.Point(442, 262);
            this.txtArtists.Name = "txtArtists";
            this.txtArtists.PasswordChar = '\0';
            this.txtArtists.PlaceholderText = "List Nghệ Sĩ";
            this.txtArtists.SelectedText = "";
            this.txtArtists.Size = new System.Drawing.Size(181, 27);
            this.txtArtists.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(28, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 87;
            this.label6.Text = "Nghệ sĩ";
            // 
            // txtArtistsNames
            // 
            this.txtArtistsNames.Animated = true;
            this.txtArtistsNames.BorderColor = System.Drawing.Color.Blue;
            this.txtArtistsNames.BorderRadius = 5;
            this.txtArtistsNames.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtArtistsNames.DefaultText = "";
            this.txtArtistsNames.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtArtistsNames.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtArtistsNames.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArtistsNames.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtArtistsNames.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArtistsNames.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtArtistsNames.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtArtistsNames.Location = new System.Drawing.Point(121, 191);
            this.txtArtistsNames.Name = "txtArtistsNames";
            this.txtArtistsNames.PasswordChar = '\0';
            this.txtArtistsNames.PlaceholderText = "Tên nghệ sĩ";
            this.txtArtistsNames.SelectedText = "";
            this.txtArtistsNames.Size = new System.Drawing.Size(181, 27);
            this.txtArtistsNames.TabIndex = 86;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(28, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 93;
            this.label7.Text = "User Name";
            // 
            // txtUsername
            // 
            this.txtUsername.Animated = true;
            this.txtUsername.BorderColor = System.Drawing.Color.Blue;
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(121, 151);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(181, 27);
            this.txtUsername.TabIndex = 92;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(335, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 91;
            this.label8.Text = "Thời lượng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(335, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 17);
            this.label9.TabIndex = 95;
            this.label9.Text = "Nhà phân phối";
            // 
            // txtDistributor
            // 
            this.txtDistributor.Animated = true;
            this.txtDistributor.BorderColor = System.Drawing.Color.Blue;
            this.txtDistributor.BorderRadius = 5;
            this.txtDistributor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDistributor.DefaultText = "Nhà phân phối";
            this.txtDistributor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDistributor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDistributor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDistributor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDistributor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDistributor.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDistributor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDistributor.Location = new System.Drawing.Point(442, 116);
            this.txtDistributor.Name = "txtDistributor";
            this.txtDistributor.PasswordChar = '\0';
            this.txtDistributor.PlaceholderText = "Mã ID";
            this.txtDistributor.SelectedText = "";
            this.txtDistributor.Size = new System.Drawing.Size(181, 27);
            this.txtDistributor.TabIndex = 94;
            // 
            // txtDuration
            // 
            this.txtDuration.BackColor = System.Drawing.Color.Transparent;
            this.txtDuration.BorderColor = System.Drawing.Color.Blue;
            this.txtDuration.BorderRadius = 5;
            this.txtDuration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDuration.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDuration.Location = new System.Drawing.Point(442, 40);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(181, 30);
            this.txtDuration.TabIndex = 96;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(28, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 97;
            this.label10.Text = "Album";
            // 
            // cboAlbum
            // 
            this.cboAlbum.BackColor = System.Drawing.Color.Transparent;
            this.cboAlbum.BorderColor = System.Drawing.Color.Blue;
            this.cboAlbum.BorderRadius = 5;
            this.cboAlbum.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboAlbum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlbum.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboAlbum.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboAlbum.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboAlbum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboAlbum.ItemHeight = 25;
            this.cboAlbum.Location = new System.Drawing.Point(121, 234);
            this.cboAlbum.Name = "cboAlbum";
            this.cboAlbum.Size = new System.Drawing.Size(181, 31);
            this.cboAlbum.TabIndex = 98;
            // 
            // cbIsWorldWide
            // 
            this.cbIsWorldWide.AutoSize = true;
            this.cbIsWorldWide.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsWorldWide.CheckedState.BorderRadius = 0;
            this.cbIsWorldWide.CheckedState.BorderThickness = 0;
            this.cbIsWorldWide.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsWorldWide.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbIsWorldWide.Location = new System.Drawing.Point(660, 40);
            this.cbIsWorldWide.Name = "cbIsWorldWide";
            this.cbIsWorldWide.Size = new System.Drawing.Size(121, 21);
            this.cbIsWorldWide.TabIndex = 99;
            this.cbIsWorldWide.Text = "Bản Toàn Cầu";
            this.cbIsWorldWide.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbIsWorldWide.UncheckedState.BorderRadius = 0;
            this.cbIsWorldWide.UncheckedState.BorderThickness = 0;
            this.cbIsWorldWide.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cbIsPrivate
            // 
            this.cbIsPrivate.AutoSize = true;
            this.cbIsPrivate.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsPrivate.CheckedState.BorderRadius = 0;
            this.cbIsPrivate.CheckedState.BorderThickness = 0;
            this.cbIsPrivate.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsPrivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbIsPrivate.Location = new System.Drawing.Point(660, 70);
            this.cbIsPrivate.Name = "cbIsPrivate";
            this.cbIsPrivate.Size = new System.Drawing.Size(107, 21);
            this.cbIsPrivate.TabIndex = 100;
            this.cbIsPrivate.Text = "Bản riêng tư";
            this.cbIsPrivate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbIsPrivate.UncheckedState.BorderRadius = 0;
            this.cbIsPrivate.UncheckedState.BorderThickness = 0;
            this.cbIsPrivate.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cbPreRelease
            // 
            this.cbPreRelease.AutoSize = true;
            this.cbPreRelease.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPreRelease.CheckedState.BorderRadius = 0;
            this.cbPreRelease.CheckedState.BorderThickness = 0;
            this.cbPreRelease.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPreRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbPreRelease.Location = new System.Drawing.Point(660, 96);
            this.cbPreRelease.Name = "cbPreRelease";
            this.cbPreRelease.Size = new System.Drawing.Size(170, 21);
            this.cbPreRelease.TabIndex = 101;
            this.cbPreRelease.Text = "Trước ngày phát hành";
            this.cbPreRelease.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbPreRelease.UncheckedState.BorderRadius = 0;
            this.cbPreRelease.UncheckedState.BorderThickness = 0;
            this.cbPreRelease.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cbIsIndie
            // 
            this.cbIsIndie.AutoSize = true;
            this.cbIsIndie.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsIndie.CheckedState.BorderRadius = 0;
            this.cbIsIndie.CheckedState.BorderThickness = 0;
            this.cbIsIndie.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsIndie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbIsIndie.Location = new System.Drawing.Point(660, 121);
            this.cbIsIndie.Name = "cbIsIndie";
            this.cbIsIndie.Size = new System.Drawing.Size(105, 21);
            this.cbIsIndie.TabIndex = 102;
            this.cbIsIndie.Text = "Bản độc lập";
            this.cbIsIndie.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbIsIndie.UncheckedState.BorderRadius = 0;
            this.cbIsIndie.UncheckedState.BorderThickness = 0;
            this.cbIsIndie.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cbHasLyric
            // 
            this.cbHasLyric.AutoSize = true;
            this.cbHasLyric.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbHasLyric.CheckedState.BorderRadius = 0;
            this.cbHasLyric.CheckedState.BorderThickness = 0;
            this.cbHasLyric.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbHasLyric.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbHasLyric.Location = new System.Drawing.Point(660, 147);
            this.cbHasLyric.Name = "cbHasLyric";
            this.cbHasLyric.Size = new System.Drawing.Size(112, 21);
            this.cbHasLyric.TabIndex = 103;
            this.cbHasLyric.Text = "Có lời bài hát";
            this.cbHasLyric.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbHasLyric.UncheckedState.BorderRadius = 0;
            this.cbHasLyric.UncheckedState.BorderThickness = 0;
            this.cbHasLyric.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // cbIsRBT
            // 
            this.cbIsRBT.AutoSize = true;
            this.cbIsRBT.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsRBT.CheckedState.BorderRadius = 0;
            this.cbIsRBT.CheckedState.BorderThickness = 0;
            this.cbIsRBT.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsRBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbIsRBT.Location = new System.Drawing.Point(660, 177);
            this.cbIsRBT.Name = "cbIsRBT";
            this.cbIsRBT.Size = new System.Drawing.Size(106, 21);
            this.cbIsRBT.TabIndex = 104;
            this.cbIsRBT.Text = "Là bản RBT";
            this.cbIsRBT.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.cbIsRBT.UncheckedState.BorderRadius = 0;
            this.cbIsRBT.UncheckedState.BorderThickness = 0;
            this.cbIsRBT.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(335, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 17);
            this.label11.TabIndex = 105;
            this.label11.Text = "Lượt thích";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(335, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 17);
            this.label12.TabIndex = 107;
            this.label12.Text = "Lượt nghe";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(335, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 17);
            this.label13.TabIndex = 109;
            this.label13.Text = "Lượt bình luận";
            // 
            // txtLike
            // 
            this.txtLike.BackColor = System.Drawing.Color.Transparent;
            this.txtLike.BorderColor = System.Drawing.Color.Blue;
            this.txtLike.BorderRadius = 5;
            this.txtLike.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLike.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtLike.Location = new System.Drawing.Point(442, 149);
            this.txtLike.Name = "txtLike";
            this.txtLike.Size = new System.Drawing.Size(181, 30);
            this.txtLike.TabIndex = 112;
            // 
            // txtListen
            // 
            this.txtListen.BackColor = System.Drawing.Color.Transparent;
            this.txtListen.BorderColor = System.Drawing.Color.Blue;
            this.txtListen.BorderRadius = 5;
            this.txtListen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtListen.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtListen.Location = new System.Drawing.Point(442, 184);
            this.txtListen.Name = "txtListen";
            this.txtListen.Size = new System.Drawing.Size(181, 30);
            this.txtListen.TabIndex = 113;
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.Color.Transparent;
            this.txtComment.BorderColor = System.Drawing.Color.Blue;
            this.txtComment.BorderRadius = 5;
            this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtComment.Location = new System.Drawing.Point(442, 220);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(181, 30);
            this.txtComment.TabIndex = 114;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.Location = new System.Drawing.Point(335, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 17);
            this.label14.TabIndex = 116;
            this.label14.Text = "User ID";
            // 
            // txtUserID
            // 
            this.txtUserID.Animated = true;
            this.txtUserID.BorderColor = System.Drawing.Color.Blue;
            this.txtUserID.BorderRadius = 5;
            this.txtUserID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserID.DefaultText = "";
            this.txtUserID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUserID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserID.Location = new System.Drawing.Point(442, 78);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '\0';
            this.txtUserID.PlaceholderText = "User ID";
            this.txtUserID.SelectedText = "";
            this.txtUserID.Size = new System.Drawing.Size(181, 27);
            this.txtUserID.TabIndex = 115;
            // 
            // frmSong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 644);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtListen);
            this.Controls.Add(this.txtLike);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbIsRBT);
            this.Controls.Add(this.cbHasLyric);
            this.Controls.Add(this.cbIsIndie);
            this.Controls.Add(this.cbPreRelease);
            this.Controls.Add(this.cbIsPrivate);
            this.Controls.Add(this.cbIsWorldWide);
            this.Controls.Add(this.cboAlbum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDistributor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtArtists);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtArtistsNames);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.cpbThumbnail);
            this.Controls.Add(this.dtgvSongDTO);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSong";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSongDTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpbThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtListen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView dtgvSongDTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn tEST;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private Guna.UI.WinForms.GunaCirclePictureBox cpbThumbnail;
        private Guna.UI2.WinForms.Guna2Button btnChonAnh;
        private Guna.UI2.WinForms.Guna2TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTitle;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtAlias;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtArtists;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtArtistsNames;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtDistributor;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtDuration;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox cboAlbum;
        private Guna.UI2.WinForms.Guna2CheckBox cbIsWorldWide;
        private Guna.UI2.WinForms.Guna2CheckBox cbIsPrivate;
        private Guna.UI2.WinForms.Guna2CheckBox cbPreRelease;
        private Guna.UI2.WinForms.Guna2CheckBox cbIsIndie;
        private Guna.UI2.WinForms.Guna2CheckBox cbHasLyric;
        private Guna.UI2.WinForms.Guna2CheckBox cbIsRBT;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtLike;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtListen;
        private Guna.UI2.WinForms.Guna2NumericUpDown txtComment;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2TextBox txtUserID;
    }
}