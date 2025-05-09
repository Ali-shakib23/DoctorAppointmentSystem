﻿using DoctorAppointment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Core.Domain.RepositoryContracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
