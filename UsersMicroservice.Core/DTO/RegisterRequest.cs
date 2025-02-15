﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersMicroservice.Core.DTO
{
    public record RegisterRequest(
        string? Email,
        string? Password,
        string? PersonName,
        GenderOptions Gender)
    {
        public RegisterRequest() : this(default, default, default, default)
        {
        }
    }
}
