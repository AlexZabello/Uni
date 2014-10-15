using DataLayer.Core;
using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public abstract class Repository<T> : AppContainer, IRepository<T> where T : IItem
    {
        public Repository(App app)
        {
            App = app;
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T Get(int id);

        public abstract bool Insert(T item);

        public abstract bool Update(T item);

        public abstract bool Delete(int id);
        
    }
}
