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
    class King : ChessPieces
    {
        public King(int x, int y, Color name, PictureBox box)
        {
            X = x;
            Y = y;
            color = name;
            Box = box;
            if (name == Color.white)
            {
                Symbol = "K";
            }
            else
            {
                Symbol = "k";
            }
        }
        public bool AllowedMoves(int x, int y)
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
            if ((x == X || x == X + 1 || x == X - 1) && (y == Y || y == Y + 1 || y == Y - 1))
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
