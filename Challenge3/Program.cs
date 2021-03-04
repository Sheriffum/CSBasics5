using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Challenge3
{
    class Program
    {
        // Умовистов Андрей
        //*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
        //Например:
        //badc являются перестановкой abcd.

        static void Main(string[] args)
        {
            Helpers.Header("Обработка текста");

            Console.WriteLine("Введите первую строку:");
            var s1 = Console.ReadLine();

            Console.WriteLine("Введите вторую строку:");
            var s2 = Console.ReadLine();

            if (IsPermutationStrings(s1,s2))
            {
                Helpers.Print("Строки являются перестановками", ConsoleColor.Green);
            } else
            {
                Helpers.Print("Строки НЕ являются перестановками", ConsoleColor.Red);
            }

            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();


        }

        /// <summary>
        /// Проверка строк на перестановку
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        static bool IsPermutationStrings(string s1, string s2)
        {
            
            var sLenth = s1.Length;
            // строки должны быть одинаковой длины
            if (s1.Length != s2.Length) return false;

            //Получаем символы первой строки
            var s1Chars = s1.Distinct().OrderBy(c=> c.ToString());
            //Получаем символы первой строки
            var s2Chars = s2.Distinct().OrderBy(c => c.ToString());

            // Проводим частотный анализ символов первой строки
            var fas1 = FrequencyAnalyzeText(s1Chars, s1);
            // Проводим частотный анализ символов второй строки
            var fas2 = FrequencyAnalyzeText(s2Chars, s2);
            // сравниваем результаты анализа
            if (Enumerable.SequenceEqual(fas1, fas2))
            {
                return true;
            } else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Частотный анализ символов в строке
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Dictionary<char, int> FrequencyAnalyzeText(IEnumerable<char> chars, string message)
        {
            var result = new Dictionary<char, int>();

            foreach (var c in chars)
            {
                var regex = new Regex(@"(" + c + @")");
                var mathes = regex.Matches(message);
                result.Add(c, mathes.Count);
            }

            return result;
        }
    }
}
