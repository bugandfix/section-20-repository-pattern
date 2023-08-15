using BugAndFix_Car_Insurance.API.Infra.Interface;
using BugAndFix_Car_Insurance.API.Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BugAndFix_Car_Insurance.API.Infra.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository()
        {
            
        }
        public void Add(T entity)
        {
            
        }
        public void Update(T entity)
        {
            
        }
        
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> result=new List<T>();
            return result;
        }
        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> result = new List<T>();
            return result;
        }
        public T GetById(int id)
        {
            return null;
        }
        public void Remove(T entity)
        {
        }
        
    }
}
