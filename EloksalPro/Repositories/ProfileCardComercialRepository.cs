using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
   public class ProfileCardComercialRepository : BaseRepo<ProfileCardComercial>, IProfileCardComercialRepository
    {
        public ObservableCollection<string> ListCommercialNoProfile(int id)
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            var inventory= Table.Where(p => p.ClientId==id).Select(p => p.EloksalNoCommercial).ToList();
            list= new ObservableCollection<string>(inventory);
            return list;
        }
        public List<string> GetByExaminationNomenclature(int id)
        {
            List<string> list = new List<string>();
            list = Table.Where(p=>p.ClientId==id).Select(p => p.EloksalNoCommercial).ToList();
            return list;
        }
        public List<string> ListCommercialNoProfile()
        {
            List<string> list = new List<string>();
            var inventory = Table.Select(p => p.EloksalNoCommercial).ToList();
            list = new List<string>(inventory);
            return list;
        }
    }
}
