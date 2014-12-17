using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        List<T> FindAll();
        T Find(int id);
        void SaveChanges();
        int Count { get;}
    }
}
