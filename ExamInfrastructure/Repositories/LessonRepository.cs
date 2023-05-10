using Exam.Application.Interfaces.Repositories.Base;
using Exam.Domain.Entities;
using ExamPersistence.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Repositories
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(ExamDBContext examDBContext) : base(examDBContext)
        {
        }
    }
}
