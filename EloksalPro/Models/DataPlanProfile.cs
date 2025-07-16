using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class DataPlanProfile:BaseEntity
    {
        public string ClientName { get; set; }
        public string NumberSpecification { get; set; }
        public DateTime? DatePlan { get; set; }
        public double? GeneralWeight { get; set; }
        public double? AllGeneralWeight { get; set; }
    }


    public class DataPlanProfileGenaral
    {
        public DateTime? DatePlan { get; set; }
        public double? GeneralWeight { get; set; }
    }
}
