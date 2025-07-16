using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IProfileConsumptionWarehouseRepository : IBaseRepository<ProfileConsumptionWarehouse>
    {
       int MaxNumberProfileConsumptionWarehouse();
       ObservableCollection<ProfileConsumptionWarehouse> GetAllEntity(string anodizingProcess);
       List<ForPivotTableProfileConsumptionWarehouse> GetForPivotTableProfileConsumptionWarehouse();
       List<ProfileConsumptionWarehouse> GetListAllEntity(string anodizingProcess);
       List<String> GetListBasketNumber();
    }
}
