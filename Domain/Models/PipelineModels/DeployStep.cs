using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PipelineModels
{
    public class DeployStep : IPipelineStep
    {
        public void Execute(Sprint sprint)
        {
            Console.WriteLine("Deploy step executed");
        }
    }
}
