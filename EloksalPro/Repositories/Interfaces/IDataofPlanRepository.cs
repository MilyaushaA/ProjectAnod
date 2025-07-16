using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IDataofPlanRepository
    {
        double? GetWeight(DateTime? date);
        List<DataPlanProfileGenaral> GetGeneralDataUpload();
    }
}
