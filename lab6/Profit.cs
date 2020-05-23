namespace LAB3
{
    public interface IProfit
    {
        string StudyForm { get; set; }
        int  ScholarShip { get; set; }
        bool IsScholarship(string StudyF);
       void Set_Scolarship(int a=0);
        void Info();
    }
    
    public interface ICompare

    {

        int CompareTo(double a,double  b);
        void Change(int a);

    }
}