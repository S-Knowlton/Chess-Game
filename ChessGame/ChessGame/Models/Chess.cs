using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChessGame.Models
{
    public class Chess
    {
        public List<List<TextBlock>> Blocks { get; set; }
        public Dictionary<Type, string> BlackPieces { get; set; }
        public Dictionary<Type, string> WhitePieces { get; set; }
        public Board Board1 { get; set; }
        public Board Board2 { get; set; }
        public Piece PreviousPiece { get; set; }

        public Chess(List<List<TextBlock>> blocks)
        {
            Blocks = blocks;

            BlackPieces = new Dictionary<Type, string>();

            BlackPieces.Add(typeof(Pawn), "\u265f");
            BlackPieces.Add(typeof(Knight), "\u265e");
            BlackPieces.Add(typeof(Bishop), "\u265d");
            BlackPieces.Add(typeof(Rook), "\u265c");
            BlackPieces.Add(typeof(Queen), "\u265b");
            BlackPieces.Add(typeof(King), "\u265a");

            WhitePieces = new Dictionary<Type, string>();

            WhitePieces.Add(typeof(Pawn), "\u2659");
            WhitePieces.Add(typeof(Knight), "\u2658");
            WhitePieces.Add(typeof(Bishop), "\u2657");
            WhitePieces.Add(typeof(Rook), "\u2656");
            WhitePieces.Add(typeof(Queen), "\u2655");
            WhitePieces.Add(typeof(King), "\u2654");
        }


    }
}
