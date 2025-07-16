using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
  public class CommercialOfferGeneralRepository:BaseRepo<CommercialOfferGeneral>, ICommercialOfferGeneralRepository
    {
        public int MaxNumberOffer()
        {
            List<CommercialOfferGeneral> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                var maxCount = list.Max(x => x.NumberOffer);
                return Convert.ToInt32(maxCount);
            }
            else
            {
                return 0;
            }
        }
        public bool CheckValueCommercialOfferGeneral(string number)
        {
            bool checkValue = Table.Any(p => p.NumberOffer == number);
            return checkValue;
        }
        public void UpdateCommercialOfferGeneral(int id, string clientName,DateTime date,string manager,string number)
        {
            CommercialOfferGeneral myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.ClientName = clientName;
                myEntity.DateOffer = date;
                myEntity.Manager = manager;
                myEntity.NumberOffer = number;
                Context.SaveChanges();
            }
        }
    }
}
