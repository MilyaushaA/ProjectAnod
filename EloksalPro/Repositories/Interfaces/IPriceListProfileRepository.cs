using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
  public  interface IPriceListProfileRepository : IBaseRepository<PriceListProfile>
    {
        void ProfilePriceUpdate(int id, string customerCode, string customerName, string profileCode, double priceProfileKg, double priceProfileMetr, double priceProfileArea);
        void ProfilePriceUpdate(string customerName, string customerCode, string profileCode, double priceProfileKg, double priceProfileMetr, double priceProfileArea);
        double GetPriceKgProfile(string nomenclature);
        double GetPriceMetrProfile(string nomenclature);
        List<string> GetNomenclature();
    }
}
