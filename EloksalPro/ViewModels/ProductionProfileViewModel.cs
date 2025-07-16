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
    public class ProductionProfileViewModel:ViewModelBase
    {
        private int _id;
        private int _idShotSummary;
        private int _idAnod;
        private int _idAnodSummary;
        private int _idHitch;
        private int _idTapeProtective;
        private int _idTapeProtectiveSummary;
        private int _idCuttingFacing;
        private int _idCuttingFacingSummary;
        private int _idPacking;
        private int _idPackingSummary;
        public string _nomenclatureProfile;
        public string _basketNumber;
        private List<SummaryTableProfile> _summaryTableProfile;
        public List<SummaryTableProfile> SummaryTableProfile
        {
            get { return _summaryTableProfile; }
            set { _summaryTableProfile = value; OnPropertyChanged(nameof(SummaryTableProfile)); }
        }
        private List<SummaryTableProfileCutting> _summaryTableProfileCutting;
        public List<SummaryTableProfileCutting> SummaryTableProfileCutting
        {
            get { return _summaryTableProfileCutting; }
            set { _summaryTableProfileCutting = value; OnPropertyChanged(nameof(SummaryTableProfileCutting)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        public int IdShotSummary
        {
            get { return _idShotSummary; }
            set { _idShotSummary = value; OnPropertyChanged(nameof(IdShotSummary)); }
        }
        public int IdAnod
        {
            get { return _idAnod; }
            set { _idAnod = value; OnPropertyChanged(nameof(IdAnod)); }
        }
        public int IdAnodSummary
        {
            get { return _idAnodSummary; }
            set { _idAnodSummary = value; OnPropertyChanged(nameof(IdAnodSummary)); }
        }
        public int IdHitch
        {
            get { return _idHitch; }
            set { _idHitch = value; OnPropertyChanged(nameof(IdHitch)); }
        }
        public int IdTapeProtective
        {
            get { return _idTapeProtective; }
            set { _idTapeProtective = value; OnPropertyChanged(nameof(IdTapeProtective)); }
        }
        public int IdTapeProtectiveSummary
        {
            get { return _idTapeProtectiveSummary; }
            set { _idTapeProtectiveSummary = value; OnPropertyChanged(nameof(IdTapeProtectiveSummary)); }
        }
        public int IdCuttingFacing
        {
            get { return _idCuttingFacing; }
            set { _idCuttingFacing = value; OnPropertyChanged(nameof(IdCuttingFacing)); }
        }
        public int IdCuttingFacingSummary
        {
            get { return _idCuttingFacingSummary; }
            set { _idCuttingFacingSummary = value; OnPropertyChanged(nameof(IdCuttingFacingSummary)); }
        }
        public int IdPacking
        {
            get { return _idPacking; }
            set { _idPacking = value; OnPropertyChanged(nameof(IdPacking)); }
        }
        public int IdPackingSummary
        {
            get { return _idPackingSummary; }
            set { _idPackingSummary = value; OnPropertyChanged(nameof(IdPackingSummary)); }
        }
        public string NomenclatureProfile
        {
            get { return _nomenclatureProfile; }
            set { _nomenclatureProfile = value; OnPropertyChanged(nameof(NomenclatureProfile)); }
        }
        public string BasketNumber
        {
            get { return _basketNumber; }
            set { _basketNumber = value; OnPropertyChanged(nameof(BasketNumber)); }
        }
        private List<ShotBlastingProfilesGeneral> _shotBlastingProfilesGenerals;
        public List<ShotBlastingProfilesGeneral> ShotBlastingProfilesGeneral
        {
            get { return _shotBlastingProfilesGenerals; }
            set { _shotBlastingProfilesGenerals = value; OnPropertyChanged(nameof(ShotBlastingProfilesGeneral)); }
        }
        private List<HitchAluminumProfileGeneral> _hitchAluminumProfileGeneral;
        public List<HitchAluminumProfileGeneral> HitchAluminumProfileGeneral
        {
            get { return _hitchAluminumProfileGeneral; }
            set { _hitchAluminumProfileGeneral = value; OnPropertyChanged(nameof(HitchAluminumProfileGeneral)); }
        }
        private List<AnodizingProcessProfileGeneral> _anodizingProcessProfileGeneral;
        public List<AnodizingProcessProfileGeneral> AnodizingProcessProfileGeneral
        {
            get { return _anodizingProcessProfileGeneral; }
            set { _anodizingProcessProfileGeneral = value; OnPropertyChanged(nameof(AnodizingProcessProfileGeneral)); }
        }
        private List<TapeProtectiveProcessProfileGeneral> _tapeProtectiveProcessProfileGeneral;
        public List<TapeProtectiveProcessProfileGeneral> TapeProtectiveProcessProfileGeneral
        {
            get { return _tapeProtectiveProcessProfileGeneral; }
            set { _tapeProtectiveProcessProfileGeneral = value; OnPropertyChanged(nameof(TapeProtectiveProcessProfileGeneral)); }
        }
        private List<СuttingFacingGeneralProfile> _cuttingFacingGeneralProfile;
        public List<СuttingFacingGeneralProfile> СuttingFacingGeneralProfile
        {
            get { return _cuttingFacingGeneralProfile; }
            set { _cuttingFacingGeneralProfile = value; OnPropertyChanged(nameof(СuttingFacingGeneralProfile)); }
        }  
        private List<PackingAluminumProfileGeneral> _packingAluminumProfileGeneral;
        public List<PackingAluminumProfileGeneral> PackingAluminumProfileGeneral
        {
            get { return _packingAluminumProfileGeneral; }
            set { _packingAluminumProfileGeneral = value; OnPropertyChanged(nameof(PackingAluminumProfileGeneral)); }
        }
        public List<ShotBlastingProfileSummaryTable> _shotBlastingProfileSummaryTable = new List<ShotBlastingProfileSummaryTable>();
        public List<ShotBlastingProfileSummaryTable> ShotBlastingProfileSummaryTable
        {
            get { return _shotBlastingProfileSummaryTable; }
            set { _shotBlastingProfileSummaryTable = value; OnPropertyChanged(nameof(ShotBlastingProfileSummaryTable)); }
        }
        public List<AnodizingProcessProfileSummaryTable> _anodizingProcessProfileSummaryTable = new List<AnodizingProcessProfileSummaryTable>();
        public List<AnodizingProcessProfileSummaryTable> AnodizingProcessProfileSummaryTable
        {
            get { return _anodizingProcessProfileSummaryTable; }
            set { _anodizingProcessProfileSummaryTable = value; OnPropertyChanged(nameof(AnodizingProcessProfileSummaryTable)); }
        }

        public List<TapeProtectiveProcessProfileSummaryTable> _tapeProtectiveProcessProfileSummaryTable = new List<TapeProtectiveProcessProfileSummaryTable>();
        public List<TapeProtectiveProcessProfileSummaryTable> TapeProtectiveProcessProfileSummaryTable
        {
            get { return _tapeProtectiveProcessProfileSummaryTable; }
            set { _tapeProtectiveProcessProfileSummaryTable = value; OnPropertyChanged(nameof(TapeProtectiveProcessProfileSummaryTable)); }
        }
        public List<СuttingFacingProfileSummaryTable> _сuttingFacingProfileSummaryTable = new List<СuttingFacingProfileSummaryTable>();
        public List<СuttingFacingProfileSummaryTable> СuttingFacingProfileSummaryTable
        {
            get { return _сuttingFacingProfileSummaryTable; }
            set { _сuttingFacingProfileSummaryTable = value; OnPropertyChanged(nameof(СuttingFacingProfileSummaryTable)); }
        }
        public List<PackingAluminumProfileSummaryTable> _packingAluminumProfileSummaryTable = new List<PackingAluminumProfileSummaryTable>();
        public List<PackingAluminumProfileSummaryTable> PackingAluminumProfileSummaryTable
        {
            get { return _packingAluminumProfileSummaryTable; }
            set { _packingAluminumProfileSummaryTable = value; OnPropertyChanged(nameof(PackingAluminumProfileSummaryTable)); }
        }
        public ICommand ShowNewShotCommand { get; }
        public ICommand ShowShotCommand { get; }
        public ICommand ShowShotSummaryCommand { get; }
        public ICommand ShowRefreshGeneralCommand { get; }
        public ICommand ShowNewHitchAluminumProfileCommand { get; }
        public ICommand ShowHitchAluminumProfileCommand { get; }
        public ICommand ShowNewAnodizingProcessProfileCommand { get; }
        public ICommand ShowAnodizingAluminumProfileCommand { get; }
        public ICommand ShowAnodizingAluminumProfileSummaryCommand { get; }

        public ICommand ShowNewTypeProtectiveProfileCommand { get; }   
        public ICommand ShowTapeProtectiveProfileCommand { get; }
        public ICommand ShowTapeProtectiveProfileSummaryCommand { get; }
        public ICommand ShowNewСuttingFacingProfileCommand{ get; }
        public ICommand ShowСuttingFacingProfileCommand { get; }
        public ICommand ShowСuttingFacingProfileSummaryCommand { get; }
        public ICommand ShowNewPackingProfileCommand { get; }
        public ICommand ShowPackingProfileCommand { get; }
        public ICommand ShowPackingProfileSummaryCommand { get; }
        public ICommand ShowSaveShotBlastingProfilesGeneralCommand { get; }
        public ICommand ShowSaveAnodizingProcessProfileGeneralCommand { get; }
        public ICommand ShowCardProfileCommand { get; }
        public ICommand ShowPrintProfileCommand { get; }

        public ProductionProfileViewModel()
        {
            ShotBlastingProfilesGeneralsRepository reposBlasting = new ShotBlastingProfilesGeneralsRepository();
            //HitchAluminumProfileGeneralsRepository reposHitchAluminumProfile = new HitchAluminumProfileGeneralsRepository();
            AnodizingProcessProfileGeneralRepository reposAnodizingProcessProfileGeneral = new AnodizingProcessProfileGeneralRepository();
            TapeProtectiveProcessProfileGeneralRepository reposTapeProtective = new TapeProtectiveProcessProfileGeneralRepository();
            СuttingFacingGeneralProfileRepository reposCuttingFacingGeneralProfile = new СuttingFacingGeneralProfileRepository();
            PackingAluminumProfileGeneralRepository reposPackingAluminumProfileGeneralRepository = new PackingAluminumProfileGeneralRepository();

            ShotBlastingProfileRepository reposShot = new ShotBlastingProfileRepository();
            AnodizingProcessProfileRepository reposAnod =new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTape= new TapeProtectiveProcessProfileRepository();
            СuttingFacingProfileRepository reposСuttingFacing = new СuttingFacingProfileRepository();
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();

            ShotBlastingProfilesGeneral = reposBlasting.GetByAllEntity();
            //HitchAluminumProfileGeneral = reposHitchAluminumProfile.GetByAllEntity();
            AnodizingProcessProfileGeneral= reposAnodizingProcessProfileGeneral.GetByAllEntity();
            TapeProtectiveProcessProfileGeneral=reposTapeProtective.GetByAllEntity();
            СuttingFacingGeneralProfile = reposCuttingFacingGeneralProfile.GetByAllEntity();
            PackingAluminumProfileGeneral = reposPackingAluminumProfileGeneralRepository.GetByAllEntity();


            ShowNewShotCommand = new ViewModelCommand(NewShotCommand); //дробейструй новая смена
            ShowShotCommand = new ViewModelCommand(ShotCommand); //дробейструй открыть смену по номеру смены
            ShowShotSummaryCommand = new ViewModelCommand(ShotSummaryTableCommand); //дробейструй открыть смену по номеру профиля
            //ShowNewHitchAluminumProfileCommand = new ViewModelCommand(NewHitchAluminumProfileCommand);
            ShowNewAnodizingProcessProfileCommand = new ViewModelCommand(NewAnodizingProcessProfileCommand);//анодирование новая смена
            ShowAnodizingAluminumProfileCommand = new ViewModelCommand(AnodizingAluminumProfileCommand);//анодирование открыть смену по номеру смены
            ShowAnodizingAluminumProfileSummaryCommand = new ViewModelCommand(AnodizingAluminumProfileSummaryCommand);//анодирование открыть смену по номеру профиля
            ShowTapeProtectiveProfileSummaryCommand= new ViewModelCommand(TapeProtectiveProfileSummaryCommand);
            ShowСuttingFacingProfileSummaryCommand= new ViewModelCommand(СuttingFacingProfileSummaryCommand);
            ShowPackingProfileSummaryCommand = new ViewModelCommand(PackingAluminumSummaryCommand);

            ShowRefreshGeneralCommand = new ViewModelCommand(RefreshGeneralProfile);
            ShowTapeProtectiveProfileCommand = new ViewModelCommand(TapeProtectiveProfileCommand);
            ShowNewTypeProtectiveProfileCommand = new ViewModelCommand(NewTypeProtectiveProfileCommand);
            ShowNewСuttingFacingProfileCommand = new ViewModelCommand(NewСuttingFacingProfileCommand);
            ShowСuttingFacingProfileCommand= new ViewModelCommand(СuttingFacingProfileCommand);

            ShowNewPackingProfileCommand= new ViewModelCommand(NewPackingAluminumCommand);
            ShowPackingProfileCommand= new ViewModelCommand(PackingAluminumCommand);

            SummaryTableProfile = GetSummaryTableProfile();
            SummaryTableProfileCutting = GetSummaryTableProfileCutting();

            ShowSaveShotBlastingProfilesGeneralCommand = new ViewModelCommand(SaveChangeShotBlastingProfilesGeneral);
            ShowSaveAnodizingProcessProfileGeneralCommand = new ViewModelCommand(SaveChangeAnodizingProcessProfileGeneral);
            ShowCardProfileCommand = new ViewModelCommand(OpenCardProfileCommand);

            ShotBlastingProfileSummaryTable = reposShot.GetShotBlastingProfileSummaryTable();
            AnodizingProcessProfileSummaryTable = reposAnod.GetAnodizingProcessProfileSummaryTable();
            TapeProtectiveProcessProfileSummaryTable = reposTape.GetTapeProtectiveProcessProfileSummaryTable();
            СuttingFacingProfileSummaryTable = reposСuttingFacing.GetСuttingFacingGeneralProfileSummaryTable();
            PackingAluminumProfileSummaryTable = reposPacking.GetPackingAluminumProfileSummaryTable();

            ShowPrintProfileCommand = new ViewModelCommand(PrintLabelProfile);
        }
        
        void SaveChangeShotBlastingProfilesGeneral(object obj)
        {
            ShotBlastingProfilesGeneralsRepository reposBlasting = new ShotBlastingProfilesGeneralsRepository();
            foreach (var item in ShotBlastingProfilesGeneral)
            {
                reposBlasting.UpdateShotBlastingProfilesGeneral(item.Id, item.Downtime);
            }
            MessageBox.Show("Данные успешно сохранены.");
        }
        void SaveChangeAnodizingProcessProfileGeneral(object obj)
        {
            AnodizingProcessProfileGeneralRepository repos = new AnodizingProcessProfileGeneralRepository();
            foreach (var item in AnodizingProcessProfileGeneral)
            {
                repos.UpdateAnodizingProcessProfileGeneral(item.Id, item.Downtime);
            }
            MessageBox.Show("Данные успешно сохранены.");
        }
        /// <summary>
        /// Открыть новую смену ( Дробейструйная обработка )
        /// </summary>
        /// <param name="obj"></param>
        void NewShotCommand(object obj)
        {
            ShotBlastingProfilesGeneralsRepository repos = new ShotBlastingProfilesGeneralsRepository();
            ShotBlastingView shot = new ShotBlastingView();
            shot.Show();
        }
        
        /// <summary>
        /// Открыть отчет по сменам ( Дробейструйная обработка )
        /// </summary>
        /// <param name="obj"></param>
        void ShotCommand(object obj)
        {
            ShotBlastingView shot = new ShotBlastingView();
            shot.Show();
            ShotBlastingProfilesGeneralsRepository repos = new ShotBlastingProfilesGeneralsRepository();
            var list = repos.GetByEntity(Id);
            if (list != null)
            {
                shot.txtNumber.Text = list.NumberShotGeneral;
                shot.txtDate.Text = list.Date.ToString();
                shot.txtShift.Text = list.Shift;
            }
        }
        /// <summary>
        /// Открыть отчет по номеру профилю ( Дробейструйная обработка )
        /// </summary>
        /// <param name="obj"></param>
        void ShotSummaryTableCommand(object obj)
        {
            ShotBlastingView shot = new ShotBlastingView();
            shot.Show();
            ShotBlastingProfilesGeneralsRepository repos = new ShotBlastingProfilesGeneralsRepository();
            var list = repos.GetByEntity(IdShotSummary);
            if (list != null)
            {
                shot.txtNumber.Text = list.NumberShotGeneral;
                shot.txtDate.Text = list.Date.ToString();
                shot.txtShift.Text = list.Shift;
            }
        }
        
        /// <summary>
        /// Открыть новую смену ( Анодирование )
        /// </summary>
        /// <param name="obj"></param>
        void NewAnodizingProcessProfileCommand(object obj)
        {
            AnodizingProcessProfileView shot = new AnodizingProcessProfileView();
            shot.Show();
        }
        /// <summary>
        /// Открыть отчет по сменам ( Анодирование )
        /// </summary>
        /// <param name="obj"></param>
        void AnodizingAluminumProfileCommand(object obj)
        {
            AnodizingProcessProfileView anod = new AnodizingProcessProfileView();
            anod.Show();
            AnodizingProcessProfileGeneralRepository repos = new AnodizingProcessProfileGeneralRepository();
            var list = repos.GetByEntity(IdAnod);
            if (list != null)
            {
                anod.txtNumber.Text = list.NumberAnodizingProcess;
                anod.txtDate.Text = list.Date.ToString();
                anod.txtShift.Text = list.Shift;
            }
        }
        /// <summary>
        /// Открыть отчет по номеру профилю ( Анодирование )
        /// </summary>
        /// <param name="obj"></param>
        void AnodizingAluminumProfileSummaryCommand(object obj)
        {
            AnodizingProcessProfileView anod = new AnodizingProcessProfileView();
            anod.Show();
            AnodizingProcessProfileGeneralRepository repos = new AnodizingProcessProfileGeneralRepository();
            var list = repos.GetByEntity(IdAnodSummary);
            if (list != null)
            {
                anod.txtNumber.Text = list.NumberAnodizingProcess;
                anod.txtDate.Text = list.Date.ToString();
                anod.txtShift.Text = list.Shift;
            }
        }
        //void NewHitchAluminumProfileCommand(object obj)
        //{
        //    HitchAluminumProfileView hitch = new HitchAluminumProfileView();
        //    hitch.Show();
        //}
        void NewTypeProtectiveProfileCommand(object obj)
        {
            TapeProtectiveProcessProfileView typeProtective = new TapeProtectiveProcessProfileView();
            typeProtective.Show();
        }
        void TapeProtectiveProfileCommand(object obj)
        {
            TapeProtectiveProcessProfileView tape = new TapeProtectiveProcessProfileView();
            tape.Show();
            TapeProtectiveProcessProfileGeneralRepository repos = new TapeProtectiveProcessProfileGeneralRepository();
            var list = repos.GetByEntity(IdTapeProtective);
            if (list != null)
            {
                tape.txtNumber.Text = list.NumberTapeProtectiveProcess;
                tape.txtDate.Text = list.Date.ToString();
                tape.txtShift.Text = list.Shift;
            }
        }
        void TapeProtectiveProfileSummaryCommand(object obj)
        {
            TapeProtectiveProcessProfileView tape = new TapeProtectiveProcessProfileView();

            tape.Show();
            TapeProtectiveProcessProfileGeneralRepository repos = new TapeProtectiveProcessProfileGeneralRepository();
            var list = repos.GetByEntity(IdTapeProtectiveSummary);
            if (list != null)
            {
                tape.txtNumber.Text = list.NumberTapeProtectiveProcess;
                tape.txtDate.Text = list.Date.ToString();
                tape.txtShift.Text = list.Shift;
            }
        }
        void NewСuttingFacingProfileCommand(object obj)
        {
            //СuttingFacingProfileView cuttingFacing = new СuttingFacingProfileView();
            СuttingFacingProfileTwoView cuttingFacing = new СuttingFacingProfileTwoView();
            cuttingFacing.Show();
        }
        void СuttingFacingProfileCommand(object obj)
        {
            СuttingFacingProfileTwoView cuttingFacing = new СuttingFacingProfileTwoView();
            cuttingFacing.Show();
            СuttingFacingGeneralProfileRepository repos = new СuttingFacingGeneralProfileRepository();
            var list = repos.GetByEntity(IdCuttingFacing);
            if (list != null)
            {
                cuttingFacing.txtNumber.Text = list.NumberСuttingFacing;
                cuttingFacing.txtDate.Text = list.Date.ToString();
                cuttingFacing.txtShift.Text = list.Shift;
            }
        }
        void СuttingFacingProfileSummaryCommand(object obj)
        {
            СuttingFacingProfileTwoView cuttingFacing = new СuttingFacingProfileTwoView();
            
            cuttingFacing.Show();
            СuttingFacingGeneralProfileRepository repos = new СuttingFacingGeneralProfileRepository();
            var list = repos.GetByEntity(IdCuttingFacingSummary);
            if (list != null)
            {
                cuttingFacing.txtNumber.Text = list.NumberСuttingFacing;
                cuttingFacing.txtDate.Text = list.Date.ToString();
                cuttingFacing.txtShift.Text = list.Shift;
            }
        }
        void NewPackingAluminumCommand(object obj)
        {
            PackingAluminumProfileView packing = new PackingAluminumProfileView();
            packing.Show();
        }
        void PackingAluminumCommand(object obj)
        {
            PackingAluminumProfileView packing = new PackingAluminumProfileView();
            packing.Show();
            PackingAluminumProfileGeneralRepository repos = new PackingAluminumProfileGeneralRepository();
            var list = repos.GetByEntity(IdPacking);
            if (list != null)
            {
                packing.txtNumber.Text = list.NumberPackingAluminumProfile;
                packing.txtDate.Text = list.Date.ToString();
                packing.txtShift.Text = list.Shift;
            }
        }
        void PackingAluminumSummaryCommand(object obj)
        {
            PackingAluminumProfileView packing = new PackingAluminumProfileView();
            packing.Show();
            PackingAluminumProfileGeneralRepository repos = new PackingAluminumProfileGeneralRepository();
            var list = repos.GetByEntity(IdPackingSummary);
            if (list != null)
            {
                packing.txtNumber.Text = list.NumberPackingAluminumProfile;
                packing.txtDate.Text = list.Date.ToString();
                packing.txtShift.Text = list.Shift;
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
        void OpenCardProfileCommand(object obj)
        {
            {
                ProfileCardRepository profileRepos = new ProfileCardRepository();
                int id = profileRepos.GetIdEntity(NomenclatureProfile);
                ImageProfileRepository imageRepos = new ImageProfileRepository();
                ImageProfileParkingRepository imageReposParking = new ImageProfileParkingRepository();
                ImageProfile image = new ImageProfile();
                ImageProfileParking imageParking = new ImageProfileParking();
                image = imageRepos.GetByExaminationNomenclature(Convert.ToInt32(id));
                imageParking = imageReposParking.GetByExaminationNomenclature(Convert.ToInt32(id));
                ProfileCardView profileCard = new ProfileCardView();
                profileCard.Show();
                ProfileCard card = new ProfileCard();
                card = profileRepos.GetByEntity(Convert.ToInt32(id));
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
                    profileCard.imagePallet.Source = imageSourceParking;
                }
            }
        }

            void RefreshGeneralProfile(object obj)
        {
            ShotBlastingProfilesGeneralsRepository reposBlasting = new ShotBlastingProfilesGeneralsRepository();
            AnodizingProcessProfileGeneralRepository reposAnodizingProcessProfileGeneral = new AnodizingProcessProfileGeneralRepository();
            TapeProtectiveProcessProfileGeneralRepository reposTapeProtective = new TapeProtectiveProcessProfileGeneralRepository();
            СuttingFacingGeneralProfileRepository reposCuttingFacingGeneralProfile = new СuttingFacingGeneralProfileRepository();
            PackingAluminumProfileGeneralRepository reposPackingAluminumProfileGeneralRepository = new PackingAluminumProfileGeneralRepository();

            ShotBlastingProfileRepository reposShot = new ShotBlastingProfileRepository();
            AnodizingProcessProfileRepository reposAnod = new AnodizingProcessProfileRepository();
            TapeProtectiveProcessProfileRepository reposTape = new TapeProtectiveProcessProfileRepository();
            СuttingFacingProfileRepository reposСuttingFacing = new СuttingFacingProfileRepository();
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();

            ShotBlastingProfilesGeneral = reposBlasting.GetByAllEntity();
            AnodizingProcessProfileGeneral = reposAnodizingProcessProfileGeneral.GetByAllEntity();
            TapeProtectiveProcessProfileGeneral = reposTapeProtective.GetByAllEntity();
            СuttingFacingGeneralProfile = reposCuttingFacingGeneralProfile.GetByAllEntity();
            PackingAluminumProfileGeneral = reposPackingAluminumProfileGeneralRepository.GetByAllEntity();
            SummaryTableProfile = GetSummaryTableProfile();
            SummaryTableProfileCutting = GetSummaryTableProfileCutting();
            ShotBlastingProfileSummaryTable = reposShot.GetShotBlastingProfileSummaryTable();
            AnodizingProcessProfileSummaryTable = reposAnod.GetAnodizingProcessProfileSummaryTable();
            TapeProtectiveProcessProfileSummaryTable = reposTape.GetTapeProtectiveProcessProfileSummaryTable();
            СuttingFacingProfileSummaryTable = reposСuttingFacing.GetСuttingFacingGeneralProfileSummaryTable();
            PackingAluminumProfileSummaryTable = reposPacking.GetPackingAluminumProfileSummaryTable();
        }
        public List<SummaryTableProfile> GetSummaryTableProfile()
        {
            List<SummaryTableProfile> list = new List<SummaryTableProfile>();
            SpecificationAllDescriptionRepository reposSpecification = new SpecificationAllDescriptionRepository();
            List<ForPivotTableSpecification> listSpecification = new List<ForPivotTableSpecification>();
            listSpecification = reposSpecification.GetForPivotTableSpecification();// спецификация
            ProfileCardRepository reposProfileCard = new ProfileCardRepository();
            List<ForPivotTableProfileCard> listProfileCard = new List<ForPivotTableProfileCard>();
            listProfileCard = reposProfileCard.GetForPivotTableProfileCard();// карта профиля 
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();
            List<ForPivotTableDetailReceptionMaterials> listDetailReceptionMaterials = new List<ForPivotTableDetailReceptionMaterials>();
            listDetailReceptionMaterials = reposReception.GetForPivotTableDetailReceptionMaterials();// прием сырья
            ShotBlastingProfileRepository reposShotBlasting = new ShotBlastingProfileRepository();
            List<ForPivotTableShotBlastingProfile> listShotBlasting = new List<ForPivotTableShotBlastingProfile>();
            listShotBlasting = reposShotBlasting.GetForPivotTableShotBlastingProfile(); // дробейструйная обработка
            //HitchAluminumProfilesRepository reposHitchAluminum = new HitchAluminumProfilesRepository();
            //List<ForPivotTableHitchAluminumProfile> listHitchAluminum = new List<ForPivotTableHitchAluminumProfile>();
            //listHitchAluminum = reposHitchAluminum.GetForPivotTableHitchAluminumProfile();// навеска
            AnodizingProcessProfileRepository reposAnodizingProcessProfile = new AnodizingProcessProfileRepository();
            List<ForPivotTableAnodizingProcessProfile> listAnodizingProcessProfile = new List<ForPivotTableAnodizingProcessProfile>();
            listAnodizingProcessProfile = reposAnodizingProcessProfile.GetForPivotTableAnodizingProcessProfile();// анодирование
            TapeProtectiveProcessProfileRepository reposTapeProtective = new TapeProtectiveProcessProfileRepository();
            List<ForPivotTableTapeProtectiveProcessProfile> listTapeProtectiveProcessProfile = new List<ForPivotTableTapeProtectiveProcessProfile>();
            listTapeProtectiveProcessProfile = reposTapeProtective.GetForPivotTableTapeProtectiveProcessProfile();// наклейка
            СuttingFacingProfileRepository reposСuttingFacing = new СuttingFacingProfileRepository();
            List<ForPivotTableСuttingFacingProfile> listСuttingFacingProfile = new List<ForPivotTableСuttingFacingProfile>();
            listСuttingFacingProfile = reposСuttingFacing.GetForPivotTableСuttingFacingProfile();// резка
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
            List<ForPivotTablePackingAluminumProfile> listPacking = new List<ForPivotTablePackingAluminumProfile>();
            listPacking = reposPacking.GetForPivotTablePackingAluminumProfile();// упаковка
            ProfileConsumptionWarehouseRepository reposProfileConsumptionWarehouse = new ProfileConsumptionWarehouseRepository();
            List<ForPivotTableProfileConsumptionWarehouse> listProfileConsumptionWarehouse = new List<ForPivotTableProfileConsumptionWarehouse>();
            listProfileConsumptionWarehouse = reposProfileConsumptionWarehouse.GetForPivotTableProfileConsumptionWarehouse();
            var listGeneral = from l1 in listSpecification
                              join l2 in listProfileCard on l1.NomenclatureProfile.Trim() equals l2.NomenclatureProfile.Trim()
                              into temp2
                              from lj2 in temp2.DefaultIfEmpty()
                              join l3 in listDetailReceptionMaterials on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l3.NomenclatureProfile, l3.NumberSpecification }
                              into temp3
                              from lj3 in temp3.DefaultIfEmpty()
                              join l4 in listShotBlasting on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l4.NomenclatureProfile, l4.NumberSpecification }
                              into temp4
                              from lj4 in temp4.DefaultIfEmpty()
                              join l6 in listAnodizingProcessProfile on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l6.NomenclatureProfile, l6.NumberSpecification }
                              into temp6
                              from lj6 in temp6.DefaultIfEmpty()
                              join l7 in listTapeProtectiveProcessProfile on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l7.NomenclatureProfile, l7.NumberSpecification }
                              into temp7
                              from lj7 in temp7.DefaultIfEmpty()
                              join l8 in listСuttingFacingProfile on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l8.NomenclatureProfile, l8.NumberSpecification }
                              into temp8
                              from lj8 in temp8.DefaultIfEmpty()
                              join l9 in listPacking on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l9.NomenclatureProfile, l9.NumberSpecification }
                              into temp9
                              from lj9 in temp9.DefaultIfEmpty()
                              join l10 in listProfileConsumptionWarehouse on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l10.NomenclatureProfile, l10.NumberSpecification }
                              into temp10
                              from lj10 in temp10.DefaultIfEmpty()
                              select new SummaryTableProfile
                              {
                                  NumberSpecification = l1.NumberSpecification,
                                  NomenclatureProfile = l1.NomenclatureProfile,
                                  Annotation=l1.Annotation,
                                  EloksalNoCommercial =  lj2 == null ? String.Empty : lj2.EloksalNoCommercial,
                                  ClientName = lj2 == null ? String.Empty : lj2.ClientName,
                                  AmountPiece = Convert.ToInt16(l1.AmountPiece),
                                  LenghtProfile = lj2 == null ? 0 : lj2.LenghtProfile,
                                  LenghtProfileFact = l1.LenghtProfileFact,
                                  AmountPieceFact = Convert.ToInt16(l1.AmountPieceFact),
                                  WeightMeter = lj2 == null ? 0 : lj2.WeightMeter,
                                  DateReception = lj3.DateReception,
                                  DateShipment = lj3.DateShipment,
                                  AmountPieceReceptionAccepted = lj3 == null ? 0 : lj3.AmountPieceReceptionAccepted,
                                  LenghtReceptionAccepted = lj3 == null ? 0 : Convert.ToDouble(lj3.LenghtReceptionAccepted),
                                  WeightReceptionAccepted = lj3 == null ? 0 : Convert.ToDouble(lj3.WeightReceptionAccepted),

                                  AmountPieceShotBlastingProfile = lj4 == null ? 0 : Convert.ToInt16(lj4.AmountPieceShotBlastingProfile),
                                  LenghtShotBlastingProfile = lj4 == null ? 0 : Convert.ToDouble(lj4.LenghtShotBlastingProfile),
                                  WeightShotBlastingProfile = lj4 == null ? 0 : Convert.ToDouble(lj4.WeightShotBlastingProfile),
                                  AmountPieceShotBlastingProfileBrak = lj4 == null ? 0 : Convert.ToInt16(lj4.AmountPieceShotBlastingProfileBrak),
                                  LenghtShotBlastingProfileBrak = lj4 == null ? 0 : Convert.ToDouble(lj4.LenghtShotBlastingProfileBrak),
                                  WeightShotBlastingProfileBrak = lj4 == null ? 0 : Convert.ToDouble(lj4.WeightShotBlastingProfileBrak),

                                  AmountPieceAnodizingProcessProfile = lj6 == null ? 0 : Convert.ToInt16(lj6.AmountPieceAnodizingProcessProfile),
                                  LenghtAnodizingProcessProfile = lj6 == null ? 0 : Convert.ToDouble(lj6.LenghtAnodizingProcessProfile),
                                  WeightAnodizingProcessProfile = lj6 == null ? 0 : Convert.ToDouble(lj6.WeightAnodizingProcessProfile),
                                  AmountPieceAnodizingProcessProfileBrak = lj6 == null ? 0 : Convert.ToInt16(lj6.AmountPieceAnodizingProcessProfileBrak),
                                  LenghtAnodizingProcessProfileBrak = lj6 == null ? 0 : Convert.ToDouble(lj6.LenghtAnodizingProcessProfileBrak),
                                  WeightAnodizingProcessProfileBrak = lj6 == null ? 0 : Convert.ToDouble(lj6.WeightAnodizingProcessProfileBrak),

                                  AmountTapeProtectiveProcessProfile = lj7 == null ? 0 : Convert.ToInt16(lj7.AmountPieceTapeProtectiveProcessProfile),
                                  LenghtTapeProtectiveProcessProfile = lj7 == null ? 0 : Convert.ToDouble(lj7.LenghtTapeProtectiveProcessProfile),
                                  WeightTapeProtectiveProcessProfile = lj7 == null ? 0 : Convert.ToDouble(lj7.WeightTapeProtectiveProcessProfile),
                                  AmountPieceTapeProtectiveProcessProfileBrak = lj7 == null ? 0 : Convert.ToInt16(lj7.AmountPieceTapeProtectiveProcessProfileBrak),
                                  LenghtTapeProtectiveProcessProfileBrak = lj7 == null ? 0 : Convert.ToDouble(lj7.LenghtTapeProtectiveProcessProfileBrak),
                                  WeightTapeProtectiveProcessProfileBrak = lj7 == null ? 0 : Convert.ToDouble(lj7.WeightTapeProtectiveProcessProfileBrak),

                                  AmountСuttingFacingProfile = lj8 == null ? 0 : Convert.ToInt16(lj8.AmountPieceСuttingFacingProfile),
                                  LenghtСuttingFacingProfile = lj8 == null ? 0 : Convert.ToDouble(lj8.LenghtСuttingFacingProfile),
                                  WeightСuttingFacingProfile = lj8 == null ? 0 : Convert.ToDouble(lj8.WeightСuttingFacingProfile),
                                  AmountPieceСuttingFacingProfileBrak = lj8 == null ? 0 : Convert.ToInt16(lj8.AmountPieceСuttingFacingProfileBrak),
                                  LenghtСuttingFacingProfileBrak = lj8 == null ? 0 : Convert.ToDouble(lj8.LenghtСuttingFacingProfileBrak),
                                  WeightСuttingFacingProfileBrak = lj8 == null ? 0 : Convert.ToDouble(lj8.WeightСuttingFacingProfileBrak),

                                  AmountPackingAluminumProfile = lj9 == null ? 0 : Convert.ToInt16(lj9.AmountPiecePackingAluminumProfile),
                                  LenghtPackingAluminumProfile = lj9 == null ? 0 : Convert.ToDouble(lj9.LenghtPackingAluminumProfile),
                                  WeightPackingAluminumProfile = lj9 == null ? 0 : Convert.ToDouble(lj9.WeightPackingAluminumProfile),
                                  AmountPiecePackingAluminumProfileBrak = lj9 == null ? 0 : Convert.ToInt16(lj9.AmountPiecePackingAluminumProfileBrak),
                                  LenghtPackingAluminumProfileBrak = lj9 == null ? 0 : Convert.ToDouble(lj9.LenghtPackingAluminumProfileBrak),
                                  WeightPackingAluminumProfileBrak = lj9 == null ? 0 : Convert.ToDouble(lj9.WeightPackingAluminumProfileBrak),

                                  AmountProfileConsumptionWarehouse = lj10 == null ? 0 : Convert.ToInt16(lj10.AmountPieceProfileConsumptionWarehouse),
                                  LenghtProfileConsumptionWarehouse = lj10 == null ? 0 : Convert.ToDouble(lj10.LenghtProfileConsumptionWarehouse),
                                  WeightProfileConsumptionWarehouse = lj10 == null ? 0 : Convert.ToDouble(lj10.WeightProfileConsumptionWarehouse),
                                  //AmountProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToInt16(lj10.AmountPieceProfileConsumptionWarehouseBrak),
                                  //LenghtProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToDouble(lj10.LenghtProfileConsumptionWarehouseBrak),
                                  //WeightProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToDouble(lj10.WeightProfileConsumptionWarehouseBrak)
                              };
            if (listGeneral != null)
            {
                list = listGeneral.AsEnumerable().Where(p=>p.DateReception >= new DateTime(2024, 12, 1))
                    .OrderByDescending(p => p.NumberSpecification)
                    .OrderByDescending(p=>p.DateReception)
                    .ToList();
            }

            return list;
        }
        public List<SummaryTableProfileCutting> GetSummaryTableProfileCutting()
        {
            List<SummaryTableProfileCutting> list = new List<SummaryTableProfileCutting>();
            SpecificationAllDescriptionRepository reposSpecification = new SpecificationAllDescriptionRepository();
            List<ForPivotTableSpecificationTwo> listSpecification = new List<ForPivotTableSpecificationTwo>();
            listSpecification = reposSpecification.GetForPivotTableSpecificationTwo();// спецификация
            ProfileCardRepository reposProfileCard = new ProfileCardRepository();
            List<ForPivotTableProfileCard> listProfileCard = new List<ForPivotTableProfileCard>();
            listProfileCard = reposProfileCard.GetForPivotTableProfileCardTwo();// карта профиля 
            DetailReceptionMaterialsRepository reposReception = new DetailReceptionMaterialsRepository();
            List<ForPivotTableDetailReceptionMaterialsTwo> listDetailReceptionMaterials = new List<ForPivotTableDetailReceptionMaterialsTwo>();
            listDetailReceptionMaterials = reposReception.GetForPivotTableDetailReceptionMaterialsTwo();// прием сырья
            ShotBlastingProfileRepository reposShotBlasting = new ShotBlastingProfileRepository();
            List<ForPivotTableShotBlastingProfileTwo> listShotBlasting = new List<ForPivotTableShotBlastingProfileTwo>();
            listShotBlasting = reposShotBlasting.GetForPivotTableShotBlastingProfileTwo(); // дробейструйная обработка
            AnodizingProcessProfileRepository reposAnodizingProcessProfile = new AnodizingProcessProfileRepository();
            List<ForPivotTableAnodizingProcessProfileTwo> listAnodizingProcessProfile = new List<ForPivotTableAnodizingProcessProfileTwo>();
            listAnodizingProcessProfile = reposAnodizingProcessProfile.GetForPivotTableAnodizingProcessProfileTwo();// анодирование
            TapeProtectiveProcessProfileRepository reposTapeProtective = new TapeProtectiveProcessProfileRepository();
            List<ForPivotTableTapeProtectiveProcessProfile> listTapeProtectiveProcessProfile = new List<ForPivotTableTapeProtectiveProcessProfile>();
            listTapeProtectiveProcessProfile = reposTapeProtective.GetForPivotTableTapeProtectiveProcessProfile();// наклейка
            СuttingFacingProfileRepository reposСuttingFacing = new СuttingFacingProfileRepository();
            List<ForPivotTableСuttingFacingProfileTwo> listСuttingFacingProfile = new List<ForPivotTableСuttingFacingProfileTwo>();
            listСuttingFacingProfile = reposСuttingFacing.GetForPivotTableСuttingTwoFacingProfile();// резка
            PackingAluminumProfileRepository reposPacking = new PackingAluminumProfileRepository();
            List<ForPivotTablePackingAluminumProfile> listPacking = new List<ForPivotTablePackingAluminumProfile>();
            listPacking = reposPacking.GetForPivotTablePackingAluminumProfile();// упаковка
            ProfileConsumptionWarehouseRepository reposProfileConsumptionWarehouse = new ProfileConsumptionWarehouseRepository();
            List<ForPivotTableProfileConsumptionWarehouse> listProfileConsumptionWarehouse = new List<ForPivotTableProfileConsumptionWarehouse>();
            listProfileConsumptionWarehouse = reposProfileConsumptionWarehouse.GetForPivotTableProfileConsumptionWarehouse();
            var listGeneral = from l1 in listСuttingFacingProfile
                              join l2 in listProfileCard on l1.NomenclatureProfile.Trim() equals l2.NomenclatureProfile.Trim()
                              into temp2
                              from lj2 in temp2.DefaultIfEmpty()
                              join l3 in listDetailReceptionMaterials on new { l1.GeneralNomenclatureProfile, l1.NumberSpecification } equals new { l3.GeneralNomenclatureProfile, l3.NumberSpecification }
                              into temp3
                              from lj3 in temp3.DefaultIfEmpty()
                              join l4 in listShotBlasting on new { l1.GeneralNomenclatureProfile, l1.NumberSpecification } equals new { l4.GeneralNomenclatureProfile, l4.NumberSpecification }
                              into temp4
                              from lj4 in temp4.DefaultIfEmpty()
                              join l6 in listAnodizingProcessProfile on new { l1.GeneralNomenclatureProfile, l1.NumberSpecification } equals new { l6.GeneralNomenclatureProfile, l6.NumberSpecification }
                              into temp6
                              from lj6 in temp6.DefaultIfEmpty()
                              join l7 in listTapeProtectiveProcessProfile on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l7.NomenclatureProfile, l7.NumberSpecification }
                              into temp7
                              from lj7 in temp7.DefaultIfEmpty()
                              join l5 in listSpecification on new { l1.GeneralNomenclatureProfile, l1.NumberSpecification } equals new { l5.GeneralNomenclatureProfile, l5.NumberSpecification }
                              into temp5
                              from lj5 in temp5.DefaultIfEmpty()
                              join l9 in listPacking on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l9.NomenclatureProfile, l9.NumberSpecification }
                              into temp9
                              from lj9 in temp9.DefaultIfEmpty()
                              join l10 in listProfileConsumptionWarehouse on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l10.NomenclatureProfile, l10.NumberSpecification }
                              into temp10
                              from lj10 in temp10.DefaultIfEmpty()
                              select new SummaryTableProfileCutting
                              {
                                  NumberSpecification = l1.NumberSpecification,
                                  NomenclatureProfile = l1.NomenclatureProfile,
                                  GeneralNomenclatureProfile = l1.GeneralNomenclatureProfile,
                                  Annotation = lj5.Annotation,
                                  EloksalNoCommercial = lj2 == null ? String.Empty : lj2.EloksalNoCommercial,
                                  ClientName = lj2 == null ? String.Empty : lj2.ClientName,
                                  AmountPiece = lj5 == null ? 0 : Convert.ToInt16(lj5.AmountPiece),
                                  LenghtProfile = lj2 == null ? 0 : lj2.LenghtProfile,
                                  LenghtProfileFact = lj5 == null ? 0 : lj5.LenghtProfileFact,
                                  AmountPieceFact = Convert.ToInt16(lj5.AmountPieceFact),
                                  WeightMeter = lj2 == null ? 0 : lj2.WeightMeter,
                                  DateReception = lj3.DateReception,
                                  DateShipment = lj3.DateShipment,
                                  AmountPieceReceptionAccepted = lj3 == null ? 0 : lj3.AmountPieceReceptionAccepted,
                                  LenghtReceptionAccepted = lj3 == null ? 0 : Convert.ToDouble(lj3.LenghtReceptionAccepted),
                                  WeightReceptionAccepted = lj3 == null ? 0 : Convert.ToDouble(lj3.WeightReceptionAccepted),

                                  AmountPieceShotBlastingProfile = lj4 == null ? 0 : Convert.ToInt16(lj4.AmountPieceShotBlastingProfile),
                                  LenghtShotBlastingProfile = lj4 == null ? 0 : Convert.ToDouble(lj4.LenghtShotBlastingProfile),
                                  WeightShotBlastingProfile = lj4 == null ? 0 : Convert.ToDouble(lj4.WeightShotBlastingProfile),
                                  AmountPieceShotBlastingProfileBrak = lj4 == null ? 0 : Convert.ToInt16(lj4.AmountPieceShotBlastingProfileBrak),
                                  LenghtShotBlastingProfileBrak = lj4 == null ? 0 : Convert.ToDouble(lj4.LenghtShotBlastingProfileBrak),
                                  WeightShotBlastingProfileBrak = lj4 == null ? 0 : Convert.ToDouble(lj4.WeightShotBlastingProfileBrak),

                                  AmountPieceAnodizingProcessProfile = lj6 == null ? 0 : Convert.ToInt16(lj6.AmountPieceAnodizingProcessProfile),
                                  LenghtAnodizingProcessProfile = lj6 == null ? 0 : Convert.ToDouble(lj6.LenghtAnodizingProcessProfile),
                                  WeightAnodizingProcessProfile = lj6 == null ? 0 : Convert.ToDouble(lj6.WeightAnodizingProcessProfile),
                                  AmountPieceAnodizingProcessProfileBrak = lj6 == null ? 0 : Convert.ToInt16(lj6.AmountPieceAnodizingProcessProfileBrak),
                                  LenghtAnodizingProcessProfileBrak = lj6 == null ? 0 : Convert.ToDouble(lj6.LenghtAnodizingProcessProfileBrak),
                                  WeightAnodizingProcessProfileBrak = lj6 == null ? 0 : Convert.ToDouble(lj6.WeightAnodizingProcessProfileBrak),

                                  AmountTapeProtectiveProcessProfile = lj7 == null ? 0 : Convert.ToInt16(lj7.AmountPieceTapeProtectiveProcessProfile),
                                  LenghtTapeProtectiveProcessProfile = lj7 == null ? 0 : Convert.ToDouble(lj7.LenghtTapeProtectiveProcessProfile),
                                  WeightTapeProtectiveProcessProfile = lj7 == null ? 0 : Convert.ToDouble(lj7.WeightTapeProtectiveProcessProfile),
                                  AmountPieceTapeProtectiveProcessProfileBrak = lj7 == null ? 0 : Convert.ToInt16(lj7.AmountPieceTapeProtectiveProcessProfileBrak),
                                  LenghtTapeProtectiveProcessProfileBrak = lj7 == null ? 0 : Convert.ToDouble(lj7.LenghtTapeProtectiveProcessProfileBrak),
                                  WeightTapeProtectiveProcessProfileBrak = lj7 == null ? 0 : Convert.ToDouble(lj7.WeightTapeProtectiveProcessProfileBrak),

                                  AmountСuttingFacingProfile = l1 == null ? 0 : Convert.ToInt16(l1.AmountPieceСuttingFacingProfile),
                                  LenghtСuttingFacingProfile = l1 == null ? 0 : Convert.ToDouble(l1.LenghtСuttingFacingProfile),
                                  WeightСuttingFacingProfile = l1 == null ? 0 : Convert.ToDouble(l1.WeightСuttingFacingProfile),
                                  AmountPieceСuttingFacingProfileBrak = l1 == null ? 0 : Convert.ToInt16(l1.AmountPieceСuttingFacingProfileBrak),
                                  LenghtСuttingFacingProfileBrak = l1 == null ? 0 : Convert.ToDouble(l1.LenghtСuttingFacingProfileBrak),
                                  WeightСuttingFacingProfileBrak = l1 == null ? 0 : Convert.ToDouble(l1.WeightСuttingFacingProfileBrak),

                                  AmountPackingAluminumProfile = lj9 == null ? 0 : Convert.ToInt16(lj9.AmountPiecePackingAluminumProfile),
                                  LenghtPackingAluminumProfile = lj9 == null ? 0 : Convert.ToDouble(lj9.LenghtPackingAluminumProfile),
                                  WeightPackingAluminumProfile = lj9 == null ? 0 : Convert.ToDouble(lj9.WeightPackingAluminumProfile),
                                  AmountPiecePackingAluminumProfileBrak = lj9 == null ? 0 : Convert.ToInt16(lj9.AmountPiecePackingAluminumProfileBrak),
                                  LenghtPackingAluminumProfileBrak = lj9 == null ? 0 : Convert.ToDouble(lj9.LenghtPackingAluminumProfileBrak),
                                  WeightPackingAluminumProfileBrak = lj9 == null ? 0 : Convert.ToDouble(lj9.WeightPackingAluminumProfileBrak),

                                  AmountProfileConsumptionWarehouse = lj10 == null ? 0 : Convert.ToInt16(lj10.AmountPieceProfileConsumptionWarehouse),
                                  LenghtProfileConsumptionWarehouse = lj10 == null ? 0 : Convert.ToDouble(lj10.LenghtProfileConsumptionWarehouse),
                                  WeightProfileConsumptionWarehouse = lj10 == null ? 0 : Convert.ToDouble(lj10.WeightProfileConsumptionWarehouse),
                                  //AmountProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToInt16(lj10.AmountPieceProfileConsumptionWarehouseBrak),
                                  //LenghtProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToDouble(lj10.LenghtProfileConsumptionWarehouseBrak),
                                  //WeightProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToDouble(lj10.WeightProfileConsumptionWarehouseBrak)
                              };
            if (listGeneral != null)
            {
                list = listGeneral.AsEnumerable().Where(p => p.DateReception >= new DateTime(2024, 12, 1))
                    .OrderByDescending(p => p.NumberSpecification)
                    .OrderByDescending(p => p.DateReception)
                    .ToList();
            }

            return list;
        }

    }
}
