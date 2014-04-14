namespace VS_Info
{
    partial class VSInfoForm
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
            this.TC = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.VSINFO = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ENVINFO = new System.Windows.Forms.TextBox();
            this.PN = new System.Windows.Forms.Panel();
            this.OKBtn = new System.Windows.Forms.Button();
            this.TC.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.PN.SuspendLayout();
            this.SuspendLayout();
            // 
            // TC
            // 
            this.TC.Controls.Add(this.tabPage1);
            this.TC.Controls.Add(this.tabPage2);
            this.TC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC.Location = new System.Drawing.Point(0, 0);
            this.TC.Name = "TC";
            this.TC.SelectedIndex = 0;
            this.TC.Size = new System.Drawing.Size(664, 466);
            this.TC.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PN);
            this.tabPage1.Controls.Add(this.VSINFO);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(656, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Visual Studio";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // VSINFO
            // 
            this.VSINFO.BackColor = System.Drawing.SystemColors.Info;
            this.VSINFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VSINFO.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VSINFO.Location = new System.Drawing.Point(3, 3);
            this.VSINFO.Multiline = true;
            this.VSINFO.Name = "VSINFO";
            this.VSINFO.ReadOnly = true;
            this.VSINFO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VSINFO.Size = new System.Drawing.Size(650, 434);
            this.VSINFO.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ENVINFO);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(656, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Environment";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ENVINFO
            // 
            this.ENVINFO.BackColor = System.Drawing.SystemColors.Info;
            this.ENVINFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ENVINFO.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ENVINFO.Location = new System.Drawing.Point(3, 3);
            this.ENVINFO.Multiline = true;
            this.ENVINFO.Name = "ENVINFO";
            this.ENVINFO.ReadOnly = true;
            this.ENVINFO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ENVINFO.Size = new System.Drawing.Size(650, 434);
            this.ENVINFO.TabIndex = 1;
            // 
            // PN
            // 
            this.PN.Controls.Add(this.OKBtn);
            this.PN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PN.Location = new System.Drawing.Point(3, 399);
            this.PN.Name = "PN";
            this.PN.Size = new System.Drawing.Size(650, 38);
            this.PN.TabIndex = 2;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKBtn.Location = new System.Drawing.Point(561, 8);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(85, 23);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // VSInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 466);
            this.Controls.Add(this.TC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "VSInfoForm";
            this.Text = "Visual Studio Environment";
            this.TC.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.PN.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TC;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel PN;
        private System.Windows.Forms.Button OKBtn;
        public System.Windows.Forms.TextBox VSINFO;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TextBox ENVINFO;

    }
}