using EloksalPro.Models;
using EloksalPro.Repositories;
using EloksalPro.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EloksalPro.ViewModels
{
    public class LaboratoryAnalysisViewModel: ViewModelBase
    {
        private int _id;
        private LaboratoryAnalysis _analiz = new LaboratoryAnalysis();
        private ObservableCollection<LaboratoryAnalysis> _list = new ObservableCollection<LaboratoryAnalysis>();
        private UserAccountModel _currentUserAccount;
        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public LaboratoryAnalysis LaboratoryAnalysis
        {
            get { return _analiz; }
            set { _analiz = value; OnPropertyChanged(nameof(LaboratoryAnalysis)); }
        }
        public ObservableCollection<LaboratoryAnalysis> ListAnalysis
        {
            get { return _list; }
            set { _list = value; OnPropertyChanged(nameof(ListAnalysis)); }
        }
        public ICommand ShowNewAnalysisViewCommand { get; }
        public ICommand ShowAnalysisViewCommand { get; }
        public ICommand ShowSaveInsertCommand { get; }
        public ICommand ShowRefreshDataCommand { get; }

        public LaboratoryAnalysisViewModel()
        {
            LaboratoryAnalysisRepository repos = new LaboratoryAnalysisRepository();
            ShowNewAnalysisViewCommand = new ViewModelCommand(ShowNewLaboratoryAnalysis);
            ShowSaveInsertCommand=new ViewModelCommand(UpdateOrInsertData);
            ListAnalysis = repos.GetByAllEntityObservableCollection();
            int MaxEloksalNo = repos.MaxNumberLaboratoryAnalysis() + 1;
            LaboratoryAnalysis.NumberAnalysis = "LA" + MaxEloksalNo.ToString("D4");
            ShowRefreshDataCommand = new ViewModelCommand(RefreshDataCommand);
            ShowAnalysisViewCommand= new ViewModelCommand(ShowLaboratoryAnalysis);
        }

        void ShowNewLaboratoryAnalysis(object obj)
        {
            LaboratoryAnalysisView analysis= new LaboratoryAnalysisView();
            analysis.Show();
        }
        void SaveInsertCommand()
        {
            DateTime? date;
            if (LaboratoryAnalysis.DateLaboratoryAnalysis == DateTime.MinValue || LaboratoryAnalysis.DateLaboratoryAnalysis==null)
            {
                date = DateTime.Now;
            }
            else
            {
                date = LaboratoryAnalysis.DateLaboratoryAnalysis;
            }
            LaboratoryAnalysisRepository repos = new LaboratoryAnalysisRepository();
            LaboratoryAnalysis analysis = new LaboratoryAnalysis();
            int maxId = repos.GetById();
            analysis.Id = ++maxId;
            analysis.NumberAnalysis = LaboratoryAnalysis.NumberAnalysis;
            analysis.DateLaboratoryAnalysis = date;
            analysis.Emloyee = LoadCurrentUserData();
            analysis.OneDegreasingTemp = LaboratoryAnalysis.OneDegreasingTemp;
            analysis.OneDegreasingCMA = LaboratoryAnalysis.OneDegreasingCMA;
            analysis.ThreeAlkalineTemp = LaboratoryAnalysis.ThreeAlkalineTemp;
            analysis.ThreeAlkalineNaOH = LaboratoryAnalysis.ThreeAlkalineNaOH;
            analysis.ThreeAlkalineAl = LaboratoryAnalysis.ThreeAlkalineAl;
            analysis.ThreeAlkalineStrip = LaboratoryAnalysis.ThreeAlkalineStrip;
            analysis.FourAlkalineTemp = LaboratoryAnalysis.FourAlkalineTemp;
            analysis.FourAlkalineNaOH = LaboratoryAnalysis.FourAlkalineNaOH;
            analysis.FourAlkalineAl = LaboratoryAnalysis.FourAlkalineAl;
            analysis.FourAlkalineCMA = LaboratoryAnalysis.FourAlkalineCMA;
            analysis.FiveHotRinsingTemp = LaboratoryAnalysis.FiveHotRinsingTemp;
            analysis.EightNeutralizationHSO = LaboratoryAnalysis.EightNeutralizationHSO;
            analysis.EightNeutralizationDeox = LaboratoryAnalysis.EightNeutralizationDeox;
            analysis.NineAnodizingTemp = LaboratoryAnalysis.NineAnodizingTemp;
            analysis.NineAnodizingHSO = LaboratoryAnalysis.NineAnodizingHSO;
            analysis.NineAnodizingAl = LaboratoryAnalysis.NineAnodizingAl;
            analysis.TenAnodizingTemp = LaboratoryAnalysis.TenAnodizingTemp;
            analysis.TenAnodizingHSO = LaboratoryAnalysis.TenAnodizingHSO;
            analysis.TenAnodizingAl = LaboratoryAnalysis.TenAnodizingAl;
            analysis.ElevenAnodizingTemp = LaboratoryAnalysis.ElevenAnodizingTemp;
            analysis.ElevenAnodizingHSO = LaboratoryAnalysis.ElevenAnodizingHSO;
            analysis.ElevenAnodizingAl = LaboratoryAnalysis.ElevenAnodizingAl;
            analysis.FourteenFlushing = LaboratoryAnalysis.FourteenFlushing;
            analysis.FifteenElectroTemp = LaboratoryAnalysis.FifteenElectroTemp;
            analysis.FifteenElectroHSO = LaboratoryAnalysis.FifteenElectroHSO;
            analysis.FifteenElectroColourT = LaboratoryAnalysis.FifteenElectroColourT;
            analysis.FifteenElectroColourS = LaboratoryAnalysis.FifteenElectroColourS;
            analysis.SixteenFlushing = LaboratoryAnalysis.SixteenFlushing;
            analysis.SeventeenDemoFlushing = LaboratoryAnalysis.SeventeenDemoFlushing;
            analysis.EighteenColdSealTemp = LaboratoryAnalysis.EighteenColdSealTemp;
            analysis.EighteenColdSealPh = LaboratoryAnalysis.EighteenColdSealPh;
            analysis.EighteenColdSealNikel = LaboratoryAnalysis.EighteenColdSealNikel;
            analysis.EighteenColdSealFluoride = LaboratoryAnalysis.EighteenColdSealFluoride;
            analysis.EighteenColdSeal = LaboratoryAnalysis.EighteenColdSeal;
            analysis.NinteenFlushing = LaboratoryAnalysis.NinteenFlushing;
            analysis.TwentyColdSealTemp = LaboratoryAnalysis.TwentyColdSealTemp;
            analysis.TwentyColdSealPh = LaboratoryAnalysis.TwentyColdSealPh;
            analysis.TwentyColdSealNikel = LaboratoryAnalysis.TwentyColdSealNikel;
            analysis.TwentyColdSealFluoride = LaboratoryAnalysis.TwentyColdSealFluoride;
            analysis.TwentyColdSeal = LaboratoryAnalysis.TwentyColdSeal;
            analysis.TwentyOneHotRinsing = LaboratoryAnalysis.TwentyOneHotRinsing;
            analysis.TwentyTwoHotRinsing = LaboratoryAnalysis.TwentyTwoHotRinsing;
            analysis.TwentyThreeHotRinsing = LaboratoryAnalysis.TwentyThreeHotRinsing;
            analysis.Result = LaboratoryAnalysis.Result;
            analysis.OneDegreasingTempCorrect = LaboratoryAnalysis.OneDegreasingTempCorrect;
            analysis.OneDegreasingCMACorrect = LaboratoryAnalysis.OneDegreasingCMACorrect;
            analysis.ThreeAlkalineTempCorrect = LaboratoryAnalysis.ThreeAlkalineTempCorrect;
            analysis.ThreeAlkalineNaOHCorrect = LaboratoryAnalysis.ThreeAlkalineNaOHCorrect;
            analysis.ThreeAlkalineAlCorrect = LaboratoryAnalysis.ThreeAlkalineAlCorrect;
            analysis.ThreeAlkalineStripCorrect = LaboratoryAnalysis.ThreeAlkalineStripCorrect;
            analysis.FourAlkalineTempCorrect = LaboratoryAnalysis.FourAlkalineTempCorrect;
            analysis.FourAlkalineNaOHCorrect = LaboratoryAnalysis.FourAlkalineNaOHCorrect;
            analysis.FourAlkalineAlCorrect = LaboratoryAnalysis.FourAlkalineAlCorrect;
            analysis.FourAlkalineCMACorrect = LaboratoryAnalysis.FourAlkalineCMACorrect;
            analysis.FiveHotRinsingTempCorrect = LaboratoryAnalysis.FiveHotRinsingTempCorrect;
            analysis.EightNeutralizationHSOCorrect = LaboratoryAnalysis.EightNeutralizationHSOCorrect;
            analysis.EightNeutralizationDeoxCorrect = LaboratoryAnalysis.EightNeutralizationDeoxCorrect;
            analysis.NineAnodizingTempCorrect = LaboratoryAnalysis.NineAnodizingTempCorrect;
            analysis.NineAnodizingHSOCorrect = LaboratoryAnalysis.NineAnodizingHSOCorrect;
            analysis.NineAnodizingAlCorrect = LaboratoryAnalysis.NineAnodizingAlCorrect;
            analysis.TenAnodizingTempCorrect = LaboratoryAnalysis.TenAnodizingTempCorrect;
            analysis.TenAnodizingHSOCorrect = LaboratoryAnalysis.TenAnodizingHSOCorrect;
            analysis.TenAnodizingAlCorrect = LaboratoryAnalysis.TenAnodizingAlCorrect;
            analysis.ElevenAnodizingTempCorrect = LaboratoryAnalysis.ElevenAnodizingTempCorrect;
            analysis.ElevenAnodizingHSOCorrect = LaboratoryAnalysis.ElevenAnodizingHSOCorrect;
            analysis.ElevenAnodizingAlCorrect = LaboratoryAnalysis.ElevenAnodizingAlCorrect;
            analysis.FourteenFlushingCorrect = LaboratoryAnalysis.FourteenFlushingCorrect;
            analysis.FifteenElectroTempCorrect = LaboratoryAnalysis.FifteenElectroTempCorrect;
            analysis.FifteenElectroHSOCorrect = LaboratoryAnalysis.FifteenElectroHSOCorrect;
            analysis.FifteenElectroColourTCorrect = LaboratoryAnalysis.FifteenElectroColourTCorrect;
            analysis.FifteenElectroColourSCorrect = LaboratoryAnalysis.FifteenElectroColourSCorrect;
            analysis.SixteenFlushingCorrect = LaboratoryAnalysis.SixteenFlushingCorrect;
            analysis.SeventeenDemoFlushingCorrect = LaboratoryAnalysis.SeventeenDemoFlushingCorrect;
            analysis.EighteenColdSealTempCorrect = LaboratoryAnalysis.EighteenColdSealTempCorrect;
            analysis.EighteenColdSealPhCorrect = LaboratoryAnalysis.EighteenColdSealPhCorrect;
            analysis.EighteenColdSealNikelCorrect = LaboratoryAnalysis.EighteenColdSealNikelCorrect;
            analysis.EighteenColdSealFluorideCorrect = LaboratoryAnalysis.EighteenColdSealFluorideCorrect;
            analysis.EighteenColdSealCorrect = LaboratoryAnalysis.EighteenColdSealCorrect;
            analysis.NinteenFlushingCorrect = LaboratoryAnalysis.NinteenFlushingCorrect;
            analysis.TwentyColdSealTempCorrect = LaboratoryAnalysis.TwentyColdSealTempCorrect;
            analysis.TwentyColdSealPhCorrect = LaboratoryAnalysis.TwentyColdSealPhCorrect;
            analysis.TwentyColdSealNikelCorrect = LaboratoryAnalysis.TwentyColdSealNikelCorrect;
            analysis.TwentyColdSealFluorideCorrect = LaboratoryAnalysis.TwentyColdSealFluorideCorrect;
            analysis.TwentyColdSealCorrect = LaboratoryAnalysis.TwentyColdSealCorrect;
            analysis.TwentyOneHotRinsingCorrect = LaboratoryAnalysis.TwentyOneHotRinsingCorrect;
            analysis.TwentyTwoHotRinsingCorrect = LaboratoryAnalysis.TwentyTwoHotRinsingCorrect;
            analysis.TwentyThreeHotRinsingCorrect = LaboratoryAnalysis.TwentyThreeHotRinsingCorrect;
            analysis.ResultCorrect = LaboratoryAnalysis.ResultCorrect;
            repos.Add(analysis);
            ListAnalysis.Add(analysis);
            MessageBox.Show("Данные успешно сохранены");
        }
        private string LoadCurrentUserData()
        {
            UserRepository userRepo = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            UserModel userList = userRepo.GetByUsername(System.Threading.Thread.CurrentPrincipal.Identity.Name);
            if (userList != null)
            {
                {
                    CurrentUserAccount.DisplayName = userList.Name;
                }
            }
            else
            {
                CurrentUserAccount.DisplayName = "User";
            }
            return CurrentUserAccount.DisplayName;
        }
        void RefreshDataCommand(object obj)
        {
            LaboratoryAnalysisRepository repos = new LaboratoryAnalysisRepository();
            ListAnalysis = repos.GetByAllEntityObservableCollection();
        }
     
        void ShowLaboratoryAnalysis(object obj)
        {
            LaboratoryAnalysisView analysis = new LaboratoryAnalysisView();
            analysis.Show();
            LaboratoryAnalysisRepository repos = new LaboratoryAnalysisRepository();
            var entity = repos.GetByEntity(Id);
            if (entity !=null)
            {
                analysis.txtNumber.Text = entity.NumberAnalysis;
                analysis.txtDateLaboratoryAnalysis.Text = Convert.ToString(entity.DateLaboratoryAnalysis);
                analysis.txtOneDegreasingTemp.Text = entity.OneDegreasingTemp;
                analysis.txtOneDegreasingCMA.Text = entity.OneDegreasingCMA;
                analysis.txtThreeAlkalineTemp.Text = entity.ThreeAlkalineTemp;
                analysis.txtThreeAlkalineNaOH.Text = entity.ThreeAlkalineNaOH;
                analysis.txtThreeAlkalineAl.Text = entity.ThreeAlkalineAl;
                analysis.txtThreeAlkalineStrip.Text = entity.ThreeAlkalineStrip;
                analysis.txtFourAlkalineTemp.Text = entity.FourAlkalineTemp;
                analysis.txtFourAlkalineNaOH.Text = entity.FourAlkalineNaOH;
                analysis.txtFourAlkalineAl.Text = entity.FourAlkalineAl;
                analysis.txtFourAlkalineCMA.Text = entity.FourAlkalineCMA;
                analysis.txtFiveHotRinsingTemp.Text = entity.FiveHotRinsingTemp;
                analysis.txtEightNeutralizationHSO.Text = entity.EightNeutralizationHSO;
                analysis.txtEightNeutralizationDeox.Text = entity.EightNeutralizationDeox;
                analysis.txtNineAnodizingTemp.Text = entity.NineAnodizingTemp;
                analysis.txtNineAnodizingHSO.Text = entity.NineAnodizingHSO;
                analysis.txtNineAnodizingAl.Text = entity.NineAnodizingAl;
                analysis.txtTenAnodizingTemp.Text = entity.TenAnodizingTemp;
                analysis.txtTenAnodizingHSO.Text = entity.TenAnodizingHSO;
                analysis.txtTenAnodizingAl.Text = entity.TenAnodizingAl;
                analysis.txtElevenAnodizingTemp.Text = entity.ElevenAnodizingTemp;
                analysis.txtElevenAnodizingHSO.Text = entity.ElevenAnodizingHSO;
                analysis.txtElevenAnodizingAl.Text = entity.ElevenAnodizingAl;
                analysis.txtFourteenFlushing.Text = entity.FourteenFlushing;
                analysis.txtFifteenElectroTemp.Text = entity.FifteenElectroTemp;
                analysis.txtFifteenElectroHSO.Text = entity.FifteenElectroHSO;
                analysis.txtFifteenElectroColourT.Text = entity.FifteenElectroColourT;
                analysis.txtFifteenElectroColourS.Text = entity.FifteenElectroColourS;
                analysis.txtSixteenFlushing.Text = entity.SixteenFlushing;
                analysis.txtSeventeenDemoFlushing.Text = entity.SeventeenDemoFlushing;
                analysis.txtEighteenColdSealTemp.Text = entity.EighteenColdSealTemp;
                analysis.txtEighteenColdSealPh.Text = entity.EighteenColdSealPh;
                analysis.txtEighteenColdSealNikel.Text = entity.EighteenColdSealNikel;
                analysis.txtEighteenColdSealFluoride.Text = entity.EighteenColdSealFluoride;
                analysis.txtEighteenColdSeal.Text = entity.EighteenColdSeal;
                analysis.txtNinteenFlushing.Text = entity.NinteenFlushing;
                analysis.txtTwentyColdSealTemp.Text = entity.TwentyColdSealTemp;
                analysis.txtTwentyColdSealPh.Text = entity.TwentyColdSealPh;
                analysis.txtTwentyColdSealNikel.Text = entity.TwentyColdSealNikel;
                analysis.txtTwentyColdSealFluoride.Text = entity.TwentyColdSealFluoride;
                analysis.txtTwentyColdSeal.Text = entity.TwentyColdSeal;
                analysis.txtTwentyOneHotRinsing.Text = entity.TwentyOneHotRinsing;
                analysis.txtTwentyTwoHotRinsing.Text = entity.TwentyTwoHotRinsing;
                analysis.txtTwentyThreeHotRinsing.Text = entity.TwentyThreeHotRinsing;
                analysis.txtResult.Text = entity.Result;
                analysis.txtOneDegreasingTempCorrect.Text = entity.OneDegreasingTempCorrect;
                analysis.txtOneDegreasingCMACorrect.Text = entity.OneDegreasingCMACorrect;
                analysis.txtThreeAlkalineTempCorrect.Text = entity.ThreeAlkalineTempCorrect;
                analysis.txtThreeAlkalineNaOHCorrect.Text = entity.ThreeAlkalineNaOHCorrect;
                analysis.txtThreeAlkalineAlCorrect.Text = entity.ThreeAlkalineAlCorrect;
                analysis.txtThreeAlkalineStripCorrect.Text = entity.ThreeAlkalineStripCorrect;
                analysis.txtFourAlkalineTempCorrect.Text = entity.FourAlkalineTempCorrect;
                analysis.txtFourAlkalineNaOHCorrect.Text = entity.FourAlkalineNaOHCorrect;
                analysis.txtFourAlkalineAlCorrect.Text = entity.FourAlkalineAlCorrect;
                analysis.txtFourAlkalineCMACorrect.Text = entity.FourAlkalineCMACorrect;
                analysis.txtFiveHotRinsingTempCorrect.Text = entity.FiveHotRinsingTempCorrect;
                analysis.txtEightNeutralizationHSOCorrect.Text = entity.EightNeutralizationHSOCorrect;
                analysis.txtEightNeutralizationDeoxCorrect.Text = entity.EightNeutralizationDeoxCorrect;
                analysis.txtNineAnodizingTempCorrect.Text = entity.NineAnodizingTempCorrect;
                analysis.txtNineAnodizingHSOCorrect.Text = entity.NineAnodizingHSOCorrect;
                analysis.txtNineAnodizingAlCorrect.Text = entity.NineAnodizingAlCorrect;
                analysis.txtTenAnodizingTempCorrect.Text = entity.TenAnodizingTempCorrect;
                analysis.txtTenAnodizingHSOCorrect.Text = entity.TenAnodizingHSOCorrect;
                analysis.txtTenAnodizingAlCorrect.Text = entity.TenAnodizingAlCorrect;
                analysis.txtElevenAnodizingTempCorrect.Text = entity.ElevenAnodizingTempCorrect;
                analysis.txtElevenAnodizingHSOCorrect.Text = entity.ElevenAnodizingHSOCorrect;
                analysis.txtElevenAnodizingAlCorrect.Text = entity.ElevenAnodizingAlCorrect;
                analysis.txtFourteenFlushingCorrect.Text = entity.FourteenFlushingCorrect;
                analysis.txtFifteenElectroTempCorrect.Text = entity.FifteenElectroTempCorrect;
                analysis.txtFifteenElectroHSOCorrect.Text = entity.FifteenElectroHSOCorrect;
                analysis.txtFifteenElectroColourTCorrect.Text = entity.FifteenElectroColourTCorrect;
                analysis.txtFifteenElectroColourSCorrect.Text = entity.FifteenElectroColourSCorrect;
                analysis.txtSixteenFlushingCorrect.Text = entity.SixteenFlushingCorrect;
                analysis.txtSeventeenDemoFlushingCorrect.Text = entity.SeventeenDemoFlushingCorrect;
                analysis.txtEighteenColdSealTempCorrect.Text = entity.EighteenColdSealTempCorrect;
                analysis.txtEighteenColdSealPhCorrect.Text = entity.EighteenColdSealPhCorrect;
                analysis.txtEighteenColdSealNikelCorrect.Text = entity.EighteenColdSealNikelCorrect;
                analysis.txtEighteenColdSealFluorideCorrect.Text = entity.EighteenColdSealFluorideCorrect;
                analysis.txtEighteenColdSealCorrect.Text = entity.EighteenColdSealCorrect;
                analysis.txtNinteenFlushingCorrect.Text = entity.NinteenFlushingCorrect;
                analysis.txtTwentyColdSealTempCorrect.Text = entity.TwentyColdSealTempCorrect;
                analysis.txtTwentyColdSealPhCorrect.Text = entity.TwentyColdSealPhCorrect;
                analysis.txtTwentyColdSealNikelCorrect.Text = entity.TwentyColdSealNikelCorrect;
                analysis.txtTwentyColdSealFluorideCorrect.Text = entity.TwentyColdSealFluorideCorrect;
                analysis.txtTwentyColdSealCorrect.Text = entity.TwentyColdSealCorrect;
                analysis.txtTwentyOneHotRinsingCorrect.Text = entity.TwentyOneHotRinsingCorrect;
                analysis.txtTwentyTwoHotRinsingCorrect.Text = entity.TwentyTwoHotRinsingCorrect;
                analysis.txtTwentyThreeHotRinsingCorrect.Text = entity.TwentyThreeHotRinsingCorrect;
                analysis.txtResultCorrect.Text = entity.ResultCorrect;
            }

        }
        void UpdateOrInsertData (object obj)
        {
            DateTime? date;
            if (LaboratoryAnalysis.DateLaboratoryAnalysis == DateTime.MinValue || LaboratoryAnalysis.DateLaboratoryAnalysis == null)
            {
                date = DateTime.Now;
            }
            else
            {
                date = LaboratoryAnalysis.DateLaboratoryAnalysis;
            }
            LaboratoryAnalysisRepository repos = new LaboratoryAnalysisRepository();
            bool checkValue = repos.CheckValueNumberAnalysis(LaboratoryAnalysis.NumberAnalysis);
            if (!checkValue)
            {
                SaveInsertCommand();
            }
            else
            {
                repos.UpdateDataLaboratoryAnalysis(LaboratoryAnalysis, date);
                MessageBox.Show("Данные изменены");
            }
        }
    }
}
