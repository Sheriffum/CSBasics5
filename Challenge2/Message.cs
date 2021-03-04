using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Challenge2
{
    static class Message
    {
        //, содержащий следующие статические методы для обработки текста:
        //а) Вывести только те слова сообщения,  которые содержат не более n букв.
        public static IEnumerable<string> GetWordsLessOrEqualNLetters(string message, int n)
        {
            return SplitMessageByWords(message).Where(w => w.Length <= n);

        }

        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.

        public static string DeleteFromMessageWordsEndsWith(string message, char c)
        {
            var pattern = @"(\w+["+c+@"])\b";
            var sb_trim = Regex.Replace(message, pattern , "");

            return sb_trim;
        }

        //в) Найти самое длинное слово сообщения.
        public static string GetLongestWord(string message)
        {
            var words =  SplitMessageByWords(message);

            return words.Where(w => w.Length == words.Max(p => p.Length)).FirstOrDefault();
        }


        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        public static string GetStringFromLongestWords(string message)
        {
            var sb = new StringBuilder();

            var words = SplitMessageByWords(message);
            var longestWords =  words.Where(w => w.Length == words.Max(p => p.Length));
            bool isFirstWord = true;
            foreach (var word in longestWords)
            {
                sb.Append(word);
                if (isFirstWord) sb.Append(" ");
                isFirstWord = false;
            }
            
            return sb.ToString();
        }


        //д) ***Создать метод, который производит частотный анализ текста.
        //В качестве параметра в него передается массив слов и текст, 
        //в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст.

        public static Dictionary<string, int> FrequencyAnalyzeText(string[] words, string message)
        {
            var result = new Dictionary<string, int>();
           
            foreach (var word in words)
            {
                 var regex = new Regex(@"\b(" + word + @")\b");
                var mathes = regex.Matches(message);
                result.Add(word, mathes.Count);
            }

            return result;
        }



        /// <summary>
        /// Получение списка слов сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <returns>Список слов</returns>
        private static List<string> SplitMessageByWords(string message)
        {
            var result = new List<string>();

            var words = Regex.Split(message, @"\W");

            foreach (var word in words)
            {
                if (word.Length > 0) result.Add(word);
            }

            return result;

        }
    }
}
