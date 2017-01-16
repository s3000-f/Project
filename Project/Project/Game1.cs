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

        float elapsedMissile;
        int coinStyle;
        int gameMode;
        Score score;
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
        Missile missile;
        Color[] barryTextureData;
        Color[] zapperTextureData;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //Setting The Game To Full Screen
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {


            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loading Zapper
            int rnd2 = new Random().Next(0, graphics.GraphicsDevice.Viewport.Height - 200);
            zapper = new Zapper(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(graphics.GraphicsDevice.Viewport.Width - 500, rnd2, 97, 263));
            zapperTextureData = zapper.getTextureData();

            //Loading Score Font
            sf = Content.Load<SpriteFont>("SpriteFont1");

            //Loading Barry
            barry = new Barry(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(200, 0, 100, 100));
            barryTextureData = barry.getTextureData();

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


            //Loading Missile
            rnd = new Random().Next(0, graphics.GraphicsDevice.Viewport.Height - 100);
            missile = new Missile(Content, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height, 0, 0,
                new Rectangle(graphics.GraphicsDevice.Viewport.Width - 100, rnd, 100, 100));
            //Load Score
            score = new Score(Content);

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();
            if (gameMode == 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space)) gameMode = 1;
            }
            else if (gameMode == 1)
            {
                Updater(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.P)) gameMode = 2;
            }
            else if (gameMode == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.P)) gameMode = 1; ;
            }


            base.Update(gameTime);
        }
        public void Updater(GameTime gameTime)
        {
            Matrix barryTransform =
                Matrix.CreateTranslation(new Vector3(new Vector2(barry.position.X, barry.position.Y), 0.0f));
            Matrix zapperTransform =
                    Matrix.CreateTranslation(new Vector3(-new Vector2(zapper.position.Width / 2, zapper.position.Height / 2), 0.0f)) *
                    // Matrix.CreateScale(block.Scale) *  would go here
                    Matrix.CreateRotationZ(zapper.getRotation()) *
                    Matrix.CreateTranslation(new Vector3(new Vector2(zapper.position.X, zapper.position.Y), 0.0f));
            Rectangle zapperRectangle = Collision.CalculateBoundingRectangle(
                         new Rectangle(0, 0, zapper.position.Width, zapper.position.Height),
                         zapperTransform);
            Rectangle barryRectangle =
                new Rectangle((int)barry.position.X, (int)barry.position.Y,
                barry.position.Width, barry.position.Height);

            //Play Background Music
            if (soundEngineInstance.State == SoundState.Stopped)
            {
                soundEngineInstance.Volume = 0.5f;
                soundEngineInstance.IsLooped = true;
                //soundEngineInstance.Play();
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
                    score.gotCoins();
                }

            }

            //Missile Hit Check
            if ((!missile.isHit) && ((barry.position.X > missile.position.X && barry.position.X < missile.getRight() && barry.getBottom() > missile.position.Y && barry.getBottom() < missile.getBottom())
                                    || (barry.getRight() > missile.position.X && barry.getBottom() > missile.position.Y && barry.position.Y < missile.getBottom() && barry.position.X < missile.getRight())
                                    || (barry.position.Y < missile.getBottom() && barry.position.X > missile.position.X && barry.position.X < missile.getRight() && barry.getBottom() > missile.position.Y)))
            {
                missile.collision();
                score.writeHighScore();
                //if (meters > bestScore)
                //{
                //    File.writeFile("" + meters + "," + takenCoins);
                //}
                this.Exit();
            }



            //Zapper Hit Check
            if (barryRectangle.Intersects(zapperRectangle))
            {
                // Check collision with person
                if (Collision.IntersectPixels(barryTransform, barry.position.Width,
                                    barry.position.Height, barryTextureData,
                                    zapperTransform, zapper.position.Width,
                                    zapper.position.Height, zapperTextureData))
                {
                    score.writeHighScore();
                    //if(meters>bestScore)
                    //{
                    //    File.writeFile("" + meters + "," + takenCoins);
                    //}
                    this.Exit();
                }
            }

            //Score Calculation
            score.run(gameTime);
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
            Console.WriteLine("" + Math.Tan(Math.PI / 2));

            //Barry Movement
            barry.physics(gameTime);

            //Movements
            foreach (Coin coin in coinList) coin.move(gameTime);
            background.move();
            missile.move(gameTime);
            if (missile.nextGen < gameTime.TotalGameTime.TotalSeconds && !missile.isLeft())
            {
                if (elapsedMissile > 5000)
                {
                    missile.fire();
                }
                else if (elapsedMissile > 4000)
                {
                    elapsedMissile += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    missile.lockOn(gameTime);
                }
                else
                {
                    elapsedMissile += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    missile.load(new Vector2(barry.position.X, barry.position.Y), gameTime);
                }
            }
            else if(missile.isLeft())
            {
                missile.regenerate(gameTime);
                elapsedMissile = 0;
            }
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
            missile.drawMissile(spriteBatch);
            barry.drawBarry(spriteBatch);
            zapper.drawZapper(spriteBatch);

            background.drawBackground(spriteBatch);
            background2.drawBackground(spriteBatch);
            spriteBatch.End();

            //Taken Coins
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            score.drawCoinScore(spriteBatch);
            spriteBatch.End();

            ////Passed distance
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            score.drawScore(spriteBatch);
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
