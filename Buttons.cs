using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace App
{
    internal class Buttons
    {
        private string[] allData;
        private string path;

        public void functions()
        {
            DateOfBirth p1 = new DateOfBirth();
            DataOrganization person = new DataOrganization();

         
            person.setPath();

            this.path = person.getPath();
            if (!File.Exists(path))
            {

                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                {

                }

                Console.WriteLine("Т.к. файла не было, программа создала новый");
            }
            else
            {





                buttons(this.path);
            }
        }

        public void buttons( string path)
        {
            string[] allData = File.ReadAllLines(path);
            Console.WriteLine("\nЧто вы хотите сделать?\n1 - Добавление нового пользователя\n2 - Удаление пользователя\n3 - Редактирование пользователя\n4 - Проверка сегодняшних дней рождения\n5 - Проверка ближайших дней рождения");
            int input = int.Parse(Console.ReadLine());
            DateOfBirth p1 = new DateOfBirth();
            DataOrganization person = new DataOrganization();
            switch (input)
            {
                case 1: // запись нового пользователя
                    person.writingDate(path);
                    buttons(path);
                    break;
                case 2: // удаление одного из пользователей
                    person.deletingDate(allData, path);
                    buttons(path);
                    break;
                case 3: // редактирование человека
                    person.editPerson(allData, path);
                    buttons(path);
                    break;
                case 6:
                    buttons(path); // возврат к началу программы
                    break;
                case 4: // проверка сегодняшних др
                    person.todaysDatesOfBirth(allData, path);
                    buttons(path);
                    break;
                case 5: // проверка др в течение месяца
                    person.monthDatesOfBirth(allData, path);
                    buttons(path);
                    break;
            }
        }
    }
}
