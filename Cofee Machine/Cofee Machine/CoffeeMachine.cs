using Cofee_Machine.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cofee_Machine
{
    class CoffeeMachine
    {
        readonly TotalProduct total = new TotalProduct();


        public decimal CostofCoffee;
        public decimal RunningTotal { get; set; }



        public CoffeeMachine()
        {
            RunningTotal = 0;
        }

        public void DepositCoin(int money)
        {
            bool invalid = false;
            while (!invalid)
            {
                switch (money)
                {
                    case 50:
                        RunningTotal += 50;
                        Console.WriteLine("\nYour balanc " + RunningTotal);
                        invalid = true;
                        break;

                    case 100:
                        RunningTotal += 100;
                        Console.WriteLine("\nYour balanc " + RunningTotal);
                        invalid = true;
                        break;

                    case 200:
                        RunningTotal += 200;
                        Console.WriteLine("\nYour balanc " + RunningTotal);
                        invalid = true;
                        break;

                    case 500:
                        RunningTotal += 500;
                        Console.WriteLine("\nYour balanc " + RunningTotal);
                        invalid = true;
                        break;

                    default:
                        Console.WriteLine("\nInvalid Entry. Please enter 50, 100, 200, 500");
                        money = Convert.ToInt32(Console.ReadLine());
                        invalid = false;
                        break;
                }
            }
            DisplayCoffeesSelection();
        }



        public void DisplayCoffeesSelection()
        {
            Console.WriteLine();
            Console.WriteLine("******************************           *      *         ");
            Console.WriteLine("**1 - for Nescafe           **          *     *           ");
            Console.WriteLine("**2 - for Espresso          **           *      *         ");
            Console.WriteLine("**3 - for Espresso Machiato **          *     *           ");
            Console.WriteLine("**4 - for Amerikano         **     ** ************ **     ");
            Console.WriteLine("**5 - for Cappuchino        **     **              ** *** ");
            Console.WriteLine("**6 - for Latte             **     **              **  ** ");
            Console.WriteLine("**7 - for HotChocolate      **     **              **  ** ");
            Console.WriteLine("**8 - for Mokacchino        **     **              ** **  ");
            Console.WriteLine("**9 - for Doppio            **      **            **      ");
            Console.WriteLine("**10 - for Tea              **       **         **        ");
            Console.WriteLine("**11 - for Hot Water        **         *********          ");
            Console.WriteLine("******************************                            ");
            Console.WriteLine();
            Console.WriteLine("Please choose your selection");

            CoffeeSelection(Convert.ToInt32(Console.ReadLine()));
        }


        private void CoffeeSelection(int id)
        {
            bool t = false;
            var dbContext = new CofeeDbContext();
            bool selectionOK = false;
            while (!selectionOK)
            {
                switch (id)
                {
                    case 1:
                        using (dbContext)
                        {
                            var cofename = dbContext.Coffees.Where(x => x.Id == 1);
                            foreach (var item in cofename)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 2:
                        using (dbContext)
                        {
                            var cofename2 = dbContext.Coffees.Where(x => x.Id == 2);
                            foreach (var item in cofename2)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 3:
                        using (dbContext)
                        {
                            var cofename3 = dbContext.Coffees.Where(x => x.Id == 3);
                            foreach (var item in cofename3)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 4:
                        using (dbContext)
                        {
                            var cofename4 = dbContext.Coffees.Where(x => x.Id == 4);
                            foreach (var item in cofename4)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 5:
                        using (dbContext)
                        {
                            var cofename5 = dbContext.Coffees.Where(x => x.Id == 5);
                            foreach (var item in cofename5)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 6:
                        using (dbContext)
                        {
                            var cofename6 = dbContext.Coffees.Where(x => x.Id == 6);
                            foreach (var item in cofename6)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 7:
                        using (dbContext)
                        {
                            var cofename7 = dbContext.Coffees.Where(x => x.Id == 7);
                            foreach (var item in cofename7)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 8:
                        using (dbContext)
                        {
                            var cofename8 = dbContext.Coffees.Where(x => x.Id == 8);
                            foreach (var item in cofename8)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                            int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 9:
                        using (dbContext)
                        {
                            var cofename9 = dbContext.Coffees.Where(x => x.Id == 9);
                            foreach (var item in cofename9)
                            {
                                CostofCoffee = item.Price;
                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                        int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 10:
                        using (dbContext)
                        {
                            var cofename10 = dbContext.Coffees.Where(x => x.Id == 10);
                            foreach (var item in cofename10)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                        int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    case 11:
                        using (dbContext)
                        {
                            var cofename11 = dbContext.Coffees.Where(x => x.Id == 11);
                            foreach (var item in cofename11)
                            {
                                CostofCoffee = item.Price;

                                if (RunningTotal >= CostofCoffee)
                                {
                                    if (total.coffee > item.Coffee && total.water > item.Water && total.sugar > item.Sugar)
                                    {
                                        Console.WriteLine($"\nThank you for choosing {item.CoffeeName} product is ready");
                                        RunningTotal -= CostofCoffee;
                                        Console.WriteLine($"\nwater= {total.water - item.Water} \nsugar= {total.sugar - item.Sugar} \ncoffee= {total.coffee - item.Coffee}");
                                        total.water -= item.Water;
                                        total.sugar -= item.Sugar;
                                        total.coffee -= item.Coffee;
                                        Console.WriteLine("\nYour change is {0}", RunningTotal);
                                        Console.WriteLine("\nPlease you action 0 for take change and 1 for continue order");
                                        while (!t)
                                        {
                                        int i = Convert.ToInt32(Console.ReadLine());
                                            switch (i)
                                            {
                                                case 0:
                                                    Console.WriteLine($"\nPleas take your change {RunningTotal}");
                                                    RunningTotal -= RunningTotal;
                                                    t = true;
                                                    DisplayCoffeesSelection();
                                                    break;
                                                case 1:
                                                    DisplayCoffeesSelection();
                                                    t = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("\ninvalid key, please enter valid key");
                                                    i = Convert.ToInt32(Console.ReadLine());
                                                    t = false;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSorry  not enough ingredients in the store ");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nyou don’t have enough money in your balance please add {0}", item.Price - RunningTotal);
                                    DepositCoin(Convert.ToInt32(Console.ReadLine()));
                                }
                            }
                            selectionOK = true;
                            break;
                        }

                    default:
                        Console.WriteLine("invalid Selection please select now");
                        id = Convert.ToInt32(Console.ReadLine());
                        selectionOK = false;
                        break;
                }
            }
        }

    }
}
