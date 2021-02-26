using System;
using System.Collections.Generic;
using retro_api.Models;

namespace retro_api.Interfaces
{
    public interface IStudentsModel
    {
        public List<Student> SelectAllStudents();
        public List<Student> SelectStudentsByHouseId(int id);

        public Student InsertStudent(int houseId, StudentRequest newStudent);
    }
}
