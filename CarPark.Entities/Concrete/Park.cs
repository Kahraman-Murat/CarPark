using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Entities.Concrete
{
    public class Park : BaseModel
    {
        public string Name { get; set; }
        //public string Latitude { get; set; }
        //public string Longitude { get; set; }
        public string[] PhoneNumbers { get; set; }
        public Address Address { get; set; }
        public string[] Personels { get; set; }
        public string WebSite { get; set; }
        public string[] EmailAddresses { get; set; }
        public ICollection<WorkingDay> WorkingDays { get; set; }
        public ICollection<FloorInformation> Floors { get; set; }
    }
}
