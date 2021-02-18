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
    }
}
