using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    public class Board
    {
        public Piece[,] board;
        Board observer;
        public Player P1 { get; set; }
        public Player P2 { get; set; }

        /*
         * Initializes the board with a new set of pieces
         */
        public Board(Player p1, Player p2, bool isChess960)
        {
            P1 = p1;
            P2 = p2;

            board = new Piece[8, 8];
            if (!isChess960)
            {
                SetupChess();
            }
            else
            {
                SetupChess960();
            }
        }

        /*
         * Constructor for the second board in the symmetrical observer pattern. Either board
         * notifies the other if it is changed.
         */
        public Board(Board b)
        {
            observer = b;
            b.observer = this;

            board = new Piece[8, 8];

            //generate flipped board (opponent's perspective)
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece tempPiece = b.GetPieceAt(new Point(i, j));

                    board[7 - i, 7 - j] = tempPiece;

                    //set piece positions for their respective boards
                    if (tempPiece.player.GetID() != 2)
                    {
                        tempPiece.SetPosition(new Point(i, j));
                    }
                    else
                    {
                        tempPiece.SetPosition(new Point(7 - i, 7 - j));
                    }
                }
            }
        }

        /*
         * Returns true if the point is on the board. False otherwise
         */
        public bool pointExists(Point p)
        {
            if (p.X > 7 || p.Y > 7 || p.X < 0 || p.Y < 0)
            {
                return false;
            }
            return true;
        }

        /*
         * Called when the board is changed. Fundamental to the symmetrical observer pattern
         */
        void changed()
        {
            //update observer board without calling setPieceAt
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    observer.board[7 - i, 7 - j] = GetPieceAt(new Point(i, j));
                }
            }
        }

        /*
         * Returns where the parameter piece is located on the board
         */
        public Point GetPiecePosition(Piece p)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Object.ReferenceEquals(board[i, j], p))
                    {
                        return new Point(i, j);
                    }
                }
            }
            throw new Exception("Piece not found on board");
        }

        /*
         * Returns the piece at a specific point on the board.
         */
        public Piece GetPieceAt(Point p)
        {
            return board[p.X, p.Y];
        }

        /*
         * Called when the board needs to move pieces around. 
         * Moves pieces
         * Switches the active player
         * Calls changed()
         */
        public void MakeMove(Move m)
        {
            Point start = m.Start;
            Point end = m.End;
            Piece firstPiece = board[start.X, start.Y];

            EmptyPiece tempEmptyPiece = new EmptyPiece();

            if (firstPiece.player.GetID() == 2)
            {
                tempEmptyPiece.position = new Point(7 - start.X, 7 - start.Y);
            }
            else
            {
                tempEmptyPiece.position = new Point(start.X, start.Y);
            }

            board[start.X, start.Y] = tempEmptyPiece;
            board[end.X, end.Y] = firstPiece;

            firstPiece.position = new Point(end.X, end.Y);

            if ((string)App.Current.Properties["ActivePlayer"] == "White")
            {
                App.Current.Properties["ActivePlayer"] = "Black";
            }
            else
            {
                App.Current.Properties["ActivePlayer"] = "White";
            }

            changed();
        }

        /* For debugging purposes
          
        public void PrintBoard(){
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    System.Console.Write(board[i, j] + " ");
                }
                System.Console.WriteLine("");
            }
        }
        */

        /// <summary>
        /// Places pieces on the board in the normal places.
        /// </summary>
        private void SetupChess()
        {
            //player 1 (white)
            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new Pawn(P1);
            }
            board[7, 0] = new Rook(P1);
            board[7, 1] = new Knight(P1);
            board[7, 2] = new Bishop(P1);
            board[7, 3] = new Queen(P1);
            board[7, 4] = new King(P1);
            board[7, 5] = new Bishop(P1);
            board[7, 6] = new Knight(P1);
            board[7, 7] = new Rook(P1);

            //player 2 (black)
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn(P2);
            }
            board[0, 0] = new Rook(P2);
            board[0, 1] = new Knight(P2);
            board[0, 2] = new Bishop(P2);
            board[0, 3] = new King(P2);
            board[0, 4] = new Queen(P2);
            board[0, 5] = new Bishop(P2);
            board[0, 6] = new Knight(P2);
            board[0, 7] = new Rook(P2);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (null == board[i, j])
                    {
                        board[i, j] = new EmptyPiece();
                    }
                }
            }
        }

        /// <summary>
        /// Places pieces on the board in random places adhering to Chess 960 rules.
        /// </summary>
        private void SetupChess960()
        {
            Random rand = new Random();
            List<int> positions = new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7 };
            List<Piece> pieces = new List<Piece> { new Queen(P1), new Knight(P1), new Knight(P1) };
            //player 1 (white)
            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new Pawn(P1);
            }

            int num = positions[rand.Next(positions.Count)];
            positions.Remove(num);
            board[7, num] = new Rook(P1);
            int num2 = 0;
            bool loop = true;
            while (loop)
            {
                num2 = positions[rand.Next(positions.Count)];
                if (num2 - num > 1 || num - num2 > 1)
                {
                    positions.Remove(num2);
                    board[7, num2] = new Rook(P1);
                    loop = false;
                }
            }
            if(num > num2)
            {
                int n = rand.Next(num2 + 1, num);
                board[7, n] = new King(P1);
                positions.Remove(n);
            }
            else
            {
                int n = rand.Next(num + 1, num2);
                board[7, n] = new King(P1);
                positions.Remove(n);
            }
            num = positions[rand.Next(positions.Count)];
            positions.Remove(num);
            board[7, num] = new Bishop(P1);
            num2 = 0;
            loop = true;
            while (loop)
            {
                num2 = positions[rand.Next(positions.Count)];
                if (num % 2 != num2 % 2)
                {
                    positions.Remove(num2);
                    board[7, num2] = new Bishop(P1);
                    loop = false;
                }
            }



            while (positions.Count > 0)
            {
                int temp = positions[rand.Next(positions.Count)];
                positions.Remove(temp);
                board[7, temp] = pieces.First();
                pieces.RemoveAt(0);
            }







            ////int temp = rand.Next(num + 1, num2);
            ////board[7, temp] = new King(P1);
            //loop = true;
            //while (loop)
            //{
            //    num2 = rand.Next(4, 8);
            //    if (board[7, num2] == null && (num % 2 != num2 % 2) && (num2 - num > 1|| num - num2 > 1))
            //    {
            //        board[7, num2] = new Bishop(P1);
            //        loop = false;
            //    }
            //}

            //player 2 (black)
            positions = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            pieces = new List<Piece> { new Queen(P2), new Knight(P2), new Knight(P2) };
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn(P2);
            }
            num = positions[rand.Next(positions.Count)];
            positions.Remove(num);
            board[0, num] = new Rook(P2);
            num2 = 0;
            loop = true;
            while (loop)
            {
                num2 = positions[rand.Next(positions.Count)];
                if (num2 - num > 1 || num - num2 > 1)
                {
                    positions.Remove(num2);
                    board[0, num2] = new Rook(P2);
                    loop = false;
                }
            }
            if (num > num2)
            {
                int n = rand.Next(num2 + 1, num);
                board[0, n] = new King(P2);
                positions.Remove(n);
            }
            else
            {
                int n = rand.Next(num + 1, num2);
                board[0, n] = new King(P2);
                positions.Remove(n);
            }
            num = positions[rand.Next(positions.Count)];
            positions.Remove(num);
            board[0, num] = new Bishop(P2);
            num2 = 0;
            loop = true;
            while (loop)
            {
                num2 = positions[rand.Next(positions.Count)];
                if (num % 2 != num2 % 2)
                {
                    positions.Remove(num2);
                    board[0, num2] = new Bishop(P2);
                    loop = false;
                }
            }

            while (positions.Count > 0)
            {
                int temp = positions[rand.Next(positions.Count)];
                positions.Remove(temp);
                board[0, temp] = pieces.First();
                pieces.RemoveAt(0);
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (null == board[i, j])
                    {
                        board[i, j] = new EmptyPiece();
                    }
                }
            }
        }
    }
}
