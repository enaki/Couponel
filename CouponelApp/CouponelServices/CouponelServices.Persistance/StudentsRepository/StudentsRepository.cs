﻿using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CouponelServices.Persistence.StudentsRepository
{
    public sealed class StudentsRepository : Repository<Student>, IStudentsRepository
    {
        public StudentsRepository(CouponelContext context) : base(context) { }
    }
}