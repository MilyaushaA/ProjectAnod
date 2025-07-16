using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ImageProfileParking : BaseEntity
    {
        public byte[] ImageBytes { get; set; }
        public int ClientId { get; set; }
    }
}