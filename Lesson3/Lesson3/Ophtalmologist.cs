using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.obj
{
    public class Ophtalmologist : Doctors
    {
        public Ophtalmologist(string name, int age, int experience, int cabinetNum) : base(name, age, experience, cabinetNum) { }
        public override void GetDiagnosis(Patients patient)
        {
            Random r = new Random();
            int diopt = r.Next(-10, 10);
            if (diopt > 0)
            {
                patient.diagnos = $"Дальнозоркость +{diopt}";
            }
            else
            {
                patient.diagnos = $"Близорукость {diopt}";
            }
            
        }
        public override void Cure(Patients patient)
        {
            Console.WriteLine($"Рецепт на очки");
            patient.IsSick = false;
        }

    }
}
