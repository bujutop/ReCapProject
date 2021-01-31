using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            List<Car> cars = carManager.GetAll();

            //Tüm liste
            Console.WriteLine("Start List:");
            cars.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}, " +
                "Description: {5}",car.Id,car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description));
            
            //Add new car,write new car
            carManager.Add(new Car { Id = 5, BrandId = 38, ColorId = 100, ModelYear = 1996, DailyPrice = 50, Description = "A white old cheap car" });
            var newCar = cars.Last();
            Console.WriteLine("\n" + "Add new car and write only new car");
            Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}, " +
                "Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", newCar.Id, newCar.BrandId, newCar.ColorId, newCar.ModelYear, 
                newCar.DailyPrice, newCar.Description);

            //Delete car by id number
            carManager.Delete(cars.SingleOrDefault(c => c.Id == 2));
            Console.WriteLine("\n" + "Delete Car 2 and write new list");
            cars.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

            //get car by id
            int carID = 5;
            var getCar = carManager.GetById(carID)[0];
            Console.WriteLine("\n" + "Get by id");
            Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}, " +
                "Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", getCar.Id, getCar.BrandId, getCar.ColorId, getCar.ModelYear,
                getCar.DailyPrice, getCar.Description);


            //update car 
            getCar.ColorId = 3;
            getCar.Description = "zzzzzz";
            carManager.Update(getCar);
            Console.WriteLine("\n" + "update car 5");
            Console.WriteLine("new color: {0} , new description: {1}",getCar.ColorId,getCar.Description);


           
            //Final version
            Console.WriteLine("\n" +"Final List:");
            cars.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));

















        }
    }
}
