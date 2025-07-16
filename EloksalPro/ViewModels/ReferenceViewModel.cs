using EloksalPro.Models;
using EloksalPro.Repositories;
using EloksalPro.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace EloksalPro.ViewModels
{
    public class ReferenceViewModel:ViewModelBase
    {
        private List<ProfileCard> _profileCard;
        private List<ClientCard> _clientCard;
        private string _eloksalId;
        private string _clientId;
        private List<СharacteristicProfile> _characteristicProfileType;
        private List<СharacteristicProfile> _characteristicProfileColor;
        private List<СharacteristicProfile> _characteristicProfileAdditional;
        public List<ProfileCard> ProfileCard
        {
            get { return _profileCard; }
            set { _profileCard = value; OnPropertyChanged(nameof(ProfileCard)); }
        }
        public List<ClientCard> ClientCard
        {
            get { return _clientCard; }
            set { _clientCard = value; OnPropertyChanged(nameof(ClientCard)); }
        }
        public string EloksalId
        {
            get { return _eloksalId; }
            set { _eloksalId = value; OnPropertyChanged(nameof(EloksalId)); }
        }
        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; OnPropertyChanged(nameof(ClientId)); }
        }
        public List<СharacteristicProfile> CharacteristicProfileType
        {
            get { return _characteristicProfileType; }
            set { _characteristicProfileType = value; OnPropertyChanged(nameof(CharacteristicProfileType)); }
        }
        public List<СharacteristicProfile> CharacteristicProfileColor
        {
            get { return _characteristicProfileColor; }
            set { _characteristicProfileColor = value; OnPropertyChanged(nameof(CharacteristicProfileColor)); }
        }
        public List<СharacteristicProfile> CharacteristicProfileAdditional
        {
            get { return _characteristicProfileAdditional; }
            set { _characteristicProfileAdditional = value; OnPropertyChanged(nameof(CharacteristicProfileAdditional)); }
        }
        public ICommand ShowProfileCardCommand { get; }
        public ICommand ShowProfilePropertyCommand { get; }
        public ICommand OpenProfileCardCommand { get; }
        public ICommand RefreshAllProfileCardCommand { get; }
        public ICommand ShowClientCardCommand { get; }
        public ICommand RefreshAllClientCardCommand { get; }
        public ICommand OpenClientCardCommand { get; }
        public ICommand ShowCharacteristiTypeProfileCommand { get; }
        public ICommand ShowCharacteristiColorProfileCommand { get; }
        public ICommand ShowCharacteristiAdditionalProfileCommand { get; }
        public ReferenceViewModel()
        {
            CharacteristicProfileRepository characteristiCardRepos = new CharacteristicProfileRepository();
            ProfileCardRepository profileRepos = new ProfileCardRepository();
            ClientCardRepository clientRepos = new ClientCardRepository();
            ProfileCard = profileRepos.GetByAllEntity();
            ClientCard = clientRepos.GetByAllEntity();
            ShowProfileCardCommand = new ViewModelCommand(ShowProfileCard);
            ShowProfilePropertyCommand = new ViewModelCommand(ShowProfileProperty);
            OpenProfileCardCommand = new ViewModelCommand(OpenProfileCard);
            RefreshAllProfileCardCommand=new ViewModelCommand(RefreshAllProfileCard);
            ShowClientCardCommand = new ViewModelCommand(ShowClientCard);
            RefreshAllClientCardCommand = new ViewModelCommand(RefreshAllClientCard);
            OpenClientCardCommand = new ViewModelCommand(OpenClientCard);
            ShowCharacteristiTypeProfileCommand = new ViewModelCommand(ShowCharacteristiTypeProfile);
            ShowCharacteristiColorProfileCommand = new ViewModelCommand(ShowCharacteristiColorProfile);
            ShowCharacteristiAdditionalProfileCommand= new ViewModelCommand(ShowCharacteristiAdditionalProfile);

            CharacteristicProfileType = characteristiCardRepos.GetByAllEntityType();
            CharacteristicProfileColor= characteristiCardRepos.GetByAllEntityColor();
            CharacteristicProfileAdditional= characteristiCardRepos.GetByAllEntityAdditional();
        }
        void ShowProfileCard(object obj)
        {
            ProfileCardView profileCard = new ProfileCardView();
            profileCard.Show();
        }
        void ShowProfileProperty(object obj)
        {
            ProfilePropertyView profileProperty = new ProfilePropertyView();
            profileProperty.Show();
        }
      
        void OpenProfileCard(object obj)
        {
            ProfileCardRepository profileRepos = new ProfileCardRepository();
            ImageProfileRepository imageRepos = new ImageProfileRepository();
            ImageProfileParkingRepository imageReposParking = new ImageProfileParkingRepository();
            ImageProfile image = new ImageProfile();
            ImageProfileParking imageParking = new ImageProfileParking();
            image = imageRepos.GetByExaminationNomenclature(Convert.ToInt32(EloksalId));
            imageParking = imageReposParking.GetByExaminationNomenclature(Convert.ToInt32(EloksalId));
            ProfileCardView profileCard = new ProfileCardView();
            profileCard.Show();
            ProfileCard card = new ProfileCard();
            card = profileRepos.GetByEntity(Convert.ToInt32(EloksalId));
            byte[] imageBytes;
            BitmapImage imageSource = new BitmapImage();
           
             if (image != null && image.ImageBytes!=null)
            {
                imageBytes = image.ImageBytes; 
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    
                    imageSource.BeginInit();
                    imageSource.StreamSource = stream;
                    imageSource.CacheOption = BitmapCacheOption.OnLoad;
                    imageSource.EndInit();
                }
            }
            byte[] imageBytesParking;
            BitmapImage imageSourceParking = new BitmapImage();

            if (imageParking != null && imageParking.ImageBytes != null)
            {
                imageBytesParking = imageParking.ImageBytes;
                using (MemoryStream stream = new MemoryStream(imageBytesParking))
                {

                    imageSourceParking.BeginInit();
                    imageSourceParking.StreamSource = stream;
                    imageSourceParking.CacheOption = BitmapCacheOption.OnLoad;
                    imageSourceParking.EndInit();
                }
            }
            if (card != null)
            {
                profileCard.txtId.Text = Convert.ToString(card.Id);
                profileCard.txtEloksalNo.Text = card.EloksalNo;
                profileCard.txtClientName.Text = card.ClientName;
                profileCard.txtEloksalNoCommercial.Text = card.EloksalNoCommercial;
                profileCard.txtEloksalNoCommercialForSpecification.Text = card.NomenclatureSpecification;
                profileCard.txtNomenclatureProfile.Text = card.NomenclatureProfile;
                profileCard.txtLenghtProfile.Text = Convert.ToString(card.LenghtProfile);
                profileCard.txtLenghtProfileTwo.Text = Convert.ToString(card.LenghtProfileTwo);
                profileCard.txtTypeAnod.Text = card.TypeAnod;
                profileCard.txtColorAnod.Text = card.ColorAnod;
                profileCard.txtThicknessCoating.Text = card.ThicknessCoating;
                profileCard.txtTrimming.IsChecked = card.Trimming;
                profileCard.txtSawed.IsChecked = card.Sawed;
                profileCard.txtTapeProtective.IsChecked = card.TapeProtective;
                profileCard.txtStretch.IsChecked = card.Stretch;
                profileCard.txtWeightMeter.Text = Convert.ToString(card.WeightMeter);
                profileCard.txtInnerPerimeter.Text = Convert.ToString(card.InnerPerimeter);
                profileCard.txtOuterPerimeter.Text = Convert.ToString(card.OuterPerimeter);
                profileCard.txtGeneralPerimeter.Text = Convert.ToString(card.GeneralPerimeter);
                profileCard.txtAreaAnod.Text = Convert.ToString(card.AreaAnod);
                profileCard.image.Source = imageSource;
                profileCard.imagePallet.Source = imageSourceParking; 
            }
        }
        void RefreshAllProfileCard(object obj)
        {
            ProfileCardRepository profileRepos = new ProfileCardRepository();
            ProfileCard = profileRepos.GetByAllEntity();
        }
        void ShowClientCard(object obj)
        {
            ClientCardView clientCard = new ClientCardView();
            clientCard.Show();
        }
        void RefreshAllClientCard(object obj)
        {
            ClientCardRepository clientRepos = new ClientCardRepository();
            ClientCard = clientRepos.GetByAllEntity();
        }
        void OpenClientCard(object obj)
        {
            ClientCardRepository profileRepos = new ClientCardRepository();
            ClientCardView clientCard = new ClientCardView();
            clientCard.Show();
            ClientCard card = new ClientCard();
            card = profileRepos.GetByEntity(Convert.ToInt32(ClientId));
          
            if (card != null)
            {
                clientCard.txtIdClient.Text = Convert.ToString(card.Id);
                clientCard.txtClientName.Text = card.ClientName;
                clientCard.txtClientNo.Text = card.ContractNumber;
                clientCard.txtPhoneNumberAnother.Text = card.ContactNumberPhoneAnother;
                clientCard.txtDateContract.Text = card.DateContract.ToString();
                clientCard.txtPhysicalAddress.Text = card.PhysicalAddress;
                clientCard.txtContactPerson.Text = card.ContactPerson;
                clientCard.txtPhoneNumber.Text = card.ContactNumberPhone;
                clientCard.txtEmail.Text = card.ContactEmail;
                clientCard.txtManager.Text = card.Manager;
            }
        }
        void ShowCharacteristiTypeProfile(object obj)
        {
            CharacteristicView characteristiCard = new CharacteristicView();
            characteristiCard.Show();
            characteristiCard.txtPropertyProfile.Text= "Вид покрытия";
        }
        void ShowCharacteristiColorProfile(object obj)
        {
            CharacteristicView characteristiCard = new CharacteristicView();
            characteristiCard.Show();
            characteristiCard.txtPropertyProfile.Text = "Цвет покрытия";
        }
        void ShowCharacteristiAdditionalProfile(object obj)
        {
            CharacteristicView characteristiCard = new CharacteristicView();
            characteristiCard.Show();
            characteristiCard.txtPropertyProfile.Text = "Дополнительные услуги";
        }
    }
}
