using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Patients : IDisplay
    {
        public string Name { get; set; }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Возраст не может быть меньше нуля!");
                }
                else if (value < 18)
                {
                    Console.WriteLine("Вам в детскую больницу!");
                    _age = value;
                }
                else
                {
                    _age = value;
                }
            }
            

        }
        public string diagnos { get; set; } = "Диагноз неизвестен";
        public bool IsSick = true;
        public Patients(string name, int age)
        {
            Console.WriteLine("Регистрация нового пациента");
            Name = name;
            Age = age;

        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя пациента: {Name} Возраст пациента: {_age} Диагноз: {diagnos}");
        }
        public void TakeMedication()
        {
            if (IsSick == true)
            {
                Console.WriteLine($"Принять лекарство от {diagnos}");
            }
            else
            {
                Console.WriteLine("Принять витамины");
            }
                 

        }
       
}
}
