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

namespace EloksalPro.ViewModels
{
    public class СuttingFacingProfileViewModel:ViewModelBase
    {
      /// <summary>
      /// Распил алюминиевого профиля
      /// </summary>
        private СuttingFacingProfile _cuttingFacingProfile = new СuttingFacingProfile();
        private string _workingShiftSource;
        public string _numberSpecificationSource;
        private string _clientName;
        private List<string> _nomenclatureProfileList;
        private string _nomenclatureSource;
        private string _eloksalNoCommercial;
        private double _weightMeter;
        private int _lenghtFact; //  длина профиля до распила
        private int _quantityProducedProfileBefore; // количество хлыстов до распила
        private double _weightProducedProfileBefore;//вес  профиля до распила
        private int _lenghtProfileAfter; //  длина профиля после распила
        private int _quantityProducedProfileAfter; // количество хлыстов после  распила
        private double _weightProducedProfileAfter; //вес  профиля после  распила
        private int _quantityDefected;//количество бракованного  профиля
        private double _weightDefected; //вес бракованного  профиля
        private int _id;
        private double _weightTechnologicalWaste;
        private List<string> _employeeList;
        private string _employeeSource;
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
        private ObservableCollection<СuttingFacingProfile> _ccuttingFacingProfileList = new ObservableCollection<СuttingFacingProfile>();
        public ObservableCollection<СuttingFacingProfile> СuttingFacingProfileList
        {
            get { return _ccuttingFacingProfileList; }
            set { _ccuttingFacingProfileList = value; OnPropertyChanged(nameof(СuttingFacingProfileList)); }
        }
        public СuttingFacingProfile СuttingFacingProfile
        {
            get { return _cuttingFacingProfile; }
            set { _cuttingFacingProfile = value; OnPropertyChanged(nameof(СuttingFacingProfile)); }
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
            set { _numberSpecificationSource = value;GetEloksalNomenclatureProfile(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
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
        public int QuantityProducedProfileBefore
        {
            get { return _quantityProducedProfileBefore; }
            set { _quantityProducedProfileBefore = value; UpdateGeneralWeightBefore(); GetWeightTechnologicalWaste(); OnPropertyChanged(nameof(QuantityProducedProfileBefore)); }
        }
        public double WeightProducedProfileBefore
        {
            get { return _weightProducedProfileBefore; }
            set { _weightProducedProfileBefore = value; OnPropertyChanged(nameof(WeightProducedProfileBefore)); }
        }
        public double WeightTechnologicalWaste
        {
            get { return _weightTechnologicalWaste; }
            set { _weightTechnologicalWaste = value; OnPropertyChanged(nameof(WeightTechnologicalWaste)); }
        }
        public int LenghtProfileAfter
        {
            get { return _lenghtProfileAfter; }
            set { _lenghtProfileAfter = value; UpdateGeneralWeightAfter(); OnPropertyChanged(nameof(LenghtProfileAfter)); }
        }
        public int QuantityProducedProfileAfter
        {
            get { return _quantityProducedProfileAfter; }
            set { _quantityProducedProfileAfter = value; UpdateGeneralWeightAfter(); GetWeightTechnologicalWaste(); OnPropertyChanged(nameof(QuantityProducedProfileAfter)); }
        }
        public int QuantityDefected
        {
            get { return _quantityDefected; }
            set { _quantityDefected = value; UpdateGeneralWeightDefected(); OnPropertyChanged(nameof(QuantityDefected)); }
        }
        public double WeightProducedProfileAfter
        {
            get { return _weightProducedProfileAfter; }
            set { _weightProducedProfileAfter = value; OnPropertyChanged(nameof(WeightProducedProfileAfter)); }
        }
        public double WeightDefected
        {
            get { return _weightDefected; }
            set { _weightDefected = value; OnPropertyChanged(nameof(WeightDefected)); }
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
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand ShowRemoveCommand { get; }
        public СuttingFacingProfileViewModel()
        {
            СuttingFacingProfileRepository reposCutting = new СuttingFacingProfileRepository();
            SaveInsertCommand = new ViewModelCommand(InsertNewСuttingFacingProfile);
            ShowRemoveCommand= new ViewModelCommand(RemoveCommand);
            NumderSpecification = GetListNumberSpecification();
            int MaxEloksalNo = reposCutting.MaxNumberСuttingFacingProfile() + 1;
            СuttingFacingProfile.NumberСuttingFacingGeneral = "CF" + MaxEloksalNo.ToString("D4");
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsernameRoleTwo();
            AddTimer();
        }
        public List<string> GetListNumberSpecification()
        {
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTape = new TapeProtectiveProcessProfileRepository();
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();
            //List<string> listNomenclatureTape = reposTape.GetNumberSpecificationCutting();
            List<string> listNomenclature = repos.GetNumberSpecificationСuttingFacing();
            List<string> listReception = reposReception.GetNumberSpecificationCuttingFacing();
            List<string> list = new List<string>();
            //list.AddRange(listNomenclatureTape);
            list.AddRange(listNomenclature);
            list.AddRange(listReception);
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
                _lenghtProfileAfter = profile.LenghtProfile;
                OnPropertyChanged(nameof(LenghtProfileAfter));
                DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
                _lenghtFact = reposDetailReception.GetLenghtFact(NomenclatureSource, NumberSpecificationSource);
                OnPropertyChanged(nameof(LenghtFact));
            }
         
        }
        public void GetEloksalNomenclatureProfile()
        {
            //TapeProtectiveProcessProfileRepository reposTape = new TapeProtectiveProcessProfileRepository();//нанесение защитной пленки
            //List<string> listTape = reposTape.GetNomenclatureCutting(NumberSpecificationSource);
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();// анодирование
            List<string> listAnod = repos.GetNomenclatureCutting(NumberSpecificationSource);
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();
            List<string> listReception = reposReception.GetNomenclatureDetailReceptionCuttingFacing(NumberSpecificationSource);
            List<string> list = new List<string>();
            //list.AddRange(listTape);
            list.AddRange(listAnod);
            list.AddRange(listReception);
            _nomenclatureProfileList = list;
            OnPropertyChanged(nameof(NomenclatureProfileList));
        }
        public void UpdateGeneralWeightBefore()
        {
            _weightProducedProfileBefore = Math.Round((Convert.ToDouble(QuantityProducedProfileBefore) * Convert.ToDouble(LenghtFact) * WeightMeter) / 1000,2);
            OnPropertyChanged(nameof(WeightProducedProfileBefore));
        }
        public void UpdateGeneralWeightAfter()
        {
            _weightProducedProfileAfter = Math.Round((Convert.ToDouble(QuantityProducedProfileAfter) * Convert.ToDouble(LenghtProfileAfter) * WeightMeter) / 1000,2);
            OnPropertyChanged(nameof(WeightProducedProfileAfter));
            _generalAreaProducedProfile = Math.Round((Convert.ToDouble(QuantityProducedProfileAfter) * Convert.ToDouble(LenghtProfileAfter) * OuterPerimeter) / 1000000,2);
            OnPropertyChanged(nameof(GeneralAreaProducedProfile));
        }
        public void UpdateGeneralWeightDefected()
        {
            _weightDefected = Math.Round((Convert.ToDouble(QuantityDefected) * Convert.ToDouble(LenghtProfileAfter) * WeightMeter) / 1000,2);
            OnPropertyChanged(nameof(WeightDefected));
            _generalAreaDefectiveProfile = Math.Round((Convert.ToDouble(QuantityDefected) * Convert.ToDouble(LenghtProfileAfter) * OuterPerimeter) / 1000000,2);
            OnPropertyChanged(nameof(GeneralAreaDefectiveProfile));
        }
        public void InsertNewСuttingFacingProfile(object obj)
        {
            СuttingFacingProfileRepository reposCutting = new СuttingFacingProfileRepository();
            СuttingFacingGeneralProfileRepository reposGeneral = new СuttingFacingGeneralProfileRepository();
            AnodizingProcessProfileRepository reposAnod = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTapeProtective = new TapeProtectiveProcessProfileRepository();
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();
            int maxId = reposCutting.GetById();
            if (СuttingFacingProfile.DateСuttingFacing== DateTime.MinValue)
            {
                СuttingFacingProfile.DateСuttingFacing = DateTime.Now;
            }
           
            bool checkValue = reposGeneral.CheckValueСuttingFacingGeneralProfile(СuttingFacingProfile.NumberСuttingFacingGeneral);
            int cuttingFacingCountBefore = Convert.ToInt32(reposCutting.GetCountNomenclatureBefore(NumberSpecificationSource, NomenclatureSource));

            double cuttingFacingWeightBefore = Math.Round(reposCutting.GetWeightNomenclatureBefore(NumberSpecificationSource, NomenclatureSource),2);
            double cuttingFacingWeightAfter = reposCutting.GetWeightNomenclatureAfter(NumberSpecificationSource, NomenclatureSource);
            double cuttingFacingWeightDefective = reposCutting.GetWeightNomenclatureDefective(NumberSpecificationSource, NomenclatureSource);
            double detailReceptionCount = reposReception.GetCountReceptionMaterials(NumberSpecificationSource, NomenclatureSource);

            double cuttingWeightTechnologicalWaste = reposCutting.GetWeightTechnologicalWaste(NumberSpecificationSource, NomenclatureSource);

            double cuttingFacingCountDefective = Convert.ToInt32(reposCutting.GetCountNomenclatureDefective(NumberSpecificationSource, NomenclatureSource));

            int anodCount = reposAnod.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource);
            int tapeProtectiveCount = Convert.ToInt32(reposTapeProtective.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource));

            int count = reposGeneral.CheckValueСuttingFacingGeneralProfileDayShift(СuttingFacingProfile.DateСuttingFacing);
            if (count >= 2 && !checkValue)
            {
                MessageBox.Show("За один день можно открыть только две смены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (СuttingFacingProfile.DateСuttingFacing == null || WorkingShiftSource == null || NumberSpecificationSource == null ||  NomenclatureSource == null || QuantityProducedProfileBefore == 0 || QuantityProducedProfileAfter == 0 || EmployeeSource == null)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (LenghtFact / LenghtProfileAfter < 2 && QuantityProducedProfileBefore < QuantityProducedProfileAfter)
            {
                MessageBox.Show("Внесите верное количество штук после распила!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (NomenclatureSource.Contains("A") && anodCount < cuttingFacingCountBefore +  QuantityProducedProfileBefore )
            {
                MessageBox.Show("Общее количество до распила превышает количество после анодирования!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!NomenclatureSource.Contains("A") && detailReceptionCount < cuttingFacingCountBefore + QuantityProducedProfileBefore)
            {
                MessageBox.Show("Общее количество до распила превышает количество принятого сырья!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //else if (!NomenclatureSource.Contains("P") && anodWeight < Math.Round(cuttingFacingWeightAfter + cuttingFacingWeightDefective + WeightProducedProfileAfter + WeightTechnologicalWaste+ WeightDefected, 2))
            //{
            //    MessageBox.Show("Общий вес после распила профиля превышает вес после анодирования!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else if (NomenclatureSource.Contains("P") && tapeProtectiveCount < cuttingFacingCountBefore + cuttingFacingCountDefective + QuantityProducedProfileBefore + QuantityDefected)
            //{
            //    MessageBox.Show("Общее количество до распила превышает количество после наклеивания защитной пленки!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else if (NomenclatureSource.Contains("P") && cuttingFacingWeightBefore < Math.Round(cuttingFacingWeightAfter + cuttingFacingWeightDefective + WeightProducedProfileAfter + WeightDefected + WeightTechnologicalWaste + cuttingWeightTechnologicalWaste, 2))
            //{
            //    MessageBox.Show("Общий вес после распила превышает вес до распила!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            else
            {
                //if (tapeProtectiveCount == cuttingFacingCountBefore + cuttingFacingCountDefective + QuantityProducedProfileBefore + QuantityDefected)
                //{
                //    List<TapeProtectiveProcessProfile> listTapeProtectiveProcess = reposTapeProtective.GetListTapeProtectiveProcess(NomenclatureSource, NumberSpecificationSource);
                //    if (listTapeProtectiveProcess != null)
                //    {
                //        foreach(var item in listTapeProtectiveProcess)
                //        {
                //            reposTapeProtective.UpdateTapeProtectiveProcessProfileReadinessProfile(item.Id, true);
                //        }
                //    } 
                //}
                if (!NomenclatureSource.Contains("A") && detailReceptionCount == cuttingFacingCountBefore + QuantityProducedProfileBefore)
                {
                    reposReception.UpdateReceptionDetailMaterialsReadinessProfile(NomenclatureSource, NumberSpecificationSource, true);
                }
                else if (anodCount == cuttingFacingCountBefore + QuantityProducedProfileBefore)
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
                СuttingFacingProfile cuttingFacingProfile = new СuttingFacingProfile();
                cuttingFacingProfile.Id = ++maxId;
                cuttingFacingProfile.DateСuttingFacing = СuttingFacingProfile.DateСuttingFacing;
                cuttingFacingProfile.NumberСuttingFacingGeneral = СuttingFacingProfile.NumberСuttingFacingGeneral;
                cuttingFacingProfile.BasketNumber = СuttingFacingProfile.BasketNumber;
                cuttingFacingProfile.NumberSpecification = NumberSpecificationSource;
                cuttingFacingProfile.NomenclatureProfile = NomenclatureSource;
                cuttingFacingProfile.EloksalNoCommercial = EloksalNoCommercial;
                cuttingFacingProfile.ClientName = ClientName;
                cuttingFacingProfile.WeightMeter = WeightMeter;
                cuttingFacingProfile.LenghtProfileBefore = LenghtFact;
                cuttingFacingProfile.QuantityProducedProfileBefore = QuantityProducedProfileBefore;
                cuttingFacingProfile.WeightProducedProfileBefore = WeightProducedProfileBefore;
                cuttingFacingProfile.GeneralAreaProducedProfile = GeneralAreaProducedProfile;
                cuttingFacingProfile.QuantityDefectedProfile = QuantityDefected;
                cuttingFacingProfile.WeightDefectedProfile = WeightDefected;
                cuttingFacingProfile.GeneralAreaDefectiveProfile = GeneralAreaDefectiveProfile;
                cuttingFacingProfile.LenghtProfileAfter = LenghtProfileAfter;
                cuttingFacingProfile.QuantityProducedProfileAfter = QuantityProducedProfileAfter;
                cuttingFacingProfile.WeightProducedProfileAfter = WeightProducedProfileAfter;
                cuttingFacingProfile.WeightTechnologicalWaste = WeightTechnologicalWaste;
                cuttingFacingProfile.Annotation = СuttingFacingProfile.Annotation;
                reposCutting.Add(cuttingFacingProfile);
                СuttingFacingProfileList.Add(cuttingFacingProfile);
                InsertNewСuttingFacingProfilesGenerals();
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
        QuantityProducedProfileBefore=0;
        WeightProducedProfileBefore=0;
        QuantityDefected=0;
        WeightDefected=0;
        LenghtProfileAfter=0;
        QuantityProducedProfileAfter=0;
        WeightProducedProfileAfter=0;
        WeightTechnologicalWaste=0;
    }
        public void InsertNewСuttingFacingProfilesGenerals()
        {
            СuttingFacingGeneralProfileRepository repos = new СuttingFacingGeneralProfileRepository();
            int maxId = repos.GetById();
            СuttingFacingGeneralProfile anodluminumProfile = new СuttingFacingGeneralProfile();
            bool checkValue = repos.CheckValueСuttingFacingGeneralProfile(СuttingFacingProfile.NumberСuttingFacingGeneral);
            if (!checkValue)
            {
                anodluminumProfile.Id = ++maxId;
                anodluminumProfile.Date = СuttingFacingProfile.DateСuttingFacing;
                anodluminumProfile.Shift = WorkingShiftSource;
                anodluminumProfile.Annotation = СuttingFacingProfile.Annotation;
                anodluminumProfile.NumberСuttingFacing = СuttingFacingProfile.NumberСuttingFacingGeneral;
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
            СuttingFacingProfileRepository repos = new СuttingFacingProfileRepository();
            СuttingFacingProfileList = repos.GetAllEntity(СuttingFacingProfile.NumberСuttingFacingGeneral);
        }
        public void AddWeightReceptionMaterials()
        {
            СuttingFacingGeneralProfileRepository repos = new СuttingFacingGeneralProfileRepository();
            СuttingFacingGeneralProfile list = repos.GetListProducedСuttingFacing(СuttingFacingProfile.NumberСuttingFacingGeneral);
            double weightProducedAfter = list.GeneralQuantityProducedProfileAfter;
            double weightProducedAllAfter = weightProducedAfter + WeightProducedProfileAfter;
            double weightProducedBefore = list.GeneralQuantityProducedProfileBefore;
            double weightProducedAllBefore = weightProducedBefore + WeightProducedProfileBefore;
            double areaProducedBefore = list.GeneralAreaProducedProfile;
            double areaProducedAllBefore = areaProducedBefore + GeneralAreaProducedProfile;
            double weightProducedDefect= list.GeneralQuantityProducedProfileDefect;
            double weightProducedAllDefect = weightProducedDefect + WeightDefected;
            double areaProducedDefect =Convert.ToDouble(list.GeneralAreaDefectiveProfile);
            double areaProducedAllDefect = areaProducedDefect + GeneralAreaDefectiveProfile;
            double weightTechnologicalWaste = list.GeneralWeightTechnologicalWaste+WeightTechnologicalWaste;

            repos.UpdateСuttingFacingProfile(СuttingFacingProfile.NumberСuttingFacingGeneral, weightProducedAllAfter, weightProducedAllBefore, weightProducedAllDefect, areaProducedAllBefore, areaProducedAllDefect, weightTechnologicalWaste);
        }
        public void RemoveCommand(object obj)
        {
            //    СuttingFacingProfileRepository repos = new СuttingFacingProfileRepository();
            //    repos.Remove(Id);
            //    СuttingFacingGeneralProfileRepository reposGeneral = new СuttingFacingGeneralProfileRepository();
            //    double weightProducedBefore = 0;
            //    double weightProducedAfter = 0;
            //    double weightProducedDefect = 0;
            //    double areaProducedAfter = 0;
            //    double areaProducedDefect = 0;
            //    СuttingFacingProfileList = repos.GetAllEntity(СuttingFacingProfile.NumberСuttingFacingGeneral);
            //    foreach (var item in СuttingFacingProfileList)
            //    {
            //        weightProducedBefore += item.WeightProducedProfileBefore;
            //        weightProducedAfter += item.WeightProducedProfileAfter;
            //        weightProducedDefect += item.WeightDefectedProfile;
            //        areaProducedAfter += item.GeneralAreaProducedProfile;
            //        areaProducedDefect += Convert.ToDouble(item.GeneralAreaDefectiveProfile);
            //    }
            //    reposGeneral.UpdateСuttingFacingProfile(СuttingFacingProfile.NumberСuttingFacingGeneral, weightProducedAfter, weightProducedBefore, weightProducedDefect, areaProducedAfter, areaProducedDefect);
            СuttingFacingProfileRepository repos = new СuttingFacingProfileRepository();
            СuttingFacingGeneralProfileRepository reposGeneral = new СuttingFacingGeneralProfileRepository();
            СuttingFacingProfile entity = new СuttingFacingProfile();
            СuttingFacingGeneralProfile entityGeneral = new СuttingFacingGeneralProfile();
            AnodizingProcessProfileRepository anodRepos = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTapeProtective = new TapeProtectiveProcessProfileRepository();
            entity = repos.GetByEntity(Id);
            if (entity != null)
            {
                double? weightProduced = entity.WeightProducedProfileAfter;
                double? weightProducedBefore = entity.WeightProducedProfileBefore;
                double? weightDefected = entity.WeightDefectedProfile;
                double? areaProduced = entity.GeneralAreaProducedProfile;
                double? areaDefected = entity.GeneralAreaDefectiveProfile;
                double? weightTechnologicalWaste = entity.WeightTechnologicalWaste;
                string name = entity.NumberSpecification;
               
                entityGeneral = reposGeneral.GetListProducedСuttingFacing(entity.NumberСuttingFacingGeneral);

                double weightProdAfter = Math.Round(Convert.ToDouble(entityGeneral.GeneralQuantityProducedProfileAfter) - Convert.ToDouble(weightProduced), 2);
                double weightProdBefore = Math.Round(Convert.ToDouble(entityGeneral.GeneralQuantityProducedProfileBefore) - Convert.ToDouble(weightProducedBefore), 2);
                double weightDefect = Math.Round(Convert.ToDouble(entityGeneral.GeneralQuantityProducedProfileDefect) - Convert.ToDouble(weightDefected), 2);
                double areaProd = Math.Round(Convert.ToDouble(entityGeneral.GeneralAreaProducedProfile) - Convert.ToDouble(areaProduced), 2);
                double areaDefect = Math.Round(Convert.ToDouble(entityGeneral.GeneralAreaDefectiveProfile) - Convert.ToDouble(areaDefected), 2);
                double technologicalWaste = Math.Round(Convert.ToDouble(entityGeneral.GeneralWeightTechnologicalWaste) - Convert.ToDouble(weightTechnologicalWaste), 2);
                reposGeneral.UpdateСuttingFacingProfile(entity.NumberСuttingFacingGeneral, Convert.ToDouble(weightProdAfter), Convert.ToDouble(weightProdBefore), Convert.ToDouble(weightDefect), Convert.ToDouble(areaProd), Convert.ToDouble(areaDefect), technologicalWaste);

                if(entity.NomenclatureProfile.Contains("A"))
                {
                    List<AnodizingProcessProfile> ListAnod= anodRepos.GetListAnodizingProcess(entity.NomenclatureProfile, entity.NumberSpecification);
                    if (ListAnod != null)
                    {
                        foreach (var item in ListAnod)
                        {
                            anodRepos.UpdateAnodizingProcessProfileReadinessProfile(item.Id, false);
                        }
                    }
                   
                }
                repos.Remove(Id);
                СuttingFacingProfileList = repos.GetAllEntity(СuttingFacingProfile.NumberСuttingFacingGeneral);
            }
        }
        public void GetWeightTechnologicalWaste()
        {
            _weightTechnologicalWaste = Math.Round(WeightProducedProfileBefore - WeightProducedProfileAfter,2);
            OnPropertyChanged(nameof(WeightTechnologicalWaste));
        }
    }
}