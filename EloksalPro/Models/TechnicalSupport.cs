using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class TechnicalSupport:BaseEntity
    {
        public string Number { get; set; } //номер заявки
        public DateTime? DateApp { get; set; } //дата заявки
        public DateTime? DatePreliminaryReadiness { get; set; }//дата предв готовности
        public DateTime? DateReadiness { get; set; }//дата исполнения
        public string ApplicationText { get; set; }//текст заявки
        public string Customer { get; set; }//заказчик
    }
}
