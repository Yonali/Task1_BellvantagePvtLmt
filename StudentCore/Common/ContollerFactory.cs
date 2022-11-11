using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Controller;

namespace StudentCore.Common
{
    public class ContollerFactory
    {

        public static StudentController CreateStudentController()
        {
            StudentController studentController = new StudentControllerImpl();
            return (StudentController)studentController;
        }

        public static CountryController CreateCountryController()
        {
            CountryController countryController = new CountryControllerImpl();
            return (CountryController)countryController;
        }

    }
}
