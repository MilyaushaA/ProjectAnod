using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class PackingAluminumProfileGeneral:BaseEntity
    {
        public DateTime Date { get; set; }
        public string Shift { get; set; }// смена
        public string Annotation { get; set; }
        public string Employee { get; set; }
        public string NumberPackingAluminumProfile { get; set; }// номер упаковки
        public double WeightProducedProfile { get; set; }//вес  профиля 
        public double WeightDefectedProfile { get; set; }//вес  профиля брак
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
   
    }

}
