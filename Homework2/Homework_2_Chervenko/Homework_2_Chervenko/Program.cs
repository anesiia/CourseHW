using System;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework_2_Chervenko
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // я не була впевнена, чи необхідно шукати ЦИФРИ и ЧИСЛА, 
            // тому я зробила складніший варіант :)

            string text1 = "Lalala 12 i want to buy 950 bananas " +
                "and k1ll all bees in the w0rld because i have an a11ergy100!";
            List<int> firstTaskList = ExtractNumbers(text1);

            int sum = 0;
            foreach (int number in firstTaskList)
            {
                sum += number;
            }

            Console.WriteLine("---First Task---");
            Console.WriteLine("Sum: " + sum + 
                "\r\nMax number: " + firstTaskList.Max());

            string text2 = "       Lalala12iwanttobuy950bananasandk1llallbees" +
                "inthew0rldbecauseihave950ana11ergy100!";
            int maxIndexExceptSpaces = FindIndexOfMaxNumberWithoutSpaces(text2);

            Console.WriteLine("---Second Task---");
            Console.WriteLine("Position of max number " +
                "without spaces: " + (maxIndexExceptSpaces + 1));

            // сто книг вручну ініціалізувати думаю недоречно, тому не писала
            int[] booksPages = { 10, 56, 92, 12, 34, 546, 734, 43, 277, 90 };

            // це завданя мені здалося занадто простим, тож
            // я подумала що треба зосередитися на ефективності
            // для часу та памяті та вирішила зробити простий
            // лінійний пошук замість максимуму з LINQ
            Console.WriteLine("---Third Task---");
            Console.WriteLine("Max: " + FindMax(booksPages));

            // і це завдання дуже схоже, але моєю метою 
            // було зробити це за 1 обхід масиву, а не 2
            int[] speedMaximums = { 120, 170, 240, 90, 360, 300, 190, 210, 360 };
            var result = FindAllMaximums(speedMaximums);

            Console.WriteLine("---Fourth Task---");
            Console.WriteLine($"а) First fastest car: {result.firstIndex + 1}");
            if (result.firstIndex != result.lastIndex)
                Console.WriteLine($"б) Last fastest car: {result.lastIndex + 1}");
        }

        public static List<int> ExtractNumbers(string text)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsNumber(text[i]))
                {
                    int j = i + 1;
                    while (j < text.Length && Char.IsNumber(text[j]))
                    {
                        j++;
                    }

                    string extractedNumber = text.Substring(i, j - i);
                    numbers.Add(Int32.Parse(extractedNumber));
                    i = j - 1;
                }
            }

            return numbers;
        }

        public static int FindIndexOfMaxNumberWithoutSpaces(string text)
        {
            List<int> secondTaskList = ExtractNumbers(text);

            int maxNumber = secondTaskList.Max();
            int maxIndex = text.IndexOf(maxNumber.ToString());
            int maxIndexExceptSpaces = 0;

            for (int i = 0; i < maxIndex; i++)
            {
                if (text[i] != ' ')
                {
                    maxIndexExceptSpaces++;
                }
            }

            return maxIndexExceptSpaces;
        }

        public static int FindMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        public static (int firstIndex, int lastIndex) FindAllMaximums(int[] arr)
        {
            int max = arr[0];
            int firstIndex = 0;
            int lastIndex = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    firstIndex = i;
                    lastIndex = i;
                }
                else if (arr[i] == max)
                {
                    lastIndex = i;
                }
            }

            return (firstIndex, lastIndex);
        }
    }
}