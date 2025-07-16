using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EloksalPro.Repositories
{
  public  class PriceListProfileRepository:BaseRepo<PriceListProfile>, IPriceListProfileRepository
    {
      public void ProfilePriceUpdate(int id, string customerName, string customerCode, string profileCode, double priceProfileKg, double priceProfileMetr, double priceProfileArea)
        {
            var myEntity = Table.FirstOrDefault(e => e.Id == id);
            if (myEntity != null)
            {
                myEntity.CustomerName = customerName;
                myEntity.CustomerCode = customerCode;
                myEntity.ProfileCode = profileCode;
                myEntity.PriceProfileKg = priceProfileKg;
                myEntity.PriceProfileMetr = priceProfileMetr;
                myEntity.PriceProfileArea = priceProfileArea;
                Context.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
        }
        public void ProfilePriceUpdate(string customerName, string customerCode, string profileCode, double priceProfileKg, double priceProfileMetr, double priceProfileArea)
        {
            var myEntity = Table.FirstOrDefault(e => e.CustomerName == customerName && e.CustomerCode== customerCode && e.ProfileCode== profileCode);
            if (myEntity != null)
            {
                myEntity.PriceProfileKg = priceProfileKg;
                myEntity.PriceProfileMetr = priceProfileMetr;
                myEntity.PriceProfileArea = priceProfileArea;
                Context.SaveChanges();
                MessageBox.Show("Данные успешно изменены");
            }
        }
        public double GetPriceKgProfile(string nomenclature)
        {
            var list = Table.FirstOrDefault(p => p.ProfileCode== nomenclature);
            double priceProfile;
            if (list != null) return priceProfile = list.PriceProfileKg;
            else return 0;
        }
      public double GetPriceMetrProfile(string nomenclature)
        {
            var list = Table.FirstOrDefault(p => p.ProfileCode == nomenclature);
            double priceProfile;
            if (list != null) return priceProfile = list.PriceProfileMetr;
            else return 0;
        }
        public double GetPriceAreaProfile(string nomenclature)
        {
            var list = Table.FirstOrDefault(p => p.ProfileCode == nomenclature);
            double priceProfile;
            if (list != null) return priceProfile = list.PriceProfileArea;
            else return 0;
        }
        public List<string> GetNomenclature()
        {
            List<string> list = new List<string>();
            list = Table.Select(p => p.ProfileCode).ToList();
            return list; 
        }

    }
}
