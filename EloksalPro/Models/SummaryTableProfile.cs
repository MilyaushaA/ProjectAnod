using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class SummaryTableProfile:BaseEntity
    {
        public string NumberSpecification { get; set; }
        public string NomenclatureProfile { get; set; }
        public string EloksalNoCommercial { get; set; }
        public string ClientName { get; set; }// наименование заказчика
        public int AmountPiece{ get; set; }// количество профиля
        public int LenghtProfile { get; set; } //  длина профиля
        public int LenghtProfileFact { get; set; }// длина хлыста
        public int AmountPieceFact { get; set; }// количество хлыстов
        public double WeightMeter { get; set; }// вес погонного метра

        public DateTime? DateReception { get; set; }// дата приема сырья
        public DateTime? DateShipment { get; set; }// предварительная дата отгрузки
        public DateTime DateProfileConsumptionWarehouse { get; set; }// дата отгрузки
        public int AmountPieceReceptionAccepted { get; set; }// принято количество хлыстов
        public double LenghtReceptionAccepted { get; set; }//принято количество  метров
        public double WeightReceptionAccepted { get; set; }//принято общий вес

        public int AmountPieceShotBlastingProfile { get; set; }// количество хлыстов на дробейструе
        public double LenghtShotBlastingProfile { get; set; }// количество  метров на дробейструе
        public double WeightShotBlastingProfile { get; set; }//общий вес на дробейструе
        public int AmountPieceShotBlastingProfileBrak { get; set; }// количество хлыстов на дробейструе брак
        public double LenghtShotBlastingProfileBrak { get; set; }// количество  метров на дробейструе брак
        public double WeightShotBlastingProfileBrak { get; set; }//  общий вес на дробейструе брак

        public int AmountPieceHitchAluminumProfile{ get; set; }// количество хлыстов навеска
        public double LenghtHitchAluminumProfile { get; set; }// количество  метров навеска
        public double WeightHitchAluminumProfile{ get; set; }//общий вес навеска
        public int AmountPieceHitchAluminumProfileBrak { get; set; }// количество хлыстов навеска брак
        public double LenghtHitchAluminumProfileBrak { get; set; }//количество  метров навеска брак
        public double WeightHitchAluminumProfileBrak { get; set; }//общий вес навеска брак

        public int AmountPieceAnodizingProcessProfile { get; set; }// количество хлыстов анодирование
        public double LenghtAnodizingProcessProfile { get; set; }// количество  метров анодирование
        public double WeightAnodizingProcessProfile { get; set; }//общий вес анодирование
        public int AmountPieceAnodizingProcessProfileBrak { get; set; }// количество хлыстов анодирование брак
        public double LenghtAnodizingProcessProfileBrak { get; set; }//количество  метров анодирование брак
        public double WeightAnodizingProcessProfileBrak { get; set; }//общий вес анодирование брак

        public int AmountTapeProtectiveProcessProfile { get; set; }// количество хлыстов нанесение защитной пленки
        public double LenghtTapeProtectiveProcessProfile { get; set; }// количество  метров нанесение защитной пленки
        public double WeightTapeProtectiveProcessProfile { get; set; }//общий вес нанесение защитной пленки
        public int AmountPieceTapeProtectiveProcessProfileBrak { get; set; }// количество хлыстов нанесение защитной пленки брак
        public double LenghtTapeProtectiveProcessProfileBrak { get; set; }//количество  метров нанесение защитной пленки брак
        public double WeightTapeProtectiveProcessProfileBrak { get; set; }//общий вес нанесение защитной пленки брак

        public int AmountСuttingFacingProfile { get; set; }// количество хлыстов резка
        public double LenghtСuttingFacingProfile { get; set; }// количество  метров резка
        public double WeightСuttingFacingProfile { get; set; }//общий вес резка
        public int AmountPieceСuttingFacingProfileBrak { get; set; }// количество хлыстов резка брак
        public double LenghtСuttingFacingProfileBrak { get; set; }//количество  метров резка брак
        public double WeightСuttingFacingProfileBrak { get; set; }//общий вес резка брак

        public int AmountPackingAluminumProfile { get; set; }// количество хлыстов упаковка
        public double LenghtPackingAluminumProfile { get; set; }// количество  метров упаковка
        public double WeightPackingAluminumProfile { get; set; }//общий вес упаковка
        public int AmountPiecePackingAluminumProfileBrak { get; set; }// количество хлыстов упаковка брак
        public double LenghtPackingAluminumProfileBrak { get; set; }//количество  метров упаковка брак
        public double WeightPackingAluminumProfileBrak { get; set; }//общий вес упаковка брак

        public int AmountProfileConsumptionWarehouse{ get; set; }// количество хлыстов склад
        public double LenghtProfileConsumptionWarehouse { get; set; }// количество  метров склад
        public double WeightProfileConsumptionWarehouse { get; set; }//общий вес склад
        public int AmountProfileConsumptionWarehouseBrak { get; set; }// количество хлыстов склад брак
        public double LenghtProfileConsumptionWarehouseBrak { get; set; }//количество  метров склад брак
        public double WeightProfileConsumptionWarehouseBrak { get; set; }//общий вес склад брак
        public string Annotation { get; set; }
        public SummaryTableProfile() { }
    }
    public class SummaryTableProfileCutting : BaseEntity
    {
        public string NumberSpecification { get; set; }
        public string NomenclatureProfile { get; set; }
        public string GeneralNomenclatureProfile { get; set; }
        public string EloksalNoCommercial { get; set; }
        public string ClientName { get; set; }// наименование заказчика
        public int AmountPiece { get; set; }// количество профиля
        public int LenghtProfile { get; set; } //  длина профиля
        public int LenghtProfileFact { get; set; }// длина хлыста
        public int AmountPieceFact { get; set; }// количество хлыстов
        public double WeightMeter { get; set; }// вес погонного метра

        public DateTime? DateReception { get; set; }// дата приема сырья
        public DateTime? DateShipment { get; set; }// предварительная дата отгрузки
        public DateTime DateProfileConsumptionWarehouse { get; set; }// дата отгрузки
        public int AmountPieceReceptionAccepted { get; set; }// принято количество хлыстов
        public double LenghtReceptionAccepted { get; set; }//принято количество  метров
        public double WeightReceptionAccepted { get; set; }//принято общий вес

        public int AmountPieceShotBlastingProfile { get; set; }// количество хлыстов на дробейструе
        public double LenghtShotBlastingProfile { get; set; }// количество  метров на дробейструе
        public double WeightShotBlastingProfile { get; set; }//общий вес на дробейструе
        public int AmountPieceShotBlastingProfileBrak { get; set; }// количество хлыстов на дробейструе брак
        public double LenghtShotBlastingProfileBrak { get; set; }// количество  метров на дробейструе брак
        public double WeightShotBlastingProfileBrak { get; set; }//  общий вес на дробейструе брак

        public int AmountPieceHitchAluminumProfile { get; set; }// количество хлыстов навеска
        public double LenghtHitchAluminumProfile { get; set; }// количество  метров навеска
        public double WeightHitchAluminumProfile { get; set; }//общий вес навеска
        public int AmountPieceHitchAluminumProfileBrak { get; set; }// количество хлыстов навеска брак
        public double LenghtHitchAluminumProfileBrak { get; set; }//количество  метров навеска брак
        public double WeightHitchAluminumProfileBrak { get; set; }//общий вес навеска брак

        public int AmountPieceAnodizingProcessProfile { get; set; }// количество хлыстов анодирование
        public double LenghtAnodizingProcessProfile { get; set; }// количество  метров анодирование
        public double WeightAnodizingProcessProfile { get; set; }//общий вес анодирование
        public int AmountPieceAnodizingProcessProfileBrak { get; set; }// количество хлыстов анодирование брак
        public double LenghtAnodizingProcessProfileBrak { get; set; }//количество  метров анодирование брак
        public double WeightAnodizingProcessProfileBrak { get; set; }//общий вес анодирование брак

        public int AmountTapeProtectiveProcessProfile { get; set; }// количество хлыстов нанесение защитной пленки
        public double LenghtTapeProtectiveProcessProfile { get; set; }// количество  метров нанесение защитной пленки
        public double WeightTapeProtectiveProcessProfile { get; set; }//общий вес нанесение защитной пленки
        public int AmountPieceTapeProtectiveProcessProfileBrak { get; set; }// количество хлыстов нанесение защитной пленки брак
        public double LenghtTapeProtectiveProcessProfileBrak { get; set; }//количество  метров нанесение защитной пленки брак
        public double WeightTapeProtectiveProcessProfileBrak { get; set; }//общий вес нанесение защитной пленки брак

        public int AmountСuttingFacingProfile { get; set; }// количество хлыстов резка
        public double LenghtСuttingFacingProfile { get; set; }// количество  метров резка
        public double WeightСuttingFacingProfile { get; set; }//общий вес резка
        public int AmountPieceСuttingFacingProfileBrak { get; set; }// количество хлыстов резка брак
        public double LenghtСuttingFacingProfileBrak { get; set; }//количество  метров резка брак
        public double WeightСuttingFacingProfileBrak { get; set; }//общий вес резка брак

        public int AmountPackingAluminumProfile { get; set; }// количество хлыстов упаковка
        public double LenghtPackingAluminumProfile { get; set; }// количество  метров упаковка
        public double WeightPackingAluminumProfile { get; set; }//общий вес упаковка
        public int AmountPiecePackingAluminumProfileBrak { get; set; }// количество хлыстов упаковка брак
        public double LenghtPackingAluminumProfileBrak { get; set; }//количество  метров упаковка брак
        public double WeightPackingAluminumProfileBrak { get; set; }//общий вес упаковка брак

        public int AmountProfileConsumptionWarehouse { get; set; }// количество хлыстов склад
        public double LenghtProfileConsumptionWarehouse { get; set; }// количество  метров склад
        public double WeightProfileConsumptionWarehouse { get; set; }//общий вес склад
        public int AmountProfileConsumptionWarehouseBrak { get; set; }// количество хлыстов склад брак
        public double LenghtProfileConsumptionWarehouseBrak { get; set; }//количество  метров склад брак
        public double WeightProfileConsumptionWarehouseBrak { get; set; }//общий вес склад брак
        public string Annotation { get; set; }
      
    }
}
