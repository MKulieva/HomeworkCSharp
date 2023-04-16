using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework6
{
    public class Program2
    {
        static async Task Main(string[] args)
        {
            string txtPath = @"C:\Users\LENOVO\source\repos\HomeworkCSharp\Lesson6\Lesson5Homework.txt";
            //Считывает путь к файлу из % AppData %/ Lesson12Homework.txt
            try
            {
                 var FileStreamTxt = new FileStream(txtPath, FileMode.Open);
                 var streamReaderTxt = new StreamReader(FileStreamTxt);
                 string csvPath = streamReaderTxt.ReadLine();
                 FileStreamTxt.Dispose();
                 streamReaderTxt.Dispose();

                 //Открывает указанный файл .csv; Выводит в консоль список файлов, прочитанный из файла csv, отсортированный по дате изменения

                 using (StreamReader csvReader = new StreamReader(csvPath))
                 {
                     List<Content> contents = new List<Content>() { };
                     string line;
                     while (!csvReader.EndOfStream)
                     {
                         line = csvReader.ReadLine();
                         string[] feature = line.Split('\t');
                         Content content = new()
                         {
                             Type = feature[0],
                             Name = feature[1],
                             DateOfChange = DateTime.Parse(feature[2])
                         };
                         contents.Add(content);
                     }

                     var sortedContent = contents.OrderBy(content => content.DateOfChange).ToList();
                     foreach (Content content in sortedContent)
                     {
                         Console.WriteLine($"{content.Type} \t {content.Name} \t {content.DateOfChange}");
                     }
                 }

                 //Удаляет файл % AppData %/ Lesson12Homework.txt
                 File.Delete(txtPath);
                 Console.WriteLine($"Файл {txtPath} удален");
             }

             catch (FileNotFoundException ex)
             {
                 Console.WriteLine($"Файл не найден: {ex.Message}");
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }




         }
        }
}
