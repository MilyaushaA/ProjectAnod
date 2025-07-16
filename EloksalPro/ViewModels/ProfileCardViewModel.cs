using EloksalPro.EfStructures;
using EloksalPro.Models;
using EloksalPro.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EloksalPro.ViewModels
{
    public class ProfileCardViewModel : ViewModelBase
    {
        public ImageProfile imageProfile = new ImageProfile();
        public ImageProfileParking imageProfileParking = new ImageProfileParking();
        private ProfileCard _profile = new ProfileCard();
        private List<string> _lenghtList;
        private List<string> _typeAnodList;
        private List<string> _colorAnodList;
        private List<string> _thicknessCoatingList;
        private List<string> _clientList;
        private List<string> _clientProfileList;
        private string _lenghtSource;
        private string _lenghtSourceTwo;
        private int _id;
        private string _typeAnodSource;
        private string _colorAnodSource;
        private string _thicknessCoatingSource;
        private string _clientSource;
        private string _clientProfileSource;
        private string _nomenclature;
        private string _nomenclatureSpecification;
        private string _eloksalNo;
        private bool _trimming;
        private bool _sawed;
        private bool _tapeProtective;
        private bool _stretch;
        private ImageSource _drawingSourse;
        private ImageSource _drawingPalletSourse;
        string image;
        string imagePallet;
        double _innerPerimeter;
        double _outerPerimeter;
        double _generalPerimeter;
        double _weightMeter;
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        public ProfileCard Profile
        {
            get { return _profile; }
            set { _profile = value; OnPropertyChanged(nameof(Profile)); }
        }
        public string Nomenclature
        {
            get { return _nomenclature; }
            set { _nomenclature = value; OnPropertyChanged(nameof(Nomenclature)); }
        }
        public string NomenclatureSpecification
        {
            get { return _nomenclatureSpecification; }
            set { _nomenclatureSpecification = value; OnPropertyChanged(nameof(NomenclatureSpecification)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        } 
        public double GeneralPerimeter
        {
            get { return _generalPerimeter; }
            set { _generalPerimeter = value; OnPropertyChanged(nameof(GeneralPerimeter)); }
        }
        public double OuterPerimeter
        {
            get { return _outerPerimeter; }
            set { _outerPerimeter = value; CalculateTotalPerimetr(); OnPropertyChanged(nameof(OuterPerimeter)); }
        }
        public double WeightMeter
        {
            get { return _weightMeter; }
            set { _weightMeter = value;OnPropertyChanged(nameof(WeightMeter)); }
        }
        public double InnerPerimeter
        {
            get { return _innerPerimeter; }
            set { _innerPerimeter = value; CalculateTotalPerimetr(); OnPropertyChanged(nameof(InnerPerimeter)); }
        }
        public string EloksalNo
        {
            get { return _eloksalNo; }
            set { _eloksalNo = value; GetDataProfileCard(); NameNomenclatureText(); OnPropertyChanged(nameof(EloksalNo)); }
        }
        public List<string> LenghtList
        {
            get { return _lenghtList; }
            set { _lenghtList = value; OnPropertyChanged(nameof(LenghtList)); }
        }
        public List<string> TypeAnodList
        {
            get { return _typeAnodList; }
            set { _typeAnodList = value; OnPropertyChanged(nameof(TypeAnodList)); }
        }
        public List<string> ColorAnodList
        {
            get { return _colorAnodList; }
            set { _colorAnodList = value; OnPropertyChanged(nameof(ColorAnodList)); }
        }
        public List<string> ThicknessCoatingList
        {
            get { return _thicknessCoatingList; }
            set { _thicknessCoatingList = value; OnPropertyChanged(nameof(ThicknessCoatingList)); }
        }
        public List<string> ClientList
        {
            get { return _clientList; }
            set { _clientList = value; OnPropertyChanged(nameof(ClientList)); }
        }
        public List<string> ClientProfileList
        {
            get { return _clientProfileList; }
            set { _clientProfileList = value; OnPropertyChanged(nameof(ClientProfileList)); }
        }
        public string LenghtSource
        {
            get { return _lenghtSource; }
            set { _lenghtSource = value; NameNomenclatureText(); OnPropertyChanged(nameof(LenghtSource)); }
        }
        public string LenghtSourceTwo
        {
            get { return _lenghtSourceTwo; }
            set { _lenghtSourceTwo = value; NameNomenclatureText(); OnPropertyChanged(nameof(LenghtSourceTwo)); }
        }
        public string TypeAnodSource
        {
            get { return _typeAnodSource; }
            set { _typeAnodSource = value; NameNomenclatureText(); OnPropertyChanged(nameof(TypeAnodSource)); }
        }
        public string ColorAnodSource
        {
            get { return _colorAnodSource; }
            set { _colorAnodSource = value; NameNomenclatureText(); OnPropertyChanged(nameof(ColorAnodSource)); }
        }
        public string ThicknessCoatingSource
        {
            get { return _thicknessCoatingSource; }
            set { _thicknessCoatingSource = value; NameNomenclatureText(); OnPropertyChanged(nameof(ThicknessCoatingSource)); }
        }
        public string ClientSource
        {
            get { return _clientSource; }
            set { _clientSource = value; ListProfileNo(); OnPropertyChanged(nameof(ClientSource)); }
        }
        public string ClientProfileSource
        {
            get { return _clientProfileSource; }
            set { _clientProfileSource = value; GetDataProfileFromEloksalNo(); GetNomenclatureSpecification(); OnPropertyChanged(nameof(ClientProfileSource)); }
        }
        public bool Trimming
        {
            get { return _trimming; }
            set { _trimming = value; NameNomenclatureText(); OnPropertyChanged(nameof(Trimming)); }
        }
        public bool Sawed
        {
            get { return _sawed; }
            set { _sawed = value; NameNomenclatureText(); OnPropertyChanged(nameof(Sawed)); }
        }
        public bool Stretch
        {
            get { return _stretch; }
            set { _stretch = value; NameNomenclatureText(); OnPropertyChanged(nameof(Stretch)); }
        }
        public bool TapeProtective
        {
            get { return _tapeProtective; }
            set { _tapeProtective = value; NameNomenclatureText(); OnPropertyChanged(nameof(TapeProtective)); }
        }
        public ImageSource DrawingSourse
        {
            get { return _drawingSourse;}
            set { _drawingSourse = value; OnPropertyChanged("DrawingSourse"); }
        }
        public ImageSource DrawingPalletSourse
        {
            get { return _drawingPalletSourse; }
            set { _drawingPalletSourse = value; OnPropertyChanged("DrawingPalletSourse"); }
        }
        public ICommand SaveInsertCommand { get; }
        public ICommand OpenImageCommand { get; }
        public ICommand DeleteImageCommand { get; }
        public ICommand PrintImageCommand { get; }

        public ICommand OpenImagePalletCommand { get; }
        public ICommand DeleteImagePalletCommand { get; }
        public ProfileCardViewModel()
        {
            SaveInsertCommand = new ViewModelCommand(ChoiceInsertandUpdate);
            ProfilePropertyRepository property = new ProfilePropertyRepository();
            CharacteristicProfileRepository characteristic = new CharacteristicProfileRepository();
            ProfileCardRepository repos = new ProfileCardRepository();
            ClientCardRepository reposClient = new ClientCardRepository();
            LenghtList =property.PropertyLenghtProfile();
            TypeAnodList = characteristic.GetByAllListType();
            ColorAnodList = characteristic.GetByAllListColor();
            ThicknessCoatingList = property.PropertyThicknessProfile("Толщина");
            ClientList = reposClient.GetByExaminationNomenclature();
            int MaxEloksalNo = repos.MaxEloksalNo() + 1;
            EloksalNo = "EL" + MaxEloksalNo.ToString("D4");
            OpenImageCommand = new ViewModelCommand(OpenFileImage);
            DeleteImageCommand= new ViewModelCommand(DeleteFileImage);
            PrintImageCommand = new ViewModelCommand(PrintImage);

            OpenImagePalletCommand = new ViewModelCommand(OpenFilePalletDrawing);
            DeleteImagePalletCommand = new ViewModelCommand(DeleteFilePalletDrawing);
        }
        public void InsertNewProfile(string nomenclature,int lenght,int lenghtTwo)
        {
            ProfileCardRepository repos = new ProfileCardRepository();
            ProfileCard profile = new ProfileCard();
            int maxId = repos.GetById();
            List<string> nomenclatureProfile = new List<string>();
            nomenclatureProfile = repos.GetByExaminationNomenclature();
            if (nomenclatureProfile.Contains(nomenclature)) MessageBox.Show($"{nomenclature}   уже есть в базе профилей", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (ClientProfileSource == "0") MessageBox.Show($"{ClientProfileSource} не может быть 0", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (TapeProtective == true && Stretch==true)
                    MessageBox.Show("Нанесение защитной пленки и Стрейч-пленка не могут быть в одном профиле", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                profile.Id = ++maxId;
                profile.EloksalNo = EloksalNo;
                profile.ClientName = ClientSource;
                profile.EloksalNoCommercial = ClientProfileSource;
                profile.NomenclatureProfile = nomenclature;
                profile.NomenclatureSpecification = NomenclatureSpecification;
                profile.LenghtProfile = lenght;// Convert.ToInt32(LenghtSource);
                profile.LenghtProfileTwo = lenghtTwo; // Convert.ToInt32(LenghtSourceTwo);
                profile.TypeAnod = TypeAnodSource;
                profile.ColorAnod = ColorAnodSource;
                profile.ThicknessCoating = ThicknessCoatingSource;
                profile.Trimming = Trimming;
                profile.Sawed = Sawed;
                profile.TapeProtective = TapeProtective;
                profile.Stretch= Stretch;
                profile.WeightMeter = WeightMeter;
                profile.InnerPerimeter = InnerPerimeter;
                profile.OuterPerimeter = OuterPerimeter;
                profile.GeneralPerimeter = GeneralPerimeter;
                profile.AreaAnod = Profile.AreaAnod;
                repos.Add(profile);
                int IdClient = repos.GetById();
                if (imageProfile != null && imageProfile.ImageBytes != null)
                {
                    ImageProfileRepository reposImage = new ImageProfileRepository();
                    ImageProfile imageProfileAdd = new ImageProfile();
                    int maxIdd = reposImage.GetById();
                    imageProfileAdd.Id = ++maxIdd;
                    imageProfileAdd.ClientId = IdClient;
                    imageProfileAdd.ImageBytes = imageProfile.ImageBytes;
                    reposImage.Add(imageProfileAdd);
                }
                if (imageProfileParking != null && imageProfileParking.ImageBytes != null)
                {
                    ImageProfileParkingRepository reposImageParking = new ImageProfileParkingRepository();
                    ImageProfileParking imageProfileAddPallet = new ImageProfileParking();
                    int maxIdd = reposImageParking.GetById();
                    imageProfileAddPallet.Id = ++maxIdd;
                    imageProfileAddPallet.ClientId = IdClient;
                    imageProfileAddPallet.ImageBytes = imageProfileParking.ImageBytes;
                    reposImageParking.Add(imageProfileAddPallet);
                }
                else
                {
                    InsertNewImageProfile(IdClient);
                    InsertNewImageProfilePallet(IdClient);
                }
               
            }
        }
        void NameNomenclatureText()
        {
            if (LenghtSourceTwo == null)
            {
                if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == false && ThicknessCoatingSource == null)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" + ColorAnodSource;
                }
                else if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                  ColorAnodSource + "-" + ThicknessCoatingSource;
                }
                else if (Trimming == true && Sawed == true && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TRP";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TP";
                }
                else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TR";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "T";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "RP";
                }
                else if (Trimming == false && Sawed == false && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "P";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "R";
                }
                else if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "S";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TS";
                }
                else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TRS";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "RS";
                }
              
            }
            else
            {
                if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == false && ThicknessCoatingSource == null)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " "+ TypeAnodSource + "-" + ColorAnodSource;
                }
                else if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                  ColorAnodSource + "-" + ThicknessCoatingSource;
                }
                else if (Trimming == true && Sawed == true && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TRP";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TP";
                }
                else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TR";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "T";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "RP";
                }
                else if (Trimming == false && Sawed == false && TapeProtective == true && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "P";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == false)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "R";
                }
                else if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "S";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TS";
                }
                else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/" + LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "TRS";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == true)
                {
                    _nomenclature = EloksalNo + " " + LenghtSource + "/"+LenghtSourceTwo + " " + TypeAnodSource + "-" +
                                   ColorAnodSource + "-" + ThicknessCoatingSource + "-" + "RS";
                }
               
            }
            OnPropertyChanged("Nomenclature");

        }
        public void UpdateProfile()
        {
            ProfileCardRepository repos = new ProfileCardRepository();
            repos.ProfileCardUpdate(Id, EloksalNo, ClientSource, ClientProfileSource, Nomenclature,NomenclatureSpecification,Convert.ToInt32(LenghtSource), Convert.ToInt32(LenghtSourceTwo),
                                     TypeAnodSource, ColorAnodSource, ThicknessCoatingSource,
                                     Trimming, Sawed, TapeProtective, Stretch, WeightMeter, InnerPerimeter,
                                     OuterPerimeter, GeneralPerimeter, Profile.AreaAnod);
            InsertNewImageProfile(Id);
            InsertNewImageProfilePallet(Id);
        }
        async void  ChoiceInsertandUpdate(object obj)
        {
            int role = LoadCurrentUserRole();
            if (role == 0 || role == 1)
            {
                if (Id == 0)
                { await Task.Run(() => InsertNewProfile(Nomenclature, Convert.ToInt32(LenghtSource), Convert.ToInt32(LenghtSourceTwo)));
                 if (LenghtSourceTwo!=null && Convert.ToInt32(LenghtSourceTwo) != 0)
                    {
                       
                        await Task.Run(() => InsertNewProfile(NameNomenclatureOne(), Convert.ToInt32(LenghtSource), 0));
                        await Task.Run(() => InsertNewProfile(NameNomenclatureTwo(), Convert.ToInt32(LenghtSourceTwo), 0));
                    }
                    MessageBox.Show("Данные успешно сохранены");
                }
               
                else await Task.Run(() => UpdateProfile());
            }
            else
            {
                MessageBox.Show("У вас нет доступа для сохранения данных!");
            }
            }
        void ListProfileNo()
        {
            ClientCardRepository repos = new ClientCardRepository();
            ProfileCardComercialRepository reposProfile = new ProfileCardComercialRepository();
            int id = repos.GetByExaminationNomenclature(ClientSource);
            if (id > 0)
            {
                _clientProfileList = reposProfile.GetByExaminationNomenclature(id);
                OnPropertyChanged("ClientProfileList");
            }

        }   
        void OpenFileImage(object obj)
        {
            int role = LoadCurrentUserRole();
            if (role==0 || role == 1)
            {
                try
                {
                    ImageProfileRepository repos = new ImageProfileRepository();
                    repos.RemoveImage(Id);
                    DrawingSourse = null;
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    bool? result = openFileDialog.ShowDialog();
                    if (result == true)
                    {
                        image = openFileDialog.FileName;
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(image);
                        bitmap.EndInit();
                        DrawingSourse = bitmap;
                    }
                }
                catch
                {
                    image = null;
                    MessageBox.Show("Неверный формат рисунка!");

                }
            }
            else
            {
                MessageBox.Show("У вас нет доступа для изменения рисунка!");
            }
      
        }
        void DeleteFileImage(object obj)
        {
            int role = LoadCurrentUserRole();
            if (role == 0 || role == 1)
            {
                ImageProfileRepository repos = new ImageProfileRepository();
            repos.RemoveImage(Id);
            DrawingSourse = null;
            }
            else
            {
                MessageBox.Show("У вас нет доступа для изменения рисунка!");
            }
        }
        void OpenFilePalletDrawing(object obj)
        {
            int role = LoadCurrentUserRole();
            if (role == 0 || role == 1)
            {
                try
            {
                ImageProfileParkingRepository repos = new ImageProfileParkingRepository();
                repos.RemoveImage(Id);
                DrawingPalletSourse = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                bool? result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    imagePallet = openFileDialog.FileName;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePallet);
                    bitmap.EndInit();
                    DrawingPalletSourse = bitmap;
                }
            }
            catch
            {
                image = null;
                MessageBox.Show("Неверный формат рисунка!");
            }
            }
            else
            {
                MessageBox.Show("У вас нет доступа для изменения рисунка!");
            }
        }
        void DeleteFilePalletDrawing(object obj)
        {
            int role = LoadCurrentUserRole();
            if (role == 0 || role == 1)
            {
                ImageProfileParkingRepository repos = new ImageProfileParkingRepository();
            repos.RemoveImage(Id);
            DrawingPalletSourse = null;
            }
            else
            {
                MessageBox.Show("У вас нет доступа для изменения рисунка!");
            }
        }
        public void InsertNewImageProfile(int id)
        {
            int maxWidth = 800; // максимальная ширина
            int maxHeight = 600; // максимальная высота
            long quality = 50; // качество (от 0 до 100) 

                ImageProfileRepository repos = new ImageProfileRepository();
                ImageProfile imageProfile = new ImageProfile();
                int maxId = repos.GetById();

                byte[] fileContent;
                if (image == null)
                {
                    fileContent = null;
                }
                else
                { fileContent = ImageHelper.ResizeAndCompressImage(image, maxWidth, maxHeight, quality); }
               
                imageProfile.Id = ++maxId;
                imageProfile.ClientId = id;
                imageProfile.ImageBytes = fileContent;
                repos.Add(imageProfile);
        }
        public void InsertNewImageProfilePallet(int id)
        {
            
                int maxWidth = 800; // максимальная ширина
                int maxHeight = 600; // максимальная высота
                long quality = 50; // качество (от 0 до 100) 

                ImageProfileParkingRepository repos = new ImageProfileParkingRepository();
                ImageProfileParking imageProfile = new ImageProfileParking();
                int maxId = repos.GetById();

                byte[] fileContent;
                if (imagePallet == null)
                {
                    fileContent = null;
                }
                else
                {
                    //Stream myStream;
                    //using (myStream = File.OpenRead(image))
                    //{
                    //    BinaryReader myReader = new BinaryReader(myStream);
                    //    fileContent = myReader.ReadBytes((int)myStream.Length);
                    //}
                    fileContent = ImageHelper.ResizeAndCompressImage(imagePallet, maxWidth, maxHeight, quality);
                }

                imageProfile.Id = ++maxId;
                imageProfile.ClientId = id;
                imageProfile.ImageBytes = fileContent;
                repos.Add(imageProfile);
         

        }
        public void CalculateTotalPerimetr()
        {
           _generalPerimeter = InnerPerimeter + OuterPerimeter;
            OnPropertyChanged("GeneralPerimeter");  
        }
        void GetDataProfileCard()
        {
            if (Id == 0)
            {
                ProfileCardRepository repos = new ProfileCardRepository();
                ImageProfileRepository imageRepos = new ImageProfileRepository();
                ImageProfileParkingRepository imageParkingRepos = new ImageProfileParkingRepository();
                ProfileCard list = new ProfileCard();
                list = repos.GetByListProfileCardFromEloksalNo(EloksalNo);
                if (list != null)
                {
                    int id = list.Id;
                    imageProfile = imageRepos.GetByExaminationNomenclature(id);
                    imageProfileParking= imageParkingRepos.GetByExaminationNomenclature(id);
                    _clientSource = list.ClientName;
                    OnPropertyChanged("ClientSource");
                    ListProfileNo();
                    _weightMeter = list.WeightMeter;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                    OnPropertyChanged("WeightMeter");
                    _outerPerimeter = list.OuterPerimeter;
                    CalculateTotalPerimetr();
                    OnPropertyChanged("OuterPerimeter");
                    BitmapImage imageSource = new BitmapImage();
                    byte[] imageBytes;
                    if (imageProfile != null && imageProfile.ImageBytes != null)
                    {
                        imageBytes = imageProfile.ImageBytes;
                        using (MemoryStream stream = new MemoryStream(imageBytes))
                        {
                            imageSource.BeginInit();
                            imageSource.StreamSource = stream;
                            imageSource.CacheOption = BitmapCacheOption.OnLoad;
                            imageSource.EndInit();
                        }
                    }
                    _drawingSourse = imageSource;
                    OnPropertyChanged("DrawingSourse");
                    BitmapImage imageParkingSource = new BitmapImage();
                    byte[] imageParkingBytes;
                    if (imageProfileParking != null && imageProfileParking.ImageBytes != null)
                    {
                        imageParkingBytes = imageProfileParking.ImageBytes;
                        using (MemoryStream stream = new MemoryStream(imageParkingBytes))
                        {
                            imageParkingSource.BeginInit();
                            imageParkingSource.StreamSource = stream;
                            imageParkingSource.CacheOption = BitmapCacheOption.OnLoad;
                            imageParkingSource.EndInit();
                        }
                    }
                    _drawingPalletSourse = imageParkingSource;
                    OnPropertyChanged("DrawingPalletSourse");
           
                }
            }
        }
        void GetDataProfileFromEloksalNo()
        {
            if (Id == 0)
            {
                CommercialOfferRepository offerRepos = new CommercialOfferRepository();
                CommercialOffer offer = new CommercialOffer();
                offer = offerRepos.GetWeightAndPerimetr(ClientSource, ClientProfileSource);
                if (offer != null)
                {
                    _weightMeter = offer.WeightMeter;
                    OnPropertyChanged("WeightMeter");
                    _outerPerimeter = offer.OuterPerimeter;
                    CalculateTotalPerimetr();
                    OnPropertyChanged("OuterPerimeter");
                    _typeAnodSource = offer.TypeAnod;
                    OnPropertyChanged("TypeAnodSource");
                    _colorAnodSource = offer.ColorAnod;
                    OnPropertyChanged("ColorAnodSource");
                    _thicknessCoatingSource = offer.ThicknessCoating;
                    OnPropertyChanged("ThicknessCoatingSource");
                    _trimming = offer.Trimming;
                    OnPropertyChanged("Trimming");
                    _sawed = offer.Sawed;
                    OnPropertyChanged("Sawed");
                    NameNomenclatureText();
                }
            }
        }
        //public async void UpdateSave(object obj)
        //{
        //  await Task.Run(() => InsertNewProfile());
        //}
        void GetNomenclatureSpecification()
        {
            _nomenclatureSpecification = ClientProfileSource;
            OnPropertyChanged("NomenclatureSpecification");

        }
        void PrintImage(object obj)
        {
            PrintDialog dlg = new PrintDialog();
            ImageProfileRepository imageRepos = new ImageProfileRepository();
            imageProfile = imageRepos.GetByExaminationNomenclature(Id);
            if (dlg.ShowDialog() == true)
            {
                Image img = new Image();
                byte[] imageBytes;
                BitmapImage imageSource = new BitmapImage();
                if (imageProfile != null && imageProfile.ImageBytes != null)
                {
                    imageBytes = imageProfile.ImageBytes;
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    {

                        imageSource.BeginInit();
                        imageSource.StreamSource = stream;
                        imageSource.CacheOption = BitmapCacheOption.OnLoad;
                        imageSource.EndInit();
                    }
                }
                img.Source = imageSource;
                dlg.PrintVisual(img, "A Page Title");
            }
        }
        private int LoadCurrentUserRole()
        {
            UserRepository userRepo = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            UserModel userList = userRepo.GetByUsername(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            if (userList != null)
            {
                {
                    CurrentUserAccount.Role = userList.Role;
                }
            }
            else
            {
                CurrentUserAccount.Role = 2;
            }
            return CurrentUserAccount.Role;
        }
        string NameNomenclatureOne()
        {
            string name= EloksalNo + " " + LenghtSource + " " + TypeAnodSource + "-" + ColorAnodSource + "-" + ThicknessCoatingSource;
                if (Trimming == true && Sawed == true && TapeProtective == true && Stretch == false)
                {
                name = name + "-" + "TRP";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == true && Stretch == false)
                {
                name =name + "-" + "TP";
                }
                else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == false)
                {
                name =name + "-" + "TR";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == false)
                {
                name = name + "-" + "T";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == true && Stretch == false)
                {
                name = name + "-" + "RP";
                }
                else if (Trimming == false && Sawed == false && TapeProtective == true && Stretch == false)
                {
                name = name + "-" + "P";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == false)
                {
                name = name + "-" + "R";
                }
                else if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == true)
                {
                name =name + "-" + "S";
                }
                else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == true)
                {
                name =name + "TS";
                }
                else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == true)
                {
                name = name + "-" + "TRS";
                }
                else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == true)
                {
                name =name + "-" + "RS";
                }
            return name;

            }
        string NameNomenclatureTwo()
        {
            string name = EloksalNo + " " + LenghtSourceTwo + " " + TypeAnodSource + "-" + ColorAnodSource + "-" + ThicknessCoatingSource;
            if (Trimming == true && Sawed == true && TapeProtective == true && Stretch == false)
            {
                name = name + "-" + "TRP";
            }
            else if (Trimming == true && Sawed == false && TapeProtective == true && Stretch == false)
            {
                name = name + "-" + "TP";
            }
            else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == false)
            {
                name = name + "-" + "TR";
            }
            else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == false)
            {
                name = name + "-" + "T";
            }
            else if (Trimming == false && Sawed == true && TapeProtective == true && Stretch == false)
            {
                name = name + "-" + "RP";
            }
            else if (Trimming == false && Sawed == false && TapeProtective == true && Stretch == false)
            {
                name = name + "-" + "P";
            }
            else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == false)
            {
                name = name + "-" + "R";
            }
            else if (Trimming == false && Sawed == false && TapeProtective == false && Stretch == true)
            {
                name = name + "-" + "S";
            }
            else if (Trimming == true && Sawed == false && TapeProtective == false && Stretch == true)
            {
                name = name + "TS";
            }
            else if (Trimming == true && Sawed == true && TapeProtective == false && Stretch == true)
            {
                name = name + "-" + "TRS";
            }
            else if (Trimming == false && Sawed == true && TapeProtective == false && Stretch == true)
            {
                name = name + "-" + "RS";
            }
            return name;

        }


    }
    }

