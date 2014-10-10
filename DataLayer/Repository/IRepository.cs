using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IRepository<T> where T : IItem
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        bool Insert(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}
