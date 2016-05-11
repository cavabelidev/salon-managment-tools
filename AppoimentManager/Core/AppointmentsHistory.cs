using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace AppoimentManager.Core
{
    [XmlRoot("appointments-history")]
    public class AppointmentsHistory
    {
        private List<Historic> histories;

        public AppointmentsHistory() { }

        [XmlArrayItem(typeof(Historic))]
        public List<Historic> Histories 
        {
            get { return this.histories; }
            set { this.histories = value; }
        }
    }
}
