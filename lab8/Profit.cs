namespace LAB3
{
    public interface IProfit
    {
        string StudyForm { get; set; }
        double ScholarShip { get; set; }
        bool IsScholarship();
        void Set_Scolarship(double a = 0);
        void Info();
    }


    public interface IComparable<in T>

    {
        int CompareTo(T other);
    }
}