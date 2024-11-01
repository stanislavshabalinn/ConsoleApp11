using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace ListAndLinkedList
{
    class Program 
    {

        private static List<string> MyList = new List<string>();
        public static LinkedList<string> MyLinkedList = new LinkedList<string>();

        static void Main(string[] args)
        {
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText("https://lms-cdn.skillfactory.ru/assets/courseware/v1/dc9cf029ae4d0ae3ab9e490ef767588f/asset-v1:SkillFactory+CDEV+2021+type@asset+block/Text1.txt");

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            //Console.WriteLine(words.Length);

            // Запустим таймер для List<T> ****************************************************************************
            var watchTwo1 = Stopwatch.StartNew();

            // Выполним вставку

            foreach (var c in words)
            {
                MyList.Add(c);
            }

            // Выведем результат
            Console.WriteLine($"Вставка в List<T> : {watchTwo1.Elapsed.TotalMilliseconds}  мс");
            //***********************************************************************************************************

            // Запустим таймер для LinkedList<T>*************************************************************************
            var watchTwo2 = Stopwatch.StartNew();

            // Выполним вставку

            foreach (var i in words)
            {
                MyLinkedList.AddFirst(i);
            }

            // Выведем результат
            Console.WriteLine($"Вставка в LinkedList<T>  : {watchTwo2.Elapsed.TotalMilliseconds}  мс");


            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Вставка элементов в List<T> работает быстрее, чем в LinkedList<T>.");

        }
    }
}