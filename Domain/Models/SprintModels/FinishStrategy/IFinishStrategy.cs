using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.SprintModels.FinishStrategy
{
    public interface IFinishStrategy
    {
        void Finish(Sprint sprint);
    }
}
