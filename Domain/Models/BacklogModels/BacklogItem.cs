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

        private IBacklogState _currentState = new TodoState();

        public BacklogItem(string title)
        {
            _title = title;
        }

        public void SetState(IBacklogState state)
        {
            if (_currentState is ReadyForTestingState || _currentState is TestingState) {

                if (state is DoingState) throw new InvalidOperationException("Cannot change state from " + _currentState.GetType().Name + " to " + state.GetType().Name);
                if (state is TodoState)
                {
                    // notify scrum master so he can ask the developer why he put an unfinished task at ready for testing
                }
            }
            
            _currentState = state;
        }
    }
}
