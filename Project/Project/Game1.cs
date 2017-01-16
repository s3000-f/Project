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
        float elapsedMissile;
        int coinStyle;
        int bestScore;
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
            //Get Best Score
            if ((File.readFile() != null))
            {
                List<string[]> scores = File.readFile();
                if (scores.Count != 0)
                    bestScore = Int32.Parse(scores[scores.Count - 1][0]);
                else
                    bestScore = 0;
            }
            else bestScore = 0;
                
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

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
                    takenCoins++;
                }

            }

            //Missile Hit Check
            if ((!missile.isHit) && ((barry.position.X > missile.position.X && barry.position.X < missile.getRight() && barry.getBottom() > missile.position.Y && barry.getBottom() < missile.getBottom())
                                    || (barry.getRight() > missile.position.X && barry.getBottom() > missile.position.Y && barry.position.Y < missile.getBottom() && barry.position.X < missile.getRight())
                                    || (barry.position.Y < missile.getBottom() && barry.position.X > missile.position.X && barry.position.X < missile.getRight() && barry.getBottom() > missile.position.Y)))
            {
                missile.collision();
                if (meters > bestScore)
                {
                    File.writeFile("" + meters + "," + takenCoins);
                }
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
                    if(meters>bestScore)
                    {
                        File.writeFile("" + meters + "," + takenCoins);
                    }
                    this.Exit();
                }
            }

            //Score Calculation
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsed >= 60)
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
            Console.WriteLine("" + Math.Tan(Math.PI / 2));

            //Barry Movement
            barry.physics(gameTime);

            //Movements
            foreach (Coin coin in coinList) coin.move(gameTime);
            background.move();
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
