/*
 1) Создать класс Triple, содержащий три поля: Int32, String, Boolean. 
 Определить конструктор Triple(Int32, String, Boolean). 
 Определить оператор + 
 Переопределить метод ToString 
 
 Triple t1 = new Triple(1, "abc", true); 
 Triple t2 = new Triple(2, "def", false); 
 Triple t3 = t1 + t2; 
 Console.WriteLine(t3); 
 
2) Для (1) определить методы явного приведения к Int32, String, и неявного приведения к Boolean 
 Triple t1 = ...; 
 String s = (String)t1; 
 Boolean b = t1; 
 
3) Для (1) определить операторы: -, /, *, ==, != 
 
4) Сделать метод-расширитель для типа String, Int32 и Boolean, для приведения типа Triple к String, Int32 и Boolean через явный вызов метода-расширителя 
 Triple t1 = 10.ToTriple(); 
 Triple t2 = "abc".ToTriple(); 
 Triple t3 = false.ToTriple();
 */





using System;

namespace seminar2
{
    class Triple
    {
        private int i;
        private string st;
        private bool b;

        public Triple(int i, string st, bool b)
        {
            this.i = i;
            this.st = st;
            this.b = b;
        }

        public static Triple operator +(Triple t1, Triple t2)
        {
            int sum_int = t1.i + t2.i;
            string sum_st = t1.st + t2.st;
            bool sum_bool = t1.b || t2.b;
            return new Triple(sum_int, sum_st, sum_bool);
        }

        public override string ToString()
        {
            return $"{i}, {st}, {b}";
        }

        public static Triple operator -(Triple t1, Triple t2)
        {
            int sub_int = t1.i - t2.i;
            string sub_st = "";
            bool sub_bool = t1.b;
            return new Triple(sub_int, sub_st, sub_bool);
        }

        public static Triple operator *(Triple t1, Triple t2)
        {
            int mul_int = t1.i * t2.i;
            string mul_string = "";
            bool mul_bool = t1.b && t2.b;
            return new Triple(mul_int, mul_string, mul_bool);
        }

        public static Triple operator /(Triple t1, Triple t2)
        {
            int div_int = t1.i / t2.i;
            string div_st = "";
            bool div_bool = t1.b;
            return new Triple(div_int, div_st, div_bool);
        }

        public static bool operator ==(Triple m1, Triple m2)
        {
            return m1.i == m2.i && m1.st == m2.st && m1.b == m2.b;
        }


        public static bool operator !=(Triple m1, Triple m2)
        {
            return !(m1 == m2);
        }



        public static explicit operator int(Triple t)
        {
            return t.i;
        }

        public static explicit operator string(Triple t)
        {
            return t.st;
        }

        public static implicit operator bool(Triple t)
        {
            return t.b;
        }

    }

    static class MyExtention
    {
        public static Triple ToTriple(this int i)
        {
            return new Triple(i, "null", false);
        }

        public static Triple ToTriple(this string st)
        {
            return new Triple(0, st, false);
        }

        public static Triple ToTriple(this bool b)
        {
            return new Triple(0, "null", b);
        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            //task1
            Triple t1 = new Triple(1, "abc", true);
            Triple t2 = new Triple(2, "def", false);
            Triple t3 = t1 + t2;
            Console.WriteLine(t3.ToString());

            //task2
            int i = (int)t1;
            String s = (String)t1;
            Boolean b = t1;

            t1 = 10.ToTriple();
            t2 = "abc".ToTriple();
            t3 = false.ToTriple();

            Console.WriteLine(t1.ToString(), t2.ToString(), t3.ToString());
        }
    }
}

