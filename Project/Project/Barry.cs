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
    class Barry : Moving
    {
        Texture2D barry;
        //  Rectangle position;
        Vector2 recSpeed;
        Vector2 recAcc;
        Vector2 gravity;
        Rectangle srcRect;
        float elapsedWalk = 0;
        float elapsedAir = 0;
        ContentManager Content;

        public Barry(ContentManager content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {

            this.Content = content;
            barry = Content.Load<Texture2D>("Barry");
            srcRect = new Rectangle(0, 0, 56, 58);
            recSpeed = Vector2.Zero;
            recAcc = new Vector2(0f, 0.5f);
            gravity = new Vector2(0f, 0.5f);
        }

        public void physics(GameTime gameTime)
        {

            if (position.Y >= 50 && position.Y <= MaxY-170) // this big if is for when exactly shetab and gravity should occur
            {
                if (position.Y == MaxY-170) // this is for animating ground barry
                    walk(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.Space)) // this is for shetab roo be bala , it should the key is down 
                {
                    // this is for animating air barry
                        jump();
                    if (recSpeed.Y < 15) // this is the speed cap, if speed is lower than 15, the gravity will increse the speed
                        recSpeed.Y += recAcc.Y;

                }
                if (Keyboard.GetState().IsKeyUp(Keys.Space) && position.Y != MaxY - 170) // this is for gravity, it should happen when the key isnt pressed
                {
                     //this is for animating air barry
                        fall();
                    if (recSpeed.Y > -10) // this is the seed cap 
                        recSpeed.Y -= gravity.Y;

                }
                position.Y -= (int)recSpeed.Y; // this will move barry with dar nazar gereftan recSpeedesh
            }
            else if (position.Y < 50) //if barry hits the roof , this will make his speed 0 and will ajdust it's positionition
            {
                position.Y = 50;
                recSpeed.Y = 0;
            }
            else if (position.Y > MaxY-170) // if barry hits the ground, this will make his speed 0 and adjust it's positionition
            {
                position.Y = MaxY-170;
                recSpeed.Y = 0;
            }
        }

        public void walk(GameTime gameTime)
        {
            barry = Content.Load<Texture2D>("runAnim");
            elapsedWalk += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedWalk > 200f)
            {
                elapsedWalk = 0;

            }
            else
            {
                if (elapsedWalk % 200 < 100)
                {
                    srcRect.X = 0;
                }
                else
                {
                    srcRect.X = 56;
                }
            }
        }
        
        public void jump()
        {
            barry = Content.Load<Texture2D>("barry_air");
            srcRect.X = 0;
        }
        public void fall()
        {
            barry = Content.Load<Texture2D>("barry_air");
            srcRect.X = 56;
        }

        public override bool isBottom()
        {
            if (position.Y >= (MaxY - position.Height - 55)) return true;
            else return false;
        }
        public override bool isTop()
        {
            if (position.Y <= 55) return true;
            else return false;
        }
        public void stop()
        {
            recSpeed.Y = 0;
            recSpeed.X = 0;
            position.Y = 55;
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
            Color[] c = new Color[barry.Width * barry.Height];
            barry.GetData(c);
            return c;
        }
        public void die()
        {

        }
        public void drawBarry(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barry, position, srcRect, Color.White);
        }

    }
}