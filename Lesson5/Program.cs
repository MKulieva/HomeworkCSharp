using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


public static class Program
{
    public static void Main ()
    {
        const string zipFile = "C:\\Users\\LENOVO\\OneDrive\\Рабочий стол\\Homework\\smartgit-win-22_1_5.zip";
        string folderPath = "C:\\Users\\LENOVO\\source\\repos\\HomeworkCSharp\\Lesson5\\ZipOpen";
        Prog1 (zipFile, folderPath);
        Prog2("C:\\Users\\LENOVO\\source\\repos\\HomeworkCSharp\\Lesson5\\Lesson5Homework.txt");
        
    }
    // Программа 1
    static void Prog1 (string zipFile, string folderPath)
    {
        string[] contents;
        //1. извлекла файлы из зипа
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        ZipFile.ExtractToDirectory(zipFile, folderPath);

        //2. Считала названия папок из указанной папки и сложила в массив
        contents = Directory.GetFileSystemEntries(folderPath);

        //3. записываю информацию о содержимом папки в документ
        string csvPath = "C:\\Users\\LENOVO\\source\\repos\\HomeworkCSharp\\Lesson5\\InfoFile.csv";
        using var FileStream = new FileStream(csvPath, FileMode.Append);
        using var streamWriter = new StreamWriter(FileStream);
        foreach (var element in contents)
        {
            ContentInfo content = new ContentInfo(element);
            streamWriter.WriteLine($"{content.Type} \t {content.Name} \t {content.DateOfChange}");
        }

        //4. Удаляю папку с распакованным архивом
        Directory.Delete(folderPath, true);

        //5. Сохраняю путь к файлу csv
        string txtPath = "C:\\Users\\LENOVO\\source\\repos\\HomeworkCSharp\\Lesson5\\Lesson5Homework.txt";//Не находит путь до %AppData%/Lesson12Homework.txt положила в другую папку
        using var FileStream2 = new FileStream(txtPath, FileMode.OpenOrCreate);
        using var streamWriter2 = new StreamWriter(FileStream2);
        streamWriter2.WriteLine(Path.GetFullPath(csvPath));
    }

    //Программа 2
    static void Prog2 (string txtPath)
    {
        if (!File.Exists (txtPath))
        {
            Console.WriteLine($"Файл {txtPath} не найден!");
        }
        else
        {
            var FileStreamTxt = new FileStream(txtPath, FileMode.Open);
            var streamReaderTxt = new StreamReader(FileStreamTxt);
            string csvPath = streamReaderTxt.ReadLine();
            FileStreamTxt.Dispose();
            streamReaderTxt.Dispose();

            if (!File.Exists(csvPath))
            {
                Console.WriteLine($"Файл {csvPath} не найден!");
            }
            else
            {
                string[] contents = File.ReadAllLines(csvPath);
                List<ContentInfo> Content = new List<ContentInfo>() { };
                foreach (var element in contents)
                {
                    
                    ContentInfo content = new ContentInfo ();
                    string[] features = element.Split("\t");
                    foreach (var feature in features)
                    {
                        if (feature == "file " || feature == "folder ")
                        {
                            content.Type = feature;
                        }
                        
                       else if (DateTime.TryParse (feature, out var date))
                        {
                            content.DateOfChange = date;
                        }
                        else
                        {
                            content.Name = feature;
                        }
                        
                    }

                    Content.Add(content);
                }

                IEnumerable < ContentInfo > sortedContent = Content.OrderBy(x => x.DateOfChange);
                foreach (ContentInfo content in sortedContent)
                {
                    Console.WriteLine($"{content.Type} \t {content.Name} \t {content.DateOfChange}");
                }
          
                
            }
            File.Delete(txtPath);
        }
    }

}



