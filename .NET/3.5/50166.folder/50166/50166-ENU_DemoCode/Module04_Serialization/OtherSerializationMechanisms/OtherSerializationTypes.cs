using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml;
using System.Xml.Serialization;
using XmlConfigurationFramework;

namespace OtherSerializationMechanisms
{
    /// <summary>
    /// This demo is an overview of other serialization mechanisms which are part
    /// of the .NET framework, including XML serialization, data-contract serialization
    /// (DCS) and SoapFormatter serialization (deprecated).
    /// </summary>
    class OtherSerializationTypes
    {
        static void Main(string[] args)
        {
            SoapFormatterSerialization();
            XmlSerialization();
            DataContractSerialization();
            ConfigFrameworkDemo();
        }

        /// <summary>
        /// Creates a sample order with several embedded items.
        /// </summary>
        private static PurchaseOrder CreateOrder()
        {
            PurchaseOrder order = new PurchaseOrder
            {
                CustomerName = "Kate",
                Items = new Item[]
                {
                    new Item { Name = "Chair", Price = 50m, Discount = 10.0f },
                    new Item { Name = "Cushion", Price = 3m, Discount = 25.0f },
                    new Item { Name = "Sofa", Price = 600m, Discount = 5.0f }
                }
            };
            order.Amount = order.Items.Sum(i => i.Price * (decimal)((100 - i.Discount) / 100.0f));
            return order;
        }

        /// <summary>
        /// The SoapFormatter type is deprecated, but it shows an alternative to 
        /// the .NET BinaryFormatter while still implementing the same interface.
        /// SoapFormatter has significant limitations, e.g. it does not support
        /// generics, and therefore its use is strongly discouraged.
        /// 
        /// It also resides in a separate assembly: System.Runtime.Serialization.Formatters.Soap
        /// </summary>
        private static void SoapFormatterSerialization()
        {
            PurchaseOrder order = CreateOrder();

            //Serialize the order to a file.  The syntax is identical to the
            //BinaryFormatter because the Serialize and Deserialize methods come
            //from the common Formatter interface.
            SoapFormatter soapFormatter = new SoapFormatter();
            FileStream file = File.Create("order.soap");
            soapFormatter.Serialize(file, order);
            file.Close();

            //SOAP output is human-readable, so we can dump it to the console.
            Console.WriteLine(File.ReadAllText("order.soap"));

            //Deserialize the order from the file.  The syntax is identical
            //to the BinaryFormatter.
            file = File.Open("order.soap", FileMode.Open);
            order = (PurchaseOrder)soapFormatter.Deserialize(file);
            file.Close();
        }

        /// <summary>
        /// XML serialization is a mechanism completely different from .NET runtime
        /// serialization.  It works on acyclic object graphs only, and serializes
        /// only public read-write properties.  Unlike the .NET serialization we have
        /// seen which uses reflection to serialize objects, the XmlSerializer uses
        /// code generation techniques to create (once) the code that will be used for
        /// serialization and deserialization of a known type.  This is the reason why
        /// the XmlSerializer takes a type in its constructor - that's the type that
        /// will have a serialization assembly built for its serialization and
        /// deserialization purposes.
        /// 
        /// There are ways to customize XML serialization using attributes placed on
        /// properties of the serialized type.  For example, the [XmlAttribute] attribute
        /// indicates that a property should be serialized as an XML attribute and not
        /// an XML element.  A couple of example attributes have been placed on the Item
        /// and PurchaseOrder classes.
        /// 
        /// There is also a way to optimize XML serialization by generating the serialization
        /// assembly in advance, using a utility called SGEN.  This is outside the scope
        /// of this demo.
        /// </summary>
        private static void XmlSerialization()
        {
            PurchaseOrder order = CreateOrder();

            //The XmlSerializer wants to know which type it will be serializing today.
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PurchaseOrder));
            //Serialize to the console:
            xmlSerializer.Serialize(Console.Out, order);

            //Serialize to a file:
            StreamWriter writer = File.CreateText("order.xml");
            xmlSerializer.Serialize(writer, order);
            writer.Close();

            //Deserialize from a file:
            StreamReader reader = File.OpenText("order.xml");
            order = (PurchaseOrder)xmlSerializer.Deserialize(reader);
        }

        /// <summary>
        /// Data-contract serialization is a mechanism used by Windows Communication
        /// Foundation (WCF) for data serialization between the distributed parties.
        /// It serializes to an XML-like format by default, but there are also flavors
        /// like the NetDataContractSerializer which perform efficient binary serialization.
        /// Unlike the XmlSerializer, DCS can serialize private fields and cyclic
        /// object graphs.  Its behavior can be customized using attributes placed on
        /// the serialized types, including the [DataContract] and [DataMember] attributes.
        /// 
        /// The DataContractSerializer resides in the System.Runtime.Serialization
        /// assembly which is new in .NET 3.0 (introduced together with WCF).
        /// </summary>
        private static void DataContractSerialization()
        {
            PurchaseOrder order = CreateOrder();
            //The DCS wants to know which type it will be serializing.
            DataContractSerializer dcs = new DataContractSerializer(typeof(PurchaseOrder));

            //Serialize to the console:
            XmlWriter writer = XmlTextWriter.Create(Console.Out);
            dcs.WriteObject(writer, order);
            writer.Close();

            //Serialize to a file:
            writer = XmlTextWriter.Create("order.dcs");
            dcs.WriteObject(writer, order);
            writer.Close();

            //Deserialize from the file:
            XmlReader reader = XmlTextReader.Create("order.dcs");
            order = (PurchaseOrder)dcs.ReadObject(reader);
            reader.Close();
        }

        /// <summary>
        /// Demonstrates the use of the simple configuration framework
        /// based on XML serialization that is part of this solution, in the
        /// XmlConfigurationFramework project.
        /// 
        /// The use of this framework for realistic configuration storage needs
        /// is discouraged: The .NET framework features excellent support for XML
        /// configuration files in the System.Configuration namespace.
        /// The framework introduced in this demo exists for demonstration
        /// purposes only.
        /// </summary>
        private static void ConfigFrameworkDemo()
        {
            ApplicationConfiguration config = ApplicationConfiguration.Load();
            config.AddSection("ConnectionStrings", "ConnectionStrings.xml", new ConnectionStrings());
            config.AddSection("AllowedUsers", "AllowedUsers.xml", new AllowedUsers());

            AllowedUsers users = config.GetSection<AllowedUsers>("AllowedUsers");
            users.Users.AddRange(new string[] { "Joe", "Jack", "Jane" });
            Configurator<AllowedUsers>.Save(users, "AllowedUsers.xml");

            config.Save();
        }
    }

    [Serializable]  //.NET serialization
    [DataContract]  //Data-contract serialization
    public class Item
    {
        [DataMember]            //Data-contract serialization
        [XmlAttribute("name")]  //XML serialization
        public string Name { get; set; }
        [DataMember]            //Data-contract serialization
        public decimal Price { get; set; }
        [DataMember]            //Data-contract serialization
        public float Discount { get; set; }
    }

    [Serializable]  //.NET serialization
    [DataContract]  //Data-contract serialization
    public class PurchaseOrder
    {
        [DataMember]                //Data-contract serialization
        public decimal Amount { get; set; }
        [DataMember]                //Data-contract serialization
        [XmlAttribute("customer")]  //XML serialization
        public string CustomerName { get; set; }
        [DataMember]                //Data-contract serialization
        [XmlArray("OrderedItems")]  //XML serialization
        public Item[] Items { get; set; }
    }
}
