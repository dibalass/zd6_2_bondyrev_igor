using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd_6_2_bondyrev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculate :ContentPage
    {
        double _metr=1, _price;
        int _days;

        public Calculate (double Metr, double Price, int Days)
        {
            InitializeComponent();
            metr.Text = "Кол-во метров: " + Metr;
            price.Text = "Цена за кг. торта: " + Price;
            day.Text = "Количество дней на изготовление: " + Days;
            _metr = Metr;
            _price = Price;
            _days = Days;
        }

        public void Calculator (double price, int paymentType, int productionDays)
        {
            double total_price = 0;
            if(paymentType==1)
            {
                total_price = price + price * 0.4;
            }
            if (paymentType == 2)
            {
                total_price = price + price * 0.2;
            }
            if (paymentType == 3)
            {
                total_price = price + price * 0.1;
            }
            if (paymentType == 4)
            {
                total_price = price;
            }
            //if (paymentType == 1)
            //{
            //    double discount = price * 0.1;
            //    total_price = price - discount;
            //} else if (paymentType == 2)
            //{
            //    double surcharge = price * 0.1;
            //    total_price = price + surcharge;
            //}
            //if (productionDays >= 20 && productionDays <= 30)
            //{
            //    double surcharge = total_price * -0.05;
            //    total_price += surcharge;
            //} else if (productionDays >= 10 && productionDays <= 18)
            //{
            //    double surcharge = total_price * 0.1;
            //    total_price += surcharge;
            //} else if (productionDays >= 1 && productionDays <= 5)
            //{
            //    double surcharge = total_price * 0.25;
            //    double surcharge_per_day = surcharge / productionDays;
            //    total_price += surcharge_per_day * productionDays;
            //}
            double cost_ = total_price * _metr;
            cost.Text = "Стоимость: " + cost_.ToString();
        }

        private void next_Clicked (object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PopAsync();
        }

        private void back_Clicked (object sender, EventArgs e)
        {
            Navigation.PopAsync();

        }

        private void PaymentTypePicker_SelectedIndexChanged (object sender, EventArgs e)
        {
            int paymentType = PaymentTypePicker.SelectedIndex + 1;
            Calculator(_price, paymentType, _days);
        }

    }
}