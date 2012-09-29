using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PersonService
{
	public class ContractManager : IContractManager
	{

		public void AddContact(IContact contact)
		{
			throw new NotImplementedException();
		}

		public IContact[] GetContacts()
		{
			return new Contact[1];
		}

		public void MyMethod(MyClass<int> obj)
		{

		}
	}
}
