using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PipelineModels
{
    public class TestStep : IPipelineStep
    {
        public void Execute(Sprint sprint)
        {
            Console.WriteLine("Test step executed");
        }
    }
}
