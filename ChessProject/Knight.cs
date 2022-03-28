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
    class Knight : ChessPieces
    {
        public Knight(int x, int y, Color name, PictureBox box)
        {
            X = x;
            Y = y;
            color = name;
            Box = box;
            Symbol = "N";
        }

        public bool AllowedMoves(int x, int y)
        {
            if ((x == X + 2 || x == X - 2 || x == X + 1 || x == X - 1) && (y == Y + 2 || y == Y - 2 || y == Y + 1 || x == Y - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
