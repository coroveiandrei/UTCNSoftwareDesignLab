using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository
    {
        List<T> GetAll<T>() where T : class;
        void Add<T>(T entity) where T:class;
        void SaveChanges();
    }
}
