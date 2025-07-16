using EloksalPro.Models;
using EloksalPro.Repositories.Base;
using EloksalPro.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Repositories
{
    public class LaboratoryAnalysisRepository:BaseRepo<LaboratoryAnalysis>, ILaboratoryAnalysisRepository
    {
        public int MaxNumberLaboratoryAnalysis()
        {
            List<LaboratoryAnalysis> list = GetByAllEntity();
            if (list.Count() > 0)
            {
                List<string> numberList = list.Select(p => p.NumberAnalysis).ToList();
                List<int> eloksalNoListInt = new List<int>();

                foreach (string item in numberList)
                {
                    int number = int.Parse(item.Substring(2));
                    eloksalNoListInt.Add(number);
                }
                int eloksalNoIntMax = eloksalNoListInt.Max();
                return eloksalNoIntMax;
            }
            else
            {
                return 0;
            }

        }
        public ObservableCollection<LaboratoryAnalysis> GetByAllEntityObservableCollection()
        {
            ObservableCollection<LaboratoryAnalysis> list = new ObservableCollection<LaboratoryAnalysis>();
            var inventory = Table;
            list = new ObservableCollection<LaboratoryAnalysis>(inventory);
            return list;
        }
        public void UpdateDataLaboratoryAnalysis(LaboratoryAnalysis entity,DateTime? date)
        {
            LaboratoryAnalysis myEntity = Table.FirstOrDefault(p => p.NumberAnalysis == entity.NumberAnalysis);
            if (myEntity != null)
            {
                myEntity.DateLaboratoryAnalysis = date;
                myEntity.OneDegreasingTemp = entity.OneDegreasingTemp;
                myEntity.OneDegreasingCMA = entity.OneDegreasingCMA;
                myEntity.ThreeAlkalineTemp = entity.ThreeAlkalineTemp;
                myEntity.ThreeAlkalineNaOH = entity.ThreeAlkalineNaOH;
                myEntity.ThreeAlkalineAl = entity.ThreeAlkalineAl;
                myEntity.ThreeAlkalineStrip = entity.ThreeAlkalineStrip;
                myEntity.FourAlkalineTemp = entity.FourAlkalineTemp;
                myEntity.FourAlkalineNaOH = entity.FourAlkalineNaOH;
                myEntity.FourAlkalineAl = entity.FourAlkalineAl;
                myEntity.FourAlkalineCMA = entity.FourAlkalineCMA;
                myEntity.FiveHotRinsingTemp = entity.FiveHotRinsingTemp;
                myEntity.EightNeutralizationHSO = entity.EightNeutralizationHSO;
                myEntity.EightNeutralizationDeox = entity.EightNeutralizationDeox;
                myEntity.NineAnodizingTemp = entity.NineAnodizingTemp;
                myEntity.NineAnodizingHSO = entity.NineAnodizingHSO;
                myEntity.NineAnodizingAl = entity.NineAnodizingAl;
                myEntity.TenAnodizingTemp = entity.TenAnodizingTemp;
                myEntity.TenAnodizingHSO = entity.TenAnodizingHSO;
                myEntity.TenAnodizingAl = entity.TenAnodizingAl;
                myEntity.ElevenAnodizingTemp = entity.ElevenAnodizingTemp;
                myEntity.ElevenAnodizingHSO = entity.ElevenAnodizingHSO;
                myEntity.ElevenAnodizingAl = entity.ElevenAnodizingAl;
                myEntity.FourteenFlushing = entity.FourteenFlushing;
                myEntity.FifteenElectroTemp = entity.FifteenElectroTemp;
                myEntity.FifteenElectroHSO = entity.FifteenElectroHSO;
                myEntity.FifteenElectroColourT = entity.FifteenElectroColourT;
                myEntity.FifteenElectroColourS = entity.FifteenElectroColourS;
                myEntity.SixteenFlushing = entity.SixteenFlushing;
                myEntity.SeventeenDemoFlushing = entity.SeventeenDemoFlushing;
                myEntity.EighteenColdSealTemp = entity.EighteenColdSealTemp;
                myEntity.EighteenColdSealPh = entity.EighteenColdSealPh;
                myEntity.EighteenColdSealNikel = entity.EighteenColdSealNikel;
                myEntity.EighteenColdSealFluoride = entity.EighteenColdSealFluoride;
                myEntity.EighteenColdSeal = entity.EighteenColdSeal;
                myEntity.NinteenFlushing = entity.NinteenFlushing;
                myEntity.TwentyColdSealTemp = entity.TwentyColdSealTemp;
                myEntity.TwentyColdSealPh = entity.TwentyColdSealPh;
                myEntity.TwentyColdSealNikel = entity.TwentyColdSealNikel;
                myEntity.TwentyColdSealFluoride = entity.TwentyColdSealFluoride;
                myEntity.TwentyColdSeal = entity.TwentyColdSeal;
                myEntity.TwentyOneHotRinsing = entity.TwentyOneHotRinsing;
                myEntity.TwentyTwoHotRinsing = entity.TwentyTwoHotRinsing;
                myEntity.TwentyThreeHotRinsing = entity.TwentyThreeHotRinsing;
                myEntity.Result = entity.Result;
                myEntity.OneDegreasingTempCorrect = entity.OneDegreasingTempCorrect;
                myEntity.OneDegreasingCMACorrect = entity.OneDegreasingCMACorrect;
                myEntity.ThreeAlkalineTempCorrect = entity.ThreeAlkalineTempCorrect;
                myEntity.ThreeAlkalineNaOHCorrect = entity.ThreeAlkalineNaOHCorrect;
                myEntity.ThreeAlkalineAlCorrect = entity.ThreeAlkalineAlCorrect;
                myEntity.ThreeAlkalineStripCorrect = entity.ThreeAlkalineStripCorrect;
                myEntity.FourAlkalineTempCorrect = entity.FourAlkalineTempCorrect;
                myEntity.FourAlkalineNaOHCorrect = entity.FourAlkalineNaOHCorrect;
                myEntity.FourAlkalineAlCorrect = entity.FourAlkalineAlCorrect;
                myEntity.FourAlkalineCMACorrect = entity.FourAlkalineCMACorrect;
                myEntity.FiveHotRinsingTempCorrect = entity.FiveHotRinsingTempCorrect;
                myEntity.EightNeutralizationHSOCorrect = entity.EightNeutralizationHSOCorrect;
                myEntity.EightNeutralizationDeoxCorrect = entity.EightNeutralizationDeoxCorrect;
                myEntity.NineAnodizingTempCorrect = entity.NineAnodizingTempCorrect;
                myEntity.NineAnodizingHSOCorrect = entity.NineAnodizingHSOCorrect;
                myEntity.NineAnodizingAlCorrect = entity.NineAnodizingAlCorrect;
                myEntity.TenAnodizingTempCorrect = entity.TenAnodizingTempCorrect;
                myEntity.TenAnodizingHSOCorrect = entity.TenAnodizingHSOCorrect;
                myEntity.TenAnodizingAlCorrect = entity.TenAnodizingAlCorrect;
                myEntity.ElevenAnodizingTempCorrect = entity.ElevenAnodizingTempCorrect;
                myEntity.ElevenAnodizingHSOCorrect = entity.ElevenAnodizingHSOCorrect;
                myEntity.ElevenAnodizingAlCorrect = entity.ElevenAnodizingAlCorrect;
                myEntity.FourteenFlushingCorrect = entity.FourteenFlushingCorrect;
                myEntity.FifteenElectroTempCorrect = entity.FifteenElectroTempCorrect;
                myEntity.FifteenElectroHSOCorrect = entity.FifteenElectroHSOCorrect;
                myEntity.FifteenElectroColourTCorrect = entity.FifteenElectroColourTCorrect;
                myEntity.FifteenElectroColourSCorrect = entity.FifteenElectroColourSCorrect;
                myEntity.SixteenFlushingCorrect = entity.SixteenFlushingCorrect;
                myEntity.SeventeenDemoFlushingCorrect = entity.SeventeenDemoFlushingCorrect;
                myEntity.EighteenColdSealTempCorrect = entity.EighteenColdSealTempCorrect;
                myEntity.EighteenColdSealPhCorrect = entity.EighteenColdSealPhCorrect;
                myEntity.EighteenColdSealNikelCorrect = entity.EighteenColdSealNikelCorrect;
                myEntity.EighteenColdSealFluorideCorrect = entity.EighteenColdSealFluorideCorrect;
                myEntity.EighteenColdSealCorrect = entity.EighteenColdSealCorrect;
                myEntity.NinteenFlushingCorrect = entity.NinteenFlushingCorrect;
                myEntity.TwentyColdSealTempCorrect = entity.TwentyColdSealTempCorrect;
                myEntity.TwentyColdSealPhCorrect = entity.TwentyColdSealPhCorrect;
                myEntity.TwentyColdSealNikelCorrect = entity.TwentyColdSealNikelCorrect;
                myEntity.TwentyColdSealFluorideCorrect = entity.TwentyColdSealFluorideCorrect;
                myEntity.TwentyColdSealCorrect = entity.TwentyColdSealCorrect;
                myEntity.TwentyOneHotRinsingCorrect = entity.TwentyOneHotRinsingCorrect;
                myEntity.TwentyTwoHotRinsingCorrect = entity.TwentyTwoHotRinsingCorrect;
                myEntity.TwentyThreeHotRinsingCorrect = entity.TwentyThreeHotRinsingCorrect;
                myEntity.ResultCorrect = entity.ResultCorrect;
                Context.SaveChanges();
            }
        }

        public bool CheckValueNumberAnalysis(string number)
        {
            bool checkValue= Table.Any(p => p.NumberAnalysis == number);
            return checkValue;
        }
        }
    }

