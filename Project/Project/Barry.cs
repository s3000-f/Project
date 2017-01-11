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
    class Barry : Moving
    {
        Texture2D barry;
      //  Rectangle position;
        Vector2 recSpeed;
        Vector2 recAcc;
        ContentManager Content;
       
        public Barry(ContentManager content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {

            this.Content = content;
            //this.position = new Rectangle(200, 0, 100, 100);
            barry = Content.Load<Texture2D>("Barry");
            recSpeed = Vector2.Zero;
            recAcc = new Vector2(0f, 0.01f);
        }
       
        public void jump(GameTime gameTime)
        {
            if (isBottom())
                position.Y = MaxY - position.Height;
            if (position.Y < 0)
                position.Y = 0;
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds/4f;
            Console.WriteLine("Time: " + time);
            if(recSpeed.Y>-5)
            {
                if (recSpeed.Y > 0)
                {
                    recSpeed.Y += -(recAcc.Y + 0.015f) * time;
                }
                else
                {
                    recSpeed += -recAcc * time;
                }
            }
            
            position.X +=(int)( recSpeed.X * time);
            position.Y += (int)(recSpeed.Y * time);
            
        }
        public void fall(GameTime gameTime)
        {
            if (position.Y < 0)
                position.Y = 0;
            if (isBottom())
                position.Y = MaxY-position.Height;
            float time =(float) gameTime.ElapsedGameTime.TotalMilliseconds/4f;
            Console.WriteLine("Time: " + time);
            if (recSpeed.Y < 5)
            {
                if (recSpeed.Y < 0)
                {
                    recSpeed.Y += (recAcc.Y + 0.015f) * time;
                }
                else
                {
                    recSpeed.Y += recAcc.Y * time;
                }
            }
            position.X += (int)(recSpeed.X * time);
            position.Y += (int)(recSpeed.Y * time);
        }

        public void walk(GameTime gameTime)
        {
            recSpeed.Y = 0;
            recSpeed.X = 0;
            position.Y = MaxY-position.Height;
            if ((gameTime.TotalGameTime.Milliseconds / 70) % 2 == 0)
            {
                barry = Content.Load<Texture2D>("Barry");
          
            }
            else
            {
                barry = Content.Load<Texture2D>("Barry2");
            }
        }

        public void stop()
        {
            recSpeed.Y = 0;
            recSpeed.X = 0;
            position.Y = 0;
        }

        public int getRight()
        {
            return position.X + position.Width;
        }

        public int getBottom()
        {
            return position.Y + position.Height;
        }
        public void drawBarry(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barry, position, Color.White);
        }

    }
}