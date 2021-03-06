﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBuyerService
    {
        IDataResult<List<Buyer>> GetAll();
        IResult Add(Buyer buyer);
    }
}
