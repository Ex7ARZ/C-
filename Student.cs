
using System;

namespace LAB3
{
    
    public enum Course
    {
        Entrant,
        First,
        Second,
        Third,
        Fourth
    };

    public abstract class Student:    Human
    {
       
        protected string Uneversity;
        
        private Course S;
   
        public Student(int age, int height, int weight, string name, string country, string sex,int course,string un ) : base(age, height, weight, name, country, sex)
   {
       S = (Course) course;
       Uneversity = un;
   }

        public virtual void GoStudy()
        {
            Console.WriteLine("I am studying!");
        }
   public string Study() => $"{Uneversity}  {S} Course \n";
   public abstract string MyMarks();
    }
    
}