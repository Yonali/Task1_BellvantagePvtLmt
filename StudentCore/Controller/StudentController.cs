using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Domain;
using StudentCore.Infarstrure;
using StudentCore.Common;


namespace StudentCore.Controller
{
    public interface StudentController
    {
        int Save(Student student);
        int Update(Student student);
        List<Student> GetStudentList(bool withCountry);

    }

    public class StudentControllerImpl : StudentController
    {
        StudentDAO studentDAO = DAOFactory.CreateStudentDAO();

        public int Save(Student student)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return studentDAO.Save(student, dbConnection);
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

        public int Update(Student student)
        {
            DbConnection dbConnection = null;
            try
            {
                dbConnection = new DbConnection();
                return studentDAO.Update(student, dbConnection);
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

        public List<Student> GetStudentList(bool withCountry)
        {
            DbConnection dbConnection = null;
            List<Student> listStudent = new List<Student> ();
            try
            {
                dbConnection = new DbConnection();
                listStudent = studentDAO.GetStudentList(dbConnection);
                if (withCountry)
                {
                    CountryDAO countryDAO = DAOFactory.CreateCountryDAO();
                    List<Country> listCountry = countryDAO.GetCountryList(dbConnection);

                    foreach (var student in listStudent)
                    {
                        student.country = listCountry.Where(x => x.CountryCode == student.CountryCode).Single();
                    }
                }

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
            return listStudent;
        }
    }
}
