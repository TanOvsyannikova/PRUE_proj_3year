/*
 1) Класс - элемент массива (ArrEl), имеет свойства name:string и val:int 
Реализовать массив ArrEl с доступом к элементам как по индексу элемента,
так и по имени элемента (два индексатора) 

2) Реализовать с использованием модификатора params метод подсчета суммы элементов, переданных в метод 

3) При помощи ref реализовать метод обмена двух переданных ему в виде параметров int'ов 

4) Метод подсчета периметра и площади четырехугольника по переданным четырем парам координат.
При помощи out реализовать возврат из этого метода рассчитанных значений.
Метод возвращает false, если площади нет (например ошибка в координатах)
 */

using System;

namespace homework1
{
    internal static class Constants
    {
        public const int ArraySize = 5;

    }

    //класс элемент массива
    class ArrEl
    {
        private string name;
        private int val;

        public string Name { get; set; }
        public virtual int Val { get; set; }

        public override string ToString()
        {
            return Name + ", " + Val;
        }
    }

    //класс массив
    class Arr
    {
        public Arr()
        {
            Data = new ArrEl[Constants.ArraySize];
        }
        // индексатор1
        public ArrEl this[int ind]
        {
            set
            {
                Data[ind] = value;
            }
            get
            {
                return Data[ind];
            }
        }
        //индексатор2
        public ArrEl this[string info]
        {

            get
            {
                ArrEl element = null;
                foreach (var el in Data)
                {
                    if (el.Name == info)
                    {
                        element = el;
                        break;
                    }
                }
                return element;

            }
        }

        private ArrEl[] Data { get; set; }


    }


    class Figure
    {
        protected double x1, y1, x2, y2, x3, y3, x4, y4;


        public static void Find_perim(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, out double perim, out bool perim_flag)
        {
            // проверка, что 4угольник не самопересекается (никакие 3 точки не лежат на 1 прямой)
            //я знаю про деление на 0(
            if (((x3 - x1) / (x2 - x1) != (y3 - y1) / (y2 - y1)) && ((x4 - x1) / (x2 - x1) != (y4 - y1) / (y2 - y1))
                && ((x4 - x1) / (x3 - x1) != (y4 - y1) / (y3 - y1)) && ((x4 - x2) / (x3 - x2) != (y4 - y2) / (y3 - y2)))
            {
                double first_side = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                double second_side = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                double third_side = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));
                double fourth_side = Math.Sqrt(Math.Pow(x4 - x1, 2) + Math.Pow(y4 - y1, 2));

                perim = first_side + second_side + third_side + fourth_side;
                perim_flag = true;
            }

            else
            {
                perim_flag = false;
                perim = 0;
            }
        }

        public static void Find_area(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, out double area, out bool area_flag)
        {
            // проверка, что 4угольник не самопересекается (никакие 3 точки не лежат на 1 прямой)
            //я знаю про деление на 0( но не знаю как проверить иначе
            if (((x3 - x1) / (x2 - x1) != (y3 - y1) / (y2 - y1)) && ((x4 - x1) / (x2 - x1) != (y4 - y1) / (y2 - y1))
                && ((x4 - x1) / (x3 - x1) != (y4 - y1) / (y3 - y1)) && ((x4 - x2) / (x3 - x2) != (y4 - y2) / (y3 - y2)))
            {
                //shoelace formula https://ru.wikipedia.org/wiki/Формула_площади_Гаусса
                area = Math.Abs(0.5 * (x1 * y2 + x2 * y3 + x3 * y4 + x4 * y1 - x2 * y1 - x3 * y2 - x4 * y3 - x1 * y4));
                area_flag = true;
            }

            else
            {
                area_flag = false;
                area = 0;
            }
        }
    }

    class Program
    {
        static int Addition(params int[] vals)
        {
            int result = 0;
            for (int i = 0; i < vals.Length; i++)
            {
                result += vals[i];

            }
            return result;
        }

        static void SwapRef(ref ArrEl first, ref ArrEl second)
        {
            int temp = 0;
            temp = first.Val;
            first.Val = second.Val;
            second.Val = temp;
        }




        static void Main(string[] args)
        {
            Arr MyArray = new Arr();

            ArrEl first = new ArrEl { Name = "first_param", Val = 678 };
            MyArray[0] = first;

            ArrEl second = new ArrEl { Name = "second_param", Val = 78 };
            MyArray[1] = second;

            ArrEl third = new ArrEl { Name = "third_param", Val = 89 };
            MyArray[2] = third;

            ArrEl forth = new ArrEl { Name = "fourth_param", Val = 333 };
            MyArray[3] = forth;

            ArrEl fifth = new ArrEl { Name = "fifth_param", Val = 689 };
            MyArray[4] = fifth;



            //task1
            Console.WriteLine(MyArray[3]); // output: forth_param, 333
            // Console.WriteLine(MyArray[78]); //exception
            Console.WriteLine(MyArray["first_param"]);
            Console.WriteLine(MyArray["hj"]); //null

            //task2
            Console.WriteLine("- - - - - - - - - - - -");
            Console.WriteLine(Addition(first.Val, MyArray[1].Val, MyArray[2].Val, MyArray[3].Val, MyArray[4].Val));
            int[] IntArray = { 2, 5, 7, 8 };
            Console.WriteLine(Addition(IntArray));

            //task 3
            Console.WriteLine("- - - - - - - - - - - -");
            Console.WriteLine("Before swap:\n");


            for (int i = 0; i < Constants.ArraySize; i++) { Console.WriteLine(MyArray[i]); }
            SwapRef(ref first, ref second);
            Console.WriteLine("");
            Console.WriteLine("After swap:\n");
            for (int i = 0; i < Constants.ArraySize; i++) { Console.WriteLine(MyArray[i]); }

            //task 4
            Console.WriteLine("- - - - - - - - - - - -");
            //ввод координат
            Console.WriteLine("Пожалуйста, вводите координаты только по/против часовой стрелки, иначе все поломается(( ");

            Console.Write("x1: ");
            double x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y1: ");
            double y1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("x2: ");
            double x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y2: ");
            double y2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("x3: ");
            double x3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y3: ");
            double y3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("x4: ");
            double x4 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y4: ");
            double y4 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Perimeter \n");

            Figure.Find_perim(x1, y1, x2, y2, x3, y3, x4, y4, out double perim, out bool perim_flag);

            if (perim_flag) { Console.WriteLine(perim); }
            else { Console.WriteLine("there's something wrong... check whether it is a quadrangle at all"); }

            Console.Write("Area ");

            Figure.Find_area(x1, y1, x2, y2, x3, y3, x4, y4, out double area, out bool area_flag);

            if (area_flag) { Console.WriteLine(area); }
            else { Console.WriteLine("there's something wrong... check whether it is a quadrangle at all"); }
        }



    }



}
