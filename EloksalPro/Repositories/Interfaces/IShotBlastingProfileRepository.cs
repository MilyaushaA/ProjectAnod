using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IShotBlastingProfileRepository:IBaseRepository<ShotBlastingProfile>
    {
        ObservableCollection<ShotBlastingProfile> GetAllEntity(string shotBlasting);
        List<string> GetNumberSpecification();
        List<string> GetNomenclature(string numberSpecification);
       
        List<ForPivotTableShotBlastingProfile> GetForPivotTableShotBlastingProfile();
        double GetWeightNomenclature(string numberSpecification, string nomenclature);
        double GetWeightNomenclatureDefective(string numberSpecification, string nomenclature);
        void UpdateShotBlastingProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile);
        void UpdateShotBlastingProfileReadinessProfile(int id, bool readinessProfile);
        List<ShotBlastingProfile> GetListShotBlastingProfile(string nomenclature, string numberSpecification);
        int? GetCountNomenclature(string numberSpecification, string nomenclature);
        int? GetCountNomenclatureDefective(string numberSpecification, string nomenclature);
        List<ShotBlastingProfileReport> GetShotBlastingProfileReport(DateTime date, string shift);
        List<ShotBlastingProfileSummaryTable> GetShotBlastingProfileSummaryTable();
        List<ShotBlastingProfile> GetNumberSpecificationAndClient(string number, string client);

    }
}
