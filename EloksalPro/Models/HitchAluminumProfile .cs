using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class HitchAluminumProfile:BaseEntity
    {
        public DateTime DateHitch { get; set; } //  номер бары
        public string NumberHitchGeneral { get; set; }
        public int NumberBars { get; set; } //  номер бары
        public string NumberSpecification { get; set; }
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public string ColorAnod { get; set; } //  цвет покрытия
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string ClientName { get; set; }// наименование заказчика
        public double WeightMeter { get; set; }// вес погонного метра
        public int AmountPieceFact { get; set; }// количество хлыстов
        public int AmountPieceDefect { get; set; }// количество хлыстов брак
        public int LenghtFact { get; set; }// длина хлыста
        public double WeightGeneral { get; set; }// вес 
        public double WeightGeneralDefect { get; set; }// вес бракованного профиля
        public string Annotation { get; set; }// вес погонного метра
        public double GeneralAreaProducedProfile { get; set; }//площадь произведенного профиля
        public double? GeneralAreaDefectiveProfile { get; set; }//площадь отбракованного профиля
        public bool ReadinessProfile { get; set; }// готовность
        public string Employee { get; set; }

    }
    public class ForPivotTableHitchAluminumProfile
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int? AmountPieceHitchAluminumProfile { get; set; }// количество хлыстов склад
        public double? LenghtHitchAluminumProfile { get; set; }// количество  метров склад
        public double? WeightHitchAluminumProfile { get; set; }//общий вес склад
        public int? AmountPieceHitchAluminumProfileBrak { get; set; }// количество хлыстов склад брак
        public double? LenghtHitchAluminumProfileBrak { get; set; }// количество  метров склад брак
        public double? WeightHitchAluminumProfileBrak { get; set; }//  общий вес склад брак

    }
}
