using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface ITapeProtectiveProcessProfileRepository:IBaseRepository<TapeProtectiveProcessProfile>
    {
        int MaxNumberTapeProtectiveProcess();
        ObservableCollection<TapeProtectiveProcessProfile> GetAllEntity(string nameTapeProtective);
        List<string> GetNumberSpecificationCutting();
        List<string> GetNomenclatureCutting(string numberSpecification);
        List<string> GetNumberSpecificationPacking();
        List<string> GetNomenclaturenPacking(string numberSpecification);
        List<ForPivotTableTapeProtectiveProcessProfile> GetForPivotTableTapeProtectiveProcessProfile();
        double GetWeightNomenclature(string numberSpecification, string nomenclature);
        double GetWeightNomenclatureDefective(string numberSpecification, string nomenclature);
        void UpdateTapeProtectiveProcessProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile);
        int? GetCountNomenclature(string numberSpecification, string nomenclature);
        int? GetCountNomenclatureDefective(string numberSpecification, string nomenclature);
        List<TapeProtectiveProcessProfileReport> GetTapeProtectiveProcessProfileReport(DateTime date, string shift);
        List<TapeProtectiveProcessProfile> GetListTapeProtectiveProcessProfile(string nomenclature, string numberSpecification);

    }
}
