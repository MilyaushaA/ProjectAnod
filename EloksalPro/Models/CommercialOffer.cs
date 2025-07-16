using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloksalPro.Models
{
    public class CommercialOffer:BaseEntity
    {
        public string ClientName { get; set; }// наименование заказчика
        public string EloksalNoCommercial { get; set; }//  номенклатура заказчика
        public string NumberOffer { get; set; }//  номеt оффера
        public DateTime DateOffer { get; set; }//  номеt оффера
        public string TypeAnod { get; set; } //  вид покрытия
        public string ColorAnod { get; set; } //  цвет покрытия
        public string ThicknessCoating { get; set; } //  толщина покрытия
        public bool Trimming { get; set; } //  торцовка
        public bool Sawed { get; set; } //  распил
        public bool TapeProtective { get; set; } //  защитная пленка
        public double WeightMeter { get; set; }// вес погонного метра
        public double OuterPerimeter { get; set; }// внешний периметр
        public double PriceArea { get; set; }// общая цена  за м2 
        public double PriceKg { get; set; }// общая цена  за кг

        public double PriceAnodArea { get; set; }// цена анодирования за м2 
        public double PriceAnodKg { get; set; }// цена анодирования за кг

        public double PriceShotArea { get; set; }// цена дробейструя за м2 
        public double PriceShotKg { get; set; }// площадь дробейструя за кг 

        public double PriceTrimArea { get; set; }// цена обрезки контактных пятен за м2 
        public double PriceTrimKg { get; set; }// цена обрезки контактных пятен за кг 

        public double PriceSawedArea { get; set; }// цена распила за м2 
        public double PriceSawedKg { get; set; }// цена распила за кг 

        public double PriceProtectiveArea { get; set; }// цена наклейки защитной пленки за м2 
        public double PriceProtectiveKg { get; set; }// цена наклейки защитной пленки за кг 
        public double PriceStretchArea { get; set; }// цена наклейки защитной пленки за м2 
        public double PriceStretchKg { get; set; }// цена наклейки защитной пленки за кг 
        public string CoverageGeneralInformation { get; set; }
        public double PriceAreaSum
        {
            get  { return Math.Round((PriceAnodArea + PriceShotArea + PriceTrimArea + PriceSawedArea + PriceProtectiveArea+ PriceStretchArea), 2); }
        }
        public double PriceKgSum
        {
           get { return Math.Round((CalculatePriceAnodKg + CalculatePriceShotKg + CalculatePriceTrimKg + CalculatePriceSawedKg + CalculatePriceProtectiveKg + CalculatePriceStretchKg), 2); }
        }
        public double CalculatePriceAnodKg
        {
            get { return Math.Round(Convert.ToDouble(PriceAnodArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightMeter)), 2); }
        }
        public double CalculatePriceShotKg
        {
            get { return Math.Round(Convert.ToDouble(PriceShotArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightMeter)), 2); }
        }
        public double CalculatePriceTrimKg
        {
            get { return Math.Round(Convert.ToDouble(PriceTrimArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightMeter)), 2); }
        }
        public double CalculatePriceSawedKg
        {
            get { return Math.Round(Convert.ToDouble(PriceSawedArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightMeter)), 2); }
        }
        public double CalculatePriceProtectiveKg
        {
            get { return Math.Round(Convert.ToDouble(PriceProtectiveArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightMeter)), 2); }
        }
        public double CalculatePriceStretchKg
        {
            get { return Math.Round(Convert.ToDouble(PriceStretchArea) * (Convert.ToDouble(OuterPerimeter) / Convert.ToDouble(WeightMeter)), 2); }
        }
    }
}
