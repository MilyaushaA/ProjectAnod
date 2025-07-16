using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class CommercialOfferGeneral:BaseEntity
    {
        public string ClientName { get; set; }// наименование заказчика
        public string NumberOffer { get; set; }//  номеt оффера
        public DateTime DateOffer { get; set; }//  номеt оффера
        public string Manager { get; set; }//  номеt оффера
    }
}
