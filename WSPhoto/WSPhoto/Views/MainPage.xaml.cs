using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSPhoto.Models;
using WSPhoto.ViewModels;
using WSPhoto.WebServices;
using Xamarin.Forms;

namespace WSPhoto.Views
{
    public partial class MainPage : ContentPage
    {
        ImagensViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new ImagensViewModel();
            this.BindingContext = viewModel;
        }

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            // verifica se usuário informou Latitude e Longitude
            if (string.IsNullOrEmpty(txtLatitude.Text))
            {
                await DisplayAlert("Localidade", "Latitude não foi informada.", "Ok");
                txtLatitude.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLongitude.Text))
            {
                await DisplayAlert("Localidade", "Longitude não foi informada.", "Ok");
                txtLongitude.Focus();
                return;
            }

            // mostra indicador de processamento em segundo plano e limpa dados da última busca
            viewModel.IsBusy = true;
            viewModel.ListaVazia = false;
            viewModel.Imagens.Clear();

            // consumir WebService do Google Place Photos para obter imagens
            WSGooglePlacesResponse resp = await MyWebServices.GetSearchAsync(double.Parse(txtLatitude.Text), double.Parse(txtLongitude.Text));
            if (resp == null)
            {
                viewModel.IsBusy = false;
                viewModel.ListaVazia = true;
                return;
            }

            // verifica se foi encontrado alguma imagem
            if (resp.Results.Count == 0)
            {
                viewModel.IsBusy = false;
                viewModel.ListaVazia = true;
                return;
            }

            // percorre resultados para montar lista de imagens
            ImagensModel imgModel;
            object img;
            foreach (Result r in resp.Results)
            {
                if (r.Photos != null && r.Photos.Count > 0)
                {
                    foreach (Photo foto in r.Photos)
                    {
                        img = await MyWebServices.GetPhotoAsync(400, foto.Photo_reference);
                        imgModel = new ImagensModel(r.Name, foto.Html_attributions, r.Vicinity, r.Geometry.GeoLocation, img);

                        viewModel.Imagens.Add(imgModel);
                    }
                }
            }

            // esconde indicador de processamento em segundo plano
            viewModel.IsBusy = false;

            // indica se lista de imagens está vazia
            viewModel.ListaVazia = (viewModel.Imagens.Count == 0);
        }

        async void Imagem_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            // obtem item selecionado
            ImagensModel item = (ImagensModel)e.Item;
            if (item == null)
                return;

            // mostra janela com detalhes
            DetalheImagem detPage = new DetalheImagem(item);
            await Navigation.PushAsync(detPage);
        }
    }
}
