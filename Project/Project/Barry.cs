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
        public bool isGravityActive = false;
        bool b = true;//mozakhrafe jahat e shetab dar gravity
        bool c = true;//mozakhrafe jahat e soraate dar gravity
        bool isRotationUp = false;
        float elapsedDeath;
        public bool isDead = false;
        bool wasDead = false;
        bool wasFallen = false;
        bool finalDeath = false;
        Vector2 recSpeed;
        Vector2 recAcc;
        Vector2 gravity;
        Rectangle srcRect;
        float elapsedWalk = 0;
        float elapsedAir = 0;
        ContentManager Content;
        KeyboardState oldState;
        MouseState oldMouseState;
        public Barry(ContentManager content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {
            this.Content = content;
            oldState = Keyboard.GetState();
            oldMouseState = Mouse.GetState();
            barry = Content.Load<Texture2D>("Barry");
            srcRect = new Rectangle(0, 0, 56, 58);
            recSpeed = Vector2.Zero;
            recAcc = new Vector2(0f, 0.5f);
            gravity = new Vector2(0f, 0.5f);
        }

        public void physics(GameTime gameTime, bool isSpeedy)
        {
            if (isSpeedy)
            {
                moveOver();
            }
            else
                moveBack();

            if (isGravityActive)
            {

                if (isDead)
                {
                    isDead = false;
                    isGravityActive = false;
                }
                else
                {

                    if (position.Y >= 50 && position.Y <= MaxY - 170) // this big if is for when exactly shetab and gravity should occur
                    {


                        if (position.Y == MaxY - 170) // this is for animating ground barry
                            walkDown(gameTime);
                        else if (position.Y == 50)
                            walkUp(gameTime);
                        if ((Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Up) || Mouse.GetState().LeftButton == ButtonState.Pressed) && (oldState.IsKeyUp(Keys.Space) && oldState.IsKeyUp(Keys.Up) && oldMouseState.LeftButton == ButtonState.Released))
                        {
                            if (isRotationUp)
                            {
                                isRotationUp = false;
                                walkUp(gameTime);
                            }
                            else
                            {
                                isRotationUp = true;
                                walkDown(gameTime);
                            }
                        }
                        if (!isRotationUp && position.Y < MaxY - 170)
                            position.Y += 35;
                        else if (isRotationUp && position.Y > 50)
                            position.Y -= 35;
                    }
                    else if (position.Y < 50) //if barry hits the roof , this will make his speed 0 and will ajdust it's positionition
                    {
                        position.Y = 50;
                        recSpeed.Y = 0;
                    }
                    else if (position.Y > MaxY - 170) // if barry hits the ground, this will make his speed 0 and adjust it's positionition
                    {
                        position.Y = MaxY - 170;
                        recSpeed.Y = 0;
                    }
                    oldState = Keyboard.GetState();
                    oldMouseState = Mouse.GetState();
                }
            }
            else
            {
                if (position.Y >= 50 && position.Y <= MaxY - 170) // this big if is for when exactly shetab and gravity should occur
                {
                    if (position.Y == MaxY - 170 && !isDead) // this is for animating ground barry
                        walk(gameTime);
                    else if (position.Y == MaxY - 170 && isDead)
                    {
                        if (elapsedDeath < 100f)
                        {
                            elapsedDeath += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                            fallen();
                        }
                        else
                        {
                            finalDeath = true;
                        }
                    }
                    if ((!isDead) && (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.Up) || Mouse.GetState().LeftButton == ButtonState.Pressed))// this is for shetab roo be bala , it should the key is down 
                    {
                        // this is for animating air barry
                        jump();
                        if (recSpeed.Y < 15) // this is the speed cap, if speed is lower than 15, the gravity will increse the speed
                            recSpeed.Y += recAcc.Y;

                    }
                    if (isDead || (Keyboard.GetState().IsKeyUp(Keys.Space) && Keyboard.GetState().IsKeyUp(Keys.Up) && Mouse.GetState().LeftButton == ButtonState.Released && position.Y != MaxY - 170)) // this is for gravity, it should happen when the key isnt pressed
                    {
                        //this is for animating air barry
                        if (!isDead) fall();
                        else
                            fallToDeath();
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
                else if (position.Y > MaxY - 170) // if barry hits the ground, this will make his speed 0 and adjust it's positionition
                {
                    position.Y = MaxY - 170;
                    recSpeed.Y = 0;
                }
            }

        }
        public void walkUp(GameTime gameTime)
        {
            barry = Content.Load<Texture2D>("gravityUp");
            srcRect.Height = 130;
            srcRect.Width = 95;
            elapsedWalk += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedWalk > 30f)
            {
                elapsedWalk = 0;
                if (srcRect.X > 569)
                    srcRect.X = 0;
                else
                {
                    srcRect.X += 95;
                }
            }


        }
        public void walkDown(GameTime gameTime)
        {
            barry = Content.Load<Texture2D>("gravityDown");
            srcRect.Height = 130;
            srcRect.Width = 95;
            elapsedWalk += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedWalk > 30f)
            {
                elapsedWalk = 0;
                if (srcRect.X > 569)
                    srcRect.X = 0;
                else
                {
                    srcRect.X += 95;
                }
            }
        }
        public bool rotateUp(GameTime gameTime)
        {
            barry = Content.Load<Texture2D>("gravityDownUp");
            srcRect.Height = 127;
            srcRect.Width = 104;
            elapsedWalk += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedWalk > 15f)
            {
                elapsedWalk = 0;
                if (srcRect.X > 520)
                {
                    srcRect.X = 0;
                    return true;
                }

                else
                {
                    srcRect.X += 104;
                }
            }
            return false;
        }
        public bool rotateDown(GameTime gameTime)
        {
            barry = Content.Load<Texture2D>("gravityUpDown");
            srcRect.Height = 127;
            srcRect.Width = 104;
            elapsedWalk += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedWalk > 15f)
            {
                elapsedWalk = 0;
                if (srcRect.X > 520)
                {
                    srcRect.X = 0;
                    return false;
                }

                else
                {
                    srcRect.X += 104;
                }
            }
            return true;
        }

        public void moveOver()
        {
            if (Background.speed < 150)
            {
                Background.speed = 150;
            }
            if (position.X < 1600)
            {
                position.X += 30;
            }
            gravity.Y = 0.05f;
            recAcc.Y = 0.05f;
        }
        public void moveBack()
        {
            if (Background.speed > 10)
            {
                Background.speed = 10;
            }
            if (position.X > 200 && !isDead)
            {
                position.X -= 30;
            }
            gravity.Y = 0.5f;
            recAcc.Y = 0.5f;
        }
        public void walk(GameTime gameTime)
        {
            barry = Content.Load<Texture2D>("runAnim");
            srcRect.Width = 56;
            srcRect.Height = 58;
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
            srcRect.Width = 56;
            srcRect.Height = 58;
            srcRect.X = 0;
        }
        public void fall()
        {
            barry = Content.Load<Texture2D>("barry_air");
            srcRect.Width = 56;
            srcRect.Height = 58;
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
        public int die()
        {
            // elapsedDeath += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //if(elapsedDeath>=)
            if (finalDeath)
            {
                barry = Content.Load<Texture2D>("dead");
                srcRect.Width = 56;
                srcRect.Height = 58;
                return 3;
            }

            else return 1;
        }
        private void fallToDeath()
        {
            if (!wasDead)
            {
                wasDead = true;
                barry = Content.Load<Texture2D>("deadFall");
                srcRect.Width = 56;
                srcRect.Height = 58;
                srcRect.X = 0;

            }
            position.X += 5;

        }
        private void fallen()
        {
            if (!wasFallen)
            {
                wasFallen = true;
                barry = Content.Load<Texture2D>("deadHit");
                srcRect.Width = 56;
                srcRect.Height = 58;
                srcRect.X = 0;
            }

        }
        public void drawBarry(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barry, position, srcRect, Color.White);
        }

    }
}