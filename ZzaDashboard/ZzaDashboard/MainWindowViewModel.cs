using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZzaDashboard.Customers;
using ZzaDashboard.OrderPrep;
using ZzaDashboard.Orders;

namespace ZzaDashboard
{
    class MainWindowViewModel
    {
        private CustomerListViewModel _customerListViewModel = new CustomerListViewModel();
        private OrderViewModel _orderViewModel = new OrderViewModel();
        private OrderPrepViewModel _orderPrepViewModel = new OrderPrepViewModel();

        public Object CurrentViewModel { get; set; }
    }
}
