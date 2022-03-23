using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChessProject
{
    class Rook : ChessPieces
    {
        public Rook(int x, int y, Color name, PictureBox box)
        {
            X = x;
            Y = y;
            color = name;
            Box = box;
            Symbol = "  R  ";
        }
        public bool AllowedMoves(int x, int y, List<ChessPieces> white, List<ChessPieces> black)
        {
            if (x > 8)
            {
                return false;
            }
            if (y > 8)
            {
                return false;
            }
            if (x < 1)
            {
                return false;
            }
            if (y < 1)
            {
                return false;
            }
            for (int i = 1; i < 9 - X; i++)
            {

                if (x == X + i && y == Y)
                {
                    for (int o = 1; o < x - X; o++)
                    {

                        for (int a = 0; a < white.Count; a++)
                        {
                            if (white[a].X == X + o && white[a].Y == Y)
                            {
                                return false;
                            }
                        }
                        for (int b = 0; b < black.Count; b++)
                        {
                            if (black[b].X == X + o && black[b].Y == Y)
                            {
                                return false;
                            }
                        }
                    }

                    return true;

                }

            }
            for (int i = 1; i < 9 - Y; i++)
            {
                if (x == X && y == Y + i)
                {
                    for (int o = 1; o < y - Y; o++)
                    {
                        for (int a = 0; a < white.Count; a++)
                        {
                            if (white[a].X == X && white[a].Y == Y + o)
                            {
                                return false;
                            }
                        }
                        for (int b = 0; b < black.Count; b++)
                        {
                            if (black[b].X == X && black[b].Y == Y + o)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
            for (int i = 1; i < X; i++)
            {
                if (x == X - i && y == Y)
                {
                    for (int o = 1; o < X - x; o++)
                    {
                        for (int a = 0; a < white.Count; a++)
                        {
                            if (white[a].X == X - o && white[a].Y == Y)
                            {
                                return false;
                            }
                        }
                        for (int b = 0; b < black.Count; b++)
                        {
                            if (black[b].X == X - o && black[b].Y == Y)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
            for (int i = 1; i < Y; i++)
            {
                if (x == X && y == Y - i)
                {
                    for (int o = 1; o < Y - y; o++)
                    {
                        for (int a = 0; a < white.Count; a++)
                        {
                            if (white[a].X == X && white[a].Y == Y - o)
                            {
                                return false;
                            }
                        }
                        for (int b = 0; b < black.Count; b++)
                        {
                            if (black[b].X == X && black[b].Y == Y - o)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
          

            return false;

        }
    }
}
