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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        int takenCoins;
        int meters;
        float elapsed;
        int coinStyle;
        Zapper zapper;
        Background background;
        Background background2;
        List<Coin> coinList;
        Barry barry;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundEffect myMusic;
        SoundEffectInstance soundEngineInstance;
        SpriteFont sf;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //Setting The Game To Full Screen
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            //  Initialazing Counting Variables
            meters = 0;
            takenCoins = 0;
            elapsed = 0;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loading Zapper
            int rnd2 = new Random().Next(0, graphics.GraphicsDevice.Viewport.Height - 200);
            zapper = new Zapper(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(graphics.GraphicsDevice.Viewport.Width-500, rnd2, 97, 263));

            //Loading Score Font
            sf = Content.Load<SpriteFont>("SpriteFont1");

            //Loading Barry
            barry = new Barry(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(200, 0, 100, 100));
            
            // Loading Backgrounds
            background = new Background(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));
            background2 = new Background(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(graphics.GraphicsDevice.Viewport.Width, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));

            //Loading Music
            myMusic = Content.Load<SoundEffect>("music");
            soundEngineInstance = myMusic.CreateInstance();

            //Loading Coins
            int rnd = new Random().Next(0, graphics.GraphicsDevice.Viewport.Height - 100);
            coinStyle = 0;
            coinList = Creator.createCoin(coinStyle, Content, graphics);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            
            //Play Background Music
            if (soundEngineInstance.State == SoundState.Stopped)
            {
                soundEngineInstance.Volume = 0.5f;
                soundEngineInstance.IsLooped = true;
                soundEngineInstance.Play();
            }
            else
                soundEngineInstance.Resume();


            //Coin Hit Check
            foreach (Coin coin in coinList)
            {
                if ((!coin.isHit) && ((barry.position.X > coin.position.X && barry.position.X < coin.getRight() && barry.getBottom() > coin.position.Y && barry.getBottom() < coin.getBottom())
                    || (barry.getRight() > coin.position.X && barry.getBottom() > coin.position.Y && barry.position.Y < coin.getBottom() && barry.position.X < coin.getRight())
                    || (barry.position.Y < coin.getBottom() && barry.position.X > coin.position.X && barry.position.X < coin.getRight() && barry.getBottom() > coin.position.Y)))
                {
                    coin.collision();
                    takenCoins++;
                }

            }

            //Score Calculation
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= 30)
            {
                meters++;
                elapsed = 0;
            }

            Updater(gameTime);
            base.Update(gameTime);
        }
        public void Updater(GameTime gameTime)
        {
            //Changing Coin Pattern
            if (coinList[coinList.Count - 1].isLeft())
            {
                if (coinStyle >= 5)
                {
                    coinStyle = 0;
                }
                else
                {
                    coinStyle++;
                }
                coinList = Creator.createCoin(coinStyle, Content, graphics);

            }

            //Barry Movement
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !barry.isTop())
            {
                Console.WriteLine("Down !Top: " + barry.isTop());
                barry.jump(gameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) && barry.isTop())
            {
                Console.WriteLine("Down Top: " + barry.isTop());
                barry.stop();
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Space) && !barry.isBottom())
            {
                Console.WriteLine("Up !Bottom: " + barry.isBottom());
                barry.fall(gameTime);
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.Space) && barry.isBottom())
            {
                Console.WriteLine("Up Bottom: " + barry.isBottom());
                barry.walk(gameTime);
            }

            //Movements
            foreach (Coin coin in coinList) coin.move(gameTime);
            background.move();
            zapper.move(gameTime, true);
            background.switchBack();
            background2.move();
            background2.switchBack();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            //Drawing Barry and Background
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            barry.drawBarry(spriteBatch);
            zapper.drawZapper(spriteBatch);
            background.drawBackground(spriteBatch);
            background2.drawBackground(spriteBatch);
            spriteBatch.End();

            //Taken Coins
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(sf, takenCoins.ToString(), new Vector2(20, 40), Color.Plum);
            spriteBatch.End();
            //Passed distance
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(sf, meters.ToString(), new Vector2(20, 10), Color.DarkRed);
            spriteBatch.End();

            //Drawing coins
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            foreach (Coin coin in coinList)
            {
                if (!coin.isHit)
                    coin.drawCoin(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
