using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Equinox.Questions.Entities.Model;

namespace Equinox.Questions.Services.CRUD.Questions
{
    public interface IQuestionRepository
    {
        void Add(Question question);
        Task AddAsync(Question quiestion);
        void AddRange(Question[] questions);
        void Delete(Question question);
        Task DeleteAsync(int orderNo);
        void Update(Question question);
        Question Get(int id);
        ICollection<Question> GetAll();
        int Next();

    }
}
