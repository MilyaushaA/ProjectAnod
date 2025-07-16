using EloksalPro.Models;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
   public interface IСharacteristicProfileRepository: IBaseRepository<СharacteristicProfile>
    {
        void ProfilePropertiesUpdate(int Id, string Name, string Marking, string Description);
        List<String> GetByAllListType();
        List<String> GetByAllListColor();
    }
}
