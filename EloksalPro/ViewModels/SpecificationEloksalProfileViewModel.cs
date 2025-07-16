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
using DevExpress.Xpf.Grid;
using EloksalPro.View;
using System.IO;
using System.Diagnostics;

namespace EloksalPro.ViewModels
{
   public class SpecificationEloksalProfileViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        List<string> _clientNameList;
        List<string> _nomenclatureList ;
        private string _clientNameSource;
        private SpecificationEloksalProfile _specificationEloksalProfile;
        private double _count;
        private double _countTwo;
        private string _nomenclatureSource;
        private string _numberSpecification;
        private int _id;
        private string _numberContract;
        private string _annotation;
        private DateTime? _dateContract;
        public ObservableCollection<SpecificationAllDescription> _allSpecification=new ObservableCollection<SpecificationAllDescription>();
        private int _amountFactMustBe;
        private int _lenghtFactMustBe;
        private List<string> _employeeList;
        private string _employeeSource;
        private bool _choicePiece;
        private bool _choicePMetr;
        private bool _calculation;
        private double _priceProfileArea;
        private double _sumProfileArea;
        private int _lenghtProfile;
        private int _lenghtProfileTwo;
        //private double _weightMeter;
        //private double _outerPerimeter;


        //public double WeightMeter
        //{
        //    get { return _weightMeter; }
        //    set { _weightMeter = value; OnPropertyChanged(nameof(WeightMeter)); }
        //}
        //public double OuterPerimeter
        //{
        //    get { return _outerPerimeter; }
        //    set { _outerPerimeter = value; OnPropertyChanged(nameof(OuterPerimeter)); }
        //}

