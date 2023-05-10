using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Interfaces.Services
{
    public interface IClassRoomService
    {
        public ICollection<ClassRoomIndexDTO> GetAll(); 
        public ClassRoomAddDTO GetById(int id);
        public int Add(ClassRoomAddDTO addDTO);
        public int Update(ClassRoomAddDTO addDTO);
        public int Delete(int id);
    }
}
