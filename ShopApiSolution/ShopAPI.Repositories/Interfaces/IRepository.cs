using ShopAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(string id);

        Task<IList<T>> GetAllAsync();

        Task<T> GetById(string id);
    }
}
