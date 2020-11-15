using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Equinox.Questions.Entities.Model
{
    public class Explanation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }  
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime LastModified { get; set; }
        public Question Question { get; set; }
    }
}
