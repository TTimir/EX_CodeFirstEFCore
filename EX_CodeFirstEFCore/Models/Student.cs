﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EX_CodeFirstEFCore.Models
{
    public class Student
    {
        [Key]
        public int SID { get; set; }
        [Column("StudentName", TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }
        [Column("StudentGender", TypeName = "varchar(100)")]
        [Required]
        public string Gender { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public int? Std { get; set; }
    }
}
