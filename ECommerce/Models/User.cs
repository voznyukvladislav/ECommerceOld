﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        List<Order> Orders { get; set; }
    }
}
