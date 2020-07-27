using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couponel.Entities;

namespace Couponel.Persistence.Repository
{
    public interface IRepository<T>
            where T : Entity
    {
        Task<T> GetById(Guid id);

        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChanges();

        Task<IList<T>> GetAll();
    }
}
