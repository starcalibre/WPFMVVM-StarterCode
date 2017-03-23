﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZzaDashboard.Orders
{
    internal class OrderViewModel : BindableBase
    {
        private Guid _customerId;

        public Guid CustomerId
        {
            get { return _customerId; }
            set { SetProperty(ref _customerId, value); }
        }
    }
}
