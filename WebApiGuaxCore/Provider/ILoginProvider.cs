using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;

namespace WebApiGuaxCore.Provider
{
    public interface ILoginProvider
    {
        Task CreateLogin(Login login);
        Task UpdateLogin(Login login);
        Task DeleteLogin(int id);
        Task<Login> GetById(int id);
        Task<IEnumerable<bool>> SignIn(Login login);
    }
}
