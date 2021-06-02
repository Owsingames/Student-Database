using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab8___Student_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            bool onContinue = true;
            while(onContinue == true)
            {
                string message = GetUserInput("");
                PersonIndex(message);
                onContinue = PickAgain();
            }    
        }

        public static string GetUserInput(string input)
        {
            Console.WriteLine("Welcome to the student database");
            Console.WriteLine("Please select a NUMBER to learn more about a person\n");
            
            Console.WriteLine("0) Mark");
            Console.WriteLine("1) Andrew");
            Console.WriteLine("2) Tommy");
            Console.WriteLine("3) Maggie");
            Console.WriteLine("4) Jerome");
            Console.WriteLine("5) Trent");
            Console.WriteLine("6) Troy");
            Console.WriteLine("7) Kevin");
            Console.WriteLine("8) Joshua");
            Console.WriteLine("9) Sean");
            Console.WriteLine("10) Kate");
            Console.WriteLine("11) James");
            Console.WriteLine();

            string userInput = Console.ReadLine().ToLower().Trim();
            
            if(userInput == "")
            {
                Console.Clear();
                Console.WriteLine("Please enter a number");
                return GetUserInput(userInput);
            }
            else
            {
                Console.Clear();
                return userInput;
            }

           
        }

        public static void PersonIndex(string input)
        {
            Console.Clear();

            //list of names
            List<string> names = new List<string>();
            names.Add("Mark Haines"); //food: Cilantro -- hometown: Grand Rapids MI
            names.Add("Andrew Klima"); //food: sushi -- hometown: Grayslake MI
            names.Add("Tommy Waalkes"); //food: Chicken curry -- hometown: Raleigh NC
            names.Add("Maggie Tamanini"); //food: Movie theater popcorn -- hometown: Montrose Mi
            names.Add("Jerome Brown"); //food: Italian cusine -- hometown: Milwaukee WI
            names.Add("Trent Nedbal"); //food: tacos -- hometown: Rochester MI
            names.Add("Troy Vizina"); //food: Broccoli -- hometown: Indian River MI
            names.Add("Kevin Jackson II"); //food: Asian cusine -- hometown: Detroit MI
            names.Add("Joshua Carolin"); //food: Nalesniki -- hometown: Northville MI
            names.Add("Sean Boatman"); //food: MEAT! -- hometown: Eaton Rapids MI
            names.Add("Kate Datema"); //food: Pizza -- hometown: Zeeland MI
            names.Add("James Moulton"); //food: sushi -- Hometown: Toledo OH

            int index = int.Parse(input);
            string name = names[index];

            if (name == names[index])
            {
                string fullname = names[index];
                Console.WriteLine("Full name is: " + fullname);
                FoodIndex(index.ToString());
            }
        }

        public static void FoodIndex(string input)
        {
            //list of favorite foods
            //index number is same as Name and hometown
            List<string> foods = new List<string>();
            foods.Add("Cilantro");
            foods.Add("Sushi");
            foods.Add("Chicken Curry");
            foods.Add("Movie Theater Popcorn");
            foods.Add("Italian Cusine");
            foods.Add("Tacos");
            foods.Add("Broccoli");
            foods.Add("Asian Cusine");
            foods.Add("Nalesniki");
            foods.Add("MEAT!");
            foods.Add("Pizza");
            foods.Add("Sushi");

            int index = int.Parse(input);
            string food = foods[index];

            if (food == foods[index])
            {
                string favoriteFood = foods[index];
                Console.WriteLine("Favorite food is: " + favoriteFood);
                HometownIndex(index.ToString());
            }
        }

        public static void HometownIndex(string input)
        {
            //list of hometowns
            //index is same/related to name and food
            List<string> hometown = new List<string>();
            hometown.Add("Grand Rapids, MI");
            hometown.Add("GrayLake, MI");
            hometown.Add("Raleigh, NC");
            hometown.Add("Montrose MI");
            hometown.Add("Milwaukee, WI");
            hometown.Add("Rochester, MI");
            hometown.Add("Indian River, MI");
            hometown.Add("Detroit, MI");
            hometown.Add("Northville MI");
            hometown.Add("Eaton Rapids, MI");
            hometown.Add("ZeeLand, MI");
            hometown.Add("Toledo, OH");

            int index = int.Parse(input);
            string home = hometown[index];

            if (home == hometown[index])
            {
                string ht = hometown[index];
                Console.WriteLine("Hometown is: " + ht);
                
            }
        }

        public static bool PickAgain()
        {
            Console.WriteLine("Would you like to learn about another person?");
            string input = Console.ReadLine().ToLower();

            if(input == "y" || input == "yes")
            {
                Console.Clear();
                return true;
            }
            else if(input == "n" || input == "no")
            {
                Console.WriteLine("Goodbye");
                return false;
            }
            else
            {
                Console.WriteLine("Please enter yes or no");
                return PickAgain();
            }
        }
    }

    

    
}
