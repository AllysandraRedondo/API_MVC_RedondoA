using AnimeListandUserList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AnimeListandUserList.Controllers
{
    public class User : Controller
    {
        // GET: HomeController1
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7003/controller/user";

            List<Owner> anime = new List<Owner>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                anime = JsonConvert.DeserializeObject<List<Owner>>(result);
            }
            return View(anime);
        }



        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(Owner user)
            {
                string apiUrl = "https://localhost:7003/controller/Adduser";
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(user);
            }

            // GET: HomeController1/Edit/5
            public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Owner user)
        {
            string apiUrl = "https://localhost:7003/controller/updateuser";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PatchAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

            public async Task<ActionResult> Delete(string user)
            {
                string apiUrl = $"https://localhost:7003/controller/deleteuser?user={user}";

                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
                return View(user);
            }

        }
    }

