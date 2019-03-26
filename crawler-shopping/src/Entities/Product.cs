using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

using System.ComponentModel.DataAnnotations;

namespace crawler_shopping.src.Entities
{
    public class Product
    {
        [Key]
        public long? Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string UnitInfo { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
