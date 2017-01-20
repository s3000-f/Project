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
    class Background : Moving
    {
        public static int speed = 10;
        public Texture2D backGround;
        Vector2 recSpeed;
        Vector2 recAcc;
        ContentManager Content;

        public Background(ContentManager content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {

            this.Content = content;
            backGround = Content.Load<Texture2D>("background\\1");
        }
        public void move()
        {
            position.X -= speed;
        }
        private void load(int bgCounter)
        {
            Console.WriteLine("bg --> "+bgCounter);
            backGround = Content.Load<Texture2D>("background\\" + bgCounter);
            
        }
        public bool switchBack(int x,int count)
        {
            
            if (position.X + backGround.Width < 0)
            {
                load(count);
                position.X = x;
                return true;
            }
            return false;
        }

        public void drawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, position, Color.White);
        }

    }
}
