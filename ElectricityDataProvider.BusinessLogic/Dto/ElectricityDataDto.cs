using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityDataProvider.BusinessLogic.Dto
{
    public class ElectricityDataDto
    {
        public string Region { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public double? PPlus { get; set; }
        public double? PMinus { get; set; }
        public DateTimeOffset Time { get; set; }

    }
}
