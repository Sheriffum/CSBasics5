using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4
{
    public class Pupil 
    {

        public Pupil(string lastName, string firstName, int[] scores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = scores;
        }





        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int[] Scores { get; private set; } = { 0, 0, 0 };

        public double AvgScore
        {
            get {
                return (Scores[0] + Scores[1] + Scores[2]) / 3.0;
            }
           
        }

        /// <summary>
        /// Создание Ученика с оценками из строки
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Pupil AddPupil(string line)
        {

            var parts = line.Split(' ');
            if (parts.Length != 5) return null;

            //<Фамилия> — строка, состоящая не более чем из 20 символов, 
            if (parts[0].Length > 20)
                return null;
            //<Имя> — строка, состоящая не более чем из 15 символов, 
            if (parts[1].Length > 15)
                return null;
            //<оценки> — через пробел три целых числа, 
            if (Int32.TryParse(parts[2], out int score1) && Int32.TryParse(parts[3], out int score2) && Int32.TryParse(parts[4], out int score3))
            {
                // проверяем оценки на "пятибальность"
                if (score1 < 1 || score1 > 5 || score2 < 1 || score2 > 5 || score3 < 1 || score3 > 5)
                    return null;
                else
                    //все проверки пройдены, создаем и возвращаем запись
                    return new Pupil(parts[0], parts[1], new int[3] { score1, score2, score3 });
            }
            else return null;

        }

      
    }

}
