using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Test22_9.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
