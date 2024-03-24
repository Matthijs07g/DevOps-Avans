using Domain.Models.BacklogModels;
using Domain.Models.BacklogModels.BacklogStates;
using Domain.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ForumModels
{
    public class ForumThread
    {
        private readonly string _title;
        public string Title { get => _title; }

        private readonly List<ForumPost> _posts = new List<ForumPost>();
        public List<ForumPost> Posts { get => _posts; }

        private readonly BacklogItem _backlogItem;
        private readonly INotificationService _notificationService;
        
        public ForumThread(BacklogItem backlogItem, INotificationService notificationService, ForumPost startPost)
        {
            _title = startPost.Title;
            _backlogItem = backlogItem;
            _notificationService = notificationService;
            _posts.Add(startPost);
        }

        public void AddPost(ForumPost post)
        {
            if (_backlogItem.CurrentState is DoneState) return;

            _posts.Add(post);
            _notificationService.Notify("New post in thread: " + Title);
        }

        public void RemovePost(ForumPost post)
        {
            _posts.Remove(post);
        }
    }
}
