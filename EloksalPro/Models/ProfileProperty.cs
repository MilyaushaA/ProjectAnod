using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ProfileProperty:BaseEntity
    {
        public string PropertyProfile { get; set; } // свойство профиля
        public string ValuePropertyProfile { get; set; } //  значние свойства профиля
   
    }
}
