using CountryModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountryDataUI.Controllers
{
    public class CountryDataUIController : Controller
    {
        HttpClient client = new HttpClient();
        MasterModel Model = new MasterModel(); 
        public async Task<IActionResult> Index()
        {
            client.BaseAddress = new Uri("http://localhost:62215/api/CountryAPI/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage country_list = await client.GetAsync("GetCountries");

            if (country_list.IsSuccessStatusCode)
            {
                var GetData = country_list.Content.ReadAsStringAsync().Result;
                Model.CModel = JsonConvert.DeserializeObject<countryModel>(GetData);

            }
            else
            {
                return NotFound();
            }

            return View(Model);
        }

        public IActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(CList model)
        {
            if (ModelState.IsValid)
            { 
            using (HttpClient client1 = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62215/api/CountryAPI/");
                HttpResponseMessage surveyData = await client.PostAsJsonAsync("AddCountry", model);
                surveyData.EnsureSuccessStatusCode();
            }
            }
            else
            {
                ViewData["ErrorMessage"] = "Fill All Form";
                return View("AddCountry");
            }

            return RedirectToAction("Index");
        }

    }
}
