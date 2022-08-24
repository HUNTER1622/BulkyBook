﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Model
{
    public class CoverType
    {
        [Key]
        public int CoverTypeId { get; set; }
        [Required]
        [Display(Name ="Cover Type")]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
