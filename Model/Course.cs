using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    [Table("course")]
    public class Course
    {
        [Key]
        [Required]
        [Column("COURSE_ID")]
        public int id { get; set; }
        [Column("COURSE_NAME")]
        public String courseName { get; set; }
        [Column("credit")]
        public float credit { get; set; }

    }
}
