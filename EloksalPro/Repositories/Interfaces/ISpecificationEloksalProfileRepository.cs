using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface ISpecificationEloksalProfileRepository: IBaseRepository<SpecificationEloksalProfile>
    {
        int MaxNumberSpecification();
        void UpdateSpecification(int id, string numContract, DateTime dateSpecification);
        List<SpecificationEloksalProfileDif> ChangeDifData();
        bool CheckValueNumberSpecification(string checkNumberSpecification);
        SpecificationEloksalProfile GetSpecificationEloksalProfile(string numberSpecification);
        void UpdateDataPlanSpecification(string numberSpecification, DateTime? datePlan,double? massa);
        List<string> GetListNumberSpecification();
        List<SpecificationEloksalProfile> GetListSpecifications();
    }
}
