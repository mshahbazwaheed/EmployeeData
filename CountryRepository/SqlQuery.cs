using System;
using System.Collections.Generic;
using System.Text;

namespace CountryRepository
{
    public class SqlQuery
    {
        public const string GetCountries = "select * from Countries";
        public const string AddCountry = "sp_addCountry";
    }
}
