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
    class Zapper : Moving
    {
        bool isRotating;
        Random rnd;
        public float nextGen = 0;
        float elapsed;
        float elapsedOverlay;
        float rotation = 0;
        const float delay = 50f;
        int frames = 0;
        public bool isHit = false;
        Texture2D zapper;
        Texture2D zapperOverlay;
        Rectangle sourceRec;
        ContentManager Content;

        public Zapper(ContentManager Content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {
            rnd = new Random();
            this.Content = Content;
            this.zapper = Content.Load<Texture2D>("zappers");
            zapperOverlay = Content.Load<Texture2D>("zapped00");

        }
        public void move(GameTime gameTime)
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
            position.X -= Background.speed;

            //Rotation
            if (isRotating)
            {

                rotation += (float)Math.PI / 50f;
                if (rotation >= (float)Math.PI) rotation -= (float)Math.PI;

            }

        }
        public override bool isLeft()
        {
            if (position.X + position.Width < 0)
                return true;
            else return false;

        }
        public float getRotation()
        {
            return rotation;
        }
        public void regenerate(GameTime gameTime)
        {
            isHit = false;
            position.X = MaxX + 200;
            position.Y = rnd.Next(50, MaxY - 170);
            int i = rnd.Next(0, 3);
            switch (i)
            {
                case 0:
                    rotation = 0;
                    break;
                case 1:
                    rotation = (float)Math.PI / 4f;
                    break;
                case 2:
                    rotation = (float)Math.PI / 2f;
                    break;
            }
            i = (rnd.Next(0, 2));
            if (i == 1) isRotating = true;
            else isRotating = false;
            nextGen = (float)gameTime.TotalGameTime.TotalSeconds + (float)(rnd.Next(1, 5));

        }

        SoundEffect collisSound;
        SoundEffectInstance se_Instance;

        public void collision(bool issfx)
        {
            //Collision Sound
            if (issfx)
            {
                collisSound = Content.Load<SoundEffect>("zap");
                se_Instance = collisSound.CreateInstance();
                se_Instance.Volume = 0.75f;
                se_Instance.IsLooped = false;
                se_Instance.Play();
            }


            //Collision Flag
            isHit = true;

        }

        public Color[] getTextureData()
        {
            Color[] c = new Color[zapper.Width * zapper.Height];
            zapper.GetData(c);
            return c;
        }
        public void screenZap(GameTime gameTime)
        {
            if (isHit)
            {
                if (elapsedOverlay > 100f)
                {
                    zapperOverlay = Content.Load<Texture2D>("zapped00");
                }
                else if (elapsedOverlay > 70f)
                {
                    elapsedOverlay += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    zapperOverlay = Content.Load<Texture2D>("zapped50");
                }
                else if (elapsedOverlay > 35f)
                {
                    elapsedOverlay += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    zapperOverlay = Content.Load<Texture2D>("zapped70");
                }
                else
                {
                    elapsedOverlay += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    zapperOverlay = Content.Load<Texture2D>("zapped90");
                }
            }
        }
        public void drawZapper(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(zapper, position, sourceRec, Color.White, rotation, new Vector2(position.Width / 2, position.Height / 2), new SpriteEffects(), 0f);
            spriteBatch.Draw(zapperOverlay, Vector2.Zero, Color.White);
        }
    }
}
