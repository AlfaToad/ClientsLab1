using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Client(string name, string email, string phone, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
