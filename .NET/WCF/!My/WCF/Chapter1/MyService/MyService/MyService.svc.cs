using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyService
{
	public class MyService : IMyContract, IMyOtherContract
	{
		public string MyMethod(string text)
		{
			return "Hello world";
		}

		string IMyContract.MyOtherMethod(string text)
		{
			return string.Format("private string {0}", text);
		}

		public string MyOtherMethod(string text)
		{
			return "Other method " + ((IMyContract)this).MyOtherMethod(text);
		}
	}
}
