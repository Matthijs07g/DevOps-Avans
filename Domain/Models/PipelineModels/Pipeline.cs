using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PipelineModels
{
    public class Pipeline
    {
        private List<IPipelineStep> _steps = new List<IPipelineStep>();

        public void AddStep(IPipelineStep step)
        {
            _steps.Add(step);
        }

        public void Execute(Sprint sprint)
        {
            foreach (var step in _steps)
            {
                try
                {
                    step.Execute(sprint);
                }
                catch (Exception ex)
                {
                    sprint._notificationService.NotifyScrumMaster("Pipeline failed at step: " + step.GetType().Name);
                    break;
                } 
                finally
                {
                    // check if succeeded and notify scrum master & product owner
                }
            }
        }
    }
}
