using EloksalPro.Models;
using EloksalPro.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EloksalPro.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        public ViewModelBase CurrentChildView
        {
            get { return _currentChildView; }
            set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); }
        }
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; OnPropertyChanged(nameof(Caption)); }
        }
        public IconChar Icon
        {
            get { return _icon; }
            set { _icon = value; OnPropertyChanged(nameof(Icon)); }
        }
        public ICommand ShowReferenceViewCommand { get; }
        public ICommand ShowCommercialDepartmentViewCommand { get; }
        public ICommand ShowProductionViewCommand { get; }
        public ICommand ShowEmployeeViewCommand { get; }
        public ICommand ShowLaboratoryViewCommand { get; }
        public ICommand ShowStorehouseViewCommand { get; }
        public ICommand ShowReportsViewCommand { get; }
        public ICommand ShowTechnicalSupportViewCommand { get; }
        public  MainViewModel()
        {
            ShowReferenceViewCommand = new ViewModelCommand(ReferenceViewCommand);
            ShowCommercialDepartmentViewCommand= new ViewModelCommand(CommercialDepartmentViewCommand);
            ShowProductionViewCommand= new ViewModelCommand(ProductionViewCommand);
            ShowEmployeeViewCommand= new ViewModelCommand(EmployeeViewCommand);
            ShowLaboratoryViewCommand = new ViewModelCommand(LaboratoryViewCommand);
            ShowStorehouseViewCommand = new ViewModelCommand(StorehouseViewCommand);
            ShowReportsViewCommand=new ViewModelCommand(ReportsViewCommand);
            ShowTechnicalSupportViewCommand= new ViewModelCommand(TechnicalSupportViewCommand);
            ExecuteShowHomeViewCommand(null);
            LoadCurrentUserData();
        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new DashboardViewModel();
            Caption = "Главная страница";
            Icon = IconChar.Home;
        }
        private void ReferenceViewCommand(object obj)
        {
            CurrentChildView = new ReferenceViewModel();
            Caption = "Справочник";
            Icon = IconChar.Book;
        }
        private void CommercialDepartmentViewCommand(object obj)
        {
            if (CurrentUserAccount.Role == 0 || CurrentUserAccount.Role == 1)
            {
                CurrentChildView = new CommercialDepartmentViewModel();
                Caption = "Коммерческий отдел";
                Icon = IconChar.BalanceScale;
            }
            else
            {
                MessageBox.Show("Доступ ограничен", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        private void ProductionViewCommand(object obj)
        {
            CurrentChildView = new ProductionProfileViewModel();
            Caption = "Производство";
            Icon = IconChar.Wpforms;
        }
        private void EmployeeViewCommand(object obj)
        {
            if (CurrentUserAccount.Role == 0)
            {
                CurrentChildView = new EmployeeViewModel();
                Caption = "Сотрудники";
                Icon = IconChar.Users;
            }
            else
            {
                MessageBox.Show("Для регистрации пользователя или изменения данных обратитесь по номеру +7(961)85-777-47", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
   
            }

        }
        private void LaboratoryViewCommand(object obj)
        {
            CurrentChildView = new LaboratoryAnalysisViewModel();
            Caption = "Лаборатория";
            Icon = IconChar.Glass;
        }
        private void StorehouseViewCommand(object obj)
        {
            CurrentChildView = new StorehouseViewModel();
            Caption = "Склад";
            Icon = IconChar.Table;
        }
        private void ReportsViewCommand(object obj)
        {
            CurrentChildView = new ReportsViewModel();
            Caption = "Отчеты";
            Icon = IconChar.BarChart;
        }
        private void TechnicalSupportViewCommand(object obj)
        {
            CurrentChildView = new TechnicalSupportViewModel();
            Caption = "Техническая поддержка";
            Icon = IconChar.Headphones;
        }
        private void LoadCurrentUserData()
        {
            UserRepository userRepo = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            UserModel userList = userRepo.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (userList != null)
            {
                {
                    CurrentUserAccount.Username = userList.Login;
                    CurrentUserAccount.DisplayName = userList.Name;
                    CurrentUserAccount.Role = userList.Role;
                    CurrentUserAccount.ProfilePicture = null;
                }
            }
            else
            {
                CurrentUserAccount.DisplayName = "User";
            }
        }
    }
}
       