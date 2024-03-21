using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PipelineModels
{
    public class BuildStep : IPipelineStep
    {
        public void Execute(Sprint sprint)
        {
            if (sprint.Name == "PipelineShouldFail")
            {
                throw new NotImplementedException();
            }
            Console.WriteLine("Build step executed");
        }
    }
}
