﻿// ----------------------------------------------------------------------------------
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

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace AdoNetDataServices1510In1.RowCount
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class RowCountContext : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new RowCountContext object using the connection string found in the 'RowCountContext' section of the application configuration file.
        /// </summary>
        public RowCountContext() : base("name=RowCountContext", "RowCountContext")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new RowCountContext object.
        /// </summary>
        public RowCountContext(string connectionString) : base(connectionString, "RowCountContext")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new RowCountContext object.
        /// </summary>
        public RowCountContext(EntityConnection connection) : base(connection, "RowCountContext")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Product> Products
        {
            get
            {
                if ((_Products == null))
                {
                    _Products = base.CreateObjectSet<Product>("Products");
                }
                return _Products;
            }
        }
        private ObjectSet<Product> _Products;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Products EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToProducts(Product product)
        {
            base.AddObject("Products", product);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="RowCountModel", Name="Product")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Product : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Product object.
        /// </summary>
        /// <param name="productID">Initial value of the ProductID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="productNumber">Initial value of the ProductNumber property.</param>
        /// <param name="standardCost">Initial value of the StandardCost property.</param>
        /// <param name="listPrice">Initial value of the ListPrice property.</param>
        /// <param name="sellStartDate">Initial value of the SellStartDate property.</param>
        public static Product CreateProduct(global::System.Int32 productID, global::System.String name, global::System.String productNumber, global::System.Decimal standardCost, global::System.Decimal listPrice, global::System.DateTime sellStartDate)
        {
            Product product = new Product();
            product.ProductID = productID;
            product.Name = name;
            product.ProductNumber = productNumber;
            product.StandardCost = standardCost;
            product.ListPrice = listPrice;
            product.SellStartDate = sellStartDate;
            return product;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                if (_ProductID != value)
                {
                    OnProductIDChanging(value);
                    ReportPropertyChanging("ProductID");
                    _ProductID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ProductID");
                    OnProductIDChanged();
                }
            }
        }
        private global::System.Int32 _ProductID;
        partial void OnProductIDChanging(global::System.Int32 value);
        partial void OnProductIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ProductNumber
        {
            get
            {
                return _ProductNumber;
            }
            set
            {
                OnProductNumberChanging(value);
                ReportPropertyChanging("ProductNumber");
                _ProductNumber = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ProductNumber");
                OnProductNumberChanged();
            }
        }
        private global::System.String _ProductNumber;
        partial void OnProductNumberChanging(global::System.String value);
        partial void OnProductNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal StandardCost
        {
            get
            {
                return _StandardCost;
            }
            set
            {
                OnStandardCostChanging(value);
                ReportPropertyChanging("StandardCost");
                _StandardCost = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StandardCost");
                OnStandardCostChanged();
            }
        }
        private global::System.Decimal _StandardCost;
        partial void OnStandardCostChanging(global::System.Decimal value);
        partial void OnStandardCostChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal ListPrice
        {
            get
            {
                return _ListPrice;
            }
            set
            {
                OnListPriceChanging(value);
                ReportPropertyChanging("ListPrice");
                _ListPrice = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ListPrice");
                OnListPriceChanged();
            }
        }
        private global::System.Decimal _ListPrice;
        partial void OnListPriceChanging(global::System.Decimal value);
        partial void OnListPriceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime SellStartDate
        {
            get
            {
                return _SellStartDate;
            }
            set
            {
                OnSellStartDateChanging(value);
                ReportPropertyChanging("SellStartDate");
                _SellStartDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SellStartDate");
                OnSellStartDateChanged();
            }
        }
        private global::System.DateTime _SellStartDate;
        partial void OnSellStartDateChanging(global::System.DateTime value);
        partial void OnSellStartDateChanged();

        #endregion
    
    }

    #endregion
    
}
