using CountryModel;
using Dapper;
using DatabaseFactory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountryRepository
{
    public class countryRepository
    {
        private IDapper _dapper;

        public countryRepository(IConfiguration config)
        {
            _dapper = new Dapperr(config);
        }

        public List<countryModel> GetAllCountriesList()
        {
            var countryName = _dapper.GetAll<countryModel>(SqlQuery.GetCountries, null, System.Data.CommandType.Text);
            return countryName;
        }

        public int AddCountry(countryModel Model)
        {
            DynamicParameters param = new DynamicParameters();
            param.AddDynamicParams(new { Model.country_id });
            param.AddDynamicParams(new { Model.country_name });
            param.AddDynamicParams(new { Model.created_by });

            var addData = _dapper.Execute(SqlQuery.AddCountry, param, System.Data.CommandType.StoredProcedure);
            return addData;
        }
    }
}
