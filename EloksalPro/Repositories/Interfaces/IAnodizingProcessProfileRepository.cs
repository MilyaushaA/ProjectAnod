using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
     public  interface IAnodizingProcessProfileRepository: IBaseRepository<AnodizingProcessProfile>
    {
        int MaxNumberAnodizingProcess();
        ObservableCollection<AnodizingProcessProfile> GetAllEntity(string anodizingProcess);
        List<string> GetNomenclature(string numberSpecification);
        List<string> GetNumberSpecification();
        List<string> GetNumberSpecificationСuttingFacing();
        List<string> GetNomenclatureCutting(string numberSpecification);
        List<string> GetNumberSpecificationPacking();
        List<string> GetNomenclaturePacking(string numberSpecification);
        List<ForPivotTableAnodizingProcessProfile> GetForPivotTableAnodizingProcessProfile();
        void UpdateAnodizingProcessProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile);
        void UpdateAnodizingProcessProfileReadinessProfile(int id, bool readinessProfile);
        List<AnodizingProcessProfile> GetListAnodizingProcess(string nomenclature, string numberSpecification);
        int GetCountNomenclature(string numberSpecification, string nomenclature);
        int GetCountNomenclatureDefective(string numberSpecification, string nomenclature);
        List<AnodizingProcessProfileReport> GetAnodizingProcessProfileReport(DateTime date, string shift);
        List<AnodizingProcessProfile> GetNumberSpecificationAndClient(string number, string client);
    }
}
