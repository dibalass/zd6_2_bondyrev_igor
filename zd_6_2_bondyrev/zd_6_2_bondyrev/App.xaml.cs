using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd_6_2_bondyrev
{
    public partial class App :Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Cakes());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
