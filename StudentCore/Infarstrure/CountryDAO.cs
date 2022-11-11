using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Domain;
using StudentCore.Common;

namespace StudentCore.Infarstrure
{
    public interface CountryDAO
    {
        List<Country> GetCountryList(DbConnection dbConnection);
        Country GetCountry(string countryCode, DbConnection dbConnection);
    }

    public class CountryDAOImpl : CountryDAO
    {
        public List<Country> GetCountryList(DbConnection dbConnection)
        {
            List<Country> listCountry = new List<Country>();

            dbConnection.cmd.CommandText = "select * from dbo.country where is_active =1";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            listCountry = dataAccessObject.ReadCollection<Country>(dbConnection.dr);
            dbConnection.dr.Close();

            return listCountry;
        }

        public Country GetCountry(string countryCode, DbConnection dbConnection)
        {
            Country country = new Country();
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "select * from dbo.country where ID = @countryCode  and is_active =1";

            dbConnection.cmd.Parameters.AddWithValue("@countryCode", countryCode);

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            country = dataAccessObject.GetSingleOject<Country>(dbConnection.dr);

            dbConnection.dr.Close();
            return country;
        }
    }
}
