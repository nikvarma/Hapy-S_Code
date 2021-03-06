﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class UnRegisteredDevice: BaseResponse
    {
        public Guid Id { get; set; }
        public Device Device { get; set; }
        public string Type { get; set; }
        [Required]
        public int TypeId { get; set; }
        [Required]
        public string DeviceId { get; set; }
        [Required]
        public string DeviceNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerfiyed { get; set; }
    }
}
