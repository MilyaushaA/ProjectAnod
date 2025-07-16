using EloksalPro.EfStructures;
using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EloksalPro.Repositories
{
    public class SpecificationAllDescriptionRepository : BaseRepo<SpecificationAllDescription>, ISpecificationAllDescriptionRepository
    {
        public int MaxNumberSpecification()
        {
            if (DateTime.Now.ToString("dd") != "1")
            {
                List<SpecificationAllDescription> list = GetByAllEntity();
                if (list.Count() > 0)
                {
                    List<string> numberList = list.Select(p => p.NumberSpecification).ToList();
                    List<int> eloksalNoListInt = new List<int>();

                    foreach (string item in numberList)
                    {
                        int ind = item.Length - 4;
                        // вырезаем последний символ
                        string text = item.Remove(ind);
                        int textNum = Convert.ToInt32(text);
                        eloksalNoListInt.Add(textNum);
                    }
                    int eloksalNoIntMax = eloksalNoListInt.Max();
                    return eloksalNoIntMax;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public int MaxNumberContract()
        {
            if (DateTime.Now.ToString("dd") != "1" && DateTime.Now.ToString("mm") != "1")
            {
                List<SpecificationAllDescription> list = GetByAllEntity();
                if (list.Count() > 0)
                {
                    List<string> numberList = list.Select(p => p.NumberContract).ToList();
                    List<int> eloksalNoListInt = new List<int>();

                    foreach (string item in numberList)
                    {
                        int ind = item.Length - 2;
                        // вырезаем последний символ
                        string text = item.Remove(ind);
                        int textNum = Convert.ToInt32(text);
                        eloksalNoListInt.Add(textNum);
                    }
                    int eloksalNoIntMax = eloksalNoListInt.Max();
                    return eloksalNoIntMax;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }
        public ObservableCollection<SpecificationAllDescription> GetByAllEntityObservableCollection(string numberSpecification)
        {
            ObservableCollection<SpecificationAllDescription> list = new ObservableCollection<SpecificationAllDescription>();
            var inventory = Table.Where(p => p.NumberSpecification == numberSpecification.TrimEnd()).ToList();
            list = new ObservableCollection<SpecificationAllDescription>(inventory);
            return list;
        }
        public List<SpecificationAllDescription> GetByAllEntityListCollection(string numberSpecification)
        {
            List<SpecificationAllDescription> list = new List<SpecificationAllDescription>();
            var inventory = Table.Where(p => p.NumberSpecification == numberSpecification.TrimEnd()).ToList();
            list = new List<SpecificationAllDescription>(inventory);
            return list;
        }
        public bool CheckValue(string numSpecification, string nomenclature, int lenght)
        {
            bool checkValue = Table.Any(p => p.NumberSpecification == numSpecification && p.NomenclatureProfile == nomenclature && p.LenghtProfileMustBe==lenght);
            return checkValue;
        }
        public void UpdateSpecificationAllDescription(string numberSpecification,string numberProfile ,int amount, int lenght)
        {
            SpecificationAllDescription myEntity = Table.FirstOrDefault(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile== numberProfile);
            if (myEntity != null)
            {
               
                myEntity.LenghtProfileFact = lenght;
                myEntity.AmountPieceFact = amount;
                Context.SaveChanges();
            }
        }
        public List<DifferenceDataAll> DifferenceData()
        {
            ObservableCollection<SpecificationAllDescription> list = new ObservableCollection<SpecificationAllDescription>();
            List<DifferenceData> inventory = Table.GroupBy(s => s.NumberSpecification)
                               .Select(g => new DifferenceData
                               {
                                   NumberSpecification = g.Key,
                                   LengthDifference = g.Sum(s => s.LenghtProfileFact - s.LenghtProfileMustBe),
                                   AmountDifference = g.Sum(s => s.AmountPieceFact - s.AmountPieceMustBe)

                               }).ToList();
            List<DifferenceDataAll> inventorySum = inventory.Select(g => new DifferenceDataAll
            {
                NumberSpecification = g.NumberSpecification,
                LengthAmountDifference = g.LengthDifference + g.AmountDifference
            }).ToList();
            return inventorySum;
        }
        public void UpdateSpecificationAllDescriptionAmountTeor(int id, int amount, int amountFact, int lenght, double count, double amountKg, double amountPMetr,double totalSum, int lenghtFact,
                                                                 bool choiceKg,bool choicePiece, bool choicePMetr, double priceKg, double pricePMetr, double pricePiece,double priceProfileArea,
                                                                 double amountTwo)
        {
            SpecificationAllDescription myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {

                myEntity.AmountPiece = count;
                myEntity.AmountKg = amountKg;
                myEntity.AmountPMetr = amountPMetr;
                myEntity.LenghtProfileMustBe = lenght;
                myEntity.AmountPieceMustBe = amount;
                myEntity.AmountPieceFact= amountFact;
                myEntity.TotalSum = totalSum;
                myEntity.LenghtProfileFact= lenghtFact;
                myEntity.ChoiceKg = choiceKg;
                myEntity.ChoicePiece = choicePiece;
                myEntity.ChoicePMetr = choicePMetr;
                myEntity.PriceKg = priceKg;
                myEntity.PricePMetr = pricePMetr;
                myEntity.PricePiece = pricePiece;
                myEntity.PriceProfileArea = priceProfileArea;
                myEntity.AmountPieceTwo = amountTwo;
                Context.SaveChanges();
            }
        }
        public List<ForPivotTableSpecification> GetForPivotTableSpecification()
        {
            SpecificationEloksalProfileRepository repos = new SpecificationEloksalProfileRepository();
            List<SpecificationEloksalProfile> listSpecificationEloksalProfile = repos.GetListSpecifications();
            List<SpecificationAllDescription> listSpecification = Table.ToList();
            var results = from a in listSpecification
                          join b in listSpecificationEloksalProfile  on a.NumberSpecification equals b.NumberSpecification
                    group a by new { a.NumberSpecification, a.NomenclatureProfile, a.EloksalNoCommercial,a.LenghtProfileFact, a.Annotation} into g
                    select new ForPivotTableSpecification
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        EloksalNoCommercial = g.Key.EloksalNoCommercial,
                        LenghtProfileFact = g.Key.LenghtProfileFact,
                        Annotation = g.Key.Annotation,
                        AmountPiece = g.Sum(p => p.AmountPiece),
                        AmountPieceFact = g.Sum(p => p.AmountPieceFact)};
            List<ForPivotTableSpecification> list = results.AsEnumerable().ToList();
            return list;

        }
        public List<ForPivotTableSpecificationTwo> GetForPivotTableSpecificationTwo()
        {
            //List<ForPivotTableSpecificationTwo> list = new List<ForPivotTableSpecificationTwo>();
            //list = Table
            //        .GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile, p.EloksalNoCommercial, p.LenghtProfileFact, p.Annotation })
            //        .Select(g => new ForPivotTableSpecificationTwo
            //        {
            //            NumberSpecification = g.Key.NumberSpecification,
            //            GeneralNomenclatureProfile = g.Key.NomenclatureProfile,
            //            EloksalNoCommercial = g.Key.EloksalNoCommercial,
            //            LenghtProfileFact = g.Key.LenghtProfileFact,
            //            Annotation = g.Key.Annotation,
            //            AmountPiece = g.Sum(p => p.AmountPiece),
            //            AmountPieceFact = g.Sum(p => p.AmountPieceFact)
            //        }).ToList();
            //return list;

            SpecificationEloksalProfileRepository repos = new SpecificationEloksalProfileRepository();
            List<SpecificationEloksalProfile> listSpecificationEloksalProfile = repos.GetListSpecifications();
            List<SpecificationAllDescription> listSpecification = Table.ToList();
            var results = from a in listSpecification
                          join b in listSpecificationEloksalProfile on a.NumberSpecification equals b.NumberSpecification
                          group a by new { a.NumberSpecification, a.NomenclatureProfile, a.EloksalNoCommercial, a.LenghtProfileFact, a.Annotation } into g
                          select new ForPivotTableSpecificationTwo
                          {
                              NumberSpecification = g.Key.NumberSpecification,
                              GeneralNomenclatureProfile = g.Key.NomenclatureProfile,
                              EloksalNoCommercial = g.Key.EloksalNoCommercial,
                              LenghtProfileFact = g.Key.LenghtProfileFact,
                              Annotation = g.Key.Annotation,
                              AmountPiece = g.Sum(p => p.AmountPiece),
                              AmountPieceFact = g.Sum(p => p.AmountPieceFact)
                          };
            List<ForPivotTableSpecificationTwo> list = results.AsEnumerable().ToList();
            return list;
        }
        public double GetTotalWeight(string numberSpecification)
        {
            var entity = Table
                .GroupBy(p => p.NumberSpecification)
                .Select(g => new
                {
                    Kg = g.Sum(x => x.AmountKg),
                    NumberSpecification = g.Key
                }).FirstOrDefault(p => p.NumberSpecification == numberSpecification);
            return entity.Kg;
        }

        public List<SpecificationForScore> GetByAllEntityListCollectionForScore(string numberSpecification)
        {
            List<SpecificationForScore> list = new List<SpecificationForScore>();
            var inventory = Table.Where(p => p.NumberSpecification == numberSpecification.TrimEnd())
                .Select(g => new SpecificationForScore
                {
                    NomenclatureProfile = "Анодирование профиля"+" "+g.EloksalNoCommercial+" " + g.NomenclatureProfile,
                    UnitProfile = g.ChoiceKg == true && g.ChoicePMetr == false && g.ChoicePiece == false ? "кг":
                             g.ChoiceKg == false && g.ChoicePMetr == false && g.ChoicePiece == true ? "шт":
                             g.ChoiceKg == false && g.ChoicePMetr == true && g.ChoicePiece == false? "пог.м":"кг",
                    AmountProfile = g.ChoiceKg == true && g.ChoicePMetr == false && g.ChoicePiece == false ? g.AmountKg :
                             g.ChoiceKg == false && g.ChoicePMetr == false && g.ChoicePiece == true ? g.AmountPiece :
                             g.ChoiceKg == false && g.ChoicePMetr == true && g.ChoicePiece == false ? g.AmountPMetr : g.AmountKg,
                    PriceProfile= g.ChoiceKg == true && g.ChoicePMetr == false && g.ChoicePiece == false ? g.PriceKg :
                             g.ChoiceKg == false && g.ChoicePMetr == false && g.ChoicePiece == true ? g.PricePiece :
                             g.ChoiceKg == false && g.ChoicePMetr == true && g.ChoicePiece == false ? g.PricePMetr : g.PriceKg,
                    TotalSumProfile =g.TotalSum}).ToList();
            list = new List<SpecificationForScore>(inventory);
            return list;
        }
    
    }
}