/**
 * Задание 3
 * Напишите функцию, которая определяет, попадает ли точка с вещественными координатами X,Y в заданную область.
 * Область показана на рисунке ниже серым цветом.
 * */

using System;
using System.Linq;

namespace exercise_2
{
    class Program
    {
        static bool InArea(double x, double y)//function: point in area or not.
        {
            double[] extaKeys = { 1, 2, 3, 4, 5, 6, 7, 8 };//area borders
            int funcY = (int)y;//parse to int to simplify calculations
            int funcX = (int)x;

            if(funcX >= 1 && (funcX <= 7 || x == 8))//borders on x coordinate
            {
                if (funcY >= 1 && (funcY <= funcX || extaKeys.Contains(y) && funcY == funcX + 1))//borders on y coordinate
                {
                    if (extaKeys.Contains(x) && !(y <= x) && !extaKeys.Contains(y)) return false;
                    return true;
                }
            }
            return false;
        }

        static double DoubleInput()//input double from keyboard
        {
            double input = 0;
            while (true)
                try { input = double.Parse(Console.ReadLine()); break; }
                catch (Exception) { Console.WriteLine("Error in input! Try again:"); }
            return input;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Program: point in area or not.");
            double x = 0;
            double y = 0;
            while(true)
            {
                Console.WriteLine("Enter x:");
                x = DoubleInput();
                Console.WriteLine("Enter y:");
                y = DoubleInput();
                Console.WriteLine("Point in area - " + InArea(x,y));
                Console.WriteLine("Input 'y' to try again with another coordinats or smth else to exit");
                if (Console.ReadKey().KeyChar != 'y') break;
                Console.WriteLine();
            }
        }
    }
}
