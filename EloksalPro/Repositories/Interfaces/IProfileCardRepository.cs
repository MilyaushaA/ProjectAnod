using EloksalPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories.Interfaces
{
    public interface IProfileCardRepository: IBaseRepository<ProfileCard>
    {
        void ProfileCardUpdate(int id, string EloksalNo, string ClientName, string EloksalNoCommercial, string NomenclatureProfile, string NomenclatureSpecification,
                                      int LenghtProfile, int LenghtProfileTwo, string TypeAnod, string ColorAnod, string ThicknessCoating, bool Trimming,
                                      bool Sawed, bool TapeProtective, bool Stretch, double WeightMeter, double InnerPerimeter, double OuterPerimeter,
                                      double GeneralPerimeter, double AreaAnod);
        int MaxEloksalNo();
        List<string> GetByExaminationNomenclature(); 
        List<string> GetByExaminationNomenclature(string client);
        string GetByNomenclature(string nameCode);
        string GetByNameProfileClient(string nomenclature);
        double GetByWeightProfile(string nomenclature);
        int GetByLenghtProfile(string nomenclature);
        double GetByOuterPerimetrProfile(string nomenclature);
        ProfileCard GetByListProfileCard(string nomenclature);
        ProfileCard GetByListProfileCardFromNomenclature(string nomenclature);
        List<ForPivotTableProfileCard> GetForPivotTableProfileCard();
        string GetByEloksalNoCommercial(string nomenclature);
        int GetByLenghtProfileTwo(string nomenclature);
        ProfileCard GetByProfileCard(string nomenclature);
    }
}
