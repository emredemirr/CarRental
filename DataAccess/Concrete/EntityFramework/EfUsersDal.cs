﻿using Core.DataAccess.EntityFramework.EfEntityRepositoryBase;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUsersDal : EfEntityRepositoryBase<Users, CarRentalContext>, IUsersDal
    {
    }
}
