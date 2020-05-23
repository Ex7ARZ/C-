using System;

namespace LAB3
{
     struct Marks
    {
        public  int HighMath,English,Java,Python;
            
    } 
    public class Programmer:Student,ICompare
    {
      

       
        Random rand=new Random();

       
       private Marks _marks;
        public Programmer(int age, int height, int weight, string name, 
            string country, string sex, Course course, string un) : base(age, height, weight, name, country, sex, course, un)
        {
            _marks.HighMath = rand.Next() % 101;
            _marks.English=rand.Next() % 101;
            _marks.Java=rand.Next() % 101;
            _marks.Python=rand.Next() % 101;
        }
        
        public override void GoStudy()
        {
            Console.WriteLine("I am studying programming !");
            _marks.HighMath = rand.Next() % 101;
            _marks.English=rand.Next() % 101;
            _marks.Java=rand.Next() % 101;
            _marks.Python=rand.Next() % 101;
        }

        public override string GetMyMarks() =>
            $"HighMath ={_marks.HighMath} \n English={_marks.English} \n Java={_marks.Java} \n Python={_marks.Python} \n ";

        public sealed override string StudyForm { get; set; }=" Unknown";
        public override bool IsScholarship(string StudyF)
        {
            StudyForm = StudyF;
            return StudyForm == "Free";
        }

        public override void Set_Scolarship(int a = 0)
        {
            ScholarShip = a;
        }

        public override void Info()
        {
           Console.WriteLine($" \n Form of study:{StudyForm}\nScholarship:{ScholarShip} \n    ");
        }

       public override double GetSr()
        {
            
            // ReSharper disable once PossibleLossOfFraction
            return (_marks.HighMath + _marks.English + _marks.Java + _marks.Python) / 4;
            
        }
        public override int CompareTo(double a,double b)
        {
            if (a < b) return 1;
                else if ((int) a == (int) b) return 0;
            else return -1;
        }

        public override void Change(int a)
        {
            switch (a)
            {
                case 1:Console.WriteLine("student study better  middle results");
                    break;
                    case 0:Console.WriteLine("student study neither good nor  bad");
                        break;
                    case -1:Console.WriteLine("student study worse middle results ");
                        break;
            }
        }
    }


    
}