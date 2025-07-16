using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
   public interface ICommercialOfferGeneralRepository:IBaseRepository<CommercialOfferGeneral>
    {
        int MaxNumberOffer();
        bool CheckValueCommercialOfferGeneral(string number);
        void UpdateCommercialOfferGeneral(int id, string clientName, DateTime date, string manager, string number);
    }
}
