﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Project
{
    class PowerUp : Moving
    {
        Texture2D powerUp;
        Random rnd = new Random();
        ContentManager Content;
        Rectangle srcRect;
        float elapsed;
        public float nextGen;
        public PowerUp(ContentManager Content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {
            this.Content = Content;
            powerUp = Content.Load<Texture2D>("power");
            srcRect = new Rectangle(0, 0, 132, 132);
        }
        public void move(GameTime gameTime)
        {
            position.X -= Background.speed;
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(elapsed>60f)
            {
                elapsed = 0;
            }
            else 
            {
                if (elapsed % 60 > 30)
                {
                    srcRect.X = 0;
                }
                else
                {
                    srcRect.X = 132;
                }
            }
        }
        public void regenerate(GameTime gameTime)
        {
            position.X = MaxX;
            position.Y = rnd.Next(50, MaxY - 170);
            nextGen = (float)gameTime.TotalGameTime.TotalSeconds + (float)(rnd.Next(7, 16));

        }
        public void drawPowerUp(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(powerUp, position, srcRect, Color.White);
        }
    }
}