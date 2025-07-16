using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IHitchAluminumProfilesRepository : IBaseRepository<HitchAluminumProfile>
    {
        ObservableCollection<HitchAluminumProfile> GetAllEntity(string shotBlasting);
        List<string> GetNomenclature(string numberSpecification);
        int MaxNumberShotBlasting();
        List<string> GetNumberSpecification();
        HitchAluminumProfile GetListHitchAluminumProfile(int id);
        List<ForPivotTableHitchAluminumProfile> GetForPivotTableHitchAluminumProfile();
        double GetWeightNomenclature(string numberSpecification, string nomenclature);
        double GetWeightNomenclatureDefective(string numberSpecification, string nomenclature);
        void UpdateHitchAluminumProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile);
    }
}
