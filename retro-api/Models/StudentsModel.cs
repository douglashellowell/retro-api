using System;
using System.Collections.Generic;
using System.Linq;
using retro_api.Interfaces;

namespace retro_api.Models
{
    public class StudentsModel : IStudentsModel
    {
        private IPotterContext _potterContext;

        public StudentsModel(IPotterContext potterContext)
        {
            _potterContext = potterContext;
        }

        public List<Student> SelectAllStudents()
        {
            try
            {
                var students = _potterContext.students.ToList();
                return students;
            }
            catch (Exception err)
            {
                return null;
            }

        }

        public List<Student> SelectStudentsByHouseId(int id)
        {
            try
            {
                return _potterContext.students.Where(student => student.HouseId == id).ToList();
            }
            catch (Exception err)
            {
                return null;
            }

        }
    }
}
