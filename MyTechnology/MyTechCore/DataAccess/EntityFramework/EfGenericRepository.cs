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
    public class EfGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()

    {
        protected readonly DbContext context;
        public EfGenericRepository(DbContext dbContext)
        {
            context = dbContext;
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {

            return context.Set<TEntity>().SingleOrDefault(filter);

        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();

        }
        public void Create(TEntity entity)
        {
            //var addEntity = context.Entry(entity);
            //addEntity.State = EntityState.Added;

            context.Entry(entity).State = EntityState.Added;
            //context.SaveChanges();

        }
        public virtual void Update(TEntity entity)
        {

            //var updateEntity = context.Entry(entity);
            //updateEntity.State = EntityState.Modified;

            context.Entry(entity).State = EntityState.Modified;
           // context.SaveChanges();

        }
        public void Delete(TEntity entity)
        {

            //var deleteEntity = context.Entry(entity);
            //deleteEntity.State = EntityState.Deleted;

            context.Entry(entity).State = EntityState.Deleted;
           // context.SaveChanges();

        }
    }
}
