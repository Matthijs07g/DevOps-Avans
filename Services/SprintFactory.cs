using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class SprintFactory
    {
        public static Sprint CreateReleaseSprint(string name, DateTime startDate, DateTime endDate)
        {
            return new ReleaseSprint(name, startDate, endDate);
        }

        public static Sprint CreateReviewSprint(string name, DateTime startDate, DateTime endDate)
        {
            return new ReviewSprint(name, startDate, endDate);
        }
    }
}
