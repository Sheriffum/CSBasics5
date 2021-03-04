using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    class Program
    {
        // Умовистов Андрей
        //2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        //а) Вывести только те слова сообщения,  которые содержат не более n букв.
        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        //в) Найти самое длинное слово сообщения.
        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        //д) ***Создать метод, который производит частотный анализ текста.
        //В качестве параметра в него передается массив слов и текст, 
        //в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.
        //Здесь требуется использовать класс Dictionary.

        static void Main(string[] args)
        {

            Helpers.Header("Обработка текста");
            var lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, Lorem do eiusmod tempor incididunt ut labore et Lorem, magna aliqua. Ut enim ad minim veniam, quis nostrud exercitatio ullamco laboris nisi ut aliquip ex ea commodo consequat.";
            Helpers.Print("Исходный текст:", ConsoleColor.Green);
            Console.WriteLine(lorem);
            Console.WriteLine();


            //а) Вывести только те слова сообщения,  которые содержат не более n букв.
            var n = 2;
            var wordsLessOrEqualNLetters = Message.GetWordsLessOrEqualNLetters(lorem, n);
            Helpers.Print($"{wordsLessOrEqualNLetters.Count()} - слов, длина которых меньше или равна {3}:", ConsoleColor.Green);
            foreach (var word in wordsLessOrEqualNLetters)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();

            //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
            var c = 'r';
            Helpers.Print($"Новое сообщение без слов, оканчивающихся на {c}:", ConsoleColor.Green);
            var messageWithoutSomeWords = Message.DeleteFromMessageWordsEndsWith(lorem, c);
            Console.WriteLine(messageWithoutSomeWords);
            Console.WriteLine();

            //в) Найти самое длинное слово сообщения.
            var longestWord = Message.GetLongestWord(lorem);
            Helpers.Print("Самое длинное слово:", ConsoleColor.Green);
            Console.WriteLine($"{longestWord} ({longestWord.Length} символов)");
            Console.WriteLine();

            //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
            var stringFromLongestWords = Message.GetStringFromLongestWords(lorem);
            Helpers.Print($"Строка из самых длинных слов:", ConsoleColor.Green);
            Console.WriteLine(stringFromLongestWords);
            Console.WriteLine();

            Helpers.Print("Частотный анализ:", ConsoleColor.Green);

            var wordsForAnalyze = new string[] { "Lorem", "ipsum", "do", "NewYork" };
            var analyzeResults = Message.FrequencyAnalyzeText(wordsForAnalyze, lorem);
            foreach (var result in analyzeResults)
            {
                Console.WriteLine($"Слово {result.Key} входит {result.Value} раз");
            }
            Console.WriteLine();

            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();

        }


       
    
    }
}
