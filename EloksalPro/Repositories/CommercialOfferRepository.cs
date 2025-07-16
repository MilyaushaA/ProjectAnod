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
   public class CommercialOfferRepository : BaseRepo<CommercialOffer>, ICommercialOfferRepository
    {
        //public bool CheckValue(int id,string numberOffer, string numberProfile,string coverageGeneralInformation, string thicknessCoating)
        //{
        //    bool checkValue = Table.Any(p =>p.Id==id && p.NumberOffer == numberOffer && p.EloksalNoCommercial == numberProfile && p.CoverageGeneralInformation== coverageGeneralInformation && p.ThicknessCoating== thicknessCoating);
        //    return checkValue;
        //}
        public bool CheckValue(int id,string numberOffer)
        {
            bool checkValue = Table.Any(p => p.Id == id && p.NumberOffer == numberOffer);
            return checkValue;
        }
        //public void UpdateCommercialOffer(int id, string name)
        //{
        //    CommercialOffer myEntity = Table.FirstOrDefault(p => p.Id == id);
        //    if (myEntity != null)
        //    {
        //        myEntity.EloksalNoCommercial = name;
        //        Context.SaveChanges();
        //    }
        //}
        public ObservableCollection<CommercialOffer> GetByAllEntityCommercialOffer(string numberOffer)
        {
            ObservableCollection<CommercialOffer> list = new ObservableCollection<CommercialOffer>();
            var inventory = Table.Where(p => p.NumberOffer == numberOffer.TrimEnd()).ToList();
            list = new ObservableCollection<CommercialOffer>(inventory);
            return list;
        }
        public List<CommercialOffer> GetByAllEntityCommercialOfferList(string numberOffer)
        {
            List<CommercialOffer> list = new List<CommercialOffer>();
            var inventory = Table.Where(p => p.NumberOffer == numberOffer.TrimEnd()).ToList();
            list = new List<CommercialOffer>(inventory);
            return list;
        }
        public CommercialOffer GetWeightAndPerimetr(string nameClient,string eloksalNo)
        {
            CommercialOffer empty = new CommercialOffer();
            empty = Table.FirstOrDefault(p => p.ClientName == nameClient && p.EloksalNoCommercial == eloksalNo);
            return empty;
        }
        public void UpdateCommercialOffer(int id, double priceArea, double priceKg, 
                                          double priceAnodArea, double priceAnodKg, 
                                          double priceShotArea, double priceShotKg,
                                          double priceTrimArea, double priceTrimKg,
                                          double priceSawedArea, double priceSawedKg,
                                          double priceProtectiveArea, double priceProtectiveKg,
                                          double priceStretchArea, double priceStretchKg,
                                          string clientName, string eloksalNoCommercial, string numberOffer,
                                          string typeAnod, string colorAnod, string thicknessCoating,
                                          bool trimming, bool sawed, bool tapeProtective, double weightMeter, double outerPerimeter, DateTime dateOffer)
        {
            CommercialOffer myEntity = Table.FirstOrDefault(p => p.Id == id);
            if (myEntity != null)
            {
                myEntity.ClientName = clientName;
                myEntity.EloksalNoCommercial = eloksalNoCommercial;
                myEntity.NumberOffer = numberOffer;
                myEntity.DateOffer = dateOffer;
                myEntity.TypeAnod = typeAnod;
                myEntity.ColorAnod = colorAnod;
                myEntity.ThicknessCoating = thicknessCoating;
                myEntity.Trimming = trimming;
                myEntity.Sawed = sawed;
                myEntity.TapeProtective = tapeProtective;
                myEntity.WeightMeter = weightMeter;
                myEntity.OuterPerimeter = outerPerimeter;
                myEntity.PriceArea = priceArea;
                myEntity.PriceKg = priceKg;
                myEntity.PriceAnodArea = priceAnodArea;
                myEntity.PriceAnodKg = priceAnodKg;
                myEntity.PriceShotArea = priceShotArea;
                myEntity.PriceShotKg = priceShotKg;
                myEntity.PriceTrimArea = priceTrimArea;
                myEntity.PriceTrimKg = priceTrimKg;
                myEntity.PriceSawedArea = priceSawedArea;
                myEntity.PriceSawedKg = priceSawedKg;
                myEntity.PriceProtectiveArea = priceProtectiveArea;
                myEntity.PriceProtectiveKg = priceProtectiveKg;
                myEntity.PriceStretchArea = priceStretchArea;
                myEntity.PriceStretchKg = priceStretchKg;
                Context.SaveChanges();
            }
        }
    }
}
