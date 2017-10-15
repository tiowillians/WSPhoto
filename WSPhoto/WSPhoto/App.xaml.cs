using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSPhoto.Views;
using Xamarin.Forms;

namespace WSPhoto
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // página inicial da aplicação (com barra de navegação)
            PaginaInicial pagInicial = new PaginaInicial();
            MainPage = new NavigationPage(pagInicial)
            {
                BarBackgroundColor = Color.MediumVioletRed,
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
