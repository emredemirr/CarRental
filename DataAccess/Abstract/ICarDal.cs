﻿using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract.EntityFramework
{
    public interface ICarDal:IEntityRepository<Car>
    {

    }
}