﻿using System.Text;
using System.IO;
using static System.Console;

static void WriteFile(string filePath,string n)
{

    if (File.Exists(filePath))
    {
        FileStream fs = new FileStream(filePath,
        FileMode.Open, FileAccess.Write,
        FileShare.None) ;
        WriteLine("Fio and bday: ");
        string writeText = ReadLine();
        writeText = writeText + "\n strok" +n+", stolb"+ n;
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

int n = 5;
string filePath = "test3.txt";
    WriteFile(filePath,n.ToString());
    // выводим результат на консоль
    WriteLine($"\nData read from the file:{ ReadFile(filePath)}");

int[,] arrayint = new int[n,n];
for (int i = 0; i < n; i++)
    for (int j=0; j < n; j++)
        arrayint[i,j] = i+j;

/*for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(arrayint[i, j]);
        Console.Write(" ");
    }
        Console.WriteLine();
}
*/
double[,] arrayfl = new double[n, n];
for (int i = 0; i < n; i++)
    for (int j = 0; j < n; j++)
        arrayfl[i, j] = (i + j+1)*(i+j+1)/7.1;

/*for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Console.Write(arrayfl[i, j]);
        Console.Write(" ");
    }
    Console.WriteLine();
}
*/
