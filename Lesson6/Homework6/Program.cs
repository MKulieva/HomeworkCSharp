using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Homework6;
public class Program
{
    /*static async Task Main(string[] args)
    {
        //string toZip = "C:\\Users\\LENOVO\\OneDrive\\Рабочий стол\\Архив";
        string zipFile = @"C:\Users\LENOVO\OneDrive\Рабочий стол\Homework\Архив.zip";
        string folderPath = @"C:\Users\LENOVO\source\repos\HomeworkCSharp\Lesson6\UnZip";
        string csvPath = @"C:\Users\LENOVO\source\repos\HomeworkCSharp\Lesson6\ContentInfo.csv";
        string txtPath = @"C:\Users\LENOVO\source\repos\HomeworkCSharp\Lesson6\Lesson5Homework.txt";

        /*ZipFile.CreateFromDirectory (toZip, zipFile);
        Console.WriteLine("Архив создан");

        //Распаковывает архив в папку рядом с запускаемым файлом программы
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        try
        {
            ZipFile.ExtractToDirectory(zipFile, folderPath);
            Console.WriteLine($"Архив {zipFile} распакован в папку {folderPath}");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Файл не найден: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            //Считывает названия файлов и папок из указанной папки
            string[] contents = Directory.GetFileSystemEntries(folderPath);

            //Записывает информацию о содержимом папки в текстовый файл в формате.csv
            await using var FileStream = new FileStream(csvPath, FileMode.Append);
            await using var StreamWriter = new StreamWriter(FileStream);
            foreach (var element in contents)
            {
                Content content = new Content();
                content.Type = File.GetAttributes(element).HasFlag(FileAttributes.Directory) ? "folder" : "file";
                content.Name = Path.GetFileName(element);
                content.DateOfChange = File.GetLastWriteTime(element);
                StreamWriter.WriteLineAsync($"{content.Type} \t  {content.Name}  \t  {content.DateOfChange}");
            }
            Console.WriteLine($"Данные о содержимом архива записаны в {csvPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        //Удаляет папку с распакованным архивом
        Directory.Delete(folderPath, true);
        Console.WriteLine($"Папка {folderPath} удалена");


        //Сохраняет путь к файлу csv в файле % AppData %/ Lesson12Homework.txt
        await using var filestream = new FileStream(txtPath, FileMode.OpenOrCreate);
        await using var streamWriter = new StreamWriter(filestream);
        streamWriter.WriteLineAsync(csvPath);
        Console.WriteLine($"Путь к файлу сохранен в {txtPath}");
    }*/
}



