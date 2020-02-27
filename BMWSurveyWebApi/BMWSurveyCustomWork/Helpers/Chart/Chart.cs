using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMWSurvey
{
    public class Chart
    {
        public string ChartType { get; set; }
        public string ChartTtitle { get; set; }
        public string[] Data { get; set; }
        public string[] labels { get; set; }
    }
}
