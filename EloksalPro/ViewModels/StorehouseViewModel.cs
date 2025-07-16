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
    public class StorehouseViewModel : ViewModelBase
    {
        private List<ReceptionMaterials> _receptionMaterials;
        private int _idReception;
        private int _idConsumptionWarehouse;
        public string _basketNumber;
        public int IdConsumptionWarehouse
        {
            get { return _idConsumptionWarehouse; }
            set { _idConsumptionWarehouse = value; OnPropertyChanged(nameof(IdConsumptionWarehouse)); }
        }
        public string BasketNumber
        {
            get { return _basketNumber; }
            set { _basketNumber = value; OnPropertyChanged(nameof(BasketNumber)); }
        }
        public List<ReceptionMaterials> ReceptionMaterials
        {
            get { return _receptionMaterials; }
            set { _receptionMaterials = value; OnPropertyChanged(nameof(ReceptionMaterials)); }
        }
        private List<ProfileConsumptionWarehouseGeneral> _profileConsumptionWarehouseGeneral;
        public List<ProfileConsumptionWarehouseGeneral> ProfileConsumptionWarehouseGeneral
        {
            get { return _profileConsumptionWarehouseGeneral; }
            set { _profileConsumptionWarehouseGeneral = value; OnPropertyChanged(nameof(ProfileConsumptionWarehouseGeneral)); }
        }
        public List<PackingAluminumProfileSummaryTable> _packingAluminumProfileSummaryTable = new List<PackingAluminumProfileSummaryTable>();
        public List<PackingAluminumProfileSummaryTable> PackingAluminumProfileSummaryTable
        {
            get { return _packingAluminumProfileSummaryTable; }
            set { _packingAluminumProfileSummaryTable = value; OnPropertyChanged(nameof(PackingAluminumProfileSummaryTable)); }
        }
        public int IdReception
        {
            get { return _idReception; }
            set { _idReception = value; OnPropertyChanged(nameof(IdReception)); }
        }
        public ICommand ShowCardReceptionDetailsCommand { get; }
        public ICommand RefreshAllProfileCommand { get; }
        public ICommand ShowNewConsumptionWarehouseProfileCommand { get; }
        public ICommand ShowNewShipmentByPalletsProfileCommand { get; }
        public ICommand ShowConsumptionWarehouseProfileCommand { get; }
        public ICommand ShowPrintProfileCommand { get; }
        public ICommand RemoveCommand { get; }
        public StorehouseViewModel()
        {

            ReceptionMaterialsRepository reposReception = new ReceptionMaterialsRepository();
            ReceptionMaterials = reposReception.GetByAllEntity();
            ShowCardReceptionDetailsCommand = new ViewModelCommand(CardReceptionDetailsCommand);
            RefreshAllProfileCommand = new ViewModelCommand(RefreshAllData);
            ShowNewConsumptionWarehouseProfileCommand = new ViewModelCommand(NewConsumptionWarehouseAluminumCommand);
            ShowConsumptionWarehouseProfileCommand = new ViewModelCommand(ConsumptionWarehouseAluminumCommand);
            ProfileConsumptionWarehouseGeneralRepository reposProfileConsumptionWarehouseGeneralRepository = new ProfileConsumptionWarehouseGeneralRepository();
            ProfileConsumptionWarehouseGeneral = reposProfileConsumptionWarehouseGeneralRepository.GetByAllEntity();
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
            PackingAluminumProfileSummaryTable = reposPacking.GetPackingAluminumProfileSummaryTable();
            ShowNewShipmentByPalletsProfileCommand = new ViewModelCommand(NewShipmentByPalletsProfile);
            ShowPrintProfileCommand = new ViewModelCommand(PrintLabelProfile);
            RemoveCommand = new ViewModelCommand(DeleteDataProfileConsumptionWarehouse);
        }
        void CardReceptionDetailsCommand(object obj)
        {
            DetailReceptionMaterialsView detail = new DetailReceptionMaterialsView();
            detail.Show();
            ReceptionMaterialsRepository reposReception = new ReceptionMaterialsRepository();
            ReceptionMaterials reception = new ReceptionMaterials();
            reception = reposReception.GetByEntity(Convert.ToInt32(IdReception));
            if (reception != null)
            {
                detail.txtNumSpecification.Text = reception.NumberSpecification;
                detail.txtId.Text = Convert.ToString(reception.Id);
                detail.txtFullName.Text = reception.FullName;
                detail.txtDateReception.Text = Convert.ToString(reception.DateReception);
                detail.txtWorkingShift.Text = reception.WorkingShift;
                detail.txtAnnotation.Text = reception.Annotation;
            }
        }
        void RefreshAllData(object obj)
        {
            RefreshAllData();
        }
        void RefreshAllData()
        {
            ReceptionMaterialsRepository reposReception = new ReceptionMaterialsRepository();
            ReceptionMaterials = reposReception.GetByAllEntity();
            ProfileConsumptionWarehouseGeneralRepository reposProfileConsumptionWarehouseGeneralRepository = new ProfileConsumptionWarehouseGeneralRepository();
            ProfileConsumptionWarehouseGeneral = reposProfileConsumptionWarehouseGeneralRepository.GetByAllEntity();
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
            PackingAluminumProfileSummaryTable = reposPacking.GetPackingAluminumProfileSummaryTable();
        }
        void NewConsumptionWarehouseAluminumCommand(object obj)
        {
            ProfileConsumptionWarehouseView consumptionWarehouse = new ProfileConsumptionWarehouseView();
            consumptionWarehouse.Show();
        }
        void NewShipmentByPalletsProfile(object obj)
        {
            ShipmentByPalletsView shipmentByPalletsProfile = new ShipmentByPalletsView();
            shipmentByPalletsProfile.Show();
        }
        void ConsumptionWarehouseAluminumCommand(object obj)
        {
            ProfileConsumptionWarehouseView consumptionWarehouse = new ProfileConsumptionWarehouseView();
            consumptionWarehouse.Show();
            ProfileConsumptionWarehouseGeneralRepository repos = new ProfileConsumptionWarehouseGeneralRepository();
            var list = repos.GetByEntity(IdConsumptionWarehouse);
            if (list != null)
            {
                consumptionWarehouse.txtNumber.Text = list.NumberProfileConsumptionWarehouse;
                consumptionWarehouse.txtDate.Text = list.Date.ToString();
                consumptionWarehouse.txtShift.Text = list.Shift;
                consumptionWarehouse.txtClientName.Text = list.ClientName;
            }
        }
        void PrintLabelProfile(object obj)
        {
            try
            {
                PackingAluminumProfileRepository repos = new PackingAluminumProfileRepository();
                PackingAluminumProfile packingAluminumProfile = new PackingAluminumProfile();
                packingAluminumProfile = repos.GetByEntityForBasket(BasketNumber);
                WindowReportsShift labelWindow = new WindowReportsShift();
                labelWindow.Show();
                labelWindow.PrintLabelProfile(packingAluminumProfile);
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке данных!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        void DeleteDataProfileConsumptionWarehouse(object obj)
        {
            if (MessageBox.Show("Вы действительно хотите удалить строку с данными",
                       "",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ProfileConsumptionWarehouseGeneralRepository repos = new ProfileConsumptionWarehouseGeneralRepository();
                var list = repos.GetByEntity(IdConsumptionWarehouse);
                if (list != null)
                {
                    ProfileConsumptionWarehouseRepository reposProfileConsumption = new ProfileConsumptionWarehouseRepository();
                    List<ProfileConsumptionWarehouse> listProfileConsumptionWarehouse = reposProfileConsumption.GetListAllEntity(list.NumberProfileConsumptionWarehouse);


                    foreach (var item in listProfileConsumptionWarehouse)
                    {
                        reposProfileConsumption.Remove(item.Id);
                    }
                    repos.Remove(IdConsumptionWarehouse);
                }
                MessageBox.Show("Данные удалены");
                RefreshAllData();
            }
        }
    }
}
