

namespace ExamPersistence.Configuration
{
    partial class ExamConfiguration : BaseEntityConfiguration<Exam.Domain.Entities.Exam>
    {
        public override void Configure(EntityTypeBuilder<Exam.Domain.Entities.Exam> builder)
        {
            base.Configure(builder);
            builder.ToTable("Exams");
            builder.Property(p=>p.ResultGrade).HasColumnType("decimal(1,0)");
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.HasOne(p => p.Lesson).WithMany(p=>p.Exams).HasForeignKey(p=>p.LessonId);
            builder.HasOne(p => p.Student).WithMany(p=>p.Exams).HasForeignKey(p=>p.StudentId);
           
        }
    }
}
