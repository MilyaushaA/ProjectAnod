using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class ExtensiveReceptionProfile:BaseEntity
    {
        public DateTime? Date { get; set; }//  номер паллета
        public string BasketNumber { get; set; }//  номер паллета
        public string ClientName { get; set; }// наименование заказчика
        public string NumberSpecification { get; set; }// номер заказа
        public string NomenclatureProfile { get; set; }//  номенклатура профиля
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public double WeightMeter { get; set; }// вес погонного метра
        public double LenghtProfile { get; set; } //  длина хлыста
        public int QuantityProducedProfile { get; set; } // количество хлыстов в паллете
        public double WeightProducedProfile { get; set; }//вес  профиля 
    }
}
