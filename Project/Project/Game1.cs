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
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            meters = 0;
            takenCoins = 0;
            elapsed = 0;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //sf=Content.Load<SpriteFont>("arial")
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sf = Content.Load<SpriteFont>("SpriteFont1");
            barry = new Barry(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(200, 0, 100, 100));
            background = new Background(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));
            background2 = new Background(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(graphics.GraphicsDevice.Viewport.Width, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height));
            myMusic = Content.Load<SoundEffect>("music");
            soundEngineInstance = myMusic.CreateInstance();
            int rnd = new Random().Next(0, graphics.GraphicsDevice.Viewport.Height - 100);
            coinStyle = 0;
            coinList = Creator.createCoin(coinStyle, Content, graphics);

            //for (int i = 0; i < 200; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        coinList.Add(new Coin(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0, 
            //            new Rectangle(300 + i * 65, rnd + j * 55, 50, 50)));
            //    }
            //}




            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            // TODO: Add your update logic here

            if (soundEngineInstance.State == SoundState.Stopped)
            {
                soundEngineInstance.Volume = 0.5f;
                soundEngineInstance.IsLooped = true;
                soundEngineInstance.Play();
            }
            else
                soundEngineInstance.Resume();
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
            foreach (Coin coin in coinList) coin.move(gameTime);
            if(coinList[coinList.Count-1].isLeft())
            {
                if(coinStyle>3)
                {
                    coinStyle = 0;
                }
                else
                {
                    coinStyle++;
                }
               // coinList.RemoveAll();
                coinList = Creator.createCoin(coinStyle, Content, graphics);

            }
            background.move();
            background.switchBack();
            background2.move();
            background2.switchBack();
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            barry.drawBarry(spriteBatch);
            background.drawBackground(spriteBatch);
            background2.drawBackground(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(sf, takenCoins.ToString(), new Vector2(20, 40), Color.Plum);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.DrawString(sf, meters.ToString(), new Vector2(20, 10), Color.DarkRed);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            foreach (Coin coin in coinList)
            {
                if (!coin.isHit)
                    coin.drawCoin(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
