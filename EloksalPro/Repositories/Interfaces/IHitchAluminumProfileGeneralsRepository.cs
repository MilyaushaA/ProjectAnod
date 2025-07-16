using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloksalPro.Models;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IHitchAluminumProfileGeneralsRepository : IBaseRepository<HitchAluminumProfileGeneral>
    {
        bool CheckValueHitchAluminumProfile(string hitchAluminumProfile);
        void UpdateHitchAluminumProfile(string numHitcGeneral, double weightProduced, double weightDefect, double areaProduced, double areaDefected);
        HitchAluminumProfileGeneral GetWeightProduced(string numHitchAluminumProfile);
        int CheckValueHitchAluminumProfileDayShift(DateTime date);
    }
    
}
