using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IProfileConsumptionWarehouseGeneralRepository : IBaseRepository<ProfileConsumptionWarehouseGeneral>
    {
        bool CheckValueProfileConsumptionWarehouse(string number);

        void UpdateConsumptionWarehouseProfile(string number, double weightProduced, double weightDefected, double areaProduced, double areaDefected);
        ProfileConsumptionWarehouseGeneral GetEntityProfileConsumptionWarehouse(string number);
        int CheckValueProfileConsumptionWarehouseDayShift(DateTime date);
    }
}