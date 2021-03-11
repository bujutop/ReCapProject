using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConseoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //CustomMappingTest();

            //BrandTest();
            //ColorTest();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car name: {0}, brand name: {1}, color name: {2}, daily price: {3}"
                    ,car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var colors = colorManager.GetAll();
            Console.WriteLine("Start List:");
            colors.ForEach(c => Console.WriteLine("Color id: {0}, color name: {1}", c.ColorId, c.ColorName));

            //Add new color:
            colorManager.Add(new Color { ColorId = 235, ColorName = "Pink" });
            colors = colorManager.GetAll();
            Console.WriteLine("\n" + "Add new color and show it:");
            Console.WriteLine("new color id: {0}, new color name: {1}", colors.Last().ColorId, colors.Last().ColorName);
            Console.WriteLine("--------");


            //Get color by id:
            var selectedColor = colorManager.GetColorById(235);
            Console.WriteLine("Get color by id:");
            Console.WriteLine("Selected color id: {0}, selected color name: {1}", selectedColor.ColorId, selectedColor.ColorName);

            //update color:
            Console.WriteLine("--------");
            selectedColor.ColorName = "Gray";
            colorManager.Update(selectedColor);
            Console.WriteLine("Update color name:");
            Console.WriteLine("Color id :{0}, new name: {1}", selectedColor.ColorId, selectedColor.ColorName);

            //delete color:
            Console.WriteLine("--------");
            Console.WriteLine("The list before delete:");
            colors = colorManager.GetAll();
            colors.ForEach(c => Console.WriteLine("Color id: {0}, color name: {1}", c.ColorId, c.ColorName));
            colorManager.Delete(selectedColor);
            colors = colorManager.GetAll();
            Console.WriteLine("\n" + "Final list after deleting color 235:");
            colors.ForEach(c => Console.WriteLine("Color id: {0}, color name: {1}", c.ColorId, c.ColorName));
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brands = brandManager.GetAll();
            Console.WriteLine("Start List:");
            brands.ForEach(b => Console.WriteLine("Brand id: {0}, brand name: {1}", b.BrandId, b.BrandName));

            //Add new brand:
            brandManager.Add(new Brand { BrandId = 4, BrandName = "Ferrari" });
            brands = brandManager.GetAll();
            Console.WriteLine("\n" + "Add new brand and show it:");
            Console.WriteLine("new brand id: {0}, new brand name: {1}", brands.Last().BrandId, brands.Last().BrandName);
            Console.WriteLine("--------");


            //Get brand by id:
            var selectedBrand = brandManager.GetBrandById(4);
            Console.WriteLine("Get brand by id:");
            Console.WriteLine("Selected brand id: {0}, selected brand name: {1}", selectedBrand.BrandId, selectedBrand.BrandName);

            //update brand:
            Console.WriteLine("--------");
            selectedBrand.BrandName = "Bugatti";
            brandManager.Update(selectedBrand);
            Console.WriteLine("Update brand name:");
            Console.WriteLine("Brand id :{0}, new name: {1}", selectedBrand.BrandId, selectedBrand.BrandName);

            //delete brand:
            Console.WriteLine("--------");
            Console.WriteLine("The list before delete:");
            brands = brandManager.GetAll();
            brands.ForEach(b => Console.WriteLine("Brand id: {0}, brand name: {1}", b.BrandId, b.BrandName));
            brandManager.Delete(selectedBrand);
            brands = brandManager.GetAll();
            Console.WriteLine("\n" + "Final list after deleting brand 4:");
            brands.ForEach(b => Console.WriteLine("Brand id: {0}, brand name: {1}", b.BrandId, b.BrandName));
        }

        private static void CustomMappingTest()
        {
            //Custom Mapping
            Console.WriteLine("-----");
            Console.WriteLine("Custom Mapping");
            BuyerManager buyerManager = new BuyerManager(new EfBuyerDal());
            foreach (var buyer in buyerManager.GetAll())
            {
                Console.WriteLine("Customer id: {0}, first name: {1}, last name: {2}", buyer.BuyerId, buyer.Name, buyer.Surname);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = carManager.GetAll();

            //Tüm liste
            Console.WriteLine("Start List:");
            cars.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}, " +
                "Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            //Add new car,write new car
            carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 201, ModelYear = 2020, DailyPrice = 1500, Description = "Some car", CarName = "Ford" });
            cars = carManager.GetAll();
            var newCar = cars.Last();
            Console.WriteLine("\n" + "Add new car and write only new car");
            Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}, " +
                "Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", newCar.Id, newCar.BrandId, newCar.ColorId, newCar.ModelYear,
                newCar.DailyPrice, newCar.Description);

            //Delete car by id number
            carManager.Delete(cars.SingleOrDefault(c => c.Id == 5));
            Console.WriteLine("\n" + "Delete Car 5 and write new list");
            cars = carManager.GetAll();
            cars.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            //get car by id
            int carID = 4;
            var getCar = carManager.GetByCarId(carID);
            Console.WriteLine("\n" + "Get by id");
            Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}, " +
                "Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", getCar.Id, getCar.BrandId, getCar.ColorId, getCar.ModelYear,
                getCar.DailyPrice, getCar.Description);


            //update car 
            getCar.ColorId = 101;
            getCar.Description = "the car";
            carManager.Update(getCar);
            cars = carManager.GetAll();
            Console.WriteLine("\n" + "update car 4");
            Console.WriteLine("new color: {0} , new description: {1}", getCar.ColorId, getCar.Description);



            //Final version
            Console.WriteLine("\n" + "Final List:");
            cars.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            Console.WriteLine("----");
            var BMWCars = carManager.GetCarsByBrandId(1);
            Console.WriteLine("BMW cars are: ");
            BMWCars.ForEach(c => Console.WriteLine(c.CarName));
            Console.WriteLine("-----");
            var WhiteCars = carManager.GetCarsByColorId(101);
            Console.WriteLine("White cars are:");
            WhiteCars.ForEach(c => Console.WriteLine(c.CarName));

            Console.WriteLine("----");
            carManager.Add(new Car { Id = 6, BrandId = 2, ColorId = 101, DailyPrice = 0, ModelYear = 2020, CarName = "White mercedes", Description = "Just rent it" });
            cars = carManager.GetAll();
        }
    }
}
