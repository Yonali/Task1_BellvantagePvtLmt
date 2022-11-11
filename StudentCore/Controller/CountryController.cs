using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Domain;
using StudentCore.Infarstrure;
using StudentCore.Common;


namespace StudentCore.Controller
{
    public interface CountryController
    {
        List<Country> GetCountryList();
        Country GetCountry(string countryCode);
    }

    public class CountryControllerImpl : CountryController
    {
        CountryDAO countryDAO = DAOFactory.CreateCountryDAO();

        public List<Country> GetCountryList()
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return countryDAO.GetCountryList(dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }

        public Country GetCountry(string countryCode)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return countryDAO.GetCountry(countryCode,dbConnection);
            }
            catch (Exception)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                {
                    dbConnection.Commit();
                }
            }
        }
    }
}
