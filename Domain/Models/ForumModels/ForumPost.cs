﻿using Domain.Models.Account;
using Domain.Models.BacklogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ForumModels
{
    public class ForumPost
    {
        private AbstractUser _poster;
        public AbstractUser Poster { get => _poster; }

        private string _title;
        public string Title { get => _title; }

        private string _content;
        public string Content { get => _content; }

        public ForumPost(AbstractUser poster, string title, string content)
        {
            _poster = poster;
            _title = title;
            _content = content;
        }
    }
}