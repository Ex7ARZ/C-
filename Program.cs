using System;
using LAB3;

public class Human
{
    private static int _id;
    private readonly string _sex;
    private int _height;
    private int _weight;

    public Human(int age, int height, int weight, string name, string country, string sex)
    {
        if (age > 0) Age = age;
        if (height > 0) _height = height;
        if (weight > 0) _weight = weight;
        Name = name;
        Country = country;
        _sex = sex;
        _id++;
    }

    public string Name { get; }

    public string Country { get; }

    public int Age { get; private set; }

    public string HumanStats()
    {
        return
            $"Name:{Name} \n Sex:{_sex} \n Height:{_height} cm \n Weight={_weight} kg \n Age={Age} ya \n Country:{Country} \n id={_id}";
    }
   public string RetName()=>Name;
   public int RetId() => _id;
   public string RetCountry() => Country;
    public void HumanStats(int height, int weight, int age)
    {
        _height = height;
        _weight = weight;
        Age = age;
    }
}

 class Humanity
 {
   
   Student Programmers=new Programmer(20,180,80,"John","USA","man",3,"BSUIR");
    public unsafe void MenuStart()
    {
        var m = true;
        while (m)
        {
            Console.Write("change-1\nshow human-2\nend program-3\n new-4\n go study -5\n show university-6\n");
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
                    Console.WriteLine(Programmers.HumanStats());
                    break;
                case 3:
                    m = false;
                    break;
                case 4:
                    
                    break;
                 case 5:
                      Programmers.GoStudy();
                      break;
                  case 6:
                      Console.Clear();
                      Console.WriteLine(Programmers.Study());
                      Console.WriteLine(Programmers.MyMarks());
                      Console.Write("\n");
                      break;
            }
        }
       
    }

    public void ChooseOne()
    {
        int n = Console.Read();
        Console.Clear();
        Console.WriteLine("1-name \n 2-country\n3-persinal id");
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

namespace LAB3
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            var first = new Humanity();
            first.MenuStart();
        }
    }
}
