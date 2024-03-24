using Domain.Models.Account;
using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.ForumModels;
using Domain.Models.SprintModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BacklogModels
{
    public class BacklogItem
    {
        public string Title { get; set; }

        public Developer? Developer { get; set; }

        public Sprint? Sprint { get; set; }

        public List<BacklogItem>? Activities { get; set; }

        private IBacklogState _currentState = new TodoState();
        public IBacklogState CurrentState { get => _currentState; set => setState(value); }

        public BacklogItem(string title)
        {
            Title = title;
        }

        public void AddActivity(BacklogItem activity)
        {
            if (Activities == null)
            {
                Activities = new List<BacklogItem>();
            }

            Activities.Add(activity);
        }

        private void setState(IBacklogState state)
        {
            if (Sprint == null) throw new InvalidOperationException("Backlog item is not in a sprint.");

            if (_currentState is ReadyForTestingState || _currentState is TestingState) {

                if (state is DoingState) throw new InvalidOperationException("Cannot change state from " + _currentState.GetType().Name + " to " + state.GetType().Name);
                if (state is TodoState)
                {
                    Sprint._notificationService.NotifyScrumMaster("[" + Title + "] status update: back to todo");
                }
            }

            if (state is ReadyForTestingState)
            {
                Sprint._notificationService.NotifyTesters("[" + Title + "] status update: ready for testing");
            }

            if (state is DoneState && !canBeDone()) throw new InvalidOperationException("Cannot change state to " + state.GetType().Name + ": not all activities are done");

            _currentState = state;
        }

        private bool canBeDone()
        {
            return Activities == null || !Activities.Exists(activity => activity.CurrentState is not DoneState);
        }
    }
}
