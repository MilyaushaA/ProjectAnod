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

namespace EloksalPro.ViewModels
{
   public class AnodizingProcessProfileViewModel:ViewModelBase
    {
        private DateTime _dateAnodizingProcess;// дата анодирования
        private string _numberAnodizingProcess;// номер анодирования
        private int _numberBars;// номер бары
        private List<string> _numberSpecification; // номер заказа
        private string _numberSpecificationSource; // 
        private List<string> _nomenclatureProfileList; // номенклатура профиля
        private string _nomenclatureSource;
        private string _colorAnod; // цвет профиля
        private string _eloksalNoCommercial; // коммерческий номер
        private string _clientName; // наименование клиента
        private double _weightMeter; // вес погонного метра
        private int _amountPieceFact;// количество хлыстов AmountPieceDefect
        private int _amountPieceDefect;// количество хлыстов
        private int _lenghtFact;// длина хлыста
        private double _weightGeneral;// общий вес анодирования
        private double _weightGeneralDefect;  //WeightGeneralDefect
        private string _annotation;// примечание
        private int _downtime;// время простоя
        private List<string> _workingShiftList = new List<string>() { "08:00-20:00", "20:00-08:00" };
        private string _workingShiftSource;
        private List<string> _employeeList;
        private string _employeeSource;   
        public int _id; // внешний периметр
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
        public AnodizingProcessProfile _anodizingProcessProfile = new AnodizingProcessProfile();     
        public AnodizingProcessProfile AnodizingProcessProfile
        {
            get { return _anodizingProcessProfile; }
            set { _anodizingProcessProfile = value; OnPropertyChanged(nameof(AnodizingProcessProfile)); }
        }
        private ObservableCollection<AnodizingProcessProfile> _anodizingProcessProfileList = new ObservableCollection<AnodizingProcessProfile>();
        public DateTime DateAnodizingProcess
        {
            get { return _dateAnodizingProcess; }
            set { _dateAnodizingProcess = value; OnPropertyChanged(nameof(DateAnodizingProcess)); }
        }
        public string NumberAnodizingProcess
        {
            get { return _numberAnodizingProcess; }
            set { _numberAnodizingProcess = value; OnPropertyChanged(nameof(NumberAnodizingProcess)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public int NumberBars
        {
            get { return _numberBars; }
            set { _numberBars = value; OnPropertyChanged(nameof(NumberBars)); }
        }
        public List<string> NumberSpecification
        {
            get { return _numberSpecification; }
            set { _numberSpecification = value; OnPropertyChanged(nameof(NumberSpecification)); }
        }
        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value; UpdateListNomenclature(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }
        public List<string> NomenclatureProfileList
        {
            get { return _nomenclatureProfileList; }
            set { _nomenclatureProfileList = value; OnPropertyChanged(nameof(NomenclatureProfileList)); }
        }
        public string NomenclatureSource
        {
            get { return _nomenclatureSource; }
            set { _nomenclatureSource = value; UpdateDataProfile(); OnPropertyChanged(nameof(NomenclatureSource)); }
        }
        public string ColorAnod
        {
            get { return _colorAnod; }
            set { _colorAnod = value; OnPropertyChanged(nameof(ColorAnod)); }
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
        public string WorkingShiftSource
        {
            get { return _workingShiftSource; }
            set { _workingShiftSource = value; OnPropertyChanged(nameof(WorkingShiftSource)); }
        }
        public int Downtime
        {
            get { return _downtime; }
            set { _downtime = value; OnPropertyChanged(nameof(Downtime)); }
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
        public ObservableCollection<AnodizingProcessProfile> AnodizingProcessProfileList
        {
            get { return _anodizingProcessProfileList; }
            set { _anodizingProcessProfileList = value; OnPropertyChanged(nameof(AnodizingProcessProfileList)); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand ShowRemoveCommand { get; }
        public AnodizingProcessProfileViewModel()
        {
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsername();
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            AnodizingProcessProfileList = repos.GetAllEntity(NumberAnodizingProcess);
            ShowRemoveCommand=new ViewModelCommand(RemoveCommand);
            NumberSpecification = GetListNumberSpecification();
            SaveInsertCommand = new ViewModelCommand(InsertNewAnodizingAluminum);
            int MaxEloksalNo = repos.MaxNumberAnodizingProcess() + 1;
            NumberAnodizingProcess = "AN" + MaxEloksalNo.ToString("D4");
            EmployeeList = userRepos.GetByUsernameRoleTwo();
            AddTimer();
        }
        public List<string> GetListNumberSpecification()
        {
            ////HitchAluminumProfilesRepository reposHitchAluminum = new HitchAluminumProfilesRepository();
            ////List<string> anodList = new List<string>();
            ////anodList = reposHitchAluminum.GetNumberSpecification();
            ////List<string> list = new List<string>();
            ////list.AddRange(anodList);
            ////List<string> listNumber = list.Distinct().ToList();
            ////return listNumber;
            ShotBlastingProfileRepository reposSnot = new ShotBlastingProfileRepository();
            DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
            List<string> shotList = new List<string>();
            List<string> detailReception = new List<string>();
            shotList = reposSnot.GetNumberSpecification();
            detailReception = reposDetailReception.GetNumberSpecification();
            List<string> list = new List<string>();
            list.AddRange(shotList);
            list.AddRange(detailReception);
            List<string> listNumber = list.Distinct().ToList();
            return listNumber;
        }
        public List<string> GetListNomenclature()
        {
            //HitchAluminumProfilesRepository reposSnot = new HitchAluminumProfilesRepository();
            //List<string> anodList = new List<string>();
            //anodList = reposSnot.GetNomenclature(NumberSpecificationSource);
            //List<string> list = new List<string>();
            //list.AddRange(anodList);
            //List<string> listNumber = list.Distinct().ToList();
            //return listNumber;

            ShotBlastingProfileRepository reposSnot = new ShotBlastingProfileRepository();
            DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
            List<string> shotList = new List<string>();
            List<string> detailReception = new List<string>();
            shotList = reposSnot.GetNomenclature(NumberSpecificationSource);
            detailReception = reposDetailReception.GetNomenclatureDetailReception(NumberSpecificationSource);
            List<string> list = new List<string>();
            list.AddRange(shotList);
            list.AddRange(detailReception);
            List<string> listNumber = list.Distinct().ToList();
            return listNumber;
        }
        public void UpdateListNomenclature()
        {
            _nomenclatureProfileList = GetListNomenclature();
            OnPropertyChanged(nameof(NomenclatureProfileList));
        }
        public void UpdateDataProfile()
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
                _colorAnod = profile.TypeAnod + profile.ColorAnod;
                OnPropertyChanged(nameof(ColorAnod));
                _weightMeter = profile.WeightMeter / 1000;
                OnPropertyChanged(nameof(WeightMeter));
                _outerPerimeter = profile.OuterPerimeter;
                OnPropertyChanged(nameof(OuterPerimeter));
                DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
                _lenghtFact = reposDetailReception.GetLenghtFact(NomenclatureSource, NumberSpecificationSource);
                OnPropertyChanged(nameof(LenghtFact));
            }  
        }
        public void UpdateGeneralWeight()
        {
            _weightGeneral = Math.Round((Convert.ToDouble(AmountPieceFact) * Convert.ToDouble(LenghtFact) * WeightMeter) / 1000,2);
            OnPropertyChanged(nameof(WeightGeneral));
            _generalAreaProducedProfile = Math.Round((OuterPerimeter / 1000 * Convert.ToDouble(LenghtFact)/1000 * Convert.ToDouble(AmountPieceFact)),2);
            OnPropertyChanged(nameof(GeneralAreaProducedProfile));
        }
        public void UpdateGeneralWeightDefect()
        {
            _weightGeneralDefect = Math.Round((Convert.ToDouble(AmountPieceDefect) * Convert.ToDouble(LenghtFact) * WeightMeter) / 1000,2);
            OnPropertyChanged(nameof(WeightGeneralDefect));
            _generalAreaDefectiveProfile = Math.Round(OuterPerimeter / 1000 * Convert.ToDouble(LenghtFact) / 1000 * Convert.ToDouble(AmountPieceDefect),2);
            OnPropertyChanged(nameof(GeneralAreaDefectiveProfile));
        }

        public void InsertNewAnodizingAluminum(object obj)
        {
            if (DateAnodizingProcess == DateTime.MinValue)
            {
                DateAnodizingProcess = DateTime.Now;
            }
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            AnodizingProcessProfileGeneralRepository reposGeneral = new AnodizingProcessProfileGeneralRepository();
            //HitchAluminumProfilesRepository reposHitchAluminum = new HitchAluminumProfilesRepository();
            //double hitchAluminumProfilesWeight = Math.Round(reposHitchAluminum.GetWeightNomenclature(NumberSpecificationSource, NomenclatureSource),2);
            DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
            ShotBlastingProfileRepository reposShot = new ShotBlastingProfileRepository();
            int anodizingProcessProfileCount = repos.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource);
            int anodizingProcessCountDefective = repos.GetCountNomenclatureDefective(NumberSpecificationSource, NomenclatureSource);
            int detailReceptionCount = reposDetailReception.GetCountReceptionMaterials(NumberSpecificationSource, NomenclatureSource);

            int shotBlastingCount = Convert.ToInt32(reposShot.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource));
            bool checkValue = reposGeneral.CheckValueAnodizingProcessProfile(NumberAnodizingProcess);
            int count = reposGeneral.CheckValueAnodizingProcessProfileDayShift(DateAnodizingProcess);
            if (count >= 2 && !checkValue)
            {
                MessageBox.Show("За один день можно открыть только две смены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (WorkingShiftSource == null || NumberSpecificationSource == null || NomenclatureSource == null || AmountPieceFact == 0 || EmployeeSource == null)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (NomenclatureSource.Contains("AD") && (shotBlastingCount < anodizingProcessProfileCount+ anodizingProcessCountDefective+AmountPieceDefect+AmountPieceFact))
            {
                MessageBox.Show("Общий вес навески превышает вес после дробейструйной обработки!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!NomenclatureSource.Contains("AD") && (detailReceptionCount < anodizingProcessProfileCount + anodizingProcessCountDefective + AmountPieceDefect + AmountPieceFact))
            {
                MessageBox.Show("Общий вес произведенного профиля превышает вес принятого сырья!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
           
            else
            {
                if (!NomenclatureSource.Contains("AD"))
                {
                    if (detailReceptionCount == anodizingProcessProfileCount + anodizingProcessCountDefective + AmountPieceDefect + AmountPieceFact)
                    {
                        reposDetailReception.UpdateReceptionDetailMaterialsReadinessProfile(NomenclatureSource, NumberSpecificationSource, true);
                    }
                }
                else
                {
                    if (shotBlastingCount == anodizingProcessProfileCount + anodizingProcessCountDefective + AmountPieceDefect + AmountPieceFact)
                    {
                        List<ShotBlastingProfile> list = reposShot.GetListShotBlastingProfile(NomenclatureSource, NumberSpecificationSource);
                        if (list != null)
                        {
                            foreach (var item in list)
                            {
                                reposShot.UpdateShotBlastingProfileReadinessProfile(item.Id, true);
                            }
                        }  
                    }
                }
                int maxId = repos.GetById();
                AnodizingProcessProfile anodizingProcessProfile = new AnodizingProcessProfile();
                anodizingProcessProfile.Id = ++maxId;
                anodizingProcessProfile.DateAnodizingProcess = DateAnodizingProcess;
                anodizingProcessProfile.NumberAnodizingProcess = NumberAnodizingProcess;
                anodizingProcessProfile.NumberBars = NumberBars;
                anodizingProcessProfile.NumberSpecification = NumberSpecificationSource;
                anodizingProcessProfile.NomenclatureProfile = NomenclatureSource;
                anodizingProcessProfile.EloksalNoCommercial = EloksalNoCommercial;
                anodizingProcessProfile.ClientName = ClientName;
                anodizingProcessProfile.ColorAnod = ColorAnod;
                anodizingProcessProfile.WeightMeter = WeightMeter;
                anodizingProcessProfile.AmountPieceFact = AmountPieceFact;
                anodizingProcessProfile.AmountPieceDefect = AmountPieceDefect;
                anodizingProcessProfile.LenghtFact = LenghtFact;
                anodizingProcessProfile.WeightGeneral = WeightGeneral;
                anodizingProcessProfile.WeightGeneralDefect = WeightGeneralDefect;
                anodizingProcessProfile.OuterPerimeter = OuterPerimeter;
                anodizingProcessProfile.GeneralAreaProducedProfile = GeneralAreaProducedProfile;
                anodizingProcessProfile.GeneralAreaDefectiveProfile = GeneralAreaDefectiveProfile;
                anodizingProcessProfile.CurrentDensity = AnodizingProcessProfile.CurrentDensity;
                anodizingProcessProfile.Voltage = AnodizingProcessProfile.Voltage;
                anodizingProcessProfile.CurrentStreng = AnodizingProcessProfile.CurrentStreng;
                anodizingProcessProfile.AnodizingTime = AnodizingProcessProfile.AnodizingTime;
                anodizingProcessProfile.BathTemperature = AnodizingProcessProfile.BathTemperature;
                anodizingProcessProfile.Employee = EmployeeSource;

                repos.Add(anodizingProcessProfile);
                AnodizingProcessProfileList.Add(anodizingProcessProfile);
                InsertNewAnodizingProfilesGenerals();
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
            ColorAnod = null;
            WeightMeter = 0;
            AmountPieceFact = 0;
            AmountPieceDefect = 0;
            LenghtFact = 0;
            WeightGeneral = 0;
            WeightGeneralDefect = 0;
            OuterPerimeter = 0;
            GeneralAreaProducedProfile = 0;
            GeneralAreaDefectiveProfile = 0;
        }
        public void InsertNewAnodizingProfilesGenerals()
        {
            AnodizingProcessProfileGeneralRepository repos = new AnodizingProcessProfileGeneralRepository();
            int maxId = repos.GetById();
            AnodizingProcessProfileGeneral anodluminumProfile = new AnodizingProcessProfileGeneral();
            bool checkValue = repos.CheckValueAnodizingProcessProfile(NumberAnodizingProcess);
            if (!checkValue)
            {
                anodluminumProfile.Id = ++maxId;
                anodluminumProfile.Date = DateAnodizingProcess;
                anodluminumProfile.Shift = WorkingShiftSource;
                anodluminumProfile.Annotation = Annotation;
                anodluminumProfile.NumberAnodizingProcess = NumberAnodizingProcess;
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
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            AnodizingProcessProfileList = repos.GetAllEntity(NumberAnodizingProcess);
        }
        public void AddWeightReceptionMaterials()
        {
            AnodizingProcessProfileGeneralRepository repos = new AnodizingProcessProfileGeneralRepository();
            AnodizingProcessProfileGeneral myEntity = new AnodizingProcessProfileGeneral();
            myEntity= repos.GetWeightProduced(NumberAnodizingProcess);
            double weightProduced = myEntity.GeneralQuantityProducedProfile;
            double weightDefected = myEntity.GeneralQuantityDefectedProfile;
            double areaProduced = myEntity.GeneralAreaProducedProfile;
            double areaDefected = Convert.ToDouble(myEntity.GeneralAreaDefectiveProfile);
            double weightProducedAll = weightProduced + WeightGeneral;
            double weightDefectedAll = weightDefected + WeightGeneralDefect;
            double areaProducedAll = areaProduced + GeneralAreaProducedProfile;
            double areaDefectedAll = areaDefected + GeneralAreaDefectiveProfile;
            repos.UpdateAnodizingAluminumProfile(NumberAnodizingProcess, weightProducedAll, weightDefectedAll, areaProducedAll, areaDefectedAll);
            ReceptionMaterialsRepository reposReceptionMaterials = new ReceptionMaterialsRepository();
            double weight = reposReceptionMaterials.GetWeightShippedProduction(NumberSpecificationSource);
            double allWeight = 0;
            if (!NomenclatureSource.Contains("AD"))
            {
                allWeight = Math.Round(WeightGeneral + WeightGeneralDefect + weight, 2);
                reposReceptionMaterials.UpdateReceptionMaterialsWeight(NumberSpecificationSource, allWeight);
            }
        }
        public void RemoveCommand(object obj)
        {
            //AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            //repos.Remove(Id);
            //AnodizingProcessProfileGeneralRepository reposGeneral = new AnodizingProcessProfileGeneralRepository();
            //double weightProduced=0;
            //double weightDefected = 0;
            //double areaProduced = 0;
            //double areaDefected = 0;
            //AnodizingProcessProfileList = repos.GetAllEntity(NumberAnodizingProcess);
            //foreach (var item in AnodizingProcessProfileList)
            //{
            //    weightProduced += item.WeightGeneral;
            //    weightDefected += item.WeightGeneralDefect;
            //    areaProduced += item.GeneralAreaProducedProfile;
            //    areaDefected += Convert.ToDouble(item.GeneralAreaDefectiveProfile);
            //}
            //reposGeneral.UpdateAnodizingAluminumProfile(NumberAnodizingProcess, Math.Round(weightProduced,2), Math.Round(weightDefected,2), Math.Round(areaProduced,2), Math.Round(areaDefected,2));

            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            AnodizingProcessProfile entity = new AnodizingProcessProfile();
            entity = repos.GetByEntity(Id);
            if (entity != null)
            {
                double? weightProduced = entity.WeightGeneral;
                double? weightDefected = entity.WeightGeneralDefect;
                double? areaProduced = entity.GeneralAreaProducedProfile;
                double? areaDefected = entity.GeneralAreaDefectiveProfile;
                string name = entity.NumberSpecification;
                ReceptionMaterialsRepository reposReception = new ReceptionMaterialsRepository();
                DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
                double receptionWeight = reposReception.GetWeightShippedProduction(name);
                double weight = Math.Round(receptionWeight - (Convert.ToDouble(weightProduced) + Convert.ToDouble(weightDefected)), 2);
                if (!entity.NomenclatureProfile.Contains("AD"))
                {
                    reposReception.UpdateReceptionMaterialsWeight(name, weight);
                    reposDetailReception.UpdateReceptionDetailMaterialsReadinessProfile(entity.NomenclatureProfile, entity.NumberSpecification, false);
                }
                AnodizingProcessProfileGeneralRepository reposGeneral = new AnodizingProcessProfileGeneralRepository();
                AnodizingProcessProfileGeneral entityAnod = new AnodizingProcessProfileGeneral();
                ShotBlastingProfileRepository shotRepos = new ShotBlastingProfileRepository();
                entityAnod = reposGeneral.GetWeightProduced(entity.NumberAnodizingProcess);
                double weightProd = Math.Round(Convert.ToDouble(entityAnod.GeneralQuantityProducedProfile) - Convert.ToDouble(weightProduced), 2);
                double weightDefect = Math.Round(Convert.ToDouble(entityAnod.GeneralQuantityDefectedProfile) - Convert.ToDouble(weightDefected), 2);
                double areaProd = Math.Round(Convert.ToDouble(entityAnod.GeneralAreaProducedProfile) - Convert.ToDouble(areaProduced), 2);
                double areaDefect = Math.Round(Convert.ToDouble(entityAnod.GeneralAreaDefectiveProfile) - Convert.ToDouble(areaDefected), 2);
                reposGeneral.UpdateAnodizingAluminumProfile(entity.NumberAnodizingProcess, Convert.ToDouble(weightProd), Convert.ToDouble(weightDefect), Convert.ToDouble(areaProd), Convert.ToDouble(areaDefect));
                //shotRepos.UpdateShotBlastingProfileReadinessProfile(entity.NomenclatureProfile, entity.NumberSpecification, false);
                
                    List<ShotBlastingProfile> list = shotRepos.GetListShotBlastingProfile(entity.NomenclatureProfile, entity.NumberSpecification);
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            shotRepos.UpdateShotBlastingProfileReadinessProfile(item.Id, false);
                        }
                    }
                
                repos.Remove(Id);
                AnodizingProcessProfileList = repos.GetAllEntity(NumberAnodizingProcess);
            }
        }
    }
}
