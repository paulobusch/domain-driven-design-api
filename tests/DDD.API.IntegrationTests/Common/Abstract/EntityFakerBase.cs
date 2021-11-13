using DDD.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using Bogus;

namespace DDD.API.IntegrationTests.Common.Abstract
{
    public class EntityFakerBase<TEntity> : Faker<TEntity> where TEntity : class
    {
        private readonly DDDContext _context;

        public EntityFakerBase(DDDContext context)
        {
            _context = context;

            CustomInstantiator(f => Activator.CreateInstance(typeof(TEntity), nonPublic: true) as TEntity);
        }

        public TEntity Save()
        {
            var entity = Generate();

            _context.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }
    }
}