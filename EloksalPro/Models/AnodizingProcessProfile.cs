using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class AnodizingProcessProfile: BaseEntity
    {
        public DateTime DateAnodizingProcess { get; set; }
        public string NumberAnodizingProcess { get; set; } // номер анодирования
        public int NumberBars { get; set; } //  номер бары
        public string NumberSpecification { get; set; } // номер заказа
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public string ColorAnod { get; set; } //  цвет покрытия
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string ClientName { get; set; }// наименование заказчика
        public double WeightMeter { get; set; }// вес погонного метра
        public int AmountPieceFact { get; set; }// количество хлыстов
        public int AmountPieceDefect { get; set; }// количество бракованных хлыстов
        public int LenghtFact { get; set; }// длина хлыста
        public double WeightGeneral { get; set; }// вес погонного метра
        public double WeightGeneralDefect { get; set; }// вес погонного метра
        public string Annotation { get; set; }// вес погонного метра
        public double OuterPerimeter { get; set; }// внешний периметр
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
        public double CurrentDensity { get; set; }// плотность тока
        public double Voltage { get; set; }// напряжение 
        public double CurrentStreng { get; set; }// сила тока
        public int AnodizingTime { get; set; }// время анодирование
        public double BathTemperature { get; set; }// время анодирование
        public bool ReadinessProfile { get; set; }// готовность
        public string Employee { get; set; }
        

    }
    public class ForPivotTableAnodizingProcessProfile
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceAnodizingProcessProfile { get; set; }// количество хлыстов на анодирование
        public double? LenghtAnodizingProcessProfile { get; set; }// количество  метров на анодирование
        public double? WeightAnodizingProcessProfile { get; set; }//общий вес на анодирование
        public int? AmountPieceAnodizingProcessProfileBrak { get; set; }// количество хлыстов на анодирование брак
        public double? LenghtAnodizingProcessProfileBrak { get; set; }// количество  метров на анодирование брак
        public double? WeightAnodizingProcessProfileBrak { get; set; }//  общий вес на анодирование брак

    }
    public class ForPivotTableAnodizingProcessProfileTwo
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string GeneralNomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceAnodizingProcessProfile { get; set; }// количество хлыстов на анодирование
        public double? LenghtAnodizingProcessProfile { get; set; }// количество  метров на анодирование
        public double? WeightAnodizingProcessProfile { get; set; }//общий вес на анодирование
        public int? AmountPieceAnodizingProcessProfileBrak { get; set; }// количество хлыстов на анодирование брак
        public double? LenghtAnodizingProcessProfileBrak { get; set; }// количество  метров на анодирование брак
        public double? WeightAnodizingProcessProfileBrak { get; set; }//  общий вес на анодирование брак

    }
    public class AnodizingProcessProfileReport
    {
        //public DateTime DateShotBlasting { get; set; }// дата дробейструя
        //public string Shift { get; set; }// смена
        public string EloksalNoCommercial { get; set; }// коммерческий номер
        public int LenghtFact { get; set; }// длина хлыста
        public int NumberBars { get; set; }// количество бар
        public int AmountPieceFact { get; set; }// количество  штук
        public double GeneralAreaProducedProfile { get; set; }//общая вес
        public double WeightGeneral { get; set; }//общая площадь 
        public string ColorAnod { get; set; }
    }
    public class AnodizingProcessProfileSummaryTable
    {
        public int Id { get; set; }
        public string NumberAnodizingProcess { get; set; }
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
