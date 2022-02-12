using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReactiveGUIService
{
    public class ReactiveService
    {
        private IList<CustomerData> _customerData;
        public ReactiveService()
        {
            _customerData = new List<CustomerData>();
            Init();
        }

        private void Init()
        {
            for(var count=1;count<10000;count++)
            {
                _customerData.Add(new CustomerData()
                {
                    CustomerId = count,
                    CustomerName = string.Concat("Customer", count.ToString()),
                    CustomerAddress = string.Concat("CustomerAddress", count.ToString())
                }) ;
                
            }
        }

        public IList<CustomerData> LoadCustomerData()
        {
            return _customerData;
        }

        public IList<CustomerData> QueryCustomerData(string customerName)
        {
            return _customerData.Where(p => p.CustomerName.Contains(customerName)).ToList();
        }

    }
}
