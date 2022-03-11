using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomProjectChess;

namespace CustomGUI
{
    public partial class Form1 : Form
    {
        static Board myBoard = new Board(8);
        public Button[,] buttonGrid = new Button[myBoard.Size, myBoard.Size];
        public string pieceChosen;
        public Form1()
        {
            InitializeComponent();
            FillGrid();
        }
        private void FillGrid()
        {
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    buttonGrid[i, j] = new Button();
                    buttonGrid[i, j].Width = buttonSize;
                    buttonGrid[i, j].Height = buttonSize;
                    buttonGrid[i, j].Click += ClickOnGridButton;
                    panel1.Controls.Add(buttonGrid[i, j]);
                    buttonGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    buttonGrid[i, j].Text = "Pick me";
                    buttonGrid[i, j].Tag = new Point(i, j);
                }
            }
        }
        public void ClickOnGridButton(object sender, EventArgs e)
        {
            Button clickedB = (Button ) sender;
            Point location = (Point ) clickedB.Tag;

            int a = location.X;
            int b = location.Y;

            Cell currentC = myBoard.Grid[a, b];

            myBoard.markNextLegal(currentC, pieceChosen);

            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    buttonGrid[i, j].Text = "";
                    buttonGrid[i, j].BackColor = Color.White;
                    if (myBoard.Grid[i, j].LegalNext == true)
                    {
                        buttonGrid[i, j].Text = "Legal";
                        buttonGrid[i, j].BackColor = Color.LightYellow;
                    }
                     else if (myBoard.Grid[i, j].Occupied == true)
                    {
                        buttonGrid[i, j].Text = pieceChosen;
                        buttonGrid[i, j].BackColor = Color.PaleVioletRed;
                    }
                }
            }


            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = comboBox1.SelectedIndex;
            switch (t)
            {
                case 0:
                    pieceChosen = "King";
                    break;
                case 1:
                    pieceChosen = "Queen";
                    break;
                case 2:
                    pieceChosen = "Bishop";
                    break;
                case 3:
                    pieceChosen = "Knight";
                    break;
                case 4:
                    pieceChosen = "Rook";
                    break;
            }
        }
    }
}
