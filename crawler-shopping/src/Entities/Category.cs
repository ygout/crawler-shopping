using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crawler_shopping.src.Entities
{
    public class Category
    {
        [Key]
        public string Uid { get; set; }
        public string Name { get; set; }

    }
}
