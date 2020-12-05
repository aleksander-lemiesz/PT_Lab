﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayerSQL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Library")]
	public partial class LibraryLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomers(Customers instance);
    partial void UpdateCustomers(Customers instance);
    partial void DeleteCustomers(Customers instance);
    partial void InsertBooks(Books instance);
    partial void UpdateBooks(Books instance);
    partial void DeleteBooks(Books instance);
    #endregion
		
		public LibraryLinqDataContext() : 
				base(global::DataLayerSQL.Properties.Settings.Default.LibraryConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customers> Customers
		{
			get
			{
				return this.GetTable<Customers>();
			}
		}
		
		public System.Data.Linq.Table<BorrowedBooks> BorrowedBooks
		{
			get
			{
				return this.GetTable<BorrowedBooks>();
			}
		}
		
		public System.Data.Linq.Table<Books> Books
		{
			get
			{
				return this.GetTable<Books>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customers")]
	public partial class Customers : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private int _money;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnmoneyChanging(int value);
    partial void OnmoneyChanged();
    #endregion
		
		public Customers()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_money", DbType="Int NOT NULL")]
		public int money
		{
			get
			{
				return this._money;
			}
			set
			{
				if ((this._money != value))
				{
					this.OnmoneyChanging(value);
					this.SendPropertyChanging();
					this._money = value;
					this.SendPropertyChanged("money");
					this.OnmoneyChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BorrowedBooks")]
	public partial class BorrowedBooks
	{
		
		private int _bookId;
		
		private int _customerId;
		
		public BorrowedBooks()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bookId", DbType="Int NOT NULL")]
		public int bookId
		{
			get
			{
				return this._bookId;
			}
			set
			{
				if ((this._bookId != value))
				{
					this._bookId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_customerId", DbType="Int NOT NULL")]
		public int customerId
		{
			get
			{
				return this._customerId;
			}
			set
			{
				if ((this._customerId != value))
				{
					this._customerId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Books")]
	public partial class Books : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _title;
		
		private string _author;
		
		private string _type;
		
		private int _penaltyCost;
		
		private System.Nullable<System.DateTime> _returnDate;
		
		private System.Nullable<int> _state;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void OnauthorChanging(string value);
    partial void OnauthorChanged();
    partial void OntypeChanging(string value);
    partial void OntypeChanged();
    partial void OnpenaltyCostChanging(int value);
    partial void OnpenaltyCostChanged();
    partial void OnreturnDateChanging(System.Nullable<System.DateTime> value);
    partial void OnreturnDateChanged();
    partial void OnstateChanging(System.Nullable<int> value);
    partial void OnstateChanged();
    #endregion
		
		public Books()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_author", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string author
		{
			get
			{
				return this._author;
			}
			set
			{
				if ((this._author != value))
				{
					this.OnauthorChanging(value);
					this.SendPropertyChanging();
					this._author = value;
					this.SendPropertyChanged("author");
					this.OnauthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_penaltyCost", DbType="Int NOT NULL")]
		public int penaltyCost
		{
			get
			{
				return this._penaltyCost;
			}
			set
			{
				if ((this._penaltyCost != value))
				{
					this.OnpenaltyCostChanging(value);
					this.SendPropertyChanging();
					this._penaltyCost = value;
					this.SendPropertyChanged("penaltyCost");
					this.OnpenaltyCostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_returnDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> returnDate
		{
			get
			{
				return this._returnDate;
			}
			set
			{
				if ((this._returnDate != value))
				{
					this.OnreturnDateChanging(value);
					this.SendPropertyChanging();
					this._returnDate = value;
					this.SendPropertyChanged("returnDate");
					this.OnreturnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_state", DbType="Int")]
		public System.Nullable<int> state
		{
			get
			{
				return this._state;
			}
			set
			{
				if ((this._state != value))
				{
					this.OnstateChanging(value);
					this.SendPropertyChanging();
					this._state = value;
					this.SendPropertyChanged("state");
					this.OnstateChanged();
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