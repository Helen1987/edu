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

#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.20916.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebFormsSampleApp.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AdventureWorksLT")]
	public partial class AdventureWorksDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProductCategory(ProductCategory instance);
    partial void UpdateProductCategory(ProductCategory instance);
    partial void DeleteProductCategory(ProductCategory instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    #endregion
		
		public AdventureWorksDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorksLTConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdventureWorksDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ProductCategory> ProductCategories
		{
			get
			{
				return this.GetTable<ProductCategory>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="SalesLT.ProductCategory")]
	public partial class ProductCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProductCategoryID;
		
		private System.Nullable<int> _ParentProductCategoryID;
		
		private string _Name;
		
		private System.Guid _rowguid;
		
		private System.DateTime _ModifiedDate;
		
		private EntitySet<ProductCategory> _ProductCategories;
		
		private EntitySet<Product> _Products;
		
		private EntityRef<ProductCategory> _ProductCategory1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProductCategoryIDChanging(int value);
    partial void OnProductCategoryIDChanged();
    partial void OnParentProductCategoryIDChanging(System.Nullable<int> value);
    partial void OnParentProductCategoryIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public ProductCategory()
		{
			this._ProductCategories = new EntitySet<ProductCategory>(new Action<ProductCategory>(this.attach_ProductCategories), new Action<ProductCategory>(this.detach_ProductCategories));
			this._Products = new EntitySet<Product>(new Action<Product>(this.attach_Products), new Action<Product>(this.detach_Products));
			this._ProductCategory1 = default(EntityRef<ProductCategory>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductCategoryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProductCategoryID
		{
			get
			{
				return this._ProductCategoryID;
			}
			set
			{
				if ((this._ProductCategoryID != value))
				{
					this.OnProductCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._ProductCategoryID = value;
					this.SendPropertyChanged("ProductCategoryID");
					this.OnProductCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentProductCategoryID", DbType="Int")]
		public System.Nullable<int> ParentProductCategoryID
		{
			get
			{
				return this._ParentProductCategoryID;
			}
			set
			{
				if ((this._ParentProductCategoryID != value))
				{
					if (this._ProductCategory1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParentProductCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._ParentProductCategoryID = value;
					this.SendPropertyChanged("ParentProductCategoryID");
					this.OnParentProductCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductCategory_ProductCategory", Storage="_ProductCategories", ThisKey="ProductCategoryID", OtherKey="ParentProductCategoryID")]
		public EntitySet<ProductCategory> ProductCategories
		{
			get
			{
				return this._ProductCategories;
			}
			set
			{
				this._ProductCategories.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductCategory_Product", Storage="_Products", ThisKey="ProductCategoryID", OtherKey="ProductCategoryID")]
		public EntitySet<Product> Products
		{
			get
			{
				return this._Products;
			}
			set
			{
				this._Products.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductCategory_ProductCategory", Storage="_ProductCategory1", ThisKey="ParentProductCategoryID", OtherKey="ProductCategoryID", IsForeignKey=true)]
		public ProductCategory ProductCategory1
		{
			get
			{
				return this._ProductCategory1.Entity;
			}
			set
			{
				ProductCategory previousValue = this._ProductCategory1.Entity;
				if (((previousValue != value) 
							|| (this._ProductCategory1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProductCategory1.Entity = null;
						previousValue.ProductCategories.Remove(this);
					}
					this._ProductCategory1.Entity = value;
					if ((value != null))
					{
						value.ProductCategories.Add(this);
						this._ParentProductCategoryID = value.ProductCategoryID;
					}
					else
					{
						this._ParentProductCategoryID = default(Nullable<int>);
					}
					this.SendPropertyChanged("ProductCategory1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ProductCategories(ProductCategory entity)
		{
			this.SendPropertyChanging();
			entity.ProductCategory1 = this;
		}
		
		private void detach_ProductCategories(ProductCategory entity)
		{
			this.SendPropertyChanging();
			entity.ProductCategory1 = null;
		}
		
		private void attach_Products(Product entity)
		{
			this.SendPropertyChanging();
			entity.ProductCategory = this;
		}
		
		private void detach_Products(Product entity)
		{
			this.SendPropertyChanging();
			entity.ProductCategory = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="SalesLT.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ProductID;
		
		private string _Name;
		
		private string _ProductNumber;
		
		private string _Color;
		
		private decimal _StandardCost;
		
		private decimal _ListPrice;
		
		private string _Size;
		
		private System.Nullable<decimal> _Weight;
		
		private System.Nullable<int> _ProductCategoryID;
		
		private System.Nullable<int> _ProductModelID;
		
		private System.DateTime _SellStartDate;
		
		private System.Nullable<System.DateTime> _SellEndDate;
		
		private System.Nullable<System.DateTime> _DiscontinuedDate;
		
		private System.Data.Linq.Binary _ThumbNailPhoto;
		
		private string _ThumbnailPhotoFileName;
		
		private System.Guid _rowguid;
		
		private System.DateTime _ModifiedDate;
		
		private EntityRef<ProductCategory> _ProductCategory;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnProductIDChanging(int value);
    partial void OnProductIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnProductNumberChanging(string value);
    partial void OnProductNumberChanged();
    partial void OnColorChanging(string value);
    partial void OnColorChanged();
    partial void OnStandardCostChanging(decimal value);
    partial void OnStandardCostChanged();
    partial void OnListPriceChanging(decimal value);
    partial void OnListPriceChanged();
    partial void OnSizeChanging(string value);
    partial void OnSizeChanged();
    partial void OnWeightChanging(System.Nullable<decimal> value);
    partial void OnWeightChanged();
    partial void OnProductCategoryIDChanging(System.Nullable<int> value);
    partial void OnProductCategoryIDChanged();
    partial void OnProductModelIDChanging(System.Nullable<int> value);
    partial void OnProductModelIDChanged();
    partial void OnSellStartDateChanging(System.DateTime value);
    partial void OnSellStartDateChanged();
    partial void OnSellEndDateChanging(System.Nullable<System.DateTime> value);
    partial void OnSellEndDateChanged();
    partial void OnDiscontinuedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnDiscontinuedDateChanged();
    partial void OnThumbNailPhotoChanging(System.Data.Linq.Binary value);
    partial void OnThumbNailPhotoChanged();
    partial void OnThumbnailPhotoFileNameChanging(string value);
    partial void OnThumbnailPhotoFileNameChanged();
    partial void OnrowguidChanging(System.Guid value);
    partial void OnrowguidChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    #endregion
		
		public Product()
		{
			this._ProductCategory = default(EntityRef<ProductCategory>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				if ((this._ProductID != value))
				{
					this.OnProductIDChanging(value);
					this.SendPropertyChanging();
					this._ProductID = value;
					this.SendPropertyChanged("ProductID");
					this.OnProductIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductNumber", DbType="NVarChar(25) NOT NULL", CanBeNull=false)]
		public string ProductNumber
		{
			get
			{
				return this._ProductNumber;
			}
			set
			{
				if ((this._ProductNumber != value))
				{
					this.OnProductNumberChanging(value);
					this.SendPropertyChanging();
					this._ProductNumber = value;
					this.SendPropertyChanged("ProductNumber");
					this.OnProductNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Color", DbType="NVarChar(15)")]
		public string Color
		{
			get
			{
				return this._Color;
			}
			set
			{
				if ((this._Color != value))
				{
					this.OnColorChanging(value);
					this.SendPropertyChanging();
					this._Color = value;
					this.SendPropertyChanged("Color");
					this.OnColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StandardCost", DbType="Money NOT NULL")]
		public decimal StandardCost
		{
			get
			{
				return this._StandardCost;
			}
			set
			{
				if ((this._StandardCost != value))
				{
					this.OnStandardCostChanging(value);
					this.SendPropertyChanging();
					this._StandardCost = value;
					this.SendPropertyChanged("StandardCost");
					this.OnStandardCostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ListPrice", DbType="Money NOT NULL")]
		public decimal ListPrice
		{
			get
			{
				return this._ListPrice;
			}
			set
			{
				if ((this._ListPrice != value))
				{
					this.OnListPriceChanging(value);
					this.SendPropertyChanging();
					this._ListPrice = value;
					this.SendPropertyChanged("ListPrice");
					this.OnListPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Size", DbType="NVarChar(5)")]
		public string Size
		{
			get
			{
				return this._Size;
			}
			set
			{
				if ((this._Size != value))
				{
					this.OnSizeChanging(value);
					this.SendPropertyChanging();
					this._Size = value;
					this.SendPropertyChanged("Size");
					this.OnSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weight", DbType="Decimal(8,2)")]
		public System.Nullable<decimal> Weight
		{
			get
			{
				return this._Weight;
			}
			set
			{
				if ((this._Weight != value))
				{
					this.OnWeightChanging(value);
					this.SendPropertyChanging();
					this._Weight = value;
					this.SendPropertyChanged("Weight");
					this.OnWeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductCategoryID", DbType="Int")]
		public System.Nullable<int> ProductCategoryID
		{
			get
			{
				return this._ProductCategoryID;
			}
			set
			{
				if ((this._ProductCategoryID != value))
				{
					if (this._ProductCategory.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProductCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._ProductCategoryID = value;
					this.SendPropertyChanged("ProductCategoryID");
					this.OnProductCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductModelID", DbType="Int")]
		public System.Nullable<int> ProductModelID
		{
			get
			{
				return this._ProductModelID;
			}
			set
			{
				if ((this._ProductModelID != value))
				{
					this.OnProductModelIDChanging(value);
					this.SendPropertyChanging();
					this._ProductModelID = value;
					this.SendPropertyChanged("ProductModelID");
					this.OnProductModelIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellStartDate", DbType="DateTime NOT NULL")]
		public System.DateTime SellStartDate
		{
			get
			{
				return this._SellStartDate;
			}
			set
			{
				if ((this._SellStartDate != value))
				{
					this.OnSellStartDateChanging(value);
					this.SendPropertyChanging();
					this._SellStartDate = value;
					this.SendPropertyChanged("SellStartDate");
					this.OnSellStartDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SellEndDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> SellEndDate
		{
			get
			{
				return this._SellEndDate;
			}
			set
			{
				if ((this._SellEndDate != value))
				{
					this.OnSellEndDateChanging(value);
					this.SendPropertyChanging();
					this._SellEndDate = value;
					this.SendPropertyChanged("SellEndDate");
					this.OnSellEndDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiscontinuedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> DiscontinuedDate
		{
			get
			{
				return this._DiscontinuedDate;
			}
			set
			{
				if ((this._DiscontinuedDate != value))
				{
					this.OnDiscontinuedDateChanging(value);
					this.SendPropertyChanging();
					this._DiscontinuedDate = value;
					this.SendPropertyChanged("DiscontinuedDate");
					this.OnDiscontinuedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThumbNailPhoto", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary ThumbNailPhoto
		{
			get
			{
				return this._ThumbNailPhoto;
			}
			set
			{
				if ((this._ThumbNailPhoto != value))
				{
					this.OnThumbNailPhotoChanging(value);
					this.SendPropertyChanging();
					this._ThumbNailPhoto = value;
					this.SendPropertyChanged("ThumbNailPhoto");
					this.OnThumbNailPhotoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThumbnailPhotoFileName", DbType="NVarChar(50)")]
		public string ThumbnailPhotoFileName
		{
			get
			{
				return this._ThumbnailPhotoFileName;
			}
			set
			{
				if ((this._ThumbnailPhotoFileName != value))
				{
					this.OnThumbnailPhotoFileNameChanging(value);
					this.SendPropertyChanging();
					this._ThumbnailPhotoFileName = value;
					this.SendPropertyChanged("ThumbnailPhotoFileName");
					this.OnThumbnailPhotoFileNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rowguid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid rowguid
		{
			get
			{
				return this._rowguid;
			}
			set
			{
				if ((this._rowguid != value))
				{
					this.OnrowguidChanging(value);
					this.SendPropertyChanging();
					this._rowguid = value;
					this.SendPropertyChanged("rowguid");
					this.OnrowguidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ProductCategory_Product", Storage="_ProductCategory", ThisKey="ProductCategoryID", OtherKey="ProductCategoryID", IsForeignKey=true)]
		public ProductCategory ProductCategory
		{
			get
			{
				return this._ProductCategory.Entity;
			}
			set
			{
				ProductCategory previousValue = this._ProductCategory.Entity;
				if (((previousValue != value) 
							|| (this._ProductCategory.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ProductCategory.Entity = null;
						previousValue.Products.Remove(this);
					}
					this._ProductCategory.Entity = value;
					if ((value != null))
					{
						value.Products.Add(this);
						this._ProductCategoryID = value.ProductCategoryID;
					}
					else
					{
						this._ProductCategoryID = default(Nullable<int>);
					}
					this.SendPropertyChanged("ProductCategory");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591