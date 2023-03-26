using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public abstract class Doctors : IDiagnostics, ICure, IDisplay
    {
        public string name;
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Возраст должен быть больше 0!");
                }
            else
                {
                    _age = value;
                }
            }

        }
        public int experience { get; set; }
        public int CabinetNum { get; set; }
        public Doctors(string name, int age, int experience, int cabinetNum)
        {
            this.name = name;
            this.Age = age;
            this.experience = experience;
            CabinetNum = cabinetNum;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя врача: {name} Возраст врача: {_age} Стаж: {experience} Кабинет №{CabinetNum}");
        }
        public abstract void GetDiagnosis(Patients patient);
        public abstract void Cure(Patients patient);

    }
}

   
