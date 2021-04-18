using System;
using System.Collections.Generic;
using System.Text;

namespace Cofee_Machine
{
    class TotalProduct
    {
        public double water = 10;
        public double sugar = 10;
        public double coffee = 10;

    public void ShowProduct()
    {
            Console.WriteLine($"water= {water} \t sugar= {sugar} \t coffee= {coffee}");
    }

    }
}
