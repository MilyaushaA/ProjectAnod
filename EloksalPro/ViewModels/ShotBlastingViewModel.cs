
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
{
    /// <summary>
    /// Дробейструйная обработка
    /// </summary>
    public class ShotBlastingViewModel:ViewModelBase
    {
        DetailReceptionMaterialsRepository detailReception = new DetailReceptionMaterialsRepository();
        public ShotBlastingProfile _shotBlasting = new ShotBlastingProfile();
        public string _numberSpecificationSource;
        public string _clientName;
        public int _lenghtProfile;
        public int _quantityProducedProfile; 
        public double _weightProfile;
        public double _weightProfileProduced;
        public int _quantityDefectiveProfile;
        public double _weightProfileDefective;
        public ObservableCollection<ShotBlastingProfile> _shotBlastingProfile = new ObservableCollection<ShotBlastingProfile>();
      
        private string _workingShiftSource;
        private int _id;
        private string _numberShotGeneral;
        private List<string> _employeeList;
        private string _employeeSource;
        private List<string> _nomenclatureProfileList; // номенклатура профиля
        private string _nomenclatureSource;
        public string _eloksalNoCommercial;
        public double _areaProfileProduced;
        public double _areaProfileDefective;
        public double _outerPerimeter;
        
        //private DateTime _endDate;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public string NumberShotGeneral
        {
            get { return _numberShotGeneral; }
            set { _numberShotGeneral = value; OnPropertyChanged("NumberShotGeneral"); }
        }
        public string WorkingShiftSource
        {
            get { return _workingShiftSource; }
            set { _workingShiftSource = value; OnPropertyChanged("WorkingShiftSource"); }
        }
        public ObservableCollection<ShotBlastingProfile> ShotBlastingProfile
        {
            get { return _shotBlastingProfile; }
            set { _shotBlastingProfile = value; OnPropertyChanged(nameof(ShotBlastingProfile)); }
        }
     
        public double WeightProfileProduced
        {
            get { return _weightProfileProduced; }
            set { _weightProfileProduced = value;OnPropertyChanged(nameof(WeightProfileProduced)); }
        }
        public int QuantityProducedProfile
        {
            get { return _quantityProducedProfile; }
            set { _quantityProducedProfile = value; GetWeightProfileProduced(); OnPropertyChanged(nameof(QuantityProducedProfile)); }
        }
        public int QuantityDefectiveProfile
        {
            get { return _quantityDefectiveProfile; }
            set { _quantityDefectiveProfile = value; GetWeightProfileDefective(); OnPropertyChanged(nameof(QuantityDefectiveProfile)); }
        }
        public double WeightProfileDefective
        {
            get { return _weightProfileDefective; }
            set { _weightProfileDefective = value; OnPropertyChanged(nameof(WeightProfileDefective)); }
        }
      
        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value;GetEloksalNoCommercial(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }
        public double AreaProfileProduced
        {
            get { return _areaProfileProduced; }
            set { _areaProfileProduced = value; OnPropertyChanged(nameof(AreaProfileProduced)); }
        }
        public double AreaProfileDefective
        {
            get { return _areaProfileDefective; }
            set { _areaProfileDefective = value; OnPropertyChanged(nameof(AreaProfileDefective)); }
        }
        public double OuterPerimeter
        {
            get { return _outerPerimeter; }
            set { _outerPerimeter = value; OnPropertyChanged(nameof(OuterPerimeter)); }
        }
        public ShotBlastingProfile ShotBlasting
        {
            get { return _shotBlasting; }
            set { _shotBlasting = value; OnPropertyChanged(nameof(ShotBlasting)); }
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
        public ShotBlastingViewModel()
        {
            ShotBlastingProfilesGeneralsRepository repos = new ShotBlastingProfilesGeneralsRepository();
            NumderSpecification = detailReception.GetNumberSpecificationShotBlasting();
            SaveInsertCommand = new ViewModelCommand(InsertNewProfileShotBlasting);
            int MaxEloksalNo = repos.MaxNumberShotBlasting() + 1;
            NumberShotGeneral = "SB" + MaxEloksalNo.ToString("D4");
            ShowRemoveCommand = new ViewModelCommand(RemoveCommand);
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsernameRoleTwo();
            AddTimer();
        } 
        public void GetEloksalNoCommercial()
        {
            NomenclatureProfileList = detailReception.GetOrderNumber(NumberSpecificationSource);
            OnPropertyChanged(nameof(EloksalNoCommercial));
        }
        public void GetNomenclatureProfile()
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
                _lenghtProfile = detailReception.GetLenghtFact(NomenclatureSource,NumberSpecificationSource);
                OnPropertyChanged(nameof(LenghtProfile));
                _weightProfile = (detailReception.GetWeightMeter(NomenclatureSource)) / 1000;
                OnPropertyChanged(nameof(WeightProfile));
                _outerPerimeter = profile.OuterPerimeter;
                OnPropertyChanged(nameof(OuterPerimeter));
            }
        }
        public void GetWeightProfileProduced()
        {
            _weightProfileProduced = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(WeightProfile) * Convert.ToDouble(QuantityProducedProfile))/1000,2);
            OnPropertyChanged(nameof(WeightProfileProduced));
            _areaProfileProduced = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(QuantityProducedProfile)) / 1000000,2);
            OnPropertyChanged(nameof(AreaProfileProduced));
        }
        public void GetWeightProfileDefective()
        {
            _weightProfileDefective = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(WeightProfile) * Convert.ToDouble(QuantityDefectiveProfile)) / 1000,2);
            OnPropertyChanged(nameof(WeightProfileDefective));
            _areaProfileDefective = Math.Round((Convert.ToDouble(LenghtProfile) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(QuantityDefectiveProfile)) / 1000000,2);
            OnPropertyChanged(nameof(AreaProfileDefective));
        }
        public void InsertNewProfileShotBlasting(object obj)
        {
            if (ShotBlasting.StartTime == null)
            {
                ShotBlasting.StartTime = DateTime.Now;
            }
            if (ShotBlasting.EndTime == null)
            {
                ShotBlasting.EndTime = DateTime.Now;
            }
            if (ShotBlasting.DateShotBlasting == DateTime.MinValue)
            {
                ShotBlasting.DateShotBlasting = DateTime.Now;
            }
            ShotBlastingProfileRepository repos = new ShotBlastingProfileRepository();
            ShotBlastingProfilesGeneralsRepository reposGeneral = new ShotBlastingProfilesGeneralsRepository();
            DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
            bool checkValue = reposGeneral.CheckValueShotBlasting(NumberShotGeneral);

            int shotBlastingCount = Convert.ToInt32(repos.GetCountNomenclature(NumberSpecificationSource, NomenclatureSource));
            int shotBlastingCountDefective = Convert.ToInt32(repos.GetCountNomenclatureDefective(NumberSpecificationSource, NomenclatureSource));
            int detailReceptionWeight = Convert.ToInt32(reposDetailReception.GetCountReceptionMaterials(NumberSpecificationSource, NomenclatureSource));
            int maxId = repos.GetById();
         
            int count = reposGeneral.CheckValueShotBlastingDayShift(ShotBlasting.DateShotBlasting);
            if (count >= 2 && !checkValue)
            {
                MessageBox.Show("За один день можно открыть только две смены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (WorkingShiftSource==null || ShotBlasting.StartTime==null || ShotBlasting.EndTime==null || NumberSpecificationSource==null ||
                NomenclatureSource==null || (QuantityProducedProfile + QuantityDefectiveProfile<0) || EmployeeSource == null)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
       
            else if (detailReceptionWeight < shotBlastingCount + shotBlastingCountDefective + QuantityProducedProfile + QuantityDefectiveProfile)
            {
                MessageBox.Show("Общий вес произведенного профиля превышает вес принятого сырья!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (detailReceptionWeight == shotBlastingCount + shotBlastingCountDefective + QuantityProducedProfile + QuantityDefectiveProfile)
                {
                    reposDetailReception.UpdateReceptionDetailMaterialsReadinessProfile(NomenclatureSource, NumberSpecificationSource, true);
                }
                ShotBlastingProfile shotBlastingProfile = new ShotBlastingProfile();
                shotBlastingProfile.Id = ++maxId;
                shotBlastingProfile.NumberShotGeneral = NumberShotGeneral;
                shotBlastingProfile.DateShotBlasting = ShotBlasting.DateShotBlasting;
                shotBlastingProfile.StartTime = ShotBlasting.StartTime;
                shotBlastingProfile.EndTime = ShotBlasting.EndTime;
                shotBlastingProfile.NumberSpecification = NumberSpecificationSource;
                shotBlastingProfile.ClientName = ClientName;
                shotBlastingProfile.EloksalNoCommercial = EloksalNoCommercial;
                shotBlastingProfile.NomenclatureProfile = NomenclatureSource;
                shotBlastingProfile.LenghtProfile = LenghtProfile;
                shotBlastingProfile.WeightMeter = WeightProfile;
                shotBlastingProfile.OuterPerimeter= OuterPerimeter;
                shotBlastingProfile.QuantityProducedProfile = QuantityProducedProfile;
                shotBlastingProfile.BasketNumber = ShotBlasting.BasketNumber;
                shotBlastingProfile.Annotation = ShotBlasting.Annotation;
                shotBlastingProfile.QuantityDefectiveProfile = QuantityDefectiveProfile;
                shotBlastingProfile.GeneralQuantityProducedProfile = WeightProfileProduced;
                shotBlastingProfile.GeneralQuantityDefectiveProfile = WeightProfileDefective;
                shotBlastingProfile.CodeDefectiveProfile = ShotBlasting.CodeDefectiveProfile;
                //shotBlastingProfile.ClampingHeight = ShotBlasting.ClampingHeight;
                //shotBlastingProfile.SpeedTheRoller = ShotBlasting.SpeedTheRoller;
                //shotBlastingProfile.OpeningTheFlapFirst = ShotBlasting.OpeningTheFlapFirst;
                //shotBlastingProfile.OpeningTheFlapSecond = ShotBlasting.OpeningTheFlapSecond;
                //shotBlastingProfile.OpeningTheFlapThird = ShotBlasting.OpeningTheFlapThird;
                //shotBlastingProfile.OpeningTheFlapFourth = ShotBlasting.OpeningTheFlapFourth;
                //shotBlastingProfile.RotationSpeedFirst = ShotBlasting.RotationSpeedFirst;
                //shotBlastingProfile.RotationSpeedSecond = ShotBlasting.RotationSpeedSecond;
                //shotBlastingProfile.RotationSpeedThird = ShotBlasting.RotationSpeedThird;
                //shotBlastingProfile.RotationSpeedFourth = ShotBlasting.RotationSpeedFourth;
                shotBlastingProfile.GeneralAreaProducedProfile =AreaProfileProduced;
                shotBlastingProfile.GeneralAreaDefectiveProfile = AreaProfileDefective;

                repos.Add(shotBlastingProfile);
                ShotBlastingProfile.Add(shotBlastingProfile);
                InsertNewShotBlastingProfilesGenerals();
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
            WeightProfile = 0;
            LenghtProfile = 0;
            OuterPerimeter = 0;
            QuantityProducedProfile = 0;
            QuantityDefectiveProfile=0;
        }
        public void InsertNewShotBlastingProfilesGenerals()
        {
            ShotBlastingProfilesGeneralsRepository repos = new ShotBlastingProfilesGeneralsRepository();
            int maxId = repos.GetById();
            ShotBlastingProfilesGeneral shotBlastingGeneral = new ShotBlastingProfilesGeneral();
            bool checkValue = repos.CheckValueShotBlasting(NumberShotGeneral);
            if (!checkValue)
            {
                shotBlastingGeneral.Id = ++maxId;
                shotBlastingGeneral.Date = ShotBlasting.DateShotBlasting;
                shotBlastingGeneral.Shift = WorkingShiftSource;
                shotBlastingGeneral.Annotation = ShotBlasting.Annotation;
                shotBlastingGeneral.NumberShotGeneral = NumberShotGeneral;
                shotBlastingGeneral.Employee= EmployeeSource;
                repos.Add(shotBlastingGeneral);
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
            ShotBlastingProfileRepository repos = new ShotBlastingProfileRepository();
            ShotBlastingProfile = repos.GetAllEntity(NumberShotGeneral);
        }
        public void AddWeightReceptionMaterials()
        {
           
            ReceptionMaterialsRepository repos = new ReceptionMaterialsRepository();
            double weight = repos.GetWeightShippedProduction(NumberSpecificationSource);
            double allWeight = weight + WeightProfileProduced + WeightProfileDefective;
            //double totalWeight = repos.GetTotalSumWeight(NumberSpecificationSourse);
            repos.UpdateReceptionMaterialsWeight(NumberSpecificationSource, allWeight);

            ShotBlastingProfilesGeneralsRepository reposShot = new ShotBlastingProfilesGeneralsRepository();
            double weightProduced = reposShot.GetWeightProduced(NumberShotGeneral);
            double weightDefective = reposShot.GetWeightDefective(NumberShotGeneral);
            double areaProduced = reposShot.GetAreaProduced(NumberShotGeneral);
            double areaDefective = reposShot.GetAreaDefective(NumberShotGeneral);
            double weightProducedAll = Math.Round(weightProduced + WeightProfileProduced,2);
            double weightDefectiveAll = Math.Round(weightDefective + WeightProfileDefective,2);
            double areaProducedAll = Math.Round(areaProduced + AreaProfileProduced, 2);
            double areatDefectiveAll = Math.Round(areaDefective + AreaProfileDefective, 2);
            reposShot.UpdateWeightDefectiveProducedProfile(NumberShotGeneral, weightProducedAll, weightDefectiveAll, areaProducedAll, areatDefectiveAll);
        }
        
        public void RemoveCommand(object obj)
        {
            ShotBlastingProfileRepository repos = new ShotBlastingProfileRepository();
            ShotBlastingProfile shot = new ShotBlastingProfile();
            shot = repos.GetByEntity(Id);
            if (shot != null)
            {
                double? weightProduced = shot.GeneralQuantityProducedProfile;
                double? weightDefective = shot.GeneralQuantityDefectiveProfile;
                double? areaProduced = shot.GeneralAreaProducedProfile;
                double? areaDefective = shot.GeneralAreaDefectiveProfile;
                double? weightSum = weightProduced + weightDefective;
                string name = shot.NumberSpecification;
                ReceptionMaterialsRepository reposReception = new ReceptionMaterialsRepository();
                DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
                double receptionWeight = reposReception.GetWeightShippedProduction(name);
                double weight = Math.Round(receptionWeight - Convert.ToDouble(weightSum),2);
                reposReception.UpdateReceptionMaterialsWeight(name, weight);
                reposDetailReception.UpdateReceptionDetailMaterialsReadinessProfile(shot.NomenclatureProfile, shot.NumberSpecification, false);
                ShotBlastingProfilesGeneralsRepository reposShot = new ShotBlastingProfilesGeneralsRepository();
                double weightProd = Math.Round(Convert.ToDouble(reposShot.GetWeightProduced(shot.NumberShotGeneral)) - Convert.ToDouble(weightProduced),2);
                double weightDefec = Math.Round(Convert.ToDouble(reposShot.GetWeightDefective(shot.NumberShotGeneral)) - Convert.ToDouble(weightDefective),2);
                double areaProd = Math.Round(Convert.ToDouble(reposShot.GetAreaProduced(shot.NumberShotGeneral)) - Convert.ToDouble(areaProduced), 2);
                double areaDefec = Math.Round(Convert.ToDouble(reposShot.GetAreaDefective(shot.NumberShotGeneral)) - Convert.ToDouble(areaDefective), 2);
                reposShot.UpdateWeightDefectiveProducedProfile(shot.NumberShotGeneral, Convert.ToDouble(weightProd), Convert.ToDouble(weightDefec), Convert.ToDouble(areaProd), Convert.ToDouble(areaDefec));
                repos.Remove(Id);
                ShotBlastingProfile = repos.GetAllEntity(NumberShotGeneral);
            }   
        }     

    }
}
