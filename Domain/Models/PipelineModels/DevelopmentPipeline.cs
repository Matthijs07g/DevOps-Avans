using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.PipelineModels
{
    public class DevelopmentPipeline : Pipeline
    {
        public DevelopmentPipeline()
        {
            base.AddStep(new SourcesStep());
            base.AddStep(new PackageStep());
            base.AddStep(new BuildStep());
            base.AddStep(new TestStep());
            base.AddStep(new AnalyseStep());
            base.AddStep(new DeployStep());
            base.AddStep(new UtilityStep());
        }
    }
}
