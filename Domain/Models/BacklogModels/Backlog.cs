using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BacklogModels
{
    public class Backlog
    {
        public List<BacklogItem> Items { get; set; } = new List<BacklogItem>();
    }
}
