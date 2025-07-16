using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
  public class DetailReceptionMaterials:BaseEntity
    {
        public DateTime? DateReception { get; set; }// дата приема сырья
        public DateTime? DateShipment { get; set; }//предварительная дата отгрузки сырья
        public string NumberSpecification { get; set; }// номер заказа
        public string EloksalNoCommercial { get; set; }// номенклатура заказчика
        public string NomenclatureProfile { get; set; }// номенклатура профиля Eloksal
        public string ClientName { get; set; }// заказчик
        public int AmountPieceFact { get; set; }// количество хлыстов
        public int LenghtFact { get; set; }// длина хлыста
        public double WeightMeter { get; set; }
       
        public string WorkingShift { get; set; }
        public string FullName { get; set; }
        public string Annotation { get; set; }
        public int SpecificationAllDescriptionsId { get; set; }
        public bool ReadinessProfile { get; set; }// готовность

        public double TotalSumWeight
        {
            get { return Math.Round(((Convert.ToDouble(LenghtFact)) * AmountPieceFact * WeightMeter) / 1000000,2); }
        }

        public SpecificationAllDescription SpecificationAllDescriptionNavigation { get; set; }


    }
    public class ForPivotTableDetailReceptionMaterials
    {
        public DateTime? DateReception { get; set; }// дата приема сырья
        public DateTime? DateShipment { get; set; }
        public string NumberSpecification { get; set; }// номер заказа
        public string NomenclatureProfile { get; set; }// номенклатура профиля Eloksal
        public int AmountPieceReceptionAccepted { get; set; }// принято количество хлыстов
        public double LenghtReceptionAccepted { get; set; }//принято количество  метров
        public double WeightReceptionAccepted { get; set; }//принято общий вес
    }
    public class ForPivotTableDetailReceptionMaterialsTwo
    {
        public DateTime? DateReception { get; set; }// дата приема сырья
        public DateTime? DateShipment { get; set; }
        public string NumberSpecification { get; set; }// номер заказа
        public string GeneralNomenclatureProfile { get; set; }// номенклатура профиля Eloksal
        public int AmountPieceReceptionAccepted { get; set; }// принято количество хлыстов
        public double LenghtReceptionAccepted { get; set; }//принято количество  метров
        public double WeightReceptionAccepted { get; set; }//принято общий вес
    }
}
