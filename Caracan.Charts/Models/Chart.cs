using System;
using System.Collections.Generic;
using System.Text;

namespace Caracan.Charts.Models
{
    public class Chart
    {
        public string Name { get; set; }
        public ChartType Type { get; set; }
        public Data Data { get; set; }
        public Options Options { get; set; }
    }
}
