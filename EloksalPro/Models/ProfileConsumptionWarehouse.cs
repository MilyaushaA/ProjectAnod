using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class ProfileConsumptionWarehouse:BaseEntity
    {
        public DateTime DateProfileConsumptionWarehouse { get; set; }
        public string NumberSpecification { get; set; }
        public string NumberProfileConsumptionWarehouse { get; set; }
        public string BasketNumber { get; set; }//  номер паллета
        public string ClientName { get; set; }// наименование заказчика
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public double? WeightMeter { get; set; }// вес погонного метра
        public int? QuantityProducedProfile{ get; set; } // количество хлыстов 
        public double WeightProducedProfile { get; set; }//вес  профиля 
        public int? QuantityDefectedProfile { get; set; } // количество бракованных хлыстов 
        public double WeightDefectedProfile { get; set; }//вес бракованного профиля 
        public int? LenghtProfile { get; set; } //  длина профиля 
        public double OuterPerimeter { get; set; }// внешний периметр  
        public string Annotation { get; set; }// примечание
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
        public bool ReadinessProfile { get; set; }// готовность
    }
    public class ForPivotTableProfileConsumptionWarehouse
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceProfileConsumptionWarehouse { get; set; }// количество хлыстов склад
        public double? LenghtProfileConsumptionWarehouse { get; set; }// количество  метров склад
        public double? WeightProfileConsumptionWarehouse { get; set; }//общий вес склад
        public int? AmountPieceProfileConsumptionWarehouseBrak { get; set; }// количество хлыстов склад брак
        public double? LenghtProfileConsumptionWarehouseBrak { get; set; }// количество  метров склад брак
        public double? WeightProfileConsumptionWarehouseBrak { get; set; }//  общий вес склад брак

    }
}
