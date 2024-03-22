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
        private string _title;
        public string Title { get => _title; set => _title = value; }

        private Developer? _developer;
        public Developer? Developer { get => _developer; set => _developer = value; }

        private Sprint? _sprint;
        public Sprint? Sprint { get => _sprint; set => _sprint = value; }

        private List<BacklogItem>? _activities;
        public List<BacklogItem>? Activities { get => _activities; set => _activities = value; }

        private IBacklogState _currentState = new TodoState();
        public IBacklogState CurrentState { get => _currentState; set => setState(value); }

        public BacklogItem(string title)
        {
            _title = title;
        }

        public void AddActivity(BacklogItem activity)
        {
            if (_activities == null)
            {
                _activities = new List<BacklogItem>();
            }

            _activities.Add(activity);
        }

        private void setState(IBacklogState state)
        {
            if (_sprint == null) throw new InvalidOperationException("Backlog item is not in a sprint.");

            if (_currentState is ReadyForTestingState || _currentState is TestingState) {

                if (state is DoingState) throw new InvalidOperationException("Cannot change state from " + _currentState.GetType().Name + " to " + state.GetType().Name);
                if (state is TodoState)
                {
                    _sprint._notificationService.NotifyScrumMaster("[" + _title + "] status update: back to todo");
                }
            }

            if (state is ReadyForTestingState)
            {
                _sprint._notificationService.NotifyTesters("[" + _title + "] status update: ready for testing");
            }

            if (state is DoneState && !canBeDone()) throw new InvalidOperationException("Cannot change state to " + state.GetType().Name + ": not all activities are done");

            _currentState = state;
        }

        private bool canBeDone()
        {
            return _activities == null ? true : !_activities.Exists(activity => activity.CurrentState is not DoneState);
        }
    }
}
