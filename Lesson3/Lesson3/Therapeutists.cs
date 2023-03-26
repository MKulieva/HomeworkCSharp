using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class Therapeutists : Doctors
    {
        public Therapeutists(string name, int age, int experience, int cabinetNum) : base(name, age, experience, cabinetNum) { }
        
        public override void GetDiagnosis(Patients patient)
        {
            string[] diagnosis = new string[5];
            diagnosis[0] = "Пневмония";
            diagnosis[1] = "Гипертоническая болезнь";
            diagnosis[2] = "Гастрит";
            diagnosis[3] = "Бронхит";
            diagnosis[4] = "Остеохондроз";
            Random r = new Random();
            string randsror = diagnosis[r.Next(0, diagnosis.Length - 1)];

            patient.diagnos = randsror;
        }

        public override void Cure(Patients patient)
        {
            Console.WriteLine("Назначено лечение");
            patient.IsSick = false;
            patient.diagnos = "Здоров";
        }

    }
}
