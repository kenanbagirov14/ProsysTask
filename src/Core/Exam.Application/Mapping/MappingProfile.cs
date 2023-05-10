using AutoMapper;

namespace Exam.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student,StudentAddDTO>().ReverseMap();
            CreateMap<Student,StudentIndexDTO>().ReverseMap();

            CreateMap<Lesson, LessonAddDTO>().ReverseMap();
            CreateMap<Lesson, LessonIndexDTO>().ReverseMap();

            CreateMap<Domain.Entities.Exam, ExamAddDTO>().ReverseMap();
            CreateMap<Domain.Entities.Exam, ExamIndexDTO>().ReverseMap();

            CreateMap<Teacher, TeacherAddDTO>().ReverseMap();
            CreateMap<Teacher, TeacherIndexDTO>().ReverseMap();

            CreateMap<ClassRoom, ClassRoomAddDTO>().ReverseMap();
            CreateMap<ClassRoom, ClassRoomIndexDTO>().ReverseMap();
        }
    }
}
