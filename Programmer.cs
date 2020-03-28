using System;

namespace LAB3
{
    
    public class Programmer:Student
    {
        Random rand=new Random();

        private struct Marks
        {
            public static int HighMath,English,Java,Python;
            
        }

        public Programmer(int age, int height, int weight, string name, string country, string sex, int course, string un) : base(age, height, weight, name, country, sex, course, un)
        {
            Marks.HighMath = rand.Next() % 101;
            Marks.English=rand.Next() % 101;
            Marks.Java=rand.Next() % 101;
            Marks.Python=rand.Next() % 101;
        }
        
        public override void GoStudy()
        {
            Console.WriteLine("I am studying programming !");
            Marks.HighMath = rand.Next() % 101;
            Marks.English=rand.Next() % 101;
            Marks.Java=rand.Next() % 101;
            Marks.Python=rand.Next() % 101;
        }

        public override string MyMarks() =>
            $"HighMath ={Marks.HighMath} \n English={Marks.English} \n Java={Marks.Java} \n Python={Marks.Python} \n ";
    }
            
}