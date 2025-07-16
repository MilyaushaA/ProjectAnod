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
   public class ShotBlastingProfilesGeneralsRepository:BaseRepo<ShotBlastingProfilesGeneral>, IShotBlastingProfilesGeneralsRepository
    {
        public bool CheckValueShotBlasting(string shotBlasting)
        {
            bool checkValue = Table.Any(p => p.NumberShotGeneral==shotBlasting);
            return checkValue;
        }
        public int CheckValueShotBlastingDayShift(DateTime date)
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
        public int MaxNumberShotBlasting()
        {
            List<ShotBlastingProfilesGeneral> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberShotGeneral).ToList();
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
        public void UpdateWeightDefectiveProducedProfile(string numShotGeneral, double weightProduced, double weightDefective, double areaProduced, double areaDefective)
        {
            ShotBlastingProfilesGeneral myEntity = Table.FirstOrDefault(p => p.NumberShotGeneral == numShotGeneral);
            if (myEntity != null)
            {
                myEntity.GeneralQuantityDefectiveProfile = weightDefective;
                myEntity.GeneralQuantityProducedProfile = weightProduced;
                myEntity.GeneralAreaProducedProfile = areaProduced;
                myEntity.GeneralAreaDefectiveProfile = areaDefective;
               
                Context.SaveChanges();
            }
        }
        public void UpdateShotBlastingProfilesGeneral(int id, int downtime)
        {
            ShotBlastingProfilesGeneral myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.Downtime = downtime;
                Context.SaveChanges();
            }
        }
        public double GetWeightDefective(string numShotGeneral)
        {
            ShotBlastingProfilesGeneral myEntity = Table.FirstOrDefault(p => p.NumberShotGeneral == numShotGeneral);
            double weight = 0;
            weight = myEntity.GeneralQuantityDefectiveProfile;
            return weight;
        }
        public double GetWeightProduced(string numShotGeneral)
        {
            ShotBlastingProfilesGeneral myEntity = Table.FirstOrDefault(p => p.NumberShotGeneral == numShotGeneral);
            double weight = 0;
            weight = myEntity.GeneralQuantityProducedProfile;
            return weight;
        }
        public double GetAreaProduced(string numShotGeneral)
        {
            ShotBlastingProfilesGeneral myEntity = Table.FirstOrDefault(p => p.NumberShotGeneral == numShotGeneral);
            double area = 0;
            area = myEntity.GeneralAreaProducedProfile;
            return area;
        }
        public double GetAreaDefective(string numShotGeneral)
        {
            ShotBlastingProfilesGeneral myEntity = Table.FirstOrDefault(p => p.NumberShotGeneral == numShotGeneral);
            double area = 0;
            area = myEntity.GeneralAreaDefectiveProfile;
            return area;
        }
        public List<ShotBlastingProfilesGeneral> GetShotBlastingProfilesGeneral()
        {
            List<ShotBlastingProfilesGeneral> list = Table.ToList();
            return list;
        }
        public int GetDowntime(DateTime date,string shift)
        {
            ShotBlastingProfilesGeneral myEntity = Table.FirstOrDefault(p => p.Date == date && p.Shift==shift);
            int min = 0;
            if (myEntity != null)
            {
                min = myEntity.Downtime;
              
            }
            return min;
        }
    }
}
