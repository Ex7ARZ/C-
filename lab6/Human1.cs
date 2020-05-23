namespace LAB3
{
    public class Human1
    {
        private static int _id;
        private readonly string _sex;
        private int _height;
        private int _weight;

        protected Human1(int age, int height, int weight, string name, string country, string sex)
        {
            if (age > 0) Age = age;
            if (height > 0) _height = height;
            if (weight > 0) _weight = weight;
            Name = name;
            Country = country;
            _sex = sex;
            _id++;
        }

        private string Name { get; }

        private string Country { get; }

        private int Age { get; set; }

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
}