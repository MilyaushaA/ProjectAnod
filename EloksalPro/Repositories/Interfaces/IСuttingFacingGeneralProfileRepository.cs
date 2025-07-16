using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IСuttingFacingGeneralProfileRepository:IBaseRepository<СuttingFacingGeneralProfile>
    {
       bool CheckValueСuttingFacingGeneralProfile(string number);
       СuttingFacingGeneralProfile GetListProducedСuttingFacing(string number);
       void UpdateСuttingFacingProfile(string number, double weightProducedAfter, double weightProducedBefore,double weightProducedDefect,
                                                        double areaProducedBefore, double areaProducedDefect, double weightTechnologicalWaste);
       int CheckValueСuttingFacingGeneralProfileDayShift(DateTime date);
        List<СuttingFacingGeneralProfile> GetСuttingFacingGeneralProfile();
    }
}
