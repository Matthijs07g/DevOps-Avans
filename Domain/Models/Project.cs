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
        public ProductOwner ProductOwner { get; set;}

        private readonly List<Sprint> _sprints = new List<Sprint>();
        public List<Sprint> Sprints { get => _sprints; }

        public Project(ProductOwner productOwner)
        {
            ProductOwner = productOwner;
        }
    }
}
