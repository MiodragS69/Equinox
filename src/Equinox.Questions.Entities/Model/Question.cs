using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Questions.Entities.Model;
using Equinox.Questions.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equinox.Questions.Entities.Model
{ 
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }        
        public string Text { get; set; }
        public Scope QuestionScope { get; set; }
        public Grade QuestionGrade { get; set; }
        public bool MultiAnswer { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Explanation Explanation { get; set; }
        public AttachedImage AttachedImage { get; set; }

    }
}
