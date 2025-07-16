using EloksalPro.Models;
using EloksalPro.Repositories;
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
{/// <summary>
 /// Нанесение защитной пленки
 /// </summary>
    public class TapeProtectiveProcessViewModel : ViewModelBase
    {
        DetailReceptionMaterialsRepository detailReception = new DetailReceptionMaterialsRepository();
        public TapeProtectiveProcessProfile _tapeProtective = new TapeProtectiveProcessProfile();
        public string _numberSpecificationSource;
        public string _clientName;

        public int _lenghtProfile;
        public int _quantityProducedProfile;
        public int _quantityDefectedProfile;
        public double _weightProfile;
        public double _weightProfileProduced;
        public double _weightProfileDefected;
        private List<string> _employeeList;
        private string _employeeSource;
        public ObservableCollection<TapeProtectiveProcessProfile> _tapeProtectiveProcessProfile = new ObservableCollection<TapeProtectiveProcessProfile>();
        private string _workingShiftSource;
        private int _id;
        private string _numberTapeProtective;
        private List<string> _nomenclatureProfileList; // номенклатура профиля
        private string _nomenclatureSource;
        public string _eloksalNoCommercial;
        public double _outerPerimeter; // внешний периметр
        public double _generalAreaProducedProfile;
        public double _generalAreaDefectiveProfile;
        public double _consumptionProtectiveFilm;
        public int _widthTapeProtectiveProfile;
        public double _quantityRunningMeter;

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
        public double QuantityRunningMeter
        {
            get { return _quantityRunningMeter; }
            set { _quantityRunningMeter = value; OnPropertyChanged(nameof(QuantityRunningMeter)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public string NumberTapeProtective
        {
            get { return _numberTapeProtective; }
            set { _numberTapeProtective = value; OnPropertyChanged("NumberTapeProtective"); }
        }
        public string WorkingShiftSource
        {
            get { return _workingShiftSource; }
            set { _workingShiftSource = value; OnPropertyChanged("WorkingShiftSource"); }
        }
        public ObservableCollection<TapeProtectiveProcessProfile> TapeProtectiveProcessProfile
        {
            get { return _tapeProtectiveProcessProfile; }
            set { _tapeProtectiveProcessProfile = value; OnPropertyChanged(nameof(TapeProtectiveProcessProfile)); }
        }
        public double WeightProfileProduced
        {
            get { return _weightProfileProduced; }
            set { _weightProfileProduced = value; OnPropertyChanged(nameof(WeightProfileProduced)); }
        }
        public double WeightProfileDefected
        {
            get { return _weightProfileDefected; }
            set { _weightProfileDefected = value; OnPropertyChanged(nameof(WeightProfileDefected)); }
        }
        public double ConsumptionProtectiveFilm
        {
            get { return _consumptionProtectiveFilm; }
            set { _consumptionProtectiveFilm = value; OnPropertyChanged(nameof (ConsumptionProtectiveFilm)); }
        }
        public int WidthTapeProtectiveProfile
        {
            get { return _widthTapeProtectiveProfile; }
            set { _widthTapeProtectiveProfile = value; GetConsumptionProtectiveFilm(); OnPropertyChanged(nameof(WidthTapeProtectiveProfile)); }
        }
        public int QuantityProducedProfile
        {
            get { return _quantityProducedProfile; }
            set { _quantityProducedProfile = value; GetWeightProfileProduced(); GetConsumptionProtectiveFilm(); OnPropertyChanged(nameof(QuantityProducedProfile)); }
        }
        public int QuantityDefectedProfile
        {
            get { return _quantityDefectedProfile; }
            set { _quantityDefectedProfile = value; GetWeightProfileDefected(); OnPropertyChanged(nameof(QuantityDefectedProfile)); }
        }

        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value; GetNomenclatureProfiles(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }

        public TapeProtectiveProcessProfile TapeProtective
        {
            get { return _tapeProtective; }
            set { _tapeProtective = value; OnPropertyChanged(nameof(TapeProtective)); }
        }
        private List<string> _workingShiftList = new List<string>() { "08:00-20:00", "20:00-08:00" };
        public List<string> WorkingShiftList
        {
            get { return _workingShiftList; }
            set { _workingShiftList = value; OnPropertyChanged(nameof(WorkingShiftList)); }
        }
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; OnPropertyChanged(nameof(ClientName)); }
        }
        public int LenghtProfile
        {
            get { return _lenghtProfile; }
            set { _lenghtProfile = value; OnPropertyChanged(nameof(LenghtProfile)); }
        }
        public double WeightProfile
        {
            get { return _weightProfile; }
            set { _weightProfile = value; OnPropertyChanged(nameof(WeightProfile)); }
        }

        private List<string> _numderSpecification;
        public List<string> NumderSpecification
        {
            get { return _numderSpecification; }
            set { _numderSpecification = value; OnPropertyChanged(nameof(NumderSpecification)); }
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
            set { _nomenclatureSource = value; GetNomenclatureProfile(); OnPropertyChanged(nameof(NomenclatureSource)); }
        }
        public string EloksalNoCommercial
        {
            get { return _eloksalNoCommercial; }
            set { _eloksalNoCommercial = value; OnPropertyChanged(nameof(EloksalNoCommercial)); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand ShowRemoveCommand { get; }
        public TapeProtectiveProcessViewModel()
        {
            
            TapeProtectiveProcessProfileRepository reposType = new TapeProtectiveProcessProfileRepository();
            NumderSpecification = GetNumberSpecificationTapeProtective();
            SaveInsertCommand = new ViewModelCommand(InsertNewProfileTapeProtective);
            int MaxEloksalNo = reposType.MaxNumberTapeProtectiveProcess() + 1;
            NumberTapeProtective = "TP" + MaxEloksalNo.ToString("D4");
            ShowRemoveCommand = new ViewModelCommand(RemoveCommand);
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsernameRoleTwo();
            AddTimer();
        }
        public void GetNomenclatureProfiles()
        {
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();
            СuttingFacingProfileRepository cuttingRepos = new СuttingFacingProfileRepository();
            List<string> listReception = reposReception.GetNomenclatureDetailReceptionTapeProtective(NumberSpecificationSource);
            List<string> listAnod = repos.GetNomenclature(NumberSpecificationSource);
            List<string> listCutting= cuttingRepos.GetNomenclatureTapeProtective(NumberSpecificationSource);
            List<string> list = new List<string>();
            list.AddRange(listReception);
            list.AddRange(listAnod);
            list.AddRange(listCutting);
            _nomenclatureProfileList =list.Distinct().ToList();
            OnPropertyChanged(nameof(NomenclatureProfileList));
        }
        public List<string> GetNumberSpecificationTapeProtective()
        {
            СuttingFacingProfileRepository cuttingRepos = new СuttingFacingProfileRepository();
            AnodizingProcessProfileRepository repos = new AnodizingProcessProfileRepository();
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();
            //TapeProtectiveProcessProfileRepository reposTape = new TapeProtectiveProcessProfileRepository();
            //List<string> listNomenclatureTape = reposTape.GetNumberSpecificationCutting();
            List<string> listNomenclature = cuttingRepos.GetNumberSpecificationCuttingTapeProtective();
            List<string> listAnod = repos.GetNumberSpecification();
            List<string> listReception = reposReception.GetNumberSpecificationTapeProtective();
            List<string> list = new List<string>();
            list.AddRange(listAnod);
            list.AddRange(listReception);
            list.AddRange(listNomenclature);
            return list;
        }
        public void GetNomenclatureProfile()
        {
            if (NomenclatureSource != null)
            {
                ProfileCardRepository repos = new ProfileCardRepository();
                ProfileCard profile = new ProfileCard();
                //string name = NomenclatureSource.Substring(0, 6);
                profile = repos.GetByListProfileCard(NomenclatureSource);

                if (profile != null)
                {
                    _clientName = profile.ClientName;
                    OnPropertyChanged(nameof(ClientName));
                    _outerPerimeter = profile.OuterPerimeter;
                    OnPropertyChanged(nameof(OuterPerimeter));
                    _eloksalNoCommercial = profile.EloksalNoCommercial;
                    OnPropertyChanged(nameof(EloksalNoCommercial));
                    _lenghtProfile = profile.LenghtProfile;
                    OnPropertyChanged(nameof(LenghtProfile));
                    _weightProfile = (profile.WeightMeter) / 1000;
                    OnPropertyChanged(nameof(WeightProfile));
                }
            }
        }
        public void GetWeightProfileProduced()
        {
            _weightProfileProduced = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(WeightProfile) * Convert.ToDouble(QuantityProducedProfile)) / 1000,2);
            OnPropertyChanged(nameof(WeightProfileProduced));
            _generalAreaProducedProfile = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(QuantityProducedProfile)) / 1000000,2);
            OnPropertyChanged(nameof(GeneralAreaProducedProfile));
            _quantityRunningMeter = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(QuantityProducedProfile)) / 1000, 2);
            OnPropertyChanged(nameof(QuantityRunningMeter));
        }
        public void GetWeightProfileDefected()
        {
            _weightProfileDefected =Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(WeightProfile) * Convert.ToDouble(QuantityDefectedProfile)) / 1000,2);
            OnPropertyChanged(nameof(WeightProfileDefected));
            _generalAreaDefectiveProfile = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(QuantityDefectedProfile)) / 1000000,2);
            OnPropertyChanged(nameof(GeneralAreaDefectiveProfile));
        }
        public void GetConsumptionProtectiveFilm()
        {
            _consumptionProtectiveFilm = Math.Round(((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(WidthTapeProtectiveProfile) * Convert.ToDouble(QuantityProducedProfile)) / 1000000), 2);
            OnPropertyChanged(nameof(ConsumptionProtectiveFilm));
        }
        public void InsertNewProfileTapeProtective(object obj)
        {
            TapeProtectiveProcessProfileRepository repos = new TapeProtectiveProcessProfileRepository();
            TapeProtectiveProcessProfileGeneralRepository reposTapeProtectiveProcessProfileGeneral = new TapeProtectiveProcessProfileGeneralRepository();
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();

            if (TapeProtective.StartTime == null)
            {
                TapeProtective.StartTime = DateTime.Now;
            }
            if (TapeProtective.EndTime == null)
            {
                TapeProtective.EndTime = DateTime.Now;
            }
            if (TapeProtective.DateTapeProtective == DateTime.MinValue)
            {
                TapeProtective.DateTapeProtective = DateTime.Now;
            }

            AnodizingProcessProfileRepository reposAnodizingProcess = new AnodizingProcessProfileRepository();
            СuttingFacingProfileRepository reposCutting = new СuttingFacingProfileRepository();
            int countAnodizingProcess = reposAnodizingProcess.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource);
            int tapeProtectiveProfilesCount = Convert.ToInt32(repos.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource));
            int tapeProtectiveProfilesCountDefective = Convert.ToInt32(repos.GetCountNomenclatureDefective(NumberSpecificationSource, NomenclatureSource));
            int cuttingFacingProfileCount = Convert.ToInt32(reposCutting.GetCountNomenclatureAfter(NumberSpecificationSource, NomenclatureSource));
            bool checkValue = reposTapeProtectiveProcessProfileGeneral.CheckValueTapeProtectiveProcessProfile(NumberTapeProtective);
            int count = reposTapeProtectiveProcessProfileGeneral.CheckValueTapeProtectiveProcessProfileDayShift(TapeProtective.DateTapeProtective);
            double detailReceptionCount = reposReception.GetCountReceptionMaterials(NumberSpecificationSource, NomenclatureSource);
            if (count >= 2 && !checkValue)
            {
                MessageBox.Show("За один день можно открыть только две смены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (WorkingShiftSource == null || NumberSpecificationSource == null || NomenclatureSource == null || QuantityProducedProfile == 0 || EmployeeSource == null || WidthTapeProtectiveProfile==0)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if ((!NomenclatureSource.Contains("T") && !NomenclatureSource.Contains("R")) && NomenclatureSource.Contains("A") && countAnodizingProcess < tapeProtectiveProfilesCount + tapeProtectiveProfilesCountDefective + QuantityProducedProfile + QuantityDefectedProfile)
            {
                MessageBox.Show("Общий вес  превышает вес после анодирования!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (NomenclatureSource.Contains("P") && !NomenclatureSource.Contains("A") && !NomenclatureSource.Contains("T") && !NomenclatureSource.Contains("R") && detailReceptionCount < tapeProtectiveProfilesCount + tapeProtectiveProfilesCountDefective + QuantityProducedProfile + QuantityDefectedProfile)
            {
                MessageBox.Show("Общий вес  превышает принятого сырья!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if ((NomenclatureSource.Contains("T") || NomenclatureSource.Contains("R")) && NomenclatureSource.Contains("P") && cuttingFacingProfileCount < QuantityProducedProfile + QuantityDefectedProfile+ tapeProtectiveProfilesCount + tapeProtectiveProfilesCountDefective)
            {
                MessageBox.Show("Общий вес  превышает вес после распила и торцовки!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                if ((!NomenclatureSource.Contains("T") && !NomenclatureSource.Contains("R")) && NomenclatureSource.Contains("A") && countAnodizingProcess == tapeProtectiveProfilesCount + tapeProtectiveProfilesCountDefective + QuantityProducedProfile + QuantityDefectedProfile)
                {

                    List<AnodizingProcessProfile> GetListTapeProtectiveProcess = reposAnodizingProcess.GetListAnodizingProcess(NomenclatureSource, NumberSpecificationSource);
                    if (GetListTapeProtectiveProcess != null)
                    {
                        foreach (var item in GetListTapeProtectiveProcess)
                        {
                            reposAnodizingProcess.UpdateAnodizingProcessProfileReadinessProfile(item.Id, true);
                        }
                    }
                }
                else if ((NomenclatureSource.Contains("T") || NomenclatureSource.Contains("R")) && NomenclatureSource.Contains("P") && cuttingFacingProfileCount == QuantityProducedProfile + QuantityDefectedProfile + tapeProtectiveProfilesCount + tapeProtectiveProfilesCountDefective)
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
                else if (NomenclatureSource.Contains("P") && !NomenclatureSource.Contains("A") && !NomenclatureSource.Contains("T") && !NomenclatureSource.Contains("R") && (detailReceptionCount == tapeProtectiveProfilesCount + tapeProtectiveProfilesCountDefective + QuantityProducedProfile + QuantityDefectedProfile))
                {
                    reposReception.UpdateReceptionDetailMaterialsReadinessProfile(NomenclatureSource, NumberSpecificationSource, true);
                }
                int maxId = repos.GetById();
                TapeProtectiveProcessProfile tapeProtectiveProcessProfile = new TapeProtectiveProcessProfile();
                tapeProtectiveProcessProfile.Id = ++maxId;
                tapeProtectiveProcessProfile.NumberTapeProtectiveGeneral = NumberTapeProtective;
                tapeProtectiveProcessProfile.DateTapeProtective = TapeProtective.DateTapeProtective;
                tapeProtectiveProcessProfile.StartTime = TapeProtective.StartTime;
                tapeProtectiveProcessProfile.EndTime = TapeProtective.EndTime;
                tapeProtectiveProcessProfile.NumberSpecification = NumberSpecificationSource;
                tapeProtectiveProcessProfile.ClientName = ClientName;
                tapeProtectiveProcessProfile.EloksalNoCommercial = EloksalNoCommercial;
                tapeProtectiveProcessProfile.NomenclatureProfile = NomenclatureSource;
                tapeProtectiveProcessProfile.LenghtProfileFact = LenghtProfile;
                tapeProtectiveProcessProfile.WeightMeter = WeightProfile;
                tapeProtectiveProcessProfile.OuterPerimeter = OuterPerimeter;
                tapeProtectiveProcessProfile.QuantityProducedProfile = QuantityProducedProfile;
                tapeProtectiveProcessProfile.QuantityDefectedProfile = QuantityDefectedProfile;
                tapeProtectiveProcessProfile.BasketNumber = TapeProtective.BasketNumber;
                tapeProtectiveProcessProfile.Annotation = TapeProtective.Annotation;
                tapeProtectiveProcessProfile.GeneralQuantityProducedProfile = WeightProfileProduced;
                tapeProtectiveProcessProfile.GeneralQuantityDefectedProfile = WeightProfileDefected;
                tapeProtectiveProcessProfile.GeneralAreaProducedProfile = GeneralAreaProducedProfile;
                tapeProtectiveProcessProfile.GeneralAreaDefectiveProfile = GeneralAreaDefectiveProfile;
                tapeProtectiveProcessProfile.QuantityRunningMeter = QuantityRunningMeter;
                tapeProtectiveProcessProfile.WidthTapeProtectiveProfile = WidthTapeProtectiveProfile;
                tapeProtectiveProcessProfile.ConsumptionProtectiveFilm = ConsumptionProtectiveFilm;
                tapeProtectiveProcessProfile.Annotation = TapeProtective.Annotation;
                tapeProtectiveProcessProfile.Employee = EmployeeSource;
                repos.Add(tapeProtectiveProcessProfile);
                TapeProtectiveProcessProfile.Add(tapeProtectiveProcessProfile);
                InsertNewTapeProtectiveProfilesGenerals();
                AddWeightTapeProtectiveProcessProfileGeneral();
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
            WeightProfile = 0;
            QuantityProducedProfile = 0;
            QuantityDefectedProfile = 0;
            LenghtProfile = 0;
            WeightProfileProduced = 0;
            WeightProfileDefected = 0;
            WidthTapeProtectiveProfile = 0;
        }
        public void InsertNewTapeProtectiveProfilesGenerals()
        {
            TapeProtectiveProcessProfileGeneralRepository repos = new TapeProtectiveProcessProfileGeneralRepository();
            int maxId = repos.GetById();
            TapeProtectiveProcessProfileGeneral tapeProtective = new TapeProtectiveProcessProfileGeneral();
            bool checkValue = repos.CheckValueTapeProtectiveProcessProfile(NumberTapeProtective);
            if (!checkValue)
            {
                tapeProtective.Id = ++maxId;
                tapeProtective.Date = TapeProtective.DateTapeProtective;
                tapeProtective.Shift = WorkingShiftSource;
                tapeProtective.Annotation = TapeProtective.Annotation;
                tapeProtective.NumberTapeProtectiveProcess = NumberTapeProtective;
                tapeProtective.Employee = EmployeeSource;
                repos.Add(tapeProtective);
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
            TapeProtectiveProcessProfileRepository repos = new TapeProtectiveProcessProfileRepository();
            TapeProtectiveProcessProfile = repos.GetAllEntity(NumberTapeProtective);
        }
        public void AddWeightTapeProtectiveProcessProfileGeneral()
        {
            TapeProtectiveProcessProfileGeneralRepository reposShot = new TapeProtectiveProcessProfileGeneralRepository();
            TapeProtectiveProcessProfileGeneral myEntity = new TapeProtectiveProcessProfileGeneral();
            myEntity = reposShot.GetWeightProduced(NumberTapeProtective);
            double weightProduced = myEntity.GeneralQuantityProducedProfile;
            double weightDefected = myEntity.GeneralQuantityDefectedProfile;
            double areaProduced = myEntity.GeneralAreaProducedProfile;
            double areaDefected = Convert.ToDouble(myEntity.GeneralAreaDefectiveProfile);
            double consumptionProtectiveFilm= myEntity.ConsumptionProtectiveFilm;
            double weightProducedAll = weightProduced + WeightProfileProduced;
            double weightDefectedAll = weightDefected + WeightProfileDefected;
            double areaProducedAll = areaProduced + GeneralAreaProducedProfile;
            double areaDefectedAll = areaDefected + GeneralAreaDefectiveProfile;
            double consumptionProtectiveFilmAll = consumptionProtectiveFilm + ConsumptionProtectiveFilm;
            reposShot.UpdateTapeProtectiveAluminumProfile(NumberTapeProtective, weightProducedAll, weightDefectedAll, areaProducedAll, areaDefectedAll, consumptionProtectiveFilmAll);
        }
        public void RemoveCommand(object obj)
        {
            //TapeProtectiveProcessProfileRepository repos = new TapeProtectiveProcessProfileRepository();
            //AnodizingProcessProfileRepository reposAnodizingProcess = new AnodizingProcessProfileRepository();
            //repos.Remove(Id);
            //TapeProtectiveProcessProfile = repos.GetAllEntity(NumberTapeProtective);
            //TapeProtectiveProcessProfileGeneralRepository reposGeneral = new TapeProtectiveProcessProfileGeneralRepository();
            //double weightProduced = 0;
            //double weightDefected = 0;
            //double areaProduced = 0;
            //double areaDefected = 0;
            //foreach (var item in TapeProtectiveProcessProfile)
            //{
            //    weightProduced += item.GeneralQuantityProducedProfile;
            //    weightDefected += item.GeneralQuantityDefectedProfile;
            //    areaProduced += item.GeneralAreaProducedProfile;
            //    areaDefected += Convert.ToDouble(item.GeneralAreaDefectiveProfile);
            //}
            //reposGeneral.UpdateTapeProtectiveAluminumProfile(NumberTapeProtective, weightProduced, weightDefected,areaProduced,areaDefected);
            //reposAnodizingProcess.UpdateAnodizingProcessProfileReadinessProfile(entity.NomenclatureProfile, entity.NumberSpecification, false);

            TapeProtectiveProcessProfileRepository repos = new TapeProtectiveProcessProfileRepository();
            TapeProtectiveProcessProfileGeneralRepository reposGeneral = new TapeProtectiveProcessProfileGeneralRepository();
            TapeProtectiveProcessProfile entity = new TapeProtectiveProcessProfile();
            entity = repos.GetByEntity(Id);
            if (entity != null)
            {
                double? weightProduced = entity.GeneralQuantityProducedProfile;
                double? weightDefected = entity.GeneralQuantityDefectedProfile;
                double? areaProduced = entity.GeneralAreaProducedProfile;
                double? areaDefected = entity.GeneralAreaDefectiveProfile;
                double? consumptionProtectiveFilmAll = entity.ConsumptionProtectiveFilm;

                TapeProtectiveProcessProfileGeneral entityTapeProtective = new TapeProtectiveProcessProfileGeneral();
                AnodizingProcessProfileRepository anodRepos = new AnodizingProcessProfileRepository();
                entityTapeProtective = reposGeneral.GetWeightProduced(entity.NumberTapeProtectiveGeneral);

                double weightProd = Math.Round(Convert.ToDouble(entityTapeProtective.GeneralQuantityProducedProfile) - Convert.ToDouble(weightProduced), 2);
                double weightDefect = Math.Round(Convert.ToDouble(entityTapeProtective.GeneralQuantityDefectedProfile) - Convert.ToDouble(weightDefected), 2);
                double areaProd = Math.Round(Convert.ToDouble(entityTapeProtective.GeneralAreaProducedProfile) - Convert.ToDouble(areaProduced), 2);
                double areaDefect = Math.Round(Convert.ToDouble(entityTapeProtective.GeneralAreaDefectiveProfile) - Convert.ToDouble(areaDefected), 2);
                double consumptionProtective= Math.Round(Convert.ToDouble(entityTapeProtective.ConsumptionProtectiveFilm) - Convert.ToDouble(consumptionProtectiveFilmAll), 2);
                reposGeneral.UpdateTapeProtectiveAluminumProfile(entity.NumberTapeProtectiveGeneral, Convert.ToDouble(weightProd), Convert.ToDouble(weightDefect), Convert.ToDouble(areaProd), Convert.ToDouble(areaDefect), Convert.ToDouble(consumptionProtective));


                if (!entity.NomenclatureProfile.Contains("T") && !entity.NomenclatureProfile.Contains("S"))
                {
                    List<AnodizingProcessProfile> ListAnod = anodRepos.GetListAnodizingProcess(entity.NomenclatureProfile, entity.NumberSpecification);
                    if (ListAnod != null)
                    {
                        foreach (var item in ListAnod)
                        {
                            anodRepos.UpdateAnodizingProcessProfileReadinessProfile(item.Id, false);
                        }
                    }

                }
                if (entity.NomenclatureProfile.Contains("T") || entity.NomenclatureProfile.Contains("S"))
                {
                    List<TapeProtectiveProcessProfile> ListTapeProtectiveProcessProfile = repos.GetListTapeProtectiveProcessProfile(entity.NomenclatureProfile, entity.NumberSpecification);
                    if (ListTapeProtectiveProcessProfile != null)
                    {
                        foreach (var item in ListTapeProtectiveProcessProfile)
                        {
                            repos.UpdateTapeProtectiveProcessProfileReadinessProfile(item.Id, false);
                        }
                    }

                }
                repos.Remove(Id);
                TapeProtectiveProcessProfile = repos.GetAllEntity(NumberTapeProtective);

            }
        }
    }
}
