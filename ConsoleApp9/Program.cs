using System.Text;
using System.IO;
using static System.Console;

static void WriteFile(string filePath,string n)
{

    if (File.Exists(filePath))
    {
        FileStream fs = new FileStream(filePath,
        FileMode.Open, FileAccess.Write,
        FileShare.None) ;
        string txt = ReadFile(filePath);
        if (txt == null)
        {

            WriteLine("Fio and bday: ");
            string writeText = ReadLine();
            byte[] writeBytes = Encoding.Default.GetBytes(writeText);
            fs.Write(writeBytes, 0, writeBytes.Length);
        }
        else
        {
            txt = txt + n;
            byte[] writetxt = Encoding.Default.GetBytes(txt);
            fs.Write(writetxt, 0, txt.Length);
        }
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
        fs.Read(readBytes, 0, readBytes.Length);
        return Encoding.Default.
        GetString(readBytes);
    }
}

int n = 5;
string filePath = "test3.txt";

// выводим результат на консоль

string Arrayint="\n";
int[,] arrayint = new int[n,n];
for (int i = 0; i < n; i++)
    for (int j=0; j < n; j++)
        arrayint[i,j] = i+j;

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Arrayint = Arrayint + arrayint[i, j].ToString() + " ";

    }
    Arrayint = Arrayint + "\n";
}

double[,] arrayfl = new double[n, n];
for (int i = 0; i < n; i++)
    for (int j = 0; j < n; j++)
        arrayfl[i, j] = (i + j+1)*(i+j+1)/7.1;

string Arrayfl="\n";
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        Arrayfl=Arrayfl+ arrayfl[i, j].ToString()+" ";
        
    }
    Arrayfl = Arrayfl + "\n";
}
string k;
//если решили добавлять кол-во строк и столбцов в списке целых чисел
k="Array int, Strok "+n.ToString()+" Stolbcov "+n.ToString();
// если решил добавить список целых чисел
k = Arrayint;
// если решил добавить список целых чисел
k = Arrayfl;
//если решили добавлять кол-во строк и столбцов в списке дробных чисел
k = Arrayfl;
WriteFile(filePath,k);
WriteLine($"\nData read from the file:{ReadFile(filePath)}");