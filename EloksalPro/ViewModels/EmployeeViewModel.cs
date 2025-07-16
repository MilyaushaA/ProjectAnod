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
    public class EmployeeViewModel:ViewModelBase
    {
        private int _id;
        List<UserModel> _user = new List<UserModel>();
        private UserModel _userModel=new UserModel();
        public UserModel UserModel
        {
            get { return _userModel; }
            set { _userModel = value; OnPropertyChanged("UserModel"); }
        }
        public List<UserModel> UserList
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged("UserList"); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public ICommand ShowNewEmployeeCommand { get; }
        public ICommand ShowEmployeeCommand { get; }
        public ICommand ShowSaveEmployeeCommand { get; }
        public ICommand ShowRefreshEmployeeCommand { get; }
        public ICommand ShowCloseCardEmployeeCommand { get; }
        public EmployeeViewModel()
        {
            UserRepository repos = new UserRepository();
            ShowNewEmployeeCommand = new ViewModelCommand(NewEmployeeCommand);
            ShowEmployeeCommand = new ViewModelCommand(EmployeeCommand);
            ShowSaveEmployeeCommand= new ViewModelCommand(ChoiceInsertandUpdate);
            ShowRefreshEmployeeCommand = new ViewModelCommand(RefreshEmployeeList);
            ShowCloseCardEmployeeCommand = new ViewModelCommand(RefreshEmployeeList);
            UserList = repos.GetByAllEntity();
        }
        public void InsertNewEmployee()
        {
            UserRepository repos = new UserRepository();
            int maxId = repos.GetById();
            UserModel userModel = new UserModel();
            userModel.Id = ++maxId;
            userModel.Name = UserModel.Name;
            userModel.Login = UserModel.Login;
            userModel.Password = UserModel.Password;
            userModel.Department= UserModel.Department;
            userModel.Role = UserModel.Role;
            userModel.PhoneNumber = UserModel.PhoneNumber;
            userModel.Email = UserModel.Email;
            userModel.Annotation = UserModel.Annotation;
            repos.Add(userModel);
            MessageBox.Show("Данные сохранены");
        }
        void NewEmployeeCommand(object obj)
        {
            EmployeeCardView employee = new EmployeeCardView();
            employee.Show();
        }
        void EmployeeCommand(object obj)
        {
            EmployeeCardView employee = new EmployeeCardView();
            employee.Show();
            UserRepository repos = new UserRepository();
            var list = repos.GetByEntity(Id);
            if (list != null)
            {
                employee.txtId.Text = list.Id.ToString();
                employee.txtName.Text = list.Name;
                employee.txtLogin.Text = list.Login;
                employee.txtPassword.Text = list.Password;
                employee.txtDepartment.Text = list.Department;
                employee.txtPhoneNumber.Text = list.PhoneNumber;
                employee.txtEmail.Text = list.Email;
                employee.txtRole.Text = list.Role.ToString();
                employee.txtAnnotation.Text = list.Annotation;
            }
        }
        void RefreshEmployeeList(object obj)
        {
            UserRepository repos = new UserRepository();
            UserList = repos.GetByAllEntity();
        }
        void UpdateEmployee()
        {
            UserRepository repos = new UserRepository();
            repos.UpdateUserName(Id, UserModel.Name, UserModel.Department, UserModel.Role, UserModel.Login, UserModel.Password,UserModel.PhoneNumber,UserModel.Email,UserModel.Annotation);
            MessageBox.Show("Данные изменены");
        }
        void ChoiceInsertandUpdate(object obj)
        {
            if (Id == 0) InsertNewEmployee();
            else UpdateEmployee();
        }

    }
}
