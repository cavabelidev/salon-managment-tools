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
        private int price;
        private AppointmentType type = AppointmentType.WithoutAcrylic;
        private string technicalCode;

        public Appointment(DateTime time, int price, AppointmentType type, string technicalCode) 
        {
            this.time = time;
            this.price = price;
            this.type = type;
            this.technicalCode = technicalCode;
        }
                
        [XmlAttribute("Price")]
        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        [XmlAttribute("Date")]
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        [XmlAttribute("type")]
        public AppointmentType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

    }
}
