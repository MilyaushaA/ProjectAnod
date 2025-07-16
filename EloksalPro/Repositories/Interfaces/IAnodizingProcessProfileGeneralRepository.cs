using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IAnodizingProcessProfileGeneralRepository: IBaseRepository<AnodizingProcessProfileGeneral>
    {
        bool CheckValueAnodizingProcessProfile(string number);
        AnodizingProcessProfileGeneral GetWeightProduced(string number);
        void UpdateAnodizingAluminumProfile(string number, double weightProduced, double weightDefected, double areaProduced, double areaDefected);
        int CheckValueAnodizingProcessProfileDayShift(DateTime date);
        void UpdateAnodizingProcessProfileGeneral(int id, int downtime);
        int GetDowntime(DateTime date, string shift);
    }
}
