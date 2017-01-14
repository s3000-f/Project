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
    class Zapper : Moving
    {
        float elapsed;
        float rotation=0;
        const float delay = 50f;
        int frames = 0;
        public bool isHit = false;
        Texture2D zapper;
        Rectangle sourceRec;
        ContentManager Content;

        public Zapper(ContentManager Content,int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {
            this.Content = Content;
            this.zapper = Content.Load<Texture2D>("zappers");
        }
        public void move(GameTime gameTime, bool isRotating, float angle = 0)
        {
            //Vibration Animation
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frames >= 3)
                    frames = 0;
                else
                    frames++;
                elapsed = 0;
            }
            sourceRec = new Rectangle(97 * frames, 0, 97, 263);
            
            //Movement
            position.X -= 10;
            if (isLeft()) position.X = MaxX;

            //Rotation
            if (isRotating)
            {
                
                    elapsedRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    rotation += (float)Math.PI / 50f;
                    if (rotation >= 2 * (float)Math.PI) rotation -= 2 * (float)Math.PI;
                
            }
            else rotation = angle;
            
        }
        public int getRight()
        {
            return position.X + position.Width;
        }

        public int getBottom()
        {
            return position.Y + position.Height;
        }
        public void drawZapper(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(zapper, position, sourceRec, Color.White, rotation, new Vector2(position.Width / 2, position.Height / 2), new SpriteEffects(), 0f);
        }
    }
}
