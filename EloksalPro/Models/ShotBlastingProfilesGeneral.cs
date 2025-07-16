using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ShotBlastingProfilesGeneral:BaseEntity
    {
        public DateTime Date { get; set; }
        public string Shift { get; set; }// смена
        public string Annotation { get; set; }
        public string Employee { get; set; }
        public string NumberShotGeneral { get; set; }
        public double GeneralQuantityProducedProfile { get; set; }
        public double GeneralQuantityDefectiveProfile { get; set; }
        public double GeneralAreaProducedProfile { get; set; }
        public double GeneralAreaDefectiveProfile { get; set; }
        public int Downtime { get; set; }

    }
}
