using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Questions.Entities.Model
{
    public class AttachedImage
    {
        public Guid Id { get; set; }
        public int QuestionId {get;set;}
        public byte[] Image { get; set; }
    }
}
