using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;
using WebApiGuaxCore.Model.db;
using WebApiGuaxCore.Provider;
using System.Linq;

namespace MySqlProvider
{
    public class MySqlDatabase : IMySql
    {
        public async Task createAdressUser(User user, int id)
        {
            try
            {
                using(MySqlConnection conn = new MySqlConnection(ConnectionMySql.ConnectioString))
                {
                    await conn.ExecuteScalarAsync<Adress>
                        (@"INSERT INTO endereco (" +
                            "rua," +
                            "bairro," +
                            "id_usuario) " +
                            "VALUES" +
                            "(@rua," +
                            "@bairro," +
                            "@ID)",
                            new
                            {
                                RUA = user.Adress.Street,
                                BAIRRO = user.Adress.District,
                                ID = id
                            }
                        );
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Phone> createPhoneUser(Phone user)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionMySql.ConnectioString))
                {
                   var result = await conn.ExecuteScalarAsync<Phone>
                        (@"INSERT INTO telefone (" +
                            "ddd," +
                            "numero) " +
                            "VALUES" +
                            "(@DDD," +
                            "@NUMERO)",
                            new
                            {
                                DDD = user.Ddd,
                                NUMERO = user.Number                             
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

        public async Task<int> createUser(User user)
        {
            try
            {
                int result;
                using (MySqlConnection conn = new MySqlConnection(ConnectionMySql.ConnectioString))
                {
                    result = await conn.ExecuteScalarAsync<int>
                        (@"INSERT INTO usuario (" +
                            "nome," +
                            "email) " +
                            "VALUES" +
                            "(@NOME," +
                            "@EMAIL); " +
                            " SELECT * FROM usuario " +
                            " WHERE id = (SELECT LAST_INSERT_ID());"
                            ,
                            new
                            {
                                NOME = user.Name,
                                EMAIL = user.Email,
                                //DDD = user.Phone.Ddd,
                                //NUMERO = user.Phone.Number,
                                //RUA = user.Adress.Street,
                                //BAIRRO = user.Adress.District
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

        public async Task<IEnumerable<User>> getAll()
        {
            try
            {
                //var users = new IEnumerable<User>();
                using(MySqlConnection conn = new MySqlConnection(ConnectionMySql.ConnectioString))
                {
                    /*
                    string sql = @"SELECT u.nome AS Name, u.email AS Email, end.rua AS Street, end.bairro AS District, tel.ddd AS Ddd, tel.numero AS Number FROM usuario u INNER JOIN endereco end ON end.id_usuario = u.id;
                                   SELECT tel.ddd AS Ddd, tel.numero AS Number FROM usuario u INNER JOIN telefone tel ON tel.id_usuario = u.id;";

                    List<User> usersList = null;
                    User u = null;
                    List<Phone> phones = null;
                    using(var list = conn.QueryMultiple(sql))
                    {
                        usersList = list.Read<User>().ToList();
                        phones = list.Read<Phone>().ToList();
                        foreach(Phone p in phones)
                        {
                            usersList.
                        }
                        
                    }*/




                    //  List<User> u = null;
                    var lookup = new Dictionary<int, User>();
                    var users = (await conn.QueryAsync<User,Adress,Phone,User>(@"SELECT u.id AS Id,u.nome AS Name, u.email AS Email, end.rua AS Street, end.bairro AS District, tel.ddd AS Ddd, tel.numero AS Number FROM usuario u " +
                                "INNER JOIN endereco end ON end.id_usuario = u.id " +
                                "INNER JOIN telefone tel ON tel.id_usuario = u.id;",
                             (user, address, phone) => {
                                 //user.Adress = address;
                                 //user.Phone = new List<Phone>() { phone };
                                 //return user;

                                 User u;
                                 if (!lookup.TryGetValue(user.Id, out u))
                                     lookup.Add(user.Id, u = user);
                                 if (u.Phone == null)
                                     u.Phone = new List<Phone>();
                                 u.Phone.Add(phone); /* Add locations to course */

                                 u.Adress = address;
                                 return u;
                             },splitOn: "Street,Ddd"
                            ));

                    var result = lookup.Values;
                    return result;
                }

                
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
