using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Buyer>> GetAll()
        {
            return new SuccessDataResult<List<Buyer>>(_buyerDal.GetAll(),Messages.GetAll);
        }
    }
}
