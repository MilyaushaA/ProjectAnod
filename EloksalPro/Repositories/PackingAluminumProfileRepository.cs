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
   public class PackingAluminumProfileRepository : BaseRepo<PackingAluminumProfile>, IPackingAluminumProfileRepository
    {
        public int MaxNumberPackingProfile()
        {
            List<PackingAluminumProfile> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberPackingAluminumProfile).ToList();
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
        public ObservableCollection<PackingAluminumProfile> GetAllEntity(string packingProfile)
        {
            ObservableCollection<PackingAluminumProfile> list = new ObservableCollection<PackingAluminumProfile>();
            var inventory = Table.Where(x => x.NumberPackingAluminumProfile.TrimEnd() == packingProfile.TrimEnd());
            list = new ObservableCollection<PackingAluminumProfile>(inventory);
            return list;
        }
        public List<string> GetNumberSpecification()
        {
            List<string> list = new List<string>();
            list = Table.Where(p=>p.ReadinessProfile==false)
                  .Select(p => p.NumberSpecification).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclature(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NumberSpecification == numberSpecification && p.ReadinessProfile==false).Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNumberBasket()
        {
            List<string> list = new List<string>();
            list = Table.Select(p => p.BasketNumber).ToList();
            return list;
        }
        public double GetWeightNomenclature(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weight = 0;
            if (list.Any())
            {
                weight = list.Sum(x => x.WeightProducedProfile);
            }
            return weight;
        }
        public int? GetAmountNomenclature(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int? count= 0;
            if (list.Any())
            {
                count = list.Sum(x => x.QuantityProducedProfile);
            }
            return count;
        }
        public int? GetAmountNomenclatureDefective(string numberSpecification, string nomenclature)
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
        public List<ForPivotTablePackingAluminumProfile> GetForPivotTablePackingAluminumProfile()
        {
            List<ForPivotTablePackingAluminumProfile> list = new List<ForPivotTablePackingAluminumProfile>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTablePackingAluminumProfile
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPiecePackingAluminumProfile = g.Sum(p => p.QuantityProducedProfile),
                        WeightPackingAluminumProfile = g.Sum(p => p.WeightProducedProfile),
                        LenghtPackingAluminumProfile = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityProducedProfile)) / 1000,
                        AmountPiecePackingAluminumProfileBrak = g.Sum(p => p.QuantityDefectedProfile),
                        LenghtPackingAluminumProfileBrak = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityDefectedProfile)) / 1000,
                        WeightPackingAluminumProfileBrak = g.Sum(p => p.WeightDefectedProfile)
                    }).ToList();
            return list;
        }
        public void UpdatePackingAluminumProfileProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile)
        {
            PackingAluminumProfile myEntity = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public void UpdatePackingAluminumProfileProfileReadinessProfile(int id, bool readinessProfile)
        {
            PackingAluminumProfile myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public List<PackingAluminumProfile> GetListPackingAluminumProfile(string nomenclature, string numberSpecification)
        {
            List<PackingAluminumProfile> list = Table.Where(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification).ToList();
            return list;
        }
        public List<PackingAluminumProfileReport> GetPackingAluminumProfileReport(DateTime date, string shift)
        {
            List<PackingAluminumProfileReport> list = new List<PackingAluminumProfileReport>();
            List<PackingAluminumProfile> listPacking = new List<PackingAluminumProfile>();
            listPacking = Table.ToList();
            PackingAluminumProfileGeneralRepository repos = new PackingAluminumProfileGeneralRepository();
            List<PackingAluminumProfileGeneral> listGeneral = new List<PackingAluminumProfileGeneral>();
            listGeneral = repos.GetPackingAluminumProfileGeneral();
            var listUnion = from a in listPacking
                            join b in listGeneral on a.NumberPackingAluminumProfile equals b.NumberPackingAluminumProfile
                            where b.Date.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd") && b.Shift == shift
                            group a by new { a.EloksalNoCommercial, a.LenghtProfile } into g
                            select new PackingAluminumProfileReport
                            {
                                EloksalNoCommercial = g.Key.EloksalNoCommercial,
                                LenghtProfile = Convert.ToInt16(g.Key.LenghtProfile),
                                QuantityProducedProfile = Convert.ToInt16(g.Sum(x => x.QuantityProducedProfile)),
                                GeneralAreaProducedProfile = Convert.ToDouble(g.Sum(x => x.GeneralAreaProducedProfile)),
                                WeightProducedProfile = Convert.ToDouble(g.Sum(x => x.WeightProducedProfile))
                            };
            list = listUnion.AsEnumerable().ToList();
            return list;
        }
        public List<string> GetBasketNumber(string nomenclatureProfile)
        {
            List<string> list = new List<string>();
            list = Table.Where(p=>p.NomenclatureProfile==nomenclatureProfile)
                .Select(p => p.BasketNumber).Distinct().ToList();
            return list;
        }
        public List<PackingAluminumProfileSummaryTable> GetPackingAluminumProfileSummaryTable()
        {
            List<PackingAluminumProfile> listPackingAluminumProfile = new List<PackingAluminumProfile>();
            listPackingAluminumProfile = Table.ToList();
            PackingAluminumProfileGeneralRepository repos = new PackingAluminumProfileGeneralRepository();
            List<PackingAluminumProfileGeneral> listPackingAluminumProfileGeneral = new List<PackingAluminumProfileGeneral>();
            listPackingAluminumProfileGeneral = repos.GetByAllEntity();
            var query = (from a in listPackingAluminumProfile
                         join b in listPackingAluminumProfileGeneral
                             on a.NumberPackingAluminumProfile equals b.NumberPackingAluminumProfile into gj
                         from b in gj.DefaultIfEmpty() // Left join
                         select new PackingAluminumProfileSummaryTable
                         {
                             Id = b.Id,
                             NumberPackingAluminumProfile = b.NumberPackingAluminumProfile,
                             Date = b.Date,
                             Shift = b.Shift,
                             BasketNumber=a.BasketNumber,
                             ClientName = a.ClientName,
                             NumberSpecification = a.NumberSpecification,
                             EloksalNoCommercial = a.EloksalNoCommercial,
                             NomenclatureProfile = a.NomenclatureProfile,
                             LenghtProfile = Convert.ToDouble(a.LenghtProfile),
                             WeightMeter = Convert.ToDouble(a.WeightMeter),
                             QuantityProducedProfile = Convert.ToInt32(a.QuantityProducedProfile),
                             GeneralQuantityProducedProfile = a.WeightProducedProfile,
                             GeneralAreaProducedProfile = a.GeneralAreaProducedProfile,
                             QuantityDefectiveProfile = Convert.ToInt32(a.QuantityDefectedProfile),
                             GeneralQuantityDefectiveProfile = a.WeightDefectedProfile,
                             GeneralAreaDefectiveProfile = Convert.ToDouble(a.GeneralAreaDefectiveProfile)
                         }).Distinct();
            List<PackingAluminumProfileSummaryTable> listSummaryTable = new List<PackingAluminumProfileSummaryTable>();
            listSummaryTable = query.AsEnumerable().OrderBy(p => p.Date).ToList();
            return listSummaryTable;
        }
        public List<PackingAluminumProfileForShipment> GetByPackingAluminumProfileForShipment()
        {
            List<PackingAluminumProfileForShipment> list = new List<PackingAluminumProfileForShipment>();
            list = Table.Select(p => new PackingAluminumProfileForShipment
            {
                NumberSpecification = p.NumberSpecification,
                BasketNumber = p.BasketNumber,
                NomenclatureProfile = p.NomenclatureProfile,
                ClientName = p.ClientName,
                EloksalNoCommercial = p.EloksalNoCommercial,
                OuterPerimeter=p.OuterPerimeter,
                WeightMeter = p.WeightMeter,
                LenghtProfile = p.LenghtProfile,
                QuantityProducedProfile = p.QuantityProducedProfile,
                WeightProducedProfile = p.WeightProducedProfile,
                GeneralAreaProducedProfile = p.GeneralAreaProducedProfile,
                Annotation = p.Annotation,
                PalletSelection = false
            }).ToList();
            return list;
        }

        public PackingAluminumProfile GetByEntityForBasket(string basket)
        {
            PackingAluminumProfile list = new PackingAluminumProfile();
            list = Table.FirstOrDefault(x => x.BasketNumber== basket);
            return list;
        }
    }
}
