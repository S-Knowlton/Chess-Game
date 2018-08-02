using System;
using System.Collections.Generic;
using System.Drawing;
using ChessGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessGameUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Chess_Board_White_Setup_Test()
        {
            List<Type> pieces = new List<Type> { typeof(Rook), typeof(Knight), typeof(Bishop), typeof(Queen), typeof(King), typeof(Bishop), typeof(Knight), typeof(Rook) };
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(p1, p2, false);
            for (int i = 0; i < 8; i++)
            {
                Piece p = b.GetPieceAt(new Point(7, i));
                Assert.AreEqual(p.GetType(), pieces[i]);
            }
        }

        [TestMethod]
        public void Chess_Board_Black_Setup_Test()
        {
            List<Type> pieces = new List<Type> { typeof(Rook), typeof(Knight), typeof(Bishop), typeof(King), typeof(Queen), typeof(Bishop), typeof(Knight), typeof(Rook) };
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(p1, p2, false);
            for (int i = 0; i < 8; i++)
            {
                Piece p = b.GetPieceAt(new Point(0, i));
                Assert.AreEqual(p.GetType(), pieces[i]);
            }
        }

        [TestMethod]
        public void Chess960_Board_White_King_Setup_Test()
        {
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(p1, p2, true);
            int[] spots = GetWhitePositions(typeof(Rook), b.board);
            Assert.AreNotEqual(spots[1] - spots[0], 1);
            bool pass = false;
            for (int i = spots[0]+1; i < spots[1]; i++)
            {
                Piece p = b.GetPieceAt(new Point(7, i));
                if(p.GetType() == typeof(King))
                {
                    pass = true;
                }
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void Chess960_Board_Black_King_Setup_Test()
        {
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(p1, p2, true);
            int[] spots = GetBlackPositions(typeof(Rook), b.board);
            Assert.AreNotEqual(spots[1] - spots[0], 1);
            bool pass = false;
            for (int i = spots[0] + 1; i < spots[1]; i++)
            {
                Piece p = b.GetPieceAt(new Point(0, i));
                if (p.GetType() == typeof(King))
                {
                    pass = true;
                }
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void Chess960_Board_White_Bishop_Setup_Test()
        {
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(p1, p2, true);
            int[] spots = GetWhitePositions(typeof(Bishop), b.board);
            Assert.AreNotEqual(spots[0] % 2, spots[1] % 2);
        }

        [TestMethod]
        public void Chess960_Board_Black_Bishop_Setup_Test()
        {
            Player p1 = new Player(1);
            Player p2 = new Player(2);
            Board b = new Board(p1, p2, true);
            int[] spots = GetBlackPositions(typeof(Bishop), b.board);
            Assert.AreNotEqual(spots[0] % 2, spots[1] % 2);
        }

        private int[] GetWhitePositions(Type t, Piece[,] board)
        {
            int[] result = new int[2];
            int spot = 0;
            for (int j = 0; j < 8; j++)
            {
                if (board[7, j].GetType() == t)
                {
                    result[spot++] = j;
                }
            }
            return result;
        }
        private int[] GetBlackPositions(Type t, Piece[,] board)
        {
            int[] result = new int[2];
            int spot = 0;
            for (int j = 0; j < 8; j++)
            {
                if (board[0, j].GetType() == t)
                {
                    result[spot++] = j;
                }
            }
            return result;
        }
    }
}
