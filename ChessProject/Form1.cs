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
    using fColor = ChessPieces.Color;
    using fType = ChessPieces.Type;
    public partial class Form1 : Form
    {
        private int dragging;
        private List<ChessPieces> white { get; set; }
        private List<ChessPieces> black { get; set; }
        private List<string> moves { get; set; }
        private int turn = 1;
        private int castleW;
        private int castleB;
        private Color light;
        private Color dark;
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();
            ((Control)pictureBox23).AllowDrop = true;

            light = Color.WhiteSmoke;
            dark = Color.LightSteelBlue;
            List<string> list_moves = new List<string>();
            List<ChessPieces> chessPieces = new List<ChessPieces>()
            {
                new ChessPieces(5,1, fType.king, fColor.white, pictureBox23),
                new ChessPieces(4,1,fType.queen, fColor.white, pictureBox1),
                new ChessPieces(3,1,fType.bishop,fColor.white,pictureBox2),
                new ChessPieces(6,1,fType.bishop,fColor.white,pictureBox3),
                new ChessPieces(2,1,fType.knight,fColor.white,pictureBox4),
                new ChessPieces(7,1,fType.knight,fColor.white,pictureBox5),
                new ChessPieces(8,1,fType.rook,fColor.white,pictureBox6),
                new ChessPieces(1,1,fType.rook,fColor.white,pictureBox7),
                new ChessPieces(1,2,fType.pone,fColor.white,pictureBox8),
                new ChessPieces(2,2,fType.pone,fColor.white,pictureBox9),
                new ChessPieces(3,2,fType.pone,fColor.white,pictureBox17),
                new ChessPieces(4,2,fType.pone,fColor.white,pictureBox16),
                new ChessPieces(5,2,fType.pone,fColor.white,pictureBox15),
                new ChessPieces(6,2,fType.pone,fColor.white,pictureBox14),
                new ChessPieces(7,2,fType.pone,fColor.white,pictureBox13),
                new ChessPieces(8,2,fType.pone,fColor.white,pictureBox12),
            };
            List<ChessPieces> chessPiecesBlack = new List<ChessPieces>()
            {
                new ChessPieces(5,8,fType.king,fColor.black,pictureBox11),
                new ChessPieces(4,8,fType.queen,fColor.black,pictureBox10),
                new ChessPieces(3,8,fType.bishop,fColor.black,pictureBox26),
                new ChessPieces(6,8,fType.bishop,fColor.black,pictureBox25),
                new ChessPieces(2,8,fType.knight,fColor.black,pictureBox24),
                new ChessPieces(7,8,fType.knight,fColor.black,pictureBox22),
                new ChessPieces(8,8,fType.rook,fColor.black,pictureBox21),
                new ChessPieces(1,8,fType.rook,fColor.black,pictureBox20),
                new ChessPieces(1,7,fType.pone,fColor.black,pictureBox19),
                new ChessPieces(2,7,fType.pone,fColor.black,pictureBox18),
                new ChessPieces(3,7,fType.pone,fColor.black,pictureBox34),
                new ChessPieces(4,7,fType.pone,fColor.black,pictureBox33),
                new ChessPieces(5,7,fType.pone,fColor.black,pictureBox32),
                new ChessPieces(6,7,fType.pone,fColor.black,pictureBox31),
                new ChessPieces(7,7,fType.pone,fColor.black,pictureBox30),
                new ChessPieces(8,7,fType.pone,fColor.black,pictureBox29),
            };
            
            label2.Text = "Białe zaczynają.";
            label1.Text = "Piwo.";
            label3.Text = "Takie tam cyferki.";
            white = chessPieces;
            black = chessPiecesBlack;
            moves = list_moves;
            for (int i = 0; i < white.Count; i++)
            {
                white[i].Box.Left = ChessPieces.Convertx(white[i].X - 1);
                white[i].Box.Top = ChessPieces.Converty(white[i].Y);
                if (white[i].X % 2 != 0 && white[i].Y % 2 == 0 || white[i].X % 2 == 0 && white[i].Y % 2 != 0)
                {
                    white[i].Box.BackColor = light;
                }
                else { white[i].Box.BackColor = dark; }
            }
            for (int i = 0; i < black.Count; i++)
            {
                black[i].Box.Left = ChessPieces.Convertx(black[i].X - 1);
                black[i].Box.Top = ChessPieces.Converty(black[i].Y);
                if (black[i].X % 2 != 0 && black[i].Y % 2 == 0 || black[i].X % 2 == 0 && black[i].Y % 2 != 0)
                {
                    black[i].Box.BackColor = light;
                }
                else { black[i].Box.BackColor = dark; }
            }
        }

        private void PictureBox23_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void MoveList(string symbol, int x, int y)
        {
            string move = symbol + ChessPieces.ConvertToLetter(x) + y;
            moves.Add(move);
        }
        private void Move_(int x, int y, int o, int i, fColor color, int use, int dragging)
        {
            if (color == fColor.white)
            {
                Position(x, y, o, i, color, dragging);
                if (white[dragging].fType == fType.pone && white[dragging].Y == 8 && use == 0)
                {
                    ChessPieces queen = new ChessPieces(white[dragging].X, white[dragging].Y,fType.queen, fColor.white, white[dragging].Box);
                    queen.Box.Image = pictureBox1.Image;
                    white.RemoveAt(dragging);
                    white.Insert(dragging, queen);

                }
                Color_(x, y, color, dragging);
                Remove(x, y, fColor.white);
                turn = 2;
                counter++;
                label2.Text = "Ruch czarnych.";
                MoveList(white[dragging].Symbol, x, y);
            }
            if (color == fColor.black)
            {
                Position(x, y, o, i, color, dragging);
                if (black[dragging].fType == fType.pone && black[dragging].Y == 1 && use == 0)
                {
                    ChessPieces queen = new ChessPieces(black[dragging].X, black[dragging].Y, fType.queen, fColor.black, black[dragging].Box);
                    queen.Box.Image = pictureBox10.Image;
                    black.RemoveAt(dragging);
                    black.Insert(dragging, queen);
                }
                Color_(x, y, color, dragging);
                Remove(x, y, fColor.black);
                turn = 1;
                label2.Text = "Ruch białych.";
                MoveList(black[dragging].Symbol, x, y);
            }          
        }
        private void Remove(int x, int y, fColor color )
        {
            if (color == fColor.white)
            {
                for (int f = 0; f < black.Count; f++)
                {
                    if (black[f].X == x && black[f].Y == y)
                    {
                        black[f].Box.Visible = false;
                        black.RemoveAt(f);
                    }
                }
            }
            if (color == fColor.black)
            {
                for (int f = 0; f < white.Count; f++)
                {
                    if (white[f].X == x && white[f].Y == y)
                    {
                        white[f].Box.Visible = false;
                        white.RemoveAt(f);
                    }
                }
            }
        }
        private void Color_(int x, int y, fColor color, int dragging)
        {
            if (color == fColor.white)
            {
                if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                {
                    white[dragging].Box.BackColor = light;
                }
                else { white[dragging].Box.BackColor = dark; }
            }
            if (color == fColor.black)
            {
                if (x % 2 != 0 && y % 2 == 0 || x % 2 == 0 && y % 2 != 0)
                {
                    black[dragging].Box.BackColor = light;
                }
                else { black[dragging].Box.BackColor = dark; }
            }         
        }
        private void Position(int x, int y,int o,int i, fColor color, int dragging)
        {
            if (color == fColor.white)
            {
                white[dragging].Box.Top = 25 + o * 94 + 10;
                white[dragging].Box.Left = 50 + i * 99 + 10;
                white[dragging].X = x;
                white[dragging].Y = y;
            }
            if (color == fColor.black)
            {
                black[dragging].Box.Top = 25 + o * 94 + 10;
                black[dragging].Box.Left = 50 + i * 99 + 10;
                black[dragging].X = x;
                black[dragging].Y = y;
            }
        }
        private void PictureBox23_DragDrop(object sender, DragEventArgs e)
        {
            label3.Text = (counter+1).ToString();
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    if (Cursor.Position.X > 50 + i * 99 && Cursor.Position.X < 50 + 93 + i * 99 && Cursor.Position.Y > 50 + o * 94 && Cursor.Position.Y < 50 + 88 + o * 94)
                    {
                        //konwersja współrzędnych fizycznych na współrzędne szachowe 
                        int x = ChessPieces.ConvertX(50 + i * 99 + 10);
                        int y = ChessPieces.ConvertY(25 + o * 94 + 10);
                        //ruch białych
                        if (turn == 1)
                        {
                            //jeśli król jest pod szachem
                            if (ChessPieces.AllowedMovesKing(white[0].X, white[0].Y, black, white, fColor.black) == false)            
                            {
                                ChessPieces check = ChessPieces.TypeOfPieces(white[0].X, white[0].Y, white, black, fColor.black);
                                int a = check.X;
                                int b = check.Y;

                                if (white[0].Mat(a, b, check, white, black, fColor.white) == true)
                                {
                                    label1.Text = "MAT - zwycięstwo czarnych!";
                                }
                                if (!ChessPieces.AllowedMoves(x, y, white))
                                {
                                    return;
                                }
                                //ruch królem
                                if (white[dragging].fType == fType.king)
                                {
                                    if (!white[0].AllowedMoves(x, y, white, black, white[0].color, 1))
                                    {
                                        return;
                                    }                              
                                    if (ChessPieces.AllowedMovesKing(x, y, black, white, fColor.black))
                                    {
                                        Move_(x, y, o, i, fColor.white, 1, dragging);
                                    }
                                }
                                //ruch inną figurą
                                if (!white[dragging].AllowedMoves(x, y, white, black, fColor.white, 0))
                                {
                                    return;
                                }
                                if (!white[dragging].Block(x, y, white, black, fColor.white, 1))
                                {
                                    return;
                                }                              
                                if (((x == a && y == b) == true || white[dragging].Cover(x, y, check, white[0], white, black) == true))
                                {
                                    Move_(x, y, o, i, fColor.white, 0, dragging);
                                }
                            }
                            //roszada
                            if (white[dragging].Symbol == "Ke1" && castleW != 1)
                            {
                                for (int r = 0; r < white.Count; r++)
                                {
                                    if (white[r].Symbol == "Rh1")
                                    {
                                        if (white[0].Castle(x, y, white, black, fColor.white) == true)
                                        {
                                            Position(x, y, o, i, fColor.white, dragging);
                                            Color_(x, y, fColor.white, dragging);
                                            castleW = 1;

                                            Position(x - 1, y, o, i - 1, fColor.white, r);
                                            Color_(x - 1, y, fColor.white, r);
                                            turn = 2;
                                            counter++;
                                            label2.Text = "Ruch czarnych.";
                                            MoveList(white[dragging].Symbol, x, y);
                                        }
                                    }
                                }
                                for (int r = 0; r < white.Count; r++)
                                {
                                    if (white[r].Symbol == "Ra1")
                                    {
                                        if (white[0].CastleL(x, y, white, black, fColor.white) == true)
                                        {
                                            Position(x, y, o, i, fColor.white, dragging);
                                            Color_(x, y, fColor.white, dragging);
                                            castleW = 1;

                                            Position(x + 1, y, o, i + 1, fColor.white, r);
                                            Color_(x + 1, y, fColor.white, r);
                                            turn = 2;
                                            counter++;
                                            label2.Text = "Ruch czarnych.";
                                            MoveList(white[dragging].Symbol, x, y);
                                        }
                                    }
                                }
                            }
                            if (!ChessPieces.AllowedMoves(x, y, white))
                            {
                                return;
                            }
                            //warunki na ruch królem
                            if (white[dragging].fType == fType.king)
                            {
                                if (!white[0].AllowedMoves(x, y, white, black, white[0].color, 1))
                                {
                                    return;
                                }
                                if (ChessPieces.AllowedMovesKing(x, y, black, white, fColor.black))
                                {
                                    Move_(x, y, o, i, fColor.white, 1, dragging);
                                }
                            }
                            //wybrana figura nie jest królem
                            if (!white[dragging].Block(x, y, white, black, fColor.white, 0))
                            {
                                return;
                            }
                            if (white[dragging].AllowedMoves(x, y, white, black, fColor.white, 0))
                            {
                                Move_(x, y, o, i, fColor.white, 0, dragging);
                            }
                        }
                        //ruch czarnych
                        if (turn == 2)
                        {
                            int c = dragging;
                            //jeśli król jest pod szachem
                            if (ChessPieces.AllowedMovesKing(black[0].X, black[0].Y, white, black, fColor.white) == false)
                            {
                                ChessPieces checkB = ChessPieces.TypeOfPieces(black[0].X, black[0].Y, white, black, fColor.white);
                                int a = checkB.X;
                                int b = checkB.Y;

                                if (black[0].Mat(a,b,checkB,white,black,fColor.black))
                                {
                                    label1.Text = "MAT- zwycięstwo białych!";
                                }
                                if (!ChessPieces.AllowedMoves(x, y, black))
                                {
                                    return;
                                }
                                //ruch królem
                                if (black[c].fType == fType.king)
                                {
                                    if (!black[c].AllowedMoves(x, y, white, black, fColor.black, 1))
                                    {
                                        return;
                                    }
                                    if (ChessPieces.AllowedMovesKing(x, y, white, black, fColor.white))
                                    {
                                        Move_(x, y, o, i, fColor.black, 0, dragging);
                                        castleB = 1;
                                    }
                                }
                                //ruch inną figurą
                                if (!black[c].AllowedMoves(x, y, white, black, fColor.black, 0))
                                {
                                    return;
                                }
                                if (!black[c].Block(x, y, white, black, fColor.black, 1))
                                {
                                    return;
                                }
                                if (((x == a && y == b) == true || black[c].Cover(x, y, checkB, black[0], white, black) == true))
                                {
                                    Move_(x, y, o, i, fColor.black, 0, dragging);

                                }
                            }
                            //roszada
                            if (black[c].Symbol == "ke8" && castleB != 1)
                            {
                                for (int r = 0; r < black.Count; r++)
                                {
                                    if (black[r].Symbol == "rh8")
                                    {
                                        label7.Text = black[c].Castle(x, y, white, black, fColor.black).ToString();
                                        if (black[c].Castle(x, y, white, black, fColor.black) == true)
                                        {
                                            Position(x, y, o, i, fColor.black, dragging);
                                            Color_(x, y, fColor.black, dragging);
                                            castleB = 1;

                                            Position(x - 1, y, o, i - 1, fColor.black, r);
                                            Color_(x - 1, y, fColor.black, r);
                                            turn = 1;
                                            label2.Text = "Ruch białych.";
                                            MoveList(black[c].Symbol, x, y);
                                        }
                                    }
                                }
                                for (int r = 0; r < black.Count; r++)
                                {
                                    if (black[r].Symbol == "ra8")
                                    {
                                        label6.Text = black[c].CastleL(x, y, white, black, fColor.black).ToString();
                                        if (black[c].CastleL(x, y, white, black, fColor.black) == true)
                                        {
                                            Position(x, y, o, i, fColor.black, dragging);
                                            Color_(x, y, fColor.black, dragging);
                                            castleB = 1;

                                            Position(x + 1, y, o, i + 1, fColor.black, r);
                                            Color_(x + 1, y, fColor.black, r);
                                            turn = 1;
                                            label2.Text = "Ruch białych.";
                                            MoveList(black[c].Symbol, x, y);
                                        }
                                    }
                                }
                            }
                            if (!ChessPieces.AllowedMoves(x, y, black))
                            {
                                return;
                            }
                            //warunki na ruch królem
                            if (black[c].fType == fType.king)
                            {
                                if (!black[c].AllowedMoves(x, y, white, black, fColor.black, 1))
                                {
                                    return;
                                }                              
                                if (ChessPieces.AllowedMovesKing(x, y, white, black, fColor.white))
                                {
                                    Move_(x, y, o, i, fColor.black, 1, dragging);
                                    castleB = 1;
                                    
                                }
                            }
                            //wybrana figura nie jest królem
                            if (!black[c].Block(x, y, white, black, fColor.black, 0))
                            {
                                return;
                            }
                            if (black[c].AllowedMoves(x, y, white, black, fColor.black, 0))
                            {
                                Move_(x, y, o, i, fColor.black, 0, dragging);
                            }
                        }
                    }
                }
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
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            List<ChessPieces> chessPieces = new List<ChessPieces>()
            {
                new ChessPieces(5,1, fType.king, fColor.white, pictureBox23),
                new ChessPieces(4,1,fType.queen, fColor.white, pictureBox1),
                new ChessPieces(3,1,fType.bishop,fColor.white,pictureBox2),
                new ChessPieces(6,1,fType.bishop,fColor.white,pictureBox3),
                new ChessPieces(2,1,fType.knight,fColor.white,pictureBox4),
                new ChessPieces(7,1,fType.knight,fColor.white,pictureBox5),
                new ChessPieces(8,1,fType.rook,fColor.white,pictureBox6),
                new ChessPieces(1,1,fType.rook,fColor.white,pictureBox7),
                new ChessPieces(1,2,fType.pone,fColor.white,pictureBox8),
                new ChessPieces(2,2,fType.pone,fColor.white,pictureBox9),
                new ChessPieces(3,2,fType.pone,fColor.white,pictureBox17),
                new ChessPieces(4,2,fType.pone,fColor.white,pictureBox16),
                new ChessPieces(5,2,fType.pone,fColor.white,pictureBox15),
                new ChessPieces(6,2,fType.pone,fColor.white,pictureBox14),
                new ChessPieces(7,2,fType.pone,fColor.white,pictureBox13),
                new ChessPieces(8,2,fType.pone,fColor.white,pictureBox12),
            };
            List<ChessPieces> chessPiecesBlack = new List<ChessPieces>()
            {
                new ChessPieces(5,8,fType.king,fColor.black,pictureBox11),
                new ChessPieces(4,8,fType.queen,fColor.black,pictureBox10),
                new ChessPieces(3,8,fType.bishop,fColor.black,pictureBox26),
                new ChessPieces(6,8,fType.bishop,fColor.black,pictureBox25),
                new ChessPieces(2,8,fType.knight,fColor.black,pictureBox24),
                new ChessPieces(7,8,fType.knight,fColor.black,pictureBox22),
                new ChessPieces(8,8,fType.rook,fColor.black,pictureBox21),
                new ChessPieces(1,8,fType.rook,fColor.black,pictureBox20),
                new ChessPieces(1,7,fType.pone,fColor.black,pictureBox19),
                new ChessPieces(2,7,fType.pone,fColor.black,pictureBox18),
                new ChessPieces(3,7,fType.pone,fColor.black,pictureBox34),
                new ChessPieces(4,7,fType.pone,fColor.black,pictureBox33),
                new ChessPieces(5,7,fType.pone,fColor.black,pictureBox32),
                new ChessPieces(6,7,fType.pone,fColor.black,pictureBox31),
                new ChessPieces(7,7,fType.pone,fColor.black,pictureBox30),
                new ChessPieces(8,7,fType.pone,fColor.black,pictureBox29),
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
                white[i].Box.Visible = true;
                if (white[i].X % 2 != 0 && white[i].Y % 2 == 0 || white[i].X % 2 == 0 && white[i].Y % 2 != 0)
                {
                    white[i].Box.BackColor = light;
                }
                else { white[i].Box.BackColor = dark; }
            }
            for (int i = 0; i < black.Count; i++)
            {
                black[i].Box.Left = ChessPieces.Convertx(black[i].X - 1);
                black[i].Box.Top = ChessPieces.Converty(black[i].Y);
                black[i].Box.Visible = true;
                if (black[i].X % 2 != 0 && black[i].Y % 2 == 0 || black[i].X % 2 == 0 && black[i].Y % 2 != 0)
                {
                    black[i].Box.BackColor = light;
                }
                else { black[i].Box.BackColor = dark; }
            }
            counter = 0;
            turn = 1;
            label4.Text = moves[0];
            moves.Clear();
        }
        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            string path = @"C:\Users\Public\Chess\ZapisPartii.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {                
                foreach (string s in moves)
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(" " + s);
                    fs.Write(info, 0, info.Length);
                }   
            }
        }
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            char chess_type = moves.Last()[0];
            char horizontal = moves.Last()[1];
            int vertical = moves.Last()[2];
            int y = ChessPieces.ConvertToNumber(horizontal);
        }
        private void pictureBox1_Move(object sender, EventArgs e)
        {
            for (int i = 0; i < white.Count; i++)
            {
                if (white[i].Box == sender)
                {
                    label1.Text = white[i].GetType().Name;
                }
            }
        }
    }
}
