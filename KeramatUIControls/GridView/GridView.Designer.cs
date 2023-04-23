namespace KeramatUIControls.GridView {
    partial class GridView {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Header = new KeramatUIControls.GridView.GridViewHeaderRow();
            this.Footer = new KeramatUIControls.GridView.GridViewFooter();
            this.Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.SeaGreen;
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Margin = new System.Windows.Forms.Padding(0);
            this.Header.MaximumSize = new System.Drawing.Size(10000, 50);
            this.Header.MinimumSize = new System.Drawing.Size(0, 50);
            this.Header.Name = "Header";
            this.Header.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Header.Size = new System.Drawing.Size(583, 50);
            this.Header.TabIndex = 0;
            // 
            // Footer
            // 
            this.Footer.BackColor = System.Drawing.Color.Green;
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(0, 304);
            this.Footer.Margin = new System.Windows.Forms.Padding(0);
            this.Footer.MaximumSize = new System.Drawing.Size(10000, 50);
            this.Footer.MinimumSize = new System.Drawing.Size(0, 50);
            this.Footer.Name = "Footer";
            this.Footer.Size = new System.Drawing.Size(583, 50);
            this.Footer.TabIndex = 1;
            // 
            // Panel
            // 
            this.Panel.AutoScroll = true;
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 50);
            this.Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Panel.Name = "Panel";
            this.Panel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Panel.Size = new System.Drawing.Size(583, 254);
            this.Panel.TabIndex = 2;
            // 
            // GridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.Footer);
            this.Controls.Add(this.Header);
            this.MinimumSize = new System.Drawing.Size(0, 200);
            this.Name = "GridView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(583, 354);
            this.ResumeLayout(false);

        }

        #endregion

        private GridViewHeaderRow Header;
        private GridViewFooter Footer;
        private Panel Panel;
    }
}
