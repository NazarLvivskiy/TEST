using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class OrderParameters
    {

        public int start { get; set; } = 1;

        public int quantity { get; set; } = 1;

        public statuses status { get; set; } = statuses.Status1;
    }
}
