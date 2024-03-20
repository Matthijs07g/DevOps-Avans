using Domain.Models.Account;
using Domain.Models.BacklogModels.BacklogStates;
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

        private List<BacklogItem>? _activities;
        public List<BacklogItem>? Activities { get => _activities; set => _activities = value; }

        private IBacklogState _currentState = new TodoState();
        public IBacklogState CurrentState { get => _currentState; set => setState(value); }

        public BacklogItem(string title)
        {
            _title = title;
        }

        private void setState(IBacklogState state)
        {
            if (_currentState is ReadyForTestingState || _currentState is TestingState) {

                if (state is DoingState) throw new InvalidOperationException("Cannot change state from " + _currentState.GetType().Name + " to " + state.GetType().Name);
                if (state is TodoState)
                {
                    // notify scrum master so he can ask the developer why he put an unfinished task at ready for testing
                }
            }

            if (state is DoneState && !canBeDone()) return;
            
            _currentState = state;
        }

        private bool canBeDone()
        {
            return _activities == null ? true : _activities.Exists(activity => activity.CurrentState is not DoneState);
        }
    }
}
