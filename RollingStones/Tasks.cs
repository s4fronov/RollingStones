using System;
using System.Collections.Generic;
using System.Text;

namespace RollingStones
{
    public class Tasks
    {
        Node start;
        List<int> stones;       

        public Tasks()
        {
            start = new Node();
            stones = new List<int>();            
        }

        public void CreateGraph(int k, int[] a, string[] b)
        {            
            for(int i = 1; i < k - 1; i++)
            {
                stones.Add(i);
            }
            start.CreateBranchesOfTurns(stones, k, a, b);            
        }

        public int FindBadValue(int k, int[] a, string[] b)
        {
            int var1, var2, var3;
            if (b[0] == "+")
            {
                var1 = k - a[0];
            }
            else
            {
                var1 = (int)Math.Ceiling(k / (double)a[0]);
            }
            if (b[1] == "+")
            {
                var2 = k - a[1];
            }
            else
            {
                var2 = (int)Math.Ceiling(k / (double)a[1]);
            }
            if (b[2] == "+")
            {
                var3 = k - a[2];
            }
            else
            {
                var3 = (int)Math.Ceiling(k / (double)a[2]);
            }
            int var4 = Math.Min(var1, var2);
            int var = Math.Min(var4, var3);
            return var - 1;
        }

        public void ShowResult(int k, int[] a, string[] b)
        {            
            int value = FindBadValue(k, a, b);            
            start.CreateListsOfStoneNumber(value);
            Console.Write("1. Значения S, при которых Петя не сможет выиграть в свой первый ход, но 100% выиграет во второй: ");
            foreach (int val in Turns.listOfSForWin)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("2. Возможные стратегии Пети: ");
            Console.WriteLine("   Петин первый ход: ");
            Strategies s = new Strategies();
            s.FirstTurnOfPlayer1(value, a, b);
            Console.WriteLine("   Васин первый ход: ");
            s.FirstTurnOfPlayer2(value, a, b);
            Console.WriteLine("   Петин последний ход: ");
            s.SecondTurnOfPlayer1(k, a, b);
        }
    }
}
