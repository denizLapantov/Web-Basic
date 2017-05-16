﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniStore.Models
{
    public class Login
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string SessionId { get; set; }

        public bool IsActive { get; set; }
    }
}
