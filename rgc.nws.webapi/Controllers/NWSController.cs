using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rgc.nws.model.Forecast;
using rgc.nws.webapi.Utilities;

namespace rgc.nws.webapi.Controllers
{
    [ApiController]
    [Produces("application/ld+json")]
    [Route("api/[controller]")]
    public class NWSController : ControllerBase
    {
        private Constants _constants;

        public NWSController(/*Constants constants*/)
        {
            //_constants = constants;
        }

        /// <summary>
        /// Returns informations for a specific city.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// {
        ///     "Latitude" : 40.585258,
        ///     "Longitude" : -105.084419
        /// }
        /// </remarks>
        /// <response code="200">Returns the response.</response>
        /// <response code="400">If the item is null</response>
        [HttpGet(Name = "GetForecast")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OutputForecastHeaders>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OutputForecastHeaders.Root>> GetWeatherForecast()
        {
            HttpClient client = new HttpClient();
            Constants constants = new Constants();

            // TODO : Figure out how to make the request uri dynamic
            var request = new HttpRequestMessage
            {
                //RequestUri = constants.LatLongForecastEndpoint(input),
                RequestUri = new Uri("https://api.weather.gov/points/40.585258,-105.084419"),
                Method = HttpMethod.Get,
                Headers =
                {
                    {"User-Agent", "1" }
                }
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                var json_result = await System.Text.Json.JsonSerializer.DeserializeAsync<OutputForecastHeaders.Root>(result);
                return json_result;
            }
            return BadRequest();
        }

    }
}

