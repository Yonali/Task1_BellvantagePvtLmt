using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentCore.Domain;
using StudentCore.Common;

namespace StudentCore.Infarstrure
{
    public interface StudentDAO
    {
        int Save(Student student, DbConnection dbConnection);
        int Update(Student student, DbConnection dbConnection);
        List<Student> GetStudentList(DbConnection dbConnection);
    }

    public class StudentSqlDAOImpl : StudentDAO
    {
        public int Save(Student student, DbConnection dbConnection)
        {

            int output = 0;


            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "Insert into Student (Country_ID ,First_Name,Last_Name,Email ,Gender,Created_date ,Created_By) " +
                                           "values (@CountryCode,@FirstName,@LastName,@Email,@Gender,@CreatedDate,@CreatedBy) SELECT SCOPE_IDENTITY() ";


            dbConnection.cmd.Parameters.AddWithValue("@CountryCode", student.CountryCode);
            dbConnection.cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            dbConnection.cmd.Parameters.AddWithValue("@LastName", student.LastName);
            dbConnection.cmd.Parameters.AddWithValue("@Email", student.Email);
            dbConnection.cmd.Parameters.AddWithValue("@Gender", student.Gender);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedBy", "Admin");

            output = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());


            return output;
        }

        public int Update(Student student, DbConnection dbConnection)
        {

            int output = 0;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "Update Student set Country_ID = @CountryCode ,First_Name = @FirstName,Last_Name = @LastName,Email  =@Email ,Gender = @Gender WHERE ID = @StudentId ";


            dbConnection.cmd.Parameters.AddWithValue("@CountryCode", student.CountryCode);
            dbConnection.cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            dbConnection.cmd.Parameters.AddWithValue("@LastName", student.LastName);
            dbConnection.cmd.Parameters.AddWithValue("@Email", student.Email);
            dbConnection.cmd.Parameters.AddWithValue("@Gender", student.Gender);
            dbConnection.cmd.Parameters.AddWithValue("@StudentId", student.StudentId);

            output = dbConnection.cmd.ExecuteNonQuery();


            return output;
        }

        public List<Student> GetStudentList(DbConnection dbConnection)
        {
            List<Student> listStudent = new List<Student>();

            dbConnection = new DbConnection();

            dbConnection.cmd.CommandText = "select * from student";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            listStudent = dataAccessObject.ReadCollection<Student>(dbConnection.dr);
            dbConnection.dr.Close();


            return listStudent;
        }
    }

}
