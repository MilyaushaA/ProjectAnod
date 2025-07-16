using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ShotBlastingProfile : BaseEntity
    {
        public DateTime DateShotBlasting { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string NumberSpecification { get; set; }
        public string NumberShotGeneral { get; set; }
        public string ClientName { get; set; }// наименование заказчика
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? LenghtProfile { get; set; } //  длина профиля
        public double? WeightMeter { get; set; }// вес погонного метра
        public int? QuantityProducedProfile { get; set; } // количество произведенного профиля
        public int? BasketNumber { get; set; }//  номер корзины
        public double GeneralQuantityProducedProfile { get; set; }//вес произведенного профиля

        public int? QuantityDefectiveProfile { get; set; } // количество отбракованного профиля
        public int? CodeDefectiveProfile { get; set; }//  код брака
        public double GeneralQuantityDefectiveProfile { get; set; }//вес отбракованного профиля
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
        //public double? OpeningTheFlapFirst { get; set; }//  открытие заслонки первая
        //public double? RotationSpeedFirst { get; set; }//  скорость вращения первая
        //public double? OpeningTheFlapSecond { get; set; }// открытие заслонки вторая
        //public double? RotationSpeedSecond { get; set; }//  скорость вращения вторая
        //public double? OpeningTheFlapThird { get; set; }//  открытие заслонки третья
        //public double? RotationSpeedThird { get; set; }//  скорость вращения третья
        //public double? OpeningTheFlapFourth { get; set; }//  открытие заслонки четвертая
        //public double? RotationSpeedFourth { get; set; }//  скорость вращения четвертая
        //public double? ClampingHeight { get; set; }//  высота прижима
        //public double? SpeedTheRoller { get; set; }//  скорость
        public string  Annotation { get; set; }//  примечание
        public double OuterPerimeter { get; set; }// внешний периметр
        public bool ReadinessProfile { get; set; }// готовность
   

    }
    public class ForPivotTableShotBlastingProfile
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceShotBlastingProfile { get; set; }// количество хлыстов на дробейструе
        public double? LenghtShotBlastingProfile { get; set; }// количество  метров на дробейструе
        public double? WeightShotBlastingProfile { get; set; }//общий вес на дробейструе
        public int? AmountPieceShotBlastingProfileBrak { get; set; }// количество хлыстов на дробейструе брак
        public double? LenghtShotBlastingProfileBrak { get; set; }// количество  метров на дробейструе брак
        public double? WeightShotBlastingProfileBrak { get; set; }//  общий вес на дробейструе брак

    }
    public class ForPivotTableShotBlastingProfileTwo
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string GeneralNomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceShotBlastingProfile { get; set; }// количество хлыстов на дробейструе
        public double? LenghtShotBlastingProfile { get; set; }// количество  метров на дробейструе
        public double? WeightShotBlastingProfile { get; set; }//общий вес на дробейструе
        public int? AmountPieceShotBlastingProfileBrak { get; set; }// количество хлыстов на дробейструе брак
        public double? LenghtShotBlastingProfileBrak { get; set; }// количество  метров на дробейструе брак
        public double? WeightShotBlastingProfileBrak { get; set; }//  общий вес на дробейструе брак

    }
    public class ShotBlastingProfileReport
    {
        //public DateTime DateShotBlasting { get; set; }// дата дробейструя
        //public string Shift { get; set; }// смена
        public string EloksalNoCommercial { get; set; }// коммерческий номер
        public int LenghtProfile { get; set; }// коммерческий номер
        public int QuantityProducedProfile { get; set; }// количество  штук
        public double GeneralQuantityProducedProfile { get; set; }//общая вес
        public double GeneralAreaProducedProfile { get; set; }//общая площадь 
    }
    public class ShotBlastingProfileSummaryTable
    {
        public int Id { get; set; }
        public string NumberShotGeneral { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
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



    }

}