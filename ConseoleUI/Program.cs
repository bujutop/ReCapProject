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
            //DtoTest();

            //AddCustomer();

            //AddRental();

        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental { CustomerId = 2, CarId = 2, RentDate = DateTime.Now });
            Console.WriteLine(result.Message);
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 1, CompanyName = "Kumpanya" });
            Console.WriteLine(result.Message);
            var customers = customerManager.GetAll().Data;
            customers.ForEach(c => Console.WriteLine("Customer Id:{0}, UserId:{1}, Compan name:{2}", c.CustomerId, c.UserId, c.CompanyName));
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
           
            foreach (var car in result.Data)
            {
                Console.WriteLine("Car name: {0}, brand name: {1}, color name: {2}, daily price: {3}"
                    , car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
            
            
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var colors = colorManager.GetAll();
            Console.WriteLine("Start List:");
            colors.Data.ForEach(c => Console.WriteLine("Color id: {0}, color name: {1}", c.ColorId, c.ColorName));
            Console.WriteLine(colors.Message);//message for GetAll

            //Add new color:
            var operation = colorManager.Add(new Color { ColorId = 235, ColorName = "Pink" });
            colors = colorManager.GetAll();
            var newColor = colors.Data.Last();
            Console.WriteLine("\n" + "Add new color and show it:");
            Console.WriteLine("new color id: {0}, new color name: {1}", newColor.ColorId, newColor.ColorName);
            Console.WriteLine(operation.Message); //message for Add
            Console.WriteLine("--------");


            //Get color by id:
            var selectedColor = colorManager.GetColorById(235).Data;
            Console.WriteLine("Get color by id:");
            Console.WriteLine("Selected color id: {0}, selected color name: {1}", selectedColor.ColorId, selectedColor.ColorName);
            Console.WriteLine(colorManager.GetColorById(235).Message); //message for GetColorById

            //update color:
            Console.WriteLine("--------");
            selectedColor.ColorName = "Gray";
            operation = colorManager.Update(selectedColor);
            Console.WriteLine("Update color name:");
            Console.WriteLine("Color id :{0}, new name: {1}", selectedColor.ColorId, selectedColor.ColorName);
            Console.WriteLine(operation.Message); //message for update

            //delete color:
            Console.WriteLine("--------");
            Console.WriteLine("The list before delete:");
            colors = colorManager.GetAll();
            colors.Data.ForEach(c => Console.WriteLine("Color id: {0}, color name: {1}", c.ColorId, c.ColorName));
            Console.WriteLine(colors.Message); //message for GetAll
            operation=  colorManager.Delete(selectedColor);
            Console.WriteLine(operation.Message); //message for Delete
            colors = colorManager.GetAll();
            Console.WriteLine("\n" + "Final list after deleting color 235:");
            colors.Data.ForEach(c => Console.WriteLine("Color id: {0}, color name: {1}", c.ColorId, c.ColorName));
            Console.WriteLine(colors.Message); //message for GetAll
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brands = brandManager.GetAll();
            Console.WriteLine("Start List:");
            brands.Data.ForEach(b => Console.WriteLine("Brand id: {0}, brand name: {1}", b.BrandId, b.BrandName));
            Console.WriteLine(brands.Message);

            //Add new brand:
            var operation = brandManager.Add(new Brand { BrandId = 4, BrandName = "Ferrari" });
            brands = brandManager.GetAll();
            var newBrand = brands.Data.Last();
            Console.WriteLine("\n" + "Add new brand and show it:");
            Console.WriteLine("new brand id: {0}, new brand name: {1}", newBrand.BrandId, newBrand.BrandName);
            Console.WriteLine(operation.Message);
            Console.WriteLine("--------");
            



            //Get brand by id:
            var selectedBrand = brandManager.GetBrandById(4).Data;
            Console.WriteLine("Get brand by id:");
            Console.WriteLine("Selected brand id: {0}, selected brand name: {1}", selectedBrand.BrandId, selectedBrand.BrandName);
            Console.WriteLine(brandManager.GetBrandById(4).Message);

            //update brand:
            Console.WriteLine("--------");
            selectedBrand.BrandName = "Bugatti";
            operation = brandManager.Update(selectedBrand);            
            Console.WriteLine("Update brand name:");
            Console.WriteLine("Brand id :{0}, new name: {1}", selectedBrand.BrandId, selectedBrand.BrandName);
            Console.WriteLine(operation.Message);

            //delete brand:
            Console.WriteLine("--------");
            Console.WriteLine("The list before delete:");
            brands = brandManager.GetAll();
            brands.Data.ForEach(b => Console.WriteLine("Brand id: {0}, brand name: {1}", b.BrandId, b.BrandName));
            Console.WriteLine(brands.Message);
            operation = brandManager.Delete(selectedBrand);
            Console.WriteLine(operation.Message);
            brands = brandManager.GetAll();
            Console.WriteLine("\n" + "Final list after deleting brand 4:");
            brands.Data.ForEach(b => Console.WriteLine("Brand id: {0}, brand name: {1}", b.BrandId, b.BrandName));
            Console.WriteLine(brands.Message);
        }

        private static void CustomMappingTest()
        {
            //Custom Mapping
            Console.WriteLine("-----");
            Console.WriteLine("Custom Mapping");
            BuyerManager buyerManager = new BuyerManager(new EfBuyerDal());
            foreach (var buyer in buyerManager.GetAll().Data)
            {
                Console.WriteLine("Customer id: {0}, first name: {1}, last name: {2}", buyer.BuyerId, buyer.Name, buyer.Surname);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetAll();

            //Tüm liste
            Console.WriteLine("Start List:");

            cars.Data.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
            " Model Year: {3}, Daily Price: {4}, " +
            "Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
            Console.WriteLine(cars.Message);
            
            //Add new car,write new car
            var operation = carManager.Add(new Car { Id = 5, BrandId = 3, ColorId = 201, ModelYear = 2020, DailyPrice = 1500, Description = "Some car", CarName = "Ford" });
            
            cars = carManager.GetAll();
            var newCar = cars.Data.Last();
            Console.WriteLine("\n" + "Add new car and write only new car");
            Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}, " +
                "Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", newCar.Id, newCar.BrandId, newCar.ColorId, newCar.ModelYear,
                newCar.DailyPrice, newCar.Description);
            Console.WriteLine(operation.Message);


            //Delete car by id number

            operation= carManager.Delete(cars.Data.SingleOrDefault(c => c.Id == 5));
            Console.WriteLine("\n" + "Delete Car 5 and write new list");
            cars = carManager.GetAll();
            cars.Data.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
            Console.WriteLine(operation.Message);
            Console.WriteLine(cars.Message);
            //get car by id
            int carID = 4;
            var getCar = carManager.GetByCarId(carID).Data;
            Console.WriteLine("\n" + "Get by id");
            Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}, " +
                "Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", getCar.Id, getCar.BrandId, getCar.ColorId, getCar.ModelYear,
                getCar.DailyPrice, getCar.Description);
            Console.WriteLine(carManager.GetByCarId(carID).Message);


            //update car 
            getCar.ColorId = 101;
            getCar.Description = "the car";
            carManager.Update(getCar);
            
            cars = carManager.GetAll();
            Console.WriteLine("\n" + "update car 4");
            Console.WriteLine("new color: {0} , new description: {1}", getCar.ColorId, getCar.Description);
            Console.WriteLine(carManager.Update(getCar).Message);


            //Final version
            Console.WriteLine("\n" + "Final List:");
            cars.Data.ForEach(car => Console.WriteLine("Car Id: {0}, Brand Number: {1}, Color Number: {2}," +
                " Model Year: {3}, Daily Price: {4}," +
                " Description: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description));
            Console.WriteLine(cars.Message);

            Console.WriteLine("----");
            var BMWCars = carManager.GetCarsByBrandId(1);
            Console.WriteLine("BMW cars are: ");
            BMWCars.Data.ForEach(c => Console.WriteLine(c.CarName));
            Console.WriteLine(BMWCars.Message);
            
            Console.WriteLine("-----");
            var whiteCars = carManager.GetCarsByColorId(101);
            Console.WriteLine("White cars are:");
            whiteCars.Data.ForEach(c => Console.WriteLine(c.CarName));
            Console.WriteLine(whiteCars.Message);
            Console.WriteLine("----");
            //Addition Error
            operation = carManager.Add(new Car { Id = 6, BrandId = 2, ColorId = 101, DailyPrice = 0, ModelYear = 2020, CarName = "White mercedes", Description = "Just rent it" });
            Console.WriteLine(operation.Message);
            
        }
    }
}
