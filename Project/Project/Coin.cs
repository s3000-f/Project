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
    class Coin : Moving
    {
        float elapsed;
        const float delay = 100f;
        int frames = 0;
        public bool isHit = false;
        Texture2D coin;
        Rectangle sourceRec;
        ContentManager Content;
        SoundEffect collisSound;
        SoundEffectInstance se_Instance;

        public Coin(ContentManager content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {

            this.Content = content;
            coin = Content.Load<Texture2D>("coins");
        }

        public void move(GameTime gameTime)
        {
            //Coin Rotation
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= delay)
            {
                if (frames >= 7)
                    frames = 0;
                else
                    frames++;
                elapsed = 0;
            }
            sourceRec = new Rectangle(52 * frames, 0, 52, 52);
            //Movement
            position.X -= Background.speed;
            if (position.X + MaxX < 0)
                position.X = MaxX;
        }
        public void collision(bool issfx)
        {
            //Collision Sound
            if(issfx)
            {
                collisSound = Content.Load<SoundEffect>("coinSound");
                se_Instance = collisSound.CreateInstance();
                se_Instance.Volume = 0.75f;
                se_Instance.IsLooped = false;
                se_Instance.Play();
            }
            

            //Collision Flag
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
        public Color[] getTextureData()
        {
            Color[] c = new Color[coin.Width * coin.Height];
            coin.GetData(c);
            return c;
        }
        public void drawCoin(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(coin, position, sourceRec, Color.White);

        }

    }
}
