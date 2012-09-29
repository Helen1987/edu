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
    partial class ChatWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            this.chatBox = new System.Windows.Forms.ListBox();
            this.chatText = new System.Windows.Forms.TextBox();
            this.sendMessage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.FormattingEnabled = true;
            resources.ApplyResources(this.chatBox, "chatBox");
            this.chatBox.Name = "chatBox";
            // 
            // chatText
            // 
            resources.ApplyResources(this.chatText, "chatText");
            this.chatText.Name = "chatText";
            this.chatText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatText_KeyDown);
            // 
            // sendMessage
            // 
            resources.ApplyResources(this.sendMessage, "sendMessage");
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.UseVisualStyleBackColor = true;
            this.sendMessage.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ChatWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.chatText);
            this.Controls.Add(this.chatBox);
            this.MaximizeBox = false;
            this.Name = "ChatWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox chatBox;
        private System.Windows.Forms.TextBox chatText;
        private System.Windows.Forms.Button sendMessage;
        private System.Windows.Forms.Label label1;
    }
}