using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App
{

    class DateOfBirth
    {
        private DateTime Birth;
        private string name;
        private string input; 
        

        public void setDate()
        {
            Console.WriteLine("Введите дату рождения человека в формате dd.MM.yyyy:");
            this.input = Console.ReadLine();
            Console.WriteLine("Введите имя и фамилию человека в формате Имя Фамилия:");
            this.name = Console.ReadLine();

            if (DateTime.TryParseExact(this.input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out this.Birth)){ } 
            else
            {
                Console.WriteLine("Некорректный формат даты."); 
                setDate(); 
            }
        }

        public string getDate()
        { 
            return this.input;      
        }                           
        public string getName()
        {
            return this.name;
        }
        public void printData()
        {
            Console.WriteLine($"{this.input} - {this.name}");  
        }                                                       





    }

}
