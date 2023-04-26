namespace Keramat.Forms.ValiNematan {
    partial class ValiNematanForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValiNematanForm));
            this.toolBox = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.btnClearSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOthers = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnConnector = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFamilyNeeds = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMemebersNeeds = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSpecialDiseases = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRelations = new System.Windows.Forms.ToolStripMenuItem();
            this.grid = new System.Windows.Forms.DataGridView();
            this.gridFooter = new KeramatUIControls.GridView.GridViewFooter();
            this.cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFinished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator1,
            this.txtSearch,
            this.btnSearch,
            this.toolStripSeparator2,
            this.btnOthers});
            this.toolBox.Location = new System.Drawing.Point(0, 0);
            this.toolBox.Name = "toolBox";
            this.toolBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolBox.Size = new System.Drawing.Size(584, 38);
            this.toolBox.TabIndex = 0;
            this.toolBox.Text = "toolBox";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(44, 35);
            this.btnAdd.Text = "افزودن";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_ClickAsync);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // txtSearch
            // 
            this.txtSearch.MaxLength = 100;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 38);
            this.txtSearch.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.ToolTipText = "جستجوی ساده";
            // 
            // btnSearch
            // 
            this.btnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearSearch});
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 35);
            this.btnSearch.Text = "جستجو";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.ButtonClick += new System.EventHandler(this.btnSearch_ButtonClick);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(170, 22);
            this.btnClearSearch.Text = "پاکسازی فرم جستجو";
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnOthers
            // 
            this.btnOthers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnector,
            this.btnLevel,
            this.btnFamilyNeeds,
            this.btnMemebersNeeds,
            this.btnSpecialDiseases,
            this.btnRelations});
            this.btnOthers.Image = ((System.Drawing.Image)(resources.GetObject("btnOthers.Image")));
            this.btnOthers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOthers.Name = "btnOthers";
            this.btnOthers.Size = new System.Drawing.Size(125, 35);
            this.btnOthers.Text = "مدیریت موارد تکمیلی";
            this.btnOthers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnConnector
            // 
            this.btnConnector.Name = "btnConnector";
            this.btnConnector.Size = new System.Drawing.Size(176, 22);
            this.btnConnector.Text = "معرف‌ها";
            // 
            // btnLevel
            // 
            this.btnLevel.Name = "btnLevel";
            this.btnLevel.Size = new System.Drawing.Size(176, 22);
            this.btnLevel.Text = "سطح‌بندی خانواده‌ها";
            // 
            // btnFamilyNeeds
            // 
            this.btnFamilyNeeds.Name = "btnFamilyNeeds";
            this.btnFamilyNeeds.Size = new System.Drawing.Size(176, 22);
            this.btnFamilyNeeds.Text = "نیاز خانواده‌ها";
            // 
            // btnMemebersNeeds
            // 
            this.btnMemebersNeeds.Name = "btnMemebersNeeds";
            this.btnMemebersNeeds.Size = new System.Drawing.Size(176, 22);
            this.btnMemebersNeeds.Text = "نیاز اعضای خانواده‌ها";
            // 
            // btnSpecialDiseases
            // 
            this.btnSpecialDiseases.Name = "btnSpecialDiseases";
            this.btnSpecialDiseases.Size = new System.Drawing.Size(176, 22);
            this.btnSpecialDiseases.Text = "بیماری‌های خاص";
            // 
            // btnRelations
            // 
            this.btnRelations.Name = "btnRelations";
            this.btnRelations.Size = new System.Drawing.Size(176, 22);
            this.btnRelations.Text = "روابط اعضای خانواده";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cId,
            this.cTitle,
            this.cFinished,
            this.cLevel,
            this.cCount,
            this.cDate});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(0, 38);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 25;
            this.grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(584, 273);
            this.grid.TabIndex = 1;
            // 
            // gridFooter
            // 
            this.gridFooter.BackColor = System.Drawing.Color.Silver;
            this.gridFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridFooter.Location = new System.Drawing.Point(0, 311);
            this.gridFooter.Margin = new System.Windows.Forms.Padding(0);
            this.gridFooter.MaximumSize = new System.Drawing.Size(10000, 50);
            this.gridFooter.MinimumSize = new System.Drawing.Size(0, 50);
            this.gridFooter.Name = "gridFooter";
            this.gridFooter.Pagination = null;
            this.gridFooter.Size = new System.Drawing.Size(584, 50);
            this.gridFooter.TabIndex = 2;
            this.gridFooter.PageChange += new KeramatUIControls.GridView.GridViewFooter.PageChangeHandler(this.gridFooter_PageChange);
            // 
            // cId
            // 
            this.cId.DataPropertyName = "Id";
            this.cId.FillWeight = 1F;
            this.cId.Frozen = true;
            this.cId.HeaderText = "کد";
            this.cId.Name = "cId";
            this.cId.ReadOnly = true;
            this.cId.Width = 50;
            // 
            // cTitle
            // 
            this.cTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cTitle.DataPropertyName = "Title";
            this.cTitle.FillWeight = 10F;
            this.cTitle.HeaderText = "عنوان";
            this.cTitle.Name = "cTitle";
            this.cTitle.ReadOnly = true;
            // 
            // cFinished
            // 
            this.cFinished.DataPropertyName = "Finished";
            this.cFinished.FillWeight = 10F;
            this.cFinished.HeaderText = "مختومه";
            this.cFinished.Name = "cFinished";
            this.cFinished.ReadOnly = true;
            this.cFinished.Width = 50;
            // 
            // cLevel
            // 
            this.cLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cLevel.DataPropertyName = "Level";
            this.cLevel.FillWeight = 3F;
            this.cLevel.HeaderText = "سطح";
            this.cLevel.Name = "cLevel";
            this.cLevel.ReadOnly = true;
            // 
            // cCount
            // 
            this.cCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cCount.DataPropertyName = "MembersCount";
            this.cCount.FillWeight = 2F;
            this.cCount.HeaderText = "تعداد اعضاء";
            this.cCount.Name = "cCount";
            this.cCount.ReadOnly = true;
            // 
            // cDate
            // 
            this.cDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cDate.DataPropertyName = "AddDate";
            this.cDate.FillWeight = 3F;
            this.cDate.HeaderText = "تاریخ درج";
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            // 
            // ValiNematanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.gridFooter);
            this.Controls.Add(this.toolBox);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ValiNematanForm";
            this.Text = "ولی‌نعمتان";
            this.Load += new System.EventHandler(this.ValiNematanForm_Load);
            this.toolBox.ResumeLayout(false);
            this.toolBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolBox;
        private ToolStripButton btnAdd;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox txtSearch;
        private ToolStripSplitButton btnSearch;
        private ToolStripMenuItem btnClearSearch;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripDropDownButton btnOthers;
        private ToolStripMenuItem btnConnector;
        private ToolStripMenuItem btnLevel;
        private ToolStripMenuItem btnFamilyNeeds;
        private ToolStripMenuItem btnMemebersNeeds;
        private ToolStripMenuItem btnSpecialDiseases;
        private ToolStripMenuItem btnRelations;
        private DataGridView grid;
        private KeramatUIControls.GridView.GridViewFooter gridFooter;
        private DataGridViewTextBoxColumn cId;
        private DataGridViewTextBoxColumn cTitle;
        private DataGridViewCheckBoxColumn cFinished;
        private DataGridViewTextBoxColumn cLevel;
        private DataGridViewTextBoxColumn cCount;
        private DataGridViewTextBoxColumn cDate;
    }
}