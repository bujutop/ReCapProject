using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfBuyerDal : IBuyerDal
    {
        public void Add(Buyer entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Buyer entity)
        {
            throw new NotImplementedException();
        }

        public Buyer Get(Expression<Func<Buyer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Buyer> GetAll(Expression<Func<Buyer, bool>> filter = null)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                return filter == null ? context.Set<Buyer>().ToList() : context.Set<Buyer>().Where(filter).ToList();
            }
        }

        public void Update(Buyer entity)
        {
            throw new NotImplementedException();
        }
    }
}
