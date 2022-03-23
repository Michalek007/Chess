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
    class ListOfPieces : Form1
    {
        public static List<ChessPieces> CreateList()
        {
            List<ChessPieces> chessPieces = new List<ChessPieces>()
            {
                //new King(6,4,ChessPieces.Color.white),  /*D1*/
                //new Queen(7,1,ChessPieces.Color.white), /*A2*/
                //new King(5,1,ChessPieces.Color.white, Form1.pictureBox23),
                //new Queen(4,1,ChessPieces.Color.white),
                //new Bishop(3,1,ChessPieces.Color.white),
                //new Bishop(6,1,ChessPieces.Color.white),
                //new Knight(2,1,ChessPieces.Color.white),
                //new Knight(7,1,ChessPieces.Color.white),
                //new Rook(8,1,ChessPieces.Color.white),
                //new Rook(1,1,ChessPieces.Color.white),
                //new Pone(1,2,ChessPieces.Color.white),
                //new Pone(2,2,ChessPieces.Color.white),
                //new Pone(3,2,ChessPieces.Color.white),
                //new Pone(4,2,ChessPieces.Color.white),
                //new Pone(5,2,ChessPieces.Color.white),
                //new Pone(6,2,ChessPieces.Color.white),
                //new Pone(7,2,ChessPieces.Color.white),
                //new Pone(8,2,ChessPieces.Color.white),



            };
            return chessPieces;

        }

        public static List<ChessPieces> CreateBlackList()
        {
            List<ChessPieces> chessPieces = new List<
                ChessPieces>()
            {
                //new King(8,4,ChessPieces.Color.black),
                //new Queen(2,4,ChessPieces.Color.black),
                //new King(5,8,ChessPieces.Color.black),
                //new Queen(4,8,ChessPieces.Color.black),
                //new Bishop(3,8,ChessPieces.Color.black),
                //new Bishop(6,8,ChessPieces.Color.black),
                //new Knight(2,8,ChessPieces.Color.black),
                //new Knight(7,8,ChessPieces.Color.black),
                //new Rook(8,8,ChessPieces.Color.black),
                //new Rook(1,8,ChessPieces.Color.black),
                //new Pone(1,7,ChessPieces.Color.black),
                //new Pone(2,7,ChessPieces.Color.black),
                //new Pone(3,7,ChessPieces.Color.black),
                //new Pone(4,7,ChessPieces.Color.black),
                //new Pone(5,7,ChessPieces.Color.black),
                //new Pone(6,7,ChessPieces.Color.black),
                //new Pone(7,7,ChessPieces.Color.black),
                //new Pone(8,7,ChessPieces.Color.black),
            };
            return chessPieces;

        }
    }
}
