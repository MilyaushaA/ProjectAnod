using EloksalPro.Models;
using EloksalPro.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EloksalPro.ViewModels
{
  public  class ProfilePropertyViewModel: ViewModelBase
    {
        private List<string> _propertiesList = new List<string> { "Длина профиля", "Вид покрытия", "Цвет покрытия", "Толщина покрытия", "КТолщина покрытия" };
        private List<ProfileProperty> _profileProperty;
        private string _propertiesSource;
        private string _valuePropertyProfile;

        public List<string> PropertiesList
        {
            get { return _propertiesList; }
            set { _propertiesList = value; OnPropertyChanged("PropertiesList"); }
        }
        public List<ProfileProperty> ProfileProperty
        {
            get { return _profileProperty; }
            set { _profileProperty = value; OnPropertyChanged("ProfileProperty"); }
        }

        public string PropertiesSource
        {
            get { return _propertiesSource; }
            set { _propertiesSource = value;  OnPropertyChanged("PropertiesSource"); }
        }
        public string ValuePropertyProfile
        {
            get { return _valuePropertyProfile; }
            set { _valuePropertyProfile = value; OnPropertyChanged("ValuePropertyProfile"); }
        }
        public ICommand SaveInsertCommand { get; }
        public ProfilePropertyViewModel()
        {
            ProfilePropertyRepository propertyRepos = new ProfilePropertyRepository();
            SaveInsertCommand = new ViewModelCommand(InsertNewPropertiesProfile);
            ProfileProperty = propertyRepos.GetByAllEntity();
        }
        public void InsertNewPropertiesProfile(object obj)
        {
            ProfilePropertyRepository repos = new ProfilePropertyRepository();
            ProfileProperty profile = new ProfileProperty();
            int maxId = repos.GetById();
            List<string> valuePropertyProfile = new List<string>();
            valuePropertyProfile = repos.GetByExaminationPropertyProfile();
            if (valuePropertyProfile.Contains(PropertiesSource+":"+ValuePropertyProfile)) MessageBox.Show($"{PropertiesSource}:{ValuePropertyProfile}  уже есть в базе свойств профиля", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                try
            {
                profile.Id = ++maxId;
                profile.PropertyProfile = PropertiesSource;
                profile.ValuePropertyProfile = ValuePropertyProfile;
                repos.Add(profile);
                MessageBox.Show("Данные успешно сохранены");
                RefreshProperty();
            }

            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат данных");
            }
        }
        void RefreshProperty()
        {
            ProfilePropertyRepository propertyRepos = new ProfilePropertyRepository();
            ProfileProperty = propertyRepos.GetByAllEntity();
        }
    }
}
