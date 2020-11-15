using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Questions.Entities.Model
{ 
    public class Answer
    {
        public int Id { get; set; }
        public int OrderNo {get;set;}
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
    }
}
