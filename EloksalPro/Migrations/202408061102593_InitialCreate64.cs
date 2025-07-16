namespace EloksalPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate64 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LaboratoryAnalysis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateLaboratoryAnalysis = c.DateTime(),
                        NumberAnalysis = c.String(),
                        Emloyee = c.String(),
                        OneDegreasingTemp = c.String(),
                        OneDegreasingCMA = c.String(),
                        ThreeAlkalineTemp = c.String(),
                        ThreeAlkalineNaOH = c.String(),
                        ThreeAlkalineAl = c.String(),
                        ThreeAlkalineStrip = c.String(),
                        FourAlkalineTemp = c.String(),
                        FourAlkalineNaOH = c.String(),
                        FourAlkalineAl = c.String(),
                        FourAlkalineCMA = c.String(),
                        FiveHotRinsingTemp = c.String(),
                        EightNeutralizationHSO = c.String(),
                        EightNeutralizationDeox = c.String(),
                        NineAnodizingTemp = c.String(),
                        NineAnodizingHSO = c.String(),
                        NineAnodizingAl = c.String(),
                        TenAnodizingTemp = c.String(),
                        TenAnodizingHSO = c.String(),
                        TenAnodizingAl = c.String(),
                        ElevenAnodizingTemp = c.String(),
                        ElevenAnodizingHSO = c.String(),
                        ElevenAnodizingAl = c.String(),
                        FourteenFlushing = c.String(),
                        FifteenElectroTemp = c.String(),
                        FifteenElectroHSO = c.String(),
                        FifteenElectroColourT = c.String(),
                        FifteenElectroColourS = c.String(),
                        SixteenFlushing = c.String(),
                        SeventeenDemoFlushing = c.String(),
                        EighteenColdSealTemp = c.String(),
                        EighteenColdSealPh = c.String(),
                        EighteenColdSealNikel = c.String(),
                        EighteenColdSealFluoride = c.String(),
                        EighteenColdSeal = c.String(),
                        NinteenFlushing = c.String(),
                        TwentyColdSealTemp = c.String(),
                        TwentyColdSealPh = c.String(),
                        TwentyColdSealNikel = c.String(),
                        TwentyColdSealFluoride = c.String(),
                        TwentyColdSeal = c.String(),
                        TwentyOneHotRinsing = c.String(),
                        TwentyTwoHotRinsing = c.String(),
                        TwentyThreeHotRinsing = c.String(),
                        Result = c.String(),
                        OneDegreasingTempCorrect = c.String(),
                        OneDegreasingCMACorrect = c.String(),
                        ThreeAlkalineTempCorrect = c.String(),
                        ThreeAlkalineNaOHCorrect = c.String(),
                        ThreeAlkalineAlCorrect = c.String(),
                        ThreeAlkalineStripCorrect = c.String(),
                        FourAlkalineTempCorrect = c.String(),
                        FourAlkalineNaOHCorrect = c.String(),
                        FourAlkalineAlCorrect = c.String(),
                        FourAlkalineCMACorrect = c.String(),
                        FiveHotRinsingTempCorrect = c.String(),
                        EightNeutralizationHSOCorrect = c.String(),
                        EightNeutralizationDeoxCorrect = c.String(),
                        NineAnodizingTempCorrect = c.String(),
                        NineAnodizingHSOCorrect = c.String(),
                        NineAnodizingAlCorrect = c.String(),
                        TenAnodizingTempCorrect = c.String(),
                        TenAnodizingHSOCorrect = c.String(),
                        TenAnodizingAlCorrect = c.String(),
                        ElevenAnodizingTempCorrect = c.String(),
                        ElevenAnodizingHSOCorrect = c.String(),
                        ElevenAnodizingAlCorrect = c.String(),
                        FourteenFlushingCorrect = c.String(),
                        FifteenElectroTempCorrect = c.String(),
                        FifteenElectroHSOCorrect = c.String(),
                        FifteenElectroColourTCorrect = c.String(),
                        FifteenElectroColourSCorrect = c.String(),
                        SixteenFlushingCorrect = c.String(),
                        SeventeenDemoFlushingCorrect = c.String(),
                        EighteenColdSealTempCorrect = c.String(),
                        EighteenColdSealPhCorrect = c.String(),
                        EighteenColdSealNikelCorrect = c.String(),
                        EighteenColdSealFluorideCorrect = c.String(),
                        EighteenColdSealCorrect = c.String(),
                        NinteenFlushingCorrect = c.String(),
                        TwentyColdSealTempCorrect = c.String(),
                        TwentyColdSealPhCorrect = c.String(),
                        TwentyColdSealNikelCorrect = c.String(),
                        TwentyColdSealFluorideCorrect = c.String(),
                        TwentyColdSealCorrect = c.String(),
                        TwentyOneHotRinsingCorrect = c.String(),
                        TwentyTwoHotRinsingCorrect = c.String(),
                        TwentyThreeHotRinsingCorrect = c.String(),
                        ResultCorrect = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LaboratoryAnalysis");
        }
    }
}
