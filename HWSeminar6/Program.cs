using MyMethodsJudisk;
using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

/*Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

0, 7, 8, -2, -2 -> 2

1, -7, 567, 89, 223-> 3*/
HWGBSeminar6();
void HWGBSeminar6()
{
    while (true)
    {
        Console.WriteLine("Введите  номера задачи 41 ,43(author:@Jane547547), 44 или exit для выхода ");
        string task = Console.ReadLine();
        switch (task)
        {
            case "41": Console.Clear(); Task41(); break;
            case "43J": Console.Clear(); Task43Jane54575457(); break;
            case "44": Console.Clear(); Task44(); break;
            case "exit": return; break;
            default: Console.Clear(); Console.WriteLine("Неверное значение"); break;
        }
    }
}

void Task41()
{
    JudMethod.TaskNum(41);// метод 19-22
    int count = 0;
    JudMethod.CountingNumbersGreatedZero(ref count);
}
//Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

//b1 = 2, k1 = 5, b2 = 4, k2 = 9-> (-0, 5; -0,5)

void Task43Jane54575457()//Решение нагло своровонное у Евгении чтобы напомнить себе потом что можно получше
{
    JudMethod.TaskNum(43);

    double b1 = JudMethod.SetNumberDouble("Введите число b1: ");//12-17
    double k1 = JudMethod.SetNumberDouble("Введите число k1: ");

    double b2 = JudMethod.SetNumberInt("Введите число b2: ");
    double k2 = JudMethod.SetNumberInt("Введите число k2: ");


    double x = (b2 - b1) / (k1 - k2);
    double y = k2 * x + b2;

    if ((y != k1 * x + b1) || (k1 - k2 == 0)) Console.WriteLine("Решений нет!");
    else Console.WriteLine($"Координаты пересечения двух прямых, x, y: ({x}) , ({y})");
}

//Задача 44:выведите первые N чисел
//Фибоначчи. Первые два числа Фибоначчи: 0 и 1.

void Task44()
{
    JudMethod.TaskNum(44);

    int PastNumber = 0;
    int NowNumber = 1;
    int NewNumber = 0;
    int toStop = JudMethod.SetNumberInt("Введите до какого числа вы хотите знать последовательность ");// метод строки 5-10
    int nowFibonacciNumber = 0;


    bool checkToStop() { return nowFibonacciNumber >= toStop; }

    FibonacciNumberRecursia(toStop, ref nowFibonacciNumber, ref PastNumber, ref NowNumber, ref NewNumber);

    void FibonacciNumberRecursia(int toStop, ref int nowFibonacciNumber, ref int PastNumberOut, ref int NowNumberOut, ref int NewNumber)
    {
        if (checkToStop()) { return; }

        if (nowFibonacciNumber == 0)
        {
            nowFibonacciNumber++;
            Console.Write($" 0 ");

            FibonacciNumberRecursia(toStop, ref nowFibonacciNumber, ref PastNumberOut, ref NowNumberOut, ref NewNumber);
        }
        else if (nowFibonacciNumber == 1)
        {
            nowFibonacciNumber++;
            Console.Write($" 1 ");

            FibonacciNumberRecursia(toStop, ref nowFibonacciNumber, ref PastNumberOut, ref NowNumberOut, ref NewNumber);
        }
        else if (nowFibonacciNumber >= 2)
        {
            nowFibonacciNumber++;

            NewNumber = NowNumberOut + PastNumberOut;
            PastNumberOut = NowNumberOut;
            NowNumberOut = NewNumber;

            Console.Write($" {NowNumberOut} ");

            FibonacciNumberRecursia(toStop, ref nowFibonacciNumber, ref PastNumberOut, ref NowNumberOut, ref NewNumber);
        }

    }
}