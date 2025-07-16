using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class СuttingFacingProfile:BaseEntity
    {
        public DateTime DateСuttingFacing { get; set; }
        public string NumberSpecification { get; set; }
        public string NumberСuttingFacingGeneral { get; set; }
        public string ClientName { get; set; }// наименование заказчика
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public double? WeightMeter { get; set; }// вес погонного метра
        public int? LenghtProfileBefore { get; set; } //  длина профиля до распила
        public int? QuantityProducedProfileBefore { get; set; } // количество хлыстов до распила
        public double WeightProducedProfileBefore { get; set; }//вес  профиля до распила
        public int? LenghtProfileAfter { get; set; } //  длина профиля после распила
        public int? QuantityProducedProfileAfter { get; set; } // количество хлыстов после  распила
        public double WeightProducedProfileAfter { get; set; }//вес  профиля после  распила
        public int? QuantityDefectedProfile { get; set; } // количество бракованного профиля
        public double WeightDefectedProfile { get; set; }//вес бракванного профиля
        public double WeightTechnologicalWaste { get; set; }//  вес технологического отхода
        public int? BasketNumber { get; set; }//  номер корзины
        public string Annotation { get; set; }// примечание
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
        public bool ReadinessProfile { get; set; }// готовность
        public string GeneralNomenclatureProfile { get; set; }//  номенклатура профиля

    }
    public class ForPivotTableСuttingFacingProfile
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceСuttingFacingProfile { get; set; }// количество хлыстов на дробейструе
        public double? LenghtСuttingFacingProfile { get; set; }// количество  метров на дробейструе
        public double? WeightСuttingFacingProfile { get; set; }//общий вес на дробейструе
        public int? AmountPieceСuttingFacingProfileBrak { get; set; }// количество хлыстов на дробейструе брак
        public double? LenghtСuttingFacingProfileBrak { get; set; }// количество  метров на дробейструе брак
        public double? WeightСuttingFacingProfileBrak { get; set; }//  общий вес на дробейструе брак

    }
    public class ForPivotTableСuttingFacingProfileTwo
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public string GeneralNomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceСuttingFacingProfile { get; set; }// количество хлыстов на дробейструе
        public double? LenghtСuttingFacingProfile { get; set; }// количество  метров на дробейструе
        public double? WeightСuttingFacingProfile { get; set; }//общий вес на дробейструе
        public int? AmountPieceСuttingFacingProfileBrak { get; set; }// количество хлыстов на дробейструе брак
        public double? LenghtСuttingFacingProfileBrak { get; set; }// количество  метров на дробейструе брак
        public double? WeightСuttingFacingProfileBrak { get; set; }//  общий вес на дробейструе брак

    }
    public class СuttingFacingProfileReport
    {
        //public DateTime DateShotBlasting { get; set; }// дата дробейструя
        //public string Shift { get; set; }// смена
        public string EloksalNoCommercial { get; set; }// коммерческий номер
        public string ClientName { get; set; }// наименование заказчика
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public string NumberSpecification { get; set; }
        public double? WeightMeter { get; set; }// вес погонного метра
        public int? LenghtProfileBefore { get; set; } //  длина профиля до распила
        public int? QuantityProducedProfileBefore { get; set; } // количество хлыстов до распила
        public double WeightProducedProfileBefore { get; set; }//вес  профиля до распила
        public int LenghtProfileAfter { get; set; }// коммерческий номер
        public int QuantityProducedProfileAfter { get; set; }// количество  штук
        public double WeightProducedProfileAfter { get; set; }//общая вес
        public double WeightTechnologicalWaste { get; set; }//общая площадь 
    }
    public class СuttingFacingProfileSummaryTable
    {
        public int Id { get; set; }
        public string NumberСuttingFacing { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
        public string ClientName { get; set; }
        public string NumberSpecification { get; set; }
        public string EloksalNoCommercial { get; set; }
        public string NomenclatureProfile { get; set; }
        public double WeightMeter { get; set; }
        public double OuterPerimeter { get; set; }
        public int LenghtProfileBefore { get; set; } //  длина профиля до распила
        public int QuantityProducedProfileBefore { get; set; } // количество хлыстов до распила
        public double WeightProducedProfileBefore { get; set; }//вес  профиля до распила
        public int LenghtProfileAfter { get; set; } //  длина профиля после распила
        public int QuantityProducedProfileAfter { get; set; } // количество хлыстов после  распила
        public double WeightProducedProfileAfter { get; set; }//вес  профиля после  распила
        public int QuantityDefectedProfile { get; set; } // количество бракованного профиля
        public double WeightDefectedProfile { get; set; }//вес бракованного профиля
        public double WeightTechnologicalWaste { get; set; }//  вес технологического отхода
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
    }
}
