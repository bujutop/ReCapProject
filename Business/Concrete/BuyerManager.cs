using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BuyerManager : IBuyerService
    {
        IBuyerDal _buyerDal;

        public BuyerManager(IBuyerDal buyerDal)
        {
            _buyerDal = buyerDal;
        }

        public List<Buyer> GetAll()
        {
            return _buyerDal.GetAll();
        }
    }
}
