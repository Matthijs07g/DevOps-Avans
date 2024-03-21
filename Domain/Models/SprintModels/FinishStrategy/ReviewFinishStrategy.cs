using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.FinishStrategy
{
    public class ReviewFinishStrategy : IFinishStrategy
    {
        public void Finish(Sprint sprint)
        {
            if (sprint.Conclusion == null) throw new InvalidOperationException("Sprint must have a conclusion to be finished");
        }
    }
}
