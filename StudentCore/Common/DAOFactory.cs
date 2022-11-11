using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Infarstrure;

namespace StudentCore.Common
{
    public class DAOFactory
    {

        public static StudentDAO CreateStudentDAO()
        {
            StudentDAO studentDAO = new StudentSqlDAOImpl();
            return (StudentDAO)studentDAO;
        }

        public static CountryDAO CreateCountryDAO()
        {
            CountryDAO countryDAO = new CountryDAOImpl();
            return (CountryDAO)countryDAO;
        }

    }
}
