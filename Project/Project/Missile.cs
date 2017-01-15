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
        public bool isHit = false, isLoading = true, isLocked = false;
        float rotation = 0;
        const float delay = 50f;
        int frames = 0;
        Texture2D missile;
        Texture2D locked;
        Texture2D loading;
        Rectangle sourceRec;
        ContentManager Content;

        public Missile(ContentManager Content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {
            this.Content = Content;
            missile = Content.Load<Texture2D>("missile");
            locked = Content.Load<Texture2D>("locked");
            loading = Content.Load<Texture2D>("loading1");

        }
        public void load(Vector2 barryPos,GameTime gameTime)
        {
            elapsed +=(float) gameTime.ElapsedGameTime.TotalMilliseconds;
            if(elapsed>300f)
            {
                elapsed = 0;

            }
            else
            {
                if(elapsed%300<150)
                {
                    loading = Content.Load<Texture2D>("loading1");
                }
                else
                {
                    loading = Content.Load<Texture2D>("loading2");
                }
            }
            int dY = position.Y - (int)barryPos.Y;
            if(dY!=0)
            {
                position.Y -= (dY / 80);
            }
        }
        public void lockOn()
        {
            isLoading = false;
            isLocked = true;
        }
        public void fire()
        {
            if(isLocked)
            {
                position.X += 100;
                position.Width += 100;
            }
            position.X -= 20;
            if (position.X + position.Width < 0) position.X = 1920;
            isLocked = false;
               
        }
        public void collision()
        {
            isHit = true;
        }
        public int getRight()
        {
            return position.X + position.Width;
        }

        public int getBottom()
        {
            return position.Y + position.Height;
        }
        public void drawMissile(SpriteBatch spriteBatch)
        {
            if (isLoading)
            {
                spriteBatch.Draw(loading, position, Color.White);
            }
            else if (isLocked)
            {
                spriteBatch.Draw(locked, position, Color.White);
            }
            else
            {
                spriteBatch.Draw(missile, position, Color.White);
            }

        }
    }
}
