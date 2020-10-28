using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Questions.Entities.Entity;
using Equinox.Questions.Entities.Enums;

namespace Equinox.Questions.Entities.Enitity
{
    public class Question
    {
        public Guid Id { get; set; }
        public int OrderNo { get; set; }
        public string Text { get; set; }
        public Scope QuestionScope { get; set; }
        public Grade QuestionGrade { get; set; }
        public bool MultiAnswer { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Explanation Explanation { get; set; }

    }
}
