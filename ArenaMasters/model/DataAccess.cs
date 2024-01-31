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
using System.Configuration;
using Org.BouncyCastle.Asn1.X509;

namespace ArenaMasters.model
{
    class DataAccess
    {
        MySqlConnection _conn;
        MySqlCommand _cmd;

        string _conectionString = "server= " + ConfigurationManager.AppSettings["server"] +";" +
                                  "user=" + ConfigurationManager.AppSettings["user"] + ";" +
                                  "database=" + ConfigurationManager.AppSettings["database"] + ";" +
                                  "port=" + ConfigurationManager.AppSettings["port"] + ";" +
                                  "password=" + ConfigurationManager.AppSettings["password"] + ";";




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
        public string PA_GetSkillData(int id_character, int placement)
        {
            //int resultado = -99;
            DataSet ds = new DataSet();
            bool _target = false;  
            bool _targetRange = false;  
            try
            {
                _cmd = new MySqlCommand(); 
                _cmd.Connection = _conn;    
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "getSkillInfoFromRooster";

                _cmd.Parameters.AddWithValue("_place", placement);
                _cmd.Parameters["_place"].Direction = ParameterDirection.Input;

                _cmd.Parameters.AddWithValue("_id_character", id_character);
                _cmd.Parameters["_id_character"].Direction = ParameterDirection.Input;

                _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

                _cmd.Parameters.Add(new MySqlParameter("_id_skill", MySqlDbType.Int32));
                _cmd.Parameters["_id_skill"].Direction = ParameterDirection.Output;

                _cmd.Parameters.Add(new MySqlParameter("_name", MySqlDbType.VarChar));
                _cmd.Parameters["_name"].Direction = ParameterDirection.Output;
                
                _cmd.Parameters.Add(new MySqlParameter("_description", MySqlDbType.VarChar));
                _cmd.Parameters["_description"].Direction = ParameterDirection.Output;

                _cmd.Parameters.Add(new MySqlParameter("_type", MySqlDbType.VarChar));
                _cmd.Parameters["_type"].Direction = ParameterDirection.Output;

                _cmd.Parameters.Add(new MySqlParameter("_tier", MySqlDbType.Int32));
                _cmd.Parameters["_tier"].Direction = ParameterDirection.Output;
                
                _cmd.Parameters.Add(new MySqlParameter("_target", MySqlDbType.VarChar));
                _cmd.Parameters["_target"].Direction = ParameterDirection.Output;
                
                _cmd.Parameters.Add(new MySqlParameter("_target_range", MySqlDbType.VarChar));
                _cmd.Parameters["_target_range"].Direction = ParameterDirection.Output;



                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["_target"].Value=="foes")
                {
                    _target=true;
                }
                if (_cmd.Parameters["_target_range"].Value=="multiple")
                {
                    _targetRange=true;
                }
                var resultJson = new
                {
                    IdSkill = _cmd.Parameters["_id_skill"].Value,
                    Name = _cmd.Parameters["_name"].Value,
                    Description = _cmd.Parameters["_description"].Value,
                    Type = _cmd.Parameters["_type"].Value,
                    Tier = _cmd.Parameters["_tier"].Value,
                    Target = _target,
                    TargetRange = _targetRange
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

        public int PA_RandomSkill(int id_character,int placement)
        {
            int resultado = -99;
            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "setRandomSkill";
                
                _cmd.Parameters.AddWithValue("_id_character", id_character);
                _cmd.Parameters["_id_character"].Direction = ParameterDirection.Input;

                _cmd.Parameters.AddWithValue("skillPlace", placement);
                _cmd.Parameters["skillPlace"].Direction = ParameterDirection.Input;

                _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

                _cmd.ExecuteNonQuery();

                resultado = (int)_cmd.Parameters["_res"].Value;

                return resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return resultado;
            }
            
        }
        public DataSet PA_GetAllGames(int id_user)
        {
            DataSet ds = new DataSet();
            int res = -99;
            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "getAllGames";

                _cmd.Parameters.AddWithValue("_id_user", id_user);
                _cmd.Parameters["_id_user"].Direction = ParameterDirection.Input;

                _cmd.Parameters.Add(new MySqlParameter("_res", MySqlDbType.Int32));
                _cmd.Parameters["_res"].Direction = ParameterDirection.Output;

                _cmd.ExecuteNonQuery();
                IDataAdapter adapter = new MySqlDataAdapter(_cmd);

                // construct DataSet to store result
                adapter.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ds;
            }

        }

        public int PA_deleteGame(int id_game) 
        {
            int resultado = -99;

            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "deleteGame";

                _cmd.Parameters.AddWithValue("_id_game", id_game);
                _cmd.Parameters["_id_game"].Direction = ParameterDirection.Input;

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

        public int PA_CountGames(int id_user)
        {
            int resultado = -99;
            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "countGames";

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

        public int PA_NewGame(int id_user)
        {
            int resultado = -99;
            try
            {
                _cmd = new MySqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = "newGame";

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

    }
}
