using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IShotBlastingProfilesGeneralsRepository:IBaseRepository<ShotBlastingProfilesGeneral>
    {
        bool CheckValueShotBlasting(string shotBlasting);
        int MaxNumberShotBlasting();
        void UpdateWeightDefectiveProducedProfile(string numShotGeneral, double weightProduced, double weightDefective, double areaProduced, double areaDefective);
        double GetWeightDefective(string numShotGeneral);
        double GetWeightProduced(string numShotGeneral);
        double GetAreaProduced(string numShotGeneral);
        double GetAreaDefective(string numShotGeneral);
        int CheckValueShotBlastingDayShift(DateTime date);
        void UpdateShotBlastingProfilesGeneral(int id, int downtime);
        int GetDowntime(DateTime date, string shift);
    }
}
