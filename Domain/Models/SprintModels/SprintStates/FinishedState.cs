using Domain.Models.BacklogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.SprintStates
{
    public class FinishedState : ISprintState
    {
        public void setName(Sprint sprint, string name)
        {
            throw new InvalidOperationException("Cannot change name of sprint that is finished");
        }

        public void setStartDate(Sprint sprint, DateTime startDate)
        {
            throw new InvalidOperationException("Cannot change start date of sprint that is finished");
        }

        public void setEndDate(Sprint sprint, DateTime endDate)
        {
            throw new InvalidOperationException("Cannot change end date of sprint that is finished");
        }

        public void addBacklogItem(Sprint sprint, BacklogItem value)
        {
            throw new InvalidOperationException("Cannot add backlog item to sprint in progress");
        }
    }
}
