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
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.ServiceModel;
    using System.Windows.Forms;
    using Microsoft.Samples.Discovery.Contracts;
    using Microsoft.Samples.Discovery.Properties;

    public partial class ChatWindow : Form
    {
        private ISimpleChatService chatClient;
        private SimpleChat simpleChatOwner;
        private PeerUser peerUser;

        public ChatWindow(SimpleChat simpleChat, PeerUser peerUserObject)
        {
            if (simpleChat == null)
            {
                throw new ArgumentNullException("simpleChat");
            }

            if (peerUserObject == null)
            {
                throw new ArgumentNullException("peerUserObject");
            }

            InitializeComponent();

            this.chatClient =
                ChannelFactory<ISimpleChatService>.CreateChannel(
                new WSHttpBinding(), peerUserObject.Address);

            this.simpleChatOwner = simpleChat;

            this.peerUser = peerUserObject;

            string chatWith = null;

            if (!string.IsNullOrEmpty(peerUserObject.UserName))
            {
                chatWith = this.peerUser.UserName;
            }
            else
            {
                chatWith = this.peerUser.Address.Uri.Host;
            }

            Text = string.Format(
                CultureInfo.CurrentCulture,
                Resources.ChattingWithMessage,
                simpleChat.UserName,
                chatWith);
            Owner = simpleChat;

            StartPosition = FormStartPosition.CenterParent;
            Show();
            chatText.Focus();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Demo code")]
        private void SendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                ChatMessage sentMsg = new ChatMessage(this.simpleChatOwner.UserName, chatText.Text, this.simpleChatOwner.LocalAddress);
                this.chatClient.ProcessSimpleMessage(sentMsg);
                this.DisplayMessage(sentMsg);
                this.chatText.Clear();
            }
            catch (CommunicationException cex)
            {
                ((ICommunicationObject)chatClient).Abort();
                MessageBox.Show(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.UserNotAvailableMessage,
                        this.peerUser.UserName,
                        cex.Message),
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        (MessageBoxOptions)0);
                this.simpleChatOwner.RemoveUser(this.peerUser.Address.Uri);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(CultureInfo.CurrentCulture, Resources.UnknownErrorMessage, ex.Message),
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        (MessageBoxOptions)0);
            }
        }

        private void ChatText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.SendMessage_Click(sender, e);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.chatClient != null)
            {
                try
                {
                    ((ICommunicationObject)chatClient).Close();
                }
                catch (CommunicationException)
                {
                    // No worries, closing
                }
            }

            base.OnClosing(e);
        }

        public void DisplayMessage(ChatMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            chatBox.Items.Add(message.UserName + " says: " + message.Message);
        }
    }
}