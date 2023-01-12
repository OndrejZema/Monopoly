using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Repository.Repositories
{
    public interface IRepository<T>
    {
        public T Get(int id);
        //public List<T> GetAll();
        public List<T> GetAll(int page, int perPage);
        public T Create(T entity);
        public T Update(T entity);
        public void Delete(int id);
    }
}
