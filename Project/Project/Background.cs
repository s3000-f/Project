﻿using System;
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
    class Background : Moving
    {
        Texture2D backGround;
   
        Vector2 recSpeed;
        Vector2 recAcc;
        ContentManager Content;

        public Background(ContentManager content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {

            this.Content = content;
            backGround = Content.Load<Texture2D>("back");
            recSpeed = Vector2.Zero;
            recAcc = new Vector2(0f, 0.01f);
        }
        public void move()
        {
            position.X -= 10;
        }
        public void switchBack()
        {
            if (position.X + MaxX-5 < 0)
                position.X = MaxX;
        }

        public void drawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, position, Color.White);
        }

    }
}