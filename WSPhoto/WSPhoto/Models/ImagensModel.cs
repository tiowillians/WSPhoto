using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSPhoto.WebServices;
using Xamarin.Forms;

namespace WSPhoto.Models
{
    public class ImagensModel
    {
        public string Titulo { get; set; }
        public object Imagem { get; set; }
        public Location Local { get; set; }
        public string Coordenadas { get; set; }
        public string Atributo { get; set; }
        public string Vizinhanca { get; set; }

        public ImagensModel(string titulo, List<string> atributos, string vizinhanca, Location local, object img)
        {
            Titulo = titulo;
            Vizinhanca = vizinhanca;
            Local = local;
            Imagem = img;

            Coordenadas = local.Lat.ToString() + " ; " + local.Lng.ToString();

            if (atributos == null || atributos.Count == 0)
                Atributo = string.Empty;
            else
                Atributo = atributos[0];
        }
    }
}
