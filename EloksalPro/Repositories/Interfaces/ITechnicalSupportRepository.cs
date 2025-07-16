using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public  interface ITechnicalSupportRepository: IBaseRepository<TechnicalSupport>
    {
        List<TechnicalSupport> GetAllInventory();
        void UpdateInventory(int id, DateTime? dateApp, DateTime? datePreliminaryReadiness, DateTime? dateReadiness, string applicationText, string customer);
    }
}
