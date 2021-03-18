using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyDatabaseContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserID
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentalDetailsDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 CustomerId = cu.CustomerId,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }


}
