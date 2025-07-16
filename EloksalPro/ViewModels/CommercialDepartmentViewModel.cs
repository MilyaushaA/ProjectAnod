using EloksalPro.Models;
using EloksalPro.Repositories;
using EloksalPro.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EloksalPro.ViewModels
{
    public class CommercialDepartmentViewModel : ViewModelBase
    {
        private List<PriceListProfile> _priceListProfile = new List<PriceListProfile>();
        private List<SummaryTableProfile> _summaryTableProfile = new List<SummaryTableProfile>();
        private List<SpecificationEloksalProfileDif> _specificationEloksalProfile = new List<SpecificationEloksalProfileDif>();
        List<CommercialOfferGeneral> _commercialOfferGeneral = new List<CommercialOfferGeneral>();
        List<DataPlanProfile> _dataPlanProfile = new List<DataPlanProfile>();
        List<DataPlanProfileGenaral> _dataPlanProfileGeneral = new List<DataPlanProfileGenaral>();
      
        private int _idPrice;
        private int _idOffer;
        private int _specificationId;
       
        public List<PriceListProfile> PriceListProfile
        {
            get { return _priceListProfile; }
            set { _priceListProfile = value; OnPropertyChanged(nameof(PriceListProfile)); }
        }
        public List<SpecificationEloksalProfileDif> SpecificationEloksalProfile
        {
            get { return _specificationEloksalProfile; }
            set { _specificationEloksalProfile = value; OnPropertyChanged(nameof(SpecificationEloksalProfile)); }
        }
        public List<SummaryTableProfile> SummaryTableProfile
        {
            get { return _summaryTableProfile; }
            set { _summaryTableProfile = value; OnPropertyChanged(nameof(SummaryTableProfile)); }
        }
        public List<CommercialOfferGeneral> CommercialOfferGeneral
        {
            get { return _commercialOfferGeneral; }
            set { _commercialOfferGeneral = value; OnPropertyChanged(nameof(CommercialOfferGeneral)); }
        }
        public List<DataPlanProfile> DataPlanProfile
        {
            get { return _dataPlanProfile; }
            set { _dataPlanProfile = value; OnPropertyChanged(nameof(DataPlanProfile)); }
        }
        public List<DataPlanProfileGenaral> DataPlanProfileGeneral
        {
            get { return _dataPlanProfileGeneral; }
            set { _dataPlanProfileGeneral = value; OnPropertyChanged(nameof(DataPlanProfileGeneral)); }
        }
        public int IdPrice
        {
            get { return _idPrice; }
            set { _idPrice = value; OnPropertyChanged(nameof(IdPrice)); }
        }
        public int SpecificationId
        {
            get { return _specificationId; }
            set { _specificationId = value; OnPropertyChanged(nameof(SpecificationId)); }
        }
    
        public int IdOffer
        {
            get { return _idOffer; }
            set { _idOffer = value; OnPropertyChanged(nameof(IdOffer)); }
        }
        public ICommand ShowPriceProfileCommand { get; }
        public ICommand OpenProfilePriceCommand { get; }
        public ICommand RefreshAllProfileCommand { get; }
        public ICommand ShowSpecificationCommand { get; }
        public ICommand ShowCardSpecificationCommand { get; }
        public ICommand ShowNewCommercialOfferCommand { get; }
        public ICommand ShowCommercialOfferCommand { get; }
        public ICommand ShowNewDataPlanCommand { get; }

        public CommercialDepartmentViewModel()
        {
            //PriceListProfileRepository priceRepos = new PriceListProfileRepository();
            //SpecificationEloksalProfileRepository specificationEloksalProfileRepository = new SpecificationEloksalProfileRepository();
            //ReceptionMaterialsRepository reposReception = new ReceptionMaterialsRepository();
            //CommercialOfferGeneralRepository reposOffer = new CommercialOfferGeneralRepository();
            //DataofPlanRepository reposPlanDate = new DataofPlanRepository();
            //SpecificationEloksalProfile = specificationEloksalProfileRepository.ChangeDifData();
            //ReceptionMaterials = reposReception.GetByAllEntity();
            //PriceListProfile = priceRepos.GetByAllEntity();
            //CommercialOfferGeneral = reposOffer.GetByAllEntity();
            //DataPlanProfile = reposPlanDate.GetByAllEntity();
            //SummaryTableProfile = GetSummaryTableProfile();
            RefreshListReceptionAndPriceListAndSpecificationEloksal(1);
            ShowPriceProfileCommand = new ViewModelCommand(ShowNewPriceProfile);
            OpenProfilePriceCommand = new ViewModelCommand(OpenProfilePrice);
            RefreshAllProfileCommand = new ViewModelCommand(RefreshListReceptionAndPriceListAndSpecificationEloksal);
            ShowSpecificationCommand = new ViewModelCommand(ShowNewSpecification);
            ShowCardSpecificationCommand = new ViewModelCommand(OpenCardSpecification);
            ShowNewCommercialOfferCommand = new ViewModelCommand(ShowNewCommercialOffer);
            ShowCommercialOfferCommand = new ViewModelCommand(OpenCommercialOffer);
            ShowNewDataPlanCommand = new ViewModelCommand(ShowNewDataPlan);    
        }
        void ShowNewPriceProfile(object obj)
        {
            PriceListView priceList = new PriceListView();
            priceList.Show();
        }
    

        void ShowNewCommercialOffer(object obj)
        {
            CommercialOfferView offerWindow = new CommercialOfferView();
            offerWindow.Show();
            CommercialOfferGeneralRepository repos = new CommercialOfferGeneralRepository();
            CommercialOfferGeneral offerGeneral = new CommercialOfferGeneral();
            int maxId = repos.GetById();
            int MaxNumberOffer = repos.MaxNumberOffer() + 1;
            offerGeneral.Id = ++maxId;
            offerGeneral.NumberOffer = MaxNumberOffer.ToString("D4");
            offerGeneral.DateOffer = DateTime.Now;
            repos.Add(offerGeneral);
            offerWindow.txtNumberOffer.Text = offerGeneral.NumberOffer;
            offerWindow.txtDateOffer.Text = offerGeneral.DateOffer.ToString();
            offerWindow.txtIdOffer.Text = offerGeneral.Id.ToString();
        }
        void ShowNewSpecification(object obj)
        {
            SpecificationEloksalProfileView specification = new SpecificationEloksalProfileView();
            specification.Show();
        }
        void ShowNewDataPlan(object obj)
        {
            DateOfPlanView plan = new DateOfPlanView();
            plan.Show();
        }
        void OpenProfilePrice(object obj)
        {
            PriceListProfileRepository priceProfileRepos = new PriceListProfileRepository();
            PriceListView priceList = new PriceListView();
            priceList.Show();
            PriceListProfile price = new PriceListProfile();
            price = priceProfileRepos.GetByEntity(Convert.ToInt32(IdPrice));
            if (price != null)
            {
                priceList.txtIdClient.Text = Convert.ToString(price.Id);
                priceList.txtClientName.Text = Convert.ToString(price.CustomerName);
                priceList.txtNomenclatureProfile.Text = price.ProfileCode.Trim();
                priceList.txtProfileCode.Text = price.CustomerCode;
                priceList.txtPriceProfileArea.Text = Convert.ToString(price.PriceProfileArea);
                priceList.txtPriceProfileKg.Text = price.PriceProfileKg.ToString("0.00");
                priceList.txtPriceProfileMetr.Text = Convert.ToString(price.PriceProfileMetr);
            }
        }
        void OpenCardSpecification(object obj)
        {
            SpecificationEloksalProfileView specificationView = new SpecificationEloksalProfileView();
            specificationView.Show();
            SpecificationEloksalProfileRepository repos = new SpecificationEloksalProfileRepository();
            SpecificationEloksalProfile specificationProfile = new SpecificationEloksalProfile();
            specificationProfile = repos.GetByEntity(Convert.ToInt32(SpecificationId));
            if (specificationProfile != null)
            {
                specificationView.txtId.Text = Convert.ToString(specificationProfile.Id);
                specificationView.txtClientName.Text = specificationProfile.ClientName;
                specificationView.txtSpecification.Text = specificationProfile.NumberSpecification;
                specificationView.txtDateSpecification.Text = Convert.ToString(specificationProfile.DateSpecification);
                specificationView.txtContract.Text = specificationProfile.NumberContract;
                specificationView.txtDateContract.Text = Convert.ToString(specificationProfile.DateContract);
                specificationView.checkBox2.IsChecked = specificationProfile.CalculateLabel;
            }
        }
        void OpenCommercialOffer(object obj)
        {
            CommercialOfferGeneralRepository repos = new CommercialOfferGeneralRepository();
            CommercialOfferView offerWindow = new CommercialOfferView();
            offerWindow.Show();
            CommercialOfferGeneral offer = new CommercialOfferGeneral();
            offer = repos.GetByEntity(Convert.ToInt32(IdOffer));
            if (offer != null)
            {
                offerWindow.txtClientText.Text = Convert.ToString(offer.ClientName);
                offerWindow.txtNumberOffer.Text = Convert.ToString(offer.NumberOffer);
                offerWindow.txtDateOffer.Text = Convert.ToString(offer.DateOffer);
                offerWindow.txtIdOffer.Text = Convert.ToString(offer.Id);
            }
        }    
        void RefreshListReceptionAndPriceListAndSpecificationEloksal(object obj)
        {
            PriceListProfileRepository priceRepos = new PriceListProfileRepository();
            PriceListProfile = priceRepos.GetByAllEntity();

            SpecificationEloksalProfileRepository specificationEloksalProfileRepository = new SpecificationEloksalProfileRepository();
            SpecificationEloksalProfile = specificationEloksalProfileRepository.ChangeDifData();
            SummaryTableProfile = GetSummaryTableProfile();
            CommercialOfferGeneralRepository reposOffer = new CommercialOfferGeneralRepository();
            CommercialOfferGeneral = reposOffer.GetByAllEntity();

            DataofPlanRepository reposPlanDate = new DataofPlanRepository();
            DataPlanProfile = reposPlanDate.GetByAllEntity();
            DataPlanProfileGeneral = reposPlanDate.GetGeneralDataUpload();
        }
        public  List<SummaryTableProfile> GetSummaryTableProfile()
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
            HitchAluminumProfilesRepository reposHitchAluminum = new HitchAluminumProfilesRepository();
            List<ForPivotTableHitchAluminumProfile> listHitchAluminum = new List<ForPivotTableHitchAluminumProfile>();
            listHitchAluminum = reposHitchAluminum.GetForPivotTableHitchAluminumProfile();// навеска
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
                                  join l5 in listHitchAluminum on new { l1.NomenclatureProfile, l1.NumberSpecification } equals new { l5.NomenclatureProfile, l5.NumberSpecification }
                                  into temp5
                                  from lj5 in temp5.DefaultIfEmpty()
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
                                      EloksalNoCommercial = l1.EloksalNoCommercial,
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

                                      AmountPieceHitchAluminumProfile = lj5 == null ? 0 : Convert.ToInt16(lj5.AmountPieceHitchAluminumProfile),
                                      LenghtHitchAluminumProfile = lj5 == null ? 0 : Convert.ToDouble(lj5.LenghtHitchAluminumProfile),
                                      WeightHitchAluminumProfile = lj5 == null ? 0 : Convert.ToDouble(lj5.WeightHitchAluminumProfile),
                                      AmountPieceHitchAluminumProfileBrak = lj5 == null ? 0 : Convert.ToInt16(lj5.AmountPieceHitchAluminumProfileBrak),
                                      LenghtHitchAluminumProfileBrak = lj5 == null ? 0 : Convert.ToDouble(lj5.LenghtHitchAluminumProfileBrak),
                                      WeightHitchAluminumProfileBrak = lj5 == null ? 0 : Convert.ToDouble(lj5.WeightHitchAluminumProfileBrak),

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
                                      AmountProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToInt16(lj10.AmountPieceProfileConsumptionWarehouseBrak),
                                      LenghtProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToDouble(lj10.LenghtProfileConsumptionWarehouseBrak),
                                      WeightProfileConsumptionWarehouseBrak = lj10 == null ? 0 : Convert.ToDouble(lj10.WeightProfileConsumptionWarehouseBrak)
                                  };
                if (listGeneral != null)
                {
                    list = listGeneral.AsEnumerable()
                    .OrderBy(p => p.NumberSpecification)
                    .OrderBy(p => p.DateReception)
                    .ToList(); 
                }

                return list;
        }
    }
}