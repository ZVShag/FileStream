using System.Text;
using System.IO;
using static System.Console;

static void WriteFile(string filePath)
{
    try
    {
    using (FileStream fs = new FileStream(filePath,
    FileMode.Open, FileAccess.Write,
    FileShare.None)) ;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally 
    {     // получаем данные для записи в файл
        WriteLine("Enter the data to write to the file: ");
       
        string writeText = ReadLine();
        // преобразуем строку в массив байт
        byte[] writeBytes = Encoding.Default.GetBytes(writeText);
        // записываем данные в файл
        fs.Write(writeBytes, 0, writeBytes.Length);
        WriteLine("Information recorded!");
    }
}
static string ReadFile(string filePath)
{
    using (FileStream fs = new FileStream(filePath,
    FileMode.Open, FileAccess.Read,
    FileShare.Read))
    {
        byte[] readBytes = new byte[(int)fs.Length];
        // считываем данные из файла
        fs.Read(readBytes, 0, readBytes.Length);
        // преобразуем байты в строку
        return Encoding.Default.
        GetString(readBytes);
    }
}

    string filePath = "test2.txt";
    WriteFile(filePath);
    // выводим результат на консоль
    WriteLine($"\nData read from the file:{ ReadFile(filePath)}");

 
