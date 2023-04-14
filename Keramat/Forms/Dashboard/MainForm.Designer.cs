namespace Keramat.Forms.Dashboard {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tblRoot = new System.Windows.Forms.TableLayoutPanel();
            this.sideBar = new System.Windows.Forms.TableLayoutPanel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.sideBtnPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.lblCharitySlogan = new System.Windows.Forms.Label();
            this.lblChrityName = new System.Windows.Forms.Label();
            this.tblRoot.SuspendLayout();
            this.sideBar.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRoot
            // 
            this.tblRoot.ColumnCount = 2;
            this.tblRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tblRoot.Controls.Add(this.sideBar, 1, 0);
            this.tblRoot.Controls.Add(this.panel, 0, 0);
            this.tblRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRoot.Location = new System.Drawing.Point(0, 0);
            this.tblRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tblRoot.Name = "tblRoot";
            this.tblRoot.RowCount = 1;
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRoot.Size = new System.Drawing.Size(784, 561);
            this.tblRoot.TabIndex = 0;
            // 
            // sideBar
            // 
            this.sideBar.ColumnCount = 1;
            this.sideBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sideBar.Controls.Add(this.lblFooter, 0, 2);
            this.sideBar.Controls.Add(this.lblTitle, 0, 0);
            this.sideBar.Controls.Add(this.sideBtnPnl, 0, 1);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBar.Location = new System.Drawing.Point(554, 0);
            this.sideBar.Margin = new System.Windows.Forms.Padding(0);
            this.sideBar.Name = "sideBar";
            this.sideBar.RowCount = 3;
            this.sideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.sideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sideBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.sideBar.Size = new System.Drawing.Size(230, 561);
            this.sideBar.TabIndex = 0;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.Location = new System.Drawing.Point(0, 511);
            this.lblFooter.Margin = new System.Windows.Forms.Padding(0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFooter.Size = new System.Drawing.Size(230, 50);
            this.lblFooter.TabIndex = 2;
            this.lblFooter.Text = "lblFooter";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(230, 100);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "lblTitle";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sideBtnPnl
            // 
            this.sideBtnPnl.AutoScroll = true;
            this.sideBtnPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sideBtnPnl.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.sideBtnPnl.Location = new System.Drawing.Point(0, 100);
            this.sideBtnPnl.Margin = new System.Windows.Forms.Padding(0);
            this.sideBtnPnl.Name = "sideBtnPnl";
            this.sideBtnPnl.Size = new System.Drawing.Size(230, 411);
            this.sideBtnPnl.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.lblCharitySlogan);
            this.panel.Controls.Add(this.lblChrityName);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(10, 10);
            this.panel.Margin = new System.Windows.Forms.Padding(10);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(534, 541);
            this.panel.TabIndex = 1;
            // 
            // lblCharitySlogan
            // 
            this.lblCharitySlogan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCharitySlogan.Location = new System.Drawing.Point(0, 60);
            this.lblCharitySlogan.Name = "lblCharitySlogan";
            this.lblCharitySlogan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCharitySlogan.Size = new System.Drawing.Size(534, 40);
            this.lblCharitySlogan.TabIndex = 1;
            this.lblCharitySlogan.Text = "lblCharitySlogan";
            this.lblCharitySlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChrityName
            // 
            this.lblChrityName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChrityName.Location = new System.Drawing.Point(0, 0);
            this.lblChrityName.Name = "lblChrityName";
            this.lblChrityName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblChrityName.Size = new System.Drawing.Size(534, 60);
            this.lblChrityName.TabIndex = 0;
            this.lblChrityName.Text = "lblChrityName";
            this.lblChrityName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tblRoot);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tblRoot.ResumeLayout(false);
            this.sideBar.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tblRoot;
        private TableLayoutPanel sideBar;
        private Label lblFooter;
        private Label lblTitle;
        private FlowLayoutPanel sideBtnPnl;
        private Panel panel;
        private Label lblCharitySlogan;
        private Label lblChrityName;
    }
}