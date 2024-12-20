﻿namespace PF_Backend.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        T Add (T entity);
        void Update(T entity);
        void Delete(int id);
    }
}