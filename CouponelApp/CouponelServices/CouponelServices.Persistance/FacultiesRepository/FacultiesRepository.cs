using System;
using System.Collections.Generic;
using System.Text;
using CouponelServices.Entities;
using CouponelServices.Persistence.Repository;

namespace CouponelServices.Persistence.FacultyRepository
{
    public sealed class FacultyRepository: Repository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(CouponelContext context) : base(context)
        {
        }
    }
}
