using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;

namespace WebApiGuaxCore.Provider
{
    public interface IMySql
    {
        Task<int> createUser(User user);
        Task createAdressUser(User user, int id);
        Task<Phone> createPhoneUser(Phone user);
        Task<IEnumerable<User>> getAll();
    }
}
