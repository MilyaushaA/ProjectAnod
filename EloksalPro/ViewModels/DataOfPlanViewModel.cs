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
    public class DataOfPlanViewModel : ViewModelBase
    {
        private List<string> _numberSpecificationList; // номер заказа
        private string _numberSpecificationSource; // 
        private string _nameClient;
        private double? _generalWeight;
        private DateTime? _datePlan;
        private int _productivity;


        public List<string> NumberSpecificationList
        {
            get { return _numberSpecificationList; }
            set { _numberSpecificationList = value; OnPropertyChanged(nameof(NumberSpecificationList)); }
        }
        public string NumberSpecificationSource
        {
            get { return _numberSpecificationSource; }
            set { _numberSpecificationSource = value; GetEntitySpecificationEloksalProfile(); OnPropertyChanged(nameof(NumberSpecificationSource)); }
        }
        public DateTime? DatePlan
        {
            get { return _datePlan; }
            set { _datePlan = value; OnPropertyChanged(nameof(DatePlan)); }
        }
        public string NameClient
        {
            get { return _nameClient; }
            set { _nameClient = value; OnPropertyChanged(nameof(NameClient)); }
        }
        public double? GeneralWeight
        {
            get { return _generalWeight; }
            set { _generalWeight = value; OnPropertyChanged(nameof(GeneralWeight)); }
        }
        public int Productivity
        {
            get { return _productivity; }
            set { _productivity = value; OnPropertyChanged(nameof(Productivity)); }
        }
        public ICommand SaveInsertCommand { get; }
        public DataOfPlanViewModel()
        {
            SpecificationEloksalProfileRepository reposSpecificationEloksal = new SpecificationEloksalProfileRepository();
            NumberSpecificationList = reposSpecificationEloksal.GetListNumberSpecification();
            SaveInsertCommand = new ViewModelCommand(SaveUpdateDatePlan);
        }
        void SaveUpdateDatePlan(object obj)
        {
            SaveUpdateDatePlanTwo();
            SpecificationEloksalProfileRepository reposSpecificationEloksal = new SpecificationEloksalProfileRepository();
            reposSpecificationEloksal.UpdateDataPlanSpecification(NumberSpecificationSource, DatePlan, GeneralWeight);
        }
        void SaveUpdateSpecificationDatePlan()
        {
            SpecificationEloksalProfileRepository reposSpecificationEloksal = new SpecificationEloksalProfileRepository();
            reposSpecificationEloksal.UpdateDataPlanSpecification(NumberSpecificationSource, DatePlan, GeneralWeight);
            NumberSpecificationList = reposSpecificationEloksal.GetListNumberSpecification();
            NumberSpecificationSource = null;
            NameClient = null;
            GeneralWeight = null;
        }
        void SaveUpdateDatePlanTwo()
        {
            DataofPlanRepository repos = new DataofPlanRepository();
            List<DataPlanProfile> list = repos.GetByAllEntity();
            List<DateTime?> listDate = list.Select(p => p.DatePlan).ToList();

            DataPlanProfile plan = new DataPlanProfile();

            double? weight = repos.GetWeight(DatePlan);

            if (DatePlan == DateTime.MinValue || DatePlan == null || NumberSpecificationSource == null || Productivity == 0)
            {
                MessageBox.Show("Внесите все данные!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (listDate.Contains(DatePlan) && Productivity - weight <= 0)
            {
                MessageBox.Show("На данную дату производство загружено полностью, выберите другую дату!", "Message", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else if (Productivity - weight > 0 && Productivity - weight > GeneralWeight)
            {
                int maxId = repos.GetById();
                plan.Id = ++maxId;
                plan.ClientName = NameClient;
                plan.NumberSpecification = NumberSpecificationSource;
                plan.DatePlan = DatePlan;
                plan.GeneralWeight = GeneralWeight;
                plan.AllGeneralWeight = GeneralWeight + Convert.ToDouble(weight);
                repos.Add(plan);
                SaveUpdateSpecificationDatePlan();
                MessageBox.Show("Данные добавлены");

            }
            else if (/*listDate.Contains(DatePlan) && */Productivity - weight > 0 && (Productivity - weight) < GeneralWeight)
            {
                double weightStart = Convert.ToDouble(GeneralWeight);
                DateTime date = Convert.ToDateTime(DatePlan);
                int maxId = repos.GetById();
                while ((Productivity - weight) < weightStart)
                {
                    DataPlanProfile planDate = new DataPlanProfile();
                    planDate.Id = ++maxId;
                    planDate.ClientName = NameClient;
                    planDate.NumberSpecification = NumberSpecificationSource;
                    planDate.DatePlan = date;
                    planDate.GeneralWeight = Productivity - weight;
                    planDate.AllGeneralWeight = (Productivity - weight) + Convert.ToDouble(weight);
                    repos.Add(planDate);
                    weightStart = Convert.ToDouble(weightStart - (Productivity - weight));
                    date = date.AddDays(1);
                    weight = repos.GetWeight(date);
                }
                DataPlanProfile planData = new DataPlanProfile();
                int maxIdd = repos.GetById();
                planData.Id = ++maxIdd;
                planData.ClientName = NameClient;
                planData.NumberSpecification = NumberSpecificationSource;
                planData.DatePlan = date;
                planData.GeneralWeight = weightStart;
                planData.AllGeneralWeight = weight + weightStart;
                repos.Add(planData);
                MessageBox.Show("Данные добавлены");
                SaveUpdateSpecificationDatePlan();
            } 
        }
 
        void GetEntitySpecificationEloksalProfile()
        {
            SpecificationEloksalProfileRepository reposSpecificationEloksal = new SpecificationEloksalProfileRepository();
            SpecificationAllDescriptionRepository repos = new SpecificationAllDescriptionRepository();
            SpecificationEloksalProfile entity = new SpecificationEloksalProfile();
            entity = reposSpecificationEloksal.GetSpecificationEloksalProfile(NumberSpecificationSource);
            if (entity != null)
            {
                _nameClient = entity.ClientName + " N:" + NumberSpecificationSource;
                OnPropertyChanged(nameof(NameClient));
                _generalWeight = repos.GetTotalWeight(NumberSpecificationSource);
                OnPropertyChanged(nameof(GeneralWeight));
            }
                
        }
    }

  }

