using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Questions.Entities.Model
{
    public class AttachedImage
    {
        public int Id { get; set; }  
        public int QuestionId { get; set; }
        public byte[] Image { get; set; }
        public Question Question { get; set; }
    }
}
