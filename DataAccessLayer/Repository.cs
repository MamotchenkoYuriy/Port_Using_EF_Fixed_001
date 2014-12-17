using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        } 
        public void Add(T entity)
        {
            if (entity.GetType() != typeof(T)) { return; }
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch(Exception err) { }
        }

        public void Remove(T entity)
        {
            if(entity.GetType() != typeof(T)) { return;}
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception err)
            {
                // ignored
            }
        }

        public void Remove(int id)
        {
            try
            {
                var removeEntity = _context.Set<T>().FirstOrDefault(m => m.Id == id);
                if(removeEntity== null) { return;}
                _context.Set<T>().Remove(removeEntity);
                _context.SaveChanges();
            }
            catch (Exception err) { }
        }

        public List<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Find(int id)
        {
            return _context.Set<T>().FirstOrDefault(m => m.Id == id);
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception){/*throw;*/}
        }

        public int Count => _context.Set<T>().Count();
    }
}
