using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityDataProvider.BusinessLogic.Dto
{
    public class AggregatedElDataDto
    {
        public string Region { get; set; }
        public double PPlus { get; set; }
        public double PMinus { get; set; }
    }
}
