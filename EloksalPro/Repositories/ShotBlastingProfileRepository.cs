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
   public class ShotBlastingProfileRepository: BaseRepo<ShotBlastingProfile>, IShotBlastingProfileRepository
    {
        public ObservableCollection<ShotBlastingProfile> GetAllEntity(string shotBlasting)
        {
            ObservableCollection<ShotBlastingProfile> list = new ObservableCollection<ShotBlastingProfile>();
            var inventory = Table.Where(x => x.NumberShotGeneral.TrimEnd() == shotBlasting.TrimEnd());
            list = new ObservableCollection<ShotBlastingProfile>(inventory);
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
            list = Table.Where(p => p.NumberSpecification==numberSpecification && p.ReadinessProfile==false).Select(p=>p.NomenclatureProfile).Distinct().ToList();
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
                weight = list.Sum(x => x.GeneralQuantityDefectiveProfile);
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
                count= list.Sum(x => x.QuantityDefectiveProfile);
            }
            return count;
        }
        public void UpdateShotBlastingProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile)
        {
            ShotBlastingProfile myEntity = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public void UpdateShotBlastingProfileReadinessProfile(int id, bool readinessProfile)
        {
            ShotBlastingProfile myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public List<ForPivotTableShotBlastingProfile> GetForPivotTableShotBlastingProfile()
        {
            List<ForPivotTableShotBlastingProfile> list = new List<ForPivotTableShotBlastingProfile>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile})
                    .Select(g => new ForPivotTableShotBlastingProfile
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        NomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceShotBlastingProfile = g.Sum(p => p.QuantityProducedProfile),
                        WeightShotBlastingProfile = g.Sum(p=>p.GeneralQuantityProducedProfile),
                        LenghtShotBlastingProfile = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityProducedProfile)) / 1000,
                        AmountPieceShotBlastingProfileBrak= g.Sum(p => p.QuantityDefectiveProfile),
                        LenghtShotBlastingProfileBrak = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityDefectiveProfile)) / 1000,
                        WeightShotBlastingProfileBrak = g.Sum(p => p.GeneralQuantityDefectiveProfile)
                    }).ToList();
            return list;
        }
        public List<ForPivotTableShotBlastingProfileTwo> GetForPivotTableShotBlastingProfileTwo()
        {
            List<ForPivotTableShotBlastingProfileTwo> list = new List<ForPivotTableShotBlastingProfileTwo>();
            list = Table.GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile })
                    .Select(g => new ForPivotTableShotBlastingProfileTwo
                    {
                        NumberSpecification = g.Key.NumberSpecification,
                        GeneralNomenclatureProfile = g.Key.NomenclatureProfile,
                        AmountPieceShotBlastingProfile = g.Sum(p => p.QuantityProducedProfile),
                        WeightShotBlastingProfile = g.Sum(p => p.GeneralQuantityProducedProfile),
                        LenghtShotBlastingProfile = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityProducedProfile)) / 1000,
                        AmountPieceShotBlastingProfileBrak = g.Sum(p => p.QuantityDefectiveProfile),
                        LenghtShotBlastingProfileBrak = g.Sum(p => p.LenghtProfile * g.Sum(f => f.QuantityDefectiveProfile)) / 1000,
                        WeightShotBlastingProfileBrak = g.Sum(p => p.GeneralQuantityDefectiveProfile)
                    }).ToList();
            return list;
        }
        public List<ShotBlastingProfile> GetListShotBlastingProfile(string nomenclature, string numberSpecification)
        {
            List<ShotBlastingProfile> list = Table.Where(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification == numberSpecification).ToList();
            return list;
        }
        public List<ShotBlastingProfileReport> GetShotBlastingProfileReport(DateTime date, string shift)
        {
            List<ShotBlastingProfileReport> list = new List<ShotBlastingProfileReport>();
            List<ShotBlastingProfile> listShotBlastingProfile = new List<ShotBlastingProfile>();
            listShotBlastingProfile = Table.ToList();
            ShotBlastingProfilesGeneralsRepository repos = new  ShotBlastingProfilesGeneralsRepository();
            List<ShotBlastingProfilesGeneral> listShotBlastingProfilesGeneral = new List<ShotBlastingProfilesGeneral>();
            listShotBlastingProfilesGeneral = repos.GetShotBlastingProfilesGeneral();
            var listUnion = from a in listShotBlastingProfile
                           join b in listShotBlastingProfilesGeneral on a.NumberShotGeneral equals b.NumberShotGeneral
                           where b.Date.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd") && b.Shift == shift
                           group a by new { a.EloksalNoCommercial, a.LenghtProfile } into g
                           select new ShotBlastingProfileReport
                           {
                               EloksalNoCommercial = g.Key.EloksalNoCommercial,
                               LenghtProfile = Convert.ToInt16(g.Key.LenghtProfile),
                               QuantityProducedProfile = Convert.ToInt16(g.Sum(x => x.QuantityProducedProfile)),
                               GeneralAreaProducedProfile = Convert.ToDouble(g.Sum(x => x.GeneralAreaProducedProfile)),
                               GeneralQuantityProducedProfile = Convert.ToDouble(g.Sum(x => x.GeneralQuantityProducedProfile))
                           };
            list = listUnion.AsEnumerable().ToList(); 
            return list; 
        }
        public List<ShotBlastingProfileSummaryTable> GetShotBlastingProfileSummaryTable()
        {
            List<ShotBlastingProfile> listShotBlastingProfile = new List<ShotBlastingProfile>();
            listShotBlastingProfile = Table.ToList();
            ShotBlastingProfilesGeneralsRepository repos = new ShotBlastingProfilesGeneralsRepository();
            List<ShotBlastingProfilesGeneral> listShotBlastingProfilesGeneral = new List<ShotBlastingProfilesGeneral>();
            listShotBlastingProfilesGeneral = repos.GetByAllEntity();
            ProfileCardRepository reposCard = new ProfileCardRepository();
            List<ProfileCard> listProfileCard= new List<ProfileCard>();
            listProfileCard = reposCard.GetByAllEntity();
            var query = (from a in listShotBlastingProfile
                        join b in listShotBlastingProfilesGeneral
                            on a.NumberShotGeneral equals b.NumberShotGeneral into gj
                        from b in gj.DefaultIfEmpty() // Left join
                        join c in listProfileCard
                        on a.NomenclatureProfile equals c.NomenclatureProfile into gi
                        from c in gi.DefaultIfEmpty() // Left join
                        select new ShotBlastingProfileSummaryTable
                        {
                            Id=b.Id,
                            NumberShotGeneral=a.NumberShotGeneral,
                            Date = b.Date,
                            Shift = b.Shift,
                            ClientName = a.ClientName,
                            NumberSpecification = a.NumberSpecification,
                            EloksalNoCommercial = a.EloksalNoCommercial,
                            NomenclatureProfile = a.NomenclatureProfile,
                            LenghtProfile = Convert.ToDouble(a.LenghtProfile),
                            WeightMeter = Convert.ToDouble(a.WeightMeter),
                            OuterPerimeter = a.OuterPerimeter,
                            QuantityProducedProfile = Convert.ToInt32(a.QuantityProducedProfile),
                            GeneralQuantityProducedProfile = a.GeneralQuantityProducedProfile,
                            GeneralAreaProducedProfile = a.GeneralAreaProducedProfile,
                            QuantityDefectiveProfile = Convert.ToInt32(a.QuantityDefectiveProfile),
                            GeneralQuantityDefectiveProfile = a.GeneralQuantityDefectiveProfile,
                            GeneralAreaDefectiveProfile = Convert.ToDouble(a.GeneralAreaDefectiveProfile)
                        }).Distinct();
            List<ShotBlastingProfileSummaryTable> listSummaryTable = new List<ShotBlastingProfileSummaryTable>();
            listSummaryTable = query.AsEnumerable().OrderBy(p=>p.Date).ToList();
            return listSummaryTable;
        }
        public List<ShotBlastingProfile> GetNumberSpecificationAndClient(string number, string client)
        {
            List<ShotBlastingProfile> list = new List<ShotBlastingProfile>();
            list = Table.Where(p => p.NumberSpecification == number && p.ClientName == client).ToList();
            return list;
        }
    }
}