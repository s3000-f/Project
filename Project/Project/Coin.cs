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
    class Coin : Moving
    {
        public bool isHit = false;
        Texture2D coin;
        Rectangle sourceRec;
        Vector2 recSpeed;
        Vector2 recAcc;
        ContentManager Content;
        //asdasdasd
        SoundEffect collisSound;
        SoundEffectInstance se_Instance;

        public Coin(ContentManager content, int MaxX, int MaxY, int MinX, int MinY, Rectangle position) : base(MaxX, MaxY, MinX, MinY, position)
        {

            this.Content = content;
            coin = Content.Load<Texture2D>("coin");
            sourceRec = new Rectangle(0, 0, 52, 52);
            recSpeed = Vector2.Zero;
            recAcc = new Vector2(0f, 0.01f);
        }

        public void move()
        {
                position.X -= 10;
            if (position.X + MaxX - 5 < 0)
                position.X = MaxX;
        }
        public void collision()
        {
            collisSound = Content.Load<SoundEffect>("coinSound");
            se_Instance = collisSound.CreateInstance();
            se_Instance.Volume = 0.75f;
            se_Instance.IsLooped = false;
            se_Instance.Play();
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
        public void drawCoin(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(coin, position, Color.White);

        }

    }
}
