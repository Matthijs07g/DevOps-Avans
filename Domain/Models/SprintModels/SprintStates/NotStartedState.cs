using Domain.Models.BacklogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.SprintStates
{
    public class NotStartedState : ISprintState
    {
        public void setName(Sprint sprint, string name)
        {
            sprint._name = name;
        }
        
        public void setStartDate(Sprint sprint, DateTime startDate)
        {
            sprint._startDate = startDate;
        }

        public void setEndDate(Sprint sprint, DateTime endDate)
        {
            sprint._endDate = endDate;
        }

        public void addBacklogItem(Sprint sprint, BacklogItem value)
        {
            sprint._backlog.Add(value);
        }
    }
}
