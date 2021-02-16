using Business.Concrete;
using DataAccess.Concrete.Repository;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    { 
        static void Main(string[] args)
        {

            // carManager.Add(new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, ModelYear = "2021", Description = "Otomatik Dizel" });
            //carManager.Add(new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 150, ModelYear = "2009", Description = "Otomatik Dizel" });
            //carManager.Add(new Car { Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 250, ModelYear = "2018", Description = "Otomatik Dizel" });
            //carManager.Add(new Car { Id = 4, BrandId = 2, ColorId = 1, DailyPrice = 600, ModelYear = "2021", Description = "Otomatik Dizel" });

            CarManager carManager = new CarManager(new EfCarDal());
           
            Console.WriteLine(carManager.Add(new Car { Id = 7, BrandId = 1, ColorId = 1, Description = "Mazda", DailyPrice = 0, ModelYear = "2021"}).Message);


            
        }
    }
}
