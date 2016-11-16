using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MyModel
{
    [DataContract]
    public class OrderEntry
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0} \nDate:{1} ",Id,Date);
        }
    }

}
