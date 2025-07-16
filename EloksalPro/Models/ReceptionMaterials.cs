using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public  class ReceptionMaterials:BaseEntity
    {
        public string ClientName {get; set;}
        public string NumberSpecification { get; set; }// номер заказа
        public DateTime? DateReception { get; set; }// дата приема сырья
        public DateTime DateSpecification { get; set; }// дата cпецификации
        public double TotalSumWeight { get; set; }
        public double WeightShippedProduction { get; set; }
        public string WorkingShift { get; set; }
        public string FullName { get; set; }
        public string Annotation { get; set; }

    }
}
