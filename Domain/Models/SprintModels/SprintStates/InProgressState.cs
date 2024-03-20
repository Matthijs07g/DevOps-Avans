using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.SprintStates
{
    public class InProgressState : ISprintState
    {
        public void setName(Sprint sprint, string name)
        {
            throw new InvalidOperationException("Cannot change name of sprint in progress");
        }

        public void setStartDate(Sprint sprint, DateTime startDate)
        {
            throw new InvalidOperationException("Cannot change start date of sprint in progress");
        }

        public void setEndDate(Sprint sprint, DateTime endDate)
        {
            throw new InvalidOperationException("Cannot change end date of sprint in progress");
        }
    }
}
