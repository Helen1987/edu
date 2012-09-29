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
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.ServiceModel;
    using System.ServiceModel.Discovery;
    using System.Windows.Forms;
    using System.Xml.Linq;
    using Microsoft.Samples.Discovery.Contracts;
    using Microsoft.Samples.Discovery.Properties;
    using System.ServiceModel.Description;

    public partial class SimpleChat : Form
    {
        #region Methods and Fields modified in lab

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Demo code")]
        private void AdHocDiscovery()
        {
            this.discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());

            this.discoveryClient.FindProgressChanged +=
                new EventHandler<FindProgressChangedEventArgs>(this.OnFindProgressChanged);
            this.discoveryClient.FindCompleted +=
                new EventHandler<FindCompletedEventArgs>(this.OnFindCompleted);

            // Setup the form for discovery
            this.ShowDiscoveryInProgress(true);

            // Do async discovery
            this.discoveryClient.FindAsync(new FindCriteria(typeof(ISimpleChatService)), discoveryClient);
        }

        private void OnFindProgressChanged(object sender, FindProgressChangedEventArgs e)
        {
            this.PopulateUserList(e.EndpointDiscoveryMetadata);
        }

        private void OnFindCompleted(object sender, FindCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.ShowStatus("Discovery cancelled");
            }
            else if (e.Error != null)
            {
                this.discoveryClient.Close();
                MessageBox.Show(
                    e.Error.Message,
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    (MessageBoxOptions)0);
            }
            else
            {
                if (this.discoveryClient.InnerChannel.State == CommunicationState.Opened)
                {
                    this.discoveryClient.Close();
                }
            }

            this.discoveryClient = null;
            this.ShowDiscoveryInProgress(false);
        }


        private void OpenServices()
        {
            // Create a singleton instance for the host
            ChatService chatService = new ChatService(this);
            chatServiceHost = new ServiceHost(chatService, this.localAddress);

            // Create a discovery behavior
            EndpointDiscoveryBehavior endpointDiscoveryBehavior = new EndpointDiscoveryBehavior();

            // Add an extension element with the username
            endpointDiscoveryBehavior.Extensions.Add(
                new XElement(
                    "root",
                    new XElement("Name", this.userName)));

            // Find the endpoint
            ServiceEndpoint simpleEndpoint =
                this.chatServiceHost.Description.Endpoints.Find(typeof(ISimpleChatService));

            // Add our behavior to the endpoint before opening it
            simpleEndpoint.Behaviors.Add(endpointDiscoveryBehavior);

            ShowStatus("Opening chat service...");
            chatServiceHost.BeginOpen(
                (result) =>
                {
                    chatServiceHost.EndOpen(result);
                    ShowStatus("Chat service ready");
                },
                null);
        }


        private void CloseServices()
        {
            if (this.chatServiceHost != null)
            {
                this.chatServiceHost.BeginClose(
                    (result) => { this.chatServiceHost.EndClose(result); },
                    null);
            }
        }

        private void PopulateUserList(EndpointDiscoveryMetadata endpointDiscoveryMetadata)
        {
            if (!this.EndpointIsSelf(endpointDiscoveryMetadata.Address.Uri))
            {
                this.AddUser(new PeerUser(GetPeerName(endpointDiscoveryMetadata), endpointDiscoveryMetadata.Address));
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Demo code")]
        private void ManagedDiscovery()
        {
            throw new NotImplementedException();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Demo code")]
        private void InitializeManagedDiscovery()
        {
            // TODO
        }

        #endregion

        #region Lab Supplied Code
        #region Variables and Imports
        private ServiceHost chatServiceHost;
        private Uri localAddress;
        private string userName;
        private DiscoveryClient discoveryClient;
        #endregion

        public SimpleChat()
        {
            InitializeComponent();
            this.InitializeManagedDiscovery();
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
        }

        public Uri LocalAddress
        {
            get
            {
                return this.localAddress;
            }
        }

        #region UI code and logic

        private void OnSignInOut(bool signedIn)
        {
            this.buttonSignOn.Enabled = !signedIn;
            this.buttonSignOut.Enabled = signedIn;
            this.buttonDiscover.Enabled = signedIn;
            this.discoveryBox.Enabled = signedIn;
        }

        private void UserNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.ButtonSignOn_Click(sender, null);
            }
        }

        // User is setting up the chat client
        private void ButtonSignOn_Click(object sender, EventArgs e)
        {
            this.SignIn();
        }

        private void DiscoverChatUsers()
        {
            this.userListBox.Items.Clear();

            if (managedRadioButton.Checked)
            {
                this.ManagedDiscovery();
            }
            else
            {
                this.AdHocDiscovery();
            }
        }

        private void ShowStatus(string status)
        {
            if (this.IsHandleCreated)
            {
                Invoke(
                    new EventHandler(delegate(object o, EventArgs a)
                        {
                            statusLabel.Text = status;
                        }));
            }
        }

        private void AdHocRadioB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.adhocRadioButton.Checked)
            {
                this.proxyAddressText.Enabled = false;
            }
        }

        private void ManagedRadioB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.managedRadioButton.Checked)
            {
                this.EnableManagedDiscovery();
            }
        }

        private void EnableManagedDiscovery()
        {
            this.proxyAddressText.Enabled = true;
            proxyAddressText.Text = Resources.ProxyAddress;
        }

        private void DiscoverButton_Click(object sender, EventArgs e)
        {
            this.DiscoverChatUsers();
        }

        private void UserListBox_DoubleClick(object sender, EventArgs e)
        {
            PeerUser selectedPeerUser = this.userListBox.SelectedItem as PeerUser;
            if (selectedPeerUser == null)
            {
                MessageBox.Show(
                        Resources.SelectUserMessage,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        (MessageBoxOptions)0);
                return;
            }

            if (selectedPeerUser.ChatWindowExists)
            {
                ShowChatWindow(selectedPeerUser);
            }
            else
            {
                ChatWindow newChatWindow = new ChatWindow(this, selectedPeerUser);
                selectedPeerUser.ChatWindow = newChatWindow;
                ShowChatWindow(selectedPeerUser);
            }
        }

        private static void ShowChatWindow(PeerUser peerUserObject)
        {
            NativeMethods.SetForegroundWindow(peerUserObject.ChatWindow.Owner.Handle);
            NativeMethods.SetForegroundWindow(peerUserObject.ChatWindow.Handle);
        }

        private void ButtonSignOut_Click(object sender, EventArgs e)
        {
            this.SignOut();
        }

        private void ChatButton_Click(object sender, EventArgs e)
        {
            this.UserListBox_DoubleClick(sender, e);
        }

        private void UserListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                this.UserListBox_DoubleClick(sender, e);
            }
        }

        public PeerUser GetUser(Uri searchUri)
        {
            foreach (object user in this.userListBox.Items)
            {
                PeerUser peerUser = user as PeerUser;
                if (peerUser.Address.Uri.Equals(searchUri))
                {
                    return peerUser;
                }
            }

            return null;
        }

        public void AddUser(PeerUser peerUser)
        {
            this.userListBox.Items.Add(peerUser);
            this.EnableUsersBox();
        }

        public void RemoveUser(Uri searchUri)
        {
            foreach (object user in this.userListBox.Items)
            {
                PeerUser peerUser = user as PeerUser;
                if (peerUser.Address.Uri.Equals(searchUri))
                {
                    if (peerUser.ChatWindowExists)
                    {
                        peerUser.ChatWindow.Close();
                    }

                    this.userListBox.Items.Remove(user);
                    break;
                }
            }
        }

        private void CloseAllWindows()
        {
            foreach (object userObject in this.userListBox.Items)
            {
                PeerUser peerUser = userObject as PeerUser;
                if (peerUser.ChatWindowExists)
                {
                    peerUser.ChatWindow.Close();
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.SignOut();
            base.OnClosing(e);
        }

        #endregion

        private void SignIn()
        {
            this.userName = userNameText.Text.Trim();

            if (this.userName.Length == 0)
            {
                MessageBox.Show(
                    Resources.EnterValidNameMessage,
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    (MessageBoxOptions)0);
                return;
            }

            this.Text = string.Format(CultureInfo.CurrentCulture, Resources.DiscoveryChat, this.userName);

            this.ShowStatus("Getting host name");

            // Initialize the setup parameters            
            this.localAddress = new Uri("http://localhost:8000/" + Guid.NewGuid().ToString());

            this.ShowStatus("Opening chat service host");
            this.OpenServices();
            this.OnSignInOut(true);
            this.DiscoverChatUsers();
        }

        private void SignOut()
        {
            this.ShowStatus("Signing out...");
            this.AbortDiscovery();
            this.CloseServices();
            this.CloseAllWindows();
            this.userListBox.Items.Clear();
            this.EnableUsersBox();
            this.OnSignInOut(false);
        }

        private void ShowDiscoveryInProgress(bool inProgress)
        {
            buttonDiscover.Enabled = !inProgress;

            if (inProgress)
            {
                buttonDiscover.Text = Resources.DiscoveryInProgressText;
            }
            else
            {
                buttonDiscover.Text = Resources.DiscoverUsersText;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Demo code")]
        private bool EndpointIsSelf(Uri endpointUri)
        {
            return this.localAddress.Equals(endpointUri);
        }

        private void EnableUsersBox()
        {
            this.usersBox.Enabled = this.userListBox.Items.Count > 0;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Demo code")]
        private void AbortDiscovery()
        {
            if (this.discoveryClient != null)
            {
                discoveryClient.CancelAsync(discoveryClient);
                this.discoveryClient.Close();
            }
        }

        private static string GetPeerName(EndpointDiscoveryMetadata metadata)
        {
            XElement peerNameElement =
                metadata.Extensions.Elements("Name").FirstOrDefault();

            if (peerNameElement != null)
                return peerNameElement.Value;

            return null;
        }
        #endregion
    }
}