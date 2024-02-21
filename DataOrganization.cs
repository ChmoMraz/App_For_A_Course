using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.IO.Pipes;
using System.Text.RegularExpressions;

namespace App
{
    internal class DataOrganization
    {
        private string path;


        public void writingDate(string path)
        {
            DateOfBirth person = new DateOfBirth();
            person.setDate();
            string name = person.getName();
            string date = person.getDate();
            File.AppendAllText(path, $"{date} - {name}\n");             
        }                                                              

        public void deletingDate(string[] allData, string path) 
        {
            Console.WriteLine("Введите имя и фамилию человека, которого хотите удалить:");
            string data = Console.ReadLine();
            Console.WriteLine("Введите дату рождения этого человека:");
            string date = Console.ReadLine();
            Console.WriteLine("\n");    

            

            bool status = false; 
            for(int i  = 0; i < allData.Length; i++)
            {
                if (allData[i].Contains(data) && allData[i].Contains(date)) 
                {
                    allData[i] = string.Empty;
                    status = true; 
                    break;
                }
            }

            if (status)
            {
                Console.WriteLine("Строка удалена");
                allData = allData.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                allData = allData.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                File.WriteAllLines(path, allData);

                
            }
            else
            {
                Console.WriteLine("Строка не найдена");
            }
           
        }
        public void editPerson(string[] allData, string path)
        {
            Console.WriteLine("Введите имя и фамилию человека, данные о котором хотели бы изменить:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите дату рождения этого человека:");
            string date = Console.ReadLine();
            bool status = false;
            int i;

            for (i = 0; i < allData.Length; i++)
            {
                if (allData[i].Contains(name) && allData[i].Contains(date))
                {
                    allData[i] = $"{date} - {name}";
                    status = true;
                    break;
                }
            }

                string editedName;
                string editedDate;
                if (status) {
                    Console.WriteLine("Что вы хотите изменить?\n1 - Смена имени\n2 - Смена даты рождения\n3 - Полная смена данных о человеке");

                    int input = int.Parse(Console.ReadLine());



                    switch (input)
                    {
                        case 1:
                        Console.WriteLine("Введите имя и фамилию, которое хотите присвоить человеку");
                        editedName = Console.ReadLine();


                        allData[i] = $"{date} - {editedName}";
                        File.WriteAllLines(path, allData);
                        Console.WriteLine($"Редактирование {name} прошло успешно");

                        allData = allData.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        allData = allData.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                        break;
                        //
                        case 2:
                        Console.WriteLine("Введите дату рождения, на которую хотите изменить в формате xx.MM.yyy ");
                        editedDate = Console.ReadLine();

                        allData[i] = $"{editedDate} - {name}";
                        File.WriteAllLines(path, allData);
                        Console.WriteLine($"Редактирование {name} прошло успешно");

                        allData = allData.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        allData = allData.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                        break;
                        //
                        case 3:
                        Console.WriteLine("Введите имя и фамилию, которое хотите присвоить человеку");
                        editedName = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения, на которую хотите изменить в формате xx.MM.yyy ");
                        editedDate = Console.ReadLine();

                        allData[i] = $"{editedDate} - {editedName}";
                        File.WriteAllLines(path, allData);
                        Console.WriteLine($"Редактирование {name} прошло успешно");

                        allData = allData.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        allData = allData.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                        break;
                    }
                }
            
                else
                {
                    Console.WriteLine($"Человек с именем {name} не найден в фалйе");
                    editPerson(allData, path);
                }
        }

        public void setPath()
        {
            Console.WriteLine("Введите название файла:");
            this.path = Console.ReadLine();
        }
        public string getPath()
        {
            
            return this.path;
        }
        public void monthDatesOfBirth(string[] allData, string path)
        {
            Console.WriteLine("День рождения в этом месяце у:");
            for (int j = 0; j < allData.Length-1; j++)
            {
                var data = allData[j];
                int data2 = Convert.ToInt32(data[0..2]);
                data = data[3..5];
                
                if (data.Contains(DateTime.Now.ToString("MM")) && data2 >= Convert.ToInt32(DateTime.Now.ToString("dd")))
                    Console.WriteLine(allData[j]);
                

            }
        }
        public void todaysDatesOfBirth(string[] allData, string path) {
            Console.WriteLine("Сегодня нужно поздравить:");
            for(int i = 0; i < allData.Length; i++) {
                if (allData[i].Contains(DateTime.Now.ToString("dd.MM")))
                    Console.WriteLine(allData[i]);
            }
            



        }
    }
}
