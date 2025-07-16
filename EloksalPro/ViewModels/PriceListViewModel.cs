using EloksalPro.Models;
using EloksalPro.Repositories;
using EloksalPro.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EloksalPro.ViewModels
{
    public class PriceListViewModel : ViewModelBase
    {
        private PriceListProfile _priceListProfile = new PriceListProfile();
        private List<string> _profileList;
        private string _profileSource;
        private string _nomenclatureProfile;
        private List<string> _clienPricetList;
        private string _clientPriceSource;
        private int _idPrice;
        private int _idProfile;

        private double _kgPrice;
        private double _metrPrice;
        private double _areaPrice;

        private List<СharacteristicProfile> _characteristicProfileType;
        private List<СharacteristicProfile> _characteristicProfileColor;
        private List<СharacteristicProfile> _characteristicProfileAdditional;

        public PriceListProfile PriceListProfile
        {
            get { return _priceListProfile; }
            set { _priceListProfile = value; OnPropertyChanged(nameof(PriceListProfile)); }
        }
        public List<string> ProfileList
        {
            get { return _profileList; }
            set { _profileList = value; OnPropertyChanged(nameof(ProfileList)); }
        }
        public string ProfileSource
        {
            get { return _profileSource; }
            set { _profileSource = value; ListProfileNo(); OnPropertyChanged(nameof(ProfileSource)); }
        }
        public int IdPrice
        {
            get { return _idPrice; }
            set { _idPrice = value;  OnPropertyChanged(nameof(IdPrice)); }
        }
        public int IdProfile
        {
            get { return _idProfile; }
            set { _idProfile = value;OnPropertyChanged(nameof(IdProfile)); }
        }
        public double AreaPrice
        {
            get { return _areaPrice; }
            set { _areaPrice = value; CalculateMetrPriceProfile(); OnPropertyChanged(nameof(AreaPrice)); }
        }
        public double KgPrice
        {
            get { return _kgPrice; }
            set { _kgPrice = value;  OnPropertyChanged(nameof(KgPrice)); }
        }
        public double MetrPrice
        {
            get { return _metrPrice; }
            set { _metrPrice = value; OnPropertyChanged(nameof(MetrPrice)); }
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
        public string NomenclatureProfile
        {
            get { return _nomenclatureProfile; }
            set { _nomenclatureProfile = value; OnPropertyChanged(nameof(NomenclatureProfile)); }
        }
        public List<string> ClientPriceList
        {
            get { return _clienPricetList; }
            set { _clienPricetList = value; OnPropertyChanged(nameof(ClientPriceList)); }
        }
        public string ClientPriceSource
        {
            get { return _clientPriceSource; }
            set { _clientPriceSource = value; ClientProfileNo(); OnPropertyChanged(nameof(ClientPriceSource)); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand OpenCardProfileCommand { get; }
        public PriceListViewModel()
        {
            CharacteristicProfileRepository characteristiCardRepos = new CharacteristicProfileRepository();
            ProfileCardComercialRepository cardComercial = new ProfileCardComercialRepository();
            SaveInsertCommand = new ViewModelCommand(ChoiceInsertandUpdate);
            OpenCardProfileCommand= new ViewModelCommand(OpenCardProfile);
            ClientCardRepository reposClient = new ClientCardRepository();
            ClientPriceList = reposClient.GetByExaminationNomenclature();
            CharacteristicProfileType = characteristiCardRepos.GetByAllEntityType();
            CharacteristicProfileColor = characteristiCardRepos.GetByAllEntityColor();
            CharacteristicProfileAdditional = characteristiCardRepos.GetByAllEntityAdditional();      
        }
        void SaveInsertNewPrice()
        {
            PriceListProfileRepository repos = new PriceListProfileRepository();

            List<string> nomenclatureProfile = new List<string>();
            nomenclatureProfile = repos.GetNomenclature();
            if (nomenclatureProfile.Contains(ProfileSource)) MessageBox.Show($"{ProfileSource} уже есть в ПРАЙС-ЛИСТЕ", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                try
                {
                    int id = repos.GetById();
                    PriceListProfile newProfilePrice = new PriceListProfile();
                    newProfilePrice.Id = ++id;
                    newProfilePrice.CustomerName = ClientPriceSource;
                    newProfilePrice.CustomerCode = NomenclatureProfile;
                    newProfilePrice.ProfileCode = ProfileSource;
                    newProfilePrice.PriceProfileKg = KgPrice;
                    newProfilePrice.PriceProfileMetr = MetrPrice;
                    newProfilePrice.PriceProfileArea = AreaPrice;
                    repos.Add(newProfilePrice);
                    MessageBox.Show("Данные успешно сохранены");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Некорректный формат данных в поле ЦЕНА");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Слишком большое или слишком маленькое число, введите другое.");
                }
            }
        }
        void ListProfileNo()
        {
            ProfileCardRepository reposProfile = new ProfileCardRepository();
            _nomenclatureProfile = reposProfile.GetByNomenclature(ProfileSource);
            OnPropertyChanged("NomenclatureProfile");
        }
        void ClientProfileNo()
        {
            ClientCardRepository repos = new ClientCardRepository();
            ProfileCardComercialRepository reposProfile = new ProfileCardComercialRepository();
            ProfileCardRepository reposProfileCard = new ProfileCardRepository();
            int id = repos.GetByExaminationNomenclature(ClientPriceSource);
            if (id > 0)
            {
                _profileList = reposProfileCard.GetByExaminationNomenclature(ClientPriceSource);
                OnPropertyChanged("ProfileList");
            }
            
        }
        public void UpdatePriceProfile()
        {
            try
            {
                PriceListProfileRepository repos = new PriceListProfileRepository();
                repos.ProfilePriceUpdate(IdPrice, ClientPriceSource, NomenclatureProfile, ProfileSource, Convert.ToDouble(KgPrice), Convert.ToDouble(MetrPrice), Convert.ToDouble(AreaPrice));
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат данных в поле ЦЕНА");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Слишком большое или слишком маленькое число, введите другое.");
            }
        }

        void ChoiceInsertandUpdate(object obj)
        {
            if (IdPrice == 0) SaveInsertNewPrice();
            else UpdatePriceProfile();
        }
        void CalculateMetrPriceProfile()
        {
            ProfileCardRepository reposProfile = new ProfileCardRepository();
            double outerPerimetr = reposProfile.GetByOuterPerimetrProfile(ProfileSource);
            double weightProfile = reposProfile.GetByWeightProfile(ProfileSource);
            if (weightProfile > 0 && outerPerimetr>0)
            {
                //_areaPrice = Math.Round(Convert.ToDouble(KgPrice) / (outerPerimetr / weightProfile), 2);
                _kgPrice = Math.Round(Convert.ToDouble(AreaPrice) * (Convert.ToDouble(outerPerimetr) / Convert.ToDouble(weightProfile)),2);
                OnPropertyChanged(nameof(KgPrice));
                _metrPrice = Math.Round(Convert.ToDouble(KgPrice) * Convert.ToDouble(weightProfile) / 1000, 2);
                OnPropertyChanged(nameof(MetrPrice));
            }
            ProfileCard list = new ProfileCard();
            list = reposProfile.GetByListProfileCard(ProfileSource);
            if (list != null)
            {
                _idProfile = list.Id;
                OnPropertyChanged(nameof(IdProfile));
            }               
        }

      
        void OpenCardProfile(object obj)
        {
            ProfileCardRepository profileRepos = new ProfileCardRepository();
            ImageProfileRepository imageRepos = new ImageProfileRepository();
            ImageProfile image = new ImageProfile();

            image = imageRepos.GetByExaminationNomenclature(Convert.ToInt32(IdProfile));
            ProfileCardView profileCard = new ProfileCardView();
            profileCard.Show();
            ProfileCard card = new ProfileCard();
            card = profileRepos.GetByEntity(Convert.ToInt32(IdProfile));
            byte[] imageBytes;
            BitmapImage imageSource = new BitmapImage();

            if (image != null && image.ImageBytes != null)
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
            if (card != null)
            {
                profileCard.txtId.Text = Convert.ToString(card.Id);
                profileCard.txtEloksalNo.Text = card.EloksalNo;
                profileCard.txtClientName.Text = card.ClientName;
                profileCard.txtEloksalNoCommercial.Text = card.EloksalNoCommercial;
                profileCard.txtNomenclatureProfile.Text = card.NomenclatureProfile;
                profileCard.txtLenghtProfile.Text = Convert.ToString(card.LenghtProfile);
                profileCard.txtTypeAnod.Text = card.TypeAnod;
                profileCard.txtColorAnod.Text = card.ColorAnod;
                profileCard.txtThicknessCoating.Text = card.ThicknessCoating;
                profileCard.txtTrimming.IsChecked = card.Trimming;
                profileCard.txtSawed.IsChecked = card.Sawed;
                profileCard.txtTapeProtective.IsChecked = card.TapeProtective;
                profileCard.txtWeightMeter.Text = Convert.ToString(card.WeightMeter);
                profileCard.txtInnerPerimeter.Text = Convert.ToString(card.InnerPerimeter);
                profileCard.txtOuterPerimeter.Text = Convert.ToString(card.OuterPerimeter);
                profileCard.txtGeneralPerimeter.Text = Convert.ToString(card.GeneralPerimeter);
                profileCard.txtAreaAnod.Text = Convert.ToString(card.AreaAnod);
                profileCard.image.Source = imageSource;
            }
        }

    }
}