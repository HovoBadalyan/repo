using Cofee_Machine.Models;
using System;
using System.Linq;

namespace Cofee_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            //for add coffee
            //using (var dbContext=new CofeeDbContext())
            //{
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Nescafe", Water = 0.1, Sugar = 0.1, Coffee = 0.1, Price = 100 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Espresso", Water = 0.1, Sugar = 0.1, Coffee = 0.1, Price = 150 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Espresso Machiato", Water = 0.1, Sugar = 0.1, Coffee = 0.2, Price = 200 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Amerikano", Water = 0.1, Sugar = 0.2, Coffee = 0.2, Price = 200 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Cappuchino", Water = 0.15, Sugar = 0.2, Coffee = 0.4, Price = 200 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Latte", Water = 0.15, Sugar = 0.3, Coffee = 0.2, Price = 250 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "HotChocolate", Water = 0.2, Sugar = 0.3, Coffee = 0.1, Price = 250 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Mokacchino", Water = 0.2, Sugar = 0.3, Coffee = 0.3, Price = 250 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Doppio", Water = 0.2, Sugar = 0.3, Coffee = 0.5, Price = 300 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Tea", Water = 0.2, Sugar = 0.3, Coffee = 0.0, Price = 100 });
            //    dbContext.Add(new CoffeeModel { CoffeeName = "Hot Water", Water = 0.2, Sugar = 0.0, Coffee = 0.0, Price = 50 });

            //    dbContext.SaveChanges();
            //}


            var CofeeMachine = new CoffeeMachine();

            Console.WriteLine("Please enter coin (50,100,200,500)");

            int a=Convert.ToInt32(Console.ReadLine());

            CofeeMachine.DepositCoin(a);

            Console.ReadLine();
        }
    }
}
