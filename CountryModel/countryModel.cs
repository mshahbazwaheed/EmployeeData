using System;
using System.Collections.Generic;

namespace CountryModel
{
    public class CList
    {
        public int country_id { get; set; }
        public string country_name { get; set; }
        public string created_by { get; set; }
    }

    public class countryModel
    {
        public List<CList> c_List { get; set; }
    }

}
