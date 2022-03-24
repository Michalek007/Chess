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
    public partial class Form1 : Form
    {
        private int dragging;
        private List<ChessPieces> white { get; set; }
        private List<ChessPieces> black { get; set; }
        private int turn = 1;
        private int castleW;
        private int castleB;
        public Form1()
        {
            InitializeComponent();
            ((Control)pictureBox23).AllowDrop = true;
            List<ChessPieces> chessPieces = new List<ChessPieces>()
            {
                new King(5,1,ChessPieces.Color.white, pictureBox23),
                new Queen(4,1,ChessPieces.Color.white, pictureBox1),
                new Bishop(3,1,ChessPieces.Color.white,pictureBox2),
                new Bishop(6,1,ChessPieces.Color.white,pictureBox3),
                new Knight(2,1,ChessPieces.Color.white,pictureBox4),
                new Knight(7,1,ChessPieces.Color.white,pictureBox5),
                new Rook(8,1,ChessPieces.Color.white,pictureBox6),
                new Rook(1,1,ChessPieces.Color.white,pictureBox7),
                new Pone(1,2,ChessPieces.Color.white,pictureBox8),
                new Pone(2,2,ChessPieces.Color.white,pictureBox9),
                new Pone(3,2,ChessPieces.Color.white,pictureBox17),
                new Pone(4,2,ChessPieces.Color.white,pictureBox16),
                new Pone(5,2,ChessPieces.Color.white,pictureBox15),
                new Pone(6,2,ChessPieces.Color.white,pictureBox14),
                new Pone(7,2,ChessPieces.Color.white,pictureBox13),
                new Pone(8,2,ChessPieces.Color.white,pictureBox12),
            };
            List<ChessPieces> chessPiecesBlack = new List<ChessPieces>()
            {
                new King(5,8,ChessPieces.Color.black,pictureBox11),
                new Queen(4,8,ChessPieces.Color.black,pictureBox10),
                new Bishop(3,8,ChessPieces.Color.black,pictureBox26),
                new Bishop(6,8,ChessPieces.Color.black,pictureBox25),
                new Knight(2,8,ChessPieces.Color.black,pictureBox24),
                new Knight(7,8,ChessPieces.Color.black,pictureBox22),
                new Rook(8,8,ChessPieces.Color.black,pictureBox21),
                new Rook(1,8,ChessPieces.Color.black,pictureBox20),
                new Pone(1,7,ChessPieces.Color.black,pictureBox19),
                new Pone(2,7,ChessPieces.Color.black,pictureBox18),
                new Pone(3,7,ChessPieces.Color.black,pictureBox34),
                new Pone(4,7,ChessPieces.Color.black,pictureBox33),
                new Pone(5,7,ChessPieces.Color.black,pictureBox32),
                new Pone(6,7,ChessPieces.Color.black,pictureBox31),
                new Pone(7,7,ChessPieces.Color.black,pictureBox30),
                new Pone(8,7,ChessPieces.Color.black,pictureBox29),
            };
            
            label2.Text = "Białe zaczynają.";
            label1.Text = "Piwo.";
            label3.Text = "Takie tam cyferki.";
            white = chessPieces;
            black = chessPiecesBlack;
            for (int i = 0; i < white.Count; i++)
            {
                white[i].Box.Left = ChessPieces.Convertx(white[i].X - 1);
                white[i].Box.Top = ChessPieces.Converty(white[i].Y);
                if (white[i].X % 2 != 0 && white[i].Y % 2 == 0 || white[i].X % 2 == 0 && white[i].Y % 2 != 0)
                {
                    white[i].Box.BackColor = Color.WhiteSmoke;
                }
                else { white[i].Box.BackColor = Color.LightSteelBlue; }
            }
            for (int i = 0; i < black.Count; i++)
            {
                black[i].Box.Left = ChessPieces.Convertx(black[i].X - 1);
                black[i].Box.Top = ChessPieces.Converty(black[i].Y);
                if (black[i].X % 2 != 0 && black[i].Y % 2 == 0 || black[i].X % 2 == 0 && black[i].Y % 2 != 0)
                {
                    black[i].Box.BackColor = Color.WhiteSmoke;
                }
                else { black[i].Box.BackColor = Color.LightSteelBlue; }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }      

        private void PictureBox23_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void PictureBox23_DragDrop(object sender, DragEventArgs e)
        {
            //label1.Text = sender.GetType().Name;
            //label1.Text = e.Data.GetData(Text,true);
            
            for (int i =0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    if (Cursor.Position.X > 50 + i * 99 && Cursor.Position.X < 50 + 93 + i * 99 && Cursor.Position.Y > 25 + o * 94 && Cursor.Position.Y < 25 + 88 + o * 94)
                    {
                        int x = ChessPieces.ConvertX(50 + i * 99 + 10);
                        int y = ChessPieces.ConvertY(25 + o * 94 + 10);
                        if (turn == 1)
                        {
                            King kingWhite = new King(white[0].X, white[0].Y, ChessPieces.Color.white, pictureBox23);
                            if (ChessPieces.AllowedMovesKing(kingWhite.X, kingWhite.Y, black, white, ChessPieces.Color.black) == false)            
                            {
                                ChessPieces check = ChessPieces.TypeOfPieces(kingWhite.X, kingWhite.Y, white, black, ChessPieces.Color.black);
                                int a = check.X;
                                int b = check.Y;

                                //int z = 0;
                                //for (int k = -1; k < 2; k++)
                                //{
                                //    for (int l = -1; l < 2; l++)
                                //    {
                                //        if (kingWhite.AllowedMoves(kingWhite.X + k, kingWhite.Y + l) == false || ChessPieces.AllowedMoves(kingWhite.X + k, kingWhite.Y + l, white) == false || ChessPieces.AllowedMovesKing(kingWhite.X + k, kingWhite.Y + l, black, white, ChessPieces.Color.black) == false)
                                //        {
                                //            z++;

                                //        }

                                //    }
                                //}
                                //label3.Text = z.ToString();
                                if (kingWhite.Mat(a, b, check, white, black, ChessPieces.Color.white))
                                {
                                    label1.Text = "MAT - zwycięstwo czarnych!";
                                }
                                if (white[dragging].GetType() == typeof(King))
                                {
                                    if (white[0].AllowedMoves(x, y, white, black, white[0].color,1) == true && ChessPieces.AllowedMovesKing(x, y, black, white, ChessPieces.Color.black) == true && ChessPieces.AllowedMoves(x,y,white) == true)
                                    {
                                        pictureBox23.Top = 25 + o * 94 + 10;
                                        pictureBox23.Left = 50 + i * 99 + 10;
                                        white[0].X = x;
                                        white[0].Y = y;
                                        castleW = 1;
                                        if (x%2 != 0 && y%2 == 0 || x % 2 == 0 && y % 2 != 0)
                                        {
                                            white[0].Box.BackColor = Color.WhiteSmoke;
                                        }
                                        else { white[0].Box.BackColor = Color.LightSteelBlue;}
                                        for (int f = 0; f < black.Count; f++)
                                        {
                                            if (black[f].X == x && black[f].Y == y)
                                            {
                                                //black[f].Box.Top = 500;
                                                //black[f].Box.Left = 500;
                                                black[f].Box.Visible = false;
                                                black.RemoveAt(f);
                                            }

                                        }
                                        turn = 2;
                                        label2.Text = "Ruch czarnych.";

                                    }

                                }
                                else
                                {
                                    //((x == a && y == b) == true || white[dragging].Cover(x, y, check, kingWhite, white, black) == true) && 
                                    // && white[dragging].Block(x, y, white, black, ChessPieces.Color.white, 1) == true
                                    label4.Text = white[dragging].Cover(x, y, check, kingWhite, white, black).ToString();
                                    label5.Text = white[dragging].AllowedMoves(x, y, white, black, ChessPieces.Color.white, 0).ToString();
                                    //label6.Text = white[dragging].Block(x, y, white, black, ChessPieces.Color.white, 1).ToString();
                                   
                                    if (((x == a && y == b) == true || white[dragging].Cover(x, y, check, kingWhite, white, black) == true) && white[dragging].AllowedMoves(x, y, white, black, ChessPieces.Color.white, 0) == true && white[dragging].Block(x, y, white, black, ChessPieces.Color.white, 1) == true)
                                    {
                                        
                                        white[dragging].Box.Top = 25 + o * 94 + 10;
                                        white[dragging].Box.Left = 50 + i * 99 + 10;
                                        white[dragging].X = x;
                                        white[dragging].Y = y;
                                        if (white[dragging].GetType() == typeof(Pone) && white[dragging].Y == 8)
                                        {
                                            Queen queen = new Queen(white[dragging].X, white[dragging].Y, ChessPieces.Color.white, white[dragging].Box);
                                            queen.Box.Image = pictureBox1.Image;
                                            white.RemoveAt(dragging);
                                            white.Insert(dragging, queen);

                                        }
                                        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                        {
                                            white[dragging].Box.BackColor = Color.WhiteSmoke;
                                        }
                                        else { white[dragging].Box.BackColor = Color.LightSteelBlue; }
                                        for (int f = 0; f < black.Count; f++)
                                        {
                                            if (black[f].X == x && black[f].Y == y)
                                            {                                       
                                                //black[f].Box.Top = 500;
                                                //black[f].Box.Left = 500;
                                                black[f].Box.Visible = false;
                                                black.RemoveAt(f);
                                            }

                                        }
                                        turn = 2;
                                        label2.Text = "Ruch czarnych.";
                                    }
                                }


                            }
                            else
                            {
                                if (white[dragging].GetType() == typeof(King))
                                {                                  
                                    if (white[0].X == 5 && white[0].Y == 1 && castleW != 1)
                                    {                                     
                                        for (int r = 0; r < white.Count; r++)
                                        {
                                            if (white[r].GetType() == typeof(Rook))
                                            {
                                                if (white[r].X == 8 && white[r].Y == 1)
                                                {
                                                    if (white[0].Castle(x, y, white, black, ChessPieces.Color.white) == true)
                                                    {
                                                        //label4.Text = white[0].Castle(x, y, white, black, ChessPieces.Color.white).ToString();
                                                        //label5.Text = b.ToString();
                                                        //label6.Text = black[c].Cover(x, y, checkB, kingBlack, white, black).ToString();
                                                        //label7.Text = black[c].AllowedMoves(a, b, white, black, ChessPieces.Color.black, 0).ToString();
                                                        white[0].Box.Top = 25 + o * 94 + 10;
                                                        white[0].Box.Left = 50 + i * 99 + 10;
                                                        white[0].X = x;
                                                        white[0].Y = y;
                                                        castleW = 1;
                                                        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                                        {
                                                            white[0].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { white[0].Box.BackColor = Color.LightSteelBlue; }

                                                        white[r].Box.Top = 25 + o * 94 + 10;
                                                        white[r].Box.Left = 50 + (i - 1) * 99 + 10;
                                                        white[r].X = x - 1;
                                                        white[r].Y = y;
                                                        if (white[r].X % 2 != 0 && y % 2 == 0 || white[r].X % 2 == 0 && y % 2 != 0)
                                                        {
                                                            white[r].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { white[r].Box.BackColor = Color.LightSteelBlue; }
                                                        turn = 2;
                                                        label2.Text = "Ruch czarnych.";
                                                    }
                                                }                                            
                                            }
                                        }
                                        for (int r = 0; r < white.Count; r++)
                                        {                                 
                                            if (white[r].GetType() == typeof(Rook))
                                            {
                                                if (white[r].X == 1 && white[r].Y == 1)
                                                {
                                                    //label5.Text = white[0].CastleL(x, y, white, black, ChessPieces.Color.white).ToString();
                                                    if (white[0].CastleL(x, y, white, black, ChessPieces.Color.white) == true)
                                                    {
                                                        
                                                        //label5.Text = b.ToString();
                                                        //label6.Text = black[c].Cover(x, y, checkB, kingBlack, white, black).ToString();
                                                        //label7.Text = black[c].AllowedMoves(a, b, white, black, ChessPieces.Color.black, 0).ToString();
                                                        white[0].Box.Top = 25 + o * 94 + 10;
                                                        white[0].Box.Left = 50 + i * 99 + 10;
                                                        white[0].X = x;
                                                        white[0].Y = y;
                                                        castleW = 1;
                                                        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                                        {
                                                            white[0].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { white[0].Box.BackColor = Color.LightSteelBlue; }

                                                        white[r].Box.Top = 25 + o * 94 + 10;
                                                        white[r].Box.Left = 50 + (i + 1) * 99 + 10;
                                                        white[r].X = x + 1;
                                                        white[r].Y = y;
                                                        if (white[r].X % 2 != 0 && y % 2 == 0 || white[r].X % 2 == 0 && y % 2 != 0)
                                                        {
                                                            white[r].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { white[r].Box.BackColor = Color.LightSteelBlue; }
                                                        turn = 2;
                                                        label2.Text = "Ruch czarnych.";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (white[0].AllowedMoves(x, y, white, black, white[0].color,1) == true && ChessPieces.AllowedMovesKing(x, y, black, white, ChessPieces.Color.black) == true && ChessPieces.AllowedMoves(x, y, white) == true)
                                    {
                                        
                                        pictureBox23.Top = 25 + o * 94 + 10;
                                        pictureBox23.Left = 50 + i * 99 + 10;
                                        white[0].X = x;
                                        white[0].Y = y;
                                        castleW = 1;
                                        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                        {
                                            white[0].Box.BackColor = Color.WhiteSmoke;
                                        }
                                        else { white[0].Box.BackColor = Color.LightSteelBlue; }
                                        for (int f = 0; f < black.Count; f++)
                                        {
                                            if (black[f].X == x && black[f].Y == y)
                                            {
                                                //black[f].Box.Top = 500;
                                                //black[f].Box.Left = 500;
                                                black[f].Box.Visible = false;
                                                black.RemoveAt(f);
                                            }

                                        }
                                        turn = 2;
                                        label2.Text = "Ruch czarnych.";
                                    }

                                }
                                else
                                {
                                    if (white[dragging].AllowedMoves(x, y, white, black, ChessPieces.Color.white,0) == true && white[dragging].Block(x, y, white, black, ChessPieces.Color.white,0) == true)
                                    {
                                        if (ChessPieces.AllowedMoves(x, y, white) == true)
                                        {
                                            white[dragging].Box.Top = 25 + o * 94 + 10;
                                            white[dragging].Box.Left = 50 + i * 99 + 10;
                                            white[dragging].X = x;
                                            white[dragging].Y = y;
                                            if (white[dragging].GetType() == typeof(Pone) && white[dragging].Y == 8)                                            
                                            {
                                                Queen queen = new Queen(white[dragging].X, white[dragging].Y, ChessPieces.Color.white, white[dragging].Box);
                                                queen.Box.Image = pictureBox1.Image;
                                                white.RemoveAt(dragging);
                                                white.Insert(dragging, queen);
                                                
                                            }
                                            if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                            {
                                                white[dragging].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { white[dragging].Box.BackColor = Color.LightSteelBlue; }
                                            for (int f = 0; f < black.Count; f++)
                                            {
                                                if (black[f].X == x && black[f].Y == y)
                                                {
                                                    //black[f].Box.Top = 500;
                                                    //black[f].Box.Left = 500;
                                                    black[f].Box.Visible = false;
                                                    black.RemoveAt(f);
                                                }

                                            }
                                            turn = 2;
                                            label2.Text = "Ruch czarnych.";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            int c = dragging;
                            King kingBlack = new King(black[0].X, black[0].Y, ChessPieces.Color.black, pictureBox2);
                            if (ChessPieces.AllowedMovesKing(kingBlack.X, kingBlack.Y, white, black, ChessPieces.Color.white) == false)
                            {
                                ChessPieces checkB = ChessPieces.TypeOfPieces(kingBlack.X, kingBlack.Y, white, black, ChessPieces.Color.white);
                                int a = checkB.X;
                                int b = checkB.Y;
                                //for (int k = -1; k < 2; k++)
                                //{
                                //    for (int l = -1; l < 2; l++)
                                //    {
                                //        if (kingBlack.AllowedMoves(kingBlack.X + k, kingBlack.Y + k) == false || ChessPieces.AllowedMoves(kingBlack.X + k, kingBlack.Y + l, black) == false || ChessPieces.AllowedMovesKing(kingBlack.X + k, kingBlack.Y + l, white, black, ChessPieces.Color.white) == false)
                                //        {
                                //            z++;

                                //        }

                                //    }
                                //}
                                ////label3.Text = z.ToString();
                                if (kingBlack.Mat(a,b,checkB,white,black,ChessPieces.Color.black))
                                {
                                    label1.Text = "MAT- zwycięstwo białych!";
                                }
                                //z = 0;
                                if (black[c].GetType() == typeof(King))
                                {
                                    if (black[c].AllowedMoves(x, y, white, black, ChessPieces.Color.black,1) == true && ChessPieces.AllowedMovesKing(x, y, white, black, ChessPieces.Color.white) == true && ChessPieces.AllowedMoves(x, y, black) == true)
                                    {
                                        if (ChessPieces.AllowedMoves(x, y, black) == true)
                                        {
                                            black[c].Box.Top = 25 + o * 94 + 10;
                                            black[c].Box.Left = 50 + i * 99 + 10;
                                            black[c].X = x;
                                            black[c].Y = y;
                                            castleB = 1;
                                            if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                            {
                                                black[c].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { black[c].Box.BackColor = Color.LightSteelBlue; }
                                            for (int f = 0; f < white.Count; f++)
                                            {
                                                if (white[f].X == x && white[f].Y == y)
                                                {                                                   
                                                    //white[f].Box.Top = 500;
                                                    //white[f].Box.Left = 500;
                                                    white[f].Box.Visible = false;
                                                    white.RemoveAt(f);
                                                }

                                            }
                                            turn = 1;
                                            label2.Text = "Ruch białych.";
                                        }
                                    }
                                }
                                else
                                {
                                    
                                    //label4.Text = a.ToString();
                                    //label5.Text = b.ToString();
                                    //label6.Text = black[c].Cover(x, y, checkB, kingBlack, white, black).ToString();
                                    //label7.Text = black[c].AllowedMoves(a, b, white, black, ChessPieces.Color.black,0).ToString();
                                    if (((x == a && y == b) == true || black[c].Cover(x, y, checkB, kingBlack, white, black) == true) && black[c].AllowedMoves(x, y, white, black, ChessPieces.Color.black,0) == true && black[c].Block(x, y, white, black, ChessPieces.Color.black, 1) == true)
                                    {
                                        black[c].Box.Top = 25 + o * 94 + 10;
                                        black[c].Box.Left = 50 + i * 99 + 10;
                                        black[c].X = x;
                                        black[c].Y = y;
                                        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                        {
                                            black[c].Box.BackColor = Color.WhiteSmoke;
                                        }
                                        else { black[c].Box.BackColor = Color.LightSteelBlue; }
                                        for (int f = 0; f < white.Count; f++)
                                        {
                                            if (white[f].X == x && white[f].Y == y)
                                            {
                                                //white[f].Box.Top = 500;
                                                //white[f].Box.Left = 500;
                                                white[f].Box.Visible = false;
                                                white.RemoveAt(f);
                                            }

                                        }
                                        turn = 1;
                                        label2.Text = "Ruch białych.";
                                    }
                                }



                            }
                            else
                            {
                                if (black[c].GetType() == typeof(King))
                                {
                                    if (black[c].X == 5 && black[c].Y == 8 && castleB != 1)
                                    {                                     
                                        for (int r = 0; r < black.Count; r++)
                                        {
                                            if (black[r].GetType() == typeof(Rook))
                                            {
                                                if (black[r].X == 8 && black[r].Y == 8)
                                                {
                                                    label7.Text = black[c].Castle(x, y, white, black, ChessPieces.Color.black).ToString();
                                                    if (black[c].Castle(x, y, white, black, ChessPieces.Color.black) == true)
                                                    {
                                                        black[c].Box.Top = 25 + o * 94 + 10;
                                                        black[c].Box.Left = 50 + i * 99 + 10;
                                                        black[c].X = x;
                                                        black[c].Y = y;
                                                        castleB = 1;
                                                        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                                        {
                                                            black[c].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { black[c].Box.BackColor = Color.LightSteelBlue; }

                                                        black[r].Box.Top = 25 + o * 94 + 10;
                                                        black[r].Box.Left = 50 + (i - 1) * 99 + 10;
                                                        black[r].X = x - 1;
                                                        black[r].Y = y;
                                                        if (black[r].X % 2 != 0 && y % 2 == 0 || black[r].X % 2 == 0 && y % 2 != 0)
                                                        {
                                                            black[r].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { black[r].Box.BackColor = Color.LightSteelBlue; }
                                                        turn = 1;
                                                        label2.Text = "Ruch białych.";
                                                    }
                                                }
                                            }
                                        }
                                        for (int r = 0; r < black.Count; r++)
                                        {
                                            if (black[r].GetType() == typeof(Rook))
                                            {                                               
                                                if (black[r].X == 1 && black[r].Y == 8)
                                                {
                                                    label6.Text = black[c].CastleL(x, y, white, black, ChessPieces.Color.black).ToString();
                                                    if (black[c].CastleL(x, y, white, black, ChessPieces.Color.black) == true)
                                                    {
                                                        black[c].Box.Top = 25 + o * 94 + 10;
                                                        black[c].Box.Left = 50 + i * 99 + 10;
                                                        black[c].X = x;
                                                        black[c].Y = y;
                                                        castleB = 1;
                                                        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                                        {
                                                            black[c].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { black[c].Box.BackColor = Color.LightSteelBlue; }

                                                        black[r].Box.Top = 25 + o * 94 + 10;
                                                        black[r].Box.Left = 50 + (i + 1) * 99 + 10;
                                                        black[r].X = x + 1;
                                                        black[r].Y = y;
                                                        if (black[r].X % 2 != 0 && y % 2 == 0 || black[r].X % 2 == 0 && y % 2 != 0)
                                                        {
                                                            black[r].Box.BackColor = Color.WhiteSmoke;
                                                        }
                                                        else { black[r].Box.BackColor = Color.LightSteelBlue; }
                                                        turn = 1;
                                                        label2.Text = "Ruch białych.";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (black[c].AllowedMoves(x, y, white, black, ChessPieces.Color.black,1) == true && ChessPieces.AllowedMovesKing(x, y, white, black, ChessPieces.Color.white) == true)
                                    {                                    
                                        if (ChessPieces.AllowedMoves(x, y, black) == true)
                                        {
                                            black[c].Box.Top = 25 + o * 94 + 10;
                                            black[c].Box.Left = 50 + i * 99 + 10;
                                            black[c].X = x;
                                            black[c].Y = y;
                                            castleB = 1;
                                            if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                            {
                                                black[c].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { black[c].Box.BackColor = Color.LightSteelBlue; }
                                            for (int f = 0; f < white.Count; f++)
                                            {
                                                if (white[f].X == x && white[f].Y == y)
                                                {
                                                    //white[f].Box.Top = 500;
                                                    //white[f].Box.Left = 500;
                                                    white[f].Box.Visible = false;
                                                    white.RemoveAt(f);
                                                }

                                            }
                                            turn = 1;
                                            label2.Text = "Ruch białych.";
                                        }
                                    }
                                }
                                else
                                {
                                    if (black[c].AllowedMoves(x, y, white, black, ChessPieces.Color.black,0) == true && black[c].Block(x,y, white, black, ChessPieces.Color.black,0) == true)
                                    {
                                        if (ChessPieces.AllowedMoves(x, y, black) == true)
                                        {
                                            black[c].Box.Top = 25 + o * 94 + 10;
                                            black[c].Box.Left = 50 + i * 99 + 10;
                                            black[c].X = x;
                                            black[c].Y = y;
                                            if (black[c].GetType() == typeof(Pone) && black[c].Y == 1)
                                            {
                                                Queen queen = new Queen(black[c].X, black[c].Y, ChessPieces.Color.black, black[c].Box);
                                                queen.Box.Image = pictureBox10.Image;
                                                black.RemoveAt(c);
                                                black.Insert(c, queen);

                                            }
                                            if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                            {
                                                black[c].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { black[c].Box.BackColor = Color.LightSteelBlue; }
                                            for (int f = 0; f < white.Count; f++)
                                            {
                                                if (white[f].X == x && white[f].Y == y)
                                                {
                                                    //white[f].Box.Top = 500;
                                                    //white[f].Box.Left = 500;
                                                    white[f].Box.Visible = false;
                                                    white.RemoveAt(f);
                                                }

                                            }
                                            turn = 1;
                                            label2.Text = "Ruch białych.";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (turn == 2)
            {
                Random random = new Random();
                //Random random1 = new Random();
                //Random random2 = new Random();
                while (turn != 1)
                {
                    int c = random.Next(0, 16);
                    int x = random.Next(1, 9);
                    int y = random.Next(1, 9);
                    if (black[c].GetType() == typeof(King))
                    {
                        if (black[c].X == 5 && black[c].Y == 8 && castleB != 1)
                        {
                            for (int r = 0; r < black.Count; r++)
                            {
                                if (black[r].GetType() == typeof(Rook))
                                {
                                    if (black[r].X == 8 && black[r].Y == 8)
                                    {
                                        label7.Text = black[c].Castle(x, y, white, black, ChessPieces.Color.black).ToString();
                                        if (black[c].Castle(x, y, white, black, ChessPieces.Color.black) == true)
                                        {
                                            black[c].Box.Top = ChessPieces.Converty(y);
                                            black[c].Box.Left = ChessPieces.Convertx(x - 1);
                                            black[c].X = x;
                                            black[c].Y = y;
                                            castleB = 1;
                                            if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                            {
                                                black[c].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { black[c].Box.BackColor = Color.LightSteelBlue; }

                                            black[c].Box.Top = ChessPieces.Converty(y);
                                            black[c].Box.Left = ChessPieces.Convertx(x - 1);
                                            black[r].X = x - 1;
                                            black[r].Y = y;
                                            if (black[r].X % 2 != 0 && y % 2 == 0 || black[r].X % 2 == 0 && y % 2 != 0)
                                            {
                                                black[r].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { black[r].Box.BackColor = Color.LightSteelBlue; }
                                            turn = 1;
                                            label2.Text = "Ruch białych.";
                                        }
                                    }
                                }
                            }
                            for (int r = 0; r < black.Count; r++)
                            {
                                if (black[r].GetType() == typeof(Rook))
                                {
                                    if (black[r].X == 1 && black[r].Y == 8)
                                    {
                                        label6.Text = black[c].CastleL(x, y, white, black, ChessPieces.Color.black).ToString();
                                        if (black[c].CastleL(x, y, white, black, ChessPieces.Color.black) == true)
                                        {
                                            black[c].Box.Top = ChessPieces.Converty(y);
                                            black[c].Box.Left = ChessPieces.Convertx(x - 1);
                                            black[c].X = x;
                                            black[c].Y = y;
                                            castleB = 1;
                                            if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                            {
                                                black[c].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { black[c].Box.BackColor = Color.LightSteelBlue; }

                                            black[c].Box.Top = ChessPieces.Converty(y);
                                            black[c].Box.Left = ChessPieces.Convertx(x - 1);
                                            black[r].X = x + 1;
                                            black[r].Y = y;
                                            if (black[r].X % 2 != 0 && y % 2 == 0 || black[r].X % 2 == 0 && y % 2 != 0)
                                            {
                                                black[r].Box.BackColor = Color.WhiteSmoke;
                                            }
                                            else { black[r].Box.BackColor = Color.LightSteelBlue; }
                                            turn = 1;
                                            label2.Text = "Ruch białych.";
                                        }
                                    }
                                }
                            }
                        }
                        if (black[c].AllowedMoves(x, y, white, black, ChessPieces.Color.black, 1) == true && ChessPieces.AllowedMovesKing(x, y, white, black, ChessPieces.Color.white) == true)
                        {
                            if (ChessPieces.AllowedMoves(x, y, black) == true)
                            {
                                black[c].Box.Top = ChessPieces.Converty(y);
                                black[c].Box.Left = ChessPieces.Convertx(x - 1);
                                black[c].X = x;
                                black[c].Y = y;
                                castleB = 1;
                                if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                {
                                    black[c].Box.BackColor = Color.WhiteSmoke;
                                }
                                else { black[c].Box.BackColor = Color.LightSteelBlue; }
                                for (int f = 0; f < white.Count; f++)
                                {
                                    if (white[f].X == x && white[f].Y == y)
                                    {
                                        //white[f].Box.Top = 500;
                                        //white[f].Box.Left = 500;
                                        white[f].Box.Visible = false;
                                        white.RemoveAt(f);
                                    }

                                }
                                turn = 1;
                                label2.Text = "Ruch białych.";
                            }
                        }
                    }
                    else
                    {
                        if (black[c].AllowedMoves(x, y, white, black, ChessPieces.Color.black, 0) == true && black[c].Block(x, y, white, black, ChessPieces.Color.black, 0) == true)
                        {
                            if (ChessPieces.AllowedMoves(x, y, black) == true)
                            {
                                black[c].Box.Top = ChessPieces.Converty(y);
                                black[c].Box.Left = ChessPieces.Convertx(x - 1);
                                black[c].X = x;
                                black[c].Y = y;
                                if (black[c].GetType() == typeof(Pone) && black[c].Y == 1)
                                {
                                    Queen queen = new Queen(black[c].X, black[c].Y, ChessPieces.Color.black, black[c].Box);
                                    queen.Box.Image = pictureBox10.Image;
                                    black.RemoveAt(c);
                                    black.Insert(c, queen);

                                }
                                if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                                {
                                    black[c].Box.BackColor = Color.WhiteSmoke;
                                }
                                else { black[c].Box.BackColor = Color.LightSteelBlue; }
                                for (int f = 0; f < white.Count; f++)
                                {
                                    if (white[f].X == x && white[f].Y == y)
                                    {
                                        //white[f].Box.Top = 500;
                                        //white[f].Box.Left = 500;
                                        white[f].Box.Visible = false;
                                        white.RemoveAt(f);
                                    }

                                }
                                turn = 1;
                                label2.Text = "Ruch białych.";
                            }
                        }
                    }
                }
                
                //for (int i =0; i< black.Count; i++)
                //{
                //    if (black[i].GetType() == typeof(Pone) && black[i].X == 5)
                //    {
                //        int x = black[i].X;
                //        int y = black[i].Y - 2 ;
                //        black[i].Box.Top = ChessPieces.Converty(y);
                //        black[i].Box.Left = ChessPieces.Convertx(x-1);
                //        black[i].X = x;
                //        black[i].Y = y;
                //        if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                //        {
                //            black[i].Box.BackColor = Color.WhiteSmoke;
                //        }
                //        else { black[i].Box.BackColor = Color.LightSteelBlue; }
                //    }
                //}
                
            }
        }
        private void PictureBox23_MouseDown(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox23)
                {
                    dragging = i;
                }
            }
            pictureBox23.DoDragDrop(pictureBox23, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox1)
                {
                    dragging = i;
                }
            }
            pictureBox1.DoDragDrop(pictureBox1, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox2)
                {
                    dragging = i;
                }
            }
            pictureBox1.DoDragDrop(pictureBox2, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox3)
                {
                    dragging = i;
                }
            }
            pictureBox1.DoDragDrop(pictureBox3, DragDropEffects.Copy | DragDropEffects.Move);
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i =0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox4)
                {
                    dragging = i;
                }
            }
            pictureBox4.DoDragDrop(pictureBox4, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox5)
                {
                    dragging = i;
                }
            }
            pictureBox5.DoDragDrop(pictureBox5, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox6)
                {
                    dragging = i;
                }
            }
            pictureBox6.DoDragDrop(pictureBox6, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox7)
                {
                    dragging = i;
                }
            }
            pictureBox7.DoDragDrop(pictureBox7, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox8)
                {
                    dragging = i;
                }
            }
            pictureBox8.DoDragDrop(pictureBox8, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox9)
                {
                    dragging = i;
                }
            }
            pictureBox9.DoDragDrop(pictureBox9, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox17_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox17)
                {
                    dragging = i;
                }
            }
            pictureBox17.DoDragDrop(pictureBox17, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox16_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox16)
                {
                    dragging = i;
                }
            }
            pictureBox16.DoDragDrop(pictureBox16, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox15_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox15)
                {
                    dragging = i;
                }
            }
            pictureBox15.DoDragDrop(pictureBox15, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox14_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox14)
                {
                    dragging = i;
                }
            }
            pictureBox14.DoDragDrop(pictureBox14, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox13)
                {
                    dragging = i;
                }
            }
            pictureBox13.DoDragDrop(pictureBox13, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == pictureBox12)
                {
                    dragging = i;
                }
            }
            pictureBox12.DoDragDrop(pictureBox12, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox11_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox11)
                {
                    dragging = i;
                }
            }
            pictureBox11.DoDragDrop(pictureBox11, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox10_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox10)
                {
                    dragging = i;
                }
            }
            pictureBox10.DoDragDrop(pictureBox10, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox26_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox26)
                {
                    dragging = i;
                }
            }
            pictureBox26.DoDragDrop(pictureBox26, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox25_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox25)
                {
                    dragging = i;
                }
            }
            pictureBox25.DoDragDrop(pictureBox25, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox24_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox24)
                {
                    dragging = i;
                }
            }
            pictureBox24.DoDragDrop(pictureBox24, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox22_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox22)
                {
                    dragging = i;
                }
            }
            pictureBox22.DoDragDrop(pictureBox22, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox21_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox21)
                {
                    dragging = i;
                }
            }
            pictureBox21.DoDragDrop(pictureBox21, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox20_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox20)
                {
                    dragging = i;
                }
            }
            pictureBox20.DoDragDrop(pictureBox20, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox19_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox19)
                {
                    dragging = i;
                }
            }
            pictureBox19.DoDragDrop(pictureBox19, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox18_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox18)
                {
                    dragging = i;
                }
            }
            pictureBox18.DoDragDrop(pictureBox18, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox34_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox34)
                {
                    dragging = i;
                }
            }
            pictureBox34.DoDragDrop(pictureBox34, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox33_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox33)
                {
                    dragging = i;
                }
            }
            pictureBox33.DoDragDrop(pictureBox33, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox32_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox32)
                {
                    dragging = i;
                }
            }
            pictureBox32.DoDragDrop(pictureBox32, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox31_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox31)
                {
                    dragging = i;
                }
            }
            pictureBox31.DoDragDrop(pictureBox31, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox30_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox30)
                {
                    dragging = i;
                }
            }
            pictureBox30.DoDragDrop(pictureBox30, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void pictureBox29_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < black.Count; i++)
            {
                if (black[i].Box == pictureBox29)
                {
                    dragging = i;
                }
            }
            pictureBox29.DoDragDrop(pictureBox29, DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel47_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel35_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel52_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
