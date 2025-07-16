using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IPackingAluminumProfileGeneralRepository:IBaseRepository<PackingAluminumProfileGeneral>
    {
        bool CheckValuePackingAluminumProfileGeneral(string number);
        PackingAluminumProfileGeneral GetListPacking(string number);
        void UpdatePackingAluminum(string number, double weightProduced, double weightDefected, double areaProduced, double? areaDefected);
        int CheckValuePackingAluminumProfileDayShift(DateTime date);
        PackingAluminumProfileGeneral GetListProducedPackingAluminum(string number);
        List<PackingAluminumProfileGeneral> GetPackingAluminumProfileGeneral();
    }
}
