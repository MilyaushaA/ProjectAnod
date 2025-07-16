using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ClientCard : BaseEntity
    {
       
        public string ClientName { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? DateContract { get; set; }
        public string PhysicalAddress { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumberPhone { get; set; }
        public string ContactNumberPhoneAnother { get; set; }
        public string ContactEmail { get; set; }
        public string Manager { get; set; }
        public IEnumerable<ProfileCardComercial> ProfileCardComercials { get; set; } = new List<ProfileCardComercial>();

    }
}
