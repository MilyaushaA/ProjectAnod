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
    public class ReceptionMaterialsViewModel: ViewModelBase
    {
     
        private List<string> _workingShiftList = new List<string>() {"08:00-20:00","20:00-08:00"};
        private string _workingShiftSource;
        private string _numberSpecification;
        private List<string> _listUser;
        private string _sourceUser;
        private string _annotation;
        private int _idReception;
        private int _idNomenclature;
        private DateTime _dateReception;
        private List<DetailReceptionMaterials> _detailReception;

        public  List<string> WorkingShiftList
        {
            get { return _workingShiftList; }
            set { _workingShiftList = value;OnPropertyChanged(nameof(WorkingShiftList)); }
        }
        public List<string> ListUser
        {
            get { return _listUser; }
            set { _listUser = value; OnPropertyChanged(nameof(ListUser)); }
        }
        public string WorkingShiftSource
        {
            get { return _workingShiftSource; }
            set { _workingShiftSource = value; OnPropertyChanged(nameof(WorkingShiftSource)); }
        }
        public List<DetailReceptionMaterials> DetailReception
        {
            get { return _detailReception; }
            set { _detailReception = value; OnPropertyChanged(nameof(DetailReception)); }
        }
       
        public string SourceUser
        {
            get { return _sourceUser; }
            set { _sourceUser = value; OnPropertyChanged(nameof(SourceUser)); }
        }
        public string NumberSpecification
        {
            get { return _numberSpecification; }
            set { _numberSpecification = value; OnPropertyChanged(nameof(NumberSpecification)); }
        }
        public string Annotation
        {
            get { return _annotation; }
            set { _annotation = value; OnPropertyChanged(nameof(Annotation));}
        }
        public int IdReception
        {
            get { return _idReception; }
            set { _idReception = value; OnPropertyChanged(nameof(IdReception)); }
        }
        public int IdNomenclature
        {
            get { return _idNomenclature; }
            set { _idNomenclature = value; OnPropertyChanged(nameof(IdNomenclature)); }
        }
        public DateTime DateReception
        {
            get { return _dateReception; }
            set { _dateReception = value; OnPropertyChanged(nameof(DateReception)); }
        }
     
        public ICommand SaveInsertCommand { get; }
       
        public ICommand ShowExtensiveReceptionProfileCommand { get; }

        public ReceptionMaterialsViewModel()
        {
            UserRepository userRepos = new UserRepository();
            DetailReceptionMaterialsRepository repos = new DetailReceptionMaterialsRepository();
            ListUser = userRepos.GetByUsernameRoleTwo();
            AddTimer();
            SaveInsertCommand = new ViewModelCommand(InsertDataReceptionMaterials);
            ShowExtensiveReceptionProfileCommand= new ViewModelCommand(ShowExtensiveReceptionProfile);
           

        }
        void ShowExtensiveReceptionProfile(object obj)
        {
            ExtensiveReceptionProfileView extensive = new ExtensiveReceptionProfileView();
            extensive.Show();
            DetailReceptionMaterialsRepository repos = new DetailReceptionMaterialsRepository();
            DetailReceptionMaterials entity = repos.GetByEntity(IdNomenclature);
            ProfileCardRepository reposCard = new ProfileCardRepository();
            ProfileCard enrtityCard = new ProfileCard();
            if (entity != null)
            {
                enrtityCard = reposCard.GetByListProfileCard(entity.NomenclatureProfile);
                extensive.txtClientName.Text = entity.ClientName;
                extensive.txtEloksalNoCommercial.Text = entity.EloksalNoCommercial;
                extensive.txtLenghtFact.Text = entity.LenghtFact.ToString();
                extensive.txtWeightMeter.Text = (entity.WeightMeter / 1000).ToString();
                extensive.txtNomenclatureProfile.Text = entity.NomenclatureProfile;
                extensive.txtNumderSpecification.Text = entity.NumberSpecification;
                extensive.txtOuterPerimeter.Text = enrtityCard.OuterPerimeter.ToString();
                extensive.txtDate.Text = entity.DateReception.ToString();
            }
        }

        public void AddTimer()
        {
            Timer timer = new Timer();
            timer.Elapsed += RefreshProductionOperation;
            timer.Interval = 500;
            timer.AutoReset = false;
            timer.Start();
        }   
        public void RefreshProductionOperation(object sender, ElapsedEventArgs e)
        {
            DetailReceptionMaterialsRepository repos = new DetailReceptionMaterialsRepository();
            DetailReception = repos.GetByAllEntityCollection(NumberSpecification);
        }
        void InsertDataReceptionMaterials(object obj)
        {
            InsertDataReceptionDetailMaterials();
        }
        void InsertDataReceptionDetailMaterials()
        {
            DetailReceptionMaterialsRepository repos = new DetailReceptionMaterialsRepository();
            SpecificationAllDescriptionRepository reposSpecification = new SpecificationAllDescriptionRepository();
            double massa=0;
            DateTime result;
            ReceptionMaterialsRepository reposReceptionMaterials = new ReceptionMaterialsRepository();
            bool ReadinessProfile=false;
            AnodizingProcessProfileRepository anodRepos = new AnodizingProcessProfileRepository();
            ShotBlastingProfileRepository shotRepos = new ShotBlastingProfileRepository();
            if (DateReception==null || WorkingShiftSource==null || SourceUser == null)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (DateTime.TryParse(Convert.ToString(DateReception), out result))
            {
                int AllHour = 168;
                foreach (var item in DetailReception)
                {
                    int shotBlastingCount = Convert.ToInt32(shotRepos.GetCountNomenclature(item.NumberSpecification, item.NomenclatureProfile))
                        + Convert.ToInt32(shotRepos.GetCountNomenclatureDefective(item.NumberSpecification, item.NomenclatureProfile));
                    int anodizingProcessProfileCount = anodRepos.GetCountNomenclature(item.NumberSpecification, item.NomenclatureProfile)
                        + anodRepos.GetCountNomenclatureDefective(item.NumberSpecification, item.NomenclatureProfile);
                    if (item.NomenclatureProfile.Contains("AD") && item.AmountPieceFact > shotBlastingCount)
                    {
                        ReadinessProfile = false;
                    }
                    else if (!item.NomenclatureProfile.Contains("AD") && item.AmountPieceFact > anodizingProcessProfileCount)
                    {
                        ReadinessProfile = false;
                    }
                    else
                    {
                        ReadinessProfile = true;
                    }
                    repos.UpdateReceptionDetailMaterials(item.Id, item.AmountPieceFact, item.LenghtFact,DateReception, ReadinessProfile);
                    reposSpecification.UpdateSpecificationAllDescription(item.NumberSpecification,item.NomenclatureProfile, item.AmountPieceFact, item.LenghtFact);
                    massa = massa + (item.LenghtFact * item.AmountPieceFact * item.WeightMeter / 1000000);
                    int min = PerformanceCalculation(item.NomenclatureProfile, item.AmountPieceFact, item.LenghtFact);
                    int hour = min / 60;
                    AllHour = AllHour + hour;  
                }
                DateTime dateMax = repos.maxDate();
                DateTime? date = dateMax.AddHours(AllHour);
                foreach (var item in DetailReception)
                {
                    repos.UpdateReceptionDetailMaterials(item.Id, date);
                }    
                reposReceptionMaterials.UpdateReceptionMaterials(IdReception, DateReception, WorkingShiftSource, SourceUser, Annotation, Math.Round(massa,2));
                MessageBox.Show("Данные сохранены");
                DetailReception = repos.GetByAllEntityCollection(NumberSpecification);
            }
            
        }     
        int PerformanceCalculation(string name, int count,int lenght)
        {
            ProfileCardRepository profileRepos = new ProfileCardRepository();
            ProfileCard profile = new ProfileCard();
            profile = profileRepos.GetByListProfileCardFromNomenclature(name);
            int color = Convert.ToInt32(profile.ColorAnod);
            int thicknessCoating = Convert.ToInt32(profile.ThicknessCoating);
            double Area = lenght * profile.OuterPerimeter * count/1000000;
            int hour = 0;
            if (color != 0 )
            {
                hour = Convert.ToInt32((Area * 30) / 45);
            }
            else if (color == 0 && thicknessCoating == 20)
            {
                hour = Convert.ToInt32((Area * 30) / 45); 
            }
            else if (color == 0 && thicknessCoating==15)
            {
                hour = Convert.ToInt32((Area * 28) / 62);
            }
            else if (color == 0 && thicknessCoating == 12)
            {
                hour = Convert.ToInt32((Area * 26) / 67);
            }
            else if (color == 0 && thicknessCoating == 5)
            {
                hour = Convert.ToInt32((Area * 14) / 75);
            }
            else if (color == 0 && thicknessCoating == 10)
            {
                hour = Convert.ToInt32((Area * 26) / 66);
            }
            return hour;
        }
        
        }
    }
