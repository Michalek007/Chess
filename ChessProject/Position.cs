using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject
{
    class Position
    {
        public static void PiecePosition(int x, int y, ChessPieces name, int z)
        {
            x = 9*x;
            y = 46 - 5*y;
            int s = 9 * name.X;
            int t = 46 - 5 * name.Y;
            for (int a = 0; a < 8; a++)
            {
                for (int i = 0; i < 8; i++)
                {
                    //if (x == 1+ a && y == 1 + i)
                    //{
                    //    Console.SetCursorPosition(x, y);
                    //    Console.WriteLine("Q");
                    //}
                    if (s == 9 + 9 * a && t == 6 + 5 * i)
                    {
                        Console.SetCursorPosition(s, t);
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(s, t+1);
                        Console.WriteLine("  ");
                    }
                    if (x == 9 + 9 * a && y == 6 + 5 * i)
                    {
                        Console.SetCursorPosition(x-2, y);
                        Console.WriteLine(name.Symbol);
                        Console.SetCursorPosition(x - 2, y+1);
                        Console.WriteLine("  " + z + "  ");
                    }
                }
            }

           
        }
    }
}
