using DesignPatterns.Context;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BankContext _bankContext;
        public GenericRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public List<T> GetAll() => _bankContext.Set<T>().ToList();
        public T GetById(int id) => _bankContext.Set<T>().Find(id);
        public void Add(T entity) => _bankContext.Set<T>().Add(entity);
        public void Update(T entity) => _bankContext.Set<T>().Update(entity);
        public void Delete(int id) { var v = GetById(id); _bankContext.Set<T>().Remove(v); }
    }
}
