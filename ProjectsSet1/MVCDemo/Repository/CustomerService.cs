using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CustomerApp.DTO;
using System.IO;

namespace CustomerApp.Repository
{
    public class CustomerService : ICustomerService
    {
        public void Add(Customer customer)
        {
            string customerCSV=GetCustomerCSV(customer);
            WriteToFile(customerCSV);
        }
  
        public string GetCustomerCSV(Customer customer)
        {
            string csvResult = string.Format("{0},{1},{2}\n", customer.FirstName, customer.LastName, customer.Email);
            return csvResult;
        }
        private void WriteToFile(string data)
        {
            string filepath = ConfigurationManager.AppSettings["FilePath"];

            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
            }

            File.AppendAllText(filepath, data);
        }
    }
}
