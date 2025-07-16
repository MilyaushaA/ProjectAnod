using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface ILaboratoryAnalysisRepository : IBaseRepository<LaboratoryAnalysis>
    {
        void UpdateDataLaboratoryAnalysis(LaboratoryAnalysis entity, DateTime? date);
        ObservableCollection<LaboratoryAnalysis> GetByAllEntityObservableCollection();
        int MaxNumberLaboratoryAnalysis();
    }
}
