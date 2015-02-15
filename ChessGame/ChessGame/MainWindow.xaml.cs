using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace ChessGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<List<TextBlock>> blocks;
        Dictionary<Type, string> blackPieces;
        Dictionary<Type, string> whitePieces;

        public MainWindow()
        {

            InitializeComponent();
            InitLists();


            Player p1 = new Player(1);
            Player p2 = new Player(2);

            Board board1 = new Board(p1, p2);
            UpdateBoard(board1);
        }

        void InitLists()
        {
            blocks = new List<List<TextBlock>>();

            blocks.Add(new List<TextBlock> {
                a8, b8, c8, d8, e8, f8, g8, h8
            });

            blocks.Add(new List<TextBlock> {
                a7, b7, c7, d7, e7, f7, g7, h7
            });

            blocks.Add(new List<TextBlock> {
                a6, b6, c6, d6, e6, f6, g6, h6
            });

            blocks.Add(new List<TextBlock> {
                a5, b5, c5, d5, e5, f5, g5, h5
            });

            blocks.Add(new List<TextBlock> {
                a4, b4, c4, d4, e4, f4, g4, h4
            });

            blocks.Add(new List<TextBlock> {
                a3, b3, c3, d3, e3, f3, g3, h3
            });

            blocks.Add(new List<TextBlock> {
                a2, b2, c2, d2, e2, f2, g2, h2
            });

            blocks.Add(new List<TextBlock> {
                a1, b1, c1, d1, e1, f1, g1, h1
            });

            blackPieces = new Dictionary<Type, string>();

            blackPieces.Add(typeof(Pawn), "\u265f");
            blackPieces.Add(typeof(Knight), "\u265e");
            blackPieces.Add(typeof(Bishop), "\u265d");
            blackPieces.Add(typeof(Rook), "\u265c");
            blackPieces.Add(typeof(Queen), "\u265b");
            blackPieces.Add(typeof(King), "\u265a");

            whitePieces = new Dictionary<Type, string>();

            whitePieces.Add(typeof(Pawn), "\u2659");
            whitePieces.Add(typeof(Knight), "\u2658");
            whitePieces.Add(typeof(Bishop), "\u2657");
            whitePieces.Add(typeof(Rook), "\u2656");
            whitePieces.Add(typeof(Queen), "\u2655");
            whitePieces.Add(typeof(King), "\u2654");
        }

        public void UpdateBoard(Board b)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    System.Drawing.Point p = new System.Drawing.Point(i, j);

                    // change this to GetPlayerAt when implemented
                    if (b.GetPieceAt(p).player.GetID() == 1)
                    {
                        Type t = b.GetPieceAt(p).GetType();
                        blocks[i][j].Text = whitePieces[t];
                    }
                    else if (b.GetPieceAt(p).player.GetID() == 2)
                    {
                        Type t = b.GetPieceAt(p).GetType();
                        blocks[i][j].Text = blackPieces[t];
                    }
                    else if (b.GetPieceAt(p).player.GetID() == 0)
                    {
                        blocks[i][j].Text = "";
                    }
                }
            }
        }

        private void a8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock s = (TextBlock)sender;
            Viewbox v = (System.Windows.Controls.Viewbox)s.Parent;
            Border b = (Border)v.Parent;
            int row = Grid.GetRow(b);

            // will have to subtract 1 from column
            int col = Grid.GetColumn(b) - 1;

            // get piece from board at this position
            Piece p;

            // add checks for correct player
        }

        private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

    }
}