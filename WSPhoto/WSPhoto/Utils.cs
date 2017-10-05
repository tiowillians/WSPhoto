using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WSPhoto
{
    public class Utils
    {

        static public object ConvertToImage(byte[] img)
        {
            if (img != null)
            {
                Image image = new Image();
                image.Source = ImageSource.FromStream(() => new MemoryStream(img));

                return image.Source;
            }

            return null;
        }

        static public byte[] ConvertToByteArray(Stream input)
        {
            if (input == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
