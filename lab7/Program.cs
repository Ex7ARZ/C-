using System;

namespace Lab7
{
   
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber num1=new RationalNumber(2,3);
            RationalNumber num2=new RationalNumber(3,4);
            RationalNumber num3 = num1 + num2;
           // Console.WriteLine(num3.N);
           // Console.WriteLine(num3.M);
           // Console.WriteLine(num3.ToString());           
          // double a = (double)num1;
          // int b = (int) num1;

          // Console.WriteLine($"{a};{b}");
          
 
          RationalNumber[] nums = new  RationalNumber[] { num1, num2, num3 };
          Array.Sort(nums);
 
          foreach(RationalNumber p in nums)
          {
              Console.WriteLine(p.ToString());
          }

           string s = "1,25";
         // var num4 = num1.ToObject(s);
         RationalNumber ss = (RationalNumber)s;
         Console.WriteLine(ss.ToString());  
        }
    }
}