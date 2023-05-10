using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamInfrastructure.Repositories
{
    public class ExamRepository : Repository<Exam.Domain.Entities.Exam>, IExamRepository
    {
        public ExamRepository(ExamDBContext examDBContext) : base(examDBContext)
        {
        }
    }
}
