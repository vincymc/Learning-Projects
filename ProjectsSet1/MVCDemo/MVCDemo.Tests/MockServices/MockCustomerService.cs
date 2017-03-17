using CustomerApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.DTO;

namespace CustomerApp.Tests.MockServices
{
    public class MockCustomerService : ICustomerService
    {
        public void Add(Customer customer)
        {
           // throw new NotImplementedException();
        }
    }
}
