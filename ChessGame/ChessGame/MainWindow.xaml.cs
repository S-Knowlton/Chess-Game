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

            Player p1 = new Player(1);
            Player p2 = new Player(2);

            Board board1 = new Board(p1, p2);
            board1.PrintBoard();

            System.Console.WriteLine("\n\n");

            Board board2 = new Board(board1);
            board2.PrintBoard();

            InitLists();
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

            blackPieces.Add(typeof(Pawn), "&#9823;");
            blackPieces.Add(typeof(Knight), "&#9822;");
            blackPieces.Add(typeof(Bishop), "&#9821;");
            blackPieces.Add(typeof(Rook), "&#9820;");
            blackPieces.Add(typeof(Queen), "&#9819;");
            blackPieces.Add(typeof(King), "&#9818;");

            whitePieces = new Dictionary<Type, string>();

            whitePieces.Add(typeof(Pawn), "&#9817;");
            whitePieces.Add(typeof(Knight), "&#9816;");
            whitePieces.Add(typeof(Bishop), "&#9815;");
            whitePieces.Add(typeof(Rook), "&#9814;");
            whitePieces.Add(typeof(Queen), "&#9813;");
            whitePieces.Add(typeof(King), "&#9812;");
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
                        blocks[i][j].Text = whitePieces[t];
                    }
                    else if (b.GetPieceAt(p).player.GetID() == 0)
                    {
                        blocks[i][j].Text = "";
                    }
                }
            }
        }
    }
}