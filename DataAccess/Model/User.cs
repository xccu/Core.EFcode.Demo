using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("user")]
    public class User
    {
        [Key]
        [Required]
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public String name { get; set; }
        [Column("password")]
        public String password { get; set; }
        [Column("age")]
        public int age { get; set; }
        [Column("sex")]
        public String sex { get; set; }

    }
}