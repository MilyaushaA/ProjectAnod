using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
   public class UserAccountModel
    {
            public string Username { get; set; }
            public string DisplayName { get; set; }
            public string PhoneNumber{ get; set; }
            public int Role { get; set; }
            public byte[] ProfilePicture { get; set; }  
    }
}
