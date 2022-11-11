using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;

namespace StudentCore.Common
{
    public class DataAccessObject : IDisposable
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbConnection"></param>
        /// <param name="readCommand"></param>
        /// <returns></returns>
        public List<T> ReadCollection<T>(SqlDataReader reader) where T : class
        //public List<T> ReadCollection<T>(OdbcDataReader reader) where T : class
        {
            List<T> collection = new List<T>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    T item = GetItemFromReader<T>(reader);
                    collection.Add(item);
                }
            }

            return collection;

        }
        /// <summary>
        /// This method is used to Read Table Row From databse and assing its column values to 
        /// Relevant Domain object.
        /// </summary>
        /// <typeparam name="T">Generic Domain Object</typeparam>
        /// <param name="dbConnection">Opend Database Connection</param>
        /// <param name="readCommand">parameterized Sql Command</param>
        /// <returns>Generic Domain Object</returns>
        //public T GetSingleOject<T>(OdbcDataReader reader) where T : class
        public T GetSingleOject<T>(SqlDataReader reader) where T : class
        {
            Type type = typeof(T);
            T singleObject = Activator.CreateInstance<T>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    singleObject = GetItemFromReader<T>(reader);
                }
            }
            return singleObject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rdr"></param>
        /// <returns></returns>
        //public T GetItemFromReader<T>(OdbcDataReader rdr) where T : class
        public T GetItemFromReader<T>(SqlDataReader rdr) where T : class
        {
            Type type = typeof(T);
            T item = Activator.CreateInstance<T>();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Type type1 = property.ReflectedType;
                // for each property declared in the type provided check if the property is
                // decorated with the DBField attribute
                if (Attribute.IsDefined(property, typeof(DBFieldAttribute)))
                {
                    DBFieldAttribute attrib = (DBFieldAttribute)Attribute.GetCustomAttribute(property, typeof(DBFieldAttribute));

                    try
                    {

                        if (Convert.IsDBNull(rdr[attrib.fieldName])) // data in database is null, so do not set the value of the property
                            continue;
                    }
                    catch (Exception)
                    {
                        continue;
                    }



                    if (property.PropertyType == rdr[attrib.fieldName].GetType()) // if the property and database field are the same
                        property.SetValue(item, rdr[attrib.fieldName], null); // set the value of property
                    else
                    {
                        try
                        {
                            property.SetValue(item, Convert.ChangeType(rdr[attrib.fieldName], property.PropertyType), null);
                        }
                        catch (Exception)
                        {
                            property.SetValue(item, rdr[attrib.fieldName].ToString().Trim(), null);
                        }
                        // change the type of the data in table to that of property and set the value of the property

                        // for SQL attrib.FieldName canbe modified as ( "@" +attrib.FieldName)
                    }

                }
            }

            return item;
        }


        #region IDisposable Members

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}
