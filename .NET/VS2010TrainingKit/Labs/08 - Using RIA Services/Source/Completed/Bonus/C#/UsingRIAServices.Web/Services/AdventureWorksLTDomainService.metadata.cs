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


using UsingRIAServices.Web.Services;

namespace UsingRIAServices.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies CustomerMetadata as the class
    // that carries additional metadata for the Customer class.
    [MetadataTypeAttribute(typeof(Customer.CustomerMetadata))]
    public partial class Customer
    {

        // This class allows you to attach custom attributes to properties
        // of the Customer class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CustomerMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CustomerMetadata()
            {
            }

            public string CompanyName { get; set; }

            [Key]
            public int CustomerID { get; set; }

            public string EmailAddress { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string MiddleName { get; set; }

            public DateTime ModifiedDate { get; set; }

            public bool NameStyle { get; set; }

            public string PasswordHash { get; set; }

            public string PasswordSalt { get; set; }

            public string Phone { get; set; }

            public Guid rowguid { get; set; }

            public EntityCollection<SalesOrderHeader> SalesOrderHeaders { get; set; }

            public string SalesPerson { get; set; }

            public string Suffix { get; set; }

            public string Title { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies SalesOrderHeaderMetadata as the class
    // that carries additional metadata for the SalesOrderHeader class.
    [MetadataTypeAttribute(typeof(SalesOrderHeader.SalesOrderHeaderMetadata))]
    public partial class SalesOrderHeader
    {

        // This class allows you to attach custom attributes to properties
        // of the SalesOrderHeader class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class SalesOrderHeaderMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private SalesOrderHeaderMetadata()
            {
            }

            public string AccountNumber { get; set; }

            public Nullable<int> BillToAddressID { get; set; }

            [Required]
            public string Comment { get; set; }

            public string CreditCardApprovalCode { get; set; }

            public Customer Customer { get; set; }

            public int CustomerID { get; set; }

            public DateTime DueDate { get; set; }

            public decimal Freight { get; set; }

            public DateTime ModifiedDate { get; set; }

            public bool OnlineOrderFlag { get; set; }

            [CustomValidation(typeof(DateValidator),"ValidateDate")]
            public DateTime OrderDate { get; set; }

            public string PurchaseOrderNumber { get; set; }

            public byte RevisionNumber { get; set; }

            public Guid rowguid { get; set; }

            public EntityCollection<SalesOrderDetail> SalesOrderDetails { get; set; }

            [Key]
            public int SalesOrderID { get; set; }

            public string SalesOrderNumber { get; set; }

            [CustomValidation(typeof(DateValidator), "ValidateDate")]
            public Nullable<DateTime> ShipDate { get; set; }

            public string ShipMethod { get; set; }

            public Nullable<int> ShipToAddressID { get; set; }

            public byte Status { get; set; }

            public decimal SubTotal { get; set; }

            public decimal TaxAmt { get; set; }

            public decimal TotalDue { get; set; }

            [Exclude]
            public EntityReference<Customer> CustomerReference { get; set; }
        }
    }
}
