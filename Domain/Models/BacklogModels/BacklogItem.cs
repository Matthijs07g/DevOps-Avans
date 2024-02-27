using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BacklogModels
{
    public abstract class BacklogItem
    {   
        public Boolean IsDone { get; }
        public List<BacklogActivity> Activities = new List<BacklogActivity>();
    }
}
