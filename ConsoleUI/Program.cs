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
            //UsersManagerTest();
            //CustomerManagerTest();
            //RentalManagerTest();
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarId + "-" + car.CarName + "-" + car.BrandName + "-" +
                                  car.ColorName + "-" + car.DailyPrice);
            }
        }

        private static void BrandManagerTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand() { BrandId = 1, BrandName = "Audi" };
            Brand brand2 = new Brand() { BrandId = 2, BrandName = "BMW" };
            Brand brand3 = new Brand() { BrandId = 3, BrandName = "Hyundai" };

            brandManager.Add(brand);
            brandManager.Add(brand2);
            brandManager.Add(brand3);
            brandManager.Delete(brand2);
            brandManager.Update(brand3);
            foreach (var brandGetAll in brandManager.GetAll().Data)
            {
                Console.WriteLine(brandGetAll.BrandId + "" + brandGetAll.BrandName);
            }
        }

        private static void ColorManagerTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color() { ColorId = 11, ColorName = "Black-Test2" };
            Color color2 = new Color() { ColorId = 18, ColorName = "Blue-Test2" };
            colorManager.Add(color2);
            colorManager.Delete(color2);
            colorManager.Update(color);
            foreach (var colorGetAll in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + "/" + color.ColorName);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car()
            {
                CarId = 6,
                CarName = "BMW",
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 170,
                Description = "Update Test",
                ModelYear = 2019
            };
            carManager.Add(car);
            carManager.Delete(car);
            carManager.Update(car);
            foreach (var car1 in carManager.GetAll().Data)
            {
                Console.WriteLine(car1.CarId + "/" + car1.CarName + "/" + car1.Description);
            }
        }

        private static void UsersManagerTest()
        {
            UserManager userManager = new UserManager(new EfUsersDal());
            Users users = new Users()
            {

            };
            userManager.Add(users);

            Users users2 = new Users()
            {

            };
            userManager.Delete(users2);

            Users users3 = new Users()
            {

            };
            userManager.Update(users3);

        }

        private static void CustomerManagerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomersDal());
            Customers customers = new Customers()
            {
                UserId = 1,
                CompanyName = "HogsMeade Test."
            };
            customerManager.Add(customers);

            Customers customers2 = new Customers()
            {
                CustomerId = 2,
                UserId = 2,
                CompanyName = "a"
            };
            customerManager.Delete(customers2);

            Customers customers3 = new Customers()
            {
                CustomerId = 3,
                UserId = 3,
                CompanyName = "Test."

            };
            customerManager.Update(customers3);
        }

        private static void RentalManagerTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalsDal());
            Rentals rentals = new Rentals()
            {
                CarId = 1,
                CustomerId = 3,
                RentDate = new DateTime(2021, 4, 1),
                ReturnDate = new DateTime(2021, 4, 10)
            };
            rentalManager.Add(rentals);
        }
    }
}
