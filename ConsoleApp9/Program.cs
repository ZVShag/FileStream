using System.Text;
using System.IO;
using static System.Console;

static void WriteFile(string filePath)
{

    if (File.Exists(filePath))
    {
        FileStream fs = new FileStream(filePath,
        FileMode.Open, FileAccess.Write,
        FileShare.None) ;
        WriteLine("Enter the data to write to the file: ");
        string writeText = ReadLine();
        byte[] writeBytes = Encoding.Default.GetBytes(writeText);
        fs.Write(writeBytes, 0, writeBytes.Length);
        WriteLine("Information recorded!");
        fs.Close();
    }
    else
    {
        WriteLine("File not found!");
        FileStream fs = new FileStream(filePath,
        FileMode.Create, FileAccess.Write,
        FileShare.None);
        WriteLine("Enter the data to write to the file: ");
        string writeText = ReadLine();
        byte[] writeBytes = Encoding.Default.GetBytes(writeText);
        fs.Write(writeBytes, 0, writeBytes.Length);
        WriteLine("Information recorded!");
        fs.Close();
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

    string filePath = "test3.txt";
    WriteFile(filePath);
    // выводим результат на консоль
    WriteLine($"\nData read from the file:{ ReadFile(filePath)}");

 
