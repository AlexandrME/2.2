using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._2
{

    class Line
    {
        private int _k = 0;
        private int _b = 0;
        private string _name = "";


        public Line(string name)
        {
            if (name.Length > 0)
            {
                _name = name;
            }
            else
                _name = "NoName";
        }

        static Line()
        {
            //Пустое тело 
        }

        //Метод 
        public void Print()
        {
            Console.WriteLine("Прямая{0}: y={1}x + {2}", _name, _k, _b);
        }

        //Свойства  
        public string Name
        {
            set { _name = Convert.ToString(value); }
            get { return _name; }
        }

        public int k
        {
            set { _k = Math.Abs(value); }
            get { return _k; }
        }

        public int b
        {
            set { _b = Math.Abs(value); }
            get { return _b; }
        }


        //Деструктор 
        ~Line()
        {
            Console.WriteLine("Объект удален!");
        }

        class StaticLine
        {
            public static void PrintList(List<Line> Lines)
            {
                foreach (Line line in Lines)
                    line.Print();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Random random = new Random();
                List<Line> lineList = new List<Line>
                 { 
                 //Заполним его анонимными экземплярами класса Human 
                 new Line("1") { k = random.Next(1, 80), b = random.Next(0, 90) }, 
                 new Line("2") { k = random.Next(1, 80), b = random.Next(0, 90) },
                 new Line("3") { k = random.Next(1, 80), b = random.Next(0, 90) }, 
                 new Line("4") { k = random.Next(1, 80), b = random.Next(0, 90) }, 
                 new Line("5") { k = random.Next(1, 80), b = random.Next(0, 90) },  

                 };
                Console.WriteLine("Список:");
                StaticLine.PrintList(lineList);
                Console.WriteLine("\nСписок в обратном порядке:"); 
                lineList.Reverse();
                StaticLine.PrintList(lineList);
                Console.WriteLine("\nСписок по угловому коэффециенту:");
                StaticLine.PrintList(lineList.OrderBy(k => k._k).ToList());

                lineList.Reverse();
                lineList.Add(new Line("6") { k = random.Next(1, 80), b = random.Next(0, 90) });
                Console.WriteLine("\nСписок с добавленным в конец элементом");
                StaticLine.PrintList(lineList);
                lineList.Insert(3, new Line("3.1") { k = random.Next(1, 180), b = random.Next(0, 90) });
                Console.WriteLine("\nСписок со вставленным элементом");
                StaticLine.PrintList(lineList);

                lineList.RemoveAt(3);
                Console.WriteLine("\nСписок с удаленным вставленным элементом");
                StaticLine.PrintList(lineList);

                int index = lineList.FindIndex(k => k.Name == "5");
                Console.WriteLine("\nНайденный элемент списка");
                lineList[index].Print();
                lineList.Clear();

                Console.WriteLine("\nПустой список");
                StaticLine.PrintList(lineList);
                Console.ReadKey();

            }
        }
    }
}


