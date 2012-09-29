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
    using System.ServiceModel;

    public class PeerUser
    {
        private string userName;
        private EndpointAddress address;
        private ChatWindow chatWindow;

        public PeerUser(EndpointAddress address)
        {
            this.address = address;
        }

        public PeerUser(string userName, EndpointAddress address)
        {
            this.userName = userName;
            this.address = address;
        }

        public PeerUser(string userName, EndpointAddress address, ChatWindow chatWindow)
        {
            this.userName = userName;
            this.address = address;
            this.chatWindow = chatWindow;
        }

        public string UserName
        {
            get { return this.userName; }
        }

        public ChatWindow ChatWindow
        {
            get { return this.chatWindow; }
            set { this.chatWindow = value; }
        }

        public EndpointAddress Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public bool ChatWindowExists
        {
            get { return (this.chatWindow != null) && !this.chatWindow.IsDisposed; }
        }

        public override string ToString()
        {
            if (this.userName == null)
            {
                return this.address.Uri.ToString();
            }
            else
            {
                return this.userName;
            }
        }
    }
}