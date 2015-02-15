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
        Piece[,] board;
        Board observer;

        public Board(Player p1, Player p2){
            board = new Piece[8,8];

            //player 1 (white)
            for (int i = 0; i < 8; i++)
            {
                board[6, i] = new Pawn(p1);
            }
            board[7, 0] = new Rook(p1);
            board[7, 1] = new Knight(p1);
            board[7, 2] = new Bishop(p1);
            board[7, 3] = new Queen(p1);
            board[7, 4] = new King(p1);
            board[7, 5] = new Bishop(p1);
            board[7, 6] = new Knight(p1);
            board[7, 7] = new Rook(p1);

            //player 2 (black)
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn(p2);
            }
            board[0, 0] = new Rook(p2);
            board[0, 1] = new Knight(p2);
            board[0, 2] = new Bishop(p2);
            board[0, 3] = new King(p2);
            board[0, 4] = new Queen(p2);
            board[0, 5] = new Bishop(p2);
            board[0, 6] = new Knight(p2);
            board[0, 7] = new Rook(p2);

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

        public bool pointExists(Point p)
        {
            if (p.X > 7 || p.Y > 7 || p.X < 0 || p.Y < 0)
            {
                return false;
            }
            return true;
        }

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

        public Board(Board b)
        {
            observer = b;
            b.observer = this;

            board = new Piece[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Piece tempPiece = b.GetPieceAt(new Point(i, j));

                    board[7 - i, 7- j] = tempPiece;

                    //set piece positions for their respective boards
                    if(tempPiece.player.GetID() != 2)
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

        public void SetPieceAt(Point p, Piece piece)
        {
            board[p.X, p.Y] = piece;
            changed();
        }

        public Piece GetPieceAt(Point p)
        {
            return board[p.X, p.Y];
        }

        int GetPlayerAt(Point p){
            return 0;
        }

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
    }
}
