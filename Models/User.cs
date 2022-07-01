﻿namespace DiaryAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime? RegisteredOn { get; set; } 

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Username { get; set; }

        public string? Gender { get; set; }

        public bool? IsActive { get; set; }






    }
}
