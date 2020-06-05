using System;

namespace LAB3
{
    class Humanity
    {
        static Programmer Programmers = new Programmer(20, 180, 80, "John", "USA",
            "man", (Course) 1, "BSUIR", "Free");

        static Programmer Programmers2 = new Programmer(23, 170, 68, "Andy", "Finland",
            "man", (Course) 3, "BSUIR", "Paid");

        private IProfit _stprofit = Programmers;

        private IComparable<Programmer> _comparable = Programmers;

        public void MenuStart()
        {
            Programmers.Notify += delegate(int sum, string mes)
            {
                Programmers.Wallet += sum;
                Console.WriteLine(mes);
            };
            Programmers.Mes += mes => Console.WriteLine(mes);

            var m = true;
            while (m)
            {
                Console.Write(
                    "\nchange-1\nshow human-2\nend program-3\n course-4\n go study -5\n show university-6\ninfo about study-7\nwallet-8\ninput money-9\nchill-10\n");
                try
                {
                    var s = Console.ReadLine();
                

                     var index = int.Parse(s);
                     
                
            switch (index)
                {
                    case 1:
                    {
                        Console.WriteLine(Programmers.HumanStats());
                        break;
                    }
                    case 2:
                        Console.WriteLine(Programmers.HumanStats());

                        break;
                    case 3:
                        m = false;
                        break;
                    case 4:
                    {
                        s = Console.ReadLine();
                        // var n = Console.Read();
                        var n = int.Parse(s);
                        Programmers.ChangeCourse((Course) n);
                        break;
                    }
                    case 5:
                        Programmers.GoStudy();
                        Programmers2.GoStudy();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine(Programmers.Study());

                        Console.WriteLine(Programmers.GetMyMarks());
                        Console.Write("\n");
                        _stprofit.Info();
                        Console.Write("\n");
                        break;
                    case 7:


                        if (_stprofit.IsScholarship())
                        {
                            var a = Console.Read();
                            _stprofit.Set_Scolarship(a);
                        }
                        else _stprofit.Set_Scolarship();

                        _stprofit.Info();

                        if (_comparable.CompareTo(Programmers2) == 1)
                            Console.WriteLine("John study better than Andy\n");
                        else if (_comparable.CompareTo(Programmers2) == 0)
                            Console.WriteLine("John study as well as Andy\n");
                        else if (_comparable.CompareTo(Programmers2) < 0)
                            Console.WriteLine("John study worse than Andy\n");

                        if(Programmers.Srmark>0)
                        Programmers.DelScholarship((a, b) => a / b, Programmers.Srmark, 50);
                           else throw new Exception("u didnt get marks");
                        Console.WriteLine($"your scholarship:{Programmers.ScholarShip}\n");
                        break;
                    case 8:
                        Console.Write($"you have:{Programmers.Wallet} $");
                        break;
                    case 9:
                        Console.Write("input sum of money:");
                        s = Console.ReadLine();
                        var q = int.Parse(s);
                        Programmers.SetMoney(q);
                        break;
                    case 10:
                        Console.Write("input sum of money to get:");
                        s = Console.ReadLine();
                        var z = int.Parse(s);
                        Programmers.Chill(z, a => a *= (-1));
                        break;
                    default: continue;
                }
            
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                
        }

        public void ChooseOne()
        {
            int n = Console.Read();
            Console.Clear();
            Console.WriteLine("1-name \n 2-country\n3-personal id");
            switch (n)
            {
                case 1:
                    Console.WriteLine(Programmers.RetName() + "\n");
                    break;
                case 2:
                    Console.WriteLine($"{Programmers.RetId()}\n");
                    break;
                case 3:
                    Console.WriteLine(Programmers.RetCountry() + "\n");
                    break;
            }
        }
    }
}