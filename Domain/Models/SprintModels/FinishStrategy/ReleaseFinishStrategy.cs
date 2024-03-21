using Domain.Models.BacklogModels.BacklogStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.FinishStrategy
{
    public class ReleaseFinishStrategy : IFinishStrategy
    {
        public void Finish(Sprint sprint)
        {
            // zet release in gang als resultaten goed genoeg zijn
            if (!areResultsGoodEnough(sprint))
            {
                var failMsg = "[" + sprint.Name + "] release failed: results are not good enough";
                sprint._notificationService.NotifyScrumMaster(failMsg);
                sprint._notificationService.NotifyProductOwner(failMsg);
                return;
            }
        }

        private bool areResultsGoodEnough(Sprint sprint)
        {
            return !sprint.Backlog.Exists(bItem => bItem.CurrentState is not DoneState);
        }
    }
}
