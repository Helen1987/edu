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

namespace Microsoft.Samples.Discovery
{
    partial class SimpleChat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "chatServiceHost", Justification="Demo code")]
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleChat));
            this.adhocRadioButton = new System.Windows.Forms.RadioButton();
            this.managedRadioButton = new System.Windows.Forms.RadioButton();
            this.proxyAddressText = new System.Windows.Forms.TextBox();
            this.discoveryBox = new System.Windows.Forms.GroupBox();
            this.discoverStatus = new System.Windows.Forms.Label();
            this.buttonDiscover = new System.Windows.Forms.Button();
            this.usersBox = new System.Windows.Forms.GroupBox();
            this.chatButton = new System.Windows.Forms.Button();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.setupBox = new System.Windows.Forms.GroupBox();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.buttonSignOn = new System.Windows.Forms.Button();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.discoveryBox.SuspendLayout();
            this.usersBox.SuspendLayout();
            this.setupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // adhocRadioButton
            // 
            resources.ApplyResources(this.adhocRadioButton, "adhocRadioButton");
            this.adhocRadioButton.Checked = true;
            this.adhocRadioButton.Name = "adhocRadioButton";
            this.adhocRadioButton.TabStop = true;
            this.adhocRadioButton.UseVisualStyleBackColor = true;
            this.adhocRadioButton.CheckedChanged += new System.EventHandler(this.AdHocRadioB_CheckedChanged);
            // 
            // managedRadioButton
            // 
            resources.ApplyResources(this.managedRadioButton, "managedRadioButton");
            this.managedRadioButton.Name = "managedRadioButton";
            this.managedRadioButton.UseVisualStyleBackColor = true;
            this.managedRadioButton.CheckedChanged += new System.EventHandler(this.ManagedRadioB_CheckedChanged);
            // 
            // proxyAddressText
            // 
            resources.ApplyResources(this.proxyAddressText, "proxyAddressText");
            this.proxyAddressText.Name = "proxyAddressText";
            // 
            // discoveryBox
            // 
            this.discoveryBox.Controls.Add(this.discoverStatus);
            this.discoveryBox.Controls.Add(this.buttonDiscover);
            this.discoveryBox.Controls.Add(this.adhocRadioButton);
            this.discoveryBox.Controls.Add(this.proxyAddressText);
            this.discoveryBox.Controls.Add(this.managedRadioButton);
            resources.ApplyResources(this.discoveryBox, "discoveryBox");
            this.discoveryBox.Name = "discoveryBox";
            this.discoveryBox.TabStop = false;
            // 
            // discoverStatus
            // 
            resources.ApplyResources(this.discoverStatus, "discoverStatus");
            this.discoverStatus.Name = "discoverStatus";
            // 
            // buttonDiscover
            // 
            resources.ApplyResources(this.buttonDiscover, "buttonDiscover");
            this.buttonDiscover.Name = "buttonDiscover";
            this.buttonDiscover.UseVisualStyleBackColor = true;
            this.buttonDiscover.Click += new System.EventHandler(this.DiscoverButton_Click);
            // 
            // usersBox
            // 
            this.usersBox.Controls.Add(this.chatButton);
            this.usersBox.Controls.Add(this.userListBox);
            resources.ApplyResources(this.usersBox, "usersBox");
            this.usersBox.Name = "usersBox";
            this.usersBox.TabStop = false;
            // 
            // chatButton
            // 
            resources.ApplyResources(this.chatButton, "chatButton");
            this.chatButton.Name = "chatButton";
            this.chatButton.UseVisualStyleBackColor = true;
            this.chatButton.Click += new System.EventHandler(this.ChatButton_Click);
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            resources.ApplyResources(this.userListBox, "userListBox");
            this.userListBox.Name = "userListBox";
            this.userListBox.DoubleClick += new System.EventHandler(this.UserListBox_DoubleClick);
            this.userListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserListBox_KeyDown);
            // 
            // setupBox
            // 
            this.setupBox.Controls.Add(this.buttonSignOut);
            this.setupBox.Controls.Add(this.buttonSignOn);
            this.setupBox.Controls.Add(this.userNameText);
            this.setupBox.Controls.Add(this.userNameLabel);
            resources.ApplyResources(this.setupBox, "setupBox");
            this.setupBox.Name = "setupBox";
            this.setupBox.TabStop = false;
            // 
            // buttonSignOut
            // 
            resources.ApplyResources(this.buttonSignOut, "buttonSignOut");
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            this.buttonSignOut.Click += new System.EventHandler(this.ButtonSignOut_Click);
            // 
            // buttonSignOn
            // 
            resources.ApplyResources(this.buttonSignOn, "buttonSignOn");
            this.buttonSignOn.Name = "buttonSignOn";
            this.buttonSignOn.UseVisualStyleBackColor = true;
            this.buttonSignOn.Click += new System.EventHandler(this.ButtonSignOn_Click);
            // 
            // userNameText
            // 
            resources.ApplyResources(this.userNameText, "userNameText");
            this.userNameText.Name = "userNameText";
            this.userNameText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserNameText_KeyDown);
            // 
            // userNameLabel
            // 
            resources.ApplyResources(this.userNameLabel, "userNameLabel");
            this.userNameLabel.Name = "userNameLabel";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // SimpleChat
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.setupBox);
            this.Controls.Add(this.usersBox);
            this.Controls.Add(this.discoveryBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleChat";
            this.discoveryBox.ResumeLayout(false);
            this.discoveryBox.PerformLayout();
            this.usersBox.ResumeLayout(false);
            this.setupBox.ResumeLayout(false);
            this.setupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton adhocRadioButton;
        private System.Windows.Forms.RadioButton managedRadioButton;
        private System.Windows.Forms.TextBox proxyAddressText;
        private System.Windows.Forms.GroupBox discoveryBox;
        private System.Windows.Forms.GroupBox usersBox;
        private System.Windows.Forms.Button chatButton;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.Button buttonDiscover;
        private System.Windows.Forms.Label discoverStatus;
        private System.Windows.Forms.GroupBox setupBox;
        private System.Windows.Forms.Button buttonSignOn;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button buttonSignOut;
    }
}