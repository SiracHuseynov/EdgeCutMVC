﻿using System.ComponentModel.DataAnnotations;

namespace EdgeCut.ViewModels
{
    public class AdminLoginVm
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
        public bool IsPersistent { get; set; }          

    }
}
