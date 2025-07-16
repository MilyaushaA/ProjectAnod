using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class AppendixSpesification
    {
        public string EloksalNoCommercial { get; set; }
        public int LenghtProfile { get; set; }
        public int LenghtProfileTwo { get; set; }
        public double AmountPiece { get; set; }
        public double AmountPieceTwo { get; set; }
        public string NomenclatureProfile { get; set; }
        public int LenghtProfileFact { get; set; }
        public int AmountPieceFact { get; set; }
        public double WeightPMetr { get; set; }
        public double OuterPerimeter { get; set; }
        public string ThicknessCoating { get; set; } //  толщина покрытия
        public string TypePackaging { get; set; } //  вид покрытия
        public string Manager { get; set; }

        public double TechnologicalWaste
        {
            get { return (((LenghtProfileFact * AmountPieceFact)-(LenghtProfile*AmountPiece)- (LenghtProfileTwo * AmountPieceTwo)) /1000); }
        }

    }
}
