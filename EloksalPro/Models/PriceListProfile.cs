using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
  public  class PriceListProfile:BaseEntity
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string ProfileCode { get; set; }
        public double PriceProfileKg { get; set; }
        public double PriceProfileMetr { get; set; }
        public double PriceProfileArea { get; set; }

    }
}
