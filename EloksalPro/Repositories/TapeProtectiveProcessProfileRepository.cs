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
    /// <summary>
    /// Нанесение защитной пленки
    /// </summary>
   public class TapeProtectiveProcessProfileRepository:BaseRepo<TapeProtectiveProcessProfile>,ITapeProtectiveProcessProfileRepository
    {
        public int MaxNumberTapeProtectiveProcess()
        {
            List<TapeProtectiveProcessProfile> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberTapeProtectiveGeneral).ToList();
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
        public ObservableCollection<TapeProtectiveProcessProfile> GetAllEntity(string nameTapeProtective)
        {
            ObservableCollection<TapeProtectiveProcessProfile> list = new ObservableCollection<TapeProtectiveProcessProfile>();
            var inventory = Table.Where(x => x.NumberTapeProtectiveGeneral.TrimEnd() == nameTapeProtective.TrimEnd());
            list = new ObservableCollection<TapeProtectiveProcessProfile>(inventory);
            return list;
        }
        public List<string> GetNumberSpecificationCutting()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => (p.NomenclatureProfile.Contains("T") || p.NomenclatureProfile.Contains("R")) && p.ReadinessProfile == false )
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclatureCutting(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NumberSpecification == numberSpecification && (p.NomenclatureProfile.Contains("T") || p.NomenclatureProfile.Contains("R")) && p.ReadinessProfile == false)
                  .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNumberSpecificationPacking()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NomenclatureProfile.Contains("P")  &&
                   p.ReadinessProfile == false)
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclaturenPacking(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p =>p.NumberSpecification== numberSpecification && p.NomenclatureProfile.Contains("P")  && p.ReadinessProfile == false)
                  .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<TapeProtectiveProcessProfile> GetListTapeProtectiveProcessProfile(string nomenclature, string numberSpecification)
        {
            List<TapeProtectiveProcessProfile> list = Table.Where(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification).ToList();
            return list;
        }
        public double GetWeightNomenclature(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.GeneralQuantityProducedProfile);
            }
            return weight;
        }
        public double GetWeightNomenclatureDefective(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.GeneralQuantityDefectedProfile);
            }
            return weight;
        }
        public int? GetCountNomenclature(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int? count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.QuantityProducedProfile);
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
        public void UpdateTapeProtectiveProcessProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile)
        {
            TapeProtectiveProcessProfile myEntity = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public void UpdateTapeProtectiveProcessProfileReadinessProfile(int id, bool readinessProfile)
        {
            TapeProtectiveProcessProfile myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public List<TapeProtectiveProcessProfile> GetListTapeProtectiveProcess(string nomenclature, string numberSpecification)
        {
            List<TapeProtectiveProcessProfile> list = Table.Where(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification).ToList();
            return list;
        }
        public List<ForPivotTableTapeProtectiveProcessProfile> GetForPivotTableTapeProtectiveProcessProfile()
        {
            List<ForPivotTableTapeProtectiveProcessProfile> list = new List<ForPivotTableTapeProtectiveProcessProfile>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTableTapeProtectiveProcessProfile
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceTapeProtectiveProcessProfile = g.Sum(p => p.QuantityProducedProfile),
                        WeightTapeProtectiveProcessProfile = g.Sum(p => p.GeneralQuantityProducedProfile),
                        LenghtTapeProtectiveProcessProfile = g.Sum(p => p.LenghtProfileFact * g.Sum(f => f.QuantityProducedProfile)) / 1000,
                        AmountPieceTapeProtectiveProcessProfileBrak = g.Sum(p => p.QuantityDefectedProfile),
                        LenghtTapeProtectiveProcessProfileBrak = g.Sum(p => p.LenghtProfileFact * g.Sum(f => f.QuantityDefectedProfile)) / 1000,
                        WeightTapeProtectiveProcessProfileBrak = g.Sum(p => p.GeneralQuantityDefectedProfile)
                    }).ToList();
            return list;
        }
        public List<TapeProtectiveProcessProfileReport> GetTapeProtectiveProcessProfileReport(DateTime date, string shift)
        {
            List<TapeProtectiveProcessProfileReport> list = new List<TapeProtectiveProcessProfileReport>();
            List<TapeProtectiveProcessProfile> listTape = new List<TapeProtectiveProcessProfile>();
            listTape = Table.ToList();
            TapeProtectiveProcessProfileGeneralRepository repos = new TapeProtectiveProcessProfileGeneralRepository();
            List<TapeProtectiveProcessProfileGeneral> listGeneral = new List<TapeProtectiveProcessProfileGeneral>();
            listGeneral = repos.GetTapeProtectiveProcessProfileGeneral();
            var listUnion = from a in listTape
                            join b in listGeneral on a.NumberTapeProtectiveGeneral equals b.NumberTapeProtectiveProcess
                            where b.Date.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd") && b.Shift == shift
                            group a by new { a.EloksalNoCommercial, a.LenghtProfileFact} into g
                            select new TapeProtectiveProcessProfileReport
                            {
                                EloksalNoCommercial = g.Key.EloksalNoCommercial,
                                LenghtProfileFact = Convert.ToInt16(g.Key.LenghtProfileFact),
                                QuantityProducedProfile = Convert.ToInt16(g.Sum(x => x.QuantityProducedProfile)),
                                GeneralAreaProducedProfile = Convert.ToDouble(g.Sum(x => x.GeneralAreaProducedProfile)),
                                GeneralQuantityProducedProfile = Convert.ToDouble(g.Sum(x => x.GeneralQuantityProducedProfile))
                            };
            list = listUnion.AsEnumerable().ToList();
            return list;
        }
        public List<TapeProtectiveProcessProfileSummaryTable> GetTapeProtectiveProcessProfileSummaryTable()
        {
            List<TapeProtectiveProcessProfile> listTapeProtectiveProcessProfile = new List<TapeProtectiveProcessProfile>();
            listTapeProtectiveProcessProfile = Table.ToList();
            TapeProtectiveProcessProfileGeneralRepository repos = new TapeProtectiveProcessProfileGeneralRepository();
            List<TapeProtectiveProcessProfileGeneral> listTapeProtectiveProcessProfileGeneral = new List<TapeProtectiveProcessProfileGeneral>();
            listTapeProtectiveProcessProfileGeneral = repos.GetByAllEntity();
            var query = (from a in listTapeProtectiveProcessProfile
                         join b in listTapeProtectiveProcessProfileGeneral
                             on a.NumberTapeProtectiveGeneral equals b.NumberTapeProtectiveProcess into gj
                         from b in gj.DefaultIfEmpty() // Left join
                         select new TapeProtectiveProcessProfileSummaryTable
                         {
                             Id = b.Id,
                             NumberTapeProtectiveGeneral = b.NumberTapeProtectiveProcess,
                             Date = b.Date,
                             Shift = b.Shift,
                             ClientName = a.ClientName,
                             NumberSpecification = a.NumberSpecification,
                             EloksalNoCommercial = a.EloksalNoCommercial,
                             NomenclatureProfile = a.NomenclatureProfile,
                             LenghtProfile = Convert.ToDouble(a.LenghtProfileFact),
                             WeightMeter = Convert.ToDouble(a.WeightMeter),
                             OuterPerimeter = a.OuterPerimeter,
                             QuantityProducedProfile = Convert.ToInt32(a.QuantityProducedProfile),
                             GeneralQuantityProducedProfile = a.GeneralQuantityProducedProfile,
                             GeneralAreaProducedProfile = a.GeneralAreaProducedProfile,
                             QuantityDefectiveProfile = Convert.ToInt32(a.QuantityDefectedProfile),
                             GeneralQuantityDefectiveProfile = a.GeneralQuantityDefectedProfile,
                             GeneralAreaDefectiveProfile = Convert.ToDouble(a.GeneralAreaDefectiveProfile),
                             QuantityRunningMeter= Convert.ToDouble(a.QuantityRunningMeter),
                             ConsumptionProtectiveFilm=Convert.ToDouble(a.ConsumptionProtectiveFilm)}).Distinct();
            List<TapeProtectiveProcessProfileSummaryTable> listSummaryTable = new List<TapeProtectiveProcessProfileSummaryTable>();
            listSummaryTable = query.AsEnumerable().OrderBy(p => p.Date).ToList();
            return listSummaryTable;
        }
    }
}
