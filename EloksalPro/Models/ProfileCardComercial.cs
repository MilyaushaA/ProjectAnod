using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class ProfileCardComercial : BaseEntity
    {
        public string EloksalNoCommercial { get; set; }
        public int ClientId { get; set; }
        public ClientCard ClientCardNavigation { get; set; }
    }
}
