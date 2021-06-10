using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Lab8___Student_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            //Student object list
            List<Student> StudentInfo = new List<Student>();
            StudentInfo.Add(new Student("Mark Haines", "Grand Rapids, MI", "Cilantro"));
            StudentInfo.Add(new Student("Andrew Klima", "Grayslake, MI", "Sushi"));
            StudentInfo.Add(new Student("Tommy Waalkes", "Raleigh, NC", "Chicken Curry"));
            StudentInfo.Add(new Student("Maggie Tamanini", "Montrose, MI", "Movie Theater Popcorn"));
            StudentInfo.Add(new Student("Jerome Brown", "Milwaukee, WI", "Italian cusine"));
            StudentInfo.Add(new Student("Trent Nedbal", "Rochester MI", "Tacos"));
            StudentInfo.Add(new Student("Troy Vizina", "Indian River, MI", "Broccoli"));
            StudentInfo.Add(new Student("Kevin Jackson II", "Detroit, MI", "Asian cusine"));
            StudentInfo.Add(new Student("Josh Carolin", "Northville MI", "Nalesniki"));
            StudentInfo.Add(new Student("Kate Datema", "Zeeland, MI", "Pizza"));
            StudentInfo.Add(new Student("James Moulton", "Toledo, OH", "Sushi"));

            MainMenu(StudentInfo);
         

           


        }
        public static void MainMenu(List<Student> StudentInfo)
        {
            Console.WriteLine("Would you like to see the Student list or Add a new Student");
            Console.WriteLine("0) See student list");
            Console.WriteLine("1) Add new Student \n");

            string input = GetUserInput("Please select an option");
            if (input == "0" || input == "see student list")
            {
                //call student information list
                StudentList(StudentInfo);
            }
            else if (input == "1" || input == "add a new student")
            {
                //call ad new student
                Console.WriteLine("--Adding a new student--");
                AddStudent(StudentInfo);

            }
            else
            {
                Console.WriteLine("that is not an option");
                GetUserInput("Please select an option provided");
            }

        }

        public static void StudentList(List<Student> StudentInfo)
        {
            //print out list of all student objects by name
            Console.WriteLine("--Student List--");
            for(int i = 0; i < StudentInfo.Count; i++)
            {
                Student stud = StudentInfo[i];
                Console.WriteLine($"{i} : {stud.Name}");
            }

            string input = GetUserInput("Would you like to Learn more about a person? (y/n)");
            if (input == "yes" || input == "y")
            {
                DisplayAdditionInto(StudentInfo);
            }
            else if (input == "n" || input == "no")
            {
                Console.Clear();
                MainMenu(StudentInfo);
            }
        }

        public static void DisplayAdditionInto(List<Student> StudentInfo)
        {
            Console.WriteLine("Please select the index of the student you want to learn more about");
            string input = Console.ReadLine();
            try
            {
                int index = int.Parse(input);
                
                for(int i = 0; i < StudentInfo.Count; i++)
                {
                    Student stud = StudentInfo[i];
                    if (index == i)
                    {
                        Console.WriteLine($"Favorite food is: {stud.FavoriteFood}");
                        Console.WriteLine($"Hometown is: {stud.Hometown}");
                        Console.ReadLine();
                        MainMenu(StudentInfo);
                    }

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please select the index of the student you want to learn more about");
                DisplayAdditionInto(StudentInfo);
            }

        }

        public static void DisplayStudentList()
        {
            //relative file path -- file is in bin folder
            string filePath = "StudentInfo.txt";
            //stream reader object -- will read file
            StreamReader reader = new StreamReader(filePath);
            //read file until end of file
            string output = reader.ReadToEnd();
            Console.WriteLine(output);

            //split lines of file when new line starts, then store those new lines in and array
            string[] lines = output.Split("\n");
            //create a list of student objects
            List<Student> studentInfo = new List<Student>();

            //convert each line into a Student object 
            foreach (string line in lines)
            {
                Student stud = ConvertToStudent(line);
                if (stud != null)
                {
                    //add new converted student object to List of Students
                    studentInfo.Add(stud);
                }
            }
            reader.Close();
        }

        public static void AddStudent(List<Student> StudentInfo)
        {
            //access to file path -- working with this file
            string filePath = "StudentInfo.txt";

            //create a new student object
            Student s = new Student();

            //ask user for information
            Console.WriteLine("Please enter student name: ");
            s.Name = Console.ReadLine();

            Console.WriteLine("Please enter Hometown:");
            s.Hometown = Console.ReadLine();

            Console.WriteLine("Please enter Favoite food:");
            s.FavoriteFood = Console.ReadLine();

            //convert Student object to string format
            string line = StudentToString(s);
            StudentInfo.Add(s);
            Console.Write($"{line} has been added to StudentInfo list");

            //read file
            StreamReader reader = new StreamReader(filePath);
            //make copy of original txt file
            string original = reader.ReadToEnd();
            reader.Close();

            //write new info to existing file
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(original + line);
            writer.Close();
            

        }

        public static string StudentToString(Student s)
        {
            string output = $"{s.Name}, {s.Hometown}, {s.FavoriteFood}";
            return output;
        }

        public static Student ConvertToStudent(string line)
        {
            //split the line at every comma and store it into a string array
            string[] properties = line.Split(',');
            //create a new student object
            Student s = new Student();

            //check it new string has 3 words
            if (properties.Length == 3)
            {
                //store the name as the name property from index 0
                s.Name = properties[0];
                //store the hometown as the hometown property from index 1
                s.Hometown = properties[1];
                //store the favorite food as the favorite food property from index 2
                s.FavoriteFood = properties[2];
                //return new object with properties
                return s;
            }
            else
            {
                //return empty object
                return s;
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine().ToLower().Trim();

            if (userInput == "0" || userInput == "1")
            {
                return userInput;
            }
            else if (userInput == "y" || userInput == "yes")
            {
                return userInput;
            }
            else if (userInput == "n" || userInput == "no")
            {
                return userInput;
            }
            else
            {
                return GetUserInput("Please select an option provided");
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
