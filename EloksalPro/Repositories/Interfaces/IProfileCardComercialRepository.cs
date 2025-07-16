using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IProfileCardComercialRepository:IBaseRepository<ProfileCardComercial>
    {
        ObservableCollection<string> ListCommercialNoProfile(int id);
        List<string> GetByExaminationNomenclature(int id);

    }
}
