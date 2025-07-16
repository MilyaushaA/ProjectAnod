using EloksalPro.Models;
using EloksalPro.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Timers;
using EloksalPro.View;

namespace EloksalPro.ViewModels
{
    public class CommercialOfferViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        private CommercialOffer _offer=new CommercialOffer();
        private string _numberOffer;
        private List<string> _typeAnodList;
        private List<string> _colorAnodList;
        private List<string> _thicknessCoatingList;

        private string _typeAnodSource;
        private string _colorAnodSource;
        private string _thicknessCoatingSource;

        private bool _trimming;
        private bool _sawed;
        private bool _tapeProtective;
        private bool _stretch;

        private double _weightProfile;
        private double _outerPerimeter;

        private double _priceArea;
        private double _priceKg;

        private double _priceAnodArea;
        private double _priceAnodKg;

        private double _priceShotArea;
        private double _priceShotKg;

        private double _priceTrimArea;
        private double _priceTrimKg;

        private double _priceSawedArea;
        private double _priceSawedKg;

        private double _priceProtectiveArea;
        private double _priceProtectiveKg;

        private double _priceStretchArea;
        private double _priceStretchKg;

        private List<string> _clientNameList;
        private string _clientNameSource;
        private string _nameClient;
        private int _idOffer;

        ObservableCollection<CommercialOffer> _allCommercialOffer = new ObservableCollection<CommercialOffer>();
   
