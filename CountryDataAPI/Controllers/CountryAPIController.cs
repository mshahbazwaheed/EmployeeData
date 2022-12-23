using CountryBL.ICountry;
using CountryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryAPIController : ControllerBase
    {
        private readonly IClass _CountryBL;

        public CountryAPIController(IClass CountryBL)
        {
            _CountryBL = CountryBL;
        }


        [HttpGet]
        [Route("GetCountries")]
        public JsonResult GetCountries()
        {
            var C_List = _CountryBL.GetAllCountries();
            return new JsonResult(new { C_List });
        }


        [HttpPost]
        [Route("AddCountry")]
        public JsonResult AddCountry(countryModel model)
        {
            var Adddata = _CountryBL.AddNewCountry(model);
            return new JsonResult(new { Adddata });
        }

    }
}
