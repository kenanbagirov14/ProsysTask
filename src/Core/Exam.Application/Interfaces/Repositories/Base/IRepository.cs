

namespace Exam.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T,bool>> predicate);
        T GetById(int id);
        int Add(T createModel);
        int Update(T updateModel);
        int Delete(int id);
        int Delete(T entity);
    }
}
