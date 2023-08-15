using System.Linq.Expressions;

namespace BugAndFix_Car_Insurance.API.Infra.Interface;

public interface IGenericRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}
