using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class СharacteristicProfile:BaseEntity
    {
        public string ProfilePropertyName { get; set; }
        public string ProfilePropertyMarking { get; set; }
        public string ProfilePropertyDescription { get; set; }
    }
}
