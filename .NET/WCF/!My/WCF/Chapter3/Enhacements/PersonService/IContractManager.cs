using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PersonService
{

	// you can remove KnownType from DataContract and use it for all implementation of service
	[ServiceKnownType(typeof(Contact))]
	[ServiceContract]
	public interface IContractManager
	{
		[OperationContract]
		// you can remove KnownType from DataContract and use it only for current method
		//[ServiceKnownType(typeof(Customer))]
		void AddContact(IContact contact);

		[OperationContract]
		IContact[] GetContacts();

		[OperationContract]
		void MyMethod(MyClass<int> obj);
	}


	public interface IContact
	{
		string FirstName { get; set; }
		string LastName { get; set; }
	}

	[DataContract]
	//[KnownType(typeof(Customer))]
	//[KnownType(typeof(Person))]
	public class Contact : IContact
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[OnSerializing]
		void OnSerializing(StreamingContext context)
		{ }

		[OnSerialized]
		void OnSerialized(StreamingContext context)
		{ }

		[OnDeserializing]
		void OnDeserializing(StreamingContext context)
		{ }

		[OnDeserialized]
		void OnDeserialized(StreamingContext context)
		{ }
	}

	// serialization order : CustomerNumber, FirstName, LastName
	[DataContract]
	public class Customer : Contact
	{
		[DataMember]
		public int CustomerNumber { get; set; }
	}

	[DataContract]
	public class Person : Contact
	{ }

	[DataContract]
	public class MyClass<T>
	{
		[DataMember]
		public T MyMember { get; set; }
	}
}
