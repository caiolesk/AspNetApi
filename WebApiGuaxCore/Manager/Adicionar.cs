using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;
using WebApiGuaxCore.Provider;

namespace WebApiGuaxCore.Manager
{
    public class Adicionar : IAdicionar
    {
        private readonly IMySql _mySql;
        public Adicionar(IMySql mySql)
        {
            this._mySql = mySql;
        }
        //public async Task createAdressUser(Adress adress)
        //{
        //    try
        //    {
        //        await _mySql.createAdressUser(adress);

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public async Task<Phone> createPhoneUser(Phone phone)
        {
            try
            {
                var result = await _mySql.createPhoneUser(phone);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task createUser(User user)
        {
            try
            {
                var id_user = await _mySql.createUser(user);
                if (user.Phone.Count != 0)
                {
                    foreach (var fone in user.Phone)
                    {
                        await _mySql.createPhoneUser(fone);
                    }
                }

                if (user.Adress != null)
                {
                    await _mySql.createAdressUser(user, id_user);
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
                var result = await _mySql.getAll();

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
