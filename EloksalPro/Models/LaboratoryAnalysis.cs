using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class LaboratoryAnalysis: BaseEntity
    {
        public DateTime? DateLaboratoryAnalysis { get; set; }
        public string NumberAnalysis { get; set; }
        public string Emloyee { get; set; }
        public string OneDegreasingTemp { get; set; }
        public string OneDegreasingCMA { get; set; }
        public string ThreeAlkalineTemp { get; set; }
        public string ThreeAlkalineNaOH { get; set; }
        public string ThreeAlkalineAl { get; set; }
        public string ThreeAlkalineStrip { get; set; }
        public string FourAlkalineTemp { get; set; }
        public string FourAlkalineNaOH { get; set; }
        public string FourAlkalineAl { get; set; }
        public string FourAlkalineCMA { get; set; }
        public string FiveHotRinsingTemp { get; set; }
        public string EightNeutralizationHSO { get; set; }
        public string EightNeutralizationDeox{ get; set; }
        public string NineAnodizingTemp { get; set; }
        public string NineAnodizingHSO { get; set; }
        public string NineAnodizingAl { get; set; }
        public string TenAnodizingTemp { get; set; }
        public string TenAnodizingHSO { get; set; }
        public string TenAnodizingAl { get; set; }
        public string ElevenAnodizingTemp { get; set; }
        public string ElevenAnodizingHSO { get; set; }
        public string ElevenAnodizingAl { get; set; }
        public string FourteenFlushing { get; set; }
        public string FifteenElectroTemp { get; set; }
        public string FifteenElectroHSO { get; set; }
        public string FifteenElectroColourT { get; set; }
        public string FifteenElectroColourS { get; set; }
        public string SixteenFlushing { get; set; }
        public string SeventeenDemoFlushing { get; set; }
        public string EighteenColdSealTemp { get; set; }
        public string EighteenColdSealPh { get; set; }
        public string EighteenColdSealNikel { get; set; }
        public string EighteenColdSealFluoride { get; set; }
        public string EighteenColdSeal { get; set; }
        public string NinteenFlushing { get; set; }
        public string TwentyColdSealTemp { get; set; }
        public string TwentyColdSealPh { get; set; }
        public string TwentyColdSealNikel { get; set; }
        public string TwentyColdSealFluoride { get; set; }
        public string TwentyColdSeal { get; set; }
        public string TwentyOneHotRinsing { get; set; }
        public string TwentyTwoHotRinsing { get; set; }
        public string TwentyThreeHotRinsing { get; set; }
        public string Result { get; set; }

        public string OneDegreasingTempCorrect { get; set; }
        public string OneDegreasingCMACorrect { get; set; }
        public string ThreeAlkalineTempCorrect { get; set; }
        public string ThreeAlkalineNaOHCorrect { get; set; }
        public string ThreeAlkalineAlCorrect { get; set; }
        public string ThreeAlkalineStripCorrect { get; set; }
        public string FourAlkalineTempCorrect { get; set; }
        public string FourAlkalineNaOHCorrect { get; set; }
        public string FourAlkalineAlCorrect { get; set; }
        public string FourAlkalineCMACorrect { get; set; }
        public string FiveHotRinsingTempCorrect { get; set; }
        public string EightNeutralizationHSOCorrect { get; set; }
        public string EightNeutralizationDeoxCorrect { get; set; }
        public string NineAnodizingTempCorrect { get; set; }
        public string NineAnodizingHSOCorrect { get; set; }
        public string NineAnodizingAlCorrect { get; set; }
        public string TenAnodizingTempCorrect { get; set; }
        public string TenAnodizingHSOCorrect { get; set; }
        public string TenAnodizingAlCorrect { get; set; }
        public string ElevenAnodizingTempCorrect { get; set; }
        public string ElevenAnodizingHSOCorrect { get; set; }
        public string ElevenAnodizingAlCorrect { get; set; }
        public string FourteenFlushingCorrect { get; set; }
        public string FifteenElectroTempCorrect { get; set; }
        public string FifteenElectroHSOCorrect { get; set; }
        public string FifteenElectroColourTCorrect { get; set; }
        public string FifteenElectroColourSCorrect { get; set; }
        public string SixteenFlushingCorrect { get; set; }
        public string SeventeenDemoFlushingCorrect { get; set; }
        public string EighteenColdSealTempCorrect { get; set; }
        public string EighteenColdSealPhCorrect { get; set; }
        public string EighteenColdSealNikelCorrect { get; set; }
        public string EighteenColdSealFluorideCorrect { get; set; }
        public string EighteenColdSealCorrect { get; set; }
        public string NinteenFlushingCorrect { get; set; }
        public string TwentyColdSealTempCorrect { get; set; }
        public string TwentyColdSealPhCorrect { get; set; }
        public string TwentyColdSealNikelCorrect { get; set; }
        public string TwentyColdSealFluorideCorrect { get; set; }
        public string TwentyColdSealCorrect { get; set; }
        public string TwentyOneHotRinsingCorrect { get; set; }
        public string TwentyTwoHotRinsingCorrect { get; set; }
        public string TwentyThreeHotRinsingCorrect { get; set; }
        public string ResultCorrect { get; set; }

    }
}
