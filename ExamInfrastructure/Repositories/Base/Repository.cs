using Exam.Application.Interfaces.Repositories;
using Exam.Domain.Entities;
using ExamPersistence.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _examDBContext;
        protected DbSet<TEntity> entity => _examDBContext.Set<TEntity>();

        public Repository(DbContext examDBContext)
        {
            _examDBContext = examDBContext ?? throw new ArgumentNullException(nameof(examDBContext));
        }
        public virtual int Add(TEntity createModel)
        {
            this.entity.Add(createModel);
            return _examDBContext.SaveChanges();
        }


        public int Delete(TEntity deleteModel)
        {
            if (_examDBContext.Entry(deleteModel).State == EntityState.Detached)
            {
                this.entity.Attach(deleteModel);
            }
            else
            {
                this.entity.Remove(deleteModel);
            }
            return _examDBContext.SaveChanges();
        }

        public virtual int Delete(int id)
        {
            var findEntity = this.entity.Find(id);
            return Delete(findEntity);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this.entity;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.entity.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            var entity = this.entity.Find(id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }

        public int Update(TEntity updateModel)
        {
            this.entity.Attach(updateModel);
            _examDBContext.Entry(entity).State = EntityState.Modified;
            return _examDBContext.SaveChanges();
        }
    }
}
