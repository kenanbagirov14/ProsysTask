
namespace ExamPersistence.Configuration
{
    public class ClassRoomConfiguration : BaseEntityConfiguration<ClassRoom>
    {
        public override void Configure(EntityTypeBuilder<ClassRoom> builder)
        {
            base.Configure(builder);

            builder.ToTable("ClassRooms");
            builder.Property(p=>p.Number).HasColumnType("decimal(2,0)");
            builder.Property(p=>p.Name).HasMaxLength(20);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);

            builder.HasMany(p => p.Students).WithOne(w => w.ClassRoom).HasForeignKey(p=>p.ClassRoomId).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(p => p.Lessons).WithOne(w => w.ClassRoom).HasForeignKey(p=>p.ClassRoomId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
