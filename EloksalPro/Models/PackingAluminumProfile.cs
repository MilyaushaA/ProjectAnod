using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class PackingAluminumProfile : BaseEntity
    {
        public DateTime DatePackingAluminumProfile { get; set; }
        public string NumberSpecification { get; set; }// номер заказа
        public string NumberPackingAluminumProfile { get; set; }// номер упаковки
        public string BasketNumber { get; set; }//  номер паллета
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public string ClientName { get; set; }// наименование заказчика
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public double? WeightMeter { get; set; }// вес погонного метра
        public double OuterPerimeter { get; set; }// вес погонного метра
        public int? LenghtProfile { get; set; } //  длина профиля 
        public int? QuantityProducedProfile { get; set; } // количество хлыстов в паллете
        public double WeightProducedProfile { get; set; }//вес  профиля 
        public int? QuantityDefectedProfile { get; set; } // количество хлыстов брак
        public double WeightDefectedProfile { get; set; }//вес  профиля  брак
        public string Annotation { get; set; }// примечание
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
        public bool ReadinessProfile { get; set; }// готовность
     
    }
    public class ForPivotTablePackingAluminumProfile
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPiecePackingAluminumProfile { get; set; }// количество хлыстов на упаковка
        public double? LenghtPackingAluminumProfile { get; set; }// количество  метров на упаковке
        public double? WeightPackingAluminumProfile { get; set; }//общий вес на упаковке
        public int? AmountPiecePackingAluminumProfileBrak { get; set; }// количество хлыстов на упаковке брак
        public double? LenghtPackingAluminumProfileBrak { get; set; }// количество  метров на упаковке брак
        public double? WeightPackingAluminumProfileBrak { get; set; }//  общий вес на упаковке брак

    }
    public class PackingAluminumProfileReport
    {
        //public DateTime DateShotBlasting { get; set; }// дата дробейструя
        //public string Shift { get; set; }// смена
        public string EloksalNoCommercial { get; set; }// коммерческий номер
        public int LenghtProfile { get; set; }// коммерческий номер
        public int QuantityProducedProfile { get; set; }// количество  штук
        public double WeightProducedProfile { get; set; }//общая вес
        public double GeneralAreaProducedProfile { get; set; }//общая площадь 
    }
    public class PackingAluminumProfileSummaryTable
    {
        public int Id { get; set; }
        public string NumberPackingAluminumProfile { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
        public string BasketNumber { get; set; }//  номер паллета
        public string ClientName { get; set; }
        public string NumberSpecification { get; set; }
        public string EloksalNoCommercial { get; set; }
        public string NomenclatureProfile { get; set; }
        public double LenghtProfile { get; set; }
        public double WeightMeter { get; set; }
        public double OuterPerimeter { get; set; }
        public int QuantityProducedProfile { get; set; }
        public double GeneralQuantityProducedProfile { get; set; }
        public double GeneralAreaProducedProfile { get; set; }
        public int QuantityDefectiveProfile { get; set; }
        public double GeneralQuantityDefectiveProfile { get; set; }
        public double GeneralAreaDefectiveProfile { get; set; }
    }
        //public override bool Equals(object obj)
        //{
        //    ShotBlastingProfileSummaryTable table = new ShotBlastingProfileSummaryTable();
        //    if (obj != table)
        //        return false;

        //    return 
        //           ClientName == table.ClientName &&
        //           NomenclatureProfile == table.NomenclatureProfile &&
        //           WeightMeter.Equals(table.WeightMeter) &&
        //           OuterPerimeter.Equals(table.OuterPerimeter);
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(Date, Shift, ClientName, NomenclatureProfile, LenghtProfile, WeightMeter, OuterPerimeter);
        //}
        public class PackingAluminumProfileForShipment
    {
            
            public string NumberSpecification { get; set; }// номер заказа
            public string BasketNumber { get; set; }//  номер паллета
            public string NomenclatureProfile { get; set; }//  номенклатура профиля
            public string ClientName { get; set; }// наименование заказчика
            public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
            public double? WeightMeter { get; set; }// вес погонного метра
            public double OuterPerimeter { get; set; }
            public int? LenghtProfile { get; set; } //  длина профиля 
            public int? QuantityProducedProfile { get; set; } // количество хлыстов в паллете
            public double WeightProducedProfile { get; set; }//вес  профиля 
            public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
            public string Annotation { get; set; }// примечание            
            public bool PalletSelection { get; set; }// готовность

        }
    }
