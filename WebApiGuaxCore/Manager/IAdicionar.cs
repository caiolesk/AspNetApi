using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;

namespace WebApiGuaxCore.Manager
{
    public interface IAdicionar
    {
        Task createUser(User user);
        //Task createAdressUser(Adress adress);
        Task<Phone> createPhoneUser(Phone phone);
        Task<IEnumerable<User>> getAll();
    }
}
