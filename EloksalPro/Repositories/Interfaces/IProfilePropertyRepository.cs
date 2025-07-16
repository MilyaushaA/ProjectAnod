using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
  public  interface IProfilePropertyRepository : IBaseRepository<ProfileProperty>
    {
        List<string> GetByExaminationPropertyProfile();
        List<string> PropertyLenghtProfile();
        List<string> PropertyTypeProfile();
        List<string> PropertyColorProfile();
        List<string> PropertyThicknessProfile(string name);
    }
}
