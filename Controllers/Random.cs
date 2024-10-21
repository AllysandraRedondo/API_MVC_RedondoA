using AnimeListandUserList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;



namespace AnimeListandUserList.Controllers
{
    public class Random : Controller
    {
        public async Task<IActionResult> Index()
        {
            string apiUrl = "https://yesno.wtf/api"; // URL for the YesNo API

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var yesNoResponse = JsonConvert.DeserializeObject<YesNo>(result);
                    return View(yesNoResponse); // Pass the model to the view
                }
                return View(null); // Handle error case
            }
        }
    }
}