#nullable enable
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Lab7
{
    public class RationalNumber: IComparer<RationalNumber>,IComparable
    {
        private int _m;
 
        public RationalNumber(int n, int m)
        {
            N = n;
            _m = (m > 0) ? m : 1;
        }
 
        public int N { get; set; }

        public int M
        {
            get => _m;
            set
            {
                if (value > 0)
                    _m = value;
                else
                    throw new Exception("Число должно быть натуральным!");
            }
        }
 
        public static RationalNumber operator +(RationalNumber a, RationalNumber b) //перекрытие мат операций
        {
            RationalNumber result = new RationalNumber(1, 1);

            if (a._m != b._m) 
            {
                result._m = a._m * b._m;
                result.N = a._m * b.N + a.N * b._m;
            }
            else
            {
                result._m = a._m;
                result.N =  a.N +  b.N;
            }

            return result;
        }
        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber(1, 1);

            if (a._m != b._m)
                return a._m * b.N > a.N * b._m;
            else return a.N > b.N;
            
        }
        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber(1, 1);

            if (a._m != b._m)
                return a._m * b.N < a.N * b._m;
            else return a.N < b.N;
        }

        public int Compare(RationalNumber x, RationalNumber y)//просто сравнение 2 объектов
        {
            if (x > y)
                return 1;
            else if (x < y)
                return -1;
            else
                return 0;
        }

        public override string ToString()//перевод объекта в строку
        {
            return string.Format("{0}/{1} ", N, _m);
            
        }

        public int CompareTo(object? obj)//сравнения для сортировки
        {
            RationalNumber p = obj as RationalNumber;
            if (p != null  )
               
                return (this.N /this._m).CompareTo(p.N /p._m);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }


     
        
        
        
        
        public static explicit operator double(RationalNumber obj)//перекрытия явного приведения типов
        {
            
            return  (double)obj.N / obj._m;
        }
        public static explicit operator int(RationalNumber obj)
        {
            
            return  obj.N / obj._m;
        }

      
        public static explicit operator RationalNumber(string s)//из строки в объект
        {
            
            var num = Convert.ToDouble(s);
            var counter = 0;
            while ( /*num % 1 != 0*/ num > (int) num)
            {
                num *= 10;
                counter++;
            }

            var first = new BigInteger(num);
            var second = new BigInteger(Math.Pow(10, counter));

            var m = first;
            var n = second;

            while (true)
            {
                var r = m % n;
                if (r == 0)
                {
                    break;
                }

                m = n;
                n = r;
            }

            var gcd = n;
            first /= gcd;
            second /= gcd;
            var a=new RationalNumber((int)first,(int)second);
            return a; 
        }
    }
}