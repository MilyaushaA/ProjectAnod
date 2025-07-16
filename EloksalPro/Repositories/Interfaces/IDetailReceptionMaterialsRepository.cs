using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IDetailReceptionMaterialsRepository:IBaseRepository<DetailReceptionMaterials>
    {
       DateTime maxDate();
       bool CheckValueId(int id);
       bool CheckValue(string numSpecification, string nomenclature);
       List<DetailReceptionMaterials> GetByAllEntityCollection(string numberSpecification);
       void UpdateReceptionDetailMaterials(string numberSpecification, string numberProfile, int amount, int lenght);
       void UpdateReceptionDetailMaterials(int id, int amount, int lenght, DateTime? date, bool ReadinessProfile);
       void RemoveIdSpecificatoin(string nomenclature, string numberSpecification);
       List<string> GetNumberSpecificationShotBlasting();
       List<string> GetOrderNumber(string numberSpecification);  
       int GetLenghtFact(string orderNumber,string numberSpecificationSource);
       //int GetLenghtFactNomenclature(string nomenclature);
       double GetWeightMeter(string orderNumber);
       List<string> GetNumberSpecification();
       List<string> GetNomenclatureDetailReception(string numberSpecification);
       List<string> GetOrderNomenclature(string numberSpecification);
       List<ForPivotTableDetailReceptionMaterials> GetForPivotTableDetailReceptionMaterials();
       List<ForPivotTableDetailReceptionMaterialsTwo> GetForPivotTableDetailReceptionMaterialsTwo();
       void UpdateReceptionDetailMaterials(int id, DateTime? date);
       double GetWeightReceptionMaterials(string numberSpecification, string nomenclature);
       int GetCountReceptionMaterials(string numberSpecification, string nomenclature);
    }
}
