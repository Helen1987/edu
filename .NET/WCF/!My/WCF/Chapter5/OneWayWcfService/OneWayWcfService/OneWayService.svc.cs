using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OneWayWcfService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	class OneWayService : IOneWayService
	{

		public void MyMethodWithError()
		{
			throw new Exception();
		}

		public void MyMethodWithoutError() { }
	}
}
