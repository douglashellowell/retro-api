using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace retro_api
{
    public class House
    {
        [Key]
        [Column("house_id")]
        public int Id { get; set; }

        [Column("house_name")]
        public string HouseName { get; set; }

        [Column("founder")]
        public string Founder { get; set; }

        [Column("animal")]
        public string Animal { get; set; }

        //public House(int house_id, string house_name, string founder, string animal)
        //{
        //    Id = house_id;
        //    House_name = house_name;
        //    Founder = founder;
        //    Animal = animal;
        //}
    }
}
