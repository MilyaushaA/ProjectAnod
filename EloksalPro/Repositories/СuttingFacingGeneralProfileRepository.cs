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
  public  class СuttingFacingGeneralProfileRepository:BaseRepo<СuttingFacingGeneralProfile>, IСuttingFacingGeneralProfileRepository
    {
        public bool CheckValueСuttingFacingGeneralProfile(string number)
        {
            bool checkValue = Table.Any(p => p.NumberСuttingFacing == number);
            return checkValue;
        }
        public int CheckValueСuttingFacingGeneralProfileDayShift(DateTime date)
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
        public СuttingFacingGeneralProfile GetListProducedСuttingFacing(string number)
        {
            СuttingFacingGeneralProfile myEntity = Table.FirstOrDefault(p => p.NumberСuttingFacing == number);
            return myEntity;
        }
        public void UpdateСuttingFacingProfile(string number, double weightProducedAfter, double weightProducedBefore,
            double weightProducedDefect, double areaProducedBefore, double areaProducedDefect,double weightTechnologicalWaste)
        {
            СuttingFacingGeneralProfile myEntity = Table.FirstOrDefault(p => p.NumberСuttingFacing == number);
            if (myEntity != null)
            {
                myEntity.GeneralQuantityProducedProfileAfter = weightProducedAfter;
                myEntity.GeneralQuantityProducedProfileBefore = weightProducedBefore;
                myEntity.GeneralQuantityProducedProfileDefect = weightProducedDefect;
                myEntity.GeneralAreaProducedProfile= areaProducedBefore;
                myEntity.GeneralAreaDefectiveProfile = areaProducedDefect;
                myEntity.GeneralWeightTechnologicalWaste = weightTechnologicalWaste;
                Context.SaveChanges();
            }
        }
        public List<СuttingFacingGeneralProfile> GetСuttingFacingGeneralProfile()
        {
            List<СuttingFacingGeneralProfile> list = Table.ToList();
            return list;
        }
    }
}
