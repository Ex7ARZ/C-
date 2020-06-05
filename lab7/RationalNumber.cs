#nullable enable
using System;
using System.Numerics;

namespace Lab7
{
    public class RationalNumber : IComparable
    {
        private int _m;
        private int _n;

        public RationalNumber(int n, int m)
        {
            _n = n;
            _m = (m > 0) ? m : 1;
        }

        public int N => _n;

        public int M => _m;

        public static RationalNumber operator +(RationalNumber a, RationalNumber b) //перекрытие мат операций
        {
            RationalNumber result = new RationalNumber(1, 1);

            if (a._m != b._m)
            {
                result._m = a._m * b._m;
                result._n = a._m * b._n + a._n * b._m;
            }
            else
            {
                result._m = a._m;
                result._n = a._n + b._n;
            }

            return result;
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber(1, 1);

            if (a._m != b._m)
                return a._m * b._n > a._n * b._m;
            else return a._n > b._n;
        }

        public static bool operator <(RationalNumber a, RationalNumber b)
        {
            RationalNumber result = new RationalNumber(1, 1);

            if (a._m != b._m)
                return a._m * b._n < a._n * b._m;
            else return a._n < b._n;
        }

        public override string ToString() //перевод объекта в строку
        {
            return string.Format("{0}/{1} ", _n, _m);
        }

        public int CompareTo(object? obj) //сравнения для сортировки
        {
            RationalNumber p = obj as RationalNumber;
            if (p != null)

                return (this._n / this._m).CompareTo(p._n / p._m);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public static explicit operator double(RationalNumber obj) //перекрытия явного приведения типов
        {
            return (double) obj._n / obj._m;
        }

        public static explicit operator int(RationalNumber obj)
        {
            return obj._n / obj._m;
        }


        public static RationalNumber Parse(string s) //из строки в объект
        {
            var num = double.Parse(s);
            // var num = Convert.ToDouble(s);
            var counter = 0;
            while (num > (int) num)
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
            var a = new RationalNumber((int) first, (int) second);
            return a;
        }
    }
}