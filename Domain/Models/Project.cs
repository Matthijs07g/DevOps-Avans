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

        private List<Sprint> _sprints = new List<Sprint>();
        public List<Sprint> Sprints { get => _sprints; }

        public Project(ProductOwner productOwner)
        {
            _productOwner = productOwner;
        }
    }
}
