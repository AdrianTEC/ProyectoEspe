﻿using System.ComponentModel.DataAnnotations;

namespace RestAPI_XF1Online.DTOs
{
    public class PlayerCreateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string AgeRange { get; set; }
    }
}