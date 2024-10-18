using AnimeListandUserList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AnimeListandUserList.Controllers
{
    public class Anime : Controller
    {
        // GET: Anime
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7003/controller/anime";

            List<AnimeContent> anime = new List<AnimeContent>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                anime = JsonConvert.DeserializeObject<List<AnimeContent>>(result);
            }
            return View(anime);
        }

        // GET: Anime/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Anime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anime/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AnimeContent anime)
        {
            string apiUrl = "https://localhost:7003/controller/Addanime";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(anime), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(anime);
        }

        // GET: Anime/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Anime/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnimeContent anime)
        {
            string apiUrl = "https://localhost:7003/controller/updateanime";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(anime), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PatchAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(anime);
        }



        // GET: Anime/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Anime/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string title)
        {
            string apiUrl = $"https://localhost:7003/controller/deleteanime?title={title}";

            using (HttpClient client = new HttpClient())
            {
      
                HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(title);
        }



    }
}
