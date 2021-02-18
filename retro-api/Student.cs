using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace retro_api
{
    public class Student
    {
        [Key]
        [Column("student_id")]
        public int Id { get; set; }

        [Column("student_name")]
        public string StudentName { get; set; }

        [ForeignKey("house_id")]
        [Column("house_id")]
        public int HouseId { get; set; }

    }
}