        public CommercialOffer Offer
        {
            get { return _offer; }
            set { _offer = value; OnPropertyChanged(nameof(Offer)); }
        }
        public string TypeAnodSource
        {
            get { return _typeAnodSource; }
            set { _typeAnodSource = value;  OnPropertyChanged(nameof(TypeAnodSource)); }
        }
        public int IdOffer 
        {
            get { return _idOffer; }
            set { _idOffer = value; OnPropertyChanged(nameof(IdOffer)); }
        }
        public string ColorAnodSource
        {
            get { return _colorAnodSource; }
            set { _colorAnodSource = value; OnPropertyChanged(nameof(ColorAnodSource)); }
        }
        public string ThicknessCoatingSource
        {
            get { return _thicknessCoatingSource; }
            set { _thicknessCoatingSource = value; OnPropertyChanged(nameof(ThicknessCoatingSource)); }
        }
        public bool Trimming
        {
            get { return _trimming; }
            set { _trimming = value; OnPropertyChanged(nameof(Trimming)); }
        }
        public bool Sawed
        {
            get { return _sawed; }
            set { _sawed = value;  OnPropertyChanged(nameof(Sawed)); }
        }
        public bool TapeProtective
        {
            get { return _tapeProtective; }
            set { _tapeProtective = value;  OnPropertyChanged(nameof(TapeProtective)); }
        }
        public bool Stretch
        {
            get { return _stretch; }
            set { _stretch = value; OnPropertyChanged(nameof(Stretch)); }
        }
        public List<string> TypeAnodList
        {
            get { return _typeAnodList; }
            set { _typeAnodList = value; OnPropertyChanged(nameof(TypeAnodList)); }
        }
        public List<string> ColorAnodList
        {
            get { return _colorAnodList; }
            set { _colorAnodList = value; OnPropertyChanged(nameof(ColorAnodList)); }
        }
        public List<string> ThicknessCoatingList
        {
            get { return _thicknessCoatingList; }
            set { _thicknessCoatingList = value; OnPropertyChanged(nameof(ThicknessCoatingList)); }
        }
        public List<string> ClientNameList
        {
            get { return _clientNameList; }
            set { _clientNameList = value; OnPropertyChanged(nameof(ClientNameList)); }
        }
        public string NumberOffer
        {
            get { return _numberOffer; }
            set { _numberOffer = value; OnPropertyChanged(nameof(NumberOffer)); }
        }
        public string ClientNameSource
        {
            get { return _clientNameSource; }
            set { _clientNameSource = value; GetNameClient(); OnPropertyChanged(nameof(ClientNameSource)); }
        }
        public double PriceArea
        {
            get { return _priceArea; }
            set { _priceArea = value;  OnPropertyChanged(nameof(PriceArea)); }
        }
        public double PriceKg
        {
            get { return _priceKg; }
            set { _priceKg = value; OnPropertyChanged(nameof(PriceKg)); }
        }
        public double PriceAnodArea
        {
            get { return _priceAnodArea; }
            set { _priceAnodArea = value; CalculatePriceAnodKg(); OnPropertyChanged(nameof(PriceAnodArea)); }
        }
        public double PriceAnodKg
        {
            get { return _priceAnodKg; }
            set { _priceAnodKg = value; OnPropertyChanged(nameof(PriceAnodKg)); }
        }
        public double PriceShotArea
        {
            get { return _priceShotArea; }
            set { _priceShotArea = value; CalculatePriceShotKg(); OnPropertyChanged(nameof(PriceShotArea)); }
        }
        public double PriceShotKg
        {
            get { return _priceShotKg; }
            set { _priceShotKg = value; OnPropertyChanged(nameof(PriceShotKg)); }
        }
        public double PriceTrimArea
        {
            get { return _priceTrimArea; }
            set { _priceTrimArea = value; CalculatePriceTrimKg(); OnPropertyChanged(nameof(PriceTrimArea)); }
        }
        public double PriceTrimKg
        {
            get { return _priceTrimKg; }
            set { _priceTrimKg = value; OnPropertyChanged(nameof(PriceTrimKg)); }
        }
        public double PriceSawedArea
        {
            get { return _priceSawedArea; }
            set { _priceSawedArea = value; CalculatePriceSawedKg(); OnPropertyChanged(nameof(PriceSawedArea)); }
        }
        public double PriceSawedKg
        {
            get { return _priceSawedKg; }
            set { _priceSawedKg = value; OnPropertyChanged(nameof(PriceSawedKg)); }
        }
        public double PriceProtectiveArea
        {
            get { return _priceProtectiveArea; }
            set { _priceProtectiveArea = value; CalculatePriceProtectivedKg(); OnPropertyChanged(nameof(PriceProtectiveArea)); }
        }
        public double PriceProtectiveKg
        {
            get { return _priceProtectiveKg; }
            set { _priceProtectiveKg = value; OnPropertyChanged(nameof(PriceProtectiveKg)); }
        }
        public double PriceStretchArea
        {
            get { return _priceStretchArea; }
            set { _priceStretchArea = value; CalculatePriceStretchKg(); OnPropertyChanged(nameof(PriceStretchArea)); }
        }
        public double PriceStretchKg
        {
            get { return _priceStretchKg; }
            set { _priceStretchKg = value; OnPropertyChanged(nameof(PriceStretchKg)); }
        }
        public double WeightProfile
        {
            get { return _weightProfile; }
            set { _weightProfile = value; CalculatePriceAnodKg(); CalculatePriceShotKg(); CalculatePriceTrimKg(); CalculatePriceSawedKg(); CalculatePriceProtectivedKg(); OnPropertyChanged(nameof(WeightProfile)); }
        }
        public double OuterPerimeter
        {
            get { return _outerPerimeter; }
            set { _outerPerimeter = value; CalculatePriceAnodKg(); CalculatePriceShotKg(); CalculatePriceTrimKg(); CalculatePriceSawedKg(); CalculatePriceProtectivedKg(); OnPropertyChanged(nameof(OuterPerimeter)); }
        }
        public ObservableCollection<CommercialOffer> AllCommercialOffer
        {
            get { return _allCommercialOffer; }
            set { _allCommercialOffer = value; OnPropertyChanged(nameof(AllCommercialOffer)); }
        }
        public ICommand CalculateAndInsertDataCommand { get; }
        public ICommand SaveInsertCommand { get;}
        public ICommand PrintOfferCommand { get; }
        public ICommand CloseOfferCommand { get; }
        public CommercialOfferViewModel()
        {
            ProfilePropertyRepository property = new ProfilePropertyRepository();
            CharacteristicProfileRepository characteristic = new CharacteristicProfileRepository();
            CommercialOfferGeneralRepository repos = new CommercialOfferGeneralRepository();
            ClientCardRepository reposClient = new ClientCardRepository();
            ClientNameList = reposClient.GetByExaminationNomenclature();
            TypeAnodList = characteristic.GetByAllListType();
            ColorAnodList = characteristic.GetByAllListColor();
            ThicknessCoatingList = property.PropertyThicknessProfile("КТолщина");
            //int MaxNumberOffer = repos.MaxNumberOffer() + 1;
            //NumberOffer = MaxNumberOffer.ToString("D4");
            CalculateAndInsertDataCommand = new ViewModelCommand(CalculateAndAddNewProfile);
            SaveInsertCommand = new ViewModelCommand(SaveData);
            PrintOfferCommand = new ViewModelCommand(OpenReportOffer);
            CloseOfferCommand = new ViewModelCommand(SaveOfferClose);
            AddTimer();
        }
        void SaveData(object obj)
        {
            InsertNewOfferIndDetail();
            InsertNewOffer();
        }
        public void InsertNewOfferIndDetail()
        {
            CommercialOfferRepository repos = new CommercialOfferRepository();
            //for (int i = 0; i < AllCommercialOffer.Count(); i++)
            //{
            //    bool checkValue = repos.CheckValue(AllCommercialOffer[i].Id, AllCommercialOffer[i].NumberOffer);
            //    if (!checkValue)
            //    {
            //        CommercialOffer offerGeneral = new CommercialOffer();
            //        int maxId = repos.GetById();
            //        offerGeneral.Id = ++maxId;
            //        offerGeneral.ClientName = AllCommercialOffer[i].ClientName;
            //        offerGeneral.NumberOffer = AllCommercialOffer[i].NumberOffer;
            //        offerGeneral.DateOffer = AllCommercialOffer[i].DateOffer;
            //        offerGeneral.EloksalNoCommercial = AllCommercialOffer[i].EloksalNoCommercial;
            //        offerGeneral.TypeAnod = AllCommercialOffer[i].TypeAnod;
            //        offerGeneral.ColorAnod = AllCommercialOffer[i].ColorAnod;
            //        offerGeneral.ThicknessCoating = AllCommercialOffer[i].ThicknessCoating;
            //        offerGeneral.Trimming = AllCommercialOffer[i].Trimming;
            //        offerGeneral.Sawed = AllCommercialOffer[i].Sawed;
            //        offerGeneral.TapeProtective = AllCommercialOffer[i].TapeProtective;
            //        offerGeneral.WeightMeter = AllCommercialOffer[i].WeightMeter;
            //        offerGeneral.OuterPerimeter = AllCommercialOffer[i].OuterPerimeter;
            //        offerGeneral.PriceArea = AllCommercialOffer[i].PriceAreaSum;
            //        offerGeneral.PriceKg = AllCommercialOffer[i].PriceKgSum;
            //        offerGeneral.PriceAnodArea = AllCommercialOffer[i].PriceAnodArea;
            //        offerGeneral.PriceAnodKg = AllCommercialOffer[i].CalculatePriceAnodKg;
            //        offerGeneral.PriceShotArea = AllCommercialOffer[i].PriceShotArea;
            //        offerGeneral.PriceShotKg = AllCommercialOffer[i].CalculatePriceShotKg;
            //        offerGeneral.PriceTrimArea = AllCommercialOffer[i].PriceTrimArea;
            //        offerGeneral.PriceTrimKg = AllCommercialOffer[i].CalculatePriceTrimKg;
            //        offerGeneral.PriceSawedArea = AllCommercialOffer[i].PriceSawedArea;
            //        offerGeneral.PriceSawedKg = AllCommercialOffer[i].CalculatePriceSawedKg;
            //        offerGeneral.PriceProtectiveArea = AllCommercialOffer[i].PriceProtectiveArea;
            //        offerGeneral.PriceProtectiveKg = AllCommercialOffer[i].CalculatePriceProtectiveKg;
            //        offerGeneral.PriceStretchArea = AllCommercialOffer[i].PriceStretchArea;
            //        offerGeneral.PriceStretchKg = AllCommercialOffer[i].CalculatePriceStretchKg;
            //        offerGeneral.CoverageGeneralInformation = AllCommercialOffer[i].CoverageGeneralInformation;
            //        repos.Add(offerGeneral);
            //        AllCommercialOffer = repos.GetByAllEntityCommercialOffer(NumberOffer);
            //    }
            //    else

            //    {
                    UpdateCommercialOffer();
                    AllCommercialOffer = repos.GetByAllEntityCommercialOffer(NumberOffer);
            //    }
            //}
            MessageBox.Show("Данные изменены");
        }
        public void InsertNewOffer()
        {
            CommercialOfferGeneralRepository repos = new CommercialOfferGeneralRepository();
            repos.UpdateCommercialOfferGeneral(IdOffer, NameClient, Offer.DateOffer, LoadCurrentUserData(), NumberOffer);
            //CommercialOfferGeneral offerGeneral = new CommercialOfferGeneral();
            //bool checkValue = repos.CheckValueCommercialOfferGeneral(NumberOffer);
            //if (!checkValue)
            //{
            //    int maxId = repos.GetById();
            //    if (Offer.DateOffer== DateTime.MinValue)
            //    {
            //        Offer.DateOffer = DateTime.Now;
            //    }
            //    offerGeneral.Id = ++maxId;
            //    offerGeneral.ClientName = NameClient;
            //    offerGeneral.NumberOffer = NumberOffer;
            //    offerGeneral.DateOffer = Offer.DateOffer;
            //    offerGeneral.Manager = LoadCurrentUserData();
            //    repos.Add(offerGeneral);
            //}
        }
        void CalculateAndAddNewProfile(object obj)
        {

            if (Offer.DateOffer == DateTime.MinValue)
            {
                Offer.DateOffer = DateTime.Now;
            }
            List<string> list = new List<string>();
            list = AllCommercialOffer.Select(p => p.EloksalNoCommercial+p.CoverageGeneralInformation+p.ThicknessCoating).ToList();
            if (/*ClientNameSource == null || */Offer.EloksalNoCommercial == null || ThicknessCoatingSource == null || 
              ColorAnodSource == null || TypeAnodSource == null || WeightProfile == 0 || OuterPerimeter == 0 || PriceAnodArea == 0)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           else if (TypeAnodSource == "AD" && PriceShotArea==0)
            {
                MessageBox.Show("Внесите данные цены за дробейструйную обработку!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Stretch == true && TapeProtective == true  )
            {
                MessageBox.Show("Нанесение защитной пленки и стрейч-пленка не могут быть в одной позиции", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if ((Trimming == true && PriceTrimArea == 0)|| (Sawed == true && PriceSawedArea == 0) || (TapeProtective == true && PriceProtectiveArea == 0))
                
            {
                MessageBox.Show("Внесите цены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (list.Contains(Offer.EloksalNoCommercial.Trim() + CoverageGeneralInformationt().Trim()+ThicknessCoatingSource.Trim()))
            {
                MessageBox.Show("Данное коммерческое предложение уже содержит выбранную номенклатуру!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                
                CommercialOfferGeneralRepository reposGeneral = new CommercialOfferGeneralRepository();
                CommercialOfferRepository repos = new CommercialOfferRepository();
                int maxId = reposGeneral.GetById();
                CommercialOffer offer = new CommercialOffer();
                //AllCommercialOffer.Add(new CommercialOffer
                //{
                offer.Id = ++maxId;
                offer.ClientName = NameClient;
                offer.NumberOffer = NumberOffer;
                offer.DateOffer = Offer.DateOffer;
                offer.EloksalNoCommercial = Offer.EloksalNoCommercial;
                offer.TypeAnod = TypeAnodSource;
                offer.ColorAnod = ColorAnodSource;
                offer.ThicknessCoating = ThicknessCoatingSource;
                offer.Trimming = Trimming;
                offer.Sawed = Sawed;
                offer.TapeProtective = TapeProtective;
                offer.WeightMeter = WeightProfile;
                offer.OuterPerimeter = OuterPerimeter;
                offer.PriceArea = PriceArea;
                offer.PriceKg = PriceKg;
                offer.PriceAnodArea = PriceAnodArea;
                offer.PriceAnodKg = PriceAnodKg;
                offer.PriceShotArea = PriceShotArea;
                offer.PriceShotKg = PriceShotKg;
                offer.PriceTrimArea = PriceTrimArea;
                offer.PriceTrimKg = PriceTrimKg;
                offer.PriceSawedArea = PriceSawedArea;
                offer.PriceSawedKg = PriceSawedKg;
                offer.PriceProtectiveArea = PriceProtectiveArea;
                offer.PriceProtectiveKg = PriceProtectiveKg;
                offer.PriceStretchArea = PriceStretchArea;
                offer.PriceStretchKg = PriceStretchKg;
                offer.CoverageGeneralInformation = CoverageGeneralInformationt();
                repos.Add(offer);
                AllCommercialOffer.Add(offer);
                MessageBox.Show("Данные добавлены");
                AllCommercialOffer = repos.GetByAllEntityCommercialOffer(NumberOffer);
            }
        }
        string CoverageGeneralInformationt()
        {
            string coverage = String.Empty;
            coverage = TypeAnodSource + '-' + ColorAnodSource;
            if (Trimming == true && Sawed == true && TapeProtective == true && Stretch == false)
            {
                coverage = coverage +'-' + "TRP";
            }
            else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == false)
            {
                coverage = coverage + '-' + "TR";
            }
            else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == false)
            {
                coverage = coverage + '-' + "T";
            }
            else if (Trimming == false && Sawed == true && TapeProtective == true && Stretch == false)
            {
                coverage = coverage + '-' + "RP";
            }
            else if (Trimming == false && Sawed == false && TapeProtective == true && Stretch == false)
            {
                coverage = coverage + '-' + "P";
            }
            else if (Trimming == true && Sawed == false && TapeProtective == true && Stretch == false)
            {
                coverage = coverage + '-' + "TP";
            }
            else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == false)
            {
                coverage = coverage + '-' + "R";
            }
            else if (Trimming == false && Sawed == false && TapeProtective == false && Stretch==true)
            {
                coverage = coverage + '-' + "S";
            }
            else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == true)
            {
                coverage = coverage + '-' + "TS";
            }
            else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == true)
            {
                coverage = coverage + '-' + "TRS";
            }
            else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == true)
            {
                coverage = coverage + '-' + "RS";
            }
            return coverage;
        }
        public void CalculatePriceAnodKg()
        {
            _priceAnodKg = Math.Round(Convert.ToDouble(PriceAnodArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightProfile)), 2);
            OnPropertyChanged(nameof(PriceAnodKg));
        }
        public void CalculatePriceShotKg()
        {
            _priceShotKg = Math.Round(Convert.ToDouble(PriceShotArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightProfile)), 2);
            OnPropertyChanged(nameof(PriceShotKg));
        }
        public void CalculatePriceTrimKg()
        {
            _priceTrimKg = Math.Round(Convert.ToDouble(PriceTrimArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightProfile)), 2);
            OnPropertyChanged(nameof(PriceTrimKg));
        }
        public void CalculatePriceSawedKg()
        {
            _priceSawedKg = Math.Round(Convert.ToDouble(PriceSawedArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightProfile)), 2);
            OnPropertyChanged(nameof(PriceSawedKg));
        }
        public void CalculatePriceProtectivedKg()
        {
            _priceProtectiveKg = Math.Round(Convert.ToDouble(PriceProtectiveArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightProfile)), 2);
            OnPropertyChanged(nameof(PriceProtectiveKg));
        }
        public void CalculatePriceStretchKg()
        {
            _priceStretchKg = Math.Round(Convert.ToDouble(PriceStretchArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightProfile)), 2);
            OnPropertyChanged(nameof(PriceStretchKg));
        }
        public void AddTimer()
        {
            Timer timer = new Timer();
            timer.Elapsed += RefreshOfferProfile;
            timer.Interval = 2000;
            timer.AutoReset = false;
            timer.Start();
        }
        public void RefreshOfferProfile(object sender, ElapsedEventArgs e)
        {
            CommercialOfferRepository repos = new CommercialOfferRepository();
            AllCommercialOffer = repos.GetByAllEntityCommercialOffer(NumberOffer);
        }
        void OpenReportOffer(object obj)
        {
            CommercialOfferRepository repos = new CommercialOfferRepository();
            List<CommercialOffer> list = new List<CommercialOffer>();
            list = repos.GetByAllEntityCommercialOfferList(NumberOffer);
            string userName = LoadCurrentUserData();
            string numberPhone = LoadCurrentUserPhone();
            WindowCommercialOffer offer = new WindowCommercialOffer();
            offer.Show();
            offer.PrintInvoice(NameClient, Offer.DateOffer, NumberOffer, userName, numberPhone, list);
        }
        private string LoadCurrentUserData()
        {
            UserRepository userRepo = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            UserModel userList = userRepo.GetByUsername(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            if (userList != null)
            {
                {
                    CurrentUserAccount.DisplayName = userList.Name;
                }
            }
            else
            {
                CurrentUserAccount.DisplayName = "User";
            }
            return CurrentUserAccount.DisplayName;
        }
        private string LoadCurrentUserPhone()
        {
            UserRepository userRepo = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            UserModel userList = userRepo.GetByUsername(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            if (userList != null)
            {
                {
                    CurrentUserAccount.PhoneNumber = userList.PhoneNumber;
                }
            }
            else
            {
                CurrentUserAccount.PhoneNumber = "(000)00-000-00";
            }
            return CurrentUserAccount.PhoneNumber;
        }

        public string NameClient
        {
            get { return _nameClient; }
            set { _nameClient = value; OnPropertyChanged("NameClient"); }
        }
        void GetNameClient()
        {
            _nameClient = ClientNameSource;
            OnPropertyChanged("NameClient");
        }
        public void UpdateCommercialOffer()
        {
            CommercialOfferRepository repos = new CommercialOfferRepository();
            foreach (var item in AllCommercialOffer)
            {
                repos.UpdateCommercialOffer(item.Id, item.PriceAreaSum, item.PriceKgSum, item.PriceAnodArea, item.CalculatePriceAnodKg,
                                                     item.PriceShotArea, item.CalculatePriceShotKg, item.PriceTrimArea, item.CalculatePriceTrimKg,
                                                     item.PriceSawedArea, item.CalculatePriceSawedKg,item.PriceProtectiveArea, item.CalculatePriceProtectiveKg,
                                                     item.PriceStretchArea, item.CalculatePriceStretchKg,item.ClientName,item.EloksalNoCommercial,item.NumberOffer,
                                                     item.TypeAnod,item.ColorAnod,item.ThicknessCoating,item.Trimming,item.Sawed,item.TapeProtective,
                                                     item.WeightMeter,item.OuterPerimeter,item.DateOffer);
            }
        }
        public void SaveOfferClose(object obj)
        {
            CommercialOfferRepository reposOffer = new CommercialOfferRepository();
            List<CommercialOffer> offerList = new List<CommercialOffer>();
            offerList = reposOffer.GetByAllEntityCommercialOfferList(NumberOffer);
            if (NameClient == null && offerList.Count==0)
            {
                if (MessageBox.Show("Сохранить коммерческое предложение?",
                  "",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    CommercialOfferGeneralRepository repos = new CommercialOfferGeneralRepository();
                    repos.Remove(IdOffer);
                }
            }
        }
    }
}
