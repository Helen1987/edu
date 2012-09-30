using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceDemarcation
{
	[ServiceContract(SessionMode=SessionMode.Required)]
	public interface IOrderManager
	{
		[OperationContract]
		void SetCustomerId(int customerId);

		[OperationContract(IsInitiating=false)]
		void AddItem(int itemId);

		[OperationContract(IsInitiating=false)]
		decimal GetTotal();

		[OperationContract(IsInitiating = false, IsTerminating = true)]
		bool ProcessOrders();
	}
}
