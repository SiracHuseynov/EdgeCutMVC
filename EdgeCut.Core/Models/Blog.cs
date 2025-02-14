﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCut.Core.Models
{
    public class Blog : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        public string? RedirectUrl { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped] 
        public IFormFile? ImageFile { get; set; }       
    }
}
