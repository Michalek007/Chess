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
    class ChessPieces
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Symbol { get; set; }
        public PictureBox Box { get; set; }
        public enum Color
        {
            black,
            white
        }
        public enum Type
        {
            king,
            queen,
            bishop,
            knight,
            rook,
            pone
        }       
        public Color color { get; set; }
        public Type fType { get; set; }
        ChessPieces(int x, int y, Type type, Color fcolor, PictureBox box)
        {
            X = x;
            Y = y;
            fType = type;
            color = fcolor;
            Box = box;
            if (type == Type.king)
            {
                if (fcolor == Color.white)
                {
                    Symbol.Append('K');
                }
                if (fcolor == Color.black)
                {
                    Symbol.Append('k');
                }
            }
            if (type == Type.queen)
            {
                if (fcolor == Color.white)
                {
                    Symbol.Append('Q');
                }
                if (fcolor == Color.black)
                {
                    Symbol.Append('q');
                }
            }
            if (type == Type.bishop)
            {
                if (fcolor == Color.white)
                {
                    Symbol.Append('B');
                }
                if (fcolor == Color.black)
                {
                    Symbol.Append('b');
                }
            }
            if (type == Type.knight)
            {
                if (fcolor == Color.white)
                {
                    Symbol.Append('N');
                }
                if (fcolor == Color.black)
                {
                    Symbol.Append('n');
                }
            }
            if (type == Type.rook)
            {
                if (fcolor == Color.white)
                {
                    Symbol.Append('R');
                }
                if (fcolor == Color.black)
                {
                    Symbol.Append('r');
                }
            }      
            if (type == Type.pone)
            {
                if (fcolor == Color.white)
                {
                    Symbol.Append('P');
                }
                if (fcolor == Color.black)
                {
                    Symbol.Append('p');
                }
            }         
            char v = (char)(y+48);
            char h = (char)(x+96);
            Symbol.Append(h);
            Symbol.Append(v);     
        }
        public static bool AllowedMoves(int x, int y, List<ChessPieces> pieces)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].X == x && pieces[i].Y == y)
                {
                    return false;
                }

            }
            return true;
        }
        public bool AllowedMoves(int x, int y, List<ChessPieces> white, List<ChessPieces> black, Color name, int use)
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
            if (fType == Type.queen || fType == Type.rook)
            {
                for (int i = 1; i < 9 - X; i++)
                {
                    if (x == X + i && y == Y)
                    {
                        for (int o = 1; o < x - X; o++)
                        {
                            for (int a = 0; a < white.Count; a++)
                            {
                                if (name == Color.white)
                                {
                                    if (white[a].X == X + o && white[a].Y == Y)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X + o && white[a].Y == Y)
                                    {
                                        return false;
                                    }
                                }

                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X + o && black[b].Y == Y)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X + o && black[b].Y == Y)
                                    {
                                        return false;
                                    }
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
                                if (name == Color.white)
                                {
                                    if (white[a].X == X && white[a].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X && white[a].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }
                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X && black[b].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X && black[b].Y == Y + o)
                                    {
                                        return false;
                                    }
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
                                if (name == Color.white)
                                {
                                    if (white[a].X == X - o && white[a].Y == Y)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X - o && white[a].Y == Y)
                                    {
                                        return false;
                                    }
                                }

                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X - o && black[b].Y == Y)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X - o && black[b].Y == Y)
                                    {
                                        return false;
                                    }
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
                                if (name == Color.white)
                                {
                                    if (white[a].X == X && white[a].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X && white[a].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }

                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X && black[b].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X && black[b].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }

                            }
                        }

                        return true;
                    }
                }
                if (this.GetType() == typeof(Rook))
                {
                    return false;
                }
            }
            if (fType == Type.queen || fType == Type.bishop)
            {
                for (int i = 1; i < 9; i++)
                {
                    if (x == X + i && y == Y + i)
                    {
                        for (int o = 1; o < x - X; o++)
                        {
                            for (int a = 0; a < white.Count; a++)
                            {
                                if (name == Color.white)
                                {
                                    if (white[a].X == X + o && white[a].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X + o && white[a].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }

                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X + o && black[b].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X + o && black[b].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }

                            }
                        }

                        return true;
                    }
                }
                for (int i = 1; i < 9; i++)
                {
                    if (x == X - i && y == Y - i)
                    {
                        for (int o = 1; o < X - x; o++)
                        {
                            for (int a = 0; a < white.Count; a++)
                            {
                                if (name == Color.white)
                                {
                                    if (white[a].X == X - o && white[a].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X - o && white[a].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }

                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X - o && black[b].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X - o && black[b].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }

                            }
                        }

                        return true;
                    }
                }
                for (int i = 1; i < 9; i++)
                {
                    if (x == X + i && y == Y - i)
                    {
                        for (int o = 1; o < x - X; o++)
                        {
                            for (int a = 0; a < white.Count; a++)
                            {
                                if (name == Color.white)
                                {
                                    if (white[a].X == X + o && white[a].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X + o && white[a].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }

                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X + o && black[b].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X + o && black[b].Y == Y - o)
                                    {
                                        return false;
                                    }
                                }

                            }
                        }

                        return true;
                    }
                }
                for (int i = 1; i < 9; i++)
                {
                    if (x == X - i && y == Y + i)
                    {
                        for (int o = 1; o < X - x; o++)
                        {
                            for (int a = 0; a < white.Count; a++)
                            {
                                if (name == Color.white)
                                {
                                    if (white[a].X == X - o && white[a].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (white[a].fType == Type.king)
                                    {

                                    }
                                    else if (white[a].X == X - o && white[a].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }

                            }
                            for (int b = 0; b < black.Count; b++)
                            {
                                if (name == Color.black)
                                {
                                    if (black[b].X == X - o && black[b].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (black[b].fType == Type.king)
                                    {

                                    }
                                    else if (black[b].X == X - o && black[b].Y == Y + o)
                                    {
                                        return false;
                                    }
                                }

                            }
                        }

                        return true;
                    }
                }
                return false;
            }
            if (fType == Type.king)
            {

                if ((x == X || x == X + 1 || x == X - 1) && (y == Y || y == Y + 1 || y == Y - 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (fType == Type.knight)
            {
                if (x == X + 2 && y == Y + 1)
                {
                    return true;
                }
                if (x == X + 2 && y == Y - 1)
                {
                    return true;
                }
                if (x == X - 2 && y == Y + 1)
                {
                    return true;
                }
                if (x == X - 2 && y == Y - 1)
                {
                    return true;
                }
                if (x == X + 1 && y == Y + 2)
                {
                    return true;
                }
                if (x == X - 1 && y == Y + 2)
                {
                    return true;
                }
                if (x == X + 1 && y == Y - 2)
                {
                    return true;
                }
                if (x == X - 1 && y == Y - 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (fType == Type.pone)
            {
                if (use == 0)
                {   
                    if (name == Color.white)
                    {
                        if (x == X && y == Y + 1)
                        {
                            for (int i = 0; i < black.Count; i++)
                            {
                                if (black[i].X == x && black[i].Y == y)
                                {
                                    return false;
                                }
                            }
                            for (int i = 0; i < white.Count; i++)
                            {
                                if (white[i].X == x && white[i].Y == y)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }


                        for (int i = 0; i < black.Count; i++)
                        {
                            if (black[i].X == X - 1 && black[i].Y == Y + 1)
                            {
                                if (x == X - 1 && y == Y + 1)
                                {
                                    return true;
                                }
                            }
                            if (black[i].X == X + 1 && black[i].Y == Y + 1)
                            {
                                if (x == X + 1 && y == Y + 1)
                                {
                                    return true;
                                }
                            }
                        }
                        if (Y == 2)
                        {
                            if (X == x && y == Y + 2)
                            {
                                for (int i = 0; i < black.Count; i++)
                                {
                                    if (black[i].X == x && black[i].Y == y)
                                    {
                                        return false;
                                    }

                                }
                                for (int i = 0; i < white.Count; i++)
                                {
                                    if (white[i].X == x && white[i].Y == y)
                                    {
                                        return false;
                                    }
                                }
                                return true;
                            }
                        }

                    }
                    if (name == Color.black)
                    {
                        if (x == X && y == Y - 1)
                        {
                            for (int i = 0; i < white.Count; i++)
                            {
                                if (white[i].X == x && white[i].Y == y)
                                {
                                    return false;
                                }
                            }
                            for (int i = 0; i < black.Count; i++)
                            {
                                if (black[i].X == x && black[i].Y == y)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                        for (int i = 0; i < white.Count; i++)
                        {
                            if (white[i].X == X - 1 && white[i].Y == Y - 1)
                            {
                                if (x == X - 1 && y == Y - 1)
                                {
                                    return true;
                                }
                            }
                            if (white[i].X == X + 1 && white[i].Y == Y - 1)
                            {
                                if (x == X + 1 && y == Y - 1)
                                {
                                    return true;
                                }
                            }
                        }
                        if (Y == 7)
                        {
                            for (int i = 0; i < white.Count; i++)
                            {
                                if (white[i].X == x && white[i].Y == y)
                                {
                                    return false;
                                }
                            }
                            for (int i = 0; i < black.Count; i++)
                            {
                                if (black[i].X == x && black[i].Y == y)
                                {
                                    return false;
                                }
                            }
                            if (X == x && y == Y - 2)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }
                else
                {
                    if (name == Color.white)
                    {
                        if ((x == X + 1 || x == X - 1) && y == Y + 1)
                        {
                            return true;
                        }
                    }
                    if (name == Color.black)
                    {
                        if ((x == X + 1 || x == X - 1) && y == Y - 1)
                        {
                            return true;
                        }
                    }

                }
                return false;
            }
            return false;

        }
        public static bool AllowedMovesKing(int x, int y, List<ChessPieces> pieces, List<ChessPieces> pieces2, Color name)
        {
            if (name == Color.white)
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i].AllowedMoves(x, y, pieces, pieces2, name, 1) == true)
                    {
                        return false;
                    }

                }
            }
            if (name == Color.black)
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i].AllowedMoves(x, y, pieces2, pieces, name, 1) == true)
                    {
                        return false;
                    }

                }

            }

            return true;
        }
        public bool Castle(int x, int y, List<ChessPieces> white, List<ChessPieces> black, Color name)
        {
            if ((x != 7 && y != 1) || (x != 7 && y != 8))
            {
                return false;
            }

            if (x == X + 2 && y == Y)
            {
                for (int i = 0; i < white.Count; i++)
                {
                    if ((white[i].X == X + 1 || white[i].X == X + 2) && white[i].Y == Y)
                    {
                        return false;
                    }
                }
                for (int i = 0; i < black.Count; i++)
                {
                    if ((black[i].X == X + 1 || black[i].X == X + 2) && black[i].Y == Y)
                    {
                        return false;
                    }

                }
                if (name == Color.white)
                {
                    if (AllowedMovesKing(x, y, black, white, Color.black) == false)
                    {
                        return false;
                    }
                    if (AllowedMovesKing(x - 1, y, black, white, Color.black) == false)
                    {
                        return false;
                    }
                    //for (int i = 0; i < black.Count; i++)
                    //{
                    //    if ((black[i].AllowedMoves(6,1,white,black,Color.black,0) == true || black[i].AllowedMoves(7, 1, white, black, Color.black,0) == true) && black[i].Y == Y)
                    //    {
                    //        return false;
                    //    }

                    //}
                }
                if (name == Color.black)
                {
                    if (AllowedMovesKing(x, y, white, black, Color.white) == false)
                    {
                        return false;
                    }
                    if (AllowedMovesKing(x - 1, y, white, black, Color.white) == false)
                    {
                        return false;
                    }

                }
                return true;

            }
            return false;
        }
        public bool CastleL(int x, int y, List<ChessPieces> white, List<ChessPieces> black, Color name)
        {
            if ((x != 3 && y != 1) || (x != 3 && y != 8))
            {
                return false;
            }
            if (x == X - 2 && y == Y)
            {
                for (int i = 0; i < white.Count; i++)
                {
                    if ((white[i].X == X - 1 || white[i].X == X - 2) && white[i].Y == Y)
                    {
                        return false;
                    }
                }
                for (int i = 0; i < black.Count; i++)
                {
                    if ((black[i].X == X - 1 || black[i].X == X - 2) && black[i].Y == Y)
                    {
                        return false;
                    }

                }
                if (name == Color.white)
                {
                    if (AllowedMovesKing(x, y, black, white, Color.black) == false)
                    {
                        return false;
                    }
                    if (AllowedMovesKing(x + 1, y, black, white, Color.black) == false)
                    {
                        return false;
                    }
                    //for (int i = 0; i < black.Count; i++)
                    //{
                    //    if ((black[i].AllowedMoves(6,1,white,black,Color.black,0) == true || black[i].AllowedMoves(7, 1, white, black, Color.black,0) == true) && black[i].Y == Y)
                    //    {
                    //        return false;
                    //    }

                    //}

                }
                if (name == Color.black)
                {
                    if (AllowedMovesKing(x, y, white, black, Color.white) == false)
                    {
                        return false;
                    }
                    if (AllowedMovesKing(x + 1, y, white, black, Color.white) == false)
                    {
                        return false;
                    }

                }
                return true;


            }
            return false;
        }
        public bool Block(int x, int y, List<ChessPieces> white, List<ChessPieces> black, Color name, int use)
        {
            if (name == Color.white && use != 1)
            {
                for (int i = 0; i < white.Count; i++)
                {
                    if (X == white[i].X && Y == white[i].Y)
                    {
                        List<ChessPieces> neWhite = new List<ChessPieces>();
                        foreach (ChessPieces z in white)
                        {
                            neWhite.Add(z);
                        }
                        neWhite.RemoveAt(i);
                        ChessPieces check = ChessPieces.TypeOfPieces(white[0].X, white[0].Y, neWhite, black, ChessPieces.Color.black);
                        int a = check.X;
                        int b = check.Y;
                        if (this.Cover(x, y, check, white[0], neWhite, black) == true || (x == a && y == b))
                        {
                            neWhite.Clear();
                            return true;
                        }
                        if (ChessPieces.AllowedMovesKing(neWhite[0].X, neWhite[0].Y, black, neWhite, Color.black) == false)
                        {
                            neWhite.Clear();
                            return false;
                        }
                        neWhite.Clear();
                    }

                }
            }
            if (name == Color.black && use != 1)
            {
                for (int i = 0; i < black.Count; i++)
                {
                    if (X == black[i].X && Y == black[i].Y)
                    {
                        List<ChessPieces> newBlack = new List<ChessPieces>();
                        foreach (ChessPieces z in black)
                        {
                            newBlack.Add(z);
                        }
                        newBlack.RemoveAt(i);
                        ChessPieces check = ChessPieces.TypeOfPieces(newBlack[0].X, newBlack[0].Y, white, newBlack, ChessPieces.Color.white);
                        int a = check.X;
                        int b = check.Y;
                        if (this.Cover(x, y, check, white[0], newBlack, black) == true || (x == a && y == b))
                        {
                            newBlack.Clear();
                            return true;
                        }
                        if (ChessPieces.AllowedMovesKing(newBlack[0].X, newBlack[0].Y, white, newBlack, Color.white) == false)
                        {
                            newBlack.Clear();
                            return false;
                        }
                    }

                }

            }
            if (name == Color.white && use == 1)
            {
                for (int i = 0; i < white.Count; i++)
                {
                    if (X == white[i].X && Y == white[i].Y)
                    {
                        List<ChessPieces> neWhite = new List<ChessPieces>();
                        foreach (ChessPieces z in white)
                        {
                            neWhite.Add(z);
                        }
                        List<ChessPieces> newBlack = new List<ChessPieces>();
                        foreach (ChessPieces z in black)
                        {
                            newBlack.Add(z);
                        }
                        int k = neWhite[i].X;
                        int l = neWhite[i].Y;
                        neWhite[i].X = x;
                        neWhite[i].Y = y;
                        for (int o = 0; o < newBlack.Count; o++)
                        {
                            if (x == newBlack[o].X && y == newBlack[o].Y)
                            {
                                newBlack.RemoveAt(o);

                            }

                        }
                        if (ChessPieces.AllowedMovesKing(neWhite[0].X, neWhite[0].Y, newBlack, neWhite, Color.black) == false)
                        {
                            neWhite[i].X = k;
                            neWhite[i].Y = l;
                            newBlack.Clear();
                            neWhite.Clear();
                            return false;
                        }
                        neWhite[i].X = k;
                        neWhite[i].Y = l;
                        newBlack.Clear();
                        neWhite.Clear();
                    }

                }
            }
            if (name == Color.black && use == 1)
            {
                for (int i = 0; i < black.Count; i++)
                {
                    if (X == black[i].X && Y == black[i].Y)
                    {
                        List<ChessPieces> newBlack = new List<ChessPieces>();
                        foreach (ChessPieces z in black)
                        {
                            newBlack.Add(z);
                        }
                        List<ChessPieces> neWhite = new List<ChessPieces>();
                        foreach (ChessPieces z in white)
                        {
                            neWhite.Add(z);
                        }
                        int k = newBlack[i].X;
                        int l = newBlack[i].Y;
                        newBlack[i].X = x;
                        newBlack[i].Y = y;
                        for (int o = 0; o < neWhite.Count; o++)
                        {
                            if (x == neWhite[o].X && y == neWhite[o].Y)
                            {
                                neWhite.RemoveAt(o);

                            }

                        }
                        if (ChessPieces.AllowedMovesKing(newBlack[0].X, newBlack[0].Y, neWhite, newBlack, Color.white) == false)
                        {
                            newBlack[i].X = k;
                            newBlack[i].Y = l;
                            newBlack.Clear();
                            neWhite.Clear();
                            return false;
                        }
                        newBlack[i].X = k;
                        newBlack[i].Y = l;
                        newBlack.Clear();
                        neWhite.Clear();
                    }

                }

            }
            return true;
        }
        public bool Cover(int x, int y, ChessPieces name, ChessPieces king, List<ChessPieces> white, List<ChessPieces> black)
        {
            if (name.color == Color.black)
            {
                for (int i = 0; i < black.Count; i++)
                {
                    if (black[i].AllowedMoves(x, y, white, black, name.color, 0) == true)
                    {
                        int z = 0;
                        z++;
                        if (z == 2)
                        {
                            return false;
                        }
                    }


                }
            }
            if (name.color == Color.white)
            {
                for (int i = 0; i < white.Count; i++)
                {
                    if (white[i].AllowedMoves(x, y, white, black, name.color, 0) == true)
                    {
                        int z = 0;
                        z++;
                        if (z == 2)
                        {
                            return false;
                        }
                    }


                }
            }
            if (name.Y == king.Y && name.X < king.X)
            {
                for (int i = 1; i < king.X - name.X; i++)
                {
                    if (x == name.X + i && y == name.Y)
                    {
                        return true;
                    }
                }
            }
            else if (name.Y == king.Y && name.X > king.X)
            {
                for (int i = 1; i < name.X - king.X; i++)
                {
                    if (x == name.X - i && y == name.Y)
                    {
                        return true;
                    }
                }
            }
            else if (name.Y < king.Y && name.X == king.X)
            {
                for (int i = 1; i < king.Y - name.Y; i++)
                {
                    if (x == name.X && y == name.Y + i)
                    {
                        return true;
                    }
                }
            }
            else if (name.Y > king.Y && name.X == king.X)
            {
                for (int i = 1; i < name.Y - king.Y; i++)
                {
                    if (x == name.X && y == name.Y - i)
                    {
                        return true;
                    }
                }
            }
            else if (name.Y > king.Y && name.X > king.X)
            {
                for (int i = 1; i < name.X - king.X; i++)
                {
                    if (x == name.X - i && y == name.Y - i)
                    {
                        return true;
                    }
                }
            }
            else if (name.Y < king.Y && name.X < king.X)
            {
                for (int i = 1; i < king.X - name.X; i++)
                {
                    if (x == name.X + i && y == name.Y + i)
                    {
                        return true;
                    }
                }
            }
            else if (name.Y > king.Y && name.X < king.X)
            {
                for (int i = 1; i < king.X - name.X; i++)
                {
                    if (x == name.X + i && y == name.Y - i)
                    {
                        return true;
                    }
                }

            }
            else if (name.Y < king.Y && name.X > king.X)
            {
                for (int i = 1; i < name.X - king.X; i++)
                {
                    if (x == name.X - i && y == name.Y + i)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        public static ChessPieces TypeOfPieces(int x, int y, List<ChessPieces> pieces, List<ChessPieces> pieces2, Color name)
        {
            if (name == Color.black)
            {
                for (int i = 0; i < pieces2.Count; i++)
                {
                    if (pieces2[i].AllowedMoves(x, y, pieces, pieces2, name, 0) == true)
                    {
                        return pieces2[i];
                    }


                }
            }
            else
            {
                for (int i = 0; i < pieces.Count; i++)
                {
                    if (pieces[i].AllowedMoves(x, y, pieces, pieces2, name, 0) == true)
                    {
                        return pieces[i];
                    }


                }
            }
            return pieces[1];
        }
        //public static bool Sudoku(int x, int y, List<ChessPieces> white, List<ChessPieces> black, Color name)
        //{
        //    return false;
        //}
        public bool Mat(int a, int b, ChessPieces check, List<ChessPieces> white, List<ChessPieces> black, Color name)
        {
            if (name == Color.white)
            {
                if (ChessPieces.AllowedMovesKing(this.X, this.Y, black, white, ChessPieces.Color.black) == false)
                {
                    for (int i = 0; i < white.Count; i++)
                    {
                        for (int o = 1; o < 9; o++)
                        {
                            for (int l = 1; l < 9; l++)
                            {
                                if (white[i].fType == Type.king)
                                {
                                    if (white[i].AllowedMoves(o, l, white, black, white[0].color, 1) == true && ChessPieces.AllowedMovesKing(o, l, black, white, ChessPieces.Color.black) == true && ChessPieces.AllowedMoves(o, l, white) == true)
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    if (((o == a && l == b) == true || white[i].Cover(o, l, check, this, white, black) == true) && white[i].AllowedMoves(o, l, white, black, ChessPieces.Color.white, 0) == true && white[i].Block(o, l, white, black, ChessPieces.Color.white, 1) == true)
                                    {
                                        return false;
                                    }
                                }

                            }
                        }
                    }
                }
            }
            if (name == Color.black)
            {
                if (ChessPieces.AllowedMovesKing(this.X, this.Y, white, black, ChessPieces.Color.white) == false)
                {
                    for (int i = 0; i < black.Count; i++)
                    {
                        for (int o = 1; o < 9; o++)
                        {
                            for (int l = 1; l < 9; l++)
                            {
                                if (black[i].fType == Type.king)
                                {
                                    if (black[i].AllowedMoves(o, l, white, black, ChessPieces.Color.black, 1) == true && ChessPieces.AllowedMovesKing(o, l, white, black, ChessPieces.Color.white) == true)
                                    {
                                        if (ChessPieces.AllowedMoves(o, l, black) == true)
                                        {
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (((o == a && l == b) == true || black[i].Cover(o, l, check, this, white, black) == true) && black[i].AllowedMoves(o, l, white, black, name, 0) == true && black[i].Block(o, l, white, black, name, 1) == true)
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }

                }
            }

            return true;


        }

        public static int ConvertX(int x)
        {
            for (int i = 0; i < 8; i++)
            {
                if (x > 50 + i * 99 && x < 50 + 93 + i * 99)
                {
                    return i + 1;
                }

            }
            return 1;

        }
        public static int ConvertY(int y)
        {
            for (int i = 0; i < 8; i++)
            {
                if (y > 25 + i * 94 && y < 25 + 88 + i * 94)
                {
                    if (i + 1 == 1)
                    {
                        return 8;
                    }
                    else if (i + 1 == 2)
                    {
                        return 7;
                    }
                    else if (i + 1 == 3)
                    {
                        return 6;
                    }
                    else if (i + 1 == 4)
                    {
                        return 5;
                    }
                    else if (i + 1 == 5)
                    {
                        return 4;
                    }
                    else if (i + 1 == 6)
                    {
                        return 3;
                    }
                    else if (i + 1 == 7)
                    {
                        return 2;
                    }
                    else if (i + 1 == 8)
                    {
                        return 1;
                    }
                }
            }
            return 1;

        }

        public static int Convertx(int x)
        {
            return 50 + x * 99 + 10;

        }
        public static int Converty(int y)
        {
            if (y == 1)
            {
                y = 8;
            }
            else if (y == 2)
            {
                y = 7;
            }
            else if (y == 3)
            {
                y = 6;
            }
            else if (y == 4)
            {
                y = 5;
            }
            else if (y == 5)
            {
                y = 4;
            }
            else if (y == 6)
            {
                y = 3;
            }
            else if (y == 7)
            {
                y = 2;
            }
            else if (y == 8)
            {
                y = 1;
            }
            return 25 + (y - 1) * 94 + 10;

        }

        public static string ConvertToLetter(int x)
        {
            if (x == 1)
            {
                return "A";
            }
            else if (x == 2)
            {
                return "B";
            }
            else if (x == 3)
            {
                return "C";
            }
            else if (x == 4)
            {
                return "D";
            }
            else if (x == 5)
            {
                return "E";
            }
            else if (x == 6)
            {
                return "F";
            }
            else if (x == 7)
            {
                return "G";
            }
            else
            {
                return "H";
            }
        }
        public static int ConvertToNumber(char a)
        {
            if (a == 'A')
            {
                return 1;
            }
            else if (a == 'B')
            {
                return 2;
            }
            else if (a == 'C')
            {
                return 3;
            }
            else if (a == 'D')
            {
                return 4;
            }
            else if (a == 'E')
            {
                return 5;
            }
            else if (a == 'F')
            {
                return 6;
            }
            else if (a == 'G')
            {
                return 7;
            }
            else if (a == 'H')
            {
                return 8;
            }
            return 1;
        }
    }
}
