using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSPhoto.WebServices
{
    public class Location
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class Viewport
    {
        [JsonProperty("northeast")]
        public Location Northeast { get; set; }

        [JsonProperty("southwest")]
        public Location Southwest { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("location")]
        public Location GeoLocation { get; set; }

        [JsonProperty("viewport")]
        public Viewport GeoViewport { get; set; }
    }

    public class OpeningHours
    {
        [JsonProperty("open_now")]
        public bool Open_now { get; set; }

        [JsonProperty("weekday_text")]
        public List<object> Weekday_text { get; set; }
    }

    public class Photo
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("html_attributions")]
        public List<string> Html_attributions { get; set; }

        [JsonProperty("photo_reference")]
        public string Photo_reference { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class Result
    {
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("opening_hours")]
        public OpeningHours Opening_hours { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }

        [JsonProperty("place_id")]
        public string Place_id { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }

        [JsonProperty("vicinity")]
        public string Vicinity { get; set; }
    }

    public class WSGooglePlacesResponse
    {
        [JsonProperty("html_attributions")]
        public List<object> Html_attributions { get; set; }

        [JsonProperty("next_page_token")]
        public string Next_page_token { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
