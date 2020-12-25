using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class Repository : IRepository
    {
        MyContext db;

        public Repository(MyContext myContext)
        {
            db = myContext;
        }

        public List<Order.response> GET(OrderParameters parameters)
        {
            return db.Orders.ToList().OrderBy(or=> or.id).Skip(parameters.start - 1).Take(parameters.quantity).Where(or=>or.status == parameters.status).ToList();
        }

        public async Task<Order.response> GET(string id)
        {
            return await db.Orders.FirstOrDefaultAsync(x => x.id == id);
        }

        public async void POST(Order.request order)
        {
            await db.Orders.AddAsync(new Order.response { id = Guid.NewGuid().ToString("N"), dimension = order.dimension, dropOff = order.dropOff, pickup = order.pickup}); ;
            
            db.SaveChanges();
        }
    }
}
