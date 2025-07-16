using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface ICommercialOfferRepository: IBaseRepository<CommercialOffer>
    {
        bool CheckValue(int id, string numberOffer);
        ObservableCollection<CommercialOffer> GetByAllEntityCommercialOffer(string numberOffer);
        void UpdateCommercialOffer(int id, double priceArea, double priceKg,
                                            double priceAnodArea, double priceAnodKg,
                                            double priceShotArea, double priceShotKg,
                                            double priceTrimArea, double priceTrimKg,
                                            double priceSawedArea, double priceSawedKg,
                                            double priceProtectiveArea, double priceProtectiveKg,
                                            double priceStretchArea, double priceStretchKg,
                                            string clientName, string eloksalNoCommercial, string numberOffer,
                                            string typeAnod, string colorAnod, string thicknessCoating,
                                            bool trimming, bool sawed, bool tapeProtective, double weightMeter, double outerPerimeter, DateTime dateOffer);
        List<CommercialOffer> GetByAllEntityCommercialOfferList(string numberOffer);
        CommercialOffer GetWeightAndPerimetr(string nameClient, string eloksalNo);
    }
}
