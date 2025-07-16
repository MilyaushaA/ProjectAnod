using EloksalPro.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class SpecificationAllDescription: BaseEntity
    {
        ProfileCardRepository reposProfile = new ProfileCardRepository();

        public string NumberSpecification { get; set; }
        public string NomenclatureProfile { get; set; }
        public string EloksalNoCommercial { get; set; }
        public double WeightMeter { get; set; }// вес погонного метра
        public double OuterPerimeter { get; set; }// внешний периметр
        public double AmountPiece { get; set; }
        public double AmountPMetr { get; set; }
        public double AmountKg { get; set; }
        public double PriceKg { get; set; }
        public double PricePiece { get; set; }
        public double PricePMetr { get; set; }
        public double PriceProfileArea { get; set; }
        public int LenghtProfileMustBe { get; set; }
        public int AmountPieceMustBe { get; set; }
        public int LenghtProfileFact { get; set; }
        public int LenghtProfile { get; set; }
        public int LenghtProfileTwo { get; set; }
        public int AmountPieceFact { get; set; }
        public double AmountPieceTwo { get; set; }
        public double TotalSum { get; set; }
        public string NumberContract { get; set; }
        public bool ChoiceKg { get; set; }
        public bool ChoicePiece { get; set; }
        public bool ChoicePMetr { get; set; }
        public string Annotation { get; set; }
        public IEnumerable<DetailReceptionMaterials> DetailReceptionMaterials { get; set; } = new List<DetailReceptionMaterials>();

        public double TotalSumWeight
        {
            get
            {
               if (ChoicePiece == true && ChoicePMetr == false)
                    return Math.Round((AmountPieceMustBe * CalculatePricePiece),2, MidpointRounding.AwayFromZero);
               else if (ChoicePMetr == true && ChoicePiece == false)
                    return Math.Round((AmountPMetrChange * CalculatePMetr), 2,MidpointRounding.AwayFromZero);
               else 
                    return Math.Round((AmountKgChange * CalculatePriceKg), 2, MidpointRounding.AwayFromZero);
            }
        }
        public double AmountKgChange
        { 
        get
            { return Math.Round(reposProfile.GetByWeightProfile(NomenclatureProfile) * AmountPieceMustBe * LenghtProfileMustBe / 1000000,2); }
        }
        public double AmountPMetrChange
        {
        get { return Math.Round(Convert.ToDouble(AmountPieceMustBe) * LenghtProfileMustBe / 1000,2); }
        }

        public double SumProfileArea
        {
            get { return Math.Round((reposProfile.GetByOuterPerimetrProfile(NomenclatureProfile) * AmountPieceMustBe * LenghtProfileMustBe / 1000000)* PriceProfileArea, 2); }
        }

        public double CalculatePriceKg
        {
            get { return Math.Round(Convert.ToDouble(PriceProfileArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightMeter)), 2); }
        }
        public double CalculatePMetr
        {
            get { return Math.Round(Convert.ToDouble(CalculatePriceKg) * Convert.ToDouble(WeightMeter) / 1000, 2); }
        }
        public double CalculatePricePiece
        {
            get { return Math.Round(Convert.ToDouble(CalculatePMetr) * LenghtProfileFact / 1000, 2);}
        }
    }
    public class DifferenceData
    {
        public string NumberSpecification { get; set; }
        public int LengthDifference { get; set; }
        public int AmountDifference { get; set; }
    }
    public class DifferenceDataAll
    {
        public string NumberSpecification { get; set; }
        public int LengthAmountDifference { get; set; }
    }
    public class ForPivotTableSpecification
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string NomenclatureProfile { get; set; }// номер номенклатуры
        public string EloksalNoCommercial { get; set; }// номер профиля клиента
        public double AmountPiece { get; set; } // количество профиля
        public int AmountPieceFact { get; set; }// количество хлыстов фактическая
        public int LenghtProfileFact { get; set; }// длина хлыста фактическая
        public string Annotation { get; set; }
    }
    public class ForPivotTableSpecificationTwo
    {
        public string NumberSpecification { get; set; }// номер спецификации
        public string GeneralNomenclatureProfile { get; set; }// номер номенклатуры
        public string EloksalNoCommercial { get; set; }// номер профиля клиента
        public double AmountPiece { get; set; } // количество профиля
        public int AmountPieceFact { get; set; }// количество хлыстов фактическая
        public int LenghtProfileFact { get; set; }// длина хлыста фактическая
        public string Annotation { get; set; }
    }
    public class SpecificationForScore
    {
        public string NomenclatureProfile { get; set; }
        public string UnitProfile { get; set; }//единица измерения
        public double AmountProfile { get; set; }// количество 
        public double PriceProfile { get; set; }// количество 
        public double TotalSumProfile { get; set; }// количество 
    }
}
