using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerApp.DTO;


namespace CustomerApp.Repository
{
    public interface ICustomerService
    {
        void Add(Customer customer);        
    }
}
