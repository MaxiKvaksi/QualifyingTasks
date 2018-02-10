/**
 * Задание 5
 * Дан массив целых чисел, в котором все числа, кроме одного, 
 * встречаются ровно два раза (например: 2, 5, 3, 8, 0, 5, 2, 0, 8).
 * Напишите программу, которая определяет то число, 
 * которое встречается ровно один раз (3 для приведенного выше массива).
 * */
using System;

namespace exercise_5
{
    class Program
    {
        static int[] readArrayFromConsole()//function for input parsing
        {
            string inputString;
            string[] stringsArray;
            int[] digitsArray = null;
            while (true)
            {
                Console.WriteLine("Enter array \n(array elements are separated by spaces), length of array is odd number:");
                while (true)//while input string emty
                {
                    if ((inputString = Console.ReadLine()).Length == 0) Console.WriteLine("Empty input! Try again:");
                    else break;
                }
                try//try to parce input string to int array
                {
                    stringsArray = inputString.Split(' ');
                    digitsArray = new int[stringsArray.Length];
                    for (int i = 0; i < stringsArray.Length; i++)
                    {
                        digitsArray[i] = int.Parse(stringsArray[i]);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Input parsing error!");
                }
                if (digitsArray.Length % 2 != 0)
                {
                    bool specialDigitIs = false;
                    BubbleSortArray(ref digitsArray);
                    for (int i = 0; i < digitsArray.Length - 1; i += 2)
                    {
                        if (digitsArray[i] != digitsArray[i + 1])
                        {
                            if (!specialDigitIs)
                            {
                                specialDigitIs = true;
                                i--;
                            }
                            else Console.WriteLine("More than 1 required digit in array!");
                        }
                    }
                    if (digitsArray[digitsArray.Length - 1] != digitsArray[digitsArray.Length - 2]) specialDigitIs = true;
                    if (specialDigitIs ) break;
                }
                else Console.WriteLine("length of array doesn't odd number!");
            }
            return digitsArray;
        }

        static void BubbleSortArray(ref int[] array)//array sort 
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
        }

        private static int SearchNumber(int[] array)//
        {
            int num = 0;
            bool numberFound = false;
            for (int i = 0; i < array.Length - 1; i+=2)
            {
                if (array[i] != array[i + 1])//pairwise comparison of array values
                {
                    num = array[i];
                    numberFound = true;
                    break;
                }
            }
            if (!numberFound) num = array[array.Length - 1];//if num not found in cycle then required num is last num
            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter an array: ");
            int[] array = readArrayFromConsole();
            Console.WriteLine("Required number is: " + SearchNumber(array));
            Console.ReadKey();
        }
    }
}
