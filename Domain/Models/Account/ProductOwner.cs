using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Account
{
    public class ProductOwner : AbstractUser
    {
        public ProductOwner(string name)
        {
            _name = name;
        }
    }
}
