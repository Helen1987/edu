// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace HRClient
{
    partial class HRForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HRForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.candidateConfirmationNumber = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.confirmationTitle = new System.Windows.Forms.Label();
            this.offerPanel = new System.Windows.Forms.Panel();
            this.confirmationPanel = new System.Windows.Forms.Panel();
            this.buttonStartAgain = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRefs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEducation = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.confirmationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(30, 82);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Candidate Information Form";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtName.Location = new System.Drawing.Point(83, 103);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(214, 20);
            this.txtName.TabIndex = 1;
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.submitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(222, 186);
            this.submitButton.Name = "submitButton";
            this.submitButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // candidateConfirmationNumber
            // 
            this.candidateConfirmationNumber.AutoSize = true;
            this.candidateConfirmationNumber.BackColor = System.Drawing.SystemColors.Window;
            this.candidateConfirmationNumber.Cursor = System.Windows.Forms.Cursors.Default;
            this.candidateConfirmationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.candidateConfirmationNumber.Location = new System.Drawing.Point(56, 215);
            this.candidateConfirmationNumber.Name = "candidateConfirmationNumber";
            this.candidateConfirmationNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.candidateConfirmationNumber.Size = new System.Drawing.Size(0, 13);
            this.candidateConfirmationNumber.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::HRClient.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 68);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.confirmationTitle);
            this.flowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(301, 44);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // confirmationTitle
            // 
            this.confirmationTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmationTitle.AutoSize = true;
            this.confirmationTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.confirmationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmationTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.confirmationTitle.Location = new System.Drawing.Point(3, 0);
            this.confirmationTitle.Name = "confirmationTitle";
            this.confirmationTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.confirmationTitle.Size = new System.Drawing.Size(34, 17);
            this.confirmationTitle.TabIndex = 0;
            this.confirmationTitle.Text = "text";
            this.confirmationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // offerPanel
            // 
            this.offerPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.offerPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.offerPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.offerPanel.Location = new System.Drawing.Point(14, 10);
            this.offerPanel.Name = "offerPanel";
            this.offerPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.offerPanel.Size = new System.Drawing.Size(316, 112);
            this.offerPanel.TabIndex = 10;
            this.offerPanel.Visible = false;
            // 
            // confirmationPanel
            // 
            this.confirmationPanel.Controls.Add(this.buttonStartAgain);
            this.confirmationPanel.Controls.Add(this.offerPanel);
            this.confirmationPanel.Controls.Add(this.flowLayoutPanel1);
            this.confirmationPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.confirmationPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmationPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.confirmationPanel.Location = new System.Drawing.Point(19, 75);
            this.confirmationPanel.Name = "confirmationPanel";
            this.confirmationPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.confirmationPanel.Size = new System.Drawing.Size(344, 147);
            this.confirmationPanel.TabIndex = 7;
            this.confirmationPanel.Visible = false;
            // 
            // buttonStartAgain
            // 
            this.buttonStartAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonStartAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartAgain.ForeColor = System.Drawing.Color.White;
            this.buttonStartAgain.Location = new System.Drawing.Point(115, 92);
            this.buttonStartAgain.Name = "buttonStartAgain";
            this.buttonStartAgain.Size = new System.Drawing.Size(75, 23);
            this.buttonStartAgain.TabIndex = 11;
            this.buttonStartAgain.Text = "Start Again";
            this.buttonStartAgain.UseVisualStyleBackColor = false;
            this.buttonStartAgain.Click += new System.EventHandler(this.buttonStartAgain_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 188);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "References:";
            // 
            // txtRefs
            // 
            this.txtRefs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRefs.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRefs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtRefs.Location = new System.Drawing.Point(83, 185);
            this.txtRefs.MaxLength = 50;
            this.txtRefs.Name = "txtRefs";
            this.txtRefs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRefs.Size = new System.Drawing.Size(45, 20);
            this.txtRefs.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 161);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Education:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 106);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // comboBoxEducation
            // 
            this.comboBoxEducation.FormattingEnabled = true;
            this.comboBoxEducation.Items.AddRange(new object[] {
            "None",
            "Bachelors",
            "Masters",
            "Doctorate"});
            this.comboBoxEducation.Location = new System.Drawing.Point(83, 157);
            this.comboBoxEducation.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxEducation.Name = "comboBoxEducation";
            this.comboBoxEducation.Size = new System.Drawing.Size(212, 21);
            this.comboBoxEducation.TabIndex = 15;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(83, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(214, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 133);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Email:";
            // 
            // HRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(376, 232);
            this.Controls.Add(this.confirmationPanel);
            this.Controls.Add(this.candidateConfirmationNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtRefs);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.comboBoxEducation);
            this.Controls.Add(this.txtEmail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HRForm";
            this.Text = "Contoso HR Tool";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.confirmationPanel.ResumeLayout(false);
            this.confirmationPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label candidateConfirmationNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label confirmationTitle;
        private System.Windows.Forms.Panel offerPanel;
        private System.Windows.Forms.Panel confirmationPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRefs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStartAgain;
        private System.Windows.Forms.ComboBox comboBoxEducation;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
    }
}