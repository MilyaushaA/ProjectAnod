using DevExpress.Mvvm;
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
/// Навеска алюминиевого профиля
/// </summary>
    public class HitchAluminumProfilesViewModel : ViewModelBase
    {
        private DateTime _dateHitch;
        private string _numberHitchGeneral;
        private int _numberBars;
        private List<string> _numberSpecification;
        private List<string> _nomenclatureProfileList;
        private string _colorAnod;
        private string _eloksalNoCommercial;
        private string _clientName;
        private double _weightMeter;
        private int _amountPieceFact;
        private int _amountPieceDefect;
        private int _lenghtFact;
        private double _weightGeneral;
        private double _weightGeneralDefect;
        private string _annotation;
        private string _numberSpecificationSource;
        private string _nomenclatureSource;
        private List<string> _workingShiftList = new List<string>() { "08:00-20:00", "20:00-08:00" };
        private string _workingShiftSource;
        private List<string> _employeeList;
        private string _employeeSource;
        private int _id;

        public double _areaProfileProduced;
        public double _areaProfileDefective;
        public double _outerPerimetr;
        private ObservableCollection<HitchAluminumProfile> _hitchAluminumProfile = new ObservableCollection<HitchAluminumProfile>();
        public DateTime DateHitch
        {
            get { return _dateHitch; }
            set { _dateHitch = value; OnPropertyChanged(nameof(DateHitch)); }
        }
        public string NumberHitchGeneral
        {
            get { return _numberHitchGeneral; }
            set { _numberHitchGeneral = value; OnPropertyChanged(nameof(NumberHitchGeneral)); }
        }
        public int NumberBars
        {
            get { return _numberBars; }
            set { _numberBars = value; OnPropertyChanged(nameof(NumberBars)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
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
            get { return _outerPerimetr; }
            set { _outerPerimetr = value; OnPropertyChanged(nameof(OuterPerimeter)); }
        }
        public List<string> NumberSpecification
        {
            get { return _numberSpecification; }
            set { _numberSpecification = value; OnPropertyChanged(nameof(NumberSpecification)); }
        }
        public List<string> NomenclatureProfileList
        {
            get { return _nomenclatureProfileList; }
            set { _nomenclatureProfileList = value; OnPropertyChanged(nameof(NomenclatureProfileList)); }
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
        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value; UpdateListNomenclature(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }
        public string NomenclatureSource
        {
            get { return _nomenclatureSource; }
            set { _nomenclatureSource = value; UpdateDataProfile(); OnPropertyChanged(nameof(NomenclatureSource)); }
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
        public ObservableCollection<HitchAluminumProfile> HitchAluminumProfileList
        {
            get { return _hitchAluminumProfile; }
            set { _hitchAluminumProfile = value; OnPropertyChanged(nameof(HitchAluminumProfileList)); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand RemoveCommand { get; }
        public HitchAluminumProfilesViewModel()
        {
            HitchAluminumProfilesRepository repos = new HitchAluminumProfilesRepository();
            HitchAluminumProfileList = repos.GetAllEntity(NumberHitchGeneral);
            NumberSpecification = GetListNumberSpecification();
            SaveInsertCommand = new ViewModelCommand(InsertNewHitchAluminum);
            RemoveCommand = new ViewModelCommand(RemoveRow);
            int MaxEloksalNo = repos.MaxNumberShotBlasting() + 1;
            NumberHitchGeneral = "HA" + MaxEloksalNo.ToString("D4");
            UserRepository userRepos = new UserRepository();
            EmployeeList = userRepos.GetByUsernameRoleTwo();
            AddTimer();
        }
        public List<string> GetListNumberSpecification()
        {
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
                _colorAnod = profile.ColorAnod;
                OnPropertyChanged(nameof(ColorAnod));
                _outerPerimetr = profile.OuterPerimeter;
                OnPropertyChanged(nameof(OuterPerimeter));
                _weightMeter = profile.WeightMeter / 1000;
                OnPropertyChanged(nameof(WeightMeter));
                DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
                _lenghtFact = reposDetailReception.GetLenghtFact(NomenclatureSource, NumberSpecificationSource);
                OnPropertyChanged(nameof(LenghtFact));
            }
        }
        public void UpdateGeneralWeight()
        {
            _weightGeneral = Math.Round((Convert.ToDouble(AmountPieceFact) * Convert.ToDouble(LenghtFact) * WeightMeter) / 1000,2);
            OnPropertyChanged(nameof(WeightGeneral));
            _areaProfileProduced = Math.Round((Convert.ToDouble(LenghtFact) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(AmountPieceFact)) / 1000000, 2);
            OnPropertyChanged(nameof(AreaProfileProduced));
        }
        public void UpdateGeneralWeightDefect()
        {
            _weightGeneralDefect = Math.Round((Convert.ToDouble(AmountPieceDefect) * Convert.ToDouble(LenghtFact) * WeightMeter) / 1000,2);
            OnPropertyChanged(nameof(WeightGeneralDefect));
            _areaProfileDefective = Math.Round((Convert.ToDouble(LenghtFact) * Convert.ToDouble(OuterPerimeter) * Convert.ToDouble(AmountPieceDefect)) / 1000000, 2);
            OnPropertyChanged(nameof(AreaProfileDefective));
    }
        public void InsertNewHitchAluminum(object obj)
        {
            if (DateHitch == DateTime.MinValue)
            {
                DateHitch = DateTime.Now;
            }
            HitchAluminumProfileGeneralsRepository reposGeneral = new HitchAluminumProfileGeneralsRepository();
            
            HitchAluminumProfilesRepository repos = new HitchAluminumProfilesRepository();
            DetailReceptionMaterialsRepository reposDetailReception = new DetailReceptionMaterialsRepository();
            ShotBlastingProfileRepository reposShot = new ShotBlastingProfileRepository();
            
            bool checkValue = reposGeneral.CheckValueHitchAluminumProfile(NumberHitchGeneral);
            int count = reposGeneral.CheckValueHitchAluminumProfileDayShift(DateHitch);
            double detailReceptionWeight = Math.Round(reposDetailReception.GetWeightReceptionMaterials(NumberSpecificationSource, NomenclatureSource), 2);
            double shotBlastingWeight = reposShot.GetWeightNomenclature(NumberSpecificationSource, NomenclatureSource);
            double hitchAluminumProfilesWeight = repos.GetWeightNomenclature(NumberSpecificationSource, NomenclatureSource);
            double hitchAluminumProfilesWeightDefective = repos.GetWeightNomenclatureDefective(NumberSpecificationSource, NomenclatureSource);
          
            int maxId = repos.GetById();
          
            if (count >= 2 && !checkValue)
            {
                MessageBox.Show("За один день можно открыть только две смены!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (WorkingShiftSource==null || NumberSpecificationSource == null || NomenclatureSource == null || AmountPieceFact == 0 || EmployeeSource == null)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (NomenclatureSource.Contains("AD") && (shotBlastingWeight < Math.Round(hitchAluminumProfilesWeight + hitchAluminumProfilesWeightDefective + WeightGeneral + WeightGeneralDefect,2)))
            {
               MessageBox.Show("Общий вес навески превышает вес после дробейструйной обработки!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);           
            }
            else if (!NomenclatureSource.Contains("AD") && (detailReceptionWeight < Math.Round(hitchAluminumProfilesWeight + hitchAluminumProfilesWeightDefective + WeightGeneral + WeightGeneralDefect,2)))
            {
                MessageBox.Show("Общий вес произведенного профиля превышает вес принятого сырья!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (!NomenclatureSource.Contains("AD"))
                {
                    if (Math.Round(hitchAluminumProfilesWeight + hitchAluminumProfilesWeightDefective + WeightGeneral + WeightGeneral, 2) >= detailReceptionWeight)
                    {
                        reposDetailReception.UpdateReceptionDetailMaterialsReadinessProfile(NomenclatureSource, NumberSpecificationSource, true);
                    }
                }
                else
                {
                    if (Math.Round(hitchAluminumProfilesWeight + hitchAluminumProfilesWeightDefective + WeightGeneral + WeightGeneral, 2) >= shotBlastingWeight)
                    {
                        reposShot.UpdateShotBlastingProfileReadinessProfile(NomenclatureSource, NumberSpecificationSource, true);
                    }
                }
               
                HitchAluminumProfile hitchAluminumProfile = new HitchAluminumProfile();
                hitchAluminumProfile.Id = ++maxId;
                hitchAluminumProfile.DateHitch = DateHitch;
                hitchAluminumProfile.NumberHitchGeneral = NumberHitchGeneral;
                hitchAluminumProfile.NumberBars = NumberBars;
                hitchAluminumProfile.NumberSpecification = NumberSpecificationSource;
                hitchAluminumProfile.NomenclatureProfile = NomenclatureSource;
                hitchAluminumProfile.EloksalNoCommercial = EloksalNoCommercial;
                hitchAluminumProfile.ClientName = ClientName;
                hitchAluminumProfile.ColorAnod = ColorAnod;
                hitchAluminumProfile.WeightMeter = WeightMeter;
                hitchAluminumProfile.AmountPieceFact = AmountPieceFact;
                hitchAluminumProfile.AmountPieceDefect = AmountPieceDefect;
                hitchAluminumProfile.LenghtFact = LenghtFact;
                hitchAluminumProfile.WeightGeneral = WeightGeneral;
                hitchAluminumProfile.WeightGeneralDefect = WeightGeneralDefect;
                hitchAluminumProfile.Annotation = Annotation;
                hitchAluminumProfile.GeneralAreaProducedProfile = AreaProfileProduced;
                hitchAluminumProfile.GeneralAreaDefectiveProfile = AreaProfileDefective;
                hitchAluminumProfile.Employee = EmployeeSource;
          
                repos.Add(hitchAluminumProfile);
                HitchAluminumProfileList.Add(hitchAluminumProfile);
                InsertNewHitchAluminumProfilesGenerals();
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
        OuterPerimeter = 0;
        WeightMeter = 0;
        AmountPieceFact = 0;
        AmountPieceDefect = 0;
        LenghtFact = 0;
        WeightGeneral = 0;
        WeightGeneralDefect = 0;
    }
    public void InsertNewHitchAluminumProfilesGenerals()
        {
            HitchAluminumProfileGeneralsRepository repos = new HitchAluminumProfileGeneralsRepository();
            int maxId = repos.GetById();
            HitchAluminumProfileGeneral hitchAluminumProfile = new HitchAluminumProfileGeneral();
            bool checkValue = repos.CheckValueHitchAluminumProfile(NumberHitchGeneral);
            if (!checkValue)
            {
                hitchAluminumProfile.Id = ++maxId;
                hitchAluminumProfile.Date = DateHitch;
                hitchAluminumProfile.Shift = WorkingShiftSource;
                hitchAluminumProfile.Annotation = Annotation;
                hitchAluminumProfile.NumberHitchGeneral = NumberHitchGeneral;
                hitchAluminumProfile.Employee = EmployeeSource;
                repos.Add(hitchAluminumProfile);
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
            HitchAluminumProfilesRepository repos = new HitchAluminumProfilesRepository();
            HitchAluminumProfileList = repos.GetAllEntity(NumberHitchGeneral);
        }
        public void AddWeightReceptionMaterials()
        {
            HitchAluminumProfileGeneralsRepository reposHitch = new HitchAluminumProfileGeneralsRepository();
            HitchAluminumProfileGeneral entity = new HitchAluminumProfileGeneral();
            entity= reposHitch.GetWeightProduced(NumberHitchGeneral);
            double weightProduced = entity.GeneralQuantityProducedProfile;
            double weightDefected = entity.GeneralQuantityDefectedProfile;
            double areaProduced = entity.GeneralAreaProducedProfile;
            double areaDefected = Convert.ToDouble(entity.GeneralAreaDefectiveProfile);
            double weightProducedAll = weightProduced + WeightGeneral;
            double weightDefectedAll = weightDefected + WeightGeneralDefect;
            double areaProducedAll = areaProduced + AreaProfileProduced;
            double areaDefectedAll = areaDefected + AreaProfileDefective;
            reposHitch.UpdateHitchAluminumProfile(NumberHitchGeneral, weightProducedAll, weightDefectedAll, areaProducedAll, areaDefectedAll);

            ReceptionMaterialsRepository repos = new ReceptionMaterialsRepository();
            double weight = repos.GetWeightShippedProduction(NumberSpecificationSource);
            double allWeight = 0;
            if (!NomenclatureSource.Contains("AD"))
            {
                allWeight = Math.Round(WeightGeneral + WeightGeneralDefect + weight,2);
                repos.UpdateReceptionMaterialsWeight(NumberSpecificationSource, allWeight);
            }
        }
        public void RemoveRow(object obj)
        {
            HitchAluminumProfilesRepository repos = new HitchAluminumProfilesRepository();
            HitchAluminumProfile entity = new HitchAluminumProfile();
            entity = repos.GetListHitchAluminumProfile(Id);
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
                double weight = Math.Round(receptionWeight - (Convert.ToDouble(weightProduced) + Convert.ToDouble(weightDefected)),2);
                if (!entity.NomenclatureProfile.Contains("AD"))
                {
                    reposReception.UpdateReceptionMaterialsWeight(name, weight);
                    reposDetailReception.UpdateReceptionDetailMaterialsReadinessProfile(entity.NomenclatureProfile, entity.NumberSpecification, false);
                }
                HitchAluminumProfileGeneralsRepository reposHitch = new HitchAluminumProfileGeneralsRepository();
                HitchAluminumProfileGeneral entityHitch = new HitchAluminumProfileGeneral();
                ShotBlastingProfileRepository shotRepos = new ShotBlastingProfileRepository();
                entityHitch = reposHitch.GetWeightProduced(entity.NumberHitchGeneral);
                double weightProd = Math.Round(Convert.ToDouble(entityHitch.GeneralQuantityProducedProfile) - Convert.ToDouble(weightProduced),2);
                double weightDefect = Math.Round(Convert.ToDouble(entityHitch.GeneralQuantityDefectedProfile) - Convert.ToDouble(weightDefected),2);
                double areaProd = Math.Round(Convert.ToDouble(entityHitch.GeneralAreaProducedProfile) - Convert.ToDouble(areaProduced), 2);
                double areaDefect = Math.Round(Convert.ToDouble(entityHitch.GeneralAreaDefectiveProfile) - Convert.ToDouble(areaDefected), 2);
                reposHitch.UpdateHitchAluminumProfile(entity.NumberHitchGeneral, Convert.ToDouble(weightProd), Convert.ToDouble(weightDefect), Convert.ToDouble(areaProd), Convert.ToDouble(areaDefect));
                shotRepos.UpdateShotBlastingProfileReadinessProfile(entity.NomenclatureProfile, entity.NumberSpecification, false);
                repos.Remove(Id);
                HitchAluminumProfileList = repos.GetAllEntity(NumberHitchGeneral);
            }
            
        }

    }
}