using System;
using System.Xml;

namespace SherlockLib
{
	/// <summary>
	/// Summary description for SherlockQuotes.
	/// </summary>
	public class SherlockQuotes
	{
		private XmlDocument quoteDoc;
		private int quoteCount;

		public SherlockQuotes(string fileName)
		{
			quoteDoc = new XmlDocument();
			quoteDoc.Load(fileName);

			quoteCount = quoteDoc.DocumentElement.ChildNodes.Count;
		}

		public Quotation GetRandomQuote()
		{
			int i;
			Random x = new Random();
			i = x.Next(quoteCount-1);
			return new Quotation( quoteDoc.DocumentElement.ChildNodes[i] );
		}

	}
}
