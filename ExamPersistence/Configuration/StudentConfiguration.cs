
namespace ExamPersistence.Configuration
{
    public class StudentConfiguration : BaseEntityConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
            builder.ToTable("Students");
            builder.Property(p => p.Number).HasColumnType("decimal(5,0)");
            builder.Property(p => p.Name).HasMaxLength(30).IsUnicode(false);
            builder.Property(p => p.LastName).HasMaxLength(30).IsUnicode(false);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.HasOne(h => h.ClassRoom).WithMany(w => w.Students).HasForeignKey(f => f.ClassRoomId);
            builder.HasMany(h => h.Exams).WithOne(w => w.Student).HasForeignKey(f => f.StudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
