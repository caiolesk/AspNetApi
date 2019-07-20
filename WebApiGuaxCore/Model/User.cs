using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiGuaxCore.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Phone> Phone { get; set; }
        public Adress Adress { get; set; }
    }
}
