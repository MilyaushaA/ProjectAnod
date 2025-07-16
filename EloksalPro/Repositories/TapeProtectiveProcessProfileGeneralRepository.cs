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
   public class TapeProtectiveProcessProfileGeneralRepository:BaseRepo<TapeProtectiveProcessProfileGeneral>, ITapeProtectiveProcessProfileGeneralRepository
    {
        public bool CheckValueTapeProtectiveProcessProfile(string number)
        {
            bool checkValue = Table.Any(p => p.NumberTapeProtectiveProcess == number);
            return checkValue;
        }
        public int CheckValueTapeProtectiveProcessProfileDayShift(DateTime date)
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
        public TapeProtectiveProcessProfileGeneral GetWeightProduced(string number)
        {
            TapeProtectiveProcessProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberTapeProtectiveProcess == number);
            return myEntity;
        }
        public void UpdateTapeProtectiveAluminumProfile(string number, double weightProduced, double weightDefected, double areaProduced,
                                                        double areaDefected, double consumptionProtectiveFilm)
        {
            TapeProtectiveProcessProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberTapeProtectiveProcess == number);
            if (myEntity != null)
            {
                myEntity.GeneralQuantityProducedProfile = weightProduced;
                myEntity.GeneralQuantityDefectedProfile = weightDefected;
                myEntity.GeneralAreaProducedProfile = areaProduced;
                myEntity.GeneralAreaDefectiveProfile= areaDefected;
                myEntity.ConsumptionProtectiveFilm = consumptionProtectiveFilm;
                Context.SaveChanges();
            }
        }
        public List<TapeProtectiveProcessProfileGeneral> GetTapeProtectiveProcessProfileGeneral()
        {
            List<TapeProtectiveProcessProfileGeneral> list = Table.ToList();
            return list;
        }
    }
}
