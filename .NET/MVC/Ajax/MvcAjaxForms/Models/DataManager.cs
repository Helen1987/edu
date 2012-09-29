using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcAjaxForms.Models
{
    public static class DataManager
    {

        private const string dataFile = @"~\App_Data\Contacts.xml";

        public static List<Contact> Load()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(dataFile), FileMode.Open);
            List<Contact> lst = (List<Contact>)xml.Deserialize(fs);
            fs.Close();
            return lst;
        }

        public static void Save(List<Contact> obj)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(dataFile), FileMode.Create);
            xml.Serialize(fs, obj);
            fs.Close();
        }

    }
}
