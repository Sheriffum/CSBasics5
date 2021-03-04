using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core;

namespace Challenge1
{
    class Program
    {
        // Умовистов Андрей
        //1. Создать программу, которая будет проверять корректность ввода логина.
        //Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        //а) без использования регулярных выражений;
        //б) с использованием регулярных выражений.
        static void Main(string[] args)
        {

            Helpers.Header("Авторизация");

            if (Authorize(5))
            {
                Helpers.Print("Логин корректный", ConsoleColor.Green);
            }
            else
            {
                Helpers.Print("Логин некорректный!", ConsoleColor.Red);
            }



            Helpers.Print("Нажмите Enter для выхода");
            Console.ReadLine();

        }

        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="attempts">Количество попыток</param>
        /// <returns></returns>
        private static bool Authorize(int attempts)
        {
            while (attempts > 0)
            {
                attempts--;

                Console.Write("Введите логин: ");
                var login = Console.ReadLine();

                if (CheckLoginWithRegEx(login))
                //if (CheckLogin(login))
                    return true;
                else
                    Helpers.Print($"Введены неверные логин/пароль. Осталось попыток: {attempts}", ConsoleColor.Yellow);
            }
            return false;
        }

        /// <summary>
        /// Проверка логина без рег. выражений
        /// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        /// </summary>
        /// <param name="login">Логин для проверки</param>
        /// <returns></returns>
        private static bool CheckLogin(string login)
        {
            // Логин не может быть пустой, для исключения дальнейших ошибок
            if (string.IsNullOrEmpty(login)) return false;

            // проверка на длину
            if (!(login.Length >= 2 && login.Length <= 10)) return false;

            // Первый символ не может быть цифрой
            if (login[0] >= '0' && login[0] <= '9') return false;

            //проверка символов a-z A-Z 0-9
            for (int i = 0; i < login.Length; i++)
            {
               
                if ((login[i] >= '0' && login[i] <= '9')
                    || (login[i] >= 'a' && login[i] <= 'z')
                    || (login[i] >= 'A' && login[i] <= 'Z'))
                    continue;
                else return false;
            }
            // все проверки пройдены
            return true;

        }

        /// <summary>
        /// Проверка логина с рег. выражениями
        /// Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        /// </summary>
        /// <param name="login">Логин для проверки</param>
        /// <returns></returns>
        private static bool CheckLoginWithRegEx(string login)
        {
            Regex regex = new Regex(@"^\D[0-9a-zA-Z]+$");
            if (regex.IsMatch(login))
                return true;
            else return false;
        }

        public struct Account
        {
            public string Login;
            public string Password;
        }
    }
}
