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
{
    public class ExtensiveReceptionViewModel : ViewModelBase
    {
        ExtensiveReceptionProfile _extensive = new ExtensiveReceptionProfile();
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        private double _weightProducedProfile;
        private double _generalAreaProfile;
        public int _quantityProducedProfile;
        public double _outerPerimetr;
        public int _id;
        ObservableCollection<ExtensiveReceptionProfile> _listExtensive = new ObservableCollection<ExtensiveReceptionProfile>();
        public ObservableCollection<ExtensiveReceptionProfile> ListExtensive
        {
            get { return _listExtensive; }
            set { _listExtensive = value; OnPropertyChanged(nameof(ListExtensive)); }
        }
        public ExtensiveReceptionProfile Extensive
        {
            get { return _extensive; }
            set { _extensive = value; OnPropertyChanged(nameof(Extensive)); }
        }
        private List<string> _nomenclatureProfileList = new List<string>();
        public List<string> NomenclatureProfileList
        {
            get { return _nomenclatureProfileList; }
            set { _nomenclatureProfileList = value; OnPropertyChanged(nameof(NomenclatureProfileList)); }
        }
        public double WeightProducedProfile
        {
            get { return _weightProducedProfile; }
            set { _weightProducedProfile = value; OnPropertyChanged(nameof(WeightProducedProfile)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public double GeneralAreaProfile
        {
            get { return _generalAreaProfile; }
            set { _generalAreaProfile = value; OnPropertyChanged(nameof(GeneralAreaProfile)); }
        }
        public double OuterPerimetr
        {
            get { return _outerPerimetr; }
            set { _outerPerimetr = value; OnPropertyChanged(nameof(OuterPerimetr)); }
        }
        public int QuantityProducedProfile
        {
            get { return _quantityProducedProfile; }
            set { _quantityProducedProfile = value; GetGeneralWeight(); OnPropertyChanged(nameof(QuantityProducedProfile)); }
        }
        public ICommand SaveInsertExtensiveCommand { get; }
        public ICommand ShowRemoveCommand { get; }
        public ICommand ShowAddCommand { get; }
        public ICommand ShowPrintCommand { get; }
        public ExtensiveReceptionViewModel()
        {

            SaveInsertExtensiveCommand = new ViewModelCommand(SaveAddDataReception);
            ShowRemoveCommand = new ViewModelCommand(RemoveCommand);
            //ShowAddCommand = new ViewModelCommand(AddDateCommand);
            AddTimerExtensive();
            ShowPrintCommand = new ViewModelCommand(PrintExtensiveReceptionProfile);
        }
        public void AddTimerExtensive()
        {
            Timer timer = new Timer();
            timer.Elapsed += RefreshExtensive;
            timer.Interval = 2000;
            timer.AutoReset = false;
            timer.Start();
        }
        public void RefreshExtensive(object sender, ElapsedEventArgs e)
        {
            ExtensiveReceptionProfileRepository repos = new ExtensiveReceptionProfileRepository();
            ListExtensive = repos.GetByAllEntityObservableCollection(Extensive.NumberSpecification);
        }
        public void RefreshExtensive()
        {
            ExtensiveReceptionProfileRepository repos = new ExtensiveReceptionProfileRepository();
            ListExtensive = repos.GetByAllEntityObservableCollection(Extensive.NumberSpecification);
        }

        void GetGeneralWeight()
        {
            _weightProducedProfile = Math.Round(QuantityProducedProfile * Extensive.WeightMeter * Extensive.LenghtProfile / 1000, 2);
            OnPropertyChanged(nameof(WeightProducedProfile));
            _generalAreaProfile = Math.Round(QuantityProducedProfile * OuterPerimetr / 1000 * Extensive.LenghtProfile / 1000, 2);
            OnPropertyChanged(nameof(GeneralAreaProfile));
        }
        void SaveAddDataReception(object obj)
        {
            if (Extensive.Date == DateTime.MinValue)
            {
                Extensive.Date = DateTime.Now;
            }
            ExtensiveReceptionProfileRepository repos = new ExtensiveReceptionProfileRepository();
            ExtensiveReceptionProfile extensive = new ExtensiveReceptionProfile();
            int maxId = repos.GetById();
            extensive.Id = ++maxId;
            extensive.BasketNumber = Extensive.BasketNumber;
            extensive.Date = Extensive.Date;
            extensive.ClientName = Extensive.ClientName;
            extensive.NomenclatureProfile = Extensive.NomenclatureProfile;
            extensive.NumberSpecification = Extensive.NumberSpecification;
            extensive.EloksalNoCommercial = Extensive.EloksalNoCommercial;
            extensive.WeightMeter = Extensive.WeightMeter;
            extensive.LenghtProfile = Extensive.LenghtProfile;
            extensive.QuantityProducedProfile = QuantityProducedProfile;
            extensive.WeightProducedProfile = WeightProducedProfile;
            ListExtensive.Add(extensive);
            repos.Add(extensive);
        }
        public void RemoveCommand(object obj)
        {
            ExtensiveReceptionProfileRepository repos = new ExtensiveReceptionProfileRepository();
            repos.Remove(Id);
            RefreshExtensive();
        }
        void PrintExtensiveReceptionProfile(object obj)
        {
            ObservableCollection<ExtensiveReceptionProfile> list = new ObservableCollection<ExtensiveReceptionProfile>();
            ExtensiveReceptionProfileRepository repos = new ExtensiveReceptionProfileRepository();
            list = repos.GetByAllEntityObservableCollection(Extensive.NumberSpecification, Extensive.Date);
            //list = repos.GetByAllEntityCommercialOfferList(NumberOffer);
            string userName = LoadCurrentUserData();
            WindowReportsShift receptionWindow = new WindowReportsShift();
            receptionWindow.Show();
            receptionWindow.PrintExtensiveReceptionProfile(list,Extensive.Date, userName);
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
        //public void AddDateCommand(object obj)
        //{
        //    var newRow = new ExtensiveReceptionProfile(); // Создайте экземпляр вашего типа данных
        //    newRow.NumberSpecification= DateTime.Now.ToString(); // Замените DateProperty на ваше свойство для даты
        //                                                          // Добавьте другие поля, которые должны быть заполнены, если необходимо

        //    // Добавление новой строки в конец
        //    ListExtensive.Add(newRow);

        //}
    }
}