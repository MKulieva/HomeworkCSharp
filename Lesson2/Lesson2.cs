int max = 0;
int max2 = 0;
try
{
    Console.WriteLine("Введите число элементов");
    int n = ReadInt(); int[] numbers = new int[n];
    for (int i = 0; i < n; i++)
    {
        Console.WriteLine($"Введите элемент №{i+1}");
        numbers[i] = ReadInt();
    }
    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max)
        {
            max = numbers[i];
        }
    }
    //Console.WriteLine($"Наибольшее число {max}");

    for (int i = 0; i < numbers.Length; i++)
    {
        if (numbers[i] > max2 && numbers[i] < max)
        {
            max2 = numbers[i];
        }
    }
    Console.WriteLine($"Второй наибольший элемент - {max2}");
}
catch (FormatException)
{
    Console.WriteLine("Вы ввели не число!");
}
catch (OverflowException ex)
{
    Console.WriteLine("Число элементов должно быть больше 0!");
    Console.WriteLine(ex.Message);
}



    
static int ReadInt()
{
    var text = Console.ReadLine();
    return Int32.Parse(text);
}
