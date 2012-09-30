using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceDemarcation
{
	public class OrderManager : IOrderManager
	{
		public void SetCustomerId(int customerId) { }

		public void AddItem(int itemId) { }

		public decimal GetTotal() { return 0; }

		public bool ProcessOrders() { return true; }
	}
}
