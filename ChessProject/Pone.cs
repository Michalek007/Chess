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
    class Pone : ChessPieces
    {
        public Pone(int x, int y, Color name, PictureBox box)
        {
            X = x;
            Y = y;
            color = name;
            Box = box;
            if (name == Color.white)
            {
                Symbol = "  P  ";
            }
            else
            {
                Symbol = "  p  ";
            }
            
        }
    }
}
