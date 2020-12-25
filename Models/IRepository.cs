using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public interface IRepository
    {
        void POST(Order.request order);

        List<Order.response> GET(OrderParameters orderParameters);

        Task<Order.response> GET(string id);
    }
}
