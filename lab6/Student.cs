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

    public abstract class Student : Human1, IProfit 
    {
        private readonly string _university;

        private Course _s;

        protected Student(int age, int height, int weight, string name,
            string country, string sex, Course course, string un)
            : base(age, height, weight, name, country, sex)
        {
            _s = course;
            _university = un;
        }

        public virtual void GoStudy()
        {
            Console.WriteLine("I am studying!");
        }

        public string Study() => $"{_university}  {_s} Course \n";
        public abstract string GetMyMarks();

        public void ChangeCourse(Course n)
        {
            _s = n;
        }

        public abstract void SetSr();

        //-------------------------------------------------------------------------------------------------------------
        public abstract string StudyForm { get; set; }
        public double ScholarShip { get; set; } = 0;


        public abstract bool IsScholarship();


        public abstract void Set_Scolarship(double a = 0);


        public abstract void Info();
        
    }
}