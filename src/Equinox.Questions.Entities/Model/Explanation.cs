﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Questions.Entities.Model
{
    public class Explanation
    {
        public Guid Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime LastModified { get; set; }
    }
}