﻿using Domain.Dtos.Role;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IRoleServices : IBaseServices<Role,RoleDto>
    {
    }
}
