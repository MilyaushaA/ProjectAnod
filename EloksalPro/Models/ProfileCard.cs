using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ProfileCard : BaseEntity
    {
        public string EloksalNo { get; set; } //номер профиля
        public string ClientName { get; set; }// наименование заказчика
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string  NomenclatureSpecification { get; set; }//  номенклатура для спецификации
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int LenghtProfile { get; set; } //  длина профиля
        public int LenghtProfileTwo { get; set; } //  длина профиля
        public string TypeAnod { get; set; } //  вид покрытия
        public string ColorAnod { get; set; } //  цвет покрытия
        public string ThicknessCoating { get; set; } //  толщина покрытия
        public bool Trimming { get; set; } //  торцовка
        public bool Sawed { get; set; } //  распил
        public bool TapeProtective { get; set; } //  защитная пленка 
        public bool Stretch { get; set; }
        public double WeightMeter { get; set; }// вес погонного метра
        public double InnerPerimeter { get; set; }// внутренний периметр
        public double OuterPerimeter { get; set; }// внешний периметр
        public double GeneralPerimeter { get; set; }// общий периметр
        public double AreaAnod { get; set; }// площадь поперечного сечения 
    }

    //public ProfileCard(string eloksalNo, string clientName, string eloksalNoCommercial, string nomenclatureProfile,
    //                   int lenghtProfile, string typeAnod, string colorAnod, string thicknessCoating, bool trimming, bool sawed,
    //                   bool tapeProtective, int weightMeter, int innerPerimeter, int outerPerimeter,int generalPerimeter,int areaAnod)
    //{
    //    EloksalNo = eloksalNo;
    //    ClientName = clientName;
    //    EloksalNoCommercial = eloksalNoCommercial;
    //    NomenclatureProfile = nomenclatureProfile;
    //    LenghtProfile = lenghtProfile;
    //    TypeAnod = typeAnod;
    //    ColorAnod = colorAnod;
    //    ThicknessCoating = thicknessCoating;
    //    Trimming = trimming;
    //    Sawed = sawed;
    //    TapeProtective = tapeProtective;
    //    WeightMeter = weightMeter;
    //    InnerPerimeter = innerPerimeter;
    //    OuterPerimeter = outerPerimeter;
    //    GeneralPerimeter = generalPerimeter;
    //    AreaAnod = areaAnod;
    //}
    //public IEnumerable<ProfileCardComercial> ProfileCardComercials { get; set; } = new List<ProfileCardComercial>();
    public class ForPivotTableProfileCard
    {
        public string ClientName { get; set; }// наименование заказчика
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public int LenghtProfile { get; set; } //  длина профиля
        public double WeightMeter { get; set; }// вес погонного метра
        public string EloksalNoCommercial { get; set; }
    }

}
