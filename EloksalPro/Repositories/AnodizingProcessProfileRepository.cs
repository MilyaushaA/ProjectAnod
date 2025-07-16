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
   public class AnodizingProcessProfileRepository: BaseRepo<AnodizingProcessProfile>,IAnodizingProcessProfileRepository
    {
        public int MaxNumberAnodizingProcess()
        {
            List<AnodizingProcessProfile> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberAnodizingProcess).ToList();
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
        public ObservableCollection<AnodizingProcessProfile> GetAllEntity(string anodizingProcess)
        {
            ObservableCollection<AnodizingProcessProfile> list = new ObservableCollection<AnodizingProcessProfile>();
            var inventory = Table.Where(x => x.NumberAnodizingProcess.TrimEnd() == anodizingProcess.TrimEnd());
            list = new ObservableCollection<AnodizingProcessProfile>(inventory);
            return list;
        }
        public List<string> GetNomenclature(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile.Contains("P") && p.ReadinessProfile == false)
                   .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNumberSpecification()
        {
            List<string> list = new List<string>();
            list = Table.Where(p=>p.NomenclatureProfile.Contains("P") && !p.NomenclatureProfile.Contains("T") && !p.NomenclatureProfile.Contains("R") && p.ReadinessProfile==false)
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }  
        public List<string> GetNumberSpecificationСuttingFacing()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => /*!p.NomenclatureProfile.Contains("P") &&*/ (p.NomenclatureProfile.Contains("T") || p.NomenclatureProfile.Contains("R") ) && p.ReadinessProfile == false)
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclatureCutting(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NumberSpecification == numberSpecification /*&& !p.NomenclatureProfile.Contains("P")*/ && (p.NomenclatureProfile.Contains("T") || p.NomenclatureProfile.Contains("R")) && p.ReadinessProfile == false).Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNumberSpecificationPacking()
        {
            List<string> list = new List<string>();
            list = Table.Where(p => !p.NomenclatureProfile.Contains("P") 
                   && !p.NomenclatureProfile.Contains("T") 
                   && !p.NomenclatureProfile.Contains("R") && p.ReadinessProfile == false)
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclaturePacking(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p =>p.NumberSpecification== numberSpecification && !p.NomenclatureProfile.Contains("P") &&
            !p.NomenclatureProfile.Contains("T") && !p.NomenclatureProfile.Contains("R") && p.ReadinessProfile == false)
                  .Select(p => p.NomenclatureProfile).Distinct().ToList();
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
        public int GetCountNomenclature(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.AmountPieceFact);
            }
            return count;
        }
        public int GetCountNomenclatureDefective(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int count = 0;
            if (list.Any())
            {
                count = list.Sum(x => x.AmountPieceDefect);
            }
            return count;
        }
        public void UpdateAnodizingProcessProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile)
        {
            AnodizingProcessProfile myEntity = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public void UpdateAnodizingProcessProfileReadinessProfile(int id ,  bool readinessProfile)
        {
            AnodizingProcessProfile myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public List<AnodizingProcessProfile> GetListAnodizingProcess(string nomenclature, string numberSpecification)
        {
            List<AnodizingProcessProfile> list = Table.Where(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification).ToList();
            return list;
        }
        public List<ForPivotTableAnodizingProcessProfile> GetForPivotTableAnodizingProcessProfile()
        {
            List<ForPivotTableAnodizingProcessProfile> list = new List<ForPivotTableAnodizingProcessProfile>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTableAnodizingProcessProfile
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceAnodizingProcessProfile = g.Sum(p => p.AmountPieceFact),
                        WeightAnodizingProcessProfile = g.Sum(p => p.WeightGeneral),
                        LenghtAnodizingProcessProfile = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceFact)) / 1000,
                        AmountPieceAnodizingProcessProfileBrak = g.Sum(p => p.AmountPieceDefect),
                        LenghtAnodizingProcessProfileBrak = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceDefect)) / 1000,
                        WeightAnodizingProcessProfileBrak = g.Sum(p => p.WeightGeneralDefect)
                    }).ToList();
            return list;
        }
        public List<ForPivotTableAnodizingProcessProfileTwo> GetForPivotTableAnodizingProcessProfileTwo()
        {
            List<ForPivotTableAnodizingProcessProfileTwo> list = new List<ForPivotTableAnodizingProcessProfileTwo>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTableAnodizingProcessProfileTwo
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        GeneralNomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceAnodizingProcessProfile = g.Sum(p => p.AmountPieceFact),
                        WeightAnodizingProcessProfile = g.Sum(p => p.WeightGeneral),
                        LenghtAnodizingProcessProfile = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceFact)) / 1000,
                        AmountPieceAnodizingProcessProfileBrak = g.Sum(p => p.AmountPieceDefect),
                        LenghtAnodizingProcessProfileBrak = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceDefect)) / 1000,
                        WeightAnodizingProcessProfileBrak = g.Sum(p => p.WeightGeneralDefect)
                    }).ToList();
            return list;
        }
        public List<AnodizingProcessProfileReport> GetAnodizingProcessProfileReport(DateTime date, string shift)
        {
            List<AnodizingProcessProfileReport> list = new List<AnodizingProcessProfileReport>();
            List<AnodizingProcessProfile> listAnod = new List<AnodizingProcessProfile>();
            listAnod = Table.ToList();
            AnodizingProcessProfileGeneralRepository repos = new AnodizingProcessProfileGeneralRepository();
            List<AnodizingProcessProfileGeneral> listAnodGeneral = new List<AnodizingProcessProfileGeneral>();
            listAnodGeneral = repos.GetAnodizingProcessProfileGeneral();
            var listUnion = from a in listAnod
                            join b in listAnodGeneral on a.NumberAnodizingProcess equals b.NumberAnodizingProcess
                            where b.Date.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd") && b.Shift == shift
                            group a by new { a.EloksalNoCommercial, a.LenghtFact,a.ColorAnod } into g
                            select new AnodizingProcessProfileReport
                            {
                                EloksalNoCommercial = g.Key.EloksalNoCommercial,
                                ColorAnod=g.Key.ColorAnod,
                                LenghtFact = Convert.ToInt16(g.Key.LenghtFact),
                                AmountPieceFact = Convert.ToInt16(g.Sum(x => x.AmountPieceFact)),
                                GeneralAreaProducedProfile = Convert.ToDouble(g.Sum(x => x.GeneralAreaProducedProfile)),
                                WeightGeneral = Convert.ToDouble(g.Sum(x => x.WeightGeneral))
                            };
            list = listUnion.AsEnumerable().ToList();
            return list;
        }
        public List<AnodizingProcessProfileSummaryTable> GetAnodizingProcessProfileSummaryTable()
        {
            List<AnodizingProcessProfile> listAnodizingProcessProfile = new List<AnodizingProcessProfile>();
            listAnodizingProcessProfile = Table.ToList();
            AnodizingProcessProfileGeneralRepository repos = new AnodizingProcessProfileGeneralRepository();
            List<AnodizingProcessProfileGeneral> listAnodizingProcessProfileGeneral = new List<AnodizingProcessProfileGeneral>();
            listAnodizingProcessProfileGeneral = repos.GetByAllEntity();
            var query = (from a in listAnodizingProcessProfile
                         join b in listAnodizingProcessProfileGeneral
                             on a.NumberAnodizingProcess equals b.NumberAnodizingProcess into gj
                         from b in gj.DefaultIfEmpty() // Left join
                         select new AnodizingProcessProfileSummaryTable
                         {
                             Id=b.Id,
                             NumberAnodizingProcess=b.NumberAnodizingProcess,
                             Date = b.Date,
                             Shift = b.Shift,
                             ClientName = a.ClientName,
                             NumberSpecification = a.NumberSpecification,
                             EloksalNoCommercial = a.EloksalNoCommercial,
                             NomenclatureProfile = a.NomenclatureProfile,
                             LenghtProfile = Convert.ToDouble(a.LenghtFact),
                             WeightMeter = Convert.ToDouble(a.WeightMeter),
                             OuterPerimeter = a.OuterPerimeter,
                             QuantityProducedProfile = Convert.ToInt32(a.AmountPieceFact),
                             GeneralQuantityProducedProfile = a.WeightGeneral,
                             GeneralAreaProducedProfile = a.GeneralAreaProducedProfile,
                             QuantityDefectiveProfile = Convert.ToInt32(a.AmountPieceDefect),
                             GeneralQuantityDefectiveProfile = a.WeightGeneralDefect,
                             GeneralAreaDefectiveProfile = Convert.ToDouble(a.GeneralAreaDefectiveProfile)
                         }).Distinct();
            List<AnodizingProcessProfileSummaryTable> listSummaryTable = new List<AnodizingProcessProfileSummaryTable>();
            listSummaryTable = query.AsEnumerable().OrderBy(p => p.Date).ToList();
            return listSummaryTable;
        }
        public List<AnodizingProcessProfile> GetNumberSpecificationAndClient(string number, string client)
        {
            List<AnodizingProcessProfile> list = new List<AnodizingProcessProfile>();
            list = Table.Where(p => p.NumberSpecification == number && p.ClientName == client).ToList();
            return list;
        }

    }
}
