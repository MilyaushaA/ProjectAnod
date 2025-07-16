using EloksalPro.Models;
using EloksalPro.Repositories;
using EloksalPro.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace EloksalPro.ViewModels
{
    public class ProfileConsumptionWarehouseViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        private DateTime _dateProfileConsumptionWarehouse;// дата анодирования
        private string _numberProfileConsumptionWarehouse;// номер анодирования
        private List<string> _numberSpecification; // номер заказа
        private List<string> _basketNumberList;
        private string _basketNumberSource; // 
        private string _numberSpecificationSource; // 
        private List<string> _nomenclatureProfileList; // номенклатура профиля
        private string _nomenclatureSource;
        private string _eloksalNoCommercial; // коммерческий номер
        private string _clientName; // наименование клиента
        private double _weightMeter; // вес погонного метра
        private int _amountPieceFact;// количество хлыстов
        private int _amountPieceDefect;// количество брака хлыстов
        private int _lenghtFact;// длина хлыста
        private double _weightGeneral;// общий вес 
        private double _weightGeneralDefect;// общий вес бракованного профиля
        private string _annotation;// примечание
        private List<string> _workingShiftList = new List<string>() { "08:00-20:00", "20:00-08:00" };
        private string _workingShiftSource;
        private List<string> _employeeList;
        private string _employeeSource;
        public double _outerPerimeter; // внешний периметр
        public double _totalArea; // общая площадь
        public int _id; // 
        public double _generalAreaProducedProfile;
        public double _generalAreaDefectiveProfile;
        public double GeneralAreaProducedProfile
        {
            get { return _generalAreaProducedProfile; }
            set { _generalAreaProducedProfile = value; OnPropertyChanged(nameof(GeneralAreaProducedProfile)); }
        }
        public double GeneralAreaDefectiveProfile
        {
            get { return _generalAreaDefectiveProfile; }
            set { _generalAreaDefectiveProfile = value; OnPropertyChanged(nameof(GeneralAreaDefectiveProfile)); }
        }
        public DateTime DateProfileConsumptionWarehouse
        {
            get { return _dateProfileConsumptionWarehouse; }
            set { _dateProfileConsumptionWarehouse = value; OnPropertyChanged(nameof(DateProfileConsumptionWarehouse)); }
        }
        public string NumberProfileConsumptionWarehouse
        {
            get { return _numberProfileConsumptionWarehouse; }
            set { _numberProfileConsumptionWarehouse = value; OnPropertyChanged(nameof(NumberProfileConsumptionWarehouse)); }
        }
        public List<string> NumberSpecification
        {
            get { return _numberSpecification; }
            set { _numberSpecification = value; OnPropertyChanged(nameof(NumberSpecification)); }
        }
        public List<string> BasketNumberList
        {
            get { return _basketNumberList; }
            set { _basketNumberList = value; OnPropertyChanged(nameof(BasketNumberList)); }
        }
        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value; UpdateListNomenclature(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string EloksalNoCommercial
        {
            get { return _eloksalNoCommercial; }
            set { _eloksalNoCommercial = value; OnPropertyChanged(nameof(EloksalNoCommercial)); }
        }
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; OnPropertyChanged(nameof(ClientName)); }
        }
        public double WeightMeter
        {
            get { return _weightMeter; }
            set { _weightMeter = value; OnPropertyChanged(nameof(WeightMeter)); }
        }
        public int AmountPieceFact
        {
            get { return _amountPieceFact; }
            set { _amountPieceFact = value; UpdateGeneralWeight(); OnPropertyChanged(nameof(AmountPieceFact)); }
        }
        public int AmountPieceDefect
        {
            get { return _amountPieceDefect; }
            set { _amountPieceDefect = value; UpdateGeneralWeightDefect(); OnPropertyChanged(nameof(AmountPieceDefect)); }
        }
        public int LenghtFact
        {
            get { return _lenghtFact; }
            set { _lenghtFact = value; OnPropertyChanged(nameof(LenghtFact)); }
        }
        public double WeightGeneral
        {
            get { return _weightGeneral; }
            set { _weightGeneral = value; OnPropertyChanged(nameof(WeightGeneral)); }
        }
        public double WeightGeneralDefect
        {
            get { return _weightGeneralDefect; }
            set { _weightGeneralDefect = value; OnPropertyChanged(nameof(WeightGeneralDefect)); }
        }
        public string Annotation
        {
            get { return _annotation; }
            set { _annotation = value; OnPropertyChanged(nameof(Annotation)); }
        }
        public double OuterPerimeter
        {
            get { return _outerPerimeter; }
            set { _outerPerimeter = value; OnPropertyChanged(nameof(OuterPerimeter)); }
        }
        public double TotalArea
        {
            get { return _totalArea; }
            set { _totalArea = value; OnPropertyChanged(nameof(TotalArea)); }
        }
        public string WorkingShiftSource
        {
            get { return _workingShiftSource; }
            set { _workingShiftSource = value; OnPropertyChanged(nameof(WorkingShiftSource)); }
        }
        public List<string> WorkingShiftList
        {
            get { return _workingShiftList; }
            set { _workingShiftList = value; OnPropertyChanged(nameof(WorkingShiftList)); }
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
        public List<string> NomenclatureProfileList
        {
            get { return _nomenclatureProfileList; }
            set { _nomenclatureProfileList = value; OnPropertyChanged(nameof(NomenclatureProfileList)); }
        }
        public string NomenclatureSource
        {
            get { return _nomenclatureSource; }
            set { _nomenclatureSource = value; GetUpdateDataProfile(); GetBasketNumberList(); OnPropertyChanged(nameof(NomenclatureSource)); }
        }
        public string BasketNumberSource
        {
            get { return _basketNumberSource; }
            set { _basketNumberSource = value; OnPropertyChanged(nameof(BasketNumberSource)); }
        }
        private ObservableCollection<ProfileConsumptionWarehouse> _profileConsumptionWarehouseList = new ObservableCollection<ProfileConsumptionWarehouse>();
        public ObservableCollection<ProfileConsumptionWarehouse> ProfileConsumptionWarehouseList
        {
            get { return _profileConsumptionWarehouseList; }
            set { _profileConsumptionWarehouseList = value; OnPropertyChanged(nameof(ProfileConsumptionWarehouseList)); }
        }
        private List<PackingAluminumProfileForShipment> _profileParkingList = new List<PackingAluminumProfileForShipment>();
        public List<PackingAluminumProfileForShipment> ProfileParkingList
        {
            get { return _profileParkingList; }
            set { _profileParkingList = value; OnPropertyChanged(nameof(ProfileParkingList)); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand ShowRemoveCommand { get; }
        public ICommand ShowPrintReportsCommand { get; }
        public ICommand ShowInsertShipmentCommand { get; }
        public ProfileConsumptionWarehouseViewModel()
        {
            ProfileConsumptionWarehouseRepository repos = new ProfileConsumptionWarehouseRepository();
            NumberSpecification = GetListNumberSpecification();
            int MaxEloksalNo = repos.MaxNumberProfileConsumptionWarehouse() + 1;
            NumberProfileConsumptionWarehouse =/* "CW" +*/ MaxEloksalNo.ToString("D3");
            ShowRemoveCommand = new ViewModelCommand(RemoveCommand);
            SaveInsertCommand = new ViewModelCommand(InsertNewConsumptionWarehouse);
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsernameRoleTwo();
            ShowPrintReportsCommand = new ViewModelCommand(OpenReportSpecification);
            ShowInsertShipmentCommand = new ViewModelCommand(InsertShipmentCommand);
            ProfileParkingList = GetListPackingAluminumProfiles();
            AddTimer();
        }
        public List<string> GetListNumberSpecification()
        {
            PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
            List<string> list = new List<string>();
            list = repos.GetNumberSpecification().Distinct().ToList();
            return list;
        }
        public void GetBasketNumberList()
        {
            PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
            _basketNumberList = repos.GetBasketNumber(NomenclatureSource).ToList();
            OnPropertyChanged(nameof(BasketNumberList));
        }
        public void GetUpdateDataProfile()
        {
            ProfileCardRepository repos = new ProfileCardRepository();
            ProfileCard profile = new ProfileCard();
            profile = repos.GetByListProfileCard(NomenclatureSource);
            if (profile != null)
            {
                _clientName = profile.ClientName;
                OnPropertyChanged(nameof(ClientName));
                _eloksalNoCommercial = profile.EloksalNoCommercial;
                OnPropertyChanged(nameof(EloksalNoCommercial));
                _weightMeter = profile.WeightMeter / 1000;
                OnPropertyChanged(nameof(WeightMeter));
                _outerPerimeter = profile.OuterPerimeter;
                OnPropertyChanged(nameof(OuterPerimeter));
                _lenghtFact = profile.LenghtProfile;
                OnPropertyChanged(nameof(LenghtFact));
            }
        }
        public List<string> GetListNomenclature()
        {
            PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
            List<string> list = new List<string>();
            list = repos.GetNomenclature(NumberSpecificationSource);
            return list;
        }
        public void UpdateListNomenclature()
        {
            _nomenclatureProfileList = GetListNomenclature();
            OnPropertyChanged(nameof(NomenclatureProfileList));
        }
        public void UpdateGeneralWeight()
        {
            _weightGeneral = Math.Round((Convert.ToDouble(AmountPieceFact) * Convert.ToDouble(LenghtFact) * WeightMeter) / 1000, 2);
            OnPropertyChanged(nameof(WeightGeneral));
            _generalAreaProducedProfile = Math.Round(OuterPerimeter / 1000 * Convert.ToDouble(LenghtFact) / 1000 * Convert.ToDouble(AmountPieceFact), 2);
            OnPropertyChanged(nameof(GeneralAreaProducedProfile));
        }
        public void UpdateGeneralWeightDefect()
        {
            _weightGeneralDefect = Math.Round((Convert.ToDouble(AmountPieceDefect) * Convert.ToDouble(LenghtFact) * WeightMeter) / 1000, 2);
            OnPropertyChanged(nameof(WeightGeneralDefect));
            _generalAreaDefectiveProfile = Math.Round(OuterPerimeter / 1000 * Convert.ToDouble(LenghtFact) / 1000 * Convert.ToDouble(AmountPieceDefect), 2);
            OnPropertyChanged(nameof(GeneralAreaDefectiveProfile));
        }
        public void InsertNewConsumptionWarehouse(object obj)
        {
            ProfileConsumptionWarehouseRepository repos = new ProfileConsumptionWarehouseRepository();
            ProfileConsumptionWarehouseGeneralRepository reposGeneral = new ProfileConsumptionWarehouseGeneralRepository();
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
            int packingCount = Convert.ToInt32(reposPacking.GetAmountNomenclature(NumberSpecificationSource, NomenclatureSource));
            int consumptionCount = Convert.ToInt32(repos.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource));
            int consumptionCountDefective = Convert.ToInt32(repos.GetCountNomenclatureDefective(NumberSpecificationSource, NomenclatureSource));
            int maxId = repos.GetById();
            if (DateProfileConsumptionWarehouse == DateTime.MinValue)
            {
                DateProfileConsumptionWarehouse = DateTime.Now;
            }
            bool checkValue = reposGeneral.CheckValueProfileConsumptionWarehouse(NumberProfileConsumptionWarehouse);
            int count = reposGeneral.CheckValueProfileConsumptionWarehouseDayShift(DateProfileConsumptionWarehouse);
            //if (count >= 2 && !checkValue)
            //{
            //    MessageBox.Show("За один день можно открыть только две смены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            if (WorkingShiftSource == null || NumberSpecificationSource == null || NomenclatureSource == null || AmountPieceFact == 0 || EmployeeSource == null)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (packingCount < consumptionCount + consumptionCountDefective + AmountPieceFact + AmountPieceDefect)
            {
                MessageBox.Show("Общее количество готового сырья превышает количество упакованного профиля!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (packingCount == consumptionCount + consumptionCountDefective + AmountPieceFact + AmountPieceDefect)
                {
                    List<PackingAluminumProfile> list = reposPacking.GetListPackingAluminumProfile(NomenclatureSource, NumberSpecificationSource);
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            reposPacking.UpdatePackingAluminumProfileProfileReadinessProfile(item.Id, true);
                        }
                    }
                }

                ProfileConsumptionWarehouse profile = new ProfileConsumptionWarehouse();
                profile.Id = ++maxId;
                profile.DateProfileConsumptionWarehouse = DateProfileConsumptionWarehouse;
                profile.NumberProfileConsumptionWarehouse = NumberProfileConsumptionWarehouse;
                profile.BasketNumber = BasketNumberSource;
                profile.NumberSpecification = NumberSpecificationSource;
                profile.NomenclatureProfile = NomenclatureSource;
                profile.EloksalNoCommercial = EloksalNoCommercial;
                profile.ClientName = ClientName;
                profile.WeightMeter = WeightMeter;
                profile.QuantityProducedProfile = AmountPieceFact;
                profile.QuantityDefectedProfile = AmountPieceDefect;
                profile.LenghtProfile = LenghtFact;
                profile.WeightProducedProfile = WeightGeneral;
                profile.WeightDefectedProfile = WeightGeneralDefect;
                profile.OuterPerimeter = OuterPerimeter;
                profile.GeneralAreaProducedProfile = GeneralAreaProducedProfile;
                profile.GeneralAreaDefectiveProfile = GeneralAreaDefectiveProfile;
                repos.Add(profile);
                ProfileConsumptionWarehouseList.Add(profile);
                InsertNewDateProfileConsumptionWarehouseGenerals();
                AddWeightReceptionMaterials();
                MessageBox.Show("Данные сохранены");
                DataReset();
            }
        }
        public void DataReset()
        {
            NomenclatureSource = null;
            EloksalNoCommercial = null;
            ClientName = null;
            WeightMeter = 0;
            AmountPieceFact = 0;
            AmountPieceDefect = 0;
            LenghtFact = 0;
            WeightGeneral = 0;
            WeightGeneralDefect = 0;
            OuterPerimeter = 0;
            TotalArea = 0;
        }
        public void InsertNewDateProfileConsumptionWarehouseGenerals()
        {
            ProfileConsumptionWarehouseGeneralRepository repos = new ProfileConsumptionWarehouseGeneralRepository();
            int maxId = repos.GetById();
            ProfileConsumptionWarehouseGeneral aluminumProfile = new ProfileConsumptionWarehouseGeneral();
            bool checkValue = repos.CheckValueProfileConsumptionWarehouse(NumberProfileConsumptionWarehouse);
            if (!checkValue)
            {
                aluminumProfile.Id = ++maxId;
                aluminumProfile.Date = DateProfileConsumptionWarehouse;
                aluminumProfile.ClientName = ClientName;
                aluminumProfile.Shift = WorkingShiftSource;
                aluminumProfile.Annotation = Annotation;
                aluminumProfile.NumberProfileConsumptionWarehouse = NumberProfileConsumptionWarehouse;
                aluminumProfile.Employee = EmployeeSource;
                repos.Add(aluminumProfile);
            }
        }
        public void InsertNewDateProfileConsumptionWarehouseGenerals(string clientName)
        {
            ProfileConsumptionWarehouseGeneralRepository repos = new ProfileConsumptionWarehouseGeneralRepository();
            int maxId = repos.GetById();
            ProfileConsumptionWarehouseGeneral aluminumProfile = new ProfileConsumptionWarehouseGeneral();
            bool checkValue = repos.CheckValueProfileConsumptionWarehouse(NumberProfileConsumptionWarehouse);
            if (!checkValue)
            {
                aluminumProfile.Id = ++maxId;
                aluminumProfile.Date = DateProfileConsumptionWarehouse;
                aluminumProfile.ClientName = clientName;
                aluminumProfile.Shift = WorkingShiftSource;
                aluminumProfile.NumberProfileConsumptionWarehouse = NumberProfileConsumptionWarehouse;
                aluminumProfile.Employee = EmployeeSource;
                repos.Add(aluminumProfile);
            }
        }
        public void AddTimer()
        {
            Timer timer = new Timer();
            timer.Elapsed += RefreshProductionOperation;
            timer.Interval = 1000;
            timer.AutoReset = false;
            timer.Start();
        }
        public void RefreshProductionOperation(object sender, ElapsedEventArgs e)
        {
            ProfileConsumptionWarehouseRepository repos = new ProfileConsumptionWarehouseRepository();
            ProfileConsumptionWarehouseList = repos.GetAllEntity(NumberProfileConsumptionWarehouse);
        }
        public void AddWeightReceptionMaterials()
        {
            ProfileConsumptionWarehouseGeneralRepository repos = new ProfileConsumptionWarehouseGeneralRepository();
            ProfileConsumptionWarehouseGeneral entity = new ProfileConsumptionWarehouseGeneral();
            entity = repos.GetEntityProfileConsumptionWarehouse(NumberProfileConsumptionWarehouse);
            double weightProduced = entity.WeightProducedProfile;
            double weightDefected = entity.WeightDefectedProfile;
            double areaProduced = entity.GeneralAreaProducedProfile;
            double areaDefected = Convert.ToDouble(entity.GeneralAreaDefectiveProfile);
            double weightProducedAll = weightProduced + WeightGeneral;
            double weightDefectedAll = weightDefected + WeightGeneralDefect;
            double areaProducedAll = areaProduced + GeneralAreaProducedProfile;
            double areatDefectedAll = areaDefected + GeneralAreaDefectiveProfile;
            repos.UpdateConsumptionWarehouseProfile(NumberProfileConsumptionWarehouse, weightProducedAll, weightDefectedAll, areaProducedAll, areatDefectedAll);
        }
        public void AddWeightReceptionMaterials(double weightGeneral, double generalAreaProducedProfile)
        {
            ProfileConsumptionWarehouseGeneralRepository repos = new ProfileConsumptionWarehouseGeneralRepository();
            ProfileConsumptionWarehouseGeneral entity = new ProfileConsumptionWarehouseGeneral();
            entity = repos.GetEntityProfileConsumptionWarehouse(NumberProfileConsumptionWarehouse);
            double weightProducedAll = entity.WeightProducedProfile + weightGeneral;
            double areaProducedAll = entity.GeneralAreaProducedProfile + generalAreaProducedProfile;
            repos.UpdateConsumptionWarehouseProfile(NumberProfileConsumptionWarehouse, weightProducedAll, 0, areaProducedAll, 0);
        }
        public void RemoveCommand(object obj)
        {
            //ProfileConsumptionWarehouseRepository repos = new ProfileConsumptionWarehouseRepository();
            //repos.Remove(Id);
            //ProfileConsumptionWarehouseGeneralRepository  reposGeneral = new ProfileConsumptionWarehouseGeneralRepository();
            //double weightProduced = 0;
            //double weightDefected = 0;
            //double areaProduced = 0;
            //double areaDefected = 0;
            //ProfileConsumptionWarehouseList = repos.GetAllEntity(NumberProfileConsumptionWarehouse);
            //foreach (var item in ProfileConsumptionWarehouseList)
            //{
            //    weightProduced += item.WeightProducedProfile;
            //    weightDefected += item.WeightDefectedProfile;
            //    areaProduced += item.GeneralAreaProducedProfile;
            //    areaDefected += Convert.ToDouble(item.GeneralAreaDefectiveProfile);
            //}
            //reposGeneral.UpdateConsumptionWarehouseProfile(NumberProfileConsumptionWarehouse, weightProduced, weightDefected, areaProduced, areaDefected);

            ProfileConsumptionWarehouseRepository repos = new ProfileConsumptionWarehouseRepository();
            ProfileConsumptionWarehouseGeneralRepository reposGeneral = new ProfileConsumptionWarehouseGeneralRepository();

            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();

            ProfileConsumptionWarehouse entity = new ProfileConsumptionWarehouse();
            ProfileConsumptionWarehouseGeneral entityGeneral = new ProfileConsumptionWarehouseGeneral();

            entity = repos.GetByEntity(Id);
            if (entity != null)
            {
                double? weightProduced = entity.WeightProducedProfile;
                double? weightDefected = entity.WeightDefectedProfile;
                double? areaProduced = entity.GeneralAreaProducedProfile;
                double? areaDefected = entity.GeneralAreaDefectiveProfile;
                string name = entity.NumberSpecification;

                entityGeneral = reposGeneral.GetEntityProfileConsumptionWarehouse(entity.NumberProfileConsumptionWarehouse);

                double weightProd = Math.Round(Convert.ToDouble(entityGeneral.WeightProducedProfile) - Convert.ToDouble(weightProduced), 2);
                double weightDefect = Math.Round(Convert.ToDouble(entityGeneral.WeightDefectedProfile) - Convert.ToDouble(weightDefected), 2);
                double areaProd = Math.Round(Convert.ToDouble(entityGeneral.GeneralAreaProducedProfile) - Convert.ToDouble(areaProduced), 2);
                double areaDefect = Math.Round(Convert.ToDouble(entityGeneral.GeneralAreaDefectiveProfile) - Convert.ToDouble(areaDefected), 2);

                reposGeneral.UpdateConsumptionWarehouseProfile(entity.NumberProfileConsumptionWarehouse, Convert.ToDouble(weightProd), Convert.ToDouble(weightDefect), Convert.ToDouble(areaProd), Convert.ToDouble(areaDefect));


                List<PackingAluminumProfile> list = reposPacking.GetListPackingAluminumProfile(entity.NomenclatureProfile, entity.NumberSpecification);
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        reposPacking.UpdatePackingAluminumProfileProfileReadinessProfile(item.Id, false);
                    }
                }
                repos.Remove(Id);
                ProfileConsumptionWarehouseList = repos.GetAllEntity(NumberProfileConsumptionWarehouse);
            }
        }
        void OpenReportSpecification(object obj)
        {
            try
            {
                WindowReportsShift reportView = new WindowReportsShift();
                reportView.Show();
                ProfileConsumptionWarehouseRepository repos = new ProfileConsumptionWarehouseRepository();
                List<ProfileConsumptionWarehouse> list = new List<ProfileConsumptionWarehouse>();
                list = repos.GetListAllEntity(NumberProfileConsumptionWarehouse);
                reportView.PrintInvoiceShip(ClientName, DateProfileConsumptionWarehouse.ToString("yyyy-MM-dd"), NumberProfileConsumptionWarehouse, LoadCurrentUserData(), list);
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        List<PackingAluminumProfileForShipment> GetListPackingAluminumProfiles()
        {
            List<String> list = new List<String>();
            ProfileConsumptionWarehouseRepository repos = new ProfileConsumptionWarehouseRepository();
            list = repos.GetListBasketNumber();
            PackingAluminumProfileRepository reposParkig = new PackingAluminumProfileRepository();
            List<PackingAluminumProfileForShipment> listParking = new List<PackingAluminumProfileForShipment>();
            listParking = reposParkig.GetByPackingAluminumProfileForShipment();
            List<PackingAluminumProfileForShipment> result = listParking.Where(p => !list.Any(p2 => p2 == p.BasketNumber)).ToList();
            return result;
        }
        void InsertShipmentCommand(object obj)
        {
            ProfileConsumptionWarehouseGeneralRepository repos = new ProfileConsumptionWarehouseGeneralRepository();
            bool checkValue = repos.CheckValueProfileConsumptionWarehouse(NumberProfileConsumptionWarehouse);
            if (WorkingShiftSource == null || DateProfileConsumptionWarehouse == null || EmployeeSource == null || NumberProfileConsumptionWarehouse == null)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (checkValue)
            {
                MessageBox.Show("Данный номер отгрузки уже создан!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                ProfileConsumptionWarehouseRepository reposProfileConsumption = new ProfileConsumptionWarehouseRepository();
                for (int i = 0; i < ProfileParkingList.Count; i++)
                {
                   if (ProfileParkingList[i].PalletSelection == true)
                    {
                        if (DateProfileConsumptionWarehouse == DateTime.MinValue)
                        {
                            DateProfileConsumptionWarehouse = DateTime.Now;
                        }
                        ProfileConsumptionWarehouse profileConsumptionWarehouse = new ProfileConsumptionWarehouse();
                        int maxid = repos.GetById();
                        profileConsumptionWarehouse.Id = ++maxid;
                        profileConsumptionWarehouse.DateProfileConsumptionWarehouse = DateProfileConsumptionWarehouse;
                        profileConsumptionWarehouse.NumberSpecification = ProfileParkingList[i].NumberSpecification;
                        profileConsumptionWarehouse.NumberProfileConsumptionWarehouse = NumberProfileConsumptionWarehouse;
                        profileConsumptionWarehouse.BasketNumber = ProfileParkingList[i].BasketNumber;
                        profileConsumptionWarehouse.ClientName = ProfileParkingList[i].ClientName;
                        profileConsumptionWarehouse.EloksalNoCommercial = ProfileParkingList[i].EloksalNoCommercial;
                        profileConsumptionWarehouse.NomenclatureProfile = ProfileParkingList[i].NomenclatureProfile;
                        profileConsumptionWarehouse.WeightMeter = ProfileParkingList[i].WeightMeter;
                        profileConsumptionWarehouse.QuantityProducedProfile = ProfileParkingList[i].QuantityProducedProfile;
                        profileConsumptionWarehouse.WeightProducedProfile = ProfileParkingList[i].WeightProducedProfile;
                        profileConsumptionWarehouse.QuantityProducedProfile = ProfileParkingList[i].QuantityProducedProfile;
                        profileConsumptionWarehouse.LenghtProfile = ProfileParkingList[i].LenghtProfile;
                        profileConsumptionWarehouse.OuterPerimeter = ProfileParkingList[i].OuterPerimeter;
                        profileConsumptionWarehouse.GeneralAreaProducedProfile = ProfileParkingList[i].GeneralAreaProducedProfile;
                        profileConsumptionWarehouse.ReadinessProfile = false;
                        profileConsumptionWarehouse.Annotation = "";
                        reposProfileConsumption.Add(profileConsumptionWarehouse);
                        InsertNewDateProfileConsumptionWarehouseGenerals(ProfileParkingList[i].ClientName);
                        AddWeightReceptionMaterials(ProfileParkingList[i].WeightProducedProfile, ProfileParkingList[i].GeneralAreaProducedProfile);
                    }
                }
                if (MessageBox.Show("Открыть отгрузочный лист?",
                       "",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        ProfileConsumptionWarehouseView consumptionWarehouse = new ProfileConsumptionWarehouseView();
                        consumptionWarehouse.Show();
                        var list = repos.GetEntityProfileConsumptionWarehouse(NumberProfileConsumptionWarehouse);
                        if (list != null)
                        {
                            consumptionWarehouse.txtNumber.Text = list.NumberProfileConsumptionWarehouse;
                            consumptionWarehouse.txtDate.Text = list.Date.ToString();
                            consumptionWarehouse.txtShift.Text = list.Shift;
                            consumptionWarehouse.txtClientName.Text = list.ClientName;
                        }
                        AddTimer();
                    }

                    catch
                    {
                        MessageBox.Show("Ошибка при открытие.");
                    }
                }
                ProfileParkingList = GetListPackingAluminumProfiles();
            }      
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

            string name = CurrentUserAccount.DisplayName;
            string[] words = name.Split(new char[] { ' ' });
            string firstLetters = "";
            if (words.Length == 3)
            {
                firstLetters = words[0] + " " + words[1].Substring(0, 1) + "." + words[2].Substring(0, 1) + ".";

            }
            else
                firstLetters = name;

            return firstLetters;
        }
    }
    }
