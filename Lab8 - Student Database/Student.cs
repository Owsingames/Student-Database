using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8___Student_Database
{
    class Student
    {
        public string Name { get; set; }
        public string Hometown { get; set; }
        public string FavoriteFood { get; set; }

        public Student()
        {

        }

        public Student(string Name, string Hometown, string FavoriteFood)
        {
            this.Name = Name;
            this.Hometown = Hometown;
            this.FavoriteFood = FavoriteFood;
        }
        
    }
}
