using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Xml;

/// <summary>
/// Summary description for EmployeesServiceCompatible
/// </summary>
[WebService(Namespace = "http://www.apress.com/ProASP.NET/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class EmployeesServiceCompatible : System.Web.Services.WebService
{
	[WebMethod(Description = "Returns the full list of employees.")]
	[SoapDocumentMethod(ResponseElementName="EmployeeList")]
	[return: XmlArray("EmployeeList")]
	public EmployeeDetails[] GetEmployee()
	{
		return new EmployeeDetails[]{new EmployeeDetails()};
	}

	[WebMethod(Description = "Returns the full list of employees.")]
	public EmployeeDetailsCustom GetCustomEmployee()
	{
		return new EmployeeDetailsCustom(101, "Joe", "Dabiak");
	}

	[XmlType("Employee", Namespace = "http://www.apress.com/ProASP.NET/")]
	public class EmployeeDetails
	{
		[XmlElement("EmployeeID")]
		public int ID;
		public string FirstName;
		public string LastName;
		public string TitleOfCourtesy;	
	}


	public class EmployeeDetailsCustom : IXmlSerializable 
	{
		public int ID;
		public string FirstName;
		public string LastName;

		public EmployeeDetailsCustom(int employeeID, string firstName, string lastName)
		{
			this.ID = employeeID;
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public EmployeeDetailsCustom(){}

		private string ns = "http://www.apress.com/ProASP.NET/CustomEmployeeDetails";
		void IXmlSerializable.WriteXml(XmlWriter w)
		{
			w.WriteStartElement("Employee", ns);
			
			w.WriteStartElement("Name", ns);
			w.WriteElementString("First", ns, FirstName);
			w.WriteElementString("Last", ns, LastName);
			w.WriteEndElement();
			
			w.WriteElementString("ID", ns, ID.ToString());
            w.WriteEndElement();
		}

		 void IXmlSerializable.ReadXml(XmlReader r)
		{
			r.MoveToContent();
			r.ReadStartElement("Employee");
			
			 r.ReadStartElement("Name");
			 FirstName = r.ReadElementString("First", ns);
			 LastName = r.ReadElementString("Last", ns);
			r.ReadEndElement();
			r.MoveToContent();
			 ID = Int32.Parse(r.ReadElementString("ID", ns));
			 r.ReadEndElement();
			 
		}

		System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}
	}
}

