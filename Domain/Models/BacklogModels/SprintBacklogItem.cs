using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BacklogModels
{
    public class SprintBacklogItem : BacklogItem
    {
        public Developer? AssignedDeveloper { get; set; }
    }
}
