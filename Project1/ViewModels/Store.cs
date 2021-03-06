﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.ViewModels
{
    public class Store
    {
        [Display(Name = "Store Number")]
        public int StoreId { get; set; }

        [Required]
        public string Location { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public long PhoneNumber { get; set; }

        public IEnumerable<Store> DropDownList { get; set; }

    }
}
