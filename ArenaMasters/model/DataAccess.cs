using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArenaMasters.model
{
    class DataAccess
    {
        MySqlConnection _conn;
        MySqlCommand _cmd;

        string _conectionString = "server=localhost;" +
                                  "user=root;" +
                                  "database=arenamasters;" +
                                  "port=3306;" +
                                  "password=1234";




        //Constructor(es)
        public DataAccess()
        {
            try
            {
                _conn = new MySqlConnection(_conectionString);
                _cmd = new MySqlCommand();
                _conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); // .NET 5 +

            }
        }
        public int PA_Login(string usuario, string pass)
        {
            int resultado = -99;

            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "findUser";

                _cmd.Parameters.AddWithValue("_name", usuario);
                _cmd.Parameters["_name"].Direction = ParameterDirection.Input;

                string paswordHash = CreateMD5(pass).Substring(0, 20);

                _cmd.Parameters.AddWithValue("_pass", paswordHash);
                _cmd.Parameters["_pass"].Direction = ParameterDirection.Input;

                _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

                _cmd.ExecuteNonQuery();

                resultado = (int)_cmd.Parameters["_res"].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return resultado;
            }
            return resultado;

        }
        public int PA_Register(string usuario, string pass)
        {
            int resultado = -99;

            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "addUser";

                _cmd.Parameters.AddWithValue("_name", usuario);
                _cmd.Parameters["_name"].Direction = ParameterDirection.Input;

                string paswordHash = CreateMD5(pass).Substring(0, 20);

                _cmd.Parameters.AddWithValue("_pass", paswordHash);
                _cmd.Parameters["_pass"].Direction = ParameterDirection.Input;

                _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

                _cmd.ExecuteNonQuery();

                resultado = (int)_cmd.Parameters["_res"].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return resultado;
            }
            return resultado;

        }
    }
}
