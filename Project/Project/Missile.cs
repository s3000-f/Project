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
    class Missile : Moving
    {
        float elapsed;
        public bool isHit = false;
        public Missile(ContentManager Content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {

        }
        public void loading(Vector2 barryPos)
        {

        }
        public void lockOn()
        {

        }
        public void fire()
        {

        }
        public void collision()
        {

        }
    }
}
