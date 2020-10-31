using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Questions.Entities.Model;

namespace Equinox.Questions.Services.CRUD.Questions
{
    public interface IQuestionRepository
    {
        void Add(Question question);
        void AddRange(Question[] questions);
        void Delete(Question question);
        void Update(Question question);
        Question Get(int id);
        ICollection<Question> GetAll();
        int Next();

    }
}
