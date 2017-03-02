using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain.Entities;


namespace Domain.Concrete
{
    public class DataBase
    {
        private string stringConnection;
        private SqlConnection connection;

        public DataBase(string strConn)
        {
            stringConnection = strConn;
        }

        public List<Person> GetData()
        {
            List<Person> result = new List<Person>();
            using (connection = new SqlConnection(stringConnection))
            {
                try
                {
                    connection.Open();
                    string StrCommand = String.Format("SELECT * FROM People");
                    SqlCommand command = new SqlCommand(StrCommand, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {                        
                            result.Add(new Person {ID=int.Parse(reader["ID"].ToString().TrimEnd(' ')),
                                                   FirstName = reader["FirstName"].ToString().TrimEnd(' '),
                                                   LastName= reader["LastName"].ToString().TrimEnd(' '),
                                                   Age= int.Parse(reader["Age"].ToString().TrimEnd(' ')),
                                                   Sex= reader["Sex"].ToString().TrimEnd(' ')
                            });

                        }
                        reader.Close();

                    }
                    else
                    {
                        reader.Close();


                    }
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
            return result;
        }

        public void DeleteData(int ID) {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                try
                {
                    connection.Open();
                    string StrCommand = String.Format("DELETE FROM People WHERE ID={0}", ID);
                    SqlCommand command = new SqlCommand(StrCommand, connection);
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }

        public void EditData(Person pers) {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                try
                {
                    connection.Open();
                    string StrCommand;
                    StrCommand = String.Format("UPDATE People SET Age={0},LastName='{1}',FirstName='{2}',Sex='{3}' WHERE ID={4}", pers.Age,pers.LastName,pers.FirstName,pers.Sex,pers.ID);
                    SqlCommand command = new SqlCommand(StrCommand, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
        }

        public void CreateData(Person pers) {
            using (SqlConnection connection = new SqlConnection(stringConnection))
            {
                try
                {
                    connection.Open();
                    string StrCommand = String.Format("INSERT INTO People ([Age],[LastName],[FirstName],[Sex]) VALUES ({0},'{1}','{2}','{3}')", pers.Age,pers.LastName,pers.FirstName,pers.Sex);
                    SqlCommand command = new SqlCommand(StrCommand, connection);
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                   throw ex;

                }
            }
        }
    }
}
