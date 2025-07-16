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
   public class TechnicalSupportViewModel:ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        TechnicalSupportRepository repos;
        TechnicalSupport _support = new TechnicalSupport();
        List<TechnicalSupport> _list = new List<TechnicalSupport>();
     
        int _id;
        int _idSupport;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public int IdSupport
        {
            get { return _idSupport; }
            set { _idSupport = value; OnPropertyChanged(nameof(IdSupport)); }
        }
        public List<TechnicalSupport> List
        {
            get { return _list; }
            set { _list = value; OnPropertyChanged("List"); }
        }
        public TechnicalSupport Support
        {
            get { return _support; }
            set { _support = value; OnPropertyChanged("Support"); }
        }
        public ICommand OpenNewTechnicalSupportCommand { get; }
        public ICommand OpenTechnicalSupportCommand { get; }
        public ICommand SaveDataCommand { get; }
        public ICommand RefreshDataCommand { get; }
        public TechnicalSupportViewModel()
        {
            repos = new TechnicalSupportRepository();
            List = repos.GetAllInventory();
            Support.Customer = LoadCurrentUserData();
            OpenNewTechnicalSupportCommand = new ViewModelCommand(ShowNewTechnicalSupportCommand);
            OpenTechnicalSupportCommand = new ViewModelCommand(ShowTechnicalSupportCommand);
            SaveDataCommand = new ViewModelCommand(ChoiceInsertOrUpdate);
            RefreshDataCommand = new ViewModelCommand(RefreshData);
        }
        void ShowNewTechnicalSupportCommand(object obj)
        {
            TechnicalSupportViewWindow support = new TechnicalSupportViewWindow();
            support.Show();
        }
        void ShowTechnicalSupportCommand(object obj)
        {
            TechnicalSupportViewWindow supportView = new TechnicalSupportViewWindow();
            supportView.Show();
            TechnicalSupport support = new TechnicalSupport();
            support = repos.GetByEntity(Convert.ToInt32(Id));
            if (support != null)
            {
                supportView.txtId.Text = support.Id.ToString();
                supportView.txtNumber.Text = support.Number;
                supportView.txtDateApp.Text = support.DateApp.ToString();
                supportView.txtDatePreliminaryReadiness.Text = support.DatePreliminaryReadiness.ToString();
                supportView.txtDateReadiness.Text = support.DateReadiness.ToString();
                supportView.txtCustomer.Text = support.Customer;
                supportView.txtApplicationText.Text = support.ApplicationText;
            }
        }
        void ChoiceInsertOrUpdate(object obj)
        {
            if (IdSupport == 0) InsertNewDataCommand();
            else UpdateData();
            MessageBox.Show("Данные сохранены");
        }
        void UpdateData()
        {
            repos.UpdateInventory(IdSupport, Support.DateApp, Support.DatePreliminaryReadiness, Support.DateReadiness, Support.ApplicationText, Support.Customer);
        }
        void InsertNewDataCommand()
        {
            TechnicalSupport support = new TechnicalSupport();
            int id = repos.GetById();
            int num = ++id;
            support.Id = ++id;
            support.Number = num.ToString("D4");
            support.DateApp = Support.DateApp;
            support.ApplicationText = Support.ApplicationText;
            support.DatePreliminaryReadiness = Support.DatePreliminaryReadiness;
            support.DateReadiness = Support.DateReadiness;
            support.Customer = Support.Customer;
            repos.Add(support);

        }
        void RefreshData(object obj)
        {
            repos = new TechnicalSupportRepository();
            List = repos.GetAllInventory();
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
    }
}

