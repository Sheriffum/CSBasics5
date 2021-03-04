using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4
{
    class Program
    {
        // Умовистов Андрей
        //*Задача ЕГЭ.
        //На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
        //В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
        //<Фамилия> <Имя> <оценки>,
        //где
        //<Фамилия> — строка, состоящая не более чем из 20 символов, 
        //<Имя> — строка, состоящая не более чем из 15 символов, 
        //<оценки> — через пробел три целых числа, 
        //соответствующие оценкам по пятибалльной системе. 
        //<Фамилия> и<Имя>, а также <Имя> и<оценки> разделены одним пробелом. 
        //Пример входной строки:
        //Иванов Петр 4 5 3
        //Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
        //Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

        static void Main(string[] args)
        {
            Helpers.Header("Обработка текста");
            bool repeat = true;
            var pupils = new List<Pupil>();
            var numberOfPupils = 0;

            //Ввод количества учеников в классе
            while (repeat)
            {
                Helpers.Print("Введите количество учеников (от 10 до 100):");

                if (Int32.TryParse(Console.ReadLine(), out numberOfPupils))
                {
                    if (numberOfPupils >= 1 && numberOfPupils <= 100)
                        repeat = false;
                }
                else
                {
                    Helpers.Print("Введено не число", ConsoleColor.Yellow);
                }
            }

            //Ввод данных об учениках

            // Заполнение из файла для тестирования
            //var lines = File.ReadAllLines("pupils.txt");
            //foreach (var line in lines)
            //{
            //    var currentPupil = Pupil.AddPupil(line);
            //    if (currentPupil != null)
            //    {
            //        pupils.Add(currentPupil);
            //    }
            //}

            var i = 1;
            while (i <= numberOfPupils)
            {
                Helpers.Print($"Введите данные о сдаче экзамена ученика № {i} из {numberOfPupils} в формате <Фамилия> <Имя> <оценки>. Пример: Иванов Иван 5 4 3");
                var currentPupil = Pupil.AddPupil(Console.ReadLine());
                if (currentPupil != null)
                {
                    Helpers.Print("Данные сохранены успешно", ConsoleColor.Green);
                    pupils.Add(currentPupil);
                    i++;
                }
                else
                {
                    Helpers.Print("Не удалось сохранить ! Проверьте ввведенные данные: ", ConsoleColor.Green);
                    Console.WriteLine(@"<Фамилия> — строка, состоящая не более чем из 20 символов, 
            <Имя> — строка, состоящая не более чем из 15 символов, 
            <оценки> — через пробел три целых числа от 1 до 5");
                }



            }
            Console.WriteLine("---------------------------------");
            Helpers.Print("Итоговая ведомость:", ConsoleColor.Blue);

            foreach (var pupil in pupils)
            {
                Console.WriteLine($"{pupil.LastName,20} {pupil.FirstName,15} {pupil.Scores[0],3} {pupil.Scores[1],3} {pupil.Scores[2],3}");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            //Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. 
            //Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

            //сортируем учеников по среднему баллу
            var sortedPupils = pupils.OrderBy(p => p.AvgScore);
 
            // создаем список худших
            var worstPupils = new List<Pupil>();
            // получаем три самые низкие средние оценки
            var worstScores = sortedPupils.Select(p => p.AvgScore).Distinct().Take(3);

            // наполняем список худших
            foreach (var score in worstScores)
            {
                // проверяем - не полон ли уже список худших, можно добавить ли хоть одного?
                var canAdd = 3 - worstPupils.Count();
                //если полон - пропускаем шаг
                if (canAdd < 1) continue;
                // добавляем учеников с текущей "плохой" оценкой 
                worstPupils.AddRange(sortedPupils.Where(p=> p.AvgScore == score));

            }

            Console.WriteLine();

            Console.WriteLine("---------------------------------");
            Helpers.Print("Худшие ученики:", ConsoleColor.Yellow);
            foreach (var pupil in worstPupils)
            {
                Console.WriteLine($"{pupil.LastName,20} {pupil.FirstName,15} {pupil.AvgScore}");
            }
            Console.WriteLine("---------------------------------");



            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();

        }




        
    }
}
