﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Account;
using Domain.Models.BacklogModels;
using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.ForumModels;
using Domain.Models.Notification;
using Domain.Models.SprintModels.FinishStrategy;
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
        public List<BacklogItem> Backlog { get => _backlog; set => _backlog = value; }

        private List<AbstractUser> _team;
        public List<AbstractUser> Team { get => _team; set => _team = value; }

        private List<ForumThread> _forum = new List<ForumThread>();
        public List<ForumThread> Forum { get => _forum; set => _forum = value; }

        private string? _conclusion;
        public string? Conclusion { get => _conclusion; set => _conclusion = value; }

        internal INotificationService _notificationService;

        protected ISprintState _currentState;
        protected IFinishStrategy _finishStrategy;

        public Sprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService)
        {
            _backlog = new List<BacklogItem>();
            _name = name;
            _startDate = startDate;
            _endDate = endDate;
            _team = new List<AbstractUser>();
            _currentState = new NotStartedState();
            _notificationService = notificationService;
        }

        public void Start()
        {
            _currentState = new InProgressState();
        }

        public void Finish() {
            _currentState = new FinishedState();
            _finishStrategy.Finish(this);
        }

        public void AddBacklogItem(BacklogItem value)
        {
            _currentState.addBacklogItem(this, value);
        }

        public void AddTeamUser(AbstractUser user)
        {
            if (_team.Contains(user))
            {
                throw new InvalidOperationException("User already in team");
            }

            _team.Add(user);
            _notificationService.Attach(user);
        }

        public ForumThread? StartForumThread(BacklogItem backlogItem, ForumPost startPost)
        {
            if (backlogItem.CurrentState is DoneState) return null;
            
            var forumThread = new ForumThread(backlogItem, _notificationService, startPost);
            _forum.Add(forumThread);

            return forumThread;
        }
    }
}
