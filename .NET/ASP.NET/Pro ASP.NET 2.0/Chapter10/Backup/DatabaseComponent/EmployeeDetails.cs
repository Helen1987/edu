using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseComponent
{
	public class EmployeeDetails
	{
		private int employeeID;
		private string firstName;
		private string lastName;
		private string titleOfCourtesy;

		public int EmployeeID
		{
			get {return employeeID;}
			set {employeeID = value;}
		}
		public string FirstName
		{
			get {return firstName;}
			set {firstName = value;}
		}
		public string LastName
		{
			get {return lastName;}
			set {lastName = value;}
		}
		public string TitleOfCourtesy
		{
			get {return titleOfCourtesy;}
			set {titleOfCourtesy = value;}
		}

		public EmployeeDetails(int employeeID, string firstName, string lastName,
			string titleOfCourtesy)
		{
			this.employeeID = employeeID;
			this.firstName = firstName;
			this.lastName = lastName;
			this.titleOfCourtesy = titleOfCourtesy;
		}

		public EmployeeDetails(){}
	}

}
