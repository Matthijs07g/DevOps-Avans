using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.BacklogModels;

namespace Domain.Models.SprintModels
{
    public class Sprint
    {
        private Backlog _backlog;
        public Backlog Backlog 
        { 
            get => _backlog;
            set
            {
                if (!isSprintStarted())
                {
                    _backlog = value;
                }
            }
        }

        private string _name;
        public string Name 
        {
            get => _name;
            set
            {
                if(!isSprintStarted())
                {
                    _name = value;
                }
            }
        }

        private DateTime _startDate;
        public DateTime StartDate 
        {
            get => _startDate;
            set
            {
                if (!isSprintStarted())
                {
                    _startDate = value;
                }
            }
        }

        private DateTime _endDate;
        public DateTime EndDate 
        {
            get => _endDate;
            set
            {
                if (!isSprintStarted())
                {
                    _endDate = value;
                }
            }
        }
        
        public Sprint(string name, DateTime startDate, DateTime endDate)
        {
            _backlog = new Backlog();
            _name = name;
            _startDate = startDate;
            _endDate = endDate;
        }
        
        private bool isSprintStarted()
        {
            return DateTime.Compare(_startDate, DateTime.UtcNow) <= 0;
        }
    }
}
