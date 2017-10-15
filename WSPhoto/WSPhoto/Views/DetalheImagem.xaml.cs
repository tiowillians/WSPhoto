using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSPhoto.Models;
using WSPhoto.ViewModels;
using WSPhoto.WebServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSPhoto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheImagem : ContentPage
    {
        DetalheViewModel viewModel;

        public DetalheImagem(PaginaInicial pai, ImagensModel im)
        {
            InitializeComponent();
            viewModel = new DetalheViewModel(im);
            this.BindingContext = viewModel;

            ObtemImagemHD(pai, im);
        }

        public async Task ObtemImagemHD(PaginaInicial pai, ImagensModel im)
        { 
            if (im.ImagemHD == null)
            {
                object imgHD = await MyWebServices.GetPhotoAsync(
                                            (im.Width > im.Height ? im.Width : im.Height) / 2,
                                            im.Reference);
                if (imgHD != null)
                {
                    viewModel.Imagem = imgHD;
                    pai.AtualizaImagemHD(im.Reference, imgHD);
                    viewModel.InformaAlteracao("Imagem");
                }

                viewModel.IsBusy = false;
            }
        }
    }
}