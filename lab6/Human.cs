namespace LAB3
{
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
        public void HumanStats(int height, int weight, int age)
        {
            _height = height;
            _weight = weight;
            Age = age;
        }
    }
}