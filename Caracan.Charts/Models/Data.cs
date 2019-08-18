using System;
using System.Collections.Generic;
using System.Text;

namespace Caracan.Charts.Models
{
    public class Data
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<List<double>> Series { get; set; }
    }
}
