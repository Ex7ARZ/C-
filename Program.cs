using System;

internal class Human
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

    public void HumanStats(int height, int weight, int age)
    {
        _height = height;
        _weight = weight;
        Age = age;
    }
}

internal class Humanity
{
    private readonly Human _people1 = new Human(1, 2, 3, "john", "5", "1");
    private readonly Human _people2 = new Human(8, 8, 3, "not john", "5", "1");

    public void MenuStart()
    {
        var m = true;
        while (m)
        {
            Console.Write("change-1\nshow human-2\nend program-3\n");
            var s = Console.ReadLine();
            var index = int.Parse(s);
            switch (index)
            {
                case 1:
                    _people1.HumanStats(20, 20, 20);
                    break;
                case 2:
                    Console.WriteLine(_people1.HumanStats());
                    Console.WriteLine(_people2.HumanStats());
                    break;
                case 3:
                    m = false;
                    break;
            }
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
//r3tt