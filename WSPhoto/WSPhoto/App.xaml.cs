using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WSPhoto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // página inicial da aplicação (com barra de navegação)
            Views.MainPage pagInicial = new Views.MainPage();
            MainPage = new NavigationPage(pagInicial)
            {
                BarBackgroundColor = Color.SteelBlue,
                BarTextColor = Color.White
            };

            NavigationPage.SetBackButtonTitle(MainPage, "");
            NavigationPage.SetHasBackButton(MainPage, true);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
