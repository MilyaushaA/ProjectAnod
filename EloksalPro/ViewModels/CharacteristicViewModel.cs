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
    public class CharacteristicViewModel: ViewModelBase
    {
        private string _propertyProfileName;
        private string _propertyProfileMarking;
        private string _propertyProfileDescription;
        private int _id;

        public string PropertyProfileName
        {
            get { return _propertyProfileName; }
            set { _propertyProfileName = value;OnPropertyChanged(nameof(PropertyProfileName)); }
        }
        public string PropertyProfileMarking
        {
            get { return _propertyProfileMarking; }
            set { _propertyProfileMarking = value; OnPropertyChanged(nameof(PropertyProfileMarking)); }
        }
        public string PropertyProfileDescription
        {
            get { return _propertyProfileDescription; }
            set { _propertyProfileDescription = value; OnPropertyChanged(nameof(PropertyProfileDescription)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public ICommand SaveInsertCommand { get; }
        public CharacteristicViewModel()
        {
            SaveInsertCommand = new ViewModelCommand(ChoiceInsertandUpdate);
        }
        void SaveInsertNewProperties()
        {
           
            CharacteristicProfileRepository repos = new CharacteristicProfileRepository();
            int id = repos.GetById();
            СharacteristicProfile newProfileProperty = new СharacteristicProfile();
            newProfileProperty.Id = ++id;
            newProfileProperty.ProfilePropertyName= PropertyProfileName;
            newProfileProperty.ProfilePropertyMarking = PropertyProfileMarking;
            newProfileProperty.ProfilePropertyDescription= PropertyProfileDescription;
            repos.Add(newProfileProperty);
     
        }
      
        public void UpdatePropertiesProfile()
        {
            CharacteristicProfileRepository repos = new CharacteristicProfileRepository();
            repos.ProfilePropertiesUpdate(Id, PropertyProfileName, PropertyProfileMarking, PropertyProfileDescription);     
        }

        void ChoiceInsertandUpdate(object obj)
        {
            if (Id == 0) SaveInsertNewProperties();
            else UpdatePropertiesProfile();
        }
    }
}
