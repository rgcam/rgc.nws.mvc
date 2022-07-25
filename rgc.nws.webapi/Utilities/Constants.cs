using System;
using rgc.nws.model.Forecast;

namespace rgc.nws.webapi.Utilities
{
    public class Constants
    {
        // NWS Endpoints
        // https://www.weather.gov/documentation/services-web-api

        /// <summary>
        /// The National Weather Service (NWS) endpoint used for retrieving forecast data. Requires the latitude and longitude of the city in which the forecast is needed.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public Uri LatLongForecastEndpoint(InputLatLongForecast input)
        {
            return new Uri($"https://api.weather.gov/points/{input.Latitude},{input.Longitude}");
        }

    }
}

