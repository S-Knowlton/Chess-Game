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
        Board board1;
        Board board2;
        Piece previousPiece;

        /*
         * Entry point of the program. Initializes everything 
         */
        public MainWindow()
        {

            InitializeComponent();
            InitLists();

            TwoPlayer.IsChecked = true;
            setup();


        }

        /*
         * Initializes the board, clears the previous selected pieces, sets the active player, updates the GUI
         */ 
        void setup()
        {
                Player p1 = new Player(1);
                Player p2 = new Player(2);
                App.Current.Properties["ActivePlayer"] = "White";

                board1 = new Board(p1, p2);
                board2 = new Board(board1);
                previousPiece = null;
                UpdateBoard(board1);
        }

        /*
         * Lists the textblocks
         * Hashes unicode chess characters by Piece subclass
         */ 
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
        /*
         * Updates the GUI to reflect the board passed in (this should be board1 throughout the program)
         */ 
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
                        blocks[i][j].Text = "  ";
                    }
                }
            }

            Thing.Text = (string)App.Current.Properties["ActivePlayer"];
        }

        /*
         * Outlines points to move to in red (GUI)
         */ 
        private void HighlightSpots(Piece p)
        {
            IEnumerable<Border> borders = MyGrid.Children.OfType<Border>();

            foreach (Border border in borders)
            {
                border.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            }

            // this is the default view
            if (p.player.GetID() == 2)
            {

                //Thing.Text = "clicked";
                List<System.Drawing.Point> endSpaces = p.getPossibleEndSpaces(board2);
                if (endSpaces != null)
                {
                    for (int i = 0; i < endSpaces.Count; i++)
                    {
                        Debug.WriteLine("x: " + endSpaces[i].X);
                        Debug.WriteLine("y: " + endSpaces[i].Y);
                        TextBlock current = blocks[7 - endSpaces[i].X][7 - endSpaces[i].Y];
                        Viewbox currentViewbox = (Viewbox)current.Parent;
                        Border currentBorder = (Border)currentViewbox.Parent;
                        SolidColorBrush tempBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                        currentBorder.BorderBrush = tempBrush;
                    }
                }
            }

            if (p.player.GetID() == 1)
            {

                //Thing.Text = "clicked";
                List<System.Drawing.Point> endSpaces = p.getPossibleEndSpaces(board1);

                if (endSpaces != null)
                {
                    for (int i = 0; i < endSpaces.Count; i++)
                    {
                        TextBlock current = blocks[endSpaces[i].X][endSpaces[i].Y];
                        Viewbox currentViewbox = (Viewbox)current.Parent;
                        Border currentBorder = (Border)currentViewbox.Parent;
                        SolidColorBrush tempBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
                        currentBorder.BorderBrush = tempBrush;
                    }
                }
            }
        }

        /*
         * Does operation to move a piece
         * Called on click. May or may not result in actual move
         * Triggers AI action if specified
         */ 
        private void MovePiece(Piece p)
        {

            if (previousPiece.player.GetID() == 1 && 
                (p.player.GetID() == 1 && p.position.X == previousPiece.position.X && p.position.Y == previousPiece.position.Y)) {
                clearBorders();
            }
            else if (previousPiece.player.GetID() == 2 &&
              (p.player.GetID() == 2 && p.position.X == previousPiece.position.X && p.position.Y == previousPiece.position.Y))
            {
                clearBorders();
            } 
            // check if piece can move to that place
            else if (previousPiece.player.GetID() == 1)
            {

                //if not the right player
                if ((string)App.Current.Properties["ActivePlayer"] == "Black")
                {
                    previousPiece = null;
                    clearBorders();
                    return;
                }

                List<System.Drawing.Point> endSpaces = previousPiece.getPossibleEndSpaces(board1);
                System.Drawing.Point piecePosition = p.position;
                if (p.player.GetID() == 2)
                {
                    piecePosition = new System.Drawing.Point(7 - p.position.X, 7 - p.position.Y);
                }

                if (endSpaces != null && endSpaces.Contains(piecePosition))
                {
                    // this move is allowed!

                    Move m = new Move(previousPiece.position, piecePosition);

                    Debug.WriteLine(board1.GetPieceAt(p.position));

                    board1.MakeMove(m);

                    clearBorders();
                    UpdateBoard(board1);

                    previousPiece = null;

                    //AI's turn
                    if (AI.IsChecked == true)
                    {
                        //wait 1 second TBI
                        AIStep();
                        UpdateBoard(board1);
                    }
                }
                else
                {
                    HighlightSpots(p);
                }
            }
            else if (previousPiece.player.GetID() == 2)
            {

                //if not the right player
                if ((string)App.Current.Properties["ActivePlayer"] == "White")
                {
                    previousPiece = null;
                    clearBorders();
                    return;
                }

                List<System.Drawing.Point> endSpaces = previousPiece.getPossibleEndSpaces(board2);
                System.Drawing.Point piecePosition = p.position;
                if (p.player.GetID() != 2)
                {
                    piecePosition = new System.Drawing.Point(7 - p.position.X, 7 - p.position.Y);
                }
                if (endSpaces != null && endSpaces.Contains(piecePosition))
                {
                    Move m = new Move(previousPiece.position, piecePosition);

                    board2.MakeMove(m);

                    clearBorders();
                }
                else
                {
                    HighlightSpots(p);
                }
            }
            else if (previousPiece.player.GetID() == 0)
            {
                HighlightSpots(p);
            }

            UpdateBoard(board1);
            previousPiece = null;

        }

        /*
         * Calls for AI to make its move
         */ 
        private void AIStep()
        {
            KyleAI ai = new KyleAI(this);

            Move aiMove = ai.GetMove(board2);

            if (null != aiMove)
            {
                board2.MakeMove(aiMove);
            }
            else
            {
                setup();
            }
        }

        /*
         * Resets all borders on the GUI
         */ 
        private void clearBorders()
        {
            IEnumerable<Border> borders = MyGrid.Children.OfType<Border>();

            foreach (Border border in borders)
            {
                border.BorderBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            }
        }

        /*
         * Handles any click on the GUI
         * Triggers movePiece if on highlighted textfield
         */ 
        private void a8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("I was clicked!");

            TextBlock s = (TextBlock) sender;
            Viewbox v = (System.Windows.Controls.Viewbox) s.Parent;
            Border b = (Border)v.Parent;
            int row = Grid.GetRow(b);

            // will have to subtract 1 from column
            int col = Grid.GetColumn(b) - 1;
            Debug.WriteLine("row is " + row);
            Debug.WriteLine("col is " + col);

            // get piece from board at this position
            Piece p = board1.GetPieceAt(new System.Drawing.Point(row, col));

            Debug.WriteLine(p);

            if (previousPiece == null || previousPiece is EmptyPiece)
            {
                HighlightSpots(p);
                previousPiece = p;
            }
            else
            {
                MovePiece(p);
            }
        }

        /*
         * Called by refresh button
         * Resets GUI, board, and active player
         */ 
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            setup();
        }

    }
}