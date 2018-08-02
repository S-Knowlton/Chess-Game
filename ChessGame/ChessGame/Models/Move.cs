﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    /*
     * Contains two points: start, and end, repsectively (referring to points on a board)
     */ 
    public class Move
    {

        public Move(Point s, Point e)
        {
            Start = s;
            End = e;
        }

        public Point Start
        {
            get;
            set;

        }
        public Point End
        {
            get;
            set;
        }

    }
}
