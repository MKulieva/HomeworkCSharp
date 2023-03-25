using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
        public class Surgeons : Doctors
        {
            public bool IsOnOperation;
        public Surgeons(string name, int age, int experience, int cabinetNum) : base(name, age, experience, cabinetNum) { }
        public override void GetDiagnosis(Patients patient)
            {
            string[] diagnosis = new string[5];
            diagnosis[0] = "Перелом ноги";
            diagnosis[1] = "Вывих сустава";
            diagnosis[2] = "Абсцесс";
            diagnosis[3] = "Порок сердца";
            diagnosis[4] = "Опухоль";
            Random r = new Random();
            string randsror = diagnosis[r.Next(0, diagnosis.Length - 1)];

            patient.diagnos = randsror;
        }
            public override void Cure(Patients patient)
            {
                patient.IsSick = false;
            patient.diagnos = "Здоров";
                Console.WriteLine("Операция прошла успешно!");

            }

        }
}
