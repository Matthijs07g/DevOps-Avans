using Domain.Models.Account;
using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project
    {
        private ProductOwner _productOwner;
        public ProductOwner ProductOwner { get => _productOwner; set => _productOwner = value; }

        private Sprint _sprint;
        public Sprint Sprint { get => _sprint; set => _sprint = value; }

        public Project(ProductOwner productOwner, Sprint sprint)
        {
            _productOwner = productOwner;
            _sprint = sprint;
        }
    }
}
