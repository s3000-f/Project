using System;
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
    class Lazer : Moving
    {
        public bool isActive = false;
        public bool isDown = false;
        Random rnd;
        public float nextGen = 0;
        float elapsedFire;
        const float delay = 50f;
        public bool isHit = false;
        Rectangle srcRect;
        Texture2D lazer;
        ContentManager Content;
        int y = 0;
        public Lazer(ContentManager Content, int MaxX, int MaxY, int MinX, int MinY,int y, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {
            this.y = y;
            this.Content = Content;
            lazer = Content.Load<Texture2D>("lazer");
            rnd = new Random();
            srcRect = new Rectangle(0, 0, 1734, 162);

        }
        public int getRight()
        {
            return position.X + position.Width;
        }
        public int getBottom()
        {
            return position.Y + position.Height -10;
        }
        public void regenerate(GameTime gameTime)
        {
            nextGen = (float)gameTime.TotalGameTime.TotalSeconds + (float)(rnd.Next(7, 15));

        }
        public void turnOn(GameTime gameTime)
        {
            if (position.Y == y && !isDown)
            {
                elapsedFire += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (elapsedFire > 4000)
                {
                    elapsedFire = 0;
                    isDown = true;
                    isActive = false;
                }
                else if (elapsedFire > 3500)
                {
                    srcRect.Y = 0;
                }
                else if (elapsedFire > 2500)

                {
                    isActive = true;
                    srcRect.Y = 648;
                }
                else if (elapsedFire > 1500)
                {
                    srcRect.Y = 486;
                }
                else if (elapsedFire > 1000)
                {
                    srcRect.Y = 324;
                }
                else if (elapsedFire > 500)
                {
                    srcRect.Y = 162;
                }
                else
                {
                    srcRect.Y = 0;
                }
            }
            else if (!isDown && position.Y<y)
            {
                position.Y += 10;
            }
            else if (isDown && position.Y > -300)
            {
                position.Y -= 10;
            }
        }
        public void drawLazer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(lazer, position, srcRect, Color.White);
        }
    }
}