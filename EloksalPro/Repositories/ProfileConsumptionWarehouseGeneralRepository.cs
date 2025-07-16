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
   public class ProfileConsumptionWarehouseGeneralRepository : BaseRepo<ProfileConsumptionWarehouseGeneral>, IProfileConsumptionWarehouseGeneralRepository
    {
        public bool CheckValueProfileConsumptionWarehouse(string number)
        {
            bool checkValue = Table.Any(p => p.NumberProfileConsumptionWarehouse == number);
            return checkValue;
        }
        public int CheckValueProfileConsumptionWarehouseDayShift(DateTime date)
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
        public void UpdateConsumptionWarehouseProfile(string number, double weightProduced, double weightDefected, double areaProduced, double areaDefected)
        {
            ProfileConsumptionWarehouseGeneral myEntity = Table.FirstOrDefault(p => p.NumberProfileConsumptionWarehouse == number);
            if (myEntity != null)
            {
                myEntity.WeightProducedProfile = weightProduced;
                myEntity.WeightDefectedProfile = weightDefected;
                myEntity.GeneralAreaProducedProfile = areaProduced;
                myEntity.GeneralAreaDefectiveProfile = areaDefected;
                Context.SaveChanges();
            }
        }
        public ProfileConsumptionWarehouseGeneral GetEntityProfileConsumptionWarehouse(string number)
        {
            ProfileConsumptionWarehouseGeneral myEntity = Table.FirstOrDefault(p => p.NumberProfileConsumptionWarehouse == number);
            return myEntity;
        }
   

    }
}
