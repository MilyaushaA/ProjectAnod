using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface IReceptionMaterialsRepository:IBaseRepository<ReceptionMaterials>
    {
        void UpdateReceptionMaterials(int id, DateTime date, string shift, string userName, string annotation,double massa);
        bool CheckValueNumberSpecification(string checkNumberSpecification);
        void UpdateReceptionMaterials(string num, double massa);
        void UpdateReceptionMaterials(int id, string numSpecification);
        void UpdateReceptionMaterialsWeight(string numSpecification, double weight);
        double GetWeightShippedProduction(string numSpecification);
        double GetTotalSumWeight(string numSpecification);
        DateTime? DateReception(string numberSpecification);
        List<DateTime?> DateReception();
    }
}
