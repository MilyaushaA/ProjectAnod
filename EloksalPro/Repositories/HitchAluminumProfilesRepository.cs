using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
    public class HitchAluminumProfilesRepository : BaseRepo<HitchAluminumProfile>, IHitchAluminumProfilesRepository
    {
        public ObservableCollection<HitchAluminumProfile> GetAllEntity(string shotBlasting)
        {
            ObservableCollection<HitchAluminumProfile> list = new ObservableCollection<HitchAluminumProfile>();
            var inventory = Table.Where(x => x.NumberHitchGeneral.TrimEnd() == shotBlasting.TrimEnd());
            list = new ObservableCollection<HitchAluminumProfile>(inventory);
            return list;
        }
        public int MaxNumberShotBlasting()
        {
            List<HitchAluminumProfile> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberHitchGeneral).ToList();
                List<int> eloksalNoListInt = new List<int>();

                foreach (string item in numberList)
                {
                    int number = int.Parse(item.Substring(2));
                    eloksalNoListInt.Add(number);
                }
                int eloksalNoIntMax = eloksalNoListInt.Max();
                return eloksalNoIntMax;
            }
            else
            {
                return 0;
            }
        }
        public List<string> GetNomenclature(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NumberSpecification == numberSpecification && p.ReadinessProfile==false)
                   .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNumberSpecification()
        {
            List<string> list = new List<string>();
            list = Table.Where(p=>p.ReadinessProfile==false)
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }
        public HitchAluminumProfile GetListHitchAluminumProfile(int id)
        {
            var list = Table.FirstOrDefault(p => p.Id == id);
            return list;
        }
        public double GetWeightNomenclature(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.WeightGeneral);
            }
            return weight;
        }
        public double GetWeightNomenclatureDefective(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.WeightGeneralDefect);
            }
            return weight;
        }
        public void UpdateHitchAluminumProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile)
        {
            HitchAluminumProfile myEntity = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public List<ForPivotTableHitchAluminumProfile> GetForPivotTableHitchAluminumProfile()
        {
            List<ForPivotTableHitchAluminumProfile> list = new List<ForPivotTableHitchAluminumProfile>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTableHitchAluminumProfile
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceHitchAluminumProfile = g.Sum(p => p.AmountPieceFact),
                        WeightHitchAluminumProfile = g.Sum(p => p.WeightGeneral),
                        LenghtHitchAluminumProfile = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceFact)) / 1000,
                        AmountPieceHitchAluminumProfileBrak = g.Sum(p => p.AmountPieceDefect),
                        LenghtHitchAluminumProfileBrak = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceDefect)) / 1000,
                        WeightHitchAluminumProfileBrak = g.Sum(p => p.WeightGeneralDefect)
                    }).ToList();
            return list;
        }
    }
}
