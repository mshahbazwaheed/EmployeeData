using CountryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountryBL.ICountry
{
    public interface IClass
    {
        List<countryModel> GetAllCountries();

        int AddNewCountry(countryModel Model);
        

    }
}
