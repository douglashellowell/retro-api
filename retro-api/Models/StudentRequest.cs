using System;
namespace retro_api.Models
{
    public class StudentRequest
    {
        public string StudentName { get; set; }
    }

    public static class StudentRequestExtension
    {
        public static Student ToStudent(this StudentRequest newStudent, int houseId)
        {
            return new Student()
            {
                StudentName = newStudent.StudentName,
                HouseId = houseId
            };
        }
    }
}
