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
   public class AnodizingProcessProfileGeneralRepository:BaseRepo<AnodizingProcessProfileGeneral>, IAnodizingProcessProfileGeneralRepository
    {
        public bool CheckValueAnodizingProcessProfile(string number)
        {
            bool checkValue = Table.Any(p => p.NumberAnodizingProcess == number);
            return checkValue;
        }
        public int CheckValueAnodizingProcessProfileDayShift(DateTime date)
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
        public AnodizingProcessProfileGeneral GetWeightProduced(string number)
        {
            AnodizingProcessProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberAnodizingProcess == number);
            return myEntity;
        }
        public void UpdateAnodizingAluminumProfile(string number, double weightProduced, double weightDefected, double areaProduced, double areaDefected)
        {
            AnodizingProcessProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberAnodizingProcess == number);
            if (myEntity != null)
            {
                myEntity.GeneralQuantityProducedProfile = weightProduced;
                myEntity.GeneralQuantityDefectedProfile = weightDefected;
                myEntity.GeneralAreaProducedProfile= areaProduced;
                myEntity.GeneralAreaDefectiveProfile = areaDefected;
                Context.SaveChanges();
            }
        }
        public void UpdateAnodizingProcessProfileGeneral(int id, int downtime)
        {
            AnodizingProcessProfileGeneral myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.Downtime = downtime;
                Context.SaveChanges();
            }
        }
        public List<AnodizingProcessProfileGeneral> GetAnodizingProcessProfileGeneral()
        {
            List<AnodizingProcessProfileGeneral> list = Table.ToList();
            return list;
        }
        public int GetDowntime(DateTime date, string shift)
        {
            AnodizingProcessProfileGeneral myEntity = Table.FirstOrDefault(p => p.Date == date && p.Shift == shift);
            int min = 0;
            if (myEntity != null)
            {
                min = myEntity.Downtime;

            }
            return min;
        }
    }
}
