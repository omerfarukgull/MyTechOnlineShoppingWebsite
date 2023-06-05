using Microsoft.EntityFrameworkCore;
using MyTechData.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyTechData.Concrete.Ef
{
    public class EfGenericRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity: class,new()
        where TContext : DbContext,new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
           using(var context = new TContext())
            { 
            return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            { 
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Create(TEntity entity)
        {
            using (var context = new TContext())
            { 
            //var addEntity = context.Entry(entity);
            //addEntity.State = EntityState.Added;

            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }
    }
        public virtual void Update(TEntity entity)
        {
            using (var context = new TContext())
            { 
            //var updateEntity = context.Entry(entity);
            //updateEntity.State = EntityState.Modified;

            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            { 
            //var deleteEntity = context.Entry(entity);
            //deleteEntity.State = EntityState.Deleted;

            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            }
        }
    }
}
