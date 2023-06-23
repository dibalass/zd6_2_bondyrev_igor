using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zd_6_2_bondyrev
{
    public partial class MainPage :ContentPage
    {
        double Metr;
        double Price;
        int Days;
        public MainPage (Cake cake)
        {
            InitializeComponent();
            Info(cake);
        }
        public void Info (Cake cake)
        {
            try
            {
                picture.Source = cake.ImagePath;
                name.Text = "Название " + cake.Name;
                category.Text = "Категория " + cake.Category;
                unit.Text = "Единица измерения " + cake.Unit;
                fats.Text = "Жиры " + cake.Fats;
                belky.Text = "Белки " + cake.Belky;
                yglevody.Text = "Углеводы " + cake.Yglevody;
                vitamins.Text = "Витамины " + cake.Vitamins;
                provider.Text = "Поставщик  " + cake.Provider;
                recipe.Text = "Рецепт " + cake.Recipe;
                Price = cake.Price;
                Days = Convert.ToInt32(cake.Belky);
            } catch
            {
                DisplayAlert("Ошибка", "Введите число", "Ок");
            }
        }
        private void next_Clicked (object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(entry.Text) <= 10 || double.Parse(entry.Text) >= 0.5)
                {
                    Metr = double.Parse(entry.Text);
                    Navigation.PushAsync(new Calculate(Metr, Price, Days));
                } else
                    DisplayAlert("Ограничение", "Вес должен быть от 0.5 до 10 кг.", "Ок");
            } catch
            {
                DisplayAlert("Ошибка", "Введите число", "Ок");
            }
        }

        private void back_Clicked (object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
