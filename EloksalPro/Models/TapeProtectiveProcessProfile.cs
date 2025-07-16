using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class TapeProtectiveProcessProfile:BaseEntity
    {
        public DateTime DateTapeProtective { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string NumberSpecification { get; set; }
        public string NumberTapeProtectiveGeneral { get; set; }
        public string ClientName { get; set; }// наименование заказчика
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? LenghtProfileFact { get; set; } //  длина профиля
        public double? WeightMeter { get; set; }// вес погонного метра
        public double OuterPerimeter { get; set; }// внешний периметр
        public int? QuantityProducedProfile { get; set; } // количество произведенного профиля
        public int? QuantityDefectedProfile { get; set; } // количество бракованного профиля
        public int? BasketNumber { get; set; }//  номер корзины
        public double GeneralQuantityProducedProfile { get; set; }//вес произведенного профиля
        public double GeneralQuantityDefectedProfile { get; set; }//вес бракованного профиля
        public int  WidthTapeProtectiveProfile { get; set; }//  ширина защитной пленки профиля
        public string Annotation { get; set; }//  ширина защитной пленки профиля
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
        public double QuantityRunningMeter { get; set; }
        public bool ReadinessProfile { get; set; }// готовность
        public string Employee { get; set; }
        public double ConsumptionProtectiveFilm { get; set; }

    }
    public class ForPivotTableTapeProtectiveProcessProfile
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceTapeProtectiveProcessProfile { get; set; }// количество хлыстов наклейка
        public double? LenghtTapeProtectiveProcessProfile { get; set; }// количество  метров наклейка
        public double? WeightTapeProtectiveProcessProfile { get; set; }//общий вес наклейка
        public int? AmountPieceTapeProtectiveProcessProfileBrak { get; set; }// количество хлыстов наклейка брак
        public double? LenghtTapeProtectiveProcessProfileBrak { get; set; }// количество  метров наклейка брак
        public double? WeightTapeProtectiveProcessProfileBrak { get; set; }//  общий вес наклейка брак

    }
    public class TapeProtectiveProcessProfileReport
    {
        //public DateTime DateShotBlasting { get; set; }// дата дробейструя
        //public string Shift { get; set; }// смена
        public string EloksalNoCommercial { get; set; }// коммерческий номер
        public int LenghtProfileFact { get; set; }// коммерческий номер
        public int QuantityProducedProfile { get; set; }// количество  штук
        public double GeneralQuantityProducedProfile { get; set; }//общая вес
        public double GeneralAreaProducedProfile { get; set; }//общая площадь 
    }
    public class TapeProtectiveProcessProfileSummaryTable
    {
        public int Id { get; set; }
        public string NumberTapeProtectiveGeneral { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }
        public string ClientName { get; set; }
        public string NumberSpecification { get; set; }
        public string EloksalNoCommercial { get; set; }
        public string NomenclatureProfile { get; set; }
        public double LenghtProfile { get; set; }
        public double WeightMeter { get; set; }
        public double OuterPerimeter { get; set; }
        public int QuantityProducedProfile { get; set; }// количество произведенного профиля
        public double GeneralQuantityProducedProfile { get; set; }// общий вес произведенного профиля
        public double GeneralAreaProducedProfile { get; set; }// общиая площадь произведенного профиля
        public int QuantityDefectiveProfile { get; set; }
        public double GeneralQuantityDefectiveProfile { get; set; }
        public double GeneralAreaDefectiveProfile { get; set; }
        public double QuantityRunningMeter { get; set; } // количество погонных метров
        public double ConsumptionProtectiveFilm { get; set; }//расход защитной пленки
    }
    }
