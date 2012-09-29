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

namespace HRApplicationServices.Contracts
{
    using System.Runtime.Serialization;

    [DataContract(Namespace = "http://contoso.com/contracts/hr")]
    public class ApplicantResume
    {
        [DataMember(IsRequired=true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
        [DataMember(IsRequired = true)]
        public string Education { get; set; }
        [DataMember(IsRequired = true)]
        public int NumReferences { get; set; }
    }
}
