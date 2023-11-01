﻿using System.ComponentModel.DataAnnotations;

namespace Tutorials.Models.Domain
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
