﻿using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Dtos;
using StoreOfBuild.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreOfBuild.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public T GetById(int id)
        {
            var entity = _context.Set<T>().SingleOrDefault(x => x.Id == id);

            if (entity == null)
                throw new NullReferenceException();
            else
                return entity;
        }

        public void Save(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChangesAsync();
        }
    }
}