using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Account
{
    public class Developer : AbstractUser
    {
        public Developer(string name)
        {
            _name = name;
        }
    }
}
