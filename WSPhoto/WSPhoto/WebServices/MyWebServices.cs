using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WSPhoto.WebServices
{
    public class MyWebServices
    {
        // URL para acessar WebService Google Place Photo
        public const string URL_WS_SEARCH = "https://maps.googleapis.com/maps/api/place/search/json?";
        public const string URL_WS_PHOTO = "https://maps.googleapis.com/maps/api/place/photo?";
        public const string GOOGLE_ACCESS_KEY = "AIzaSyA_DvP2kVLTomcZMWtL8iVs1ZxyObGDCBU";

        public static async Task<WSGooglePlacesResponse> GetSearchAsync(double lat, double lng)
        {
            string url = URL_WS_SEARCH;
            url += "location=" + lat.ToString().Replace(',', '.');
            url += "," + lng.ToString().Replace(',', '.');
            url += "&radius=50000";
            url += "&key=" + GOOGLE_ACCESS_KEY;
            string resp = await GetStringAsync(url);
            if (resp == null)
                return null;

            WSGooglePlacesResponse placesResponse = JsonConvert.DeserializeObject<WSGooglePlacesResponse>(resp);
            return placesResponse;
        }

        public static async Task<object> GetPhotoAsync(int maxwidth, string reference)
        {
            string url = URL_WS_PHOTO;
            url += "maxwidth=" + maxwidth.ToString();
            url += "&photoreference=" + reference;
            url += "&key=" + GOOGLE_ACCESS_KEY;

            byte[] bytes = await GetByteArrayAsync(url);
            return Utils.ConvertToImage(bytes);
        }

        public static async Task<string> GetStringAsync(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var strDados = await client.GetStringAsync(url);
                    return strDados;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        static public async Task<byte[]> GetByteArrayAsync(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var arr = await client.GetByteArrayAsync(url);
                    return arr;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
