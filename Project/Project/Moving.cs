using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Project
{
    class Moving
    {
        public Rectangle position;
        public int MaxX, MinX;
        public int MaxY, MinY;
        public Moving(int MaxX, int MaxY, int MinX, int MinY, Rectangle position)
        {
            this.MaxX = MaxX;
            this.MaxY = MaxY;
            this.MinX = MinX;
            this.MinY = MinY;
            this.position = position;
        }
        public virtual bool isTop()
        {
            if (position.Y <= 0) return true;
            else return false;
        }
        public virtual bool isBottom()
        {
            if (position.Y >= (MaxY - position.Height)) return true;
            else return false;
        }
        public virtual bool isLeft()
        {
            if (position.X <= 0) return true;
            else return false;
        }
        public bool isRight()
        {
            if (position.X >= (MaxX - position.Width)) return true;
            else return false;
        }
    }
}
