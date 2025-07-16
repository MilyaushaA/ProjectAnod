using EloksalPro.Models;
using EloksalPro.Repositories;
using EloksalPro.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EloksalPro.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        DateTime _date;
        bool _choiceDay;
        bool _choiceNight;
        private string _clientName;
        private List<string> _numberSpecification;
        private string _numberSpecificationSource;
        List<string> _productionSectorList = new List<string>() {"Дробейструйная обработка,Анодирование", "Наклеивание защитной пленки",
                                                                "Распил\\Торцовка","Упаковка алюминиевого профиля","Отгрузка профиля" };
        string _productionSectorSource;
        ShotBlastingProfileRepository reposShot;
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; OnPropertyChanged(nameof(ClientName)); }
        }
        public List<string> NumberSpecification
        {
            get { return _numberSpecification; }
            set { _numberSpecification = value; OnPropertyChanged(nameof(NumberSpecification)); }
        }
        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value; UpdateClientName(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
        public bool ChoiceDay
        {
            get { return _choiceDay; }
            set { _choiceDay = value; OnPropertyChanged(nameof(ChoiceDay)); }
        }
        public bool ChoiceNight
        {
            get { return _choiceNight; }
            set { _choiceNight = value; OnPropertyChanged(nameof(ChoiceNight)); }
        }
        public List<string> ProductionSectorList
        {
            get { return _productionSectorList; }
            set { _productionSectorList = value; OnPropertyChanged(nameof(ProductionSectorList)); }
        }
        public string ProductionSectorSource
        {
            get { return _productionSectorSource; }
            set { _productionSectorSource = value; OnPropertyChanged(nameof(ProductionSectorSource)); }
        }
        public ICommand ShowPrintReportsCommand { get; }
        public ICommand ShowPrintReportsClientCommand { get; }
        public ReportsViewModel()
        {
            DetailReceptionMaterialsRepository repos = new DetailReceptionMaterialsRepository();
            NumberSpecification = repos.GetNumberSpecificationClient();
            ShowPrintReportsCommand = new ViewModelCommand(PrintReportsCommand);
            ShowPrintReportsClientCommand = new ViewModelCommand(PrintReportsClientCommand);
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
        void PrintReportsCommand(object obj)
        {
            try
            {

                WindowReportsShift reportView = new WindowReportsShift();
                reportView.Show();

                if (ProductionSectorSource == "Дробейструйная обработка,Анодирование")
                {
                    ShotBlastingProfileRepository reposShot = new ShotBlastingProfileRepository();
                    ShotBlastingProfilesGeneralsRepository reposShotGeneral = new ShotBlastingProfilesGeneralsRepository();
                    int minShotDay = reposShotGeneral.GetDowntime(Convert.ToDateTime(Date), "08:00-20:00");
                    int minShotNight = reposShotGeneral.GetDowntime(Convert.ToDateTime(Date), "20:00-08:00");
                    AnodizingProcessProfileRepository reposAnod = new AnodizingProcessProfileRepository();
                    AnodizingProcessProfileGeneralRepository reposAnodGeneral = new AnodizingProcessProfileGeneralRepository();
                    int minAnodDay = reposAnodGeneral.GetDowntime(Convert.ToDateTime(Date), "08:00-20:00");
                    int minAnodNight = reposAnodGeneral.GetDowntime(Convert.ToDateTime(Date), "20:00-08:00");
                    List<ShotBlastingProfileReport> listShot = new List<ShotBlastingProfileReport>();
                    List<AnodizingProcessProfileReport> listAnod = new List<AnodizingProcessProfileReport>();
                    if (ChoiceDay == true)
                    {
                        listShot = reposShot.GetShotBlastingProfileReport(Convert.ToDateTime(Date), "08:00-20:00");
                        listAnod = reposAnod.GetAnodizingProcessProfileReport(Convert.ToDateTime(Date), "08:00-20:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "День", listShot, listAnod, minAnodDay, minShotDay);
                    }
                    else if (ChoiceNight == true)
                    {
                        listShot = reposShot.GetShotBlastingProfileReport(Convert.ToDateTime(Date), "20:00-08:00");
                        listAnod = reposAnod.GetAnodizingProcessProfileReport(Convert.ToDateTime(Date), "20:00-08:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "Ночь", listShot, listAnod, minAnodNight, minShotNight);
                    }
                }
                if (ProductionSectorSource == "Наклеивание защитной пленки")
                {
                    TapeProtectiveProcessProfileRepository reposTape = new TapeProtectiveProcessProfileRepository();
                    List<TapeProtectiveProcessProfileReport> listTape = new List<TapeProtectiveProcessProfileReport>();
                    if (ChoiceDay == true)
                    {
                        listTape = reposTape.GetTapeProtectiveProcessProfileReport(Convert.ToDateTime(Date), "08:00-20:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "День", listTape);
                    }
                    else if (ChoiceNight == true)
                    {
                        listTape = reposTape.GetTapeProtectiveProcessProfileReport(Convert.ToDateTime(Date), "20:00-08:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "Ночь", listTape);
                    }
                }
                if (ProductionSectorSource == "Распил\\Торцовка")
                {
                    СuttingFacingProfileRepository reposCutting = new СuttingFacingProfileRepository();
                    List<СuttingFacingProfileReport> listCutting = new List<СuttingFacingProfileReport>();
                    if (ChoiceDay == true)
                    {
                        listCutting = reposCutting.GetСuttingFacingProfileReport(Convert.ToDateTime(Date), "08:00-20:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "День", listCutting, LoadCurrentUserData());
                    }
                    else if (ChoiceNight == true)
                    {
                        listCutting = reposCutting.GetСuttingFacingProfileReport(Convert.ToDateTime(Date), "20:00-08:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "Ночь", listCutting, LoadCurrentUserData());
                    }
                }
                if (ProductionSectorSource == "Упаковка алюминиевого профиля")
                {
                    PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
                    List<PackingAluminumProfileReport> listPacking = new List<PackingAluminumProfileReport>();
                    if (ChoiceDay == true)
                    {
                        listPacking = reposPacking.GetPackingAluminumProfileReport(Convert.ToDateTime(Date), "08:00-20:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "День", listPacking);
                    }
                    else if (ChoiceNight == true)
                    {
                        listPacking = reposPacking.GetPackingAluminumProfileReport(Convert.ToDateTime(Date), "20:00-08:00");
                        reportView.PrintInvoice(Date.ToString("yyyy-MM-dd"), "Ночь", listPacking);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        void PrintReportsClientCommand(object obj)
        {
            List<ShotBlastingProfile> listShot = new List<ShotBlastingProfile>();
            List<AnodizingProcessProfile> listAnod = new List<AnodizingProcessProfile>();
            reposShot = new ShotBlastingProfileRepository();
            AnodizingProcessProfileRepository reposAnod = new AnodizingProcessProfileRepository();
            listShot = reposShot.GetNumberSpecificationAndClient(NumberSpecificationSource, ClientName);
            listAnod = reposAnod.GetNumberSpecificationAndClient(NumberSpecificationSource, ClientName);
            try
            {

                WindowReportsShift reportView = new WindowReportsShift();
            reportView.Show();
            reportView.PrintListNumberAndClient(NumberSpecificationSource, ClientName, listShot, listAnod);

            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public void UpdateClientName()
        {
            DetailReceptionMaterialsRepository repos = new DetailReceptionMaterialsRepository();
            _clientName = repos.GetClient(NumberSpecificationSource);
            OnPropertyChanged(nameof(ClientName));
        }
    }
}
