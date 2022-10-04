using System.ComponentModel.Design;
using System.Collections.Generic;

namespace ShoppingList
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to The Minnie Mart!");
            
            //loop for customers cart
            List<string> customersCart = new List<string>();

            bool orderAgain = true;
            while (orderAgain == true)
            {

                Console.WriteLine("");
                Console.WriteLine("Item \t Price");
                Console.WriteLine("===============");

                //Dictionaryfor menu
                Dictionary<string, double> menu = new Dictionary<string, double>();
                menu.Add("apple", .87);
                menu.Add("banana", 0.62);
                menu.Add("fig", 1.79);
                menu.Add("honey", 1.56);
                menu.Add("grapes", 1.65);
                menu.Add("jelly", 2.84);
                menu.Add("salt", 1.99);
                menu.Add("lemon", 1.54);



                //displaying full menu
                foreach (KeyValuePair<string, double> item in menu)
                {
                    Console.WriteLine(item.Key + " \t" + item.Value);
                }

                //allowing user to pick an item and dispalying it.
                Console.Write("Which item would you like to order? ");
                string cart = Console.ReadLine().ToLower();

                bool validItem = true;
                while (validItem == true)
                {
                    if (menu.ContainsKey(cart))
                    {
                        Console.WriteLine("Adding " + cart + " to cart for $" + menu[cart] + ".");
                        customersCart.Add(cart);
                        validItem = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, we do not sell that. Please try again.");
                        cart = Console.ReadLine().ToLower();
                        validItem = true;

                    }
                }


                orderAgain = AskToContinue(customersCart, menu);
                              
               
            }
        }
        //method that dies my calculations and ask the user if they want to go again
        public static bool AskToContinue(List <string> customersCart, Dictionary <string, double> menu)
        {

            double averagePrice = 0;
            double sum = 0;

            Console.WriteLine("Would you like to order anything else? Y/N.");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                return true;
            }
            else if (answer == "n")
            {
                Console.WriteLine("Here's what you got:");
                foreach (string items in customersCart)
                {
                    Console.WriteLine(items + " \t" +  menu[items]);
                    sum += menu[items];
                }
                averagePrice = sum / customersCart.Count();

                Console.WriteLine("Average price per item in order was $" + averagePrice);
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, that was an invalid response, please input a valid response.");
                return AskToContinue(customersCart, menu);
            }
        }

    
    }
}