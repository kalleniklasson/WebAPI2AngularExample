using System;

namespace WebAPI2Angular.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
    }
}