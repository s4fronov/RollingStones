using System;
using System.Collections.Generic;
using System.Text;

namespace RollingStones
{
    public class Strategies
    {
        
        public Strategies()
        {            
        }

        public void FirstTurnOfPlayer1 (int badValue, int[] a, string[] b)
        {
            foreach (int v in Turns.listOfSForWin)
            {
                if (b[0] == "+" && v + a[0] == badValue)
                { Console.WriteLine($"    Если камушков {v}, то он прибавляет {a[0]} и получается {badValue} штук(и)"); }
                else if (b[0] == "*" && v * a[0] == badValue)
                { Console.WriteLine($"    Если камушков {v}, то он увеличивает в {a[0]} раз(а) и получается {badValue} штук(и)"); }

                if (b[1] == "+" && v + a[1] == badValue)
                { Console.WriteLine($"    Если камушков {v}, то он прибавляет {a[1]} и получается {badValue} штук(и)"); }
                else if(b[1] == "*" && v * a[1] == badValue)
                { Console.WriteLine($"    Если камушков {v}, то он увеличивает в {a[1]} раз(а) и получается {badValue} штук(и)"); } 

                if (b[2] == "+" && v + a[2] == badValue)
                { Console.WriteLine($"    Если камушков {v}, то он прибавляет {a[2]} и получается {badValue} штук(и)"); }
                else if (b[2] == "*" && v * a[2] == badValue)
                { Console.WriteLine($"    Если камушков {v}, то он увеличивает в {a[2]} раз(а) и получается {badValue} штук(и)"); }
            }
        }

        public void FirstTurnOfPlayer2(int badValue, int[] a, string[] b)
        {
            if (b[0] == "+")
            { Console.WriteLine($"    Вася может добавить {a[0]} и получается {badValue + a[0]} штук(и)"); }
            else 
            { Console.WriteLine($"    Вася может увеличить в {a[0]} раз(а) и получается {badValue * a[0]} штук(и)"); }

            if (b[1] == "+")
            { Console.WriteLine($"    Вася может добавить {a[1]} и получается {badValue + a[1]} штук(и)"); }
            else
            { Console.WriteLine($"    Вася может увеличить в {a[1]} раз(а) и получается {badValue * a[1]} штук(и)"); }

            if (b[2] == "+")
            { Console.WriteLine($"    Вася может добавить {a[2]} и получается {badValue + a[2]} штук(и)"); }
            else
            { Console.WriteLine($"    Вася может увеличить в {a[2]} раз(а) и получается {badValue * a[2]} штук(и)"); }            
        }

        public void SecondTurnOfPlayer1(int k, int[] a, string[] b)
        {
            foreach (int v in Turns.listOfVasyaFirst)
            {
                if (b[0] == "+" && v + a[0] >= k)
                { Console.WriteLine($"    Если камушков получилось {v}, то Петя прибавляет {a[0]} и получается {v + a[0]} штук(и)"); }
                else if (b[0] == "*" && v * a[0] >= k)
                { Console.WriteLine($"    Если камушков получилось {v}, то Петя увеличивает их в {a[0]} раз(а) и получается {v * a[0]} штук(и)"); }

                if (b[1] == "+" && v + a[1] >= k)
                { Console.WriteLine($"    Если камушков получилось {v}, то Петя прибавляет {a[1]} и получается {v + a[1]} штук(и)"); }
                else if (b[1] == "*" && v * a[1] >= k)
                { Console.WriteLine($"    Если камушков получилось {v}, то Петя увеличивает их в {a[1]} раз(а) и получается {v * a[1]} штук(и)"); }

                if (b[2] == "+" && v + a[2] >= k)
                { Console.WriteLine($"    Если камушков получилось {v}, то Петя прибавляет {a[2]} и получается {v + a[2]} штук(и)"); }
                else if (b[2] == "*" && v * a[2] >= k)
                { Console.WriteLine($"    Если камушков получилось {v}, то Петя увеличивает их в {a[2]} раз(а) и получается {v * a[2]} штук(и)"); }
            }
        }
    }
}
