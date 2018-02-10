/**
 * Задание 1
 * Дан массив целых чисел. Напишите функцию, которая получает данный массив в качестве аргумента
 * и сортирует его по возрастанию, а также программу для демонстрации работы этой функции. 
 * 
 * Задание 2
 * Напишите функцию, которая для отсортированного массива целых чисел определяет, 
 * содержится ли в нем заданное значение. 
*/
using System;

namespace exercise_1
{
    class Program
    {
        /**
         * Задание 1
         * */
        static void BubbleSortArray(ref int[] array)//Bubble sorting algorithm: sorting of neighboring elements
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                {
                    if(array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
        }

        static void ShellSortArray(ref int[] array)//Shell sorting algorithm: sorting elements at a certain step
        {
            int i, j, step;
            int temp;
            for (step = array.Length / 2; step > 0; step /= 2)
                for (i = step; i < array.Length; i++)
                {
                    temp = array[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (temp < array[j - step])
                            array[j] = array[j - step];
                        else
                            break;
                    }
                    array[j] = temp;
                }
        }

        static int[] readArrayFromConsole()//function for input parsing
        {
            string inputString;
            string[] stringsArray;
            int[] digitsArray = null;
            while (true)
            {
                Console.WriteLine("Enter array \n(array elements are separated by spaces):");
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
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Input parsing error!");
                }
            }
            return digitsArray;
        }

        static void ShowArray(int[] array)
        {
            Console.WriteLine("Sorted array:");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        /**
        * Задание 2
        * */
        private static bool searchInputDigitInArray(int digit, int[] digitsArray)//binary search
        {
            int leftSide = 0;
            int rightSide = digitsArray.Length;
            int middle = 0;

            while (!(leftSide >= rightSide))
            {
                middle = leftSide + (rightSide - leftSide) / 2;//array division into two parts
                if (digitsArray[middle] == digit)
                    return true;

                if (digitsArray[middle] > digit)
                    rightSide = middle;
                else
                    leftSide = middle + 1;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int[] digitsArray = null;
            byte flag = 0;//flag for choose sorting algorithm
            while (true)
            {
                digitsArray = readArrayFromConsole();
                while (true)
                {
                    Console.WriteLine("Sorting:\n1.Bubble\n2.Shell\n3.C# array sorting");
                    try
                    {
                        flag = byte.Parse(Console.ReadLine());
                        if (flag > 3 || flag < 1) throw new Exception();
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error in input! Try again:");
                    }
                }
                switch (flag)//kinds of sorting
                {
                    case 1: BubbleSortArray(ref digitsArray); ShowArray(digitsArray); break;
                    case 2: ShellSortArray(ref digitsArray); ShowArray(digitsArray); break;
                    case 3: Array.Sort(digitsArray); ShowArray(digitsArray); break;
                }
                char keyChar;
                Console.WriteLine("Enter 'n' to try sorting another array\nEnter 's' to search for a given number in an array\n" +
                    " else another to exit: ");
                keyChar = Console.ReadKey().KeyChar;
                if ('s' == keyChar)
                {
                    int digit = 0;
                    Console.WriteLine("Input digit:");
                    while (true)//cycle for the correct number entry
                    {
                        try
                        {
                            digit = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error in input! Try again:");
                        }
                    }
                    if (searchInputDigitInArray(digit, digitsArray)) Console.WriteLine("array contains this digit!");
                    else Console.WriteLine("array doesn't contains this digit!");
                    Console.WriteLine("Enter 'n' to try sorting another array\n " +
                   " else another to exit: ");
                    keyChar = Console.ReadKey().KeyChar;
                }
                if (!('n' == keyChar)) break;
                Console.WriteLine();
            }
        }

        /**
         * Another ways to search in C#: 
         * Array.IndexOf(digitsArray, digit)
         * Array.Exists(digitsArray, element => element == digit)
         */

        
    }
}
