using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.SprintStates
{
    public interface ISprintState
    {
        void setName(Sprint sprint, string name);
        void setStartDate(Sprint sprint, DateTime startDate);
        void setEndDate(Sprint sprint, DateTime endDate);
    }
}
