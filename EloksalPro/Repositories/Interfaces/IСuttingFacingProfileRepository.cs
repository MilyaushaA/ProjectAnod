using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IСuttingFacingProfileRepository: IBaseRepository<СuttingFacingProfile>
    {
        int MaxNumberСuttingFacingProfile();
        List<string> GetNumberSpecificationCuttingTapeProtective();
        ObservableCollection<СuttingFacingProfile> GetAllEntity(string cuttingFacingProfile);
        List<string> GetNumberSpecificationСutting();
        List<string> GetNomenclatureСutting(string numberSpecification);
        List<ForPivotTableСuttingFacingProfile> GetForPivotTableСuttingFacingProfile();
        void UpdateСuttingFacingProfileProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile);
        void UpdateСuttingFacingProfileProfileReadinessProfile(int id, bool readinessProfile);
        List<СuttingFacingProfile> GetListСuttingFacingProfile(string nomenclature, string numberSpecification);
        List<СuttingFacingProfileReport> GetСuttingFacingProfileReport(DateTime date, string shift);
        List<СuttingFacingProfileSummaryTable> GetСuttingFacingGeneralProfileSummaryTable();
        List<string> GetNomenclatureTapeProtective(string numberSpecification);

    }
}
