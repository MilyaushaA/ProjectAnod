using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ProfileConsumptionWarehouseGeneral : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Shift { get; set; }// смена
        public string Annotation { get; set; }
        public string Employee { get; set; }
        public string ClientName { get; set; }
        public string NumberProfileConsumptionWarehouse { get; set; }
        public double WeightProducedProfile { get; set; }
        public double WeightDefectedProfile { get; set; }
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
   
    }
}
