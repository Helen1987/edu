using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace MvcAjaxForms.Models
{
    [Serializable]
    public class Contact
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("lastName")]
        public string LastName { get; set; }

        [XmlAttribute("firstName")]
        public string FirstName { get; set; }

        [XmlAttribute("company")]
        public string Company { get; set; }
    }
}
