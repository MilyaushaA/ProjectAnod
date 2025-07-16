using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
  public  class SpecificationEloksalProfile:BaseEntity
    {
        public string ClientName { get; set; }
        public string NumberSpecification { get; set; }
        public string NumberContract{ get; set; }
        public DateTime DateSpecification { get; set; }
        public DateTime DateContract { get; set; }
        public DateTime? DatePlan { get; set; }
        public double? GeneralWeight { get; set; }
        public string Manager { get; set; }
        public bool CalculateLabel { get; set; }

    }
    public class SpecificationEloksalProfileDif : BaseEntity
    {
      
        public string ClientName { get; set; }
        public string NumberSpecification { get; set; }
        public string NumberContract { get; set; }
        public DateTime DateSpecification { get; set; }
        public DateTime DateContract { get; set; }
        public int DifData { get; set; }
        public string Manager { get; set; }
        public bool CalculateLabel { get; set; }


    }
    public class SpecificationDataPlan 
    {
        public string ClientName { get; set; }
        public string NumberSpecification { get; set; } 
        public DateTime? DatePlan { get; set; }
        public double? GeneralWeight { get; set; }

    }
}

