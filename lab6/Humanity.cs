using System;

namespace LAB3
{
    class Humanity
    {
        static Student Programmers=new Programmer(20,180,80,"John","USA",
            "man",(Course)1,"BSUIR");

        private IProfit _stprofit = Programmers;
        private ICompare _comparable =  Programmers;
        public void MenuStart()
        {
            var m = true;
            while (m)
            {
                Console.Write("\nchange-1\nshow human-2\nend program-3\n course-4\n go study -5\n show university-6\ninfo about study-7\n");
                var s = Console.ReadLine();
                var index = int.Parse(s);
            
                switch (index)
                {
                    case 1:
                    {
                        Console.WriteLine( Programmers.HumanStats());
                        break;
                    }
                    case 2:
                        Console.WriteLine(Programmers.HumanStats());
                       // Console.WriteLine(Programmers.HumanStats());
                        break;
                    case 3:
                        m = false;
                        break;
                    case 4:
                    {
                        s=Console.ReadLine();
                       // var n = Console.Read();
                       var n=int.Parse(s);
                        Programmers.ChangeCourse((Course)n);
                        break;
                    }
                    case 5:
                        Programmers.GoStudy();
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
                      Console.WriteLine("choose Free or Paid form:\n");
                        s=Console.ReadLine();
                      if(  _stprofit.IsScholarship(s))
                      {
                          var a = Console.Read();
                          _stprofit.Set_Scolarship(a);
                      }
                      else _stprofit.Set_Scolarship();
                      _stprofit.Info();
                      _comparable.Change(_comparable.CompareTo(50,Programmers.GetSr()));
                      
                      break;
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
                    Console.WriteLine(Programmers.RetName()+"\n");
                    break;
                case 2:
                    Console.WriteLine($"{Programmers.RetId()}\n");
                    break;
                case 3:
                    Console.WriteLine(Programmers.RetCountry()+"\n");
                    break;
                    
            }
        }
    }
}
