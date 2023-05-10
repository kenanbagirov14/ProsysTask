using Exam.Domain.Entities;
using Exam.Domain.Interfaces;
using ExamPersistence.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamPersistence.DBContext
{
    public class ExamDBContext : DbContext
    {
        public ExamDBContext(DbContextOptions<ExamDBContext> options) : base(options)
        {

        }

        //public ExamDBContext(DbContextOptions options) : base(options)
        //{

        //}

        //public ExamDBContext()
        //{
        //}

        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Exam.Domain.Entities.Exam> Exams { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(typeof(ISoftDelete)))
                {
                    item.AddSoftDeleteQueryFilter();
                }
            }


            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    if (!builder.IsConfigured)
        //    {
        //        string conectionStr = "Data Source=DESKTOP-1CSU1HJ\\SQLEXPRESS;Database=Exam;Trusted_Connection=True;";
        //        builder.UseSqlServer(conectionStr, opt =>
        //        {
        //            opt.EnableRetryOnFailure();
        //        });
        //    }
        //}


        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }


        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        public void OnBeforeSave()
        {
            var entities = ChangeTracker.Entries<IEntity>();
            var deletedEntities = ChangeTracker.Entries<ISoftDelete>();

            StatedByAddedAndModifie(entities);
            StatedByDeleted(deletedEntities);

        }

        public void StatedByAddedAndModifie(IEnumerable<EntityEntry<IEntity>> entries)
        {
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.Version = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now;
                        entry.Entity.Version += 1;
                        break;
                }

            }
        }

        public void StatedByDeleted(IEnumerable<EntityEntry<ISoftDelete>> entries)
        {
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    if (!entry.Entity.IsDeleted)
                    {
                        entry.Entity.IsDeleted = true;
                        entry.State = EntityState.Modified;
                    }
                }
            }
        }
    }
}
