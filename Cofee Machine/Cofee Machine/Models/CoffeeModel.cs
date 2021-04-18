using System;
using System.Collections.Generic;
using System.Text;

namespace Cofee_Machine.Models
{
   public class CoffeeModel
    {
        public int Id { get; set; }
        public string CoffeeName  { get; set; }
        public double Water  { get; set; }
        public double Sugar  { get; set; }
        public double Coffee  { get; set; }
        public decimal Price { get; set; }

    }
}
