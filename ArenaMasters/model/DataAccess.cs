using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.Json.Nodes;
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
                                  "port=3309;" +
                                  "password=joyfe";




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

        public int PA_FindUser(string name, string psw)
        {
            int resultado = -96;
            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "findUser";

                _cmd.Parameters.AddWithValue("_name", name);
                _cmd.Parameters["_name"].Direction = ParameterDirection.Input;

                _cmd.Parameters.AddWithValue("_pass", psw);
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


        public int PA_ContinueGame(int id_user)
        {
            int resultado = -96;
            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "continueGame";

                _cmd.Parameters.AddWithValue("_id_user", id_user);
                _cmd.Parameters["_id_user"].Direction = ParameterDirection.Input;

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

        public string PA_GetGameData(int id_game)
        {
            //int resultado = -99;
            DataSet ds = new DataSet();
            try
            {
                _cmd = new MySqlCommand(); 
                _cmd.Connection = _conn;    
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "getGameData";

                _cmd.Parameters.AddWithValue("_id_game", id_game);
                _cmd.Parameters["_id_game"].Direction = ParameterDirection.Input;

                _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

                _cmd.Parameters.Add(new MySqlParameter("_money", MySqlDbType.Int32));
                _cmd.Parameters["_money"].Direction = ParameterDirection.Output;

                _cmd.Parameters.Add(new MySqlParameter("_round", MySqlDbType.Int32));
                _cmd.Parameters["_round"].Direction = ParameterDirection.Output;
                
                _cmd.Parameters.Add(new MySqlParameter("_refresh", MySqlDbType.Int32));
                _cmd.Parameters["_refresh"].Direction = ParameterDirection.Output;

                _cmd.ExecuteNonQuery();

                var resultJson = new
                {
                    Res = _cmd.Parameters["_res"].Value,
                    Money = _cmd.Parameters["_money"].Value,
                    Round = _cmd.Parameters["_round"].Value,
                    Refresh = _cmd.Parameters["_refresh"].Value
                };
                string jsonResult = JsonConvert.SerializeObject(resultJson);

                return jsonResult;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ex.Message;
            }
        }
    }
}
