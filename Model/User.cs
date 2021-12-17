using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("user")]
    public class User
    {
        [Key]
        [Required]
        [Column("USER_ID")]
        public int id { get; set; }
        [Column("USER_NAME")]
        public String name { get; set; }
        [Column("password")]
        public String password { get; set; }
        [Column("age")]
        public int age { get; set; }
        [Column("sex")]
        public String sex { get; set; }

    }
}