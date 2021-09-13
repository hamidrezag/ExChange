﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public interface IBaseModel
    {
        long Id { get; set; }
    }
    public class BaseModel:IBaseModel
    {
        public long Id { get; set; }
    }
}
