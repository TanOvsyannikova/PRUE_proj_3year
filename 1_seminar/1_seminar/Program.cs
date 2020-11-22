using System;

namespace _1_seminar
{
    public class Man
    {
        protected string _name;
        protected int _age;

        public Man(string name, int age)
        {
            SetName(name);
            SetAge(age);
            GetAge();
            GetName();
        }

        public string GetName() { return _name; }
        public int GetAge() { return _age; }
        public void SetName(string name)
        {
            if (name != "") { this._name = name; }
            else throw new Exception("no name");
        }
        public virtual void SetAge(int age) { this._age = age; }

        public override string ToString() { return "Человек, " + _name + ", " + _age;}
     }


    public class Teenager : Man
    {
        protected string _school;

        public Teenager( string name, int age, string sch) : base(name, age)
        {
            _school = sch;
        }

        public override void SetAge(int age)
        {
            if ((age < 13) || (age > 19)) {throw new Exception();}
            else this._age = age;
        }

        public override string ToString()
        {
            return string.Format("Подросток, {0}, {1}, Место учебы: {2}",
                                  this._name, this._age, this._school);
        }

    }

    public class Worker : Man
    {
        protected string _work_place;

        public Worker(string name, int age, string work_pl) : base(name, age)
        {
           _work_place = work_pl;
        }

        public override void SetAge(int a)
        {
            if ((a < 16) || (a > 70)) { throw new Exception(); }
            else this._age = a;
        }

        public override string ToString()
        {
            return string.Format("Работник, {0}, {1}, Место работы: {2}",
                                  this._name, this._age, this._work_place);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Man m = new Man("Vasya", 40);
            //Man m2 = new Man("", 20);
            Console.WriteLine(m.ToString());

            Teenager t = new Teenager("Petya", 16, "superSchool");
            //Teenager t2 = new Teenager("Andrew", 20, "supeSchool");
            Console.WriteLine(t.ToString());

            Worker w = new Worker("Kirill", 46, "PRUE");
            Console.WriteLine(w.ToString());

        }
    }


}