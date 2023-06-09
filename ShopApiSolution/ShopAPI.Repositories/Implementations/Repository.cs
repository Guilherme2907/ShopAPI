﻿using Microsoft.EntityFrameworkCore;
using ShopAPI.Models.Entities;
using ShopAPI.Repositories.Contexts;
using ShopAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetById(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityToBeUpdated = await _dbSet.FindAsync(entity.Id);

            if (entityToBeUpdated is null)
            {
                return null;
            }

            _context.Entry(entityToBeUpdated).CurrentValues.SetValues(entity);

            return entity;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity is null)
            {
                return false;
            }

            _dbSet.Remove(entity);

            return true;
        }
    }
}
