using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AppoimentManager.Core
{
    [XmlRoot("appointment")]
    public class Appointment
    {
        private DateTime date = DateTime.Now;
       
        private List<Service> services;
        private string technicalCode;

        public Appointment(DateTime time, List<Service> services , string technicalCode) 
        {
            this.date = time;
            this.services = services;
            this.technicalCode = technicalCode;
        }
                
        [XmlAttribute("date")]
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        [XmlAttribute("services")]
        public List<Service> Services
        {
            get { return this.services; }
            set { this.services = value; }
        }

    }
}
