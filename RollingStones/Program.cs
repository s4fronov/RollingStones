using System;
using System.Collections.Generic;

namespace RollingStones
{
    class Program
    {
        static void Main(string[] args)
        {
            string condition1 = "";
            string condition2 = "";
            string condition3 = "";
            
            int value1 = 0;
            int value2 = 0;
            int value3 = 0;
            string symbol1 = "+";
            string symbol2 = "+";
            string symbol3 = "+";

            bool error;
            int total = 0;
            string pattern = @"([+*])+(\d+)";

            Console.WriteLine("Задача: Два игрока, Петя и Ваcя, играют в следующую игру. Перед игроками лежит куча камней. Игроки ходят по очереди, первый ход делает Петя. За один ход игрок может добавить в кучу разное количество камней или увеличить кучу в некоторое количество раз (3 варианта). У каждого игрока есть необходимое количество камней, чтобы делать ходы. Игра завершается, когда количество камней в куче становится не менее N. Победителем считается игрок, сделавший последний ход, то есть первым получивший кучу, в которой будет N или больше камней. В начальный момент в куче было S камней.");
            Console.WriteLine();
            Console.WriteLine("Введите свои условия и программа покажет: ");
            Console.WriteLine("Значения S (начальное число камней в куче), при которых у Пети есть выигрышная стратегия, причем Петя должен выиграть только за второй ход (независимо от того, как будет ходить Ваcя), и выигрышную стратегию для этого значения S.");            
            Console.WriteLine();
            Console.WriteLine("Введите условия игры:");

            do
            {
                error = false;
                try
                {
                    Console.Write("Количество камней для победы (N) = ");
                    total = Convert.ToInt32(Console.ReadLine());
                    Exceptions.CheckValue(total);
                }
                catch(Exceptions ex)
                {
                    Console.WriteLine(ex.Message);
                    error = true;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Неверный формат значения! Введите число.");
                    error = true;
                }
            }
            while (error);
            
            Console.WriteLine();
            Console.WriteLine("Введите условия увеличения количества камней в куче в формате '+x' или '*x' : ");

            do
            {
                error = true;
                try
                {
                    Console.Write("Условие #1: ");
                    condition1 = Console.ReadLine();
                    foreach (var expression in condition1)
                    {
                        foreach (System.Text.RegularExpressions.Match r in
                        System.Text.RegularExpressions.Regex.Matches(condition1, pattern))
                        {
                            value1 = Int32.Parse(r.Groups[2].Value);
                            symbol1 = r.Groups[1].Value;
                        }
                    }
                    Exceptions.CheckCondition(value1);
                }
                catch (Exceptions ex)
                {
                    Console.WriteLine(ex.Message);
                    error = false;
                }
            }
            while (error == false);

            do
            {
                error = false;
                try
                {
                    Console.Write("Условие #2: ");
                    condition2 = Console.ReadLine();
                    foreach (var expression in condition2)
                    {
                        foreach (System.Text.RegularExpressions.Match r in
                        System.Text.RegularExpressions.Regex.Matches(condition2, pattern))
                        {
                            value2 = Int32.Parse(r.Groups[2].Value);
                            symbol2 = r.Groups[1].Value;
                        }
                    }
                    Exceptions.CheckCondition(value2);
                    Exceptions.CheckDuplicate(condition1, condition2);
                }
                catch (Exceptions ex)
                {
                    Console.WriteLine(ex.Message);
                    error = true;
                }
            }
            while (error);

            do
            {
                error = true;
                try
                {
                    Console.Write("Условие #3: ");
                    condition3 = Console.ReadLine();
                    foreach (var expression in condition3)
                    {
                        foreach (System.Text.RegularExpressions.Match r in
                        System.Text.RegularExpressions.Regex.Matches(condition3, pattern))
                        {
                            value3 = Int32.Parse(r.Groups[2].Value);
                            symbol3 = r.Groups[1].Value;
                        }
                    }
                    Exceptions.CheckCondition(value3);
                    Exceptions.CheckDuplicate(condition1, condition2, condition3);
                }
                catch (Exceptions ex)
                {
                    Console.WriteLine(ex.Message);
                    error = false;
                }
            }
            while (error == false);

            int[] a = new int[3] { value1, value2, value3 };
            string[] b = new string[3] { symbol1, symbol2, symbol3 };

            Console.WriteLine("");            
            Console.WriteLine("Решение: ");
            Tasks f = new Tasks();            
            Turns.listOfSForWin = new List<int>();
            Turns.listOfVasyaFirst = new List<int>();            
            f.CreateGraph(total, a, b);            
            f.ShowResult(total, a, b);            
        }
    }
}
