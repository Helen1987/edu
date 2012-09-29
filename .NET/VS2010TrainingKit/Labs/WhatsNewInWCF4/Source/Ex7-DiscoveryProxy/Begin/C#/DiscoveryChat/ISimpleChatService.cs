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

namespace Microsoft.Samples.Discovery.Contracts
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract(ConfigurationName = "ISimpleChatService", Name = "SimpleChat", Namespace = "http://sample.microsoft.com/wcf4")]
    public interface ISimpleChatService
    {
        [OperationContract(IsOneWay = true,
            Action = "http://sample.microsoft.com/wcf4/SendSimpleMsgAction")]
        void ProcessSimpleMessage(ChatMessage message);
    }

    // This datacontract defines the basic message that the SimpleChat Service needs to implement
    [DataContract(Name = "ChatMessage", Namespace = "http://sample.microsoft.com/wcf4/ChatClient")]
    public class ChatMessage
    {
        private string userName;
        private string message;
        private Uri userUri;

        public ChatMessage(string userName, string message, Uri userUri)
        {
            this.userName = userName;
            this.message = message;
            this.userUri = userUri;
        }

        [DataMember]
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        [DataMember]
        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        [DataMember]
        public Uri UserUri
        {
            get { return this.userUri; }
            set { this.userUri = value; }
        }
    }
}