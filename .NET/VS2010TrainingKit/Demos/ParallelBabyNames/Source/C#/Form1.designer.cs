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

namespace PlinqMvpDemo
{
    partial class Form1
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
            this.RunLinqButton = new System.Windows.Forms.Button();
            this.RunPlinqButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StateTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InputSize1MB = new System.Windows.Forms.RadioButton();
            this.InputSize5MB = new System.Windows.Forms.RadioButton();
            this.InputSize10MB = new System.Windows.Forms.RadioButton();
            this.InputSize50MB = new System.Windows.Forms.RadioButton();
            this.InputSize100MB = new System.Windows.Forms.RadioButton();
            this.InputSize250MB = new System.Windows.Forms.RadioButton();
            this.InputSize500MB = new System.Windows.Forms.RadioButton();
            this.LinqPicture = new System.Windows.Forms.PictureBox();
            this.PlinqPicture = new System.Windows.Forms.PictureBox();
            this.LinqTimeLabel = new System.Windows.Forms.Label();
            this.PlinqTimeLabel = new System.Windows.Forms.Label();
            this.SpeedupLabel = new System.Windows.Forms.Label();
            this.LinqYearStartLabel = new System.Windows.Forms.Label();
            this.PlinqYearStartLabel = new System.Windows.Forms.Label();
            this.LinqYearEndLabel = new System.Windows.Forms.Label();
            this.PlinqYearEndLabel = new System.Windows.Forms.Label();
            this.LinqValueStartLabel = new System.Windows.Forms.Label();
            this.PlinqValueStartLabel = new System.Windows.Forms.Label();
            this.PlinqValueEndLabel = new System.Windows.Forms.Label();
            this.LinqValueEndLabel = new System.Windows.Forms.Label();
            this.InputSize1GB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LineRadioButton = new System.Windows.Forms.RadioButton();
            this.HistogramRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.ProcessorsToUse = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.LinqPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlinqPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessorsToUse)).BeginInit();
            this.SuspendLayout();
            // 
            // RunLinqButton
            // 
            this.RunLinqButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.RunLinqButton.Location = new System.Drawing.Point(89, 384);
            this.RunLinqButton.Name = "RunLinqButton";
            this.RunLinqButton.Size = new System.Drawing.Size(198, 57);
            this.RunLinqButton.TabIndex = 0;
            this.RunLinqButton.Text = "LINQ";
            this.RunLinqButton.UseVisualStyleBackColor = true;
            this.RunLinqButton.Click += new System.EventHandler(this.RunLinqButton_Click);
            // 
            // RunPlinqButton
            // 
            this.RunPlinqButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.RunPlinqButton.Location = new System.Drawing.Point(600, 384);
            this.RunPlinqButton.Name = "RunPlinqButton";
            this.RunPlinqButton.Size = new System.Drawing.Size(198, 57);
            this.RunPlinqButton.TabIndex = 1;
            this.RunPlinqButton.Text = "PLINQ";
            this.RunPlinqButton.UseVisualStyleBackColor = true;
            this.RunPlinqButton.Click += new System.EventHandler(this.RunPlinqButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(386, 418);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(146, 23);
            this.NameTextBox.TabIndex = 4;
            this.NameTextBox.Text = "Robert";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "State:";
            // 
            // StateTextBox
            // 
            this.StateTextBox.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StateTextBox.Location = new System.Drawing.Point(386, 444);
            this.StateTextBox.Name = "StateTextBox";
            this.StateTextBox.Size = new System.Drawing.Size(146, 23);
            this.StateTextBox.TabIndex = 6;
            this.StateTextBox.Text = "WA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Input size:";
            // 
            // InputSize1MB
            // 
            this.InputSize1MB.AutoSize = true;
            this.InputSize1MB.Location = new System.Drawing.Point(386, 496);
            this.InputSize1MB.Name = "InputSize1MB";
            this.InputSize1MB.Size = new System.Drawing.Size(47, 17);
            this.InputSize1MB.TabIndex = 12;
            this.InputSize1MB.Tag = "1";
            this.InputSize1MB.Text = "1MB";
            this.InputSize1MB.UseVisualStyleBackColor = true;
            this.InputSize1MB.CheckedChanged += new System.EventHandler(this.InputSize1MB_CheckedChanged);
            // 
            // InputSize5MB
            // 
            this.InputSize5MB.AutoSize = true;
            this.InputSize5MB.Location = new System.Drawing.Point(451, 496);
            this.InputSize5MB.Name = "InputSize5MB";
            this.InputSize5MB.Size = new System.Drawing.Size(47, 17);
            this.InputSize5MB.TabIndex = 13;
            this.InputSize5MB.Tag = "5";
            this.InputSize5MB.Text = "5MB";
            this.InputSize5MB.UseVisualStyleBackColor = true;
            this.InputSize5MB.CheckedChanged += new System.EventHandler(this.InputSize5MB_CheckedChanged);
            // 
            // InputSize10MB
            // 
            this.InputSize10MB.AutoSize = true;
            this.InputSize10MB.Location = new System.Drawing.Point(516, 496);
            this.InputSize10MB.Name = "InputSize10MB";
            this.InputSize10MB.Size = new System.Drawing.Size(53, 17);
            this.InputSize10MB.TabIndex = 14;
            this.InputSize10MB.Tag = "10";
            this.InputSize10MB.Text = "10MB";
            this.InputSize10MB.UseVisualStyleBackColor = true;
            this.InputSize10MB.CheckedChanged += new System.EventHandler(this.InputSize10MB_CheckedChanged);
            // 
            // InputSize50MB
            // 
            this.InputSize50MB.AutoSize = true;
            this.InputSize50MB.Location = new System.Drawing.Point(580, 496);
            this.InputSize50MB.Name = "InputSize50MB";
            this.InputSize50MB.Size = new System.Drawing.Size(53, 17);
            this.InputSize50MB.TabIndex = 15;
            this.InputSize50MB.Tag = "50";
            this.InputSize50MB.Text = "50MB";
            this.InputSize50MB.UseVisualStyleBackColor = true;
            this.InputSize50MB.CheckedChanged += new System.EventHandler(this.InputSize50MB_CheckedChanged);
            // 
            // InputSize100MB
            // 
            this.InputSize100MB.AutoSize = true;
            this.InputSize100MB.Location = new System.Drawing.Point(386, 519);
            this.InputSize100MB.Name = "InputSize100MB";
            this.InputSize100MB.Size = new System.Drawing.Size(59, 17);
            this.InputSize100MB.TabIndex = 16;
            this.InputSize100MB.Tag = "100";
            this.InputSize100MB.Text = "100MB";
            this.InputSize100MB.UseVisualStyleBackColor = true;
            this.InputSize100MB.CheckedChanged += new System.EventHandler(this.InputSize100MB_CheckedChanged);
            // 
            // InputSize250MB
            // 
            this.InputSize250MB.AutoSize = true;
            this.InputSize250MB.Checked = true;
            this.InputSize250MB.Location = new System.Drawing.Point(451, 519);
            this.InputSize250MB.Name = "InputSize250MB";
            this.InputSize250MB.Size = new System.Drawing.Size(59, 17);
            this.InputSize250MB.TabIndex = 17;
            this.InputSize250MB.TabStop = true;
            this.InputSize250MB.Tag = "250";
            this.InputSize250MB.Text = "250MB";
            this.InputSize250MB.UseVisualStyleBackColor = true;
            this.InputSize250MB.CheckedChanged += new System.EventHandler(this.InputSize250MB_CheckedChanged);
            // 
            // InputSize500MB
            // 
            this.InputSize500MB.AutoSize = true;
            this.InputSize500MB.Location = new System.Drawing.Point(516, 519);
            this.InputSize500MB.Name = "InputSize500MB";
            this.InputSize500MB.Size = new System.Drawing.Size(59, 17);
            this.InputSize500MB.TabIndex = 18;
            this.InputSize500MB.TabStop = true;
            this.InputSize500MB.Tag = "500";
            this.InputSize500MB.Text = "500MB";
            this.InputSize500MB.UseVisualStyleBackColor = true;
            this.InputSize500MB.CheckedChanged += new System.EventHandler(this.InputSize500MB_CheckedChanged);
            // 
            // LinqPicture
            // 
            this.LinqPicture.Location = new System.Drawing.Point(35, 26);
            this.LinqPicture.Name = "LinqPicture";
            this.LinqPicture.Size = new System.Drawing.Size(404, 326);
            this.LinqPicture.TabIndex = 19;
            this.LinqPicture.TabStop = false;
            // 
            // PlinqPicture
            // 
            this.PlinqPicture.Location = new System.Drawing.Point(485, 26);
            this.PlinqPicture.Name = "PlinqPicture";
            this.PlinqPicture.Size = new System.Drawing.Size(404, 326);
            this.PlinqPicture.TabIndex = 20;
            this.PlinqPicture.TabStop = false;
            // 
            // LinqTimeLabel
            // 
            this.LinqTimeLabel.AutoSize = true;
            this.LinqTimeLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinqTimeLabel.ForeColor = System.Drawing.Color.Red;
            this.LinqTimeLabel.Location = new System.Drawing.Point(93, 454);
            this.LinqTimeLabel.Name = "LinqTimeLabel";
            this.LinqTimeLabel.Size = new System.Drawing.Size(112, 26);
            this.LinqTimeLabel.TabIndex = 22;
            this.LinqTimeLabel.Text = "0.0 seconds";
            this.LinqTimeLabel.Visible = false;
            // 
            // PlinqTimeLabel
            // 
            this.PlinqTimeLabel.AutoSize = true;
            this.PlinqTimeLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlinqTimeLabel.ForeColor = System.Drawing.Color.Red;
            this.PlinqTimeLabel.Location = new System.Drawing.Point(686, 454);
            this.PlinqTimeLabel.Name = "PlinqTimeLabel";
            this.PlinqTimeLabel.Size = new System.Drawing.Size(112, 26);
            this.PlinqTimeLabel.TabIndex = 23;
            this.PlinqTimeLabel.Text = "0.0 seconds";
            this.PlinqTimeLabel.Visible = false;
            // 
            // SpeedupLabel
            // 
            this.SpeedupLabel.AutoSize = true;
            this.SpeedupLabel.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedupLabel.ForeColor = System.Drawing.Color.Red;
            this.SpeedupLabel.Location = new System.Drawing.Point(340, 365);
            this.SpeedupLabel.Name = "SpeedupLabel";
            this.SpeedupLabel.Size = new System.Drawing.Size(188, 36);
            this.SpeedupLabel.TabIndex = 24;
            this.SpeedupLabel.Text = "1.03X speedup";
            this.SpeedupLabel.Visible = false;
            // 
            // LinqYearStartLabel
            // 
            this.LinqYearStartLabel.AutoSize = true;
            this.LinqYearStartLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinqYearStartLabel.Location = new System.Drawing.Point(32, 355);
            this.LinqYearStartLabel.Name = "LinqYearStartLabel";
            this.LinqYearStartLabel.Size = new System.Drawing.Size(31, 13);
            this.LinqYearStartLabel.TabIndex = 25;
            this.LinqYearStartLabel.Text = "1970";
            // 
            // PlinqYearStartLabel
            // 
            this.PlinqYearStartLabel.AutoSize = true;
            this.PlinqYearStartLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlinqYearStartLabel.Location = new System.Drawing.Point(482, 355);
            this.PlinqYearStartLabel.Name = "PlinqYearStartLabel";
            this.PlinqYearStartLabel.Size = new System.Drawing.Size(31, 13);
            this.PlinqYearStartLabel.TabIndex = 26;
            this.PlinqYearStartLabel.Text = "1970";
            // 
            // LinqYearEndLabel
            // 
            this.LinqYearEndLabel.AutoSize = true;
            this.LinqYearEndLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinqYearEndLabel.Location = new System.Drawing.Point(409, 355);
            this.LinqYearEndLabel.Name = "LinqYearEndLabel";
            this.LinqYearEndLabel.Size = new System.Drawing.Size(31, 13);
            this.LinqYearEndLabel.TabIndex = 27;
            this.LinqYearEndLabel.Text = "1970";
            // 
            // PlinqYearEndLabel
            // 
            this.PlinqYearEndLabel.AutoSize = true;
            this.PlinqYearEndLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlinqYearEndLabel.Location = new System.Drawing.Point(858, 355);
            this.PlinqYearEndLabel.Name = "PlinqYearEndLabel";
            this.PlinqYearEndLabel.Size = new System.Drawing.Size(31, 13);
            this.PlinqYearEndLabel.TabIndex = 28;
            this.PlinqYearEndLabel.Text = "1970";
            // 
            // LinqValueStartLabel
            // 
            this.LinqValueStartLabel.AutoSize = true;
            this.LinqValueStartLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinqValueStartLabel.Location = new System.Drawing.Point(16, 339);
            this.LinqValueStartLabel.Name = "LinqValueStartLabel";
            this.LinqValueStartLabel.Size = new System.Drawing.Size(13, 13);
            this.LinqValueStartLabel.TabIndex = 29;
            this.LinqValueStartLabel.Text = "0";
            this.LinqValueStartLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlinqValueStartLabel
            // 
            this.PlinqValueStartLabel.AutoSize = true;
            this.PlinqValueStartLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlinqValueStartLabel.Location = new System.Drawing.Point(466, 339);
            this.PlinqValueStartLabel.Name = "PlinqValueStartLabel";
            this.PlinqValueStartLabel.Size = new System.Drawing.Size(13, 13);
            this.PlinqValueStartLabel.TabIndex = 30;
            this.PlinqValueStartLabel.Text = "0";
            this.PlinqValueStartLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlinqValueEndLabel
            // 
            this.PlinqValueEndLabel.AutoSize = true;
            this.PlinqValueEndLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlinqValueEndLabel.Location = new System.Drawing.Point(448, 26);
            this.PlinqValueEndLabel.Name = "PlinqValueEndLabel";
            this.PlinqValueEndLabel.Size = new System.Drawing.Size(31, 13);
            this.PlinqValueEndLabel.TabIndex = 31;
            this.PlinqValueEndLabel.Text = "1000";
            this.PlinqValueEndLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LinqValueEndLabel
            // 
            this.LinqValueEndLabel.AutoSize = true;
            this.LinqValueEndLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinqValueEndLabel.Location = new System.Drawing.Point(-2, 26);
            this.LinqValueEndLabel.Name = "LinqValueEndLabel";
            this.LinqValueEndLabel.Size = new System.Drawing.Size(31, 13);
            this.LinqValueEndLabel.TabIndex = 32;
            this.LinqValueEndLabel.Text = "1000";
            this.LinqValueEndLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // InputSize1GB
            // 
            this.InputSize1GB.AutoSize = true;
            this.InputSize1GB.Location = new System.Drawing.Point(580, 519);
            this.InputSize1GB.Name = "InputSize1GB";
            this.InputSize1GB.Size = new System.Drawing.Size(46, 17);
            this.InputSize1GB.TabIndex = 33;
            this.InputSize1GB.Tag = "500";
            this.InputSize1GB.Text = "1GB";
            this.InputSize1GB.UseVisualStyleBackColor = true;
            this.InputSize1GB.CheckedChanged += new System.EventHandler(this.InputSize1GB_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LineRadioButton);
            this.groupBox1.Controls.Add(this.HistogramRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(11, 483);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 53);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // LineRadioButton
            // 
            this.LineRadioButton.AutoSize = true;
            this.LineRadioButton.Location = new System.Drawing.Point(163, 21);
            this.LineRadioButton.Name = "LineRadioButton";
            this.LineRadioButton.Size = new System.Drawing.Size(77, 17);
            this.LineRadioButton.TabIndex = 1;
            this.LineRadioButton.Text = "Line Graph";
            this.LineRadioButton.UseVisualStyleBackColor = true;
            // 
            // HistogramRadioButton
            // 
            this.HistogramRadioButton.AutoSize = true;
            this.HistogramRadioButton.Checked = true;
            this.HistogramRadioButton.Location = new System.Drawing.Point(14, 21);
            this.HistogramRadioButton.Name = "HistogramRadioButton";
            this.HistogramRadioButton.Size = new System.Drawing.Size(125, 17);
            this.HistogramRadioButton.TabIndex = 0;
            this.HistogramRadioButton.TabStop = true;
            this.HistogramRadioButton.Text = "Histogram/Bar Graph";
            this.HistogramRadioButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(665, 496);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Processors:";
            // 
            // ProcessorsToUse
            // 
            this.ProcessorsToUse.Location = new System.Drawing.Point(742, 496);
            this.ProcessorsToUse.Name = "ProcessorsToUse";
            this.ProcessorsToUse.Size = new System.Drawing.Size(147, 45);
            this.ProcessorsToUse.TabIndex = 36;
            this.ProcessorsToUse.Scroll += new System.EventHandler(this.ProcessorsToUse_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 562);
            this.Controls.Add(this.ProcessorsToUse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.InputSize1GB);
            this.Controls.Add(this.LinqValueEndLabel);
            this.Controls.Add(this.PlinqValueEndLabel);
            this.Controls.Add(this.PlinqValueStartLabel);
            this.Controls.Add(this.LinqValueStartLabel);
            this.Controls.Add(this.PlinqYearEndLabel);
            this.Controls.Add(this.LinqYearEndLabel);
            this.Controls.Add(this.PlinqYearStartLabel);
            this.Controls.Add(this.LinqYearStartLabel);
            this.Controls.Add(this.SpeedupLabel);
            this.Controls.Add(this.PlinqTimeLabel);
            this.Controls.Add(this.LinqTimeLabel);
            this.Controls.Add(this.PlinqPicture);
            this.Controls.Add(this.LinqPicture);
            this.Controls.Add(this.InputSize500MB);
            this.Controls.Add(this.InputSize250MB);
            this.Controls.Add(this.InputSize100MB);
            this.Controls.Add(this.InputSize50MB);
            this.Controls.Add(this.InputSize10MB);
            this.Controls.Add(this.InputSize5MB);
            this.Controls.Add(this.InputSize1MB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StateTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.RunPlinqButton);
            this.Controls.Add(this.RunLinqButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PLINQ Demo";
            ((System.ComponentModel.ISupportInitialize)(this.LinqPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlinqPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessorsToUse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RunLinqButton;
        private System.Windows.Forms.Button RunPlinqButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StateTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton InputSize1MB;
        private System.Windows.Forms.RadioButton InputSize5MB;
        private System.Windows.Forms.RadioButton InputSize10MB;
        private System.Windows.Forms.RadioButton InputSize50MB;
        private System.Windows.Forms.RadioButton InputSize100MB;
        private System.Windows.Forms.RadioButton InputSize250MB;
        private System.Windows.Forms.RadioButton InputSize500MB;
        private System.Windows.Forms.PictureBox LinqPicture;
        private System.Windows.Forms.PictureBox PlinqPicture;
        private System.Windows.Forms.Label LinqTimeLabel;
        private System.Windows.Forms.Label PlinqTimeLabel;
        private System.Windows.Forms.Label SpeedupLabel;
        private System.Windows.Forms.Label LinqYearStartLabel;
        private System.Windows.Forms.Label PlinqYearStartLabel;
        private System.Windows.Forms.Label LinqYearEndLabel;
        private System.Windows.Forms.Label PlinqYearEndLabel;
        private System.Windows.Forms.Label LinqValueStartLabel;
        private System.Windows.Forms.Label PlinqValueStartLabel;
        private System.Windows.Forms.Label PlinqValueEndLabel;
        private System.Windows.Forms.Label LinqValueEndLabel;
        private System.Windows.Forms.RadioButton InputSize1GB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton LineRadioButton;
        private System.Windows.Forms.RadioButton HistogramRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar ProcessorsToUse;
    }
}

