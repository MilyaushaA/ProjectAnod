using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IPackingAluminumProfileRepository : IBaseRepository<PackingAluminumProfile>
    {
       int MaxNumberPackingProfile();
       ObservableCollection<PackingAluminumProfile> GetAllEntity(string packingProfile);
       List<string> GetNumberSpecification();
       List<string> GetNomenclature(string numberSpecification);
       List<ForPivotTablePackingAluminumProfile> GetForPivotTablePackingAluminumProfile();
       double GetWeightNomenclature(string numberSpecification, string nomenclature);
       double GetWeightNomenclatureDefective(string numberSpecification, string nomenclature);
       void UpdatePackingAluminumProfileProfileReadinessProfile(string nomenclature, string numberSpecification, bool readinessProfile);
       void UpdatePackingAluminumProfileProfileReadinessProfile(int id, bool readinessProfile);
       List<PackingAluminumProfile> GetListPackingAluminumProfile(string nomenclature, string numberSpecification);
       int? GetAmountNomenclature(string numberSpecification, string nomenclature);
       List<PackingAluminumProfileReport> GetPackingAluminumProfileReport(DateTime date, string shift);
       List<string> GetBasketNumber(string nomenclatureProfile);
       List<string> GetNumberBasket();
       List<PackingAluminumProfileForShipment> GetByPackingAluminumProfileForShipment();
    }
}
