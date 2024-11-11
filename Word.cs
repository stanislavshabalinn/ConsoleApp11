using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Word
{
    class Program

    {
        private static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText("https://lms-cdn.skillfactory.ru/assets/courseware/v1/dc9cf029ae4d0ae3ab9e490ef767588f/asset-v1:SkillFactory+CDEV+2021+type@asset+block/Text1.txt");

            //Убираем из текста знаки пунктуации
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            // Сохраняем символы-разделители в массив
            char[] delimiters = new char[] { ' ', '\r', '\n' };

            // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            // выводим количество
            // Console.WriteLine(words.Length);

            foreach (var c in words)
            {
                if (myDictionary.ContainsKey(c))
                {

                    int value = myDictionary[c];
                    value = value + 1;
                    myDictionary[c] = value;
                }
                else
                {
                    myDictionary.Add(c, 1);
                }
            }

            var sortDict = from entry in myDictionary
                           orderby entry.Value descending
                           select entry;

            int i = 0;
            foreach (var value in sortDict)
            {
                if (i < 10)
                {
                    i++;
                    Console.WriteLine($"{value.Key} = {value.Value}");
                }
            }
        }
    }
}