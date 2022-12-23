using CountryBL.ICountry;
using CountryModel;
using CountryRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountryBL.Concrete
{
    public class CountryClass : IClass
    {
        public countryRepository _Repository;

        public CountryClass(IConfiguration config)
        {
            _Repository = new countryRepository(config);
        }
        public List<countryModel> GetAllCountries()
        {
            var CountryList = _Repository.GetAllCountriesList();
            if (CountryList == null || CountryList.Count <= 0)
            {
                throw new Exception();
            }
            return CountryList;
        }

        public int AddNewCountry(countryModel Model)
        {
            int data = 0;
            if (Model == null)
            {
                throw new ArgumentNullException();
            }
 
                    data += _Repository.AddCountry(Model);

            return data;
        }
    }
}
