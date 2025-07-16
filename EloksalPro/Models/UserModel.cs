using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class UserModel:BaseEntity
    {
      
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] TimeStamp;
        public int Role { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Annotation { get; set; }
    }
}
