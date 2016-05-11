using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AppoimentManager.Core
{
    [XmlRoot("historic")]
    public class Historic
    {
        private Appointment appointment;
        private string technicalCode;

        public Historic() 
        { }

        public Historic(Appointment appointment, Technical technical) 
        {
            this.appointment = appointment;
            this.technicalCode = technical.Code;
        }

        [XmlAttribute("technical-code")]
        public string TechnicalCode 
        {
            get { return this.technicalCode; }
            set { this.technicalCode = value; }
        }

        [XmlElement("appointment")]
        public Appointment Appointment 
        {
            get { return this.appointment; }
            set { this.appointment = value; }
        }
    }
}
