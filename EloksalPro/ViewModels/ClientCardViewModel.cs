using EloksalPro.EfStructures;
using EloksalPro.Models;
using EloksalPro.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Timers;
using Microsoft.Win32;
using System.IO;

namespace EloksalPro.ViewModels
{
  public class ClientCardViewModel:ViewModelBase
    {
        private ClientCard _clientCard = new ClientCard();
        private string _noProfile;
        private int _idClient;
       
        private ObservableCollection<string> _listCommercialNoProfile;
        public ClientCard ClientCard
        {
            get { return _clientCard; }
            set { _clientCard = value; OnPropertyChanged(nameof(ClientCard)); }
        }   
        public string NoProfile
        {
            get { return _noProfile; }

            set {_noProfile = value; OnPropertyChanged(nameof(NoProfile)); }
        }
        public int IdClient
        {
            get { return _idClient; }
            set { _idClient = value; OnPropertyChanged(nameof(IdClient)); }
        }
        public ObservableCollection<string> ListCommercialNoProfile
        {
            get { return _listCommercialNoProfile; }
            set { _listCommercialNoProfile = value; OnPropertyChanged(nameof(ListCommercialNoProfile)); }
        }   
        public ICommand SaveInsertCommand { get; }
        public ICommand SaveInsertNewProfilaCommand { get; }
       
        public ClientCardViewModel()
        {
            ProfileCardComercialRepository repos = new ProfileCardComercialRepository();
            SaveInsertCommand = new ViewModelCommand(ChoiceInsertOrUpdate);
            SaveInsertNewProfilaCommand = new ViewModelCommand(InsertNewProfileCardClient);
            ListCommercialNoProfile = repos.ListCommercialNoProfile(IdClient);
            AddTimer();
            
        }
        public void InsertNewProfileCardClient(object obj)
        {
            int maxIdClient;
            if (IdClient == 0)
            {
                ClientCardRepository reposClient = new ClientCardRepository();
                maxIdClient = reposClient.GetById()+1;
            }
           else
            {
                maxIdClient = IdClient;
            }
            ProfileCardComercialRepository repos = new ProfileCardComercialRepository();
            ProfileCardComercial profileClientCard = new ProfileCardComercial();
            int maxId = repos.GetById();
            List<string> nomenclatureProfile = new List<string>();
            nomenclatureProfile = repos.GetByExaminationNomenclature(maxIdClient);

            if (nomenclatureProfile.Contains(NoProfile.Trim())) { MessageBox.Show($"{NoProfile}   уже есть в базе профилей клиента", "Message", MessageBoxButton.OK, MessageBoxImage.Information); }
            else if (NoProfile.Trim() == String.Empty) { MessageBox.Show("Строка не может быть пустой"); }
            else
            {
                profileClientCard.Id = ++maxId;
                profileClientCard.EloksalNoCommercial = NoProfile;
                profileClientCard.ClientId = maxIdClient;
                repos.Add(profileClientCard);
                ListCommercialNoProfile.Add(NoProfile);
            }

        }
        public void InsertNewClient()
        {
            ClientCardRepository repos = new ClientCardRepository();
            ClientCard clientCard = new ClientCard();
            int maxId = repos.GetById();
            List<string> nomenclatureClient = new List<string>();
            nomenclatureClient = repos.GetByExaminationNomenclature();
            if (nomenclatureClient.Contains(ClientCard.ClientName)) MessageBox.Show($"{ClientCard.ClientName}   уже есть в базе клиентов", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                clientCard.Id = ++maxId;
                clientCard.ClientName = ClientCard.ClientName;
                clientCard.ContractNumber = ClientCard.ContractNumber;
                clientCard.ContactNumberPhoneAnother = ClientCard.ContactNumberPhoneAnother;
                clientCard.DateContract = ClientCard.DateContract;
                clientCard.PhysicalAddress = ClientCard.PhysicalAddress;
                clientCard.ContactPerson = ClientCard.ContactPerson;
                clientCard.ContactNumberPhone = ClientCard.ContactNumberPhone;
                clientCard.ContactEmail = ClientCard.ContactEmail;
                clientCard.Manager = ClientCard.Manager;
                repos.Add(clientCard);
                MessageBox.Show("Данные сохранены");
            }     
        }
        public void UpdateClientCard()
        {
            ClientCardRepository repos = new ClientCardRepository();
            repos.ClientCardUpdate(IdClient, ClientCard.ContractNumber, ClientCard.ClientName, ClientCard.DateContract, ClientCard.PhysicalAddress, ClientCard.ContactPerson,
                                    ClientCard.ContactNumberPhone, ClientCard.ContactEmail,ClientCard.Manager);
        }
        public void AddTimer()
        {
            Timer timer = new Timer();
            timer.Elapsed += RefreshProductionOperation;
            timer.Interval = 2000;
            timer.AutoReset = false;
            timer.Start();
        }
        public void RefreshProductionOperation(object sender, ElapsedEventArgs e)
        {
            ProfileCardComercialRepository repos = new ProfileCardComercialRepository();
            ListCommercialNoProfile = repos.ListCommercialNoProfile(IdClient);
        }
        void ChoiceInsertOrUpdate(object obj)
        {
            if (IdClient == 0) InsertNewClient();
            else UpdateClientCard();
        }
      
    }
}
