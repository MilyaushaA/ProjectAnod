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
   public class СuttingFacingProfileRepository : BaseRepo<СuttingFacingProfile>, IСuttingFacingProfileRepository
    {
        public int MaxNumberСuttingFacingProfile()
        {
            List<СuttingFacingProfile> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberСuttingFacingGeneral).ToList();
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
        public ObservableCollection<СuttingFacingProfile> GetAllEntity(string cuttingFacingProfile)
        {
            ObservableCollection<СuttingFacingProfile> list = new ObservableCollection<СuttingFacingProfile>();
            var inventory = Table.Where(x => x.NumberСuttingFacingGeneral.TrimEnd() == cuttingFacingProfile.TrimEnd());
            list = new ObservableCollection<СuttingFacingProfile>(inventory);
            return list;
        }
        public List<string> GetNumberSpecificationСutting()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.ReadinessProfile == false && !p.NomenclatureProfile.Contains("P"))
                  .Select(p => p.NumberSpecification ).Distinct().ToList();
            return list;
        }
        public List<string> GetNumberSpecificationCuttingTapeProtective()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NomenclatureProfile.Contains("P") && p.ReadinessProfile == false)
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclatureTapeProtective(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile.Contains("P") && p.ReadinessProfile == false)
                .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclatureСutting(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p=>p.NumberSpecification== numberSpecification && p.ReadinessProfile == false && !p.NomenclatureProfile.Contains("P"))
                  .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public double GetWeightNomenclatureAfter(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature && p.ReadinessProfile == false);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.WeightProducedProfileAfter);
            }
            return weight;
        }
        public double GetWeightNomenclatureBefore(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.WeightProducedProfileBefore);
            }
            return weight;
        }
        public int? GetCountNomenclatureBefore(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int? count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.QuantityProducedProfileBefore);
            }
            return count;
        }
        public int? GetCountNomenclatureAfter(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int? count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.QuantityProducedProfileAfter);
            }
            return count;
        }
        public int? GetCountNomenclatureDefective(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int? count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.QuantityDefectedProfile);
            }
            return count;
        }
        public double GetWeightNomenclatureDefective(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.WeightDefectedProfile);
            }
            return weight;
        }
        public double GetWeightTechnologicalWaste(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.WeightTechnologicalWaste);
            }
            return weight;
        }
        public void UpdateСuttingFacingProfileProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile)
        {
            СuttingFacingProfile myEntity = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public void UpdateСuttingFacingProfileProfileReadinessProfile(int id, bool readinessProfile)
        {
            СuttingFacingProfile myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public List<ForPivotTableСuttingFacingProfile> GetForPivotTableСuttingFacingProfile()
        {
            List<ForPivotTableСuttingFacingProfile> list = new List<ForPivotTableСuttingFacingProfile>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTableСuttingFacingProfile
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceСuttingFacingProfile = g.Sum(p => p.QuantityProducedProfileAfter),
                        WeightСuttingFacingProfile = g.Sum(p => p.WeightProducedProfileAfter),
                        LenghtСuttingFacingProfile = g.Sum(p => p.LenghtProfileAfter * g.Sum(f => f.QuantityProducedProfileAfter)) / 1000,
                        AmountPieceСuttingFacingProfileBrak = g.Sum(p => p.QuantityDefectedProfile),
                        LenghtСuttingFacingProfileBrak = g.Sum(p => p.LenghtProfileAfter * g.Sum(f => f.QuantityDefectedProfile)) / 1000,
                        WeightСuttingFacingProfileBrak = g.Sum(p => p.WeightDefectedProfile)
                    }).ToList();
            return list;
        }
        public List<ForPivotTableСuttingFacingProfileTwo> GetForPivotTableСuttingTwoFacingProfile()
        {
            List<ForPivotTableСuttingFacingProfileTwo> list = new List<ForPivotTableСuttingFacingProfileTwo>();
            list = Table.Where(p => p.GeneralNomenclatureProfile!=null)
                        .GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile,p.GeneralNomenclatureProfile })
                        .Select(g => new ForPivotTableСuttingFacingProfileTwo
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        GeneralNomenclatureProfile = g.Key.GeneralNomenclatureProfile,
                        AmountPieceСuttingFacingProfile = g.Sum(p => p.QuantityProducedProfileAfter),
                        WeightСuttingFacingProfile = g.Sum(p => p.WeightProducedProfileAfter),
                        LenghtСuttingFacingProfile = g.Sum(p => p.LenghtProfileAfter * g.Sum(f => f.QuantityProducedProfileAfter)) / 1000,
                        AmountPieceСuttingFacingProfileBrak = g.Sum(p => p.QuantityDefectedProfile),
                        LenghtСuttingFacingProfileBrak = g.Sum(p => p.LenghtProfileAfter * g.Sum(f => f.QuantityDefectedProfile)) / 1000,
                        WeightСuttingFacingProfileBrak = g.Sum(p => p.WeightDefectedProfile)
                    }).ToList();
            return list;
        }
        public List<СuttingFacingProfile> GetListСuttingFacingProfile(string nomenclature, string numberSpecification)
        {
            List<СuttingFacingProfile> list = Table.Where(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification).ToList();
            return list;
        }
        public List<СuttingFacingProfileReport> GetСuttingFacingProfileReport(DateTime date, string shift)
        {
            List<СuttingFacingProfileReport> list = new List<СuttingFacingProfileReport>();
            List<СuttingFacingProfile> listСuttingFacing = new List<СuttingFacingProfile>();
            listСuttingFacing = Table.ToList();
            СuttingFacingGeneralProfileRepository repos = new СuttingFacingGeneralProfileRepository();
            List<СuttingFacingGeneralProfile> listGeneral = new List<СuttingFacingGeneralProfile>();
            listGeneral = repos.GetСuttingFacingGeneralProfile();
            var listUnion = from a in listСuttingFacing
                            join b in listGeneral on a.NumberСuttingFacingGeneral equals b.NumberСuttingFacing
                            where b.Date.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd") && b.Shift == shift
                            group a by new { a.EloksalNoCommercial,a.NomenclatureProfile,a.ClientName ,a.NumberSpecification,a.LenghtProfileAfter,
                                            a.LenghtProfileBefore,a.WeightMeter
                            } into g
                            select new СuttingFacingProfileReport
                            {
                                EloksalNoCommercial = g.Key.EloksalNoCommercial,
                                NumberSpecification = g.Key.NumberSpecification,
                                NomenclatureProfile = g.Key.NomenclatureProfile,
                                WeightMeter = g.Key.WeightMeter,
                                ClientName = g.Key.ClientName,
                                LenghtProfileAfter = Convert.ToInt16(g.Key.LenghtProfileAfter),
                                QuantityProducedProfileAfter = Convert.ToInt16(g.Sum(x => x.QuantityProducedProfileAfter)),
                                WeightProducedProfileAfter = Convert.ToDouble(g.Sum(x => x.WeightProducedProfileAfter)),
                                LenghtProfileBefore = Convert.ToInt16(g.Key.LenghtProfileBefore),
                                QuantityProducedProfileBefore = Convert.ToInt16(g.Sum(x => x.QuantityProducedProfileBefore)),
                                WeightProducedProfileBefore = Convert.ToDouble(g.Sum(x => x.WeightProducedProfileBefore)),
                                WeightTechnologicalWaste = Convert.ToDouble(g.Sum(x => x.WeightTechnologicalWaste))
                            };
            list = listUnion.AsEnumerable().ToList();
            return list;
        }
        public List<СuttingFacingProfileSummaryTable> GetСuttingFacingGeneralProfileSummaryTable()
        {
            List<СuttingFacingProfile> listСuttingFacingProfile = new List<СuttingFacingProfile>();
            listСuttingFacingProfile = Table.ToList();
            СuttingFacingGeneralProfileRepository repos = new СuttingFacingGeneralProfileRepository();
            List<СuttingFacingGeneralProfile> listСuttingFacingGeneralProfile = new List<СuttingFacingGeneralProfile>();
            listСuttingFacingGeneralProfile = repos.GetByAllEntity();
            var query = (from a in listСuttingFacingProfile
                         join b in listСuttingFacingGeneralProfile
                             on a.NumberСuttingFacingGeneral equals b.NumberСuttingFacing into gj
                         from b in gj.DefaultIfEmpty() // Left join
                         select new СuttingFacingProfileSummaryTable
                         {
                             Id = b.Id,
                             NumberСuttingFacing = b.NumberСuttingFacing,
                             Date = b.Date,
                             Shift = b.Shift,
                             ClientName = a.ClientName,
                             NumberSpecification = a.NumberSpecification,
                             EloksalNoCommercial = a.EloksalNoCommercial,
                             NomenclatureProfile = a.NomenclatureProfile,
                             WeightMeter = Convert.ToDouble(a.WeightMeter),
                             //OuterPerimeter = a.OuterPerimeter,
                             LenghtProfileBefore = Convert.ToInt32(a.LenghtProfileBefore),
                             QuantityProducedProfileBefore = Convert.ToInt32(a.QuantityProducedProfileBefore),
                             WeightProducedProfileBefore = a.WeightProducedProfileBefore,
                             LenghtProfileAfter = Convert.ToInt32(a.LenghtProfileAfter),
                             QuantityProducedProfileAfter = Convert.ToInt32(a.QuantityProducedProfileAfter),
                             WeightProducedProfileAfter = a.WeightProducedProfileAfter,
                             QuantityDefectedProfile = Convert.ToInt32(a.QuantityDefectedProfile),
                             WeightDefectedProfile = Convert.ToDouble(a.WeightDefectedProfile),
                             WeightTechnologicalWaste = Convert.ToDouble(a.WeightTechnologicalWaste)
                         }).Distinct();
            List<СuttingFacingProfileSummaryTable> listSummaryTable = new List<СuttingFacingProfileSummaryTable>();
            listSummaryTable = query.AsEnumerable().OrderBy(p => p.Date).ToList();
            return listSummaryTable;
        }
    }
}
