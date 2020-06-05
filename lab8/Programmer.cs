using System;

namespace LAB3
{
    struct Marks
    {
        public int HighMath, English, Java, Python;
    }

    public class Programmer : Student, IComparable<Programmer> 
    {
        public delegate void StudyMessage(string message);

        public delegate int Minus(int a);

        public event StudyMessage Mes;

        public delegate void AccountHandler(int sum, string message);

        public event AccountHandler Notify;
        private int _wallet = 10;
        public int Wallet
        {
            get => _wallet;
            set => _wallet = value;
        }

        public void SetMoney(int sum)
        {
            
            
                if (sum > 0) Notify?.Invoke(sum, $"На счет поступило: {sum}");
                else Console.WriteLine(" u can input only positive sum! ");
            
            
        }

        public void Chill(int sum, Minus func)
        {
            if (Wallet >= sum)
            {
                Notify?.Invoke(func(sum), $"Со счета снято: {sum},приятного отдыха!");
            }
            else Notify?.Invoke(sum, $"Недостаточно денег на счете. Текущий баланс: {Wallet}");
        }

        Random rand = new Random();


        private Marks _marks;

        public Programmer(int age, int height, int weight, string name,
            string country, string sex, Course course, string un, string stscolarshhip) : base(age, height, weight,
            name, country, sex,
            course, un)
        {
            StudyForm = stscolarshhip;
            Srmark = 0;
            _marks.HighMath = rand.Next() % 101;
            _marks.English = rand.Next() % 101;
            _marks.Java = rand.Next() % 101;
            _marks.Python = rand.Next() % 101;
        }

        public override void GoStudy()
        {
            //  Console.WriteLine("I am studying programming !");
            Mes?.Invoke("I am studying programming !");
            _marks.HighMath = rand.Next() % 101;
            _marks.English = rand.Next() % 101;
            _marks.Java = rand.Next() % 101;
            _marks.Python = rand.Next() % 101;
            SetSr();
        }

        public override string GetMyMarks() =>
            $"HighMath ={_marks.HighMath} \n English={_marks.English} \n Java={_marks.Java} \n Python={_marks.Python} \n ";

        public sealed override string StudyForm { get; set; }

        public override bool IsScholarship()
        {
            //StudyForm = StudyF;
            return StudyForm == "Free";
        }

        public override void Set_Scolarship(double a = 0)
        {
            
                if (a >= 0) ScholarShip = a;
                else Console.WriteLine(" u can input only positive sum! ");
            
            
        }

        public override void Info()
        {
            Console.WriteLine($" \n Form of study:{StudyForm}\nScholarship:{ScholarShip} \n    ");
        }

        public override void SetSr()
        {
            // ReSharper disable once PossibleLossOfFraction
            Srmark = (_marks.HighMath + _marks.English + _marks.Java + _marks.Python) / 4;
        }

        public double Srmark { get; private set; }

        public delegate double Coef(double a, double b);

        public void DelScholarship(Coef func, double a, double b)
        {
            Set_Scolarship(ScholarShip * func(a, b));
        }

        public int CompareTo(Programmer other)
        {
            return this.Srmark.CompareTo(other.Srmark);
        }
    }
}