
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Simple_Restful_Api.Model;


namespace Simple_Restful_Api.Controllers
{

    //this controller will send a http request to the third party restful api,
    //then process the data which is returned
    [ApiController]
    [Route("[controller]")]
    public class DigimonController : ControllerBase
    {
        private readonly HttpClient _client;

        public DigimonController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }

            _client = clientFactory.CreateClient("digimon");
        }


        /// <summary>
        /// Gets the raw JSON for the digimon
        /// </summary>
        /// <returns>A string representing the digimon information for you according to your age</returns>
        [HttpGet]
        [Route("age")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetYourDigimonByAge(int age)
        {
            string name = "";

            if (age < 14)
            {
                name = "in training";
            }
            else if (age < 16)
            {
                name = "Training";

            }
            else if (age < 18)
            {
                name = "Fresh";

            }
            else if (age < 20)
            {
                name = "Rookie";

            }
            else if (age < 22)
            {
                name = "Champion";

            }
            else if (age < 24)
            {
                name = "Armor";
            }
            else if (age < 26)
            {
                name = "Mega";
            }
            else
            {
                name = "Ultimate";
            }


            var res = await _client.GetAsync(name);
            var content = await res.Content.ReadAsStringAsync();
            List<Digimon> digimons = new List<Digimon>();
            object? obj = JsonConvert.DeserializeObject(content, typeof(List<Digimon>));
            digimons = (List<Digimon>)obj!;

            int maxLength = digimons.Count;
            Random rd = new Random();
            int index = rd.Next(0, maxLength);

            string msg = "Your Digimon is:\nName: " + digimons[index].Name + "\nLevel: " + digimons[index].Level + "\nimageUrl: "
                + digimons[index].img;

            return Ok(msg);
        }

    }
}

