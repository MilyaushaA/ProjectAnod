using EloksalPro.EfStructures;
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
   public  class ProfileCardRepository:BaseRepo<ProfileCard>, IProfileCardRepository
    {
        public int MaxEloksalNo()
        {
            List<ProfileCard> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> eloksalNoList = list.Select(p => p.EloksalNo).ToList();
                List<int> eloksalNoListInt = new List<int>();

                foreach (string item in eloksalNoList)
                {
                    string text = item.Substring(0,6);
                    int number = int.Parse(text.Substring(2));
                    eloksalNoListInt.Add(number);
                }
                int eloksalNoIntMax = eloksalNoListInt.Max();
                return eloksalNoIntMax;
            }
            else
            {
                return 0;
            }

        }
        public void ProfileCardUpdate(int id, string EloksalNo,string ClientName,string EloksalNoCommercial,string NomenclatureProfile, string NomenclatureSpecification,
                                      int LenghtProfile, int LenghtProfileTwo, string TypeAnod,string ColorAnod,string ThicknessCoating, bool Trimming,
                                      bool Sawed, bool TapeProtective, bool Stretch, double WeightMeter, double InnerPerimeter, double OuterPerimeter, 
                                      double GeneralPerimeter, double AreaAnod)
        {
            
            var myEntity = Table.FirstOrDefault(e => e.Id == id);
            if (myEntity != null)
            {
            myEntity.EloksalNo = EloksalNo;
            myEntity.ClientName = ClientName;
            myEntity.EloksalNoCommercial = EloksalNoCommercial;
            myEntity.NomenclatureProfile = NomenclatureProfile;
            myEntity.NomenclatureSpecification = NomenclatureSpecification;
            myEntity.LenghtProfile = LenghtProfile;
            myEntity.LenghtProfileTwo = LenghtProfileTwo;
            myEntity.TypeAnod = TypeAnod;
            myEntity.ColorAnod = ColorAnod;
            myEntity.ThicknessCoating = ThicknessCoating;
            myEntity.Trimming = Trimming;
            myEntity.Sawed = Sawed;
            myEntity.Stretch = Stretch;
            myEntity.TapeProtective = TapeProtective;
            myEntity.WeightMeter = WeightMeter;
            myEntity.InnerPerimeter = InnerPerimeter;
            myEntity.OuterPerimeter = OuterPerimeter;
            myEntity.GeneralPerimeter = GeneralPerimeter;
            myEntity.AreaAnod = AreaAnod;
            Context.SaveChanges();
            MessageBox.Show("Данные успешно изменены");
            }
            }
      
        public List<string> GetByExaminationNomenclature()
        {
            List<string> list = new List<string>();
            list = Table.Select(p => p.NomenclatureProfile).ToList();
            return list;
        }
        public List<string> GetByExaminationNomenclature(string client)
        {
            List<string> list = new List<string>();
            list = Table.Where(p=>p.ClientName==client).Select(p => p.NomenclatureProfile).Distinct().ToList();
            return list;
        }
        public string GetByNomenclature(string nameCode)
        {
            var list = Table.FirstOrDefault(p=>p.NomenclatureProfile.Trim()==nameCode.Trim());
            string nomenclatureProfile;
            if (list != null) return nomenclatureProfile = list.NomenclatureSpecification;
            else return String.Empty;
        }
        public string GetByNameProfileClient(string nomenclature)
        {

            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            string nomenclatureProfile;
            if (list != null) return nomenclatureProfile = list.NomenclatureSpecification;
            else return String.Empty;
        }
        public string GetByEloksalNoCommercial(string nomenclature)
        {

            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            string nomenclatureProfile;
            if (list != null) return nomenclatureProfile = list.EloksalNoCommercial;
            else return String.Empty;
        }
        public double GetByWeightProfile(string nomenclature)
        {

            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            double weightProfile;
            if (list != null) return weightProfile = list.WeightMeter;
            else return 0;
        }
        public int GetByLenghtProfile(string nomenclature)
        {
            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            int lenghtProfile;
            if (list != null) return lenghtProfile = list.LenghtProfile;
            else return 0;
        }
        public int GetByLenghtProfileTwo(string nomenclature)
        {
            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            int lenghtProfile;
            if (list != null) return lenghtProfile = list.LenghtProfileTwo;
            else return 0;
        }
        public double GetByOuterPerimetrProfile(string nomenclature)
        {
            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            double outerPerimetrProfile;
            if (list != null) return outerPerimetrProfile = list.OuterPerimeter;
            else return 0;
        }
        public ProfileCard GetByListProfileCard(string nomenclature)
        {
            ProfileCard list = new ProfileCard();
            list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclature);
            return list;
        }
        public ProfileCard GetByProfileCard(string nomenclature)
        {
            ProfileCard list = new ProfileCard();
            list = Table.FirstOrDefault(p => p.EloksalNo == nomenclature);
            return list;
        }
        public ProfileCard GetByListProfileCardFromNomenclature(string nomenclature)
        {
            ProfileCard list = new ProfileCard();
            list = Table.FirstOrDefault(p => p.NomenclatureProfile== nomenclature);
            return list;
        }
        public ProfileCard GetByListProfileCardFromEloksalNo(string eloksalNo)
        {
            ProfileCard list = new ProfileCard();
            list = Table.FirstOrDefault(p => p.EloksalNo == eloksalNo);
            return list;
        }
        //public void DeleteImageBytes(int id)
        // {
        //     ProfileCardRepository repos = new ProfileCardRepository();
        //     var entity = repos.GetByEntity(id);
        //     byte[] image = entity.ImageBytes;
        //     image = null;
        //     Context.SaveChanges();
        // }

            public int GetIdEntity(string nomenclatureProfile)
        {
            var list = Table.FirstOrDefault(p => p.NomenclatureProfile == nomenclatureProfile);
            int id;
            if (list != null) return id = list.Id;
            else return 0;
        }

        public List<ForPivotTableProfileCard> GetForPivotTableProfileCard()
        {
            List<ForPivotTableProfileCard> list = new List<ForPivotTableProfileCard>();
            list = Table
                    .Select(g => new ForPivotTableProfileCard
                    {
                        ClientName = g.ClientName,
                        EloksalNoCommercial= g.EloksalNoCommercial,
                        NomenclatureProfile = g.NomenclatureProfile,
                        LenghtProfile = g.LenghtProfile,
                        WeightMeter = g.WeightMeter/1000
                    }).ToList();
            return list;
        }

        public List<ForPivotTableProfileCard> GetForPivotTableProfileCardTwo()
        {
            List<ForPivotTableProfileCard> list = new List<ForPivotTableProfileCard>();
            list = Table.Where(p=>p.LenghtProfileTwo==0)
                    .Select(g => new ForPivotTableProfileCard
                    {
                        ClientName = g.ClientName,
                        EloksalNoCommercial = g.EloksalNoCommercial,
                        NomenclatureProfile = g.NomenclatureProfile,
                        LenghtProfile = g.LenghtProfile,
                        WeightMeter = g.WeightMeter / 1000
                    }).ToList();
            return list;
        }

    }
}

