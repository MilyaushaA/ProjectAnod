using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public  class СuttingFacingGeneralProfile:BaseEntity
    {
        public DateTime Date { get; set; }
        public string Shift { get; set; }// смена
        public string Annotation { get; set; }
        public string Employee { get; set; }
        public string NumberСuttingFacing { get; set; }
        public double GeneralQuantityProducedProfileBefore { get; set; }
        public double GeneralQuantityProducedProfileAfter { get; set; }
        public double GeneralQuantityProducedProfileDefect { get; set; }
        public double GeneralWeightTechnologicalWaste { get; set; } //  вес технологического отхода
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
    }
}
