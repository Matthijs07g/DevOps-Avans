using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Account;
using Domain.Models.BacklogModels;
using Domain.Models.SprintModels.SprintStates;

namespace Domain.Models.SprintModels
{
    public abstract class Sprint
    {
        internal string _name;
        public string Name { get => _name; set => _currentState.setName(this, value); }

        internal DateTime _startDate;
        public DateTime StartDate { get => _startDate; set => _currentState.setStartDate(this, value); }

        internal DateTime _endDate;
        public DateTime EndDate { get => _endDate; set => _currentState.setEndDate(this, value); }

        internal List<BacklogItem> _backlog;
        public List<BacklogItem> Backlog { get => _backlog; set => _currentState.addBacklogItem(this, value); }

        private List<AbstractUser> _team;
        public List<AbstractUser> Team { get => _team; set => _team = value; }

        private ISprintState _currentState;

        public Sprint(string name, DateTime startDate, DateTime endDate)
        {
            _backlog = new List<BacklogItem>();
            _name = name;
            _startDate = startDate;
            _endDate = endDate;
            _team = new List<AbstractUser>();
            _currentState = new NotStartedState();
        }

        public void Start()
        {
            _currentState = new InProgressState();
        }

        public void Finish()
        {
            _currentState = new FinishedState();
        }
    }
}
