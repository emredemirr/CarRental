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
            //CarManagerTest();
            //ColorManagerTest();
            //BrandManagerTest();
            //CarDtoTest();
        }

        //private static void CarDtoTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarDetails())
        //    {
        //        Console.WriteLine(car.CarId + "-" + car.CarName + "-" + car.BrandName + "-" + car.ColorName + "-" + car.DailyPrice);
        //    }
        //}
        //private static void BrandManagerTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    Brand brand = new Brand() { BrandId = 1, BrandName = "Audi" };
        //    Brand brand2 = new Brand() { BrandId = 2, BrandName = "BMW" };
        //    Brand brand3 = new Brand() { BrandId = 3, BrandName = "Hyundai" };

        //    brandManager.Add(brand);
        //    brandManager.Add(brand2);
        //    brandManager.Add(brand3);
        //    brandManager.Delete(brand2);
        //    brandManager.Update(brand3);
        //    foreach (var brandGetAll in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brandGetAll.BrandId + "" + brandGetAll.BrandName);
        //    }
        //}
        //private static void ColorManagerTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    Color color = new Color() { ColorId = 1, ColorName = "Black-UpdateTest" };
        //    Color color2 = new Color() { ColorId = 2, ColorName = "Blue" };
        //    colorManager.Add(color2);
        //    colorManager.Delete(color2);
        //    colorManager.Update(color);
        //    foreach (var colorGetAll in colorManager.GetAll())
        //    {
        //        Console.WriteLine(color.ColorId + "/" + color.ColorName);
        //    }
        //}
        //private static void CarManagerTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Car car = new Car() { CarId = 6, CarName = "BMW", BrandId = 2, ColorId = 3, DailyPrice = 170, Description = "Update Test", ModelYear = 2019 };
        //    carManager.Add(car);
        //    carManager.Delete(car);
        //    carManager.Update(car);
        //    foreach (var car1 in carManager.GetAll())
        //    {
        //        Console.WriteLine(car1.CarId + "/" + car1.CarName + "/" + car1.Description);
        //    }
        //}
    }
}
