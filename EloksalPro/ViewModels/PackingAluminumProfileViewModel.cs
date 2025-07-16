using EloksalPro.Models;
using EloksalPro.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Timers;
using System.Windows;
using EloksalPro.View;

namespace EloksalPro.ViewModels
{/// <summary>
/// Упаковка алюминиевого профиля
/// </summary>
    public class PackingAluminumProfileViewModel:ViewModelBase
    {
        private PackingAluminumProfile _packingAluminumProfile = new PackingAluminumProfile();
        private string _workingShiftSource;
        public string _numberSpecificationSource;
        private string _clientName;
        private List<string> _nomenclatureProfileList;
        private string _nomenclatureSource;
        private string _eloksalNoCommercial;
        private double _weightMeter;
        private int _lenghtFact; //  длина профиля до распила
        private int _quantityProducedProfile; // количество хлыстов 
        private double _weightProducedProfile;//вес профиля 
        private int _quantityDefectedProfile; // количество хлыстов 
        private double _weightDefectedProfile;//вес профиля 
        private List<string> _employeeList;
        private string _employeeSource;
        private int _id;
        public double _outerPerimeter; // внешний периметр
        public double _generalAreaProducedProfile;
        public double _generalAreaDefectiveProfile;

        public double OuterPerimeter
        {
            get { return _outerPerimeter; }
            set { _outerPerimeter = value; OnPropertyChanged(nameof(OuterPerimeter)); }
        }
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
        DetailReceptionMaterialsRepository detailReception = new DetailReceptionMaterialsRepository();
        private ObservableCollection<PackingAluminumProfile> _packingAluminumProfileList = new ObservableCollection<PackingAluminumProfile>();
        public ObservableCollection<PackingAluminumProfile> PackingAluminumProfileList
        {
            get { return _packingAluminumProfileList; }
            set { _packingAluminumProfileList = value; OnPropertyChanged(nameof(PackingAluminumProfileList)); }
        }
        public PackingAluminumProfile PackingAluminumProfile
        {
            get { return _packingAluminumProfile; }
            set { _packingAluminumProfile = value; OnPropertyChanged(nameof(PackingAluminumProfile)); }
        }
        public string WorkingShiftSource
        {
            get { return _workingShiftSource; }
            set { _workingShiftSource = value; OnPropertyChanged("WorkingShiftSource"); }
        }
        private List<string> _workingShiftList = new List<string>() { "08:00-20:00", "20:00-08:00" };
        public List<string> WorkingShiftList
        {
            get { return _workingShiftList; }
            set { _workingShiftList = value; OnPropertyChanged(nameof(WorkingShiftList)); }
        }
        private List<string> _numderSpecification;
        public List<string> NumderSpecification
        {
            get { return _numderSpecification; }
            set { _numderSpecification = value; OnPropertyChanged(nameof(NumderSpecification)); }
        }
        public List<string> NomenclatureProfileList
        {
            get { return _nomenclatureProfileList; }
            set { _nomenclatureProfileList = value; OnPropertyChanged(nameof(NomenclatureProfileList)); }
        }
        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value; GetEloksalNomenclatureProfile(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }
        public string NomenclatureSource
        {
            get { return _nomenclatureSource; }
            set { _nomenclatureSource = value; GetUpdateDataProfile(); OnPropertyChanged(nameof(NomenclatureSource)); }
        }
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; OnPropertyChanged(nameof(ClientName)); }
        }
        public string EloksalNoCommercial
        {
            get { return _eloksalNoCommercial; }
            set { _eloksalNoCommercial = value; OnPropertyChanged(nameof(EloksalNoCommercial)); }
        }
        public double WeightMeter
        {
            get { return _weightMeter; }
            set { _weightMeter = value; OnPropertyChanged(nameof(WeightMeter)); }
        }
        public int LenghtFact
        {
            get { return _lenghtFact; }
            set { _lenghtFact = value; OnPropertyChanged(nameof(LenghtFact)); }
        }
        public int QuantityProducedProfile
        {
            get { return _quantityProducedProfile; }
            set { _quantityProducedProfile= value; GetWeightProfileProduced(); OnPropertyChanged(nameof(QuantityProducedProfile)); }
        }
        public double WeightProducedProfile
        {
            get { return _weightProducedProfile; }
            set { _weightProducedProfile = value; OnPropertyChanged(nameof(WeightProducedProfile)); }
        }
        public int QuantityDefectedProfile
        {
            get { return _quantityDefectedProfile; }
            set { _quantityDefectedProfile = value; GetWeightProfileDefected(); OnPropertyChanged(nameof(QuantityDefectedProfile)); }
        }
        public double WeightDefectedProfile
        {
            get { return _weightDefectedProfile; }
            set { _weightDefectedProfile = value; OnPropertyChanged(nameof(WeightDefectedProfile)); }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
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
        public ICommand SaveInsertCommand { get; }
        public ICommand ShowRemoveCommand { get; }
        public PackingAluminumProfileViewModel()
        {
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
            SaveInsertCommand = new ViewModelCommand(InsertNewPackingProfile);
            ShowRemoveCommand = new ViewModelCommand(RemoveCommand);
            NumderSpecification = GetListNumberSpecification();
            int MaxEloksalNo = reposPacking.MaxNumberPackingProfile() + 1;
            PackingAluminumProfile.NumberPackingAluminumProfile = "PA" + MaxEloksalNo.ToString("D4");
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsernameRoleTwo();
            AddTimer();
        }
        public List<string> GetListNumberSpecification()
        {
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTape = new TapeProtectiveProcessProfileRepository();
            СuttingFacingProfileRepository reposCutting = new СuttingFacingProfileRepository();
            List<string> listNomenclatureTape = reposTape.GetNumberSpecificationPacking();
            List<string> listNomenclatureAnod = repos.GetNumberSpecificationPacking();
            List<string> listNomenclatureCutting = reposCutting.GetNumberSpecificationСutting();
            List<string> list = new List<string>();
            list.AddRange(listNomenclatureTape);
            list.AddRange(listNomenclatureAnod);
            list.AddRange(listNomenclatureCutting);
            List<string> listNew = new List<string>();
            listNew = list.Distinct().ToList();
            return listNew;
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
                _outerPerimeter = profile.OuterPerimeter;
                OnPropertyChanged(nameof(OuterPerimeter));
                _eloksalNoCommercial = profile.EloksalNoCommercial;
                OnPropertyChanged(nameof(EloksalNoCommercial));
                _weightMeter = profile.WeightMeter / 1000;
                OnPropertyChanged(nameof(WeightMeter));
                _lenghtFact = profile.LenghtProfile;
                OnPropertyChanged(nameof(LenghtFact));
            }
        }
        public void GetEloksalNomenclatureProfile()
        {
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTape = new TapeProtectiveProcessProfileRepository();
            СuttingFacingProfileRepository reposCutting = new СuttingFacingProfileRepository();

            List<string> listNomenclatureAnod = repos.GetNomenclaturePacking(NumberSpecificationSource);
            List<string> listNomenclatureTape = reposTape.GetNomenclaturenPacking(NumberSpecificationSource);
            List<string> listNomenclatureCutting = reposCutting.GetNomenclatureСutting(NumberSpecificationSource);

            List<string> list = new List<string>();
            list.AddRange(listNomenclatureTape);
            list.AddRange(listNomenclatureAnod);
            list.AddRange(listNomenclatureCutting);
            _nomenclatureProfileList = list;
            OnPropertyChanged(nameof(NomenclatureProfileList));
        }
      
        public void InsertNewPackingProfile(object obj)
        {
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
            PackingAluminumProfileGeneralRepository reposPackingAluminumProfileGeneral = new PackingAluminumProfileGeneralRepository();

            СuttingFacingProfileRepository reposCutting = new СuttingFacingProfileRepository();
            AnodizingProcessProfileRepository reposAnod = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTapeProtective = new TapeProtectiveProcessProfileRepository();

            List <string> listBasketNumber = reposPacking.GetNumberBasket();
            int maxId = reposPacking.GetById();
            if (PackingAluminumProfile.DatePackingAluminumProfile == DateTime.MinValue)
            {
                PackingAluminumProfile.DatePackingAluminumProfile = DateTime.Now;
            }

          
            int anodCount = reposAnod.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource);
            int tapeProtectiveCount = Convert.ToInt32(reposTapeProtective.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource));
            int cuttingFacingProfileCount = Convert.ToInt32(reposCutting.GetCountNomenclatureAfter(NumberSpecificationSource, NomenclatureSource));

            double packingProfilesCount = Convert.ToInt32(reposPacking.GetAmountNomenclature(NumberSpecificationSource, NomenclatureSource));
            double packingProfilesCountDefective = Convert.ToInt32(reposPacking.GetAmountNomenclatureDefective(NumberSpecificationSource, NomenclatureSource));

            bool checkValue = reposPackingAluminumProfileGeneral.CheckValuePackingAluminumProfileGeneral(PackingAluminumProfile.NumberPackingAluminumProfile);
            int count = reposPackingAluminumProfileGeneral.CheckValuePackingAluminumProfileDayShift(PackingAluminumProfile.DatePackingAluminumProfile);
            if (count >= 2 && !checkValue)
            {
                MessageBox.Show("За один день можно открыть только две смены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (WorkingShiftSource == null || NumberSpecificationSource == null || NomenclatureSource == null || QuantityProducedProfile <= 0 || EmployeeSource == null || QuantityDefectedProfile<0)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!NomenclatureSource.Contains("T") && !NomenclatureSource.Contains("R") && !NomenclatureSource.Contains("P") && anodCount < QuantityProducedProfile+QuantityDefectedProfile+ packingProfilesCount+ packingProfilesCountDefective)
            {
                MessageBox.Show("Общее количество упакованного профиля  превышает количество после анодирования!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (NomenclatureSource.Contains("P") && tapeProtectiveCount < QuantityProducedProfile + QuantityDefectedProfile + packingProfilesCount + packingProfilesCountDefective)
            {
                MessageBox.Show("Общее количество упакованного профиля  превышает количество после  нанесения защитной пленки !", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if ((NomenclatureSource.Contains("T") || NomenclatureSource.Contains("R")) &&(!NomenclatureSource.Contains("P")) && cuttingFacingProfileCount < QuantityProducedProfile + QuantityDefectedProfile + packingProfilesCount + packingProfilesCountDefective)
            {
                MessageBox.Show("Общее количество упакованного профиля  превышает количество после  после распила (торцовки)!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (listBasketNumber.Contains(PackingAluminumProfile.BasketNumber))
            {
                MessageBox.Show("Данный паллет уже занесен в базу данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (!NomenclatureSource.Contains("P") && !NomenclatureSource.Contains("T") && !NomenclatureSource.Contains("R") && anodCount == QuantityProducedProfile + QuantityDefectedProfile + packingProfilesCount + packingProfilesCountDefective)
                {
                    List<AnodizingProcessProfile> listAnodizingProcessProfile = reposAnod.GetListAnodizingProcess(NomenclatureSource, NumberSpecificationSource);
                    if (listAnodizingProcessProfile != null)
                    {
                        foreach (var item in listAnodizingProcessProfile)
                        {
                            reposAnod.UpdateAnodizingProcessProfileReadinessProfile(item.Id, true);
                        }
                    }           
                }
                else if (NomenclatureSource.Contains("P") && tapeProtectiveCount == QuantityProducedProfile + QuantityDefectedProfile + packingProfilesCount + packingProfilesCountDefective)
                {
                    List<TapeProtectiveProcessProfile> listTapeProtectiveProcess = reposTapeProtective.GetListTapeProtectiveProcess(NomenclatureSource, NumberSpecificationSource);
                    if (listTapeProtectiveProcess != null)
                    {
                        foreach (var item in listTapeProtectiveProcess)
                        {
                            reposTapeProtective.UpdateTapeProtectiveProcessProfileReadinessProfile(item.Id, true);
                        }
                    }  
                }
                else if ((NomenclatureSource.Contains("T") || NomenclatureSource.Contains("R")) && !NomenclatureSource.Contains("P") && cuttingFacingProfileCount == QuantityProducedProfile + QuantityDefectedProfile + packingProfilesCount + packingProfilesCountDefective)
                {
                    List<СuttingFacingProfile> listСuttingFacingProfile = reposCutting.GetListСuttingFacingProfile(NomenclatureSource, NumberSpecificationSource);
                    if (listСuttingFacingProfile != null)
                    {
                        foreach (var item in listСuttingFacingProfile)
                        {
                            reposCutting.UpdateСuttingFacingProfileProfileReadinessProfile(item.Id, true);
                        }
                    }           
                }
                PackingAluminumProfile packingAluminumProfile = new PackingAluminumProfile();
                packingAluminumProfile.Id = ++maxId;
                packingAluminumProfile.DatePackingAluminumProfile = PackingAluminumProfile.DatePackingAluminumProfile;
                packingAluminumProfile.NumberPackingAluminumProfile = PackingAluminumProfile.NumberPackingAluminumProfile;
                packingAluminumProfile.BasketNumber = PackingAluminumProfile.BasketNumber;
                packingAluminumProfile.NumberSpecification = NumberSpecificationSource;
                packingAluminumProfile.NomenclatureProfile = NomenclatureSource;
                packingAluminumProfile.EloksalNoCommercial = EloksalNoCommercial;
                packingAluminumProfile.ClientName = ClientName;
                packingAluminumProfile.WeightMeter = WeightMeter;
                packingAluminumProfile.OuterPerimeter = OuterPerimeter;
                packingAluminumProfile.LenghtProfile = LenghtFact;
                packingAluminumProfile.QuantityProducedProfile = QuantityProducedProfile;
                packingAluminumProfile.GeneralAreaProducedProfile = GeneralAreaProducedProfile;
                packingAluminumProfile.WeightProducedProfile = WeightProducedProfile;
                packingAluminumProfile.QuantityDefectedProfile = QuantityDefectedProfile;
                packingAluminumProfile.WeightDefectedProfile = WeightDefectedProfile;
                packingAluminumProfile.GeneralAreaDefectiveProfile = GeneralAreaDefectiveProfile;
                packingAluminumProfile.Annotation = PackingAluminumProfile.Annotation;
                reposPacking.Add(packingAluminumProfile);
                PackingAluminumProfileList.Add(packingAluminumProfile);
                InsertNewPackingProfilesGenerals();
                AddWeightReceptionMaterials();
                MessageBox.Show("Данные сохранены"); 
                 DataReset();
            }         
        }
        public void DataReset()
        {
            NumberSpecificationSource = null;
            NomenclatureSource = null;
            EloksalNoCommercial = null;
            ClientName = null;
            WeightMeter = 0;
            LenghtFact = 0;
            OuterPerimeter = 0;
            QuantityProducedProfile = 0;
            QuantityDefectedProfile = 0;
        }
        public void InsertNewPackingProfilesGenerals()
        {
            PackingAluminumProfileGeneralRepository repos = new PackingAluminumProfileGeneralRepository();
            int maxId = repos.GetById();
            PackingAluminumProfileGeneral anodluminumProfile = new PackingAluminumProfileGeneral();
            bool checkValue = repos.CheckValuePackingAluminumProfileGeneral(PackingAluminumProfile.NumberPackingAluminumProfile);
            if (!checkValue)
            {
                anodluminumProfile.Id = ++maxId;
                anodluminumProfile.Date = PackingAluminumProfile.DatePackingAluminumProfile;
                anodluminumProfile.Shift = WorkingShiftSource;
                anodluminumProfile.Annotation = PackingAluminumProfile.Annotation;
                anodluminumProfile.NumberPackingAluminumProfile= PackingAluminumProfile.NumberPackingAluminumProfile;
                anodluminumProfile.Employee = EmployeeSource;
                repos.Add(anodluminumProfile);
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
            PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
            PackingAluminumProfileList= repos.GetAllEntity(PackingAluminumProfile.NumberPackingAluminumProfile);
        }
        public void AddWeightReceptionMaterials()
        {
            PackingAluminumProfileGeneralRepository repos = new PackingAluminumProfileGeneralRepository();
            PackingAluminumProfileGeneral list = repos.GetListPacking(PackingAluminumProfile.NumberPackingAluminumProfile);
            double weightProducedBefore = list.WeightProducedProfile;
            double weightDefected= list.WeightDefectedProfile;
            double areaProducedBefore = list.GeneralAreaProducedProfile;
            double? areaDefected = list.GeneralAreaDefectiveProfile;
            double weightProducedAll = weightProducedBefore + WeightProducedProfile;
            double weightDefectedAll = weightDefected + WeightDefectedProfile;
            double areaProducedAll = areaProducedBefore + GeneralAreaProducedProfile;
            double? areaDefectedAll = areaDefected + GeneralAreaDefectiveProfile;
            repos.UpdatePackingAluminum(PackingAluminumProfile.NumberPackingAluminumProfile, weightProducedAll, weightDefectedAll, areaProducedAll, areaDefectedAll);
        }
        public void RemoveCommand(object obj)
        {
            //PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
            //repos.Remove(Id);
            //PackingAluminumProfileGeneralRepository reposGeneral = new PackingAluminumProfileGeneralRepository();
            //double weightProduced= 0;
            //double weightDefected = 0;
            //double areaProduced = 0;
            //double areaDefected = 0;
            //PackingAluminumProfileList = repos.GetAllEntity(PackingAluminumProfile.NumberPackingAluminumProfile);
            //foreach (var item in PackingAluminumProfileList)
            //{
            //    weightProduced += item.WeightProducedProfile;
            //    weightDefected += item.WeightDefectedProfile;
            //    areaProduced += item.GeneralAreaProducedProfile;
            //    areaDefected += Convert.ToDouble(item.GeneralAreaDefectiveProfile);
            //}
            //reposGeneral.UpdateСuttingFacingProfile(PackingAluminumProfile.NumberPackingAluminumProfile, weightProduced, weightDefected, areaProduced, areaDefected);
            PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
            PackingAluminumProfileGeneralRepository reposGeneral = new PackingAluminumProfileGeneralRepository();
            PackingAluminumProfile entity = new PackingAluminumProfile();
            PackingAluminumProfileGeneral entityGeneral = new PackingAluminumProfileGeneral();

            AnodizingProcessProfileRepository anodRepos = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTapeProtective = new TapeProtectiveProcessProfileRepository();
            СuttingFacingProfileRepository reposСuttingFacingProfile = new СuttingFacingProfileRepository();

            entity = repos.GetByEntity(Id);
            if (entity != null)
            {
                double? weightProduced = entity.WeightProducedProfile;
                double? weightDefected = entity.WeightDefectedProfile;
                double? areaProduced = entity.GeneralAreaProducedProfile;
                double? areaDefected = entity.GeneralAreaDefectiveProfile;
                string name = entity.NumberSpecification;

                entityGeneral = reposGeneral.GetListProducedPackingAluminum(entity.NumberPackingAluminumProfile);

                double weightProdAfter = Math.Round(Convert.ToDouble(entityGeneral.WeightProducedProfile) - Convert.ToDouble(weightProduced), 2);
                double weightDefect = Math.Round(Convert.ToDouble(entityGeneral.WeightDefectedProfile) - Convert.ToDouble(weightDefected), 2);
                double areaProd = Math.Round(Convert.ToDouble(entityGeneral.GeneralAreaProducedProfile) - Convert.ToDouble(areaProduced), 2);
                double areaDefect = Math.Round(Convert.ToDouble(entityGeneral.GeneralAreaDefectiveProfile) - Convert.ToDouble(areaDefected), 2);

                reposGeneral.UpdatePackingAluminum(entity.NumberPackingAluminumProfile, Convert.ToDouble(weightProdAfter), Convert.ToDouble(weightDefect), Convert.ToDouble(areaProd), Convert.ToDouble(areaDefect));

                if (!entity.NomenclatureProfile.Contains("T") && !entity.NomenclatureProfile.Contains("R") && !entity.NomenclatureProfile.Contains("P"))
                {
                    List<AnodizingProcessProfile> listAnodizingProcessProfile = anodRepos.GetListAnodizingProcess(entity.NomenclatureProfile, entity.NumberSpecification);
                    if (listAnodizingProcessProfile != null)
                    {
                        foreach (var item in listAnodizingProcessProfile)
                        {
                            anodRepos.UpdateAnodizingProcessProfileReadinessProfile(item.Id, false);
                        }
                    }
                }
                if (entity.NomenclatureProfile.Contains("P"))
                {
                    List<TapeProtectiveProcessProfile> listTapeProtectiveProcess = reposTapeProtective.GetListTapeProtectiveProcess(entity.NomenclatureProfile, entity.NumberSpecification);
                    if (listTapeProtectiveProcess != null)
                    {
                        foreach (var item in listTapeProtectiveProcess)
                        {
                            reposTapeProtective.UpdateTapeProtectiveProcessProfileReadinessProfile(item.Id, false);
                        }
                    }
                }
                if ((entity.NomenclatureProfile.Contains("T") || entity.NomenclatureProfile.Contains("R")) &&  !entity.NomenclatureProfile.Contains("P") )
                {
                    List<СuttingFacingProfile> listСuttingFacingProfile = reposСuttingFacingProfile.GetListСuttingFacingProfile(entity.NomenclatureProfile, entity.NumberSpecification);
                    if (listСuttingFacingProfile != null)
                    {
                        foreach (var item in listСuttingFacingProfile)
                        {
                            reposСuttingFacingProfile.UpdateСuttingFacingProfileProfileReadinessProfile(item.Id, false);
                        }
                    }
                }
                repos.Remove(Id);
                PackingAluminumProfileList = repos.GetAllEntity(PackingAluminumProfile.NumberPackingAluminumProfile);
            }
        }
        public void GetWeightProfileProduced()
        {
            _weightProducedProfile = Math.Round((Convert.ToDouble(LenghtFact) * Convert.ToDouble(WeightMeter) * Convert.ToDouble(QuantityProducedProfile)) / 1000,2);
            OnPropertyChanged(nameof(WeightProducedProfile));
            _generalAreaProducedProfile = Math.Round((Convert.ToDouble(LenghtFact) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(QuantityProducedProfile)) / 1000000,2);
            OnPropertyChanged(nameof(GeneralAreaProducedProfile));
        }
        public void GetWeightProfileDefected()
        {
            _weightDefectedProfile = Math.Round((Convert.ToDouble(LenghtFact) * Convert.ToDouble(WeightMeter) * Convert.ToDouble(QuantityDefectedProfile)) / 1000,2);
            OnPropertyChanged(nameof(WeightDefectedProfile));
            _generalAreaDefectiveProfile = Math.Round((Convert.ToDouble(LenghtFact) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(QuantityDefectedProfile)) / 1000000,2);
            OnPropertyChanged(nameof(GeneralAreaDefectiveProfile));
        }
        void OpenReportSpecification(object obj)
        {
            try
            {
                PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
                PackingAluminumProfile packingAluminumProfile = new PackingAluminumProfile();
                packingAluminumProfile = repos.GetByEntity(Id);
                WindowReportsShift labelWindow = new WindowReportsShift();
                labelWindow.Show();
                labelWindow.PrintLabelProfile(packingAluminumProfile);
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
