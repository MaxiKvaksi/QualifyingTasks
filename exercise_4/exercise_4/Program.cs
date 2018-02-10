/**
 * Задание 4
 * Напишите программу, которая определяет сумму целых чисел из интервала от 1 до 1000,
 * которые делятся без остатка на 3 или на 5. 
 * */
using System;

namespace exercise_4
{
    class Program
    {
        static System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();

        static int FirstAlgorithm()
        {
            int sum = 0;
            myStopwatch.Start();
            for (int i = 1; i <= 1000; i++)
            {
                if (i % 5 == 0 || i % 3 == 0) sum += i;
            }
            myStopwatch.Stop();
            Console.WriteLine("1 algorithm time:" + myStopwatch.Elapsed);
            myStopwatch.Reset();
            return sum;
        }

        static int SecondAlgorithm()
        {
            int sum5 = 0;
            int sum3 = 0;
            int x = 0;
            myStopwatch.Start();
            do
            {
                sum5 += x;
                x += 5;
            } while (x <= 1000);
            x = 0;
            do
            {
                sum3 += (x % 5 == 0) ? 0 : x;
                x += 3;
            } while (x <= 1000);
            myStopwatch.Stop();
            Console.WriteLine("2 algorithm time:" + myStopwatch.Elapsed);
            myStopwatch.Reset();
            return sum3 + sum5;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("sum of numbers that are divided by 3 or 5 in [1..1000]:(1 alg/2 alg)\n" 
                + FirstAlgorithm() + "/" + SecondAlgorithm());
            Console.ReadKey();
        }
    }
}
