using Equinox.Questions.Entities.Model;

namespace Equinox.Questions.Services.CRUD.Explanations
{
    public interface IExplanationRepository
    {
        void Add(Explanation explanation);
        void AddRange(Explanation[] explanations);
        void Delete(Explanation explanation);
        void Update(Explanation explanation);
        void Get(int id);
        void GetAll();
        int Next();
    }
}
