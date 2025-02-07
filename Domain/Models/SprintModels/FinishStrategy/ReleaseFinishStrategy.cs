﻿using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.PipelineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.FinishStrategy
{
    public class ReleaseFinishStrategy : IFinishStrategy
    {
        private readonly Pipeline _pipeline = new DevelopmentPipeline();

        public void Finish(Sprint sprint)
        {
            if (!areResultsGoodEnough(sprint))
            {
                var failMsg = "[" + sprint.Name + "] release failed: results are not good enough";
                sprint._notificationService.NotifyScrumMaster(failMsg);
                sprint._notificationService.NotifyProductOwner(failMsg);
                return;
            }

            _pipeline.Execute(sprint);
        }

        private bool areResultsGoodEnough(Sprint sprint)
        {
            return !sprint.Backlog.Exists(bItem => bItem.CurrentState is not DoneState);
        }
    }
}
