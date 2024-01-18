using System.ComponentModel;
using System.Windows.Forms;
using TGMTplayer.Controls;

namespace ExamplePlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                _mWindowState?.Dispose();

                //_updateTimer?.Dispose();
                _houseKeepingTimer?.Dispose();
                //sometimes hangs??
                //if (_fsw != null)
                //    _fsw.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._helpItem = new System.Windows.Forms.MenuItem();
            this.menu_weigher = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_accessControl = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_user = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_changePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_permission = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctxtMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._takePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.ctxtMnu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _helpItem
            // 
            this._helpItem.Index = -1;
            this._helpItem.Text = "";
            // 
            // menu_weigher
            // 
            this.menu_weigher.Name = "menu_weigher";
            this.menu_weigher.Size = new System.Drawing.Size(32, 19);
            // 
            // menu_accessControl
            // 
            this.menu_accessControl.Image = ((System.Drawing.Image)(resources.GetObject("menu_accessControl.Image")));
            this.menu_accessControl.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.menu_accessControl.Name = "menu_accessControl";
            this.menu_accessControl.Padding = new System.Windows.Forms.Padding(0);
            this.menu_accessControl.Size = new System.Drawing.Size(187, 20);
            this.menu_accessControl.Text = "Board Access Control";
            // 
            // menu_user
            // 
            this.menu_user.Name = "menu_user";
            this.menu_user.Size = new System.Drawing.Size(32, 19);
            // 
            // menu_changePassword
            // 
            this.menu_changePassword.Image = ((System.Drawing.Image)(resources.GetObject("menu_changePassword.Image")));
            this.menu_changePassword.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.menu_changePassword.Name = "menu_changePassword";
            this.menu_changePassword.Padding = new System.Windows.Forms.Padding(0);
            this.menu_changePassword.Size = new System.Drawing.Size(145, 20);
            this.menu_changePassword.Text = "Đổi mật khẩu";
            // 
            // menu_permission
            // 
            this.menu_permission.Image = ((System.Drawing.Image)(resources.GetObject("menu_permission.Image")));
            this.menu_permission.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.menu_permission.Name = "menu_permission";
            this.menu_permission.Padding = new System.Windows.Forms.Padding(0);
            this.menu_permission.Size = new System.Drawing.Size(145, 20);
            this.menu_permission.Text = "Phân quyền";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(150, 100);
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 327);
            this.panel1.TabIndex = 25;
            // 
            // ctxtMnu
            // 
            this.ctxtMnu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxtMnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._takePhotoToolStripMenuItem});
            this.ctxtMnu.Name = "_ctxtMnu";
            this.ctxtMnu.Size = new System.Drawing.Size(142, 30);
            // 
            // _takePhotoToolStripMenuItem
            // 
            this._takePhotoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("_takePhotoToolStripMenuItem.Image")));
            this._takePhotoToolStripMenuItem.Name = "_takePhotoToolStripMenuItem";
            this._takePhotoToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this._takePhotoToolStripMenuItem.Text = "Take Picture";
            this._takePhotoToolStripMenuItem.Click += new System.EventHandler(this._takePhotoToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.txt_url);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 71);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(532, 24);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 32);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_url
            // 
            this.txt_url.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_url.Location = new System.Drawing.Point(57, 26);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(469, 29);
            this.txt_url.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(642, 398);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TGMT player";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ctxtMnu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


       
        private MenuItem _helpItem;
        private static string _lastPath = Program.AppPath;
        private static string _currentFileName = "";
        
       
        private FormWindowState _previousWindowState = FormWindowState.Normal;
        private bool _shuttingDown;
        private IContainer components;
      

        private SplitContainer splitContainer2;
        private ToolStripMenuItem menu_weigher;
        private ToolStripMenuItem menu_accessControl;
        private Panel panel1;
        private ToolStripMenuItem menu_user;
        private ToolStripMenuItem menu_permission;
        private ContextMenuStrip ctxtMnu;
        private ToolStripMenuItem _takePhotoToolStripMenuItem;
        private ToolStripMenuItem menu_changePassword;
        private GroupBox groupBox1;
        private Label label1;
        private Button btn_start;
        private TextBox txt_url;
    }
}