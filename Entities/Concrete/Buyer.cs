using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Buyer:IEntity
    {
        public int BuyerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
