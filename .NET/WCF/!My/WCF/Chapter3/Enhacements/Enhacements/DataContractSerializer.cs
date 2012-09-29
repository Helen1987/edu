using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;

namespace Enhacements
{
	public class DataContractSerializer<T> : XmlObjectSerializer
	{
		DataContractSerializer _dataContractSerializer;

		public DataContractSerializer()
		{
			_dataContractSerializer = new DataContractSerializer(typeof(T));
		}

		public new T ReadObject(Stream stream)
		{
			return (T)_dataContractSerializer.ReadObject(stream);
		}

		public new T ReadObject(XmlReader reader)
		{
			return (T)_dataContractSerializer.ReadObject(reader);
		}

		public void WriteObject(Stream stream, T graph)
		{
			_dataContractSerializer.WriteObject(stream, graph);
		}

		public void WriteObject(XmlWriter writer, T graph)
		{
			_dataContractSerializer.WriteObject(writer, graph);
		}

	}
}
