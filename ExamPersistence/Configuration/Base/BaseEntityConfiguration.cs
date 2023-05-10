using Exam.Domain.Entities;

namespace ExamPersistence.Configuration
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).ValueGeneratedOnAdd();
            builder.Property(h => h.CreatedDate).ValueGeneratedOnAdd();
            builder.Property(h => h.CreatedDate).ValueGeneratedOnUpdate();

        }
    }
}
