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
    public partial class Cakes :ContentPage
    {
        public List<Cake> cakes { get; set; }
        public Cakes ()
        {
            InitializeComponent();
            cakes = new List<Cake>
            {
                new Cake {Name="Шоколадный бисквит на кипятке",
                    Category="Бисквитный",
                    Cost=1000,
                    Unit="Цельный торт",
                    Fats = 300,
                    Belky = 200,
                    Yglevody = 50,
                    Vitamins = 10,
                    Price = 1000,
                    Provider="Цитрон",
                    Count="в наличии",
                    Recipe="Рецепт:",
                    ImagePath="chocolate.jpg"},

                new Cake {Name="Торт Муравьиная горка с маком",
                    Category="Песочный",
                    Cost=1000,
                    Unit="Кусочек",
                    Fats = 10,
                    Belky = 300,
                    Yglevody = 150,
                    Vitamins = 300,
                    Price = 1000,
                    Provider="Цитрон",
                    Count="в наличии",
                    Recipe="Рецепт:",
                    ImagePath = "sand.jpg"},

                new Cake {Name="Торт мороженное",
                    Category="Вафельный",
                    Cost=1000,
                    Unit="Цельный торт",
                    Fats = 500,
                    Belky = 300,
                    Yglevody = 100,
                    Vitamins = 100,
                    Price = 250,
                    Provider="Цитрон",
                    Count="в наличии",
                    Recipe="Рецепт:",
                    ImagePath = "vafel.jpg"},

                new Cake {Name="Торт Сахара",
                    Category="Твороженный",
                    Cost=300,
                    Unit="Кусочек",
                    Fats = 50,
                    Belky = 150,
                    Yglevody = 250,
                    Vitamins = 300,
                    Price = 300,
                    Provider="Цитрон",
                    Count="в наличии",
                    Recipe="Рецепт:",
                    ImagePath = "tvorog.jpg"}
            };
            Label header = new Label
            {
                Text = "Онлайн кулинария\n(заказ и покупка тортов)",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Blue,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
            };

            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = cakes,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Title");
                    Binding companyBinding = new Binding { Path = "Price", StringFormat = "Цена торта {0}" };
                    imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
                    return imageCell;
                })
            };
            listView.ItemTapped += OnItemTapped;
            this.Content = new StackLayout { Children = { header, listView, runningtitle, date, button } };
        }
        Cake selectedCake;
        public void OnItemTapped (object sender, ItemTappedEventArgs e)
        {
            selectedCake = e.Item as Cake;
            if (selectedCake != null)
            {
                runningtitle.Text = $"Торт: {selectedCake.Count} - {selectedCake.Name}";
            }

        }

        private void Button_Clicked (object sender, EventArgs e)
        {
            if (selectedCake != null)
            {
                Navigation.PushAsync(new MainPage(selectedCake));
            } else
                DisplayAlert("Ошибка", "Выбери торт", "Ок");
        }

        private void Button_Clicked_1 (object sender, EventArgs e)
        {
            if (selectedCake != null)
            {
                Navigation.PushAsync(new Calculate(selectedCake.Metr=1, selectedCake.Price, selectedCake.Belky));
            } else
                DisplayAlert("Ошибка", "Выбери торт", "Ок");
        }
    }
}