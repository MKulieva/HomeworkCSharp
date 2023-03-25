
using Lesson3;
using Lesson3.obj;
using System.Security.Cryptography;

public static class Program
{
    public static void Main ()
    {
        Patients p1 = new Patients("Алексей", 25);
         p1.DisplayInfo();

         Therapeutists t1 = new Therapeutists("Анна", 38, 10, 102);
         t1.DisplayInfo();
         t1.GetDiagnosis(p1);
         p1.DisplayInfo();
         p1.TakeMedication();
         t1.Cure(p1);
         p1.DisplayInfo();
         p1.TakeMedication();

        Console.WriteLine(" ");

        Patients p2 = new Patients ("Петр", 20);
        p2.DisplayInfo();

        Surgeons s1 = new Surgeons("Иван", 46, 15, 111);
        s1.DisplayInfo();
        s1.GetDiagnosis(p2);
        p2.DisplayInfo();
        s1.Cure (p2);
        p2.DisplayInfo();

        Console.WriteLine(" ");

        Patients p3 = new Patients("Людмила", 67);
        p3.DisplayInfo();

        Ophtalmologist o1 = new Ophtalmologist("Семен", 35, 9, 209);
        o1.DisplayInfo();
        o1.GetDiagnosis(p3);
        p3.DisplayInfo();
        o1.Cure(p3);
        p3.DisplayInfo();
    }
}