using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSPhoto.Models;
using WSPhoto.WebServices;

namespace WSPhoto.ViewModels
{
    public class DetalheViewModel : INotifyPropertyChanged
    {
        public string Titulo { get; set; }
        public object Imagem { get; set; }
        public Location Local { get; set; }
        public string Coordenadas { get; set; }
        public string Atributo { get; set; }
        public string Vizinhanca { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InformaAlteracao(string propriedade)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                InformaAlteracao("IsBusy");
            }
        }

        public DetalheViewModel(ImagensModel img)
        {
            Titulo = img.Titulo;
            Imagem = img.ImagemHD;
            _isBusy = (img.ImagemHD == null);
            Local = img.Local;
            Coordenadas = img.Coordenadas;
            Atributo = img.Atributo;
            Vizinhanca = img.Vizinhanca;
        }
    }
}
