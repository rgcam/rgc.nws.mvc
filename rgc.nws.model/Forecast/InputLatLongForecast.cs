using System;
using System.ComponentModel.DataAnnotations;

namespace rgc.nws.model.Forecast
{
    public class InputLatLongForecast
    {
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
    }
}

