using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;
using WebApiGuaxCore.Model.db;
using WebApiGuaxCore.Provider;

namespace MySqlProvider
{
    public class LoginProvider : ILoginProvider
    {
        public async Task CreateLogin(Login login)
        {
            try
            {
                using(MySqlConnection conn = new MySqlConnection(ConnectionMySql.ConnectioString))
                {
                    await conn.ExecuteScalarAsync(
                        @"INSERT INTO login (" +
                        "email," +
                        "senha) " +
                        "VALUES " +
                        "(@EMAIL, " +
                        "@PASSWORD);",
                        new
                        {
                            EMAIL = login.Email,
                            PASSWORD = login.Password
                        }
                     );
                }

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteLogin(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionMySql.ConnectioString))
                {
                    await conn.ExecuteScalarAsync(
                        @"DELETE FROM login where id=@ID;"
                        ,
                        new
                        {
                           ID = id
                        }
                     );
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<Login> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<bool>> SignIn(Login login)
        {
            try
            {
                
                using (MySqlConnection conn = new MySqlConnection(ConnectionMySql.ConnectioString))
                {
                 var result = await conn.QueryAsync<bool>(
                        @"SELECT * FROM login where email=@EMAIL AND senha=@PASSWORD",
                        new
                        {
                            EMAIL = login.Email,
                            PASSWORD = login.Password
                        }
                     );

                    return result;
                }
               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task UpdateLogin(Login login)
        {
            throw new NotImplementedException();
        }
    }
}
