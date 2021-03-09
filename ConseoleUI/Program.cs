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
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> cars = carManager.GetAll();

            //Tüm liste
            Console.WriteLine("Start List:");
            cars.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}, " +
                "Description: {5}",car.Id,car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description));
            
            //Add new car,write new car
            carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 201, ModelYear = 2020, DailyPrice = 1500, Description= "Some car" ,CarName="Ford"});
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
