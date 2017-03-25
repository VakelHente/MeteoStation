using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeteorologyStationApp.Models
{
    public class DataModels
    {
        public List<int> iddata { get; set; }
        public List<double> tempreture { get; set; }
        public List<double> humidity { get; set; }
        public List<double> pressure { get; set; }
        public List<int> iddevice { get; set; }
        public List<int> idregion { get; set; }
        public List<DateTime> dateTime { get; set; }
        public List<double> outdata { get; set; }
    }
}