using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;
using WebApiGuaxCore.Provider;

namespace WebApiGuaxCore.Manager
{
    public class LoginManager : ILoginManager
    {

        private readonly ILoginProvider _loginProvider;

        public LoginManager(ILoginProvider loginProvider)
        {
            this._loginProvider = loginProvider;
        }
        public async Task CreateLogin(Login login)
        {
            try
            {

                await _loginProvider.CreateLogin(login);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteLogin(int id)
        {
            try
            {

                await _loginProvider.DeleteLogin(id);

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
                var result = await _loginProvider.SignIn(login);

                return result;
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
