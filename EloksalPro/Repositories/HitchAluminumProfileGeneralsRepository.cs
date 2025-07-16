using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
   public class HitchAluminumProfileGeneralsRepository : BaseRepo<HitchAluminumProfileGeneral>, IHitchAluminumProfileGeneralsRepository
    {
        public bool CheckValueHitchAluminumProfile(string hitchAluminumProfile)
        {
            bool checkValue = Table.Any(p => p.NumberHitchGeneral == hitchAluminumProfile);
            return checkValue;
        }
        public int CheckValueHitchAluminumProfileDayShift(DateTime date)
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
        public void UpdateHitchAluminumProfile(string numHitcGeneral, double weightProduced, double weightDefect, double areaProduced, double areaDefected)
        {
            HitchAluminumProfileGeneral myEntity = Table.FirstOrDefault(p => p.NumberHitchGeneral==numHitcGeneral);
            if (myEntity != null)
            {
                myEntity.GeneralQuantityProducedProfile = weightProduced;
                myEntity.GeneralQuantityDefectedProfile = weightDefect;
                myEntity.GeneralAreaProducedProfile= areaProduced;
                myEntity.GeneralAreaDefectiveProfile = areaDefected;
                Context.SaveChanges();
            }
        }
        public HitchAluminumProfileGeneral GetWeightProduced(string numHitchAluminumProfile)
        {
            HitchAluminumProfileGeneral  myEntity = Table.FirstOrDefault(p => p.NumberHitchGeneral== numHitchAluminumProfile);
            return myEntity;
        }
    }
}
