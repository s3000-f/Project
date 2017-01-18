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
    class SuperSpeed : Moving
    {
        float elapsedSin=0;
        public float nextGen = 0;
        const float delay = 100f;
        public bool isHit = false;
        Random rnd = new Random();
        Texture2D superSpeed;
        ContentManager Content;
        public SuperSpeed(ContentManager Content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {
            this.Content = Content;
            superSpeed = Content.Load<Texture2D>("superSpeed");
        }
        public void move(GameTime gameTime)
        {
            position.X -= Background.speed / 2;
            if(elapsedSin/1000>(float)Math.PI*2)
            {
                elapsedSin = 0;
            }
            else
            {
                elapsedSin += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            position.Y = (int)(Math.Sin((double)elapsedSin/1000)*400)+540;
        }
        public void regenerate(GameTime gameTime)
        {
            position.X = MaxX + 200;
            position.Y = rnd.Next(50, MaxY - 170);
            nextGen = (float)gameTime.TotalGameTime.TotalSeconds + (float)(rnd.Next(5, 10));

        }
        public override bool isLeft()
        {
            if (position.X + position.Width < 0)
                return true;
            else return false;

        }
        public void drawSuperSpeed(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(superSpeed, position, Color.White);
        }
    }
}
