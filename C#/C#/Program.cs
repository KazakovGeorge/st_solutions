using System.Numerics;
using System.IO;
using System.Text;

static class Program
{
    static void Main(string[] args)
    {
        NumManager manager = new NumManager();

        // Вызов методов
        int[] numArr = manager.get_num_arr("..\\..\\..\\nums.txt");
        int[] minMax = manager.get_min_max(numArr);
        long multiEven = manager.get_multi_even(numArr);

        // Вывод в консоль
        //for (int i = 0; i < numArr.Length; i++) { Console.WriteLine(i.ToString() + ": " + numArr[i].ToString()); }
        Console.WriteLine("Min/Max: " + minMax[0].ToString() + " | " + minMax[1].ToString());
        Console.WriteLine("MultiEven: " + multiEven.ToString());
    }
}

//  Описание класса
public class NumManager
{
    //  Метод возвращающий массив значений int из файла
    public int[] get_num_arr(string path)
    {
        int[] numArr = new int[0];

        using (FileStream file = new FileStream(path, FileMode.Open))
        {
            // выделяем массив для считывания данных из файла
            byte[] buffer = new byte[file.Length];
            // считываем данные
            file.ReadAsync(buffer, 0, buffer.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(buffer);

            string[] numArrStr = textFromFile.Split(new string[] {" "}, StringSplitOptions.None);
            int[] numArrLong = Array.ConvertAll(numArrStr, s => int.Parse(s));

            numArr = numArrLong;
        }

        return numArr;
    }

    // Метод нахождения мин и макс. Возвращает список list[minValue, maxValue]
    public int[] get_min_max(int[] numArr)
    {
        int min = numArr.Min();
        int max = numArr.Max();

        /*  если подробно
        int max = numArr[0];
        int min = numArr[0];

        for (int i = 0; i < numArr.Length; i++)
        {
            if (numArr[i] < min) { min = numArr[i]; }
            if (numArr[i] > max) { max = numArr[i]; }
        }
        */

        return new int[] { min, max };
    }

    public long get_multi_even(int[] numArr)
    {
        long result = 1;

        for(int i = 0; i < numArr.Length; i++)
        {
            if (numArr[i] % 2 == 0 && numArr[i] != 0)
            {
                result *= numArr[i];
            }
        }

        if (result == 1) { return 0; }
        else { return result; }
    }
}