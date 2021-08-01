﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderDetail.Models
{
    class CustomerOrderDetailModel
    {
        public int CustomerOrderId { get; set; }

        public int CustomerId { get; set; }

        public int ItemId { get; set; }

        public string FirstNmae { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}
