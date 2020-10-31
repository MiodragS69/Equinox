using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Questions.Entities.Model;

namespace Equinox.Questions.Services.CRUD.Answers
{
    public interface IAnswerRepository
    {
        void Add(Answer answer);
        void AddRange(Answer[] answers);
        void Delete(Answer answer);
        void Update(Answer answer);
        Answer Get(int id);
        ICollection<Answer> GetAll(int id);
        int Next();
    }
}
