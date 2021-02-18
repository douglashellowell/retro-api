using System;
using System.Collections.Generic;

namespace retro_api.Interfaces
{
    public interface IStudentsModel
    {
        public List<Student> SelectAllStudents();
        public List<Student> SelectStudentsByHouseId(int id);
    }
}
