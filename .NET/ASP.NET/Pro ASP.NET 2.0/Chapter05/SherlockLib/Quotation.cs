using System;
using System.Xml;

namespace SherlockLib
{
	/// <summary>
	/// Summary description for Quotation.
	/// </summary>
	public class Quotation
	{
		private string qsource;
		private string date;
		private string quotation;
		
		public Quotation(XmlNode quoteNode)
		{
			if ( (quoteNode.SelectSingleNode("source")) != null)
				qsource = quoteNode.SelectSingleNode("source").InnerText;
			if ( (quoteNode.Attributes.GetNamedItem("date")) != null)
				date = quoteNode.Attributes.GetNamedItem("date").Value;
			quotation = quoteNode.FirstChild.InnerText;
		}

		public string Source
		{
			get 
			{
				return qsource;

			}
			set 
			{
				qsource = value;
			}
		}

		public string Date
		{
			get 
			{
				return date;
			}
			set 
			{
				date = value;
			}
		}

		public string QuotationText
		{
			get 
			{
				return quotation;
			}
			set 
			{
				quotation = value;
			}
		}
	}
}
