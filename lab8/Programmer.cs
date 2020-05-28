using System;

namespace LAB3
{
     struct Marks
    {
        public  int HighMath,English,Java,Python;
            
    } 
    public class Programmer:Student,ICompare
    {
        public delegate void StudyMessage(string message);
        
        public delegate int Minus(int a);
        public event StudyMessage Mes;
        public delegate void AccountHandler(int sum ,string message);
        public event AccountHandler Notify; 
        public int Wallet
        {
            get => wallet;
            set => wallet = value;
        }

        public void SetMoney(int sum)
        {
            try
            {
                if (sum > 0) Notify?.Invoke(sum, $"На счет поступило: {sum}");
                else throw new Exception(" u can input only positive sum! ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
               
            }
          
        }

        public void Chill(int sum,Minus func)
        {
            
            if (Wallet >= sum)
            {
                
                Notify?.Invoke(func(sum),$"Со счета снято: {sum},приятного отдыха!");
            }
            else  Notify?.Invoke(sum,$"Недостаточно денег на счете. Текущий баланс: {Wallet}");
        }
       
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
          //  Console.WriteLine("I am studying programming !");
          Mes?.Invoke("I am studying programming !");
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

        public override void Set_Scolarship(double a = 0)
        {
           
            
            try
            {
                if (a > 0)ScholarShip = a;
                else throw new Exception(" u can input only positive sum! ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.Message}");
               
            }
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
        public delegate double  Coef(double a,double b);
        public void DelScholarship(Coef func,double a,double b )
        {
            Set_Scolarship(ScholarShip * func(a,b));
        }
    }
   
    
}