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
    using Microsoft.Samples.Discovery.Contracts;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class ChatService : ISimpleChatService
    {
        private SimpleChat simpleChat;

        public ChatService(SimpleChat simpleChat)
        {
            this.simpleChat = simpleChat;
        }

        public void ProcessSimpleMessage(ChatMessage chatMessage)
        {
            if (chatMessage == null || string.IsNullOrEmpty(chatMessage.UserName) || chatMessage.UserUri == null)
            {
                return;
            }

            PeerUser peerUserObject = this.simpleChat.GetUser(chatMessage.UserUri);
            if (peerUserObject == null)
            {
                // User is not in internal store, update container and show message               
                peerUserObject = new PeerUser(chatMessage.UserName, new EndpointAddress(chatMessage.UserUri));
                this.simpleChat.AddUser(peerUserObject);

                peerUserObject.ChatWindow = new ChatWindow(this.simpleChat, peerUserObject);                
            }

            if (peerUserObject.ChatWindowExists)
            {
                // User is in internal store and has an open chat window
                peerUserObject.ChatWindow.DisplayMessage(chatMessage);
                ShowChatWindow(peerUserObject);
            }
            else
            {
                // User is in internal store but no chat window is open                
                peerUserObject.ChatWindow = new ChatWindow(this.simpleChat, peerUserObject);
                peerUserObject.ChatWindow.DisplayMessage(chatMessage);
                ShowChatWindow(peerUserObject);
            }
        }

        private static void ShowChatWindow(PeerUser peerUserObject)
        {
            NativeMethods.SetForegroundWindow(peerUserObject.ChatWindow.Handle);
        }        
    }
}