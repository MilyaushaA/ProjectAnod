using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
  public  interface ITapeProtectiveProcessProfileGeneralRepository:IBaseRepository<TapeProtectiveProcessProfileGeneral>
    {
       bool CheckValueTapeProtectiveProcessProfile(string number);
       TapeProtectiveProcessProfileGeneral GetWeightProduced(string number);
       void UpdateTapeProtectiveAluminumProfile(string number, double weightProduced, double weightDefected, double areaProduced,
                                                         double areaDefected, double consumptionProtectiveFilm);
       int CheckValueTapeProtectiveProcessProfileDayShift(DateTime date);
       List<TapeProtectiveProcessProfileGeneral> GetTapeProtectiveProcessProfileGeneral();
    }
}
