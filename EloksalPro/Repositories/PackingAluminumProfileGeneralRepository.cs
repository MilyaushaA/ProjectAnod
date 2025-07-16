using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
  public  class PackingAluminumProfileGeneralRepository : BaseRepo<PackingAluminumProfileGeneral>, IPackingAluminumProfileGeneralRepository
    {
        public bool CheckValuePackingAluminumProfileGeneral(string number)
        {
            bool checkValue = Table.Any(p => p.NumberPackingAluminumProfile == number);
            return checkValue;
        }
        public int CheckValuePackingAluminumProfileDayShift(DateTime date)
        {
            var countValue = Table.Where(g => DbFunctions.TruncateTime(g.Date) == date.Date).ToList();
            int countShift = countValue.Count;
            if (countValue != null)
            {
                return countShift;
            }
            else
                return 0;
        }
        public PackingAluminumProfileGeneral GetListPacking(string number)
        {
            PackingAluminumProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberPackingAluminumProfile == number);
            return myEntity;
        }
        public void UpdatePackingAluminum(string number, double weightProduced, double weightDefected, double areaProduced, double? areaDefected)
        {
            PackingAluminumProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberPackingAluminumProfile == number);
            if (myEntity != null)
            {
                myEntity.WeightProducedProfile= weightProduced;
                myEntity.WeightDefectedProfile = weightDefected;
                myEntity.GeneralAreaProducedProfile= areaProduced;
                myEntity.GeneralAreaDefectiveProfile = areaDefected;
                Context.SaveChanges();
            }
        }
        public PackingAluminumProfileGeneral GetListProducedPackingAluminum(string number)
        {
            PackingAluminumProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberPackingAluminumProfile == number);
            return myEntity;
        }
        public List<PackingAluminumProfileGeneral> GetPackingAluminumProfileGeneral()
        {
            List<PackingAluminumProfileGeneral> list = Table.ToList();
            return list;
        }
    }
}
