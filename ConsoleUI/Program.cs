using Business.Concrete;
using DataAccess.Abstract.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { CarId = 2, CarName = "Audi", BrandId=2, ColorId=3,DailyPrice=170,Description="Araba", ModelYear=2019 }) ;
            
            foreach (var car1 in carManager.GetAll())
            {
                Console.WriteLine(car1.Description);
            }
        }
    }
}
