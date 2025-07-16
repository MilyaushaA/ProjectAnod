using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface ISpecificationAllDescriptionRepository : IBaseRepository<SpecificationAllDescription>
    {
        ObservableCollection<SpecificationAllDescription> GetByAllEntityObservableCollection(string numberSpecification);
        List<SpecificationAllDescription> GetByAllEntityListCollection(string numberSpecification);
        bool CheckValue(string numSpecification, string nomenclature, int lenght);
        void UpdateSpecificationAllDescription(string numberSpecification, string numberProfile, int amount, int lenght);
        List<DifferenceDataAll> DifferenceData();
        void UpdateSpecificationAllDescriptionAmountTeor(int id, int amount, int amountFact, int lenght, double count, double amountKg, double amountPMetr, double totalSum, int lenghtFact,
                                                                bool choiceKg, bool choicePiece, bool choicePMetr, double priceKg, double pricePMetr, double pricePiece, double priceProfileArea,
                                                                 double amountTwo);
        List<ForPivotTableSpecification> GetForPivotTableSpecification();
        int MaxNumberSpecification();
        double GetTotalWeight(string numberSpecification);
        List<SpecificationForScore> GetByAllEntityListCollectionForScore(string numberSpecification);
    }
}
