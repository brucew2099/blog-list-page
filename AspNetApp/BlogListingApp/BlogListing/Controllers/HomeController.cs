using BlogListing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogListing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        string apiBaseUrl = "https://localhost:44317";

        public async Task<IActionResult> Index()
        {
            List<Topic> topics = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("blog/topics");

                if(getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    topics = JsonConvert.DeserializeObject<List<Topic>>(results);
                }
                else
                {
                    return BadRequest("Error calling the API");
                }

            }

            ViewData.Model = topics;

            return View();
        }

        public async Task<IActionResult> Blog(string topic)
        {
            List<Blog> blogs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync($"blog/topics/{topic}/blogs");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    blogs = JsonConvert.DeserializeObject<List<Blog>>(results);
                }
                else
                {
                    return BadRequest("Error calling the API");
                }

            }

            ViewData.Model = blogs;

            return View();
        }

        public async Task<IActionResult> Posts(string id)
        {
            Blog blog = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync($"api/Blogs/{id}");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    blog = JsonConvert.DeserializeObject<Blog>(results);
                }
                else
                {
                    return BadRequest("Error calling the API");
                }

            }

            ViewData.Model = blog;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