        public bool ChoicePiece
        {
            get { return _choicePiece; }
            set { _choicePiece = value;OnPropertyChanged(nameof(ChoicePiece)); }
        }
        public bool ChoicePMetr
        {
            get { return _choicePMetr; }
            set { _choicePMetr = value; OnPropertyChanged(nameof(ChoicePMetr)); }
        }
        public bool Calculation
        {
            get { return _calculation; }
            set { _calculation = value; OnPropertyChanged(nameof(Calculation)); }
        }
        public ObservableCollection<SpecificationAllDescription> AllSpecification 
        {
            get { return _allSpecification; }
            set { _allSpecification = value; OnPropertyChanged(nameof(AllSpecification)); }
        }
        public List<string> ClientNameList
        {
            get { return _clientNameList; }
            set { _clientNameList = value; OnPropertyChanged(nameof(ClientNameList));}
        }
        public List<string> NomenclatureList
        {
            get { return _nomenclatureList; }
            set { _nomenclatureList = value; OnPropertyChanged(nameof(NomenclatureList)); }
        }
        public string ClientNameSource
        {
            get { return _clientNameSource; }
            set { _clientNameSource = value; CheckNomenclature(); GetNumberContract(); OnPropertyChanged(nameof(ClientNameSource)); }
        }
        public string NumberSpecification
        {
            get { return _numberSpecification; }
            set{
                SpecificationEloksalProfileRepository repos = new SpecificationEloksalProfileRepository();
                List<SpecificationEloksalProfile> specification = new List<SpecificationEloksalProfile>();
                specification = repos.GetByAllEntity();
                List<string> listNumberSpecification = specification.Select(p => p.NumberSpecification).ToList();
                if (listNumberSpecification.Contains(value.Trim()) && Id==0) 
                {
                    MessageBox.Show("Данная спецификация уже есть в базе данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                _numberSpecification = value; OnPropertyChanged(nameof(NumberSpecification));}     
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public int AmountFactMustBe
        {
            get { return _amountFactMustBe; }
            set { _amountFactMustBe = value; OnPropertyChanged(nameof(AmountFactMustBe)); }
        }
        public int LenghtFactMustBe
        {
            get { return _lenghtFactMustBe; }
            set { _lenghtFactMustBe = value; OnPropertyChanged(nameof(LenghtFactMustBe)); }
        }
        public int LenghtProfile
        {
            get { return _lenghtProfile; }
            set { _lenghtProfile = value; OnPropertyChanged(nameof(LenghtProfile)); }
        }
        public int LenghtProfileTwo
        {
            get { return _lenghtProfileTwo; }
            set { _lenghtProfileTwo = value; OnPropertyChanged(nameof(LenghtProfileTwo)); }
        }
        public SpecificationEloksalProfile SpecificationEloksalProfile
        {
            get { return _specificationEloksalProfile; }
            set { _specificationEloksalProfile = value; OnPropertyChanged(nameof(SpecificationEloksalProfile)); }
        }
        public string NomenclatureSource
        {
            get { return _nomenclatureSource; }
            set { _nomenclatureSource = value; GetLenghtNomenclature(); OnPropertyChanged(nameof(NomenclatureSource)); }
        }
        public string Annotation
        {
            get { return _annotation; }
            set { _annotation = value; OnPropertyChanged(nameof(Annotation)); }
        }
        public string NumberContract
        {
            get { return _numberContract; }
            set { _numberContract = value; OnPropertyChanged(nameof(NumberContract)); }
        }
        public DateTime? DateContract
        {
            get { return _dateContract; }
            set { _dateContract = value; OnPropertyChanged(nameof(DateContract)); }
        }
        public double Count
        {
            get { return _count; }
            set { _count = value;OnPropertyChanged(nameof(Count)); }
        }
        public double CountTwo
        {
            get { return _countTwo; }
            set { _countTwo = value; OnPropertyChanged(nameof(CountTwo)); }
        }
        public List<string> EmployeeList
        {
            get { return _employeeList; }
            set { _employeeList = value; OnPropertyChanged(nameof(EmployeeList)); }
        }
        public string EmployeeSource
        {
            get { return _employeeSource; }
            set { _employeeSource = value; OnPropertyChanged(nameof(EmployeeSource)); }
        }
        public double PriceProfileArea
        {
            get { return _priceProfileArea; }
            set { _priceProfileArea = value; OnPropertyChanged(nameof(PriceProfileArea)); }
        }
        public double SumProfileArea
        {
            get { return _sumProfileArea; }
            set { _sumProfileArea = value; OnPropertyChanged(nameof(SumProfileArea)); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand CalculateAndInsertDataCommand { get; }
        public ICommand PrintSpecificationCommand { get; }
        public ICommand PrintSpecificationTwoCommand { get; }
        public ICommand RefreshSpecificationCommand { get; }
        public ICommand UpdatePriceListCommand { get; }
        public ICommand SaveSpecificationCsvCommand { get; }
        public SpecificationEloksalProfileViewModel()
        {
            _specificationEloksalProfile = new SpecificationEloksalProfile();
            SpecificationEloksalProfileRepository reposSpecificationEloksal = new SpecificationEloksalProfileRepository();
            ClientCardRepository repos = new ClientCardRepository();
            SpecificationAllDescriptionRepository reposSpecification = new SpecificationAllDescriptionRepository();
            ClientNameList = repos.GetByExaminationNomenclature();
            SaveInsertCommand = new ViewModelCommand(InsertAllSpecification);
            //AllSpecification = reposSpecification.GetByAllEntityObservableCollection();
            CalculateAndInsertDataCommand= new ViewModelCommand(CalculateAndAddDataSpecification);
            PrintSpecificationCommand= new ViewModelCommand(OpenReportSpecification);
            PrintSpecificationTwoCommand = new ViewModelCommand(OpenReportSpecificationTwo);
            UpdatePriceListCommand = new ViewModelCommand(UpdatePriceList);
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsername();
            int MaxEloksalNo = reposSpecificationEloksal.MaxNumberSpecification() + 1;
            DateTime date = DateTime.Now;
            NumberSpecification =MaxEloksalNo.ToString("D3")+date.ToString("MM") + date.ToString("yy");
            SaveSpecificationCsvCommand = new ViewModelCommand(SaveSpecificationToCsv);
            AddTimer();
        }
        public void InsertNewSpecification()
        {
            SpecificationEloksalProfileRepository repos = new SpecificationEloksalProfileRepository();
            SpecificationEloksalProfile specification = new SpecificationEloksalProfile();
            bool checkValue = repos.CheckValueNumberSpecification(NumberSpecification);
            if (!checkValue)
            {
                int maxId = repos.GetById();
                if (SpecificationEloksalProfile.DateSpecification == DateTime.MinValue)
                {
                    SpecificationEloksalProfile.DateSpecification = DateTime.Now;
                }
                if (DateContract == DateTime.MinValue || DateContract==null)
                {
                    DateContract = DateTime.Now;
                }
                specification.Id = ++maxId;
                specification.ClientName = ClientNameSource;
                specification.NumberSpecification = NumberSpecification;
                specification.DateSpecification = SpecificationEloksalProfile.DateSpecification;
                specification.NumberContract = NumberContract;
                specification.CalculateLabel = Calculation;
                specification.DateContract = Convert.ToDateTime(DateContract);
                specification.Manager = LoadCurrentUserData();
                repos.Add(specification);
            }   
        }      
        void CheckNomenclature()
        {
            ProfileCardRepository reposProfile = new ProfileCardRepository();
            _nomenclatureList = reposProfile.GetByExaminationNomenclature(ClientNameSource);
            OnPropertyChanged(nameof(NomenclatureList));
        }
        void GetLenghtNomenclature()
        {
            ProfileCardRepository reposProfile = new ProfileCardRepository();
            _lenghtProfile = reposProfile.GetByLenghtProfile(NomenclatureSource);
            OnPropertyChanged(nameof(LenghtProfile));
            _lenghtProfileTwo = reposProfile.GetByLenghtProfileTwo(NomenclatureSource);
            OnPropertyChanged(nameof(LenghtProfileTwo));
        }
        void CalculateAndAddDataSpecification(object obj)
        {
            ProfileCardRepository reposProfile = new ProfileCardRepository();
            PriceListProfileRepository reposPriceProfile = new PriceListProfileRepository();
            SpecificationAllDescriptionRepository reposSpecification = new SpecificationAllDescriptionRepository();

            bool checkValue = AllSpecification.Any(p => p.NumberSpecification == NumberSpecification && p.NomenclatureProfile == NomenclatureSource && p.LenghtProfileMustBe == LenghtFactMustBe);


            double priceKg = reposPriceProfile.GetPriceKgProfile(NomenclatureSource);
            double priceMetr = reposPriceProfile.GetPriceMetrProfile(NomenclatureSource);
            double priceProfileArea = reposPriceProfile.GetPriceAreaProfile(NomenclatureSource);
            string EloksalNoCommercial = reposProfile.GetByNameProfileClient(NomenclatureSource);
            double weightProfile = reposProfile.GetByWeightProfile(NomenclatureSource);
            double outerPerimetr = reposProfile.GetByOuterPerimetrProfile(NomenclatureSource);
            //int lenghtProfile = reposProfile.GetByLenghtProfile(NomenclatureSource);
            double pricePiece = priceMetr * LenghtFactMustBe/ 1000;
          
            //List<string> list = new List<string>();
            //List<int> listLenght = new List<int>();
            List<string> listNumberSpecification = new List<string>();
            List<string> listNumberContract= new List<string>();
            //list = AllSpecification.Select(p => p.NomenclatureProfile).ToList();
            //listLenght = AllSpecification.Select(p => p.LenghtProfileMustBe).ToList();
            listNumberSpecification = AllSpecification.Select(p => p.NumberSpecification).ToList();
            listNumberContract= AllSpecification.Select(p => p.NumberContract).ToList();
            if (NumberSpecification == null || EloksalNoCommercial==null || NomenclatureSource ==null || Count ==0 ||
               ClientNameSource ==null || SpecificationEloksalProfile.DateSpecification==null || SpecificationEloksalProfile.DateContract == null || Count==0 || AmountFactMustBe==0 || LenghtFactMustBe==0)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (checkValue)
            {
                MessageBox.Show("Данная спецификация уже содержит выбранную номенклатуру!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (listNumberSpecification.Count>0 && !listNumberSpecification.Contains(NumberSpecification))
            {
                MessageBox.Show("Номер спецификации не соответствует ранее добавленой!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
               else if (listNumberContract.Count > 0 && !listNumberContract.Contains(NumberContract))
            {
                MessageBox.Show("Номер договора не соответствует ранее добавленой!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                bool choiceKg=false;
                if (ChoicePiece == false && ChoicePMetr == false)
                {
                    choiceKg = true;
                }
                AllSpecification.Add(new SpecificationAllDescription
                {
                    NomenclatureProfile = NomenclatureSource,
                    NumberSpecification = NumberSpecification,
                    NumberContract = NumberContract,
                    WeightMeter= weightProfile,
                    OuterPerimeter=outerPerimetr,
                    EloksalNoCommercial = EloksalNoCommercial,
                    AmountPieceMustBe= AmountFactMustBe,
                    AmountPiece = Count,
                    AmountPieceTwo = CountTwo,
                    ChoiceKg = choiceKg,
                    ChoicePiece = ChoicePiece,
                    ChoicePMetr=ChoicePMetr,
                    //AmountKg = Math.Round(countKg, 2),
                    //AmountPMetr = lenghtMetr,
                    //PriceKg = Math.Round(priceKg, 2),
                    //PricePMetr = Math.Round(priceMetr, 2),
                    //PricePiece = Math.Round(pricePiece, 2),
                    PriceProfileArea= Math.Round(priceProfileArea, 2),
                    //TotalSumWeight = Math.Round(totalSum, 2),
                   
                    LenghtProfileMustBe = LenghtFactMustBe,
                    AmountPieceFact = AmountFactMustBe,
                    LenghtProfileFact = LenghtFactMustBe,
                    LenghtProfile = LenghtProfile,
                    LenghtProfileTwo = LenghtProfileTwo,
                    Annotation =Annotation
                });  
            }  
        }
        void SaveListAllSpecification()
        {
            SpecificationAllDescriptionRepository reposSpecification = new SpecificationAllDescriptionRepository();
            DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();

            ProfileCardRepository profileCardRepos = new ProfileCardRepository();
            var maxid = reposSpecification.GetById();
            var maxidReception = reposDetailReception.GetById();
            for (int i = 0; i < AllSpecification.Count; i++)
            {
                bool checkValue = reposSpecification.CheckValue(AllSpecification[i].NumberSpecification, AllSpecification[i].NomenclatureProfile, AllSpecification[i].LenghtProfileMustBe);
              if (!checkValue)
                {
                    SpecificationAllDescription specificationDescription = new SpecificationAllDescription();
                    DetailReceptionMaterials receptionDetals = new DetailReceptionMaterials();
                    double weight = profileCardRepos.GetByWeightProfile(AllSpecification[i].NomenclatureProfile);
                    string EloksalNo = profileCardRepos.GetByEloksalNoCommercial(AllSpecification[i].NomenclatureProfile);
                    specificationDescription.Id = ++maxid;
                    specificationDescription.NumberSpecification = AllSpecification[i].NumberSpecification;
                    specificationDescription.NumberContract = AllSpecification[i].NumberContract;
                    specificationDescription.NomenclatureProfile = AllSpecification[i].NomenclatureProfile;
                    specificationDescription.EloksalNoCommercial = AllSpecification[i].EloksalNoCommercial;
                    specificationDescription.WeightMeter= AllSpecification[i].WeightMeter;
                    specificationDescription.OuterPerimeter = AllSpecification[i].OuterPerimeter;
                    specificationDescription.AmountKg = AllSpecification[i].AmountKgChange;
                    specificationDescription.AmountPiece = AllSpecification[i].AmountPiece;
                    specificationDescription.AmountPMetr = AllSpecification[i].AmountPMetrChange;
                    specificationDescription.PriceKg = AllSpecification[i].CalculatePriceKg;
                    specificationDescription.PricePiece = AllSpecification[i].CalculatePricePiece;
                    specificationDescription.PricePMetr = AllSpecification[i].CalculatePMetr;
                    specificationDescription.PriceProfileArea = AllSpecification[i].PriceProfileArea;
                    specificationDescription.TotalSum = AllSpecification[i].TotalSumWeight;
                    specificationDescription.LenghtProfileMustBe = AllSpecification[i].LenghtProfileMustBe;
                    specificationDescription.AmountPieceMustBe = AllSpecification[i].AmountPieceMustBe;
                    specificationDescription.LenghtProfileFact = AllSpecification[i].LenghtProfileFact;
                    specificationDescription.AmountPieceFact= AllSpecification[i].AmountPieceFact;
                    specificationDescription.LenghtProfile = AllSpecification[i].LenghtProfile;
                    specificationDescription.LenghtProfileTwo = AllSpecification[i].LenghtProfileTwo;
                    specificationDescription.AmountPieceTwo = AllSpecification[i].AmountPieceTwo;
                    specificationDescription.ChoiceKg = AllSpecification[i].ChoiceKg;
                    specificationDescription.ChoicePiece = AllSpecification[i].ChoicePiece;
                    specificationDescription.ChoicePMetr = AllSpecification[i].ChoicePMetr;
                    specificationDescription.Annotation = AllSpecification[i].Annotation;
                    reposSpecification.Add(specificationDescription);
                    if (Calculation == false)
                    {
                        receptionDetals.Id = ++maxidReception;
                        receptionDetals.NumberSpecification = AllSpecification[i].NumberSpecification;
                        receptionDetals.NomenclatureProfile = AllSpecification[i].NomenclatureProfile;
                        receptionDetals.EloksalNoCommercial = EloksalNo;
                        receptionDetals.AmountPieceFact = AllSpecification[i].AmountPieceMustBe;
                        receptionDetals.LenghtFact = AllSpecification[i].LenghtProfileMustBe;
                        receptionDetals.WeightMeter = weight;
                        receptionDetals.ClientName = ClientNameSource;
                        reposDetailReception.Add(receptionDetals);
                    }
                }
                else
                {
                    UpdateDataDescription();
                }
            }

            RefreshProductionOperation();
            MessageBox.Show("Данные успешно сохранены");
        }
        public void AddTimer()
        {
            Timer timer = new Timer();
            timer.Elapsed += RefreshProductionOperation;
            timer.Interval = 2000;
            timer.AutoReset = false;
            timer.Start();
        }
        public void RefreshProductionOperation(object sender, ElapsedEventArgs e)
        {
            SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
            AllSpecification = repos.GetByAllEntityObservableCollection(NumberSpecification);
        }
        public void RefreshProductionOperation()
        {
            SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
            AllSpecification = repos.GetByAllEntityObservableCollection(NumberSpecification);
        }
        //void CheckNumberSpesification()
        //{
        //    SpecificationEloksalProfileRepository repos = new SpecificationEloksalProfileRepository();
        //    List<SpecificationEloksalProfile> specification = new List<SpecificationEloksalProfile>();
        //    specification = repos.GetByAllEntity();
        //    List<string> listNumberSpecification = specification.Select(p => p.NumberSpecification).ToList();
        //     if (listNumberSpecification.Contains(NumberSpecification.Trim()))
        //    {
        //        MessageBox.Show("Данная спецификация уже есть в базе данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //}
        void InsertReceptionMaterials()
        {
            if (Calculation == false)
            {
                ReceptionMaterialsRepository reposReseptionMaterials = new ReceptionMaterialsRepository();
                ReceptionMaterials receptionMaterials = new ReceptionMaterials();
                bool checkValue = reposReseptionMaterials.CheckValueNumberSpecification(NumberSpecification);
                if (!checkValue)
                {
                    int maxId = reposReseptionMaterials.GetById();
                    if (SpecificationEloksalProfile.DateSpecification == DateTime.MinValue)
                    {
                        SpecificationEloksalProfile.DateSpecification = DateTime.Now;
                    }
                    receptionMaterials.Id = ++maxId;
                    receptionMaterials.ClientName = ClientNameSource;
                    receptionMaterials.NumberSpecification = NumberSpecification;
                    receptionMaterials.DateSpecification = SpecificationEloksalProfile.DateSpecification;
                    reposReseptionMaterials.Add(receptionMaterials);
                }
            }
         
        }

        void UpdatePriceList(object obj)
        {
            PriceListProfileRepository repos = new PriceListProfileRepository();
            foreach(var item in AllSpecification)
            {
                repos.ProfilePriceUpdate(ClientNameSource,item.EloksalNoCommercial,item.NomenclatureProfile, Convert.ToDouble(item.CalculatePriceKg), Convert.ToDouble(item.CalculatePMetr), Convert.ToDouble(item.PriceProfileArea));
            }   
        }
        void UpdateDataDescription()
        {
            SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
            SpecificationEloksalProfileRepository reposSpecification = new SpecificationEloksalProfileRepository();
            ReceptionMaterialsRepository reposReseptionMaterials = new ReceptionMaterialsRepository();
            DetailReceptionMaterialsRepository reposDetailReseptionMaterials = new DetailReceptionMaterialsRepository();
            ProfileCardRepository reposProfile = new ProfileCardRepository();
            double massa=0;
            foreach (var item in AllSpecification)
            {
                repos.UpdateSpecificationAllDescriptionAmountTeor(item.Id, item.AmountPieceMustBe, item.AmountPieceFact, item.LenghtProfileMustBe,item.AmountPiece,item.AmountKgChange,
                                                                  item.AmountPMetrChange,item.TotalSumWeight,item.LenghtProfileFact,item.ChoiceKg,item.ChoicePiece,item.ChoicePMetr,
                                                                  item.CalculatePriceKg, item.CalculatePMetr, item.CalculatePricePiece, item.PriceProfileArea,item.AmountPieceTwo);
                reposDetailReseptionMaterials.UpdateReceptionDetailMaterials(item.NumberSpecification,item.NomenclatureProfile, item.AmountPieceMustBe, item.LenghtProfileMustBe);
                double profileList = reposProfile.GetByWeightProfile(item.NomenclatureProfile);
                massa = Math.Round(massa + (item.LenghtProfileFact*item.AmountPieceFact*profileList / 1000000),2);
            }
           reposSpecification.UpdateSpecification(Id, NumberSpecification, SpecificationEloksalProfile.DateSpecification);
            if (Calculation == false)
            {
                reposReseptionMaterials.UpdateReceptionMaterials(NumberSpecification, massa);
            }          
        }

        //void ChoiceInsertOrUpdate(object obj)
        //{
        //    if (Id == 0) InsertAllSpecification();
        //    else UpdateDataDescription();
        //}
        void OpenReportSpecification(object obj)
        {
            if (ClientNameSource.Contains("ВМК") || ClientNameSource.Contains("Реалит"))
            {
                try
                {
                    SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
                    List<SpecificationAllDescription> listDescription = new List<SpecificationAllDescription>();
                    List<AppendixSpesification> listAppendix = new List<AppendixSpesification>();
                    listAppendix = GetAllAppendixSpecification(NumberSpecification);
                    listDescription = repos.GetByAllEntityListCollection(NumberSpecification);
                    WindowSpecification specification = new WindowSpecification();
                    specification.Show();
                    specification.PrintInvoiceIndividualClient(ClientNameSource, SpecificationEloksalProfile.DateSpecification, NumberSpecification, NumberContract,
                        Convert.ToDateTime(DateContract), listDescription, listAppendix);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            //else if (ClientNameSource.Contains("Реалит"))
            //{
            //    try
            //    {
            //        SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
            //        List<SpecificationAllDescription> listDescription = new List<SpecificationAllDescription>();
            //        List<AppendixSpesification> listAppendix = new List<AppendixSpesification>();
            //        listAppendix = GetAllAppendixSpecification(NumberSpecification);
            //        listDescription = repos.GetByAllEntityListCollection(NumberSpecification);
            //        WindowSpecification specification = new WindowSpecification();
            //        specification.Show();
            //        specification.PrintInvoiceIndividualClient(ClientNameSource, SpecificationEloksalProfile.DateSpecification, NumberSpecification, NumberContract,
            //            Convert.ToDateTime(DateContract), listDescription, listAppendix);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //}
            else
            {
                try
                {
                    SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
                    List<SpecificationAllDescription> listDescription = new List<SpecificationAllDescription>();
                    List<AppendixSpesification> listAppendix = new List<AppendixSpesification>();
                    listAppendix = GetAllAppendixSpecification(NumberSpecification);
                    listDescription = repos.GetByAllEntityListCollection(NumberSpecification);
                    WindowSpecification specification = new WindowSpecification();
                    specification.Show();
                    specification.PrintInvoice(ClientNameSource, SpecificationEloksalProfile.DateSpecification, NumberSpecification, NumberContract,
                        Convert.ToDateTime(DateContract), listDescription, listAppendix);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
           
        }
        void OpenReportSpecificationTwo(object obj)
        {
                try
                {
                    SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
                    List<SpecificationAllDescription> listDescription = new List<SpecificationAllDescription>();
                    List<AppendixSpesification> listAppendix = new List<AppendixSpesification>();
                    listAppendix = GetAllAppendixSpecification(NumberSpecification);
                    listDescription = repos.GetByAllEntityListCollection(NumberSpecification);
                    WindowSpecification specification = new WindowSpecification();
                    specification.Show();
                    specification.PrintInvoiceTwo(ClientNameSource, SpecificationEloksalProfile.DateSpecification, NumberSpecification, NumberContract,
                        Convert.ToDateTime(DateContract), listDescription, listAppendix);
                }
                catch
                {
                    MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }  
        public void InsertAllSpecification(object obj)
        {
            var list = AllSpecification.Select(p => p.NumberSpecification).ToList();
            if (!list.Contains(NumberSpecification))
            {
                MessageBox.Show("Номер спецификации в номенклатуре не соответствует!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                InsertNewSpecification();
                SaveListAllSpecification();
                InsertReceptionMaterials();
            }
            
        }
        public void GetNumberContract()
        {
            ClientCardRepository repos = new ClientCardRepository();
            _numberContract =  repos.GetByNumberContract(ClientNameSource);
            OnPropertyChanged(nameof(NumberContract));
            _dateContract=repos.GetByDateContract(ClientNameSource);
            OnPropertyChanged(nameof(DateContract));

        }
        public List<AppendixSpesification> GetAllAppendixSpecification(string numberSpecification)
        {
            SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
            ProfileCardRepository reposProfile = new ProfileCardRepository();
            List<SpecificationAllDescription> listSpecification = new List<SpecificationAllDescription>();
            listSpecification = repos.GetByAllEntityListCollection(numberSpecification);
            List<ProfileCard> profileList = new List<ProfileCard>();
            profileList = reposProfile.GetByAllEntity();
            var inventory = from l1 in listSpecification
                            join l2 in profileList on l1.NomenclatureProfile.Trim() equals l2.NomenclatureProfile.Trim()
                            into temp
                            from lj in temp.DefaultIfEmpty()
                            select new AppendixSpesification
                            {
                                EloksalNoCommercial = l1.EloksalNoCommercial,
                                LenghtProfile = lj.LenghtProfile,
                                AmountPiece = l1.AmountPiece,
                                LenghtProfileTwo = lj.LenghtProfileTwo,
                                AmountPieceTwo = l1.AmountPieceTwo,
                                NomenclatureProfile = l1.NomenclatureProfile,
                                LenghtProfileFact = l1.LenghtProfileFact,
                                AmountPieceFact = l1.AmountPieceFact,
                                WeightPMetr = lj.WeightMeter,
                                OuterPerimeter=lj.OuterPerimeter,
                                ThicknessCoating = lj.ThicknessCoating,
                                TypePackaging = lj.TypeAnod
                            };
            List <AppendixSpesification> list = inventory.AsEnumerable().ToList();
            return list;
        }
        //void UpdatePriceProfileArea()
        //{
        //    PriceListProfileRepository reposPriceProfile = new PriceListProfileRepository();
        //    _priceProfileArea = reposPriceProfile.GetPriceAreaProfile(NomenclatureSource);
        //    OnPropertyChanged(nameof(PriceProfileArea));

        //}
        //void CalculateSumProfileArea()
        //{
        //    ProfileCardRepository reposProfile = new ProfileCardRepository();
        //    int lenghtProfile = reposProfile.GetByLenghtProfile(NomenclatureSource);
        //    double outerProfile = reposProfile.GetByOuterPerimetrProfile(NomenclatureSource);
        //    double areaProfile = (lenghtProfile * outerProfile * Count) / 1000000;
        //    _sumProfileArea = Math.Round((PriceProfileArea * areaProfile),2);
        //    OnPropertyChanged(nameof(SumProfileArea));
        //}

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

        void SaveSpecificationToCsv(object obj)
        {
            SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
            List<SpecificationForScore> list = repos.GetByAllEntityListCollectionForScore(NumberSpecification);
            SaveToCsv(list, NumberSpecification);
            string path= @"C:\Score";
            Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
        }
         void SaveToCsv(List<SpecificationForScore> data,string NumberSpecification)
        {
            string folderPath = @"C:\Score";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string fileName = $"{NumberSpecification}.csv";
            string path = Path.Combine(@"C:\Score\", fileName);
            using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8)) { 

                // Запись заголовков колонок
                writer.WriteLine("Товары (работы, услуги);Кол-во;Ед.;Цена;Сумма");

            foreach (var item in data)
            {
                writer.WriteLine($"{item.NomenclatureProfile};{item.AmountProfile};{item.UnitProfile};{item.PriceProfile};{item.TotalSumProfile}"); }
            }
        }
    }
}
