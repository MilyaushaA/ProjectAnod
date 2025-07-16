using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
   public class DetailReceptionMaterialsRepository: BaseRepo<DetailReceptionMaterials>, IDetailReceptionMaterialsRepository
    {
        public DateTime maxDate()
        {
            DateTime? date = Table.Max(r => r.DateShipment);
            if (date != null)
            {
                return Convert.ToDateTime(date);
            }
           else
            {
              return  DateTime.Now;
            }
        }
        public bool CheckValueId(int id)
        {
            bool checkValue = Table.Any(p => p.SpecificationAllDescriptionsId == id);
            return checkValue;
        }
        public bool CheckValue(string numSpecification, string nomenclature)
        {
            bool checkValue = Table.Any(p => p.NumberSpecification == numSpecification && p.NomenclatureProfile == nomenclature);
            return checkValue;
        }
        public List<DetailReceptionMaterials> GetByAllEntityCollection(string numberSpecification)
        {
            List<DetailReceptionMaterials> list = new List<DetailReceptionMaterials>();
            var inventory = Table.Where(p => p.NumberSpecification == numberSpecification.TrimEnd()).ToList();
            list = new List<DetailReceptionMaterials>(inventory);
            return list;
        }
        public void UpdateReceptionDetailMaterials(string numberSpecification, string numberProfile,int amount, int lenght)
        {
            DetailReceptionMaterials myEntity = Table.FirstOrDefault(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == numberProfile);
            if (myEntity != null)
            {
                myEntity.LenghtFact = lenght;
                myEntity.AmountPieceFact = amount;
                //myEntity.DateReception = date;
                Context.SaveChanges();
            }
        }
        public void UpdateReceptionDetailMaterials(int id, int amount, int lenght, DateTime ? date, bool ReadinessProfile)
        {
            DetailReceptionMaterials myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.LenghtFact = lenght;
                myEntity.AmountPieceFact = amount;
                myEntity.DateReception = date;
                myEntity.ReadinessProfile = ReadinessProfile;
                Context.SaveChanges();
            }
        }
        public void UpdateReceptionDetailMaterials(int id, DateTime? date)
        {
            DetailReceptionMaterials myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.DateShipment = date;
                Context.SaveChanges();
            }
        }
        public void UpdateReceptionDetailMaterialsReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile)
        {
            DetailReceptionMaterials myEntity = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature && p.NumberSpecification== numberSpecification);
            if (myEntity != null)
            {
                myEntity.ReadinessProfile = readinessProfile;
                Context.SaveChanges();
            }
        }
        public void RemoveIdSpecificatoin(string numberSpecification,string nomenclature)
        {
            var list = Table.FirstOrDefault(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            Table.Remove(list);
            Context.SaveChanges();
        }
        public List<string> GetNumberSpecificationShotBlasting()
        {
            ReceptionMaterialsRepository repos = new ReceptionMaterialsRepository();
  
            List<DateTime?> date = new List<DateTime?>();
            date = repos.DateReception();
            List<string> list = new List<string>();
            if (date.Count>0)
            {
                string substr1 = "AD";
                list = Table.Where(p => p.NomenclatureProfile.Contains(substr1) && p.DateReception!=null && p.ReadinessProfile==false).Select(p => p.NumberSpecification).Distinct().ToList();
            }
            return list;
        }    
        public List<string> GetOrderNumber(string numberSpecification)
        {
            ReceptionMaterialsRepository repos = new ReceptionMaterialsRepository();
            DateTime? date = new DateTime();
            date = repos.DateReception(numberSpecification);
            List<string> list = new List<string>();
            if (date != null)
            {
                string substr1 = "AD";
                list = Table.Where(p => p.NomenclatureProfile.Contains(substr1) && p.NumberSpecification == numberSpecification && p.ReadinessProfile==false).Select(p => p.NomenclatureProfile).ToList(); 
            }
            return list;
        }   
        public int GetLenghtFact(string nomenclature, string numberSpecification)
        {
            int lenght;
            var list = Table.FirstOrDefault(p => p.NomenclatureProfile.TrimEnd() == nomenclature.TrimEnd() && p.NumberSpecification.TrimEnd() == numberSpecification.TrimEnd());
            lenght = list.LenghtFact;
            return lenght;
        }
        //public int GetLenghtFactNomenclature(string nomenclature)
        //{
        //    int lenght;
        //    var list = Table.FirstOrDefault(p => p.NomenclatureProfile.TrimEnd() == nomenclature.TrimEnd());
        //    lenght = list.LenghtFact;
        //    return lenght;
        //}
        public double GetWeightMeter(string nomenclature)
        {
            double weightMeter;
            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            weightMeter = list.WeightMeter;
            return weightMeter;
        }
        public double GetWeightReceptionMaterials(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            double weightReception = 0;
            if (list.Any())
            {
                weightReception = list.Sum(x => x.AmountPieceFact*x.LenghtFact*x.WeightMeter / 1000000);
            }
            return weightReception;
        }
        public int GetCountReceptionMaterials(string numberSpecification, string nomenclature)
        {
            var list = Table.Where(p => p.NumberSpecification == numberSpecification && p.NomenclatureProfile == nomenclature);
            int countReception = 0;
            if (list.Any())
            {
                countReception = list.Sum(x => x.AmountPieceFact);
            }
            return countReception;
        }
        public List<string> GetNumberSpecification()
        {
            ReceptionMaterialsRepository repos = new ReceptionMaterialsRepository();
            List<DateTime?> date = new List<DateTime?>();
            date = repos.DateReception();
            List<string> list = new List<string>();
            if (date.Count > 0)
            {
                list = Table.Where(p => !p.NomenclatureProfile.Contains("AD") && p.NomenclatureProfile.Contains("A") && p.DateReception!=null && p.ReadinessProfile==false).Select(p => p.NumberSpecification).Distinct().ToList();
            }
            return list;           
        }
        public List<string> GetNumberSpecificationTapeProtective()
        {
            ReceptionMaterialsRepository repos = new ReceptionMaterialsRepository();
            List<DateTime?> date = new List<DateTime?>();
            date = repos.DateReception();
            List<string> list = new List<string>();
            if (date.Count > 0)
            {
                list = Table.Where(p => !p.NomenclatureProfile.Contains("AD") && !p.NomenclatureProfile.Contains("A") && p.NomenclatureProfile.Contains("P")
                                        && p.DateReception != null && p.ReadinessProfile == false).Select(p => p.NumberSpecification).Distinct().ToList();
            }
            return list;
        }
        public List<string> GetNumberSpecificationCuttingFacing()
        {
            ReceptionMaterialsRepository repos = new ReceptionMaterialsRepository();
            List<DateTime?> date = new List<DateTime?>();
            date = repos.DateReception();
            List<string> list = new List<string>();
            if (date.Count > 0)
            {
                list = Table.Where(p => !p.NomenclatureProfile.Contains("AD") && !p.NomenclatureProfile.Contains("A") && (p.NomenclatureProfile.Contains("R")
                                        || p.NomenclatureProfile.Contains("T")) && p.DateReception != null && p.ReadinessProfile == false).Select(p => p.NumberSpecification).Distinct().ToList();
            }
            return list;
        }
        public List<string> GetNomenclatureDetailReceptionTapeProtective(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => !p.NomenclatureProfile.Contains("AD") 
                   && !p.NomenclatureProfile.Contains("A") && p.NomenclatureProfile.Contains("P")
                   && p.DateReception != null && p.ReadinessProfile == false && p.NumberSpecification == numberSpecification)
                  .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclatureDetailReceptionCuttingFacing(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => !p.NomenclatureProfile.Contains("AD") && !p.NomenclatureProfile.Contains("A") && (p.NomenclatureProfile.Contains("R") && p.NumberSpecification == numberSpecification
                  || p.NomenclatureProfile.Contains("T")) && p.DateReception != null && p.ReadinessProfile == false)
                  .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetNomenclatureDetailReception(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => !p.NomenclatureProfile.Contains("AD") && p.DateReception != null && p.ReadinessProfile == false && p.NumberSpecification== numberSpecification)
                  .Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public List<string> GetOrderNomenclature(string numberSpecification)
        {
            List<string> list = new List<string>();
            list = Table.Where(p => p.NumberSpecification == numberSpecification).Select(p => p.NomenclatureProfile).ToList();
            return list;
        }
        public List<ForPivotTableDetailReceptionMaterials> GetForPivotTableDetailReceptionMaterials()
        {
            List <ForPivotTableDetailReceptionMaterials> list= new List<ForPivotTableDetailReceptionMaterials>();
            list = Table
                 .GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile,p.DateReception,p.DateShipment})
                 .Select(g => new ForPivotTableDetailReceptionMaterials
                 {
                     NumberSpecification = g.Key.NumberSpecification,
                     NomenclatureProfile = g.Key.NomenclatureProfile,
                     DateReception= g.Key.DateReception,
                     DateShipment=g.Key.DateShipment,
                     AmountPieceReceptionAccepted = g.Sum(p => p.AmountPieceFact),
                     LenghtReceptionAccepted = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceFact))/1000.00,
                     WeightReceptionAccepted = g.Sum(p => p.LenghtFact * p.WeightMeter * g.Sum(f => f.AmountPieceFact)) / 1000000,
                 }).ToList();
            return list;
        }
        public List<ForPivotTableDetailReceptionMaterialsTwo> GetForPivotTableDetailReceptionMaterialsTwo()
        {
            List<ForPivotTableDetailReceptionMaterialsTwo> list = new List<ForPivotTableDetailReceptionMaterialsTwo>();
            list = Table
                 .GroupBy(p => new { p.NumberSpecification, p.NomenclatureProfile, p.DateReception, p.DateShipment })
                 .Select(g => new ForPivotTableDetailReceptionMaterialsTwo
                 {
                     NumberSpecification = g.Key.NumberSpecification,
                     GeneralNomenclatureProfile = g.Key.NomenclatureProfile,
                     DateReception = g.Key.DateReception,
                     DateShipment = g.Key.DateShipment,
                     AmountPieceReceptionAccepted = g.Sum(p => p.AmountPieceFact),
                     LenghtReceptionAccepted = g.Sum(p => p.LenghtFact * g.Sum(f => f.AmountPieceFact)) / 1000.00,
                     WeightReceptionAccepted = g.Sum(p => p.LenghtFact * p.WeightMeter * g.Sum(f => f.AmountPieceFact)) / 1000000,
                 }).ToList();
            return list;
        }
        public List<String> GetNumberSpecificationClient()
        {
            List<String> list = new List<String>();
            list = Table.Select(p => p.NumberSpecification).ToList();
            return list;
        }
        public string GetClient(string numberSpecification)
        {
            var list = Table.FirstOrDefault(p => p.NumberSpecification == numberSpecification);
            if (list != null)
            {
                return list.ClientName;
            }
            return String.Empty;
        }
    }
}
