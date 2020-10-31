using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using CashFlow.Library.Domain.SeedWork;

namespace CashFlow.Library.Domain
{
    public class Owner : IAggregateRoot
    {    

        public string IdentityGuid { get; private set; }

        public string Name { get; private set; }

    }

}