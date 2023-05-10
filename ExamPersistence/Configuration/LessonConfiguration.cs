

namespace ExamPersistence.Configuration
{
    public class LessonConfiguration : BaseEntityConfiguration<Lesson>
    {
        public override void Configure(EntityTypeBuilder<Lesson> builder)
        {
            base.Configure(builder);
            builder.ToTable("Lessons");
            builder.Property(p=>p.Code).HasMaxLength(3).IsFixedLength().IsUnicode(false);
            builder.Property(p=>p.Name).HasMaxLength(30).IsUnicode(false);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.HasOne(p => p.ClassRoom).WithMany(p => p.Lessons).HasForeignKey(f => f.ClassRoomId);
            builder.HasOne(p => p.Teacher).WithOne(w=>w.Lesson);
        }
    }
}
