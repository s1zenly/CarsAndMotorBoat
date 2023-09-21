using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using EKRLib;
using static System.Net.Mime.MediaTypeNames;


namespace Project
{
    class Program
    {
        static List<Transport> transport = new List<Transport>();
        static Random random = new Random();
        /// <summary>
        /// В методе происходит реализация повтора, запись в файл, также вывод на экран данных с переопределенного StartEngine
        /// </summary>
        static void Main()
        {
            // Данная переменная отвечает за повтор программы или нет, в зависимости от выбора пользователя
            bool repeat = false;
            while (repeat == false)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                // Даная переменная является длинной списка в диапозоне -[6, 10)
                var kol = random.Next(6, 10);
                try
                {
                    // Данная переменная производит запись в Car.txt
                    using (StreamWriter swC = new StreamWriter("../../../../Cars.txt", false, System.Text.Encoding.UTF8))
                    {
                        // Данная переменная производит запись в MotorBoat.txt
                        using (StreamWriter swM = new StreamWriter("../../../../MotorBoat.txt", false, System.Text.Encoding.UTF8))
                        {
                            for (int i = 0; i < kol; i++)
                            {
                                // Данная переменная получает данные случайной генерации Car или Motorboat
                                Transport save = GenerateOneObject();
                                transport.Add(save);

                                if (save.GetType().Name == "Car")
                                {
                                    swC.WriteLine(save.ToString());
                                }
                                else
                                {
                                    swM.WriteLine(save.ToString());
                                }
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("У вас открыт файл! Закройте его и нажмите любую клавишу, кроме \"Escape\"!");
                }

                for (int i = 0; i < transport.Count; i++)
                {
                    Console.WriteLine(transport[i].StartEngine());
                }

                Console.WriteLine("Если хотите закончить, то нажмите \"Escape\", иначе любую другую клавишу");

                var cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Escape)
                {
                    repeat = true;
                    Console.WriteLine();
                    Console.WriteLine("До свидания!");
                }

                transport.Clear();
            }
        }

        /// <summary>
        /// Генерируется случайно Car или MotorBoat, а также power и происходит проверка на корректность данных
        /// </summary>
        /// <returns></returns>
        static Transport GenerateOneObject()
        {
            var NumberRandomObject = random.Next(0, 2);
            var power = random.Next(10, 100);
            string model = GenerateModel();

            try
            {
                if (NumberRandomObject == 0)
                    return (new Car(model, Convert.ToUInt16(power)));
                else
                    return (new MotorBoat(model, Convert.ToUInt16(power)));
            }
            catch (TransportException ex)
            {
                Console.WriteLine(ex.Message);
                return GenerateOneObject();
            }
        }

        /// <summary>
        /// Создается Модель согласно спецификации
        /// <param name="modefull"> В данной переменной будет собран посимвольно конечный номер </param>
        /// <param name="model">  В данной переменной появляется слуйчайное число для конвертации из таблицы аски далее </param>
        /// </summary>
        /// <returns></returns>
        static string GenerateModel()
        {
            string modelfull = "";

            for (int j = 0; j < 5; j++)
            {
                bool flag = false;

                while (flag == false)
                {
                    var model = random.Next(48, 91);

                    if (!((model >= 58) && (model <= 64)))
                    {
                        modelfull += (char)model;
                        flag = true;
                    }
                }
            }
            return modelfull;
        }
    }
}