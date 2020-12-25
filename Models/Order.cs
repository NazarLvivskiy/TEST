using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TEST.Models
{
    public enum statuses
    {
        Status1,
        Status2,
        Status3
    }
    public class Order
    {
        public class request
        {
            [Required]
            public string dimension { get; set; }

            public Location pickup { get; set; }

            public Location dropOff { get; set; }
        }

        public class response
        {
            

            [Required]
            public string id { get; set; }

            [Required]
            public string dimension { get; set; }

            public statuses status { get; set; }

            public Location pickup { get; set; }

            public Location dropOff { get; set; }
        }
    }
    

    [Owned]
    public class Location
    {
        public double latitude { get; set; }

        public double longitude { get; set; }
    }



}
