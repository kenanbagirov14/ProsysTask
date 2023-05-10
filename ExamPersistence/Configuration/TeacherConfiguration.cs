

namespace ExamPersistence.Configuration
{
    public class TeacherConfiguration :BaseEntityConfiguration<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            builder.ToTable("Teachers");
            builder.Property(p => p.FirstName).HasMaxLength(20).IsUnicode(false);
            builder.Property(p => p.LastName).HasMaxLength(20).IsUnicode(false);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.HasOne(p => p.Lesson).WithOne(w => w.Teacher);
        }
    }
}
