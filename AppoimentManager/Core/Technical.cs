using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AppoimentManager.Core
{
    [XmlRoot("technical")]
    public class Technical
    {
        private string name;
        private string lastName;
        private int appointments;
        private int total;
        private string code;

        [XmlElement("code")]
        public string Code
        {
            get { return code; }
            set { this.code = value; }
        }

        [XmlElement("name")]
        public string Name
        {
            get { return name; }
            set { this.name = value; }
        }

        [XmlElement("last-name")]
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
    }
}
